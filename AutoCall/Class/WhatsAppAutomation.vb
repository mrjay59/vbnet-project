Imports System
Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Automation

Public Class WhatsAppAutomation


    ' Konstanta yang sudah ada
    Const WHATSAPP_SHORTCUT_NAME As String = "WhatsApp"
    Const WHATSAPP_MAIN_WINDOW_NAME As String = "WhatsApp"
    Const CALL_ICON_NAME As String = "Calls"
    Const CALL_NUMBER_BUTTON_NAME As String = "Call a number"
    Const PHONE_NUMBER_POPUP_HOST_NAME As String = "PopupHost"
    Const PHONE_NUMBER_POPUP_TITLE_INSIDE As String = "Phone number"
    Const PHONE_NUMBER_EDIT_FIELD_NAME As String = "Enter phone number"
    Const VOICE_CALL_BUTTON_NAME As String = "Voice call" ' Nama ini untuk tombol di pop-up, bukan di chat window
    Const CHAT_AUDIO_CALL_BUTTON_NAME As String = "Voice call"
    Const CHAT_VIDEO_CALL_BUTTON_NAME As String = "Video call"


    ' --- Deklarasi Fungsi Windows API (P/Invoke) ---
    <DllImport("user32.dll", SetLastError:=True)>
    Private Shared Function SetCursorPos(x As Integer, y As Integer) As Boolean
    End Function

    <DllImport("user32.dll")>
    Private Shared Sub mouse_event(dwFlags As UInteger, dx As UInteger, dy As UInteger, dwData As UInteger, dwExtraInfo As IntPtr)
    End Sub

    <DllImport("user32.dll", SetLastError:=True)> Private Shared Function SetWindowPos(ByVal hWnd As IntPtr, ByVal hWndInsertAfter As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal uFlags As UInteger) As Boolean
    End Function

    ' Deklarasi P/Invoke
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function FindWindow(ByVal lpClassName As String, ByVal lpWindowName As String) As IntPtr
    End Function

    ' Konstanta untuk ShowWindow
    Private Const SW_RESTORE As Integer = 9 ' Mengaktifkan dan menampilkan jendela jika minimal

    ' Deklarasi ShowWindow
    <DllImport("user32.dll")>
    Private Shared Function ShowWindow(ByVal hWnd As IntPtr, ByVal nCmdShow As Integer) As Boolean
    End Function

    Private Const SWP_SHOWWINDOW As UInteger = &H40
    Private Const HWND_NOTOPMOST As Integer = -2
    Private Const HWND_TOPMOST As Integer = -1
    ' Konstanta untuk mouse_event flags
    Private Const MOUSEEVENTF_LEFTDOWN As UInteger = &H2 ' Left button down
    Private Const MOUSEEVENTF_LEFTUP As UInteger = &H4   ' Left button up


    Public Sub AutomateWhatsAppCallDirect(phoneNumber As String)
        Console.WriteLine($"Attempting to open WhatsApp chat directly for {phoneNumber}...")
        OpenWhatsAppProtocol(phoneNumber)

        Console.WriteLine("Waiting for WhatsApp chat window to appear...")
        Dim whatsappChatWindow As AutomationElement = FindWhatsAppChatWindowByPhoneNumber(phoneNumber)

        If whatsappChatWindow IsNot Nothing Then
            Console.WriteLine("WhatsApp chat window found. Looking for Call button...")

            Dim windowPattern As WindowPattern = TryCast(whatsappChatWindow.GetCurrentPattern(WindowPattern.Pattern), WindowPattern)
            If windowPattern IsNot Nothing Then
                windowPattern.SetWindowVisualState(WindowVisualState.Normal)
                Thread.Sleep(500)
            End If


            Dim callButton As AutomationElement = FindCallButtonInWhatsAppChat(whatsappChatWindow)

            If callButton IsNot Nothing Then
                Console.WriteLine("Call button found. Clicking it...")
                Console.WriteLine($"DEBUG: Call Button Name: '{callButton.Current.Name}'")
                Console.WriteLine($"DEBUG: Call Button ControlType: {callButton.Current.ControlType}")
                Console.WriteLine($"DEBUG: Call Button IsEnabled: {callButton.Current.IsEnabled}")
                Console.WriteLine($"DEBUG: Call Button IsOffscreen: {callButton.Current.IsOffscreen}")

                Dim invokePattern As InvokePattern = Nothing
                Try
                    invokePattern = TryCast(callButton.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
                    invokePattern.Invoke()
                Catch ex As Exception
                    Console.WriteLine($"Error saat mencoba mendapatkan InvokePattern: {ex.Message}. Ini kemungkinan normal untuk 'Unsupported Pattern'.")
                End Try

                If invokePattern IsNot Nothing Then
                    Console.WriteLine("InvokePattern didukung. Mencoba mengklik tombol via InvokePattern.")
                    Try
                        invokePattern.Invoke()
                        Console.WriteLine("Call button clicked successfully via InvokePattern.")
                    Catch ex As Exception
                        Console.WriteLine($"Error saat InvokePattern.Invoke(): {ex.Message}. Beralih ke klik mouse.")
                        PerformMouseClick(callButton)
                    End Try
                Else
                    Console.WriteLine("InvokePattern tidak didukung untuk Call button. Mencoba klik mouse sebagai gantinya.")
                    PerformMouseClick(callButton)
                End If
            Else
                Console.WriteLine("Call button not found in the WhatsApp chat window.")
                Console.WriteLine("Please use inspect.exe to identify the 'Name' and 'ControlType' of the Call button.")
            End If
        Else
            Console.WriteLine("WhatsApp chat window not found after opening protocol. Automation failed.")
        End If
    End Sub

    ''' <summary>
    ''' Melakukan simulasi klik mouse pada AutomationElement menggunakan GetClickablePoint() dengan retry.
    ''' </summary>
    ''' <param name="element">AutomationElement yang akan diklik.</param>
    Private Sub PerformMouseClick(element As AutomationElement)
        Try
            If Not element.Current.IsEnabled Then
                Console.WriteLine("WARNING: Tombol tidak aktif (IsEnabled = false). Tidak dapat diklik.")
                Return
            End If
            If element.Current.IsOffscreen Then
                Console.WriteLine("WARNING: Tombol berada di luar layar (IsOffscreen = true). Tidak dapat diklik.")
                Return
            End If

            ' *** PERBAIKAN DI SINI: Panggil element.SetFocus() langsung ***
            Try
                element.SetFocus()
                Console.WriteLine("DEBUG: SetFocus attempted on the button.")
                Thread.Sleep(200) ' Beri waktu agar fokus diterapkan
            Catch ex As Exception
                Console.WriteLine($"DEBUG: Error trying to set focus or SetFocus not supported: {ex.Message}")
            End Try

            Dim clickablePoint As System.Windows.Point
            Dim maxRetries As Integer = 10
            Dim retryCount As Integer = 0
            Dim pointFound As Boolean = False

            Do While Not pointFound AndAlso retryCount < maxRetries
                Try
                    clickablePoint = element.GetClickablePoint()
                    pointFound = True
                Catch ex As NoClickablePointException
                    Console.WriteLine($"DEBUG: Percobaan {retryCount + 1}/{maxRetries}: {ex.Message}. Mencoba lagi...")
                    Thread.Sleep(750)
                    retryCount += 1
                Catch ex As Exception
                    Console.WriteLine($"Terjadi kesalahan tidak terduga saat mendapatkan ClickablePoint: {ex.Message}")
                    Exit Do
                End Try
            Loop

            If Not pointFound Then
                Console.WriteLine("ERROR: Gagal mendapatkan ClickablePoint setelah beberapa kali percobaan. Tombol tidak dapat diklik.")
                ' Fallback ke BoundingRectangle jika ClickablePoint gagal persistent
                PerformMouseClickUsingBoundingRectangle(element)
                Return
            End If

            Dim x As Integer = CInt(clickablePoint.X)
            Dim y As Integer = CInt(clickablePoint.Y)

            Console.WriteLine($"Mengklik pada koordinat ClickablePoint: X={x}, Y={y}")

            SetCursorPos(x, y)
            Thread.Sleep(100)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Thread.Sleep(50)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

            Console.WriteLine("Call button clicked successfully via mouse simulation using ClickablePoint.")
        Catch ex As Exception
            Console.WriteLine($"Terjadi kesalahan saat mencoba mengklik Call button via mouse: {ex.Message}")
        End Try
    End Sub
    ' Keep this function as a final fallback
    Private Sub PerformMouseClickUsingBoundingRectangle(element As AutomationElement)
        Try
            ' Ensure the element is still valid and has a BoundingRectangle
            Dim rect As System.Windows.Rect = element.Current.BoundingRectangle

            ' Check for empty or invalid rectangle (could happen if element becomes stale)
            If rect.IsEmpty Then
                Console.WriteLine("WARNING: BoundingRectangle is empty. Cannot click.")
                Return
            End If

            Dim x As Integer = CInt(rect.Left + rect.Width / 2)
            Dim y As Integer = CInt(rect.Top + rect.Height / 2)

            Console.WriteLine($"Mengklik pada koordinat BoundingRectangle: X={x}, Y={y}")

            SetCursorPos(x, y)
            Thread.Sleep(100)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Thread.Sleep(50)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)

            Console.WriteLine("Call button clicked successfully via mouse simulation using BoundingRectangle.")
        Catch ex As Exception
            Console.WriteLine($"Terjadi kesalahan saat mencoba mengklik Call button via BoundingRectangle: {ex.Message}")
            Console.WriteLine("Mungkin BoundingRectangle tidak valid atau masalah lain.")
        End Try
    End Sub

    Public Sub AutomateWhatsAppCallViaPopup(phoneNumber As String, preferredApp As String)
        Console.WriteLine($"Opening WhatsApp protocol for {phoneNumber}...")
        OpenWhatsAppProtocol(phoneNumber) ' Ini akan memunculkan popup

        Console.WriteLine($"Attempting to select '{preferredApp}' from the popup...")
        Dim success As Boolean = SelectWhatsAppAppAndClickOk(preferredApp) ' Panggil fungsi penanganan popup

        If success Then
            Console.WriteLine("Popup handled. Check for WhatsApp chat window.")
            ' Lanjutkan ke langkah mencari tombol call di WA Beta
            Dim whatsappChatWindow As AutomationElement = FindWhatsAppChatWindowByPhoneNumber(phoneNumber)
            If whatsappChatWindow IsNot Nothing Then
                Console.WriteLine("WhatsApp chat window found. Looking for Call button...")
                Dim callButton As AutomationElement = FindCallButtonInWhatsAppChat(whatsappChatWindow)
                If callButton IsNot Nothing Then
                    Console.WriteLine("Call button found. Clicking it...")
                    Dim invokePattern As InvokePattern = TryCast(callButton.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
                    If invokePattern IsNot Nothing Then
                        invokePattern.Invoke()
                        Console.WriteLine("Call button clicked successfully.")
                    Else
                        Console.WriteLine("InvokePattern not supported for Call button.")
                    End If
                Else
                    Console.WriteLine("Call button not found in the WhatsApp chat window.")
                End If
            Else
                Console.WriteLine("WhatsApp chat window not found after opening protocol. Automation failed.")
            End If
        Else
            Console.WriteLine("WhatsApp automation failed at the popup selection stage.")
        End If
    End Sub

    Private Function SelectWhatsAppAppAndClickOk(appToSelect As String) As Boolean
        Dim popupWindow As AutomationElement = Nothing
        Dim maxAttempts As Integer = 20 ' Tingkatkan jumlah upaya pencarian
        Dim attemptDelayMs As Integer = 500 ' Frekuensi pencarian (setengah detik)

        Console.WriteLine("Starting search for popup window...")
        ' Di dalam SelectWhatsAppAppAndClickOk atau FindWhatsAppChatWindow
        Dim popupTitleCandidate1 As String = "How do you want to open this?"
        Dim popupTitleCandidate2 As String = "Bagaimana Anda ingin membuka ini?" ' Jika ini adalah varian bahasa Indonesia

        popupWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
    New AndCondition(
        New PropertyCondition(AutomationElement.NameProperty, popupTitleCandidate1),
        New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)
    ))

        If popupWindow Is Nothing Then
            popupWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
        New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, popupTitleCandidate2),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)
        ))
        End If

        If popupWindow Is Nothing Then
            ' Jika tetap tidak ditemukan berdasarkan nama, coba hanya berdasarkan ClassName dan ControlType
            ' Ini berisiko bisa salah identifikasi jika ada dialog lain dengan ClassName yang sama
            Console.WriteLine("Warning: Popup not found by name, trying by ClassName only. This might be less precise.")
            popupWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
        New AndCondition(
            New PropertyCondition(AutomationElement.ClassNameProperty, "#32770"),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)
        ))
        End If

        ' Tunggu hingga jendela popup muncul
        For attempt As Integer = 1 To maxAttempts
            Console.WriteLine($"Attempt {attempt}: Looking for popup window...")
            popupWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                New AndCondition(
                    New PropertyCondition(AutomationElement.NameProperty, "How do you want to open this?"),
                    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window)
                ))

            If popupWindow IsNot Nothing Then
                Console.WriteLine("Popup window found.")
                Exit For ' Keluar dari loop jika ditemukan
            End If
            Thread.Sleep(attemptDelayMs)
        Next

        If popupWindow Is Nothing Then
            Console.WriteLine("Popup window 'How do you want to open this?' not found after multiple attempts.")
            Return False
        End If

        Console.WriteLine("Searching for list element within the popup...")
        ' Temukan elemen daftar
        Dim listElement As AutomationElement = popupWindow.FindFirst(TreeScope.Children,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.List))

        If listElement Is Nothing Then
            Console.WriteLine("List element not found within the popup window.")
            Return False
        End If

        Console.WriteLine($"Searching for '{appToSelect}' list item...")
        ' Temukan item daftar yang sesuai (WhatsApp atau WhatsApp Beta)
        Dim whatsappListItem As AutomationElement = listElement.FindFirst(TreeScope.Children,
            New AndCondition(
                New PropertyCondition(AutomationElement.NameProperty, appToSelect),
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)
            ))

        If whatsappListItem Is Nothing Then
            Console.WriteLine($"'{appToSelect}' list item not found.")
            Return False
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
            Dim invokePattern As InvokePattern = TryCast(whatsappListItem.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            If invokePattern IsNot Nothing Then
                invokePattern.Invoke() ' Ini bisa setara dengan double click tergantung elemennya
                Console.WriteLine($"Invoked '{appToSelect}'.")
                Thread.Sleep(500)
            Else
                Console.WriteLine($"Neither SelectionItemPattern nor InvokePattern supported for '{appToSelect}'. Cannot select.")
                Return False
            End If
        End If

        ' --- Klik Tombol OK ---
        Console.WriteLine("Searching for OK button...")
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
                Return True
            Else
                Console.WriteLine("InvokePattern not supported for OK button.")
                Return False
            End If
        Else
            Console.WriteLine("OK button not found.")
            Return False
        End If
    End Function

    Private Sub OpenWhatsAppProtocol(phoneNumber As String)
        Try
            Dim uri As String = $"whatsapp://send?phone={phoneNumber}"
            Process.Start(New ProcessStartInfo(uri) With {.UseShellExecute = True})
            Thread.Sleep(10000) ' Mulai dengan 10 detik, sesuaikan jika perlu.
        Catch ex As Exception
            Console.WriteLine($"Error opening WhatsApp protocol: {ex.Message}")
        End Try
    End Sub

    Private Function FindWhatsAppChatWindowByPhoneNumber(phoneNumber As String) As AutomationElement
        Dim whatsappChatWindow As AutomationElement = Nothing
        Dim maxAttempts As Integer = 20 ' Coba cari 20 kali
        Dim attemptDelayMs As Integer = 1000 ' Dengan jeda 1 detik

        For attempt As Integer = 1 To maxAttempts
            Console.WriteLine($"Attempt {attempt}: Looking for WhatsApp chat window...")

            ' PENTING: Anda harus VERIFIKASI NAMA JENDELA WhatsApp dengan inspect.exe.
            ' Beberapa kemungkinan nama jendela:
            ' - "WhatsApp" (untuk jendela utama)
            ' - Nama kontak/grup (misalnya, "John Doe - WhatsApp")
            ' - Bagian dari nomor telepon (jika WhatsApp menampilkannya di judul jendela)

            ' PERBAIKAN DI SINI: Hapus PropertyConditionFlags.Substring
            ' UI Automation secara otomatis melakukan pencarian substring untuk properti teks.

            ' Kondisi pencarian untuk jendela PopupHost
            Dim winApp As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, "WhatsApp Beta"),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
            New PropertyCondition(AutomationElement.ClassNameProperty, "WinUIDesktopWin32WindowClass")
        )


            whatsappChatWindow = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, winApp)

            If whatsappChatWindow IsNot Nothing Then
                Console.WriteLine($"WhatsApp chat window found with name: {whatsappChatWindow.Current.Name}")
                Exit For
            End If
            Thread.Sleep(attemptDelayMs)
        Next
        Return whatsappChatWindow
    End Function

    Private Function FindCallButtonInWhatsAppChat(chatWindow As AutomationElement) As AutomationElement


        Dim headerElement As AutomationElement = Nothing

        Dim condAnyHeader As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, ""),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Group),
            New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "header")
        )

        Dim headerStopwatch As New Stopwatch()
        headerStopwatch.Start()
        Do While headerElement Is Nothing AndAlso headerStopwatch.Elapsed.TotalSeconds < 15 ' Beri waktu lebih
            Dim potentialHeaders As AutomationElementCollection = AutomationElement.RootElement.FindAll(TreeScope.Descendants, condAnyHeader)

            If potentialHeaders.Count = 0 Then
                Console.WriteLine("Tidak ada elemen 'header' dasar yang ditemukan. Mencoba lagi...")
            Else
                Console.WriteLine($"Ditemukan {potentialHeaders.Count} elemen 'header' potensial.")
            End If

            For Each pHeader As AutomationElement In potentialHeaders
                ' Coba cari elemen anak yang unik dari header yang benar
                Dim condProfileDetailsButton As New AndCondition(
                    New PropertyCondition(AutomationElement.NameProperty, "Profile details"),
                    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
                )
                Dim condVideoCallButton As New AndCondition(
                    New PropertyCondition(AutomationElement.NameProperty, CHAT_VIDEO_CALL_BUTTON_NAME),
                    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
                )

                Dim profileButtonFound As Boolean = pHeader.FindFirst(TreeScope.Children, condProfileDetailsButton) IsNot Nothing
                Dim videoCallButtonFound As Boolean = pHeader.FindFirst(TreeScope.Children, condVideoCallButton) IsNot Nothing


                Console.WriteLine($"    - 'Profile details' button found: {profileButtonFound}")
                Console.WriteLine($"    - 'Video call' button found: {videoCallButtonFound}")

                If profileButtonFound OrElse videoCallButtonFound Then
                    headerElement = pHeader
                    Console.WriteLine($"  -> Header yang benar ditemukan (berdasarkan anak unik).")
                    Exit For
                End If
            Next

            If headerElement Is Nothing Then
                Console.WriteLine($"Header element yang benar belum ditemukan. Mencoba lagi... (Sudah berjalan: {headerStopwatch.Elapsed.TotalSeconds:F1}s)")
                Thread.Sleep(500)
            End If
        Loop
        headerStopwatch.Stop()

        If headerElement Is Nothing Then
            Console.WriteLine("Header element yang benar tidak ditemukan di jendela chat. Tidak dapat menemukan tombol panggilan.")
            Return Nothing
        End If
        Console.WriteLine("Header element yang benar ditemukan.")


        Dim callButton As AutomationElement = Nothing
        ' Kondisi untuk menemukan tombol "Voice call"
        Dim condCallButton As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, CHAT_AUDIO_CALL_BUTTON_NAME),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
            New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
        )

        Dim buttonStopwatch As New Stopwatch()
        buttonStopwatch.Start()
        Do While callButton Is Nothing AndAlso buttonStopwatch.Elapsed.TotalSeconds < 15
            Dim foundButtons As AutomationElementCollection = headerElement.FindAll(TreeScope.Descendants, condCallButton)
            If foundButtons.Count > 0 Then
                callButton = foundButtons(0)
                Console.WriteLine($"Ditemukan {foundButtons.Count} tombol '{CHAT_AUDIO_CALL_BUTTON_NAME}'. Mengambil yang pertama.")
            End If

            If callButton Is Nothing Then
                Console.WriteLine($"Tombol '{CHAT_AUDIO_CALL_BUTTON_NAME}' belum ditemukan di header. Mencoba lagi... (Sudah berjalan: {buttonStopwatch.Elapsed.TotalSeconds:F1}s)")

                Thread.Sleep(500)
            End If
        Loop
        buttonStopwatch.Stop()

        Return callButton
    End Function

    Public Function GetWhatsAppUWPInstallPath() As String
        Dim psi As New ProcessStartInfo()
        psi.FileName = "powershell"
        psi.Arguments = "-Command ""(Get-AppxPackage *WhatsAppDesktop* | Select-Object -ExpandProperty InstallLocation)"""
        psi.RedirectStandardOutput = True
        psi.UseShellExecute = False
        psi.CreateNoWindow = True

        Try
            Using proc As Process = Process.Start(psi)
                Using reader As StreamReader = proc.StandardOutput
                    Dim output As String = reader.ReadToEnd().Trim()

                    If Not String.IsNullOrWhiteSpace(output) Then
                        '  MessageBox.Show("InstallLocation ditemukan: " & output)
                        Return output
                    Else
                        '  MessageBox.Show("WhatsApp UWP tidak ditemukan.")
                        Return ""
                    End If
                End Using
            End Using
        Catch ex As Exception
            '  MessageBox.Show("Gagal menjalankan powershell: " & ex.Message)
            Return ""
        End Try
    End Function

    Public Function OpenWhatsAppFromExecutable() As Boolean

        Try
            Dim pathWa = GetWhatsAppUWPInstallPath()

            If pathWa <> "" Then

                ' Buat command untuk membuka aplikasi UWP
                Dim exePath = Path.Combine(pathWa, "WhatsApp.exe")

                If File.Exists(exePath) Then
                    Process.Start(exePath)
                Else
                    MessageBox.Show("File WhatsApp.exe tidak ditemukan di folder.")
                End If

                Return True

            Else
                Return False
            End If




        Catch ex As System.ComponentModel.Win32Exception
            Console.WriteLine($"ERROR: Gagal meluncurkan WhatsApp. Pastikan jalur file benar dan Anda memiliki izin. Detail: {ex.Message}")
            Return False
        Catch ex As Exception
            Console.WriteLine($"Terjadi kesalahan tak terduga saat mencoba meluncurkan WhatsApp: {ex.Message}")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Mencari jendela WhatsApp dan mengklik ikon "Calls" di sidebar.
    ''' </summary>
    ''' <returns>True jika berhasil mengklik ikon panggilan, False jika tidak.</returns>
    Public Function ClickCallIconInSidebar() As Boolean
        Console.WriteLine($"Mencari jendela utama WhatsApp: '{WHATSAPP_MAIN_WINDOW_NAME}'...")
        Dim whatsappWindow As AutomationElement = Nothing
        Dim stopwatch As New Stopwatch()

        Dim condWhatsAppWindow As New PropertyCondition(AutomationElement.NameProperty, WHATSAPP_MAIN_WINDOW_NAME)

        stopwatch.Start()
        Do While whatsappWindow Is Nothing AndAlso stopwatch.Elapsed.TotalSeconds < 30 ' Tunggu hingga 30 detik
            whatsappWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, condWhatsAppWindow)
            If whatsappWindow Is Nothing Then
                Console.WriteLine($"Jendela WhatsApp belum ditemukan. Mencoba lagi...")
                Thread.Sleep(1000)
            End If
        Loop
        stopwatch.Stop()

        If whatsappWindow Is Nothing Then
            Console.WriteLine($"Jendela WhatsApp '{WHATSAPP_MAIN_WINDOW_NAME}' tidak ditemukan.")
            Return False
        End If
        Console.WriteLine("Jendela WhatsApp ditemukan.")

        Console.WriteLine($"Mencari ikon '{CALL_ICON_NAME}' di sidebar...")
        Dim callIcon As AutomationElement = Nothing

        ' Jika inspect.exe menunjukkan ControlType: ListItem
        Dim condCallIcon As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, CALL_ICON_NAME),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem)
        )

        ' Atau jika ControlType: TabItem
        ' Dim condCallIcon As New AndCondition( _
        '    New PropertyCondition(AutomationElement.NameProperty, CALL_ICON_NAME), _
        '    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem) _
        ' )

        ' Coba cari di Descendants dari jendela WhatsApp, karena posisi sidebar bisa bervariasi
        callIcon = whatsappWindow.FindFirst(TreeScope.Descendants, condCallIcon)

        If callIcon Is Nothing Then
            Console.WriteLine($"Ikon panggilan '{CALL_ICON_NAME}' tidak ditemukan dalam jendela WhatsApp. Mungkin namanya berbeda atau struktur UI-nya.")
            ' Coba cari alternatif (misal: AutomationId jika ada)
            ' Atau cari ControlType.TabItem jika Calls adalah tab
            Return False
        End If

        Dim selectionItemPattern As SelectionItemPattern = TryCast(callIcon.GetCurrentPattern(SelectionItemPattern.Pattern), SelectionItemPattern)
        If selectionItemPattern IsNot Nothing Then
            selectionItemPattern.Select()
            Console.WriteLine("Ikon panggilan (ListItem) berhasil dipilih.")
            Thread.Sleep(2000) ' Beri jeda untuk UI berubah
            Return True
        Else
            ' Fallback ke InvokePattern jika bukan ListItem atau SelectionItemPattern tidak didukung
            Dim invoke As InvokePattern = TryCast(callIcon.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            If invoke IsNot Nothing Then
                invoke.Invoke()
                Console.WriteLine("Ikon panggilan (Button) berhasil diklik.")
                Thread.Sleep(2000)
                Return True
            Else
                Console.WriteLine($"Tidak ada SelectionItemPattern maupun InvokePattern ditemukan untuk ikon '{CALL_ICON_NAME}'. Tidak dapat mengklik/memilih.")
                Return False
            End If
        End If


        'Console.WriteLine($"Ikon '{CALL_ICON_NAME}' ditemukan. Mengklik...")
        'Dim invokePattern As InvokePattern = TryCast(callIcon.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
        'If invokePattern IsNot Nothing Then
        '    invokePattern.Invoke()
        '    Console.WriteLine("Ikon panggilan diklik. Menunggu UI diperbarui...")
        '    Thread.Sleep(2000) ' Beri jeda untuk navigasi UI
        '    Return True
        'Else
        '    Console.WriteLine($"Tidak dapat mengklik ikon '{CALL_ICON_NAME}' (InvokePattern tidak tersedia).")
        '    Return False
        'End If
    End Function

    ''' <summary>
    ''' Mengklik tombol "Call a number" (atau "New call"), mengelola pop-up, input nomor, dan mengklik "Voice call".
    ''' </summary>
    ''' <param name="phoneNumber">Nomor telepon yang akan diinput.</param>
    ''' <returns>True jika berhasil, False jika tidak.</returns>
    Public Function ClickCallNumberAndHandlePopup(ByVal phoneNumber As String, app As String) As Boolean
        Console.WriteLine($"Mencari tombol '{CALL_NUMBER_BUTTON_NAME}' untuk memicu pop-up...")
        Dim callNumberButton As AutomationElement = Nothing

        Dim condCallNumberButton As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, CALL_NUMBER_BUTTON_NAME),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
        )
        callNumberButton = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, condCallNumberButton)

        If callNumberButton Is Nothing Then
            Console.WriteLine($"Tombol '{CALL_NUMBER_BUTTON_NAME}' tidak ditemukan.")
            Return False
        End If

        If (callNumberButton.Current.IsEnabled) Then
            Console.WriteLine($"Tombol '{CALL_NUMBER_BUTTON_NAME}' ditemukan. Mengklik...")
            Dim invokePatternButton As InvokePattern = TryCast(callNumberButton.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            If invokePatternButton IsNot Nothing Then
                invokePatternButton.Invoke()
                Console.WriteLine("Tombol diklik. Menunggu pop-up input nomor muncul...")
                Thread.Sleep(3000)
            Else
                Console.WriteLine($"Tidak dapat mengklik tombol '{CALL_NUMBER_BUTTON_NAME}' (InvokePattern tidak tersedia).")
                Return False
            End If
        Else
            HandleVoiceCall(app)
        End If

        ' --- Kelola Pop-up "PopupHost" (jendela utama) ---
        Console.WriteLine($"Mencari pop-up utama: '{PHONE_NUMBER_POPUP_HOST_NAME}' (ClassName: 'Xaml_WindowedPopupClass')...")
        Dim popupHostWindow As AutomationElement = Nothing
        Dim stopwatch As New Stopwatch()

        ' Kondisi pencarian untuk jendela PopupHost
        Dim condPopupHostWindow As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, PHONE_NUMBER_POPUP_HOST_NAME),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
            New PropertyCondition(AutomationElement.ClassNameProperty, "Xaml_WindowedPopupClass")
        )

        stopwatch.Start()
        Do While popupHostWindow Is Nothing AndAlso stopwatch.Elapsed.TotalSeconds < 30
            ' Coba cari sebagai anak langsung dari RootElement
            popupHostWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, condPopupHostWindow)

            ' Fallback ke Descendants dari RootElement jika tidak ditemukan sebagai Children
            If popupHostWindow Is Nothing Then
                popupHostWindow = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, condPopupHostWindow)
            End If

            If popupHostWindow Is Nothing Then
                Console.WriteLine($"Pop-up '{PHONE_NUMBER_POPUP_HOST_NAME}' belum ditemukan. Mencoba lagi... (Sudah berjalan: {stopwatch.Elapsed.TotalSeconds:F1}s)")
                Thread.Sleep(500)
            End If
        Loop
        stopwatch.Stop()

        If popupHostWindow Is Nothing Then
            Console.WriteLine($"Pop-up '{PHONE_NUMBER_POPUP_HOST_NAME}' tidak ditemukan setelah waktu habis (30 detik).")
            Return False
        End If
        Console.WriteLine($"Pop-up '{PHONE_NUMBER_POPUP_HOST_NAME}' ditemukan.")

        ' --- Sekarang, cari container "Phone number" di dalam PopupHost ---
        Console.WriteLine($"Mencari kontainer 'Phone number' di dalam 'Pop-up'...")
        Dim phoneNumberContainer As AutomationElement = Nothing

        ' Cari sebagai Descendants di dalam popupHostWindow
        phoneNumberContainer = PopupContainer(popupHostWindow)

        If phoneNumberContainer Is Nothing Then
            Console.WriteLine($"Kontainer 'Phone number' tidak ditemukan di dalam 'Pop-up'.")
            Return False
        End If
        Console.WriteLine("Kontainer 'Phone number' ditemukan.")


        ' --- Input Nomor Telepon (cari di dalam phoneNumberContainer) ---
        Console.WriteLine($"Mencari bidang input nomor telepon: '{PHONE_NUMBER_EDIT_FIELD_NAME}'...")
        Dim editField As AutomationElement = Nothing
        Dim condEditField As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, PHONE_NUMBER_EDIT_FIELD_NAME),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)
        )
        editField = phoneNumberContainer.FindFirst(TreeScope.Descendants, condEditField) ' Cari di dalam container

        If editField Is Nothing Then
            Console.WriteLine($"Bidang input nomor telepon '{PHONE_NUMBER_EDIT_FIELD_NAME}' tidak ditemukan.")
            Return False
        End If

        Dim valuePattern As ValuePattern = TryCast(editField.GetCurrentPattern(ValuePattern.Pattern), ValuePattern)
        If valuePattern IsNot Nothing AndAlso Not valuePattern.Current.IsReadOnly Then
            valuePattern.SetValue(phoneNumber)
            Console.WriteLine($"Nomor '{phoneNumber}' berhasil diinput.")
        Else
            Console.WriteLine("Tidak dapat menginput nomor telepon (ValuePattern tidak tersedia atau read-only).")
            Return False
        End If

        Console.WriteLine($"Mencari tombol panggilan suara: '{VOICE_CALL_BUTTON_NAME}'...")
        Dim voiceCallButton As AutomationElement = Nothing
        Dim condVoiceCallButton As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, VOICE_CALL_BUTTON_NAME),
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
        )

        Dim voiceCallButtonStopwatch As New Stopwatch() ' Stopwatch baru untuk tombol panggilan
        voiceCallButtonStopwatch.Start()
        Do While voiceCallButton Is Nothing AndAlso voiceCallButtonStopwatch.Elapsed.TotalSeconds < 10 ' Beri waktu 10 detik
            voiceCallButton = phoneNumberContainer.FindFirst(TreeScope.Descendants, condVoiceCallButton) ' Cari di dalam container
            If voiceCallButton Is Nothing Then
                Console.WriteLine($"Tombol panggilan suara '{VOICE_CALL_BUTTON_NAME}' belum ditemukan. Mencoba lagi... (Sudah berjalan: {voiceCallButtonStopwatch.Elapsed.TotalSeconds:F1}s)")
                Thread.Sleep(500)
            End If
        Loop
        voiceCallButtonStopwatch.Stop()

        If voiceCallButton Is Nothing Then
            Console.WriteLine($"Tombol panggilan suara '{VOICE_CALL_BUTTON_NAME}' tidak ditemukan setelah waktu habis (10 detik).")
            Return False
        End If
        Console.WriteLine("Tombol panggilan suara ditemukan.")

        ' Ini adalah bagian untuk memastikan tombol aktif sebelum diklik
        Dim buttonEnableTimeout As Integer = 5
        Dim buttonEnableStopwatch As New Stopwatch()
        buttonEnableStopwatch.Start()
        Do While Not voiceCallButton.Current.IsEnabled AndAlso buttonEnableStopwatch.Elapsed.TotalSeconds < buttonEnableTimeout
            Thread.Sleep(100)
        Loop
        buttonEnableStopwatch.Stop()

        If voiceCallButton.Current.IsEnabled Then
            Dim invokeVoiceCallPattern As InvokePattern = TryCast(voiceCallButton.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            If invokeVoiceCallPattern IsNot Nothing Then
                invokeVoiceCallPattern.Invoke()
                Console.WriteLine($"Tombol '{VOICE_CALL_BUTTON_NAME}' diklik. Panggilan dimulai.")
                Return True
            Else
                Console.WriteLine($"InvokePattern tidak ditemukan untuk tombol '{VOICE_CALL_BUTTON_NAME}'.")
                Return False
            End If
        Else
            Console.WriteLine($"Tombol '{VOICE_CALL_BUTTON_NAME}' tidak aktif setelah {buttonEnableTimeout} detik.")
            Return False
        End If



    End Function

    Private Function PopupContainer(elbefore As AutomationElement)
        Dim phoneNumberContainer As AutomationElement = Nothing
        Dim condPhoneNumberContainer As New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, "Pop-up"),
            New OrCondition(
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                New PropertyCondition(AutomationElement.ClassNameProperty, "Popup")
            )
        )
        ' Cari sebagai Descendants di dalam popupHostWindow
        phoneNumberContainer = elbefore.FindFirst(TreeScope.Descendants, condPhoneNumberContainer)

        Return phoneNumberContainer
    End Function



    Public Sub HandleMinimizedWhatsAppCall()
        Dim windowTitle As String = "Voice call ‎- WhatsApp"
        Dim windowHandle As IntPtr = FindWindow("ApplicationFrameWindow", windowTitle)

        If windowHandle <> IntPtr.Zero Then
            Console.WriteLine("Jendela panggilan WhatsApp ditemukan.")

            ' Jika jendela ditemukan, paksa untuk kembali ke tampilan normal
            ShowWindow(windowHandle, SW_RESTORE)

            ' Setelah jendela dipulihkan, berikan waktu untuk UI stabil
            Thread.Sleep(1000)

            ' Sekarang, cari AutomationElement seperti biasa, yang seharusnya berhasil
            Dim popupvoicewindows As AutomationElement = AutomationElement.RootElement.FindFirst(
            TreeScope.Descendants,
            New AndCondition(
                 New PropertyCondition(AutomationElement.NameProperty, windowTitle),
                New PropertyCondition(AutomationElement.ClassNameProperty, "ApplicationFrameWindow")
            )
        )


            If popupvoicewindows IsNot Nothing Then
                ' Langkah 2: Periksa status jendela (opsional, untuk debugging)
                'Dim windowPattern As WindowPattern = TryCast(popupvoicewindows.GetCurrentPattern(WindowPattern.Pattern), WindowPattern)
                'If windowPattern IsNot Nothing Then
                '    Console.WriteLine($"Sebelum klik: CanMinimize={windowPattern.Current.CanMinimize}")
                'End If

                ' Langkah 3: Dapatkan BoundingRectangle dan hitung koordinat tengah
                Dim rect As System.Windows.Rect = popupvoicewindows.Current.BoundingRectangle
                Dim centerX As Integer = CInt(rect.Left + (rect.Width / 2))
                Dim centerY As Integer = CInt(rect.Top + (rect.Height / 2))

                Console.WriteLine($"Melakukan klik 'pemicu' pada koordinat tengah: X={centerX}, Y={centerY}")

                ' Lakukan klik mouse
                PerformMouseClickAt(centerX, centerY)
                Thread.Sleep(1000) ' Beri waktu agar jendela merespons dan propertinya diperbarui

                ' Langkah 4: Periksa kembali status jendela (opsional, untuk verifikasi)
                'If windowPattern IsNot Nothing Then
                '    Console.WriteLine($"Setelah klik: CanMinimize={windowPattern.Current.CanMinimize}")
                'End If

                ' Langkah 5: Lanjutkan dengan otomatisasi lainnya
                ' Sekarang jendela seharusnya aktif, jadi kita bisa mengklik tombol 'End call'
                Dim endCallClicked As Boolean = TryClickButton("End call", popupvoicewindows, 5, 500)

                ' ... (lanjutkan dengan logika Close dan OK) ...

            Else
                Console.WriteLine("ERROR: Jendela panggilan tidak ditemukan.")
            End If

        Else
            Console.WriteLine("Jendela panggilan WhatsApp tidak ditemukan.")
        End If
    End Sub

    Private Sub PerformMouseClickAt(x As Integer, y As Integer)
        Try
            SetCursorPos(x, y)
            Thread.Sleep(50)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Thread.Sleep(20)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        Catch ex As Exception
            Console.WriteLine($"ERROR: Gagal melakukan klik mouse pada koordinat {x}, {y}: {ex.Message}")
        End Try
    End Sub

    Public Sub HandleVoiceCall(ByVal app As String)
        Dim popupvoicewindows As AutomationElement = Nothing
        Dim condition As Condition = Nothing

        If (app = "WhatsApp Beta") Then
            condition = New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, "Voice call"),
            New AndCondition(
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "window"),
                New PropertyCondition(AutomationElement.ClassNameProperty, "ApplicationFrameWindow")
            )
        )
            Console.WriteLine($"[HandleVoiceCall] Mencari jendela 'Voice call' untuk {app}...")
        Else ' Asumsi ini untuk WhatsApp Biasa
            condition = New AndCondition(
            New PropertyCondition(AutomationElement.NameProperty, "Voice call ‎- WhatsApp"),
            New AndCondition(
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window),
                New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "window"),
                New PropertyCondition(AutomationElement.ClassNameProperty, "ApplicationFrameWindow")
            )
        )
            Console.WriteLine($"[HandleVoiceCall] Mencari jendela 'Voice call - WhatsApp' untuk {app}...")
        End If

        Dim maxRetries As Integer = 10 ' Tingkatkan retries untuk memberikan lebih banyak waktu
        Dim retryDelayMs As Integer = 1000 ' Tetap 1 detik antar percobaan
        Dim foundWindow As Boolean = False


        For i As Integer = 0 To maxRetries - 1
            Try
                popupvoicewindows = AutomationElement.RootElement.FindFirst(TreeScope.Descendants, condition)
                If popupvoicewindows IsNot Nothing Then


                    ' Tambahan: Periksa dan pulihkan status jendela jika terminimalisasi
                    Dim windowPattern As WindowPattern = TryCast(popupvoicewindows.GetCurrentPattern(WindowPattern.Pattern), WindowPattern)
                    Dim canMaximize As Boolean = windowPattern.Current.CanMaximize
                    Dim canMinimize As Boolean = windowPattern.Current.CanMinimize
                    Dim windowState As WindowVisualState = windowPattern.Current.WindowVisualState
                    If windowPattern IsNot Nothing Then

                        ' Anda bisa menggunakan properti ini dalam logika Anda, misalnya:
                        If canMaximize AndAlso windowState <> WindowVisualState.Maximized Then
                            Console.WriteLine("Jendela bisa dimaksimalkan dan saat ini tidak maksimal. Mencoba memaksimalkan...")
                            windowPattern.SetWindowVisualState(WindowVisualState.Normal)

                        End If

                        Console.WriteLine("Windows canMinimize " & canMinimize)

                        If canMinimize = False Then
                            windowPattern.SetWindowVisualState(WindowVisualState.Normal)


                            Dim targetElement As AutomationElement = Nothing

                            ' 1. Buat kondisi pencarian berdasarkan FrameworkId dan ClassName
                            Dim condXAMl As New AndCondition(
        New PropertyCondition(AutomationElement.FrameworkIdProperty, "XAML"),
        New PropertyCondition(AutomationElement.ClassNameProperty, "Windows.UI.Input.InputSite.WindowClass")
    )

                            ' 2. Lakukan pencarian elemen dengan retry loop untuk memastikan keandalan
                            Console.WriteLine("Mencari elemen 'XAML' dengan ClassName 'Windows.UI.Input.InputSite.WindowClass'...")

                            For ai As Integer = 0 To maxRetries - 1
                                Try
                                    targetElement = popupvoicewindows.FindFirst(TreeScope.Descendants, condXAMl)
                                    If targetElement IsNot Nothing Then
                                        Console.WriteLine($"Elemen ditemukan setelah {ai + 1} percobaan.")
                                        Exit For
                                    End If
                                Catch ex As Exception
                                    Console.WriteLine($"Pencarian gagal pada percobaan {ai + 1}/{maxRetries}: {ex.Message}. Mencoba lagi...")
                                End Try
                                Thread.Sleep(retryDelayMs)
                            Next

                            PerformMouseClickSingle(targetElement)

                        End If

                    End If

                    foundWindow = True
                    popupvoicewindows.SetFocus()
                    Console.WriteLine($"[HandleVoiceCall] Jendela '{app}' ditemukan dan disesuaikan setelah {i + 1} percobaan.")
                    Exit For
                End If
            Catch ex As COMException
                If ex.ErrorCode = &H80004005 Then
                    Console.WriteLine($"[HandleVoiceCall] Percobaan {i + 1}/{maxRetries}: COM Error (E_FAIL) saat mencari jendela '{app}'. Mencoba lagi...")
                Else
                    Console.WriteLine($"[HandleVoiceCall] Percobaan {i + 1}/{maxRetries}: COM Error tak terduga: {ex.Message}. Mencoba lagi...")
                End If
            Catch ex As Exception
                Console.WriteLine($"[HandleVoiceCall] Percobaan {i + 1}/{maxRetries}: Error tak terduga saat mencari jendela '{app}': {ex.Message}. Mencoba lagi...")
            End Try

            Thread.Sleep(retryDelayMs)
        Next



        '   TryClickButton("Close Voice call - " & app, popupvoicewindows, 5, 500) ' Coba 5x, delay 500ms

        If popupvoicewindows IsNot Nothing Then
            Console.WriteLine($"[HandleVoiceCall] Melanjutkan interaksi dengan jendela panggilan {popupvoicewindows.Current.Name}...")

            Dim AppBar As AutomationElement = Nothing

            Dim condAppBar As New AndCondition(
       New PropertyCondition(AutomationElement.NameProperty, "AppWindow Custom Title Bar"),
       New AndCondition(
           New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
           New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "pane")
       ))


            Thread.Sleep(1000)
            '  popupvoicewindows.SetFocus()
            ' Mencoba klik "End call"
            Dim endCallClicked As Boolean = TryClickButton("End call", popupvoicewindows, 5, 500) ' Coba 5x, delay 500ms
            If endCallClicked Then
                Console.WriteLine($"[HandleVoiceCall] Tombol 'End call' diklik.")
                Thread.Sleep(1000) ' Beri waktu setelah End Call
            Else
                TryClickButton("Close", AppBar, 5, 500) ' Coba 5x, delay 500ms
                Dim okClicked As Boolean = TryClickButton("OK", popupvoicewindows, 5, 500)
                If okClicked Then
                    Console.WriteLine($"[HandleVoiceCall] Tombol 'OK' diklik.")
                    Thread.Sleep(1000)
                Else
                    TryClickButton("Close", AppBar, 5, 500) ' Coba 5x, delay 500ms
                End If

            End If


            AppBar = popupvoicewindows.FindFirst(TreeScope.Descendants, condAppBar)
            TryClickButton("Close", popupvoicewindows, 5, 500) ' Coba 5x, delay 500ms

            Dim CloseTrue As Boolean = TryClickButton("Close", AppBar, 5, 500) ' Coba 5x, delay 500ms

            If (CloseTrue) Then
                Thread.Sleep(1500)
                ' Mencoba klik "OK" (jika ada dialog konfirmasi atau error)
                Dim okClicked As Boolean = TryClickButton("OK", popupvoicewindows, 5, 500)
                If okClicked Then
                    Console.WriteLine($"[HandleVoiceCall] Tombol 'OK' diklik.")

                Else
                    TryClickButton("Close", AppBar, 5, 500) ' Coba 5x, delay 500ms
                End If
            Else
                ' Mencoba klik "Close" (mungkin muncul setelah End Call, atau jika panggilan sudah selesai)
                Dim closeClicked As Boolean = TryClickButton("Close", popupvoicewindows, 5, 500)
                If closeClicked Then
                    Console.WriteLine($"[HandleVoiceCall] Tombol 'Close' diklik.")
                    Thread.Sleep(1000)
                Else
                    TryClickButton("Close", AppBar, 5, 500) ' Coba 5x, delay 500ms

                    ' Mencoba klik "OK" (jika ada dialog konfirmasi atau error)
                    Dim okClicked As Boolean = TryClickButton("OK", popupvoicewindows, 5, 500)
                    If okClicked Then
                        Console.WriteLine($"[HandleVoiceCall] Tombol 'OK' diklik.")
                        Thread.Sleep(1000)
                    Else
                        TryClickButton("Close", AppBar, 5, 500) ' Coba 5x, delay 500ms
                    End If
                End If
            End If



            TryClickButton("Close Voice call ‎- " & app, popupvoicewindows, 5, 500) ' Coba 5x, delay 500ms



        End If
    End Sub

    ' --- Tambahkan fungsi helper ini di modul Anda ---
    Private Function TryClickButton(buttonName As String, parentElement As AutomationElement, maxRetries As Integer, retryDelayMs As Integer) As Boolean
        For i As Integer = 0 To maxRetries - 1
            Try
                Dim button As AutomationElement = parentElement.FindFirst(TreeScope.Descendants,
                New AndCondition(
                    New PropertyCondition(AutomationElement.NameProperty, buttonName),
                    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button)
                ))

                If button IsNot Nothing AndAlso button.Current.IsEnabled Then
                    Dim invokePattern As InvokePattern = TryCast(button.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
                    If invokePattern IsNot Nothing Then
                        invokePattern.Invoke()
                        Return True
                    Else
                        ' Fallback ke klik mouse jika InvokePattern tidak didukung
                        ' Anda bisa memanggil PerformMouseClick di sini, tapi pastikan PerformMouseClick hanya untuk 1 klik
                        ' (tidak ada loop retry internal agar tidak tumpang tindih)
                        Console.WriteLine($"DEBUG: InvokePattern tidak didukung untuk '{buttonName}'. Mencoba klik mouse.")
                        PerformMouseClickSingle(button) ' Ini adalah versi sederhana PerformMouseClick tanpa retry internal
                        Return True
                    End If
                End If
            Catch ex As Exception
                Console.WriteLine($"WARNING: Percobaan {i + 1}/{maxRetries} untuk mengklik '{buttonName}' gagal: {ex.Message}")
            End Try
            Thread.Sleep(retryDelayMs)
        Next
        Return False
    End Function

    Private Sub PerformMouseClickSingle(element As AutomationElement)
        Try
            '  element.SetFocus() ' Coba fokuskan
            Thread.Sleep(100)

            Dim clickablePoint As System.Windows.Point = element.GetClickablePoint()
            Dim x As Integer = CInt(clickablePoint.X)
            Dim y As Integer = CInt(clickablePoint.Y)

            Console.WriteLine(clickablePoint)
            SetCursorPos(x, y)
            Thread.Sleep(50)
            mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0)
            Thread.Sleep(20)
            mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0)
        Catch ex As Exception
            Console.WriteLine($"ERROR: Gagal melakukan klik mouse tunggal pada elemen: {ex.Message}")
        End Try
    End Sub
    Private Sub BtnInvoke(ByVal NamProperty As String, element As AutomationElement)
        Dim btnOK As AutomationElement = Nothing

        Dim condbtnOK As New AndCondition(
       New PropertyCondition(AutomationElement.NameProperty, NamProperty),
       New AndCondition(
           New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Button),
           New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "button")
       ))

        Thread.Sleep(1000)
        btnOK = element.FindFirst(TreeScope.Descendants, condbtnOK)

        Dim invokePatternoK As InvokePattern = Nothing
        Try
            invokePatternoK = TryCast(btnOK.GetCurrentPattern(InvokePattern.Pattern), InvokePattern)
            invokePatternoK.Invoke()
        Catch ex As Exception
            Console.WriteLine($"Error saat mencoba mendapatkan InvokePattern: {ex.Message}. Ini kemungkinan normal untuk 'Unsupported Pattern'.")
        End Try
    End Sub

    Private Sub KlikOk(ByVal NamProperty As String, element As AutomationElement)
        Dim btnOK As AutomationElement = Nothing

        Dim condListItemOK As New AndCondition(
       New PropertyCondition(AutomationElement.NameProperty, NamProperty),
       New AndCondition(
           New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.ListItem),
           New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "list item")
       ))

        Thread.Sleep(1000)
        btnOK = element.FindFirst(TreeScope.Descendants, condListItemOK)

        PerformMouseClick(btnOK)

    End Sub

End Class