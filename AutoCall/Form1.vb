Imports System.IO
Imports System.Management
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Imports System.Text
Imports System.Drawing.Drawing2D
Imports System.Net.WebSockets

Public Class Form1

    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New System.Drawing.Point
    Private DataRespon As String = String.Empty
    Private DataParse As Object = Nothing
    Private EnDe As New DeEnCrypt
    Private borderRadius As Integer = 10
    Private borderSize As Integer = 3
    Private borderColor As Color = Color.HotPink
    Private DatR As String = String.Empty
    Private dbJson As New ClassJson

    Private username As String = String.Empty

    Public Event SendDataJson As EventHandler(Of ClassData)
    ''Drag Form
    '<DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
    'Private Shared Sub ReleaseCapture()
    'End Sub
    '<DllImport("user32.DLL", EntryPoint:="SendMessage")>
    'Private Shared Sub SendMessage(ByVal hWnd As System.IntPtr, ByVal wMsg As Integer, ByVal wParam As Integer, ByVal lParam As Integer)
    'End Sub

    Public Property ReceivedData() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub getuser()

        DataRespon = Ap_mrjay59.DataUser
        DataParse = JsonConvert.DeserializeObject(DataRespon)
        DatR = DataRespon
    End Sub

    Private Async Function ConnectoWebSocket(ByVal username As String) As Task

        WSManager.Client = New WebSocketClient()

        AddHandler WSManager.Client.OnConnected,
        Sub()
            WSManager.IsConnected = True
            Debug.WriteLine("WSS CONNECTED")
        End Sub

        AddHandler WSManager.Client.OnDisconnected,
        Sub()
            WSManager.IsConnected = False
            Debug.WriteLine("WSS DISCONNECTED")
        End Sub

        AddHandler WSManager.Client.ConnectionStateChanged, AddressOf wsClient_ConnectionStateChanged
        'AddHandler WSManager.Client.MessageReceived, AddressOf wsClient_MessageReceived

        Await WSManager.Client.ConnectAsync($"wss://ws.autocall.my.id/ws?username={username}")
    End Function

    ' Tangani event perubahan status koneksi
    Private Sub wsClient_ConnectionStateChanged(state As WebSocketState)
        ' Pastikan perubahan UI dilakukan di thread utama
        If LbChatState.InvokeRequired Then
            LbChatState.Invoke(New Action(Of WebSocketState)(AddressOf UpdateStatus), state)
        Else
            UpdateStatus(state)
        End If
    End Sub

    ' Perbarui status di Label
    Private Sub UpdateStatus(state As WebSocketState)
        Select Case state
            Case WebSocketState.Connecting
                LbChatState.Text = "Connecting."
                PnChatState.BackColor = Color.Yellow
            Case WebSocketState.Open
                LbChatState.Text = "Connected"
                PnChatState.BackColor = Color.Orange
            Case WebSocketState.Closed
                LbChatState.Text = "Disconnected"
                PnChatState.BackColor = Color.Red
            Case WebSocketState.Aborted
                LbChatState.Text = "N/A Connect"
                PnChatState.BackColor = Color.Black
            Case Else
                LbChatState.Text = "Unknown"
                PnChatState.BackColor = Color.White
        End Select
    End Sub

    ' Tangani pesan yang diterima
    Public Sub OnMessageSendServer(sender As Object, e As ClassData)
        Dim msg = e.Data
        If WSManager.Client Is Nothing OrElse Not WSManager.Client.IsConnected Then
            Debug.WriteLine("WSS BELUM READY")
            Exit Sub
        End If

        WSManager.Client.SendMessage(msg)

    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        getuser()



    End Sub

    Private Function GetRoundedPath(rect As Rectangle, radius As Single) As GraphicsPath
        Dim path As GraphicsPath = New GraphicsPath()
        Dim curveSize As Single = radius * 2.0F
        path.StartFigure()
        path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90)
        path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90)
        path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90)
        path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Private Sub FormRegionAndBorder(form As Form, radius As Single, graph As Graphics, borderColor As Color, borderSize As Single)
        If Me.WindowState <> FormWindowState.Minimized Then
            Using roundPath As GraphicsPath = GetRoundedPath(form.ClientRectangle, radius)
                Using penBorder As Pen = New Pen(borderColor, borderSize)
                    Using transform As Matrix = New Matrix()
                        graph.SmoothingMode = SmoothingMode.AntiAlias
                        form.Region = New Region(roundPath)
                        If borderSize >= 1 Then
                            Dim rect As Rectangle = form.ClientRectangle
                            Dim scaleX As Single = 1.0F - ((borderSize + 1) / rect.Width)
                            Dim scaleY As Single = 1.0F - ((borderSize + 1) / rect.Height)
                            transform.Scale(scaleX, scaleY)
                            transform.Translate(borderSize / 1.6F, borderSize / 1.6F)
                            graph.Transform = transform
                            graph.DrawPath(penBorder, roundPath)
                        End If
                    End Using
                End Using
            End Using
        End If
    End Sub

    Private Sub ControlRegionAndBorder(control As Control, radius As Single, graph As Graphics, borderColor As Color)
        Using roundPath As GraphicsPath = GetRoundedPath(control.ClientRectangle, radius)
            Using penBorder As Pen = New Pen(borderColor, 1)
                graph.SmoothingMode = SmoothingMode.AntiAlias
                control.Region = New Region(roundPath)
                graph.DrawPath(penBorder, roundPath)
            End Using
        End Using
    End Sub

    Private Sub DrawPath(rectForm As Rectangle, graphics As Graphics, color As Color)
        Using roundPath As GraphicsPath = GetRoundedPath(rectForm, borderRadius)
            Using penBorder As Pen = New Pen(color, 3)
                graphics.DrawPath(penBorder, roundPath)
            End Using
        End Using
    End Sub

    Private Structure FormBoundsColors
        Public TopLeftColor As Color
        Public TopRightColor As Color
        Public BottomLeftColor As Color
        Public BottomRightColor As Color
    End Structure
    Private Function GetFormBoundsColors() As FormBoundsColors
        Dim fbColor = New FormBoundsColors()
        Using bmp = New Bitmap(1, 1)
            Using graph As Graphics = Graphics.FromImage(bmp)
                Dim rectBmp As New Rectangle(0, 0, 1, 1)
                'Top Left
                rectBmp.X = Me.Bounds.X - 1
                rectBmp.Y = Me.Bounds.Y
                'graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.TopLeftColor = bmp.GetPixel(0, 0)
                'Top Right
                rectBmp.X = Me.Bounds.Right
                rectBmp.Y = Me.Bounds.Y
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.TopRightColor = bmp.GetPixel(0, 0)
                'Bottom Left
                rectBmp.X = Me.Bounds.X
                rectBmp.Y = Me.Bounds.Bottom
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0)
                'Bottom Right
                rectBmp.X = Me.Bounds.Right
                rectBmp.Y = Me.Bounds.Bottom
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size)
                fbColor.BottomRightColor = bmp.GetPixel(0, 0)
            End Using
        End Using
        Return fbColor
    End Function
    Private Sub PanelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelHeader.MouseDown
        allowCoolMove = True
        myCoolPoint = New System.Drawing.Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll

        'ReleaseCapture()
        'SendMessage(Me.Handle, &H112, &HF012, 0)
    End Sub

    Private Sub PanelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelHeader.MouseMove
        If allowCoolMove = True Then
            Me.Location = New System.Drawing.Point(Me.Location.X + e.X - myCoolPoint.X, Me.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub PanelHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelHeader.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Lblname_MouseDown(sender As Object, e As MouseEventArgs) Handles Lblname.MouseDown
        allowCoolMove = True
        myCoolPoint = New System.Drawing.Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub Lblname_MouseMove(sender As Object, e As MouseEventArgs) Handles Lblname.MouseMove
        If allowCoolMove = True Then
            Me.Location = New System.Drawing.Point(Me.Location.X + e.X - myCoolPoint.X, Me.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub Lblname_MouseUp(sender As Object, e As MouseEventArgs) Handles Lblname.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub
    Private Async Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim apkname = dbConn.ApkProfile("name")
        Dim apkvers = dbConn.ApkProfile("versi")
        Dim culture As CultureInfo = New CultureInfo("id-ID")


        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim dial = fodev & "\dial\"
        Dim LocAn = fodev & "\LocAn\"
        Dim log = fodev & "\log\"
        Dim wadesktop = fodev & "\wadesktop\"
        Dim WASCANQR = fodev & "\WASCANQR\"

        If (dbConn.IsInternetAvailable() = True) Then
            lblbro.Text = apkname & " " & apkvers

            Dim GetUser As Object = DataParse

            'cek status aplikasi free or premium

            If (GetUser("status")("code") = 1) Then
                For Each item In GetUser("error")
                    MsgBox(item)
                Next

                Me.Close()
                PgLoading.Hide()

                Exit Sub
            End If

            ' Dim apkdata = JsonConvert.DeserializeObject(jsonObject("body")("apk_data"))
            Dim apkstat = GetUser("body")("apk_data")(0)("apk_status")
            username = GetUser("body")("apk_user")
            Dim hp = GetUser("body")("apk_hp")
            Dim tdigit As Decimal = hp.ToString.Substring(hp.ToString.Length - 3, 3)
            Dim harga As Decimal = GetUser("body")("apk_produk")("apk_price")
            Dim fiprice As Decimal = harga + tdigit
            Dim frmhrg As String = fiprice.ToString("C", culture)
            Dim divice As Boolean = GetUser("body")("apk_device")


            Lblname.Text = "Akun " & username
            lbstatus.Text = apkstat

            If (apkstat = "FREE") Then
                Dim page As New FrmReqToken
                PanelView.Controls.Clear()
                page.TopLevel = False
                page.lblprice.Text = frmhrg
                PanelView.Controls.Add(page)
                page.Show()
                Timer1.Start()
                Timer1.Enabled = True
            ElseIf (apkstat = "PRO") Then
                BtnHome_Click(sender, e)
                Timer1.Start()
                Timer1.Enabled = True
            End If


        Else
            MsgBox("Cek Koneksi Internet Anda")
            Me.Close()
            frmLayer1.Close()
            PgLoading.Close()
        End If

        If Not (IO.Directory.Exists(dial)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If Not (IO.Directory.Exists(LocAn)) Then
            IO.Directory.CreateDirectory(LocAn)
        End If

        If Not (IO.Directory.Exists(log)) Then
            IO.Directory.CreateDirectory(log)
        End If

        If Not (IO.Directory.Exists(wadesktop)) Then
            IO.Directory.CreateDirectory(wadesktop)
        End If

        If Not (IO.Directory.Exists(WASCANQR)) Then
            IO.Directory.CreateDirectory(WASCANQR)
        End If

        CopyFolder(dial, FoldeQ)

        Await ConnectoWebSocket(username)
    End Sub

    Public Sub CopyFolder(sourcePath As String, destPath As String)

        If Not Directory.Exists(sourcePath) Then
            MsgBox("Folder sumber tidak ditemukan")
            Exit Sub
        End If

        ' buat folder tujuan jika belum ada
        If Not Directory.Exists(destPath) Then
            Directory.CreateDirectory(destPath)
        End If

        ' copy semua file
        For Each filePath As String In Directory.GetFiles(sourcePath)

            Dim fileName As String = Path.GetFileName(filePath)
            Dim destFile As String = Path.Combine(destPath, fileName)

            File.Copy(filePath, destFile, True)

        Next
        ' copy subfolder
        For Each folder As String In Directory.GetDirectories(sourcePath)
            Dim folderName As String = Path.GetFileName(folder)
            Dim newDest As String = Path.Combine(destPath, folderName)

            CopyFolder(folder, newDest)
        Next

    End Sub
    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        PgLoading.Close()
        client.DisconnectAsync()
    End Sub

    Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles BtnHome.Click

        BtnHome.BackColor = Color.Gray
        BtnPaket.BackColor = Color.Transparent
        BtnMsg.BackColor = Color.Transparent
        BtnCall.BackColor = Color.Transparent
        BtnAtur.BackColor = Color.Transparent


        Dim x = BtnHome.Location.X + BtnHome.Width
        Dim y = BtnHome.Location.Y
        Panelgb.Location = New Point(x, y)
        Panelgb.Height = BtnHome.Height
        Panelgb.Visible = True

        Dim culture As CultureInfo = New CultureInfo("id-ID")
        Dim GetUser As Object = DataParse

        'cek status aplikasi free or premium

        If (GetUser("status")("code") = 1) Then
            For Each item In GetUser("error")
                MsgBox(item)
            Next


            Me.Hide()
            PgLoading.Hide()
            frmLayer1.Show()


            Exit Sub
        End If

        ' Dim apkdata = JsonConvert.DeserializeObject(jsonObject("body")("apk_data"))
        Dim apkstat = GetUser("body")("apk_data")(0)("apk_status")
        Dim hp = GetUser("body")("apk_hp")
        Dim tdigit As Decimal = hp.ToString.Substring(hp.ToString.Length - 3, 3)
        Dim harga As Decimal = GetUser("body")("apk_produk")("apk_price")
        Dim fiprice As Decimal = harga + tdigit
        Dim frmhrg As String = fiprice.ToString("C", culture)
        Dim divice As Boolean = GetUser("body")("apk_device")

        If (apkstat = "FREE") Then
            Dim page As New FrmReqToken
            PanelView.Controls.Clear()
            page.TopLevel = False
            page.lblprice.Text = frmhrg
            PanelView.Controls.Add(page)
            page.Show()
        ElseIf (apkstat = "PRO") Then


            Try
                Dim page As New frmHome
                PanelView.Controls.Clear()
                page.TopLevel = False
                page.Dock = DockStyle.Fill
                page.SendDataUser = DataRespon
                PanelView.Controls.Add(page)
                page.Show()


            Catch ex As Exception

            End Try
        End If


        'Dim apkname = dbConn.ApkProfile("name")
        'Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        'Dim FoldeQ = fodev & "\dial\"

        'If Not (IO.Directory.Exists(fodev)) Then
        '    IO.Directory.CreateDirectory(fodev)
        'End If

        'If Not (IO.Directory.Exists(FoldeQ)) Then
        '    IO.Directory.CreateDirectory(FoldeQ)
        'End If




    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        '-> Smooth Outer Border
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
        Dim rectForm As Rectangle = Me.ClientRectangle
        Dim mWidht As Integer = rectForm.Width / 2
        Dim mHeight As Integer = rectForm.Height / 2
        Dim fbColor = GetFormBoundsColors()
        'Top Left
        DrawPath(rectForm, e.Graphics, fbColor.TopLeftColor)
        'Top Right
        Dim rectTopRight As New Rectangle(rectForm.Right - mWidht, rectForm.Y, mWidht, mHeight)
        DrawPath(rectTopRight, e.Graphics, fbColor.TopRightColor)
        'Bottom Left
        Dim rectBottomLeft As New Rectangle(rectForm.X, rectForm.Bottom - mHeight, mWidht, mHeight)
        DrawPath(rectBottomLeft, e.Graphics, fbColor.BottomLeftColor)
        'Bottom Right
        Dim rectBottomRight As New Rectangle(rectForm.Right - mWidht, rectForm.Bottom - mHeight, mWidht, mHeight)
        DrawPath(rectBottomRight, e.Graphics, fbColor.BottomRightColor)
        '-> Set Rounded Region and Border
        FormRegionAndBorder(Me, borderRadius, e.Graphics, borderColor, borderSize)
    End Sub

    Public Sub BukaMenu(ByVal Menu As String, sender As Object, e As EventArgs)
        If (Menu = "home") Then
            BtnHome_Click(sender, e)
        ElseIf (Menu = "apk") Then
            BtnPaket_Click(sender, e)

        End If
    End Sub

    Private Async Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        'If Not (LbChatState.Text = "Connected") Then
        '    ConnectoWebSocket()
        'End If


        Try
            Dim DRes = Ap_mrjay59.DataUser
            Dim DPar = dbJson.Json2aray(DRes)
            'cek logout atau tidak 

            If WSManager.Client Is Nothing OrElse Not WSManager.Client.IsConnected Then
                Await ConnectoWebSocket(username)
            End If

            If Not (DPar Is Nothing) Then
                ' Dim apk_device As Boolean
                If (DPar("status")("code") = 1) Then
                    Timer1.Stop()

                    Dim PgCall As PgCall = Application.OpenForms.OfType(Of PgCall)().FirstOrDefault()
                    If PgCall IsNot Nothing Then
                        ' Kirim data ke Form2
                        If (PgCall.engine._isRunning) Then
                            PgCall.engine.Stop()
                            ' 🔴 Clear queue
                            PgCall.engine.ClearAll()
                        End If

                    End If

                    Dim frmkirim As frmkirim = Application.OpenForms.OfType(Of frmkirim)().FirstOrDefault()
                    If frmkirim IsNot Nothing Then
                        ' Kirim data ke Form2
                        If frmkirim.cts IsNot Nothing Then
                            frmkirim.cts.Cancel()

                            frmkirim.PnlogActivty.Controls.Clear()


                        End If
                    End If


                    For Each item In DPar("error")

                        MsgBox(item, MsgBoxStyle.OkOnly)
                    Next

                    Me.Close()
                    PgLoading.Close()
                    Exit Sub
                End If

                DatR = DRes
            End If
        Catch ex As Exception

        End Try


        'apk_device = DPar("body")("apk_device")

        'If (apk_device = False) Then
        '    '  MsgBox("")

        'End If
    End Sub

    Private Sub BtnMsg_Click(sender As Object, e As EventArgs) Handles BtnMsg.Click

        BtnHome.BackColor = Color.Transparent
        BtnPaket.BackColor = Color.Transparent
        BtnMsg.BackColor = Color.Gray
        BtnCall.BackColor = Color.Transparent
        BtnAtur.BackColor = Color.Transparent

        Dim x = BtnMsg.Location.X + BtnMsg.Width
        Dim y = BtnMsg.Location.Y
        Panelgb.Location = New Point(x, y)
        Panelgb.Height = BtnMsg.Height
        Panelgb.Visible = True

        If PanelView.Controls.Count > 0 Then
            Dim oldPage As pgMsg = TryCast(PanelView.Controls(0), pgMsg)
            If oldPage IsNot Nothing Then
                RemoveHandler oldPage.SendDataJson, AddressOf OnMessageSendServer
                oldPage.Dispose()
            End If
            PanelView.Controls.Clear()
        End If

        Try
            Dim page As New pgMsg
            PanelView.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DataRespon
            'page.BukaMenu("smartphone", sender, e)
            AddHandler page.SendDataJson, AddressOf OnMessageSendServer
            PanelView.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAtur_Click(sender As Object, e As EventArgs) Handles BtnAtur.Click
        BtnHome.BackColor = Color.Transparent
        BtnPaket.BackColor = Color.Transparent
        BtnMsg.BackColor = Color.Transparent
        BtnCall.BackColor = Color.Transparent
        BtnAtur.BackColor = Color.Gray

        Dim x = BtnAtur.Location.X + BtnAtur.Width
        Dim y = BtnAtur.Location.Y
        Panelgb.Location = New Point(x, y)
        Panelgb.Height = BtnAtur.Height
        Panelgb.Visible = True

        PanelView.Controls.Clear()
        Try
            Dim page As New PgAturvb
            PanelView.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DataRespon
            'page.BukaMenu("smartphone", sender, e)
            PanelView.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCall_Click(sender As Object, e As EventArgs) Handles BtnCall.Click
        BtnHome.BackColor = Color.Transparent
        BtnPaket.BackColor = Color.Transparent
        BtnMsg.BackColor = Color.Transparent
        BtnCall.BackColor = Color.Gray
        BtnAtur.BackColor = Color.Transparent

        Dim x = BtnCall.Location.X + BtnCall.Width
        Dim y = BtnCall.Location.Y
        Panelgb.Location = New Point(x, y)
        Panelgb.Height = BtnCall.Height
        Panelgb.Visible = True


        PanelView.Controls.Clear()
        Try
            Dim page As New PgCAtur
            PanelView.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DataRespon
            PanelView.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPaket_Click(sender As Object, e As EventArgs) Handles BtnPaket.Click
        BtnHome.BackColor = Color.Transparent
        BtnPaket.BackColor = Color.Gray
        BtnMsg.BackColor = Color.Transparent
        BtnCall.BackColor = Color.Transparent
        BtnAtur.BackColor = Color.Transparent


        Dim x = BtnPaket.Location.X + BtnPaket.Width
        Dim y = BtnPaket.Location.Y
        Panelgb.Location = New Point(x, y)
        Panelgb.Height = BtnPaket.Height
        Panelgb.Visible = True


        PanelView.Controls.Clear()
        Try
            Dim page As New frmApk
            PanelView.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DataRespon
            ' page.BukaMenu("smartphone", sender, e)
            PanelView.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnLogot_Click(sender As Object, e As EventArgs) Handles BtnLogot.Click
        Dim apkname = dbConn.ApkProfile("name")
        Dim apkvers = dbConn.ApkProfile("versi")
        Dim DPar = dbJson.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString
        Dim serial As String = EnDe.GetIdDevice
        Dim DbSource As String = dbConn.SearchPATH()
        Dim soudb = JsonConvert.DeserializeObject(DbSource)
        Dim getoken = soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname)
        Dim userpc As String = EnDe.GetUserName.Trim

        ' service data parameter
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("apk_produk", apkname)
        param.Add("prdversi", apkvers)
        param.Add("prdmsin", serial)
        param.Add("devname", userpc)
        param.Add("token", getoken)




        Dim msg = "Apa Yakin Mau Logout? Service yang berjalan akan terhenti "

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            Ap_mrjay59.logout(param)
            Threading.Thread.Sleep(2000)
            Dim PgCall As PgCall = Application.OpenForms.OfType(Of PgCall)().FirstOrDefault()
            If PgCall IsNot Nothing Then
                ' Kirim data ke Form2
                PgCall.IsStopped = True
            End If

            Dim frmkirim As frmkirim = Application.OpenForms.OfType(Of frmkirim)().FirstOrDefault()
            If frmkirim IsNot Nothing Then
                ' Kirim data ke Form2
                If frmkirim.cts IsNot Nothing Then
                    frmkirim.cts.Cancel()

                    frmkirim.PnlogActivty.Controls.Clear()


                End If
            End If
            Me.Close()
            frmLayer1.Close()
            PgLoading.TopLevel = True
            PgLoading.Startimer()
            PgLoading.Show()
        End If
    End Sub

    Private Sub BtnNotif_Click(sender As Object, e As EventArgs) Handles BtnNotif.Click
        BtnHome.BackColor = Color.Transparent
        BtnPaket.BackColor = Color.Transparent
        BtnMsg.BackColor = Color.Transparent
        BtnCall.BackColor = Color.Transparent
        BtnAtur.BackColor = Color.Transparent
        BtnNotif.BackColor = Color.Gray



        Try
            Dim page As New pgNotifikasi
            'page.SendDataUser = DatR
            'page.BukaMenu("smartphone", sender, e)
            'AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
            page.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
