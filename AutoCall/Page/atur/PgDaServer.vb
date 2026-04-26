Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports QRCoder

Public Class PgDaServer

    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private mjy As New mrjay59
    Public Event SendDataJson As EventHandler(Of ClassData)
    Private WithEvents paging As New PagingControl()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub CreateButton()
        ' Bersihkan panel terlebih dahulu jika perlu
        Panel2.Controls.Clear()
        PnDScanQr.Controls.Clear()
        Dim spacing As Integer = 5 ' Jarak antar tombol
        Dim btnWidth As Integer = 100
        Dim btnHeight As Integer = 30


        Dim jsonObj As JObject = JObject.Parse(DatR)
        Dim datserObj = jsonObj("body")("dataserver")("apk_data")

        Dim apk_tglexp As Long = jsonObj("body")("dataserver")("apk_tglexp")
        Dim apk_time As Long = jsonObj("body")("apk_time")

        Dim unixTime As Long = apk_tglexp
        Dim epoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        Dim localTime As DateTime = epoch.AddSeconds(unixTime).ToLocalTime()

        Label6.Visible = True
        Label6.Text = "Expired :" & localTime.ToString("yyyy-MM-dd")
        Dim msg = "Batas Waktu Sudah Expired: " & localTime.ToString("yyyy-MM-dd HH:mm:ss") & Environment.NewLine +
                 "Halaman ini tidak dapat Akses" + Environment.NewLine + Environment.NewLine

        If (apk_time > apk_tglexp) Then
            MsgBox(msg)

            Exit Sub
        End If

        Dim jsonObj2 As JObject = JObject.Parse(datserObj)

        Dim gpropObj As IEnumerable(Of JProperty) = jsonObj2.Properties()
        Dim h As Integer = 0
        For Each prop As JProperty In gpropObj

            Dim Platform As String = prop.Name
            Dim jmlh As Integer = jsonObj2(prop.Name)("totuse")
            Dim state As String = jsonObj2(prop.Name)("state")

            Dim btn As New Button()
            btn.Name = Platform
            btn.Text = Platform.ToUpper
            btn.Font = New Font("Microsoft Sans Serif", 8.25)
            btn.FlatStyle = FlatStyle.Flat
            btn.FlatAppearance.BorderSize = 0
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent
            btn.BackColor = Color.Transparent
            btn.ForeColor = Color.Black
            btn.Cursor = Cursors.Hand
            btn.Width = btnWidth
            btn.Height = btnHeight
            btn.Left = h * (btnWidth + spacing)
            btn.Top = 5 ' Tetap di baris yang sama

            h = h + 1
            ' Tambahkan ke Panel1
            Panel2.Controls.Add(btn)

            ' Event handler (opsional)
            AddHandler btn.Click, AddressOf ShowPage



        Next



    End Sub

    ' Function untuk memeriksa apakah kontrol dengan nama tertentu sudah ada di Panel
    Private Function IsControlInPanelByName(panel As Panel, controlName As String) As Boolean
        For Each ctrl As Control In panel.Controls
            If ctrl.Name = controlName Then
                Return True
            End If
        Next
        Return False
    End Function

    Function GenerateQRCode(inputText As String) As Bitmap
        ' Buat objek QRCodeGenerator
        Dim qrGenerator As New QRCodeGenerator()
        ' Buat data QR Code
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q)
        ' Buat QR Code dari data
        Dim qrCode As New QRCode(qrCodeData)
        ' Render QR Code sebagai gambar Bitmap
        Dim qrCodeImage As Bitmap = qrCode.GetGraphic(30)

        Return qrCodeImage
    End Function

    Public Sub OnReceiveData(sender As Object, e As ClassData)
        Dim msg = e.Data
        Console.WriteLine(msg)
        Dim apkname = dbConn.ApkProfile("name")
        Dim mmsg As String = String.Empty
        Dim sessionId As String = String.Empty
        '  "message": "connectionState: {\"qr\":\"2@FnC3ruK/Bm+qit4aPtDUYhJlxQj9yzq9dpFJZuG/galDHpzIIEPBDM2cpC/KCj2h+r2VvhYwkLKhsJzZZ8JH3esL8Xt5IliwG0c=,ur9ZoJVGz17aS49PrcQQMONoQgqHs9UZYebw+KKNkAw=,ME9d0DA7K+H5ELtxOqIdNNTCKRCuc0+BxA7StEzSRmo=,ROWyoH7rWGKVVTGoGDvphYvGcNO6KnN2KMBTTD2ajD4=\"}",
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\WASCANQR"

        If Not (Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If


        If msg.IndexOf("connectionState") > 0 AndAlso msg.IndexOf("qr") > 0 Then
            Dim QQrode As String = String.Empty
            Dim WSanArr = jsonpa.Json2aray(msg)
            Dim XXmsg As String = WSanArr("message").ToString.Replace("connectionState:", "")
            sessionId = WSanArr("sessionId").ToString
            Dim QrrArr = jsonpa.Json2aray(XXmsg)
            '  Dim WCanResp As String = XXmsg(2)
            QQrode = QrrArr("qr")

            If Not IsNothing(QQrode) Then
                'Dim payload As String = QQrode.ToString()
                ' Panggil function untuk generate QR Code
                Dim qrCodeImage As Bitmap = GenerateQRCode(QQrode)

                ' Simpan QR Code sebagai file gambar
                Dim filePath As String = FoldeQ & $"\qrcode_{sessionId}.png"

                If (IO.File.Exists(filePath)) Then
                    File.Delete(filePath)
                End If

                qrCodeImage.Save(filePath, Imaging.ImageFormat.Png)
            End If

            mmsg = "Create Qrcode...." & QQrode

        ElseIf msg.IndexOf("connectionState") > 0 AndAlso msg.IndexOf("connection") > 0 Then
            Dim WSanArr = jsonpa.Json2aray(msg)
            Dim XXmsg As String = WSanArr("message").ToString.Replace("connectionState:", "")
            sessionId = WSanArr("sessionId").ToString
            Dim QrrArr = jsonpa.Json2aray(XXmsg)
            mmsg = QrrArr("connection").ToString

        Else

            Dim XXmsg As String = jsonpa.dencode(msg, "message")
            sessionId = jsonpa.dencode(msg, "sessionId")
            mmsg = XXmsg
        End If

        For Each ctrl As Control In PnListServer.Controls
            If TypeOf ctrl Is UClistScanQr Then
                Dim item = DirectCast(ctrl, UClistScanQr)
                Dim lblText = item.LblSeassionId.Text
                Dim Seassionid As String() = lblText.Split("-")


                If Not (Seassionid(0) = sessionId) Then
                    If msg.IndexOf("Ready") >= 0 OrElse msg.IndexOf("Failure") >= 0 _
                                                         OrElse msg.IndexOf("Timeout") >= 0 OrElse msg.IndexOf("ERR_NAME") >= 0 Then
                        item.Btnstt.Enabled = True
                        item.BtnLOut.Enabled = True
                    End If
                End If

            End If
        Next



        For Each control As UCScanQR In PnDScanQr.Controls.OfType(Of UCScanQR)()
            Dim sesid = control.LbWAnm.Text.Trim

            If (sesid = sessionId) Then
                Dim qrcodePath As String = FoldeQ & $"\qrcode_{sessionId}.png"

                Try

                    If File.Exists(qrcodePath) Then

                        Dim qrCode As Image


                        Using originalImage As New Bitmap(qrcodePath)
                            qrCode = New Bitmap(originalImage, New Point(195, 195))

                        End Using

                        If msg.IndexOf("Ready") >= 0 OrElse msg.IndexOf("Failure") >= 0 _
                                                          OrElse msg.IndexOf("Timeout") >= 0 OrElse msg.IndexOf("ERR_NAME") >= 0 Then



                            'image close 
                            control.LblR.Visible = True
                            control.LblR.Text = "Ready"
                            control.picQRCode.Visible = False
                            File.Delete(qrcodePath)

                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)
                        Else
                            ' update UI dari thread yang berbeda
                            control.LblR.Visible = False
                            control.picQRCode.Invoke(
                                                                              Sub()
                                                                                  control.picQRCode.Visible = True
                                                                                  control.picQRCode.Image = qrCode
                                                                              End Sub)


                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)


                        End If


                    Else

                        If msg.IndexOf("Ready") >= 0 OrElse msg.IndexOf("Failure") >= 0 _
                                                          OrElse msg.IndexOf("Timeout") >= 0 OrElse msg.IndexOf("ERR_NAME") >= 0 Then



                            'image close 
                            control.LblR.Visible = True
                            control.LblR.Text = "Ready"
                            control.picQRCode.Visible = False


                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)
                        Else


                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)


                        End If
                    End If

                Catch ex As Exception

                End Try




            End If
        Next


    End Sub

    Public Sub ScanQrSingle(sender As Object, e As ClassData)
        PnDScanQr.Controls.Clear()
        ' Add any initialization after the InitializeComponent() call.
        Dim DatObj = e.Data
        RaiseEvent SendDataJson(Me, New ClassData(DatObj.ToString))
        Dim PObj = jsonpa.Json2aray(DatObj)
        Dim sessionId As String = PObj("body")(0)("name")
        Dim msg As String = PObj("body")(0)("msg")
        Dim funcx As String = PObj("body")(0)("func")

        If (funcx = "OnService") Then
            Dim ScanQr As New UCScanQR
            ScanQr.Location = New Point(31, 31)
            ScanQr.LbWAnm.Text = sessionId
            ScanQr.LblR.Text = msg
            ScanQr.LblR.Visible = True
            ScanQr.lstLog.Items.Add(String.Format("[Sesi : {0}]  {1} ", sessionId, msg))
            PnDScanQr.Controls.Add(ScanQr)
        End If


    End Sub

    Private activeButton As Button = Nothing
    Private activeLinePanel As Panel = Nothing
    Private Sub ShowPage(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim namaTombol As String = btn.Name
        Dim platform As String = btn.Text

        ' Reset tampilan tombol sebelumnya
        If activeButton IsNot Nothing Then
            activeButton.BackColor = Color.Transparent
        End If

        TextSearch.Tag = platform
        ' Tandai tombol yang aktif
        btn.BackColor = Color.LightBlue
        activeButton = btn

        PnAddForm.Controls.Clear()

        Dim jsonObj As JObject = JObject.Parse(DatR)
        Dim datserObj = jsonObj("body")("dataserver")("apk_data")
        Dim jsonObj2 As JObject = JObject.Parse(datserObj)

        If (jsonObj2.Count = 0) Then
            MsgBox("FITUR INI BELUM AKTIF Silahkan Upgrade AKUN")
            Exit Sub
        End If

        Dim jmlh As Integer = jsonObj2(platform.ToLower)("totuse")
        Dim state As String = jsonObj2(platform.ToLower)("state")

        Label4.Text = "State : " & state
        Label2.Text = "Maksimal WA : " & jmlh

        Label4.Visible = True
        Label2.Visible = True

        If (platform.Trim = "WASERVER") Then
            Label1.Text = "Tambahkan WA Server"
            Try
                Dim page As New WAServerForm
                page.TopLevel = False
                page.Dock = DockStyle.Fill
                page.SendDataUser = DatR
                'page.BukaMenu("smartphone", sender, e)

                PnAddForm.Controls.Add(page)
                page.Show()

            Catch ex As Exception

            End Try
        ElseIf (platform.Trim = "WASCANQR") Then
            Label1.Text = "Tambahkan  WA ScanQr"

            If PnAddForm.Controls.Count > 0 Then
                Dim oldPage As WAScanQrForm = TryCast(PnAddForm.Controls(0), WAScanQrForm)
                If oldPage IsNot Nothing Then
                    RemoveHandler oldPage.SendDataJson, AddressOf Form1.OnMessageSendServer
                    oldPage.Dispose()
                End If
                PnAddForm.Controls.Clear()
            End If
            Try
                Dim page As New WAScanQrForm
                page.TopLevel = False
                page.Dock = DockStyle.Fill
                page.SendDataUser = DatR
                'page.BukaMenu("smartphone", sender, e)
                AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer

                PnAddForm.Controls.Add(page)
                page.Show()

                'RemoveHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer

            Catch ex As Exception

            End Try
        ElseIf (platform.Trim = "WAFORWARD") Then
            Label1.Text = "Tambahkan WA Forward"
            Try
                Dim page As New WAForwardForm
                page.TopLevel = False
                page.Dock = DockStyle.Fill
                page.SendDataUser = DatR
                'page.BukaMenu("smartphone", sender, e)

                PnAddForm.Controls.Add(page)
                page.Show()

            Catch ex As Exception

            End Try

        End If

        LoadData(1, "")




    End Sub

    Private Sub LoadData(page As Integer, keyword As String)
        Dim platform = TextSearch.Tag
        Dim param As New Dictionary(Of String, String)
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        param.Add("username", username)
        param.Add("platform", platform.ToLower)
        param.Add("paging", page)
        param.Add("carik", keyword)
        param.Add("all", "no")

        Dim ListWA As String = WApp.OnListServer(param)
        ' Console.WriteLine(ListWA)
        Dim DatParse = jsonpa.Json2aray(ListWA)
        Dim totpage As Integer = DatParse("body")("totalpage")
        Dim datSer As JArray = DatParse("body")("data")
        ' RaiseEvent SendDataJson(Me, New ClassData(ListWA.ToString))
        PnListServer.Controls.Clear()


        If (page = 1) Then
            '  paging.Location = New Point(20, 300)
            paging.Size = New Size(460, 40)
            PnPaging.Controls.Add(paging)
            paging.Setup(Math.Round(totpage), 1) ' total halaman 10
        End If

        RemoveHandler Form1.SendDataJson, AddressOf OnReceiveData

        AddHandler Form1.SendDataJson, AddressOf OnReceiveData

        Try
            Dim a = 0
            Dim op = 0
            For Each item In datSer

                Dim Name As String = item("aichat_name")
                Dim number As String = item("aichat_number")
                Dim service = item("aichat_service")
                Dim pl = item("aichat_platform")

                Dim IsCon As String = String.Empty
                Dim Colors As Color
                Dim CtWA As New UClistScanQr

                If (pl = "wascanqr") Then
                    If (service = "CONNECTED") Then
                        IsCon = "Stop Service"
                        Colors = Color.Orange
                        CtWA.BtnLOut.Text = "LogOut"
                        CtWA.Btnstt.ForeColor = Color.Black
                    ElseIf (service = "OPEN") Then
                        op = op + 1
                        IsCon = "Stop Service"
                        Colors = Color.Orange
                        CtWA.BtnLOut.Text = "LogOut"
                        CtWA.BtnLOut.Visible = True
                        CtWA.Btnstt.ForeColor = Color.Black
                    ElseIf (service = "CLOSE") Then
                        IsCon = "Start Service"
                        Colors = Color.FromArgb(80, 165, 190)
                        CtWA.Btnstt.ForeColor = Color.White
                        'CtWA.BtnLOut.Enabled = False
                        CtWA.BtnLOut.Visible = False
                    ElseIf (service = "CONNECTING") Then
                        IsCon = "Start Service"
                        Colors = Color.FromArgb(80, 165, 190)
                        CtWA.Btnstt.ForeColor = Color.White
                        'CtWA.BtnLOut.Enabled = False
                    End If
                ElseIf (pl = "waforward") Then
                    If (service = "OPEN") Then
                        op = op + 1
                        IsCon = "Stop Service"
                        Colors = Color.Orange
                        CtWA.BtnLOut.Text = "Delete"
                        CtWA.BtnLOut.Visible = True
                        CtWA.Btnstt.ForeColor = Color.Black
                    ElseIf (service = "CLOSE") Then
                        IsCon = "Start Service"
                        Colors = Color.FromArgb(80, 165, 190)
                        'CtWA.BtnLOut.Enabled = False
                        CtWA.BtnLOut.Visible = True
                    End If
                End If

                a = a + 1
                Dim c = a - 1
                Dim pin = c * 45 + 3
                CtWA.LbNo.Text = a
                CtWA.LblSeassionId.Text = $"{Name}-{number}"
                CtWA.LblSeassionId.Tag = pl
                CtWA.Btnstt.Text = IsCon
                CtWA.Btnstt.BackColor = Colors

                CtWA.PnState.BackColor = Colors
                CtWA.ContextMenuStrip = CtWA.ContextMenuStrip1

                CtWA.Location = New Point(9, pin)
                CtWA.SendDataUser = DatR


                AddHandler CtWA.SendDataJson, AddressOf ScanQrSingle
                AddHandler CtWA.ButtonClicked, AddressOf startClick
                PnListServer.Controls.Add(CtWA)


            Next

        Catch ex As Exception

        End Try
    End Sub

    Private Sub startClick(sender As Object, isActive As Boolean)
        Dim platform = TextSearch.Tag
        For Each ctrl As Control In PnListServer.Controls
            If TypeOf ctrl Is UClistScanQr Then
                Dim item = DirectCast(ctrl, UClistScanQr)
                Dim STAKSE = item.Btnstt.Text

                If item Is sender Then
                    ' Biarkan tombol yang diklik tetap aktif sesuai status barunya
                    item.Btnstt.Enabled = True
                    item.BtnLOut.Enabled = True
                    item.IsActive = isActive
                Else

                    If (STAKSE = "Start Service") Then
                        ' Jika tombol yang diklik aktif, disable tombol lain
                        item.Btnstt.Enabled = Not isActive
                        item.BtnLOut.Enabled = Not isActive
                        item.IsActive = False
                    End If

                End If
                ' item.BackColor = If(item.IsActive, Color.LightBlue, SystemColors.Control)

            End If
        Next
    End Sub

    Private Sub Paging_PageChanged(page As Integer) Handles paging.PageChanged

        LoadData(page, "")
    End Sub

    Private Sub PgDaServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateButton()

    End Sub

    ' Atur placeholder dinamis
    Private Const PlaceholderText As String = "Cari nomor..."

    Private Sub txtSearch_GotFocus(sender As Object, e As EventArgs) Handles TextSearch.GotFocus
        If TextSearch.Text = PlaceholderText Then
            TextSearch.Text = ""
            TextSearch.ForeColor = Color.White
        End If
    End Sub

    Private Sub txtSearch_LostFocus(sender As Object, e As EventArgs) Handles TextSearch.LostFocus
        If String.IsNullOrWhiteSpace(TextSearch.Text) Then
            TextSearch.Text = PlaceholderText
            TextSearch.ForeColor = Color.Gray
        End If
    End Sub


    Private Sub TextSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextSearch.KeyPress
        ' Izinkan hanya angka 0-9, backspace, dan delete
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim keyword As String = TextSearch.Text.Trim()

            LoadData(1, keyword)

        End If
    End Sub


End Class