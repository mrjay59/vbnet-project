Imports System.Drawing.Drawing2D
Imports AutoCall
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq


Public Class pgMsg
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private DatR As String = String.Empty
    Private DataJson = Nothing
    Private WApp As New WhatsAppClass
    Public Event SendDataJson As EventHandler(Of ClassData)
    Private lastDateDisplayed As Date = Date.MinValue
    Private WithEvents pnlMessageList As New FlowLayoutPanel()

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub LoadDataServer()

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("platform", "wascanqr")
        param.Add("all", "open")
        ' "wascanqr"
        Dim ListWA As String = WApp.OnListServer(param)
        ' Data JSON Anda
        Dim jsonString As String = ListWA



    End Sub

    Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click

        BtnNotRead.BackColor = Color.Transparent
        BtnAll.BackColor = Color.Gray
        BtnNewMsg.BackColor = Color.Transparent


        Dim x = BtnAll.Location.X
        Dim y = BtnAll.Location.Y + BtnAll.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnAll.Width
        Panelgb.Visible = True

        Dim page As New ChatListForm
        PnChatList.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        page.SendDataUser = DatR
        page.SearchFromDisplayed("")
        AddHandler page.SendDataJson, AddressOf OnClickMessage
        PnChatList.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub BtnNotRead_Click(sender As Object, e As EventArgs) Handles BtnNotRead.Click
        BtnNotRead.BackColor = Color.Gray
        BtnAll.BackColor = Color.Transparent
        BtnNewMsg.BackColor = Color.Transparent


        Dim x = BtnNotRead.Location.X
        Dim y = BtnNotRead.Location.Y + BtnNotRead.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnNotRead.Width
        Panelgb.Visible = True
    End Sub

    Private Sub BtnNewMsg_Click(sender As Object, e As EventArgs) Handles BtnNewMsg.Click

        BtnNotRead.BackColor = Color.Transparent
        BtnAll.BackColor = Color.Transparent
        BtnNewMsg.BackColor = Color.Gray

        Dim x = BtnNewMsg.Location.X
        Dim y = BtnNewMsg.Location.Y + BtnNewMsg.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnNewMsg.Width
        Panelgb.Visible = True


        Dim jsonObj As JObject = JObject.Parse(DatR)
        Dim datserObj = jsonObj("body")("dataserver")("apk_data")

        Dim apk_tglexp As Long = jsonObj("body")("dataserver")("apk_tglexp")
        Dim apk_time As Long = jsonObj("body")("apk_time")

        Dim unixTime As Long = apk_tglexp
        Dim epoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
        Dim localTime As DateTime = epoch.AddSeconds(unixTime).ToLocalTime()

        Dim msg = "Batas Waktu Sudah Expired: " & localTime.ToString("yyyy-MM-dd HH:mm:ss") & Environment.NewLine +
                 "Halaman ini tidak dapat Akses" + Environment.NewLine + Environment.NewLine

        If (apk_time > apk_tglexp) Then
            MsgBox(msg)

            Exit Sub
        End If

        Try
            Dim page As New PgKirim
            page.SendDataUser = DatR
            'page.BukaMenu("smartphone", sender, e)

            page.ShowDialog()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNewMsg_Paint(sender As Object, e As PaintEventArgs) Handles BtnNewMsg.Paint
        Dim width = BtnNewMsg.Width
        Dim Height = BtnNewMsg.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 20 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnNewMsg.Region = New Region(path)
    End Sub

    Private Sub BtnAll_Paint(sender As Object, e As PaintEventArgs) Handles BtnAll.Paint
        Dim width = BtnAll.Width
        Dim Height = BtnAll.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 20 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnAll.Region = New Region(path)
    End Sub

    Private Sub BtnNotRead_Paint(sender As Object, e As PaintEventArgs) Handles BtnNotRead.Paint
        Dim width = BtnNotRead.Width
        Dim Height = BtnNotRead.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 20 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnNotRead.Region = New Region(path)
    End Sub

    Private Sub pgMsg_Load(sender As Object, e As EventArgs) Handles Me.Load

        BtnAll_Click(sender, e)


        TextSearch.Text = PlaceholderText
        TextSearch.ForeColor = Color.Gray
    End Sub

    Private Sub OnClickMessage(sender As Object, e As ClassData)
        Dim Datjson = e.Data
        pnlMessageList.Controls.Clear()
        ' Setup panel untuk menampung pesan
        SetupMessagePanel()

        ' Contoh data pesan
        listMessages(Datjson) ' Generate 100 pesan contoh

        PictureBox1.Visible = True
        Label1.Visible = True
        Label2.Visible = True
        BtnWA.Visible = True
        BtnSIP.Visible = True

    End Sub

    Private Sub SetupMessagePanel()
        pnlMessageList.Dock = DockStyle.Fill
        pnlMessageList.AutoScroll = True
        pnlMessageList.FlowDirection = FlowDirection.TopDown
        pnlMessageList.WrapContents = False
        pnlMessageList.AutoSize = False
        pnlMessageList.AutoScrollMinSize = New Size(0, 0)
        pnlMessageList.HorizontalScroll.Enabled = False
        pnlMessageList.HorizontalScroll.Visible = False
        pnlMessageList.VerticalScroll.Enabled = True
        pnlMessageList.VerticalScroll.Visible = True
        pnlMessageList.Width = 717 ' Lebar sesuai permintaan
        PnMessage.Controls.Add(pnlMessageList)
    End Sub

    Private Sub listMessages(Datjson As String)
        pnlMessageList.SuspendLayout()


        Dim DPar = jsonpa.Json2aray(Datjson)
        Dim username = DPar("username")
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("platform", DPar("Platform"))
        param.Add("tipe", "chatlist")
        param.Add("nosender", DPar("PhoneSender"))
        param.Add("tonu", DPar("PhoneNumber"))

        Label1.Text = DPar("PhoneNumber")
        Label2.Text = $"{DPar("Platform")}-{DPar("PhoneSender")}"
        Label1.Tag = Datjson

        ComboBox1.Text = DPar("SessionId").ToString
        Label5.Text = DPar("PhoneSender").ToString

        Dim ListWA As String = WApp.OnDetailMsg(param)
        Dim Datlist As JArray = jsonpa.Json2aray(ListWA)


        ' Contoh data dummy (ganti dengan data sebenarnya)
        For i As Integer = 0 To Datlist.Count - 1
            Dim tujuan As String = String.Empty
            Dim NumText As String = Datlist(i)("aichat_from")
            Dim isgroup As String = Datlist(i)("aichat_isgroup")
            Dim isOutbox As Boolean = IIf(Datlist(i)("aichat_type") = "Inbox", False, True)
            Dim waktu As Date = Datlist(i)("aichat_datetime")
            Dim sessionId As String = Datlist(i)("aichat_waname")
            Dim sstate As String = Datlist(i)("aichat_state")

            AddDateHeaderIfNeeded(waktu)
            Dim rawText As String = Datlist(i)("aichat_text").ToString()
            Dim cleanText As String = rawText.Replace(vbLf, vbCrLf)


            Dim bubble As New MessageBubble()
            bubble.TimeText = waktu.ToString("T")
            bubble.IsOutbox = isOutbox
            bubble.MessageText = cleanText
            '  bubble.ContentType.Text = MessageBubble.ContentType.Text

            If bubble.IsOutbox Then
                bubble.StatusText = If(sstate = "false", "!! Gagal Terkirim", "✓ Terkirim")
                bubble.SenderText = $"#{NumText} {sessionId}"
            Else
                bubble.SenderText = $"#{NumText}"
            End If
            bubble.Width = pnlMessageList.Width - 25 ' Beri ruang untuk scrollbar


            pnlMessageList.Controls.Add(bubble)
        Next





        pnlMessageList.ResumeLayout(True)

        ' Scroll ke bawah
        ScrollToBottom()
    End Sub

    Private Sub AddDateHeaderIfNeeded(msgDate As Date)
        ' Tampilkan header hanya jika tanggal berbeda dengan sebelumnya
        If msgDate.Date <> lastDateDisplayed.Date Then
            lastDateDisplayed = msgDate

            ' Buat label header tanggal
            Dim lblHeader As New Label()
            lblHeader.Text = GetDateDisplayText(msgDate)
            lblHeader.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            lblHeader.ForeColor = Color.White
            lblHeader.BackColor = Color.Transparent
            lblHeader.TextAlign = ContentAlignment.MiddleCenter
            lblHeader.Dock = DockStyle.Top
            lblHeader.Height = 20
            lblHeader.Width = pnlMessageList.Width - 25
            lblHeader.Margin = New Padding(0, 10, 0, 5)

            pnlMessageList.Controls.Add(lblHeader)
        End If
    End Sub

    Private Function GetDateDisplayText(dt As Date) As String
        Dim today As Date = Date.Today

        If dt.Date = today Then
            Return "HARI INI"
        ElseIf dt.Date = today.AddDays(-1) Then
            Return "KEMARIN"
        Else
            Return dt.ToString("dd MMM yyyy").ToUpper()
        End If
    End Function

    Private Sub ScrollToBottom()
        If pnlMessageList.VerticalScroll.Visible Then
            pnlMessageList.VerticalScroll.Value = pnlMessageList.VerticalScroll.Maximum
        End If
    End Sub

    ' Event untuk scroll otomatis saat ukuran berubah
    Private Sub pnlMessageList_ControlAdded(sender As Object, e As ControlEventArgs) Handles pnlMessageList.ControlAdded
        ScrollToBottom()
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim Datjson As String = Label1.Tag
        Dim WaName As String = ComboBox1.Text
        Dim SenderNo As String = Label5.Text

        Dim DPar = jsonpa.Json2aray(Datjson)
        Dim username = DPar("username")


        Dim textmsg As String = TextMessage.Text
        AddDateHeaderIfNeeded(Date.Now)
        Dim bubble As New MessageBubble()

        bubble.IsOutbox = True
        bubble.MessageText = textmsg
        bubble.TimeText = DateTime.Now.ToString("T")
        bubble.SenderText = SenderNo
        bubble.Width = pnlMessageList.Width - 25

        pnlMessageList.Controls.Add(bubble)

        Dim jsdata, jsdata1 As New JObject
        Dim jsArr As New JArray
        jsdata.Add("name", WaName)
        jsdata.Add("username", username)
        jsdata.Add("tonum", DPar("PhoneNumber"))
        jsdata.Add("tsender", DPar("PhoneSender"))
        jsdata.Add("text", textmsg)
        jsdata.Add("metCall", "wascanqr")
        jsdata.Add("func", "OnReceive")
        jsdata1.Add("body", jsArr)
        jsArr.Add(jsdata)

        RaiseEvent SendDataJson(Me, New ClassData(jsdata1.ToString))
        TextMessage.Text = ""
    End Sub

    Private Sub TextMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles TextMessage.KeyDown
        If e.KeyCode = Keys.Enter Then
            If e.Shift Then
                ' SHIFT + ENTER → tambahkan newline secara manual
                Dim tb As TextBox = CType(sender, TextBox)
                tb.SelectedText = vbCrLf

                ' Biarkan default berjalan (jangan suppress)
                e.SuppressKeyPress = True ' Hindari dobel newline (optional)
            Else
                ' Hanya ENTER ditekan
                btnSend_Click(sender, e)
                ' Opsional: cegah ding-dong sound atau line break (jika multiline)
                e.SuppressKeyPress = True
            End If


        End If
    End Sub

    Private Sub TextSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles TextSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim keyword As String = TextSearch.Text.Trim()

            Dim page As New ChatListForm
            PnChatList.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DatR
            page.SearchFromDisplayed(keyword)
            AddHandler page.SendDataJson, AddressOf OnClickMessage
            PnChatList.Controls.Add(page)
            page.Show()
        End If
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


End Class