Imports System.Windows.Automation
Imports System.Threading
Imports Newtonsoft.Json.Linq
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Public Class ClassUI

    <DllImport("user32.dll")>
    Private Shared Function SetCursorPos(x As Integer, y As Integer) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Sub mouse_event(dwFlags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As IntPtr)
    End Sub

    Private Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2
    Private Const MOUSEEVENTF_LEFTUP As UInteger = &H4

    Public Sub AutomateWhatsAppCallSetup(phoneNumber As String, preferredApp As String)
        ' 1. Buka protokol
        OpenWhatsAppProtocol(phoneNumber)

        ' 2. UI Automation membaca popup dan memilih WhatsApp
        ' Jika Anda ingin mengotomatiskan "Always use this app", Anda bisa menemukan checkbox dan mengklik-nya sebelum OK
        SelectWhatsAppApp(preferredApp)

        ' 3. Lakukan klik OK
        ClickOkButton()

        Console.WriteLine("Automation sequence completed. Check for WhatsApp chat window.")

        ' 4. (Opsional) Memverifikasi Tampilan Chat dan Tombol Panggilan
        ' Bagian ini lebih kompleks dan spesifik untuk struktur internal jendela WhatsApp itu sendiri.
        ' Anda perlu menggunakan inspect.exe pada jendela WhatsApp yang terbuka untuk mengidentifikasi
        ' properti elemen-elemen seperti tombol "Call".
        ' Contoh sederhana (hanya mencari jendela WhatsApp berdasarkan ProcessId jika Anda tahu ID-nya):
        ' Dim whatsappProcess() As Process = Process.GetProcessesByName("WhatsApp") ' Atau nama proses yang sesuai
        ' If whatsappProcess.Length > 0 Then
        '     Dim whatsappChatWindow As AutomationElement = Nothing
        '     Dim chatWindowAttempts As Integer = 10
        '     For i As Integer = 0 To chatWindowAttempts - 1
        '         whatsappChatWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, _
        '             New PropertyCondition(AutomationElement.ProcessIdProperty, whatsappProcess(0).Id))
        '         If whatsappChatWindow IsNot Nothing Then Exit For
        '         Thread.Sleep(1000)
        '     Next
        '
        '     If whatsappChatWindow IsNot Nothing Then
        '         Console.WriteLine("WhatsApp chat window found.")
        '         ' Di sini Anda bisa menambahkan logika untuk mencari tombol "Call" di dalam whatsappChatWindow
        '         ' Contoh: Dim callButton As AutomationElement = whatsappChatWindow.FindFirst(TreeScope.Descendants, New PropertyCondition(AutomationElement.NameProperty, "Call"))
        '         ' If callButton IsNot Nothing Then Console.WriteLine("Call button found!") Else Console.WriteLine("Call button not found.")
        '     Else
        '         Console.WriteLine("WhatsApp chat window not found.")
        '     End If
        ' Else
        '     Console.WriteLine("WhatsApp process not found.")
        ' End If
    End Sub

    Private Sub OpenWhatsAppProtocol(phoneNumber As String)
        Try
            Dim uri As String = $"whatsapp://send?phone={phoneNumber}"
            Process.Start(New ProcessStartInfo(uri) With {.UseShellExecute = True})
            Thread.Sleep(10000)  ' Beri waktu untuk popup muncul
        Catch ex As Exception
            Console.WriteLine($"Error opening WhatsApp protocol: {ex.Message}")
        End Try
    End Sub

    Private Sub SelectWhatsAppApp(appToSelect As String)
        Dim popupWindow As AutomationElement = Nothing
        Dim maxAttempts As Integer = 10
        Dim attempt As Integer = 0

        ' Tunggu hingga jendela popup muncul
        While popupWindow Is Nothing AndAlso attempt < maxAttempts
            Console.WriteLine($"Attempt {attempt + 1}: Looking for popup window...")
            popupWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
        New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, "How do you want to open this?"),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)
        ))
            If popupWindow Is Nothing Then
                Thread.Sleep(500) ' Kurangi delay dalam loop pencarian menjadi 0.5 detik
            End If
            attempt += 1
        End While

        If popupWindow Is Nothing Then
            Console.WriteLine("Popup window 'How do you want to open this?' not found.")
            Return
        End If

        Console.WriteLine("Popup window found. Searching for list item...")

        ' Temukan elemen daftar
        Dim listElement As AutomationElement = popupWindow.FindFirst(TreeScope.Children,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List))

        If listElement Is Nothing Then
            Console.WriteLine("List element not found within the popup window.")
            Return
        End If

        Console.WriteLine("List element found. Searching for specific WhatsApp item...")

        ' Temukan item daftar yang sesuai (WhatsApp atau WhatsApp Beta)
        Dim whatsappListItem As AutomationElement = listElement.FindFirst(TreeScope.Children,
            New AndCondition(
                New PropertyCondition(AutomationElement.NameProperty, appToSelect),
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)
            ))

        If whatsappListItem Is Nothing Then
            Console.WriteLine($"'{appToSelect}' list item not found.")
            Return
        End If

        Console.WriteLine($"'{appToSelect}' list item found. Invoking select pattern...")

        ' Lakukan Select (setara dengan klik 1 kali)
        Dim selectPattern As SelectionItemPattern = TryCast(whatsappListItem.GetCurrentPattern(SelectionItemPattern.Pattern), SelectionItemPattern)
        If selectPattern IsNot Nothing Then
            selectPattern.Select()
            Console.WriteLine($"Selected '{appToSelect}'.")
            Thread.Sleep(500) ' Beri sedikit waktu setelah memilih
        Else
            Console.WriteLine($"SelectionItemPattern not supported for '{appToSelect}'. Trying InvokePattern (double click alternative).")
            ' Jika SelectPattern tidak tersedia (jarang), coba InvokePattern
            Dim invokePattern As InvokePattern = TryCast(whatsappListItem.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            If invokePattern IsNot Nothing Then
                invokePattern.Invoke() ' Ini bisa setara dengan double click tergantung elemennya
                Console.WriteLine($"Invoked '{appToSelect}'.")
                Thread.Sleep(500)
            Else
                Console.WriteLine($"Neither SelectionItemPattern nor InvokePattern supported for '{appToSelect}'. Manual interaction might be needed.")
            End If
        End If
    End Sub

    Private Sub ClickOkButton()
        Dim popupWindow As AutomationElement = Nothing
        Dim maxAttempts As Integer = 5
        Dim attempt As Integer = 0

        ' Cari kembali jendela popup (karena mungkin hilang jika Anda menggunakan InvokePattern langsung pada list item)
        While popupWindow Is Nothing AndAlso attempt < maxAttempts
            popupWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                New AndCondition(
                    New PropertyCondition(AutomationElement.NameProperty, "How do you want to open this?"),
                    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)
                ))
            If popupWindow Is Nothing Then
                Thread.Sleep(500)
            End If
            attempt += 1
        End While

        If popupWindow Is Nothing Then
            Console.WriteLine("Popup window not found for clicking OK button. It might have closed automatically.")
            Return
        End If

        Dim okButton As AutomationElement = popupWindow.FindFirst(TreeScope.Children,
            New AndCondition(
                New PropertyCondition(AutomationElement.NameProperty, "OK"),
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
            ))

        If okButton IsNot Nothing Then
            Console.WriteLine("OK button found. Invoking click...")
            Dim invokePattern As InvokePattern = TryCast(okButton.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            If invokePattern IsNot Nothing Then
                invokePattern.Invoke()
                Console.WriteLine("OK button clicked.")
                Thread.Sleep(2000) ' Beri waktu untuk WhatsApp terbuka
            Else
                Console.WriteLine("InvokePattern not supported for OK button.")
            End If
        Else
            Console.WriteLine("OK button not found.")
        End If
    End Sub


    Public Function GetWAProfileInfoAsJson() As JObject
        Dim result As New JObject()
        Dim processes = Process.GetProcessesByName("WhatsApp")
        If processes.Length = 0 Then
            result.Add("nama", "")
            result.Add("nomer", "")
            result.Add("photo", "tidak ada")
            Return result
        End If

        Dim mainWindow = AutomationElement.FromHandle(processes(0).MainWindowHandle)

        ' Cari popup profil
        Dim popup As AutomationElement = Nothing
        For i = 1 To 10
            popup = mainWindow.FindFirst(TreeScope.Descendants,
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window))
            If popup IsNot Nothing Then Exit For
            Threading.Thread.Sleep(500)
        Next

        If popup Is Nothing Then
            result.Add("nama", "")
            result.Add("nomer", "")
            result.Add("photo", "tidak ada")
            Return result
        End If

        ' Cari semua teks
        Dim texts = popup.FindAll(TreeScope.Descendants,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text))

        Dim nama As String = ""
        Dim nomer As String = ""
        Dim adaFoto As Boolean = False

        For i As Integer = 0 To texts.Count - 1
            Dim ele = texts(i)
            Dim content = ele.Current.Name

            If content = "Phone number" AndAlso i + 1 < texts.Count Then
                nomer = texts(i + 1).Current.Name
            End If

            If i > 0 AndAlso texts(i - 1).Current.Name = "Edit Name" Then
                nama = content
            End If
        Next

        ' Cek apakah ada elemen foto profil (biasanya ControlType.Image)
        Dim img = popup.FindFirst(TreeScope.Descendants,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Image))
        adaFoto = img IsNot Nothing

        result.Add("nama", nama)
        result.Add("nomer", nomer)
        result.Add("photo", If(adaFoto, "ada", "tidak ada"))

        Return result
    End Function


End Class
