Imports System.Diagnostics
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Windows.Automation



Public Class SIPAutomation




    Private mainWindowHandle As IntPtr
    Private mainWindow As AutomationElement
    Private processId As Integer



    Public Function GetCleanProcessName(exePath As String) As String
        ' Ambil nama file tanpa ekstensi
        Dim rawName As String = Path.GetFileNameWithoutExtension(exePath)

        ' Hapus semua angka
        Dim cleanName As String = Regex.Replace(rawName, "\d+", "")

        Return cleanName
    End Function

    Public Function FindOrStart(exePath As String, processName As String) As Boolean
        ' Cari proses SIP yang sudah ada
        Dim procs = Process.GetProcessesByName(processName)
        Dim proc As Process = Nothing

        If procs.Length > 0 Then
            proc = procs(0)
        Else
            ' Start proses baru
            proc = Process.Start(exePath)
            If proc Is Nothing Then Return False
        End If

        proc.WaitForInputIdle(5000)

        processId = proc.Id
        Dim success As Boolean = False
        Try
            ' Tunggu sampai ada window utama

            For i As Integer = 0 To 20 ' max 10 detik
                proc.Refresh()
                If proc.MainWindowHandle <> IntPtr.Zero Then
                    mainWindowHandle = proc.MainWindowHandle
                    mainWindow = AutomationElement.FromHandle(mainWindowHandle)
                    success = True
                    Exit For
                End If
                Thread.Sleep(500)
            Next
        Catch ex As Exception

        End Try


        Return success
    End Function

    ' Cari window utama berdasarkan Process
    Public Function FindMainWindow(proc As Process) As Boolean
        Try
            ' Tunggu idle kalau masih hidup
            If Not proc.HasExited Then
                proc.WaitForInputIdle()
            End If
        Catch ex As InvalidOperationException
            ' Kalau prosesnya sudah exit sebelum idle
            Return False
        End Try

        For i As Integer = 0 To 20 ' max 10 detik
            proc.Refresh()

            ' Kalau sudah exit, hentikan
            If proc.HasExited Then
                Return False
            End If

            mainWindowHandle = proc.MainWindowHandle

            If mainWindowHandle <> IntPtr.Zero Then
                Try
                    mainWindow = AutomationElement.FromHandle(mainWindowHandle)
                    If mainWindow IsNot Nothing Then
                        Return True
                    End If
                Catch ex As COMException
                    ' UIAutomation belum siap → tunggu lagi
                End Try
            End If

            Thread.Sleep(500)
        Next

        Return False
    End Function



    ' Property untuk expose AutomationElement utama
    Public ReadOnly Property MainWindowElement As AutomationElement
        Get
            Return mainWindow
        End Get
    End Property

    '''' <summary>
    '''' a. Buka aplikasi melalui cmd
    '''' b. Cek title aplikasi
    '''' </summary>
    'Public Sub StartApp(exePath As String)
    '    process = Process.Start(exePath)
    '    Thread.Sleep(2000) ' beri waktu aplikasi terbuka
    'End Sub


    ''' <summary>
    ''' c. Cari window utama berdasarkan title
    ''' </summary>
    Public Function FindMainWindow(title As String) As Boolean
        For i As Integer = 1 To 20
            mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children,
                New PropertyCondition(AutomationElement.NameProperty, title))
            If mainWindow IsNot Nothing Then Return True
            Thread.Sleep(500)
        Next
        Return False
    End Function


    ''' <summary>
    ''' d. Cari panel dialog (Pane + LocalizedControlType=dialog)
    ''' </summary>
    Private Function GetDialogPane() As AutomationElement
        ' Lebih aman: jangan pakai LocalizedControlType
        Dim dialogCondition As New AndCondition(
            New PropertyCondition(AutomationElement.LocalizedControlTypeProperty, "dialog"),
                 New OrCondition(
                    New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane),
                    New PropertyCondition(AutomationElement.ClassNameProperty, "#32770")
                 )
        )

        Dim dialog As AutomationElement = Nothing
        For i As Integer = 1 To 20
            dialog = mainWindow.FindFirst(TreeScope.Descendants, dialogCondition)
            If dialog IsNot Nothing Then Exit For
            Thread.Sleep(500)
        Next

        If dialog Is Nothing Then
            ' Debug fallback: dump semua Pane di bawah mainWindow biar kelihatan
            Dim panes = mainWindow.FindAll(TreeScope.Descendants,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Pane))
            Console.WriteLine("Ditemukan " & panes.Count & " Pane:")
            For Each p As AutomationElement In panes
                Console.WriteLine("  ClassName=" & p.Current.ClassName & " Name=" & p.Current.Name)
            Next
        End If

        Return dialog
    End Function


    ''' <summary>
    ''' e  f. Input nomor ke ComboBox->Edit
    ''' </summary>
    Public Sub InputNumber(nomor As String)

        If Not IsPhoneTabSelected(mainWindow) Then
            SwitchToPhoneTab(mainWindow)
        End If


        Dim combo As AutomationElement = mainWindow.FindFirst(
            TreeScope.Descendants,
            New PropertyCondition(AutomationElement.AutomationIdProperty, "1078"))

        If combo Is Nothing Then Throw New Exception("ComboBox tidak ditemukan")

        ' Cari child edit box dari combo
        Dim edit As AutomationElement = combo.FindFirst(
            TreeScope.Descendants,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit))

        If edit Is Nothing Then Throw New Exception("EditBox dalam ComboBox tidak ditemukan")

        ' Baru apply ValuePattern
        Dim vp As ValuePattern = Nothing
        If edit.TryGetCurrentPattern(ValuePattern.Pattern, vp) Then
            vp.SetValue(nomor)
        Else
            Throw New Exception("EditBox tidak support ValuePattern")
        End If

        combo.SetFocus()
        edit.SetFocus()

        System.Windows.Forms.SendKeys.SendWait("{ENTER}")
        Thread.Sleep(500)
    End Sub

    ''' <summary>
    ''' g. Klik tombol Call (cek enabled dulu)
    ''' </summary>
    Public Sub CallSip()
        Dim dialog = GetDialogPane()
        If dialog Is Nothing Then Throw New Exception("Dialog tidak ditemukan")

        Dim callBtn As AutomationElement = dialog.FindFirst(TreeScope.Descendants,
            New PropertyCondition(AutomationElement.AutomationIdProperty, "1022"))
        If callBtn Is Nothing Then Throw New Exception("Tombol Call tidak ditemukan")

        If callBtn.Current.IsEnabled Then
            Dim invoke As InvokePattern = Nothing
            If callBtn.TryGetCurrentPattern(InvokePattern.Pattern, invoke) Then
                invoke.Invoke()
            End If
        Else
            Throw New Exception("Tombol Call belum aktif")
        End If
    End Sub

    ''' <summary>
    ''' h. Cek status bar (return text status)
    ''' </summary>
    Public Function GetStatus() As String
        Dim statusBar As AutomationElement = mainWindow.FindFirst(TreeScope.Descendants,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.StatusBar))
        If statusBar Is Nothing Then Return ""

        Dim onlineText As AutomationElement = statusBar.FindFirst(TreeScope.Descendants,
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Text))
        If onlineText Is Nothing Then Return ""

        Return onlineText.Current.Name
    End Function

    ''' <summary>
    ''' i. Stop call → klik tombol Call lagi (toggle)
    ''' </summary>
    Public Sub EndCall()
        ' Cari tombol End Call berdasarkan AutomationId
        Dim endBtn As AutomationElement = mainWindow.FindFirst(TreeScope.Descendants,
        New PropertyCondition(AutomationElement.AutomationIdProperty, "1055"))

        If endBtn Is Nothing Then
            Throw New Exception("Tombol End Call tidak ditemukan")
        End If

        ' Pastikan tombol aktif
        If endBtn.Current.IsEnabled Then
            Dim invoke As InvokePattern = Nothing
            If endBtn.TryGetCurrentPattern(InvokePattern.Pattern, invoke) Then
                invoke.Invoke()
                Console.WriteLine("Tombol End Call ditekan.")
            Else
                Console.WriteLine("InvokePattern tidak tersedia untuk End Call.")
            End If
        Else
            Console.WriteLine("Tombol End Call tidak aktif.")
        End If
    End Sub

    Public Function IsPhoneTabSelected(mainWindow As AutomationElement) As Boolean
        ' Cari tab dengan nama "Phone"
        Dim phoneTab As AutomationElement = mainWindow.FindFirst(
        TreeScope.Descendants,
        New AndCondition(
            New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem),
            New PropertyCondition(AutomationElement.NameProperty, "Phone")
        ))



        ' Gunakan SelectionItemPattern untuk cek apakah selected
        Dim selItem As Object = Nothing
        If phoneTab.TryGetCurrentPattern(SelectionItemPattern.Pattern, selItem) Then
            Dim pattern As SelectionItemPattern = CType(selItem, SelectionItemPattern)
            Return pattern.Current.IsSelected
        End If

        ' Kalau gagal deteksi, asumsi false
        Return False
    End Function

    Public Sub SwitchToPhoneTab(mainWindow As AutomationElement)
        ' Cari tab dengan nama "Phone"
        Dim phoneTab As AutomationElement = mainWindow.FindFirst(
            TreeScope.Descendants,
            New AndCondition(
                New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.TabItem),
                New PropertyCondition(AutomationElement.NameProperty, "Phone")
            ))

        If phoneTab Is Nothing Then
            Throw New Exception("Tab 'Phone' tidak ditemukan")
        End If

        ' Cek apakah sudah selected
        Dim selItem As Object = Nothing
        If phoneTab.TryGetCurrentPattern(SelectionItemPattern.Pattern, selItem) Then
            Dim pattern As SelectionItemPattern = CType(selItem, SelectionItemPattern)
            If Not pattern.Current.IsSelected Then
                pattern.Select()
                Console.WriteLine("Berhasil switch ke tab Phone.")
            Else
                Console.WriteLine("Tab Phone sudah aktif.")
            End If
        Else
            Throw New Exception("Tab Phone tidak mendukung SelectionItemPattern.")
        End If
    End Sub

    Public Sub InputNumberAndEnableCall(nomor As String)
        ' Pastikan tab Phone aktif
        If Not IsPhoneTabSelected(mainWindow) Then
            SwitchToPhoneTab(mainWindow)
        End If

        ' 1. Pancing klik tombol keypad "8"
        Dim btn8 As AutomationElement = mainWindow.FindFirst(
        TreeScope.Descendants,
        New PropertyCondition(AutomationElement.AutomationIdProperty, "1068"))

        If btn8 IsNot Nothing Then
            Dim inv As InvokePattern = Nothing
            If btn8.TryGetCurrentPattern(InvokePattern.Pattern, inv) Then
                inv.Invoke()
                Thread.Sleep(200)
                inv.Invoke()
                Thread.Sleep(200)
                inv.Invoke()
            End If
        End If

        ' 2. Cari ComboBox (input nomor)
        Dim combo As AutomationElement = mainWindow.FindFirst(
        TreeScope.Descendants,
        New PropertyCondition(AutomationElement.AutomationIdProperty, "1078"))
        If combo Is Nothing Then Throw New Exception("ComboBox tidak ditemukan")

        Dim edit As AutomationElement = combo.FindFirst(
        TreeScope.Descendants,
        New PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit))
        If edit Is Nothing Then Throw New Exception("EditBox dalam ComboBox tidak ditemukan")
        Thread.Sleep(500)
        ' 3. Isi nomor lengkap
        Dim vp As ValuePattern = Nothing
        If edit.TryGetCurrentPattern(ValuePattern.Pattern, vp) Then
            vp.SetValue(nomor)
        End If
        Thread.Sleep(500)

        ' 4. Cari tombol Call
        Dim callBtn As AutomationElement = mainWindow.FindFirst(
        TreeScope.Descendants,
        New PropertyCondition(AutomationElement.AutomationIdProperty, "1022"))
        If callBtn Is Nothing Then Throw New Exception("Tombol Call tidak ditemukan")

        ' Refresh properti tombol Call
        ClickButtonMultiple(callBtn, 2)
    End Sub

    Public Sub ClickButtonMultiple(callBtn As AutomationElement, times As Integer, Optional delayMs As Integer = 300)


        For i As Integer = 1 To times
            If callBtn.Current.IsEnabled Then
                Dim inv As InvokePattern = Nothing
                If callBtn.TryGetCurrentPattern(InvokePattern.Pattern, inv) Then
                    inv.Invoke()

                End If
            Else
                Console.WriteLine($"Klik ke-{i} dilewati (Button disabled)")
            End If

            Thread.Sleep(delayMs) ' jeda antar klik
        Next
    End Sub

End Class
