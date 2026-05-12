Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.Http
Imports System.Security.Cryptography
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports System.Windows.Interop
Imports Mysqlx.XDevAPI
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class pgMsg
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private deEn As New DeEnCrypt
    Private DatR As String = String.Empty
    Private DataJson = Nothing
    Private WApp As New WhatsAppClass

    Private lastDateDisplayed As Date = Date.MinValue
    Private WithEvents pnlMessageList As New FlowLayoutPanel()

    Private CurrentChat As ChatItem = Nothing


    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub BtnAll_Click(sender As Object, e As EventArgs) Handles BtnAll.Click

        AddHandler WSManager.Client.MessageReceived, AddressOf wsClient_MessageReceived
        BtnNotRead.BackColor = Color.Transparent
        BtnAll.BackColor = Color.Gray
        BtnNewMsg.BackColor = Color.Transparent


        Dim x = BtnAll.Location.X
        Dim y = BtnAll.Location.Y + BtnAll.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnAll.Width
        Panelgb.Visible = True

        Dim page As New ChatListForm
        page.ParentMsgForm = Me
        PnChatList.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        page.SendDataUser = DatR
        page.SearchFromDisplayed("", "")
        PnChatList.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub wsClient_MessageReceived(message As String)

        If (message Is Nothing) Then Exit Sub

        Dim arrj = jsonpa.Json2aray(message)

        If (arrj("event") IsNot Nothing) Then
            If arrj("event").ToString = "message" Then
                OnMessageReceived(message)
            ElseIf (arrj("event").ToString = "message.ack") Then
                OnMessageAck(message)
            End If
        End If

    End Sub

    Private Sub OnMessageAck(json As String)

        Try

            Dim obj = jsonpa.Json2aray(json)

            Dim msgId As String =
            obj("payload")("payload")("id").ToString()

            Dim ack As Integer =
            obj("payload")("payload")("ack")

            Dim ackName As String =
            obj("payload")("payload")("ackName").ToString


            Dim frm =
            TryCast(
                PnChatList.Controls(0),
                ChatListForm
            )

            If frm Is Nothing Then Return

            If frm.ChatItems Is Nothing Then Return

            For Each chat In frm.ChatItems

                Dim msg =
                chat.Conversation.
                Where(Function(x)
                          Return x.FromMe = True AndAlso
                                 x.Ack = 1
                      End Function).
                OrderByDescending(Function(x) x.Timestamp).
                FirstOrDefault()



                If msg IsNot Nothing Then

                    Dim oldId = msg.MsgId

                    msg.Ack = ack
                    msg.MsgId = msgId

                    UpdateBubbleAck(oldId, msgId, ack)

                End If

            Next


        Catch ex As Exception

            Console.WriteLine(ex.Message)

        End Try

        ' Console.WriteLine(json)

    End Sub

    Private Sub UpdateBubbleAck(
    oldMsgId As String,
    newMsgId As String,
    ack As Integer
)

        For Each ctrl As Control In pnlMessageList.Controls

            Dim bubble =
            TryCast(ctrl, MessageBubble)

            If bubble Is Nothing Then Continue For

            If bubble.MsgId = oldMsgId Then

                Dim stateStatus As Message.AckStatus

                If [Enum].IsDefined(
                GetType(Message.AckStatus),
                ack
            ) Then

                    stateStatus = CType(
                    ack,
                    Message.AckStatus
                )

                Else

                    stateStatus =
                    Message.AckStatus.Failed

                End If

                bubble.MsgId = newMsgId

                bubble.StatusText =
                GetStatusIcon(stateStatus)


                Exit For

            End If

        Next

    End Sub

    Private Sub OnMessageReceived(json As String)
        Dim frm = TryCast(PnChatList.Controls(0), ChatListForm)


        Try


            Dim newobj As New Object
            Dim obj = jsonpa.Json2aray(json)

            Dim remoteJidAlt As String = obj("payload")("payload")("_data")("key")("remoteJidAlt").ToString
            Dim _phone As String() = Split(remoteJidAlt, "@")
            Dim phone = _phone(0).ToString
            Dim text As String = obj("payload")("payload")("body").ToString
            Dim msgid As String = obj("payload")("payload")("id").ToString
            Dim hasMedia As Boolean = obj("payload")("payload")("hasMedia").ToString
            Dim fromMe As Boolean = obj("payload")("payload")("fromMe")
            Dim _sender As String() = Split(obj("payload")("me")("id").ToString, "@")
            Dim MediaUrl As String = ""
            Dim MediaType As String = Message.MediaTypes.Text

            Dim mediaObj = obj("payload")("media")

            If mediaObj IsNot Nothing AndAlso mediaObj.Type <> JTokenType.Null Then

                MediaUrl =
        mediaObj("url")?.ToString()
                newobj("media") = mediaObj
                MediaType =
        jsonpa.DetectMediaType(newobj.ToString())

            End If
            Dim unixTime As Long = CLng(obj("payload")("payload")("timestamp"))

            Dim Timestamp As DateTime = DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime

            Dim msg As New Message With {
            .MsgId = msgid,
            .ContentText = text,
            .Timestamp = Timestamp,
            .FromMe = fromMe,
            .MediaUrl = MediaUrl,
            .MediaType = MediaType,
            .Sender = _sender(0).ToString
        }

            If Not msg.FromMe Then

                My.Computer.Audio.Play(
        My.Resources.whatsapp_sound_effect,
        AudioPlayMode.Background
    )

            End If

            If frm IsNot Nothing Then

                frm.UpdateChatRealtime(phone, msg)

            End If
        Catch ex As Exception

            Console.WriteLine(ex.Message)

        End Try



    End Sub

    Public Sub AddMessageBubble(msg As Message)

        AddDateHeaderIfNeeded(Date.Now)
        Dim bubble As New MessageBubble()

        bubble.IsOutbox = msg.FromMe
        bubble.MessageText = msg.ContentText
        bubble.TimeText = msg.Timestamp.ToString("HH:mm")
        bubble.SenderText = msg.Sender
        bubble.StatusText = GetStatusIcon(msg.Status)
        bubble.Width = pnlMessageList.Width - 25

        pnlMessageList.Controls.Add(bubble)

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

        'If (apk_time > apk_tglexp) Then
        '    MsgBox(msg)

        '    Exit Sub
        'End If

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

        MenuChat.Items.Clear()

        MenuChat.Items.Add("WAScanQR")
        MenuChat.Items.Add("WAServer")


        TextSearch.Text = PlaceholderText
        TextSearch.ForeColor = Color.Gray
    End Sub

    Public Sub OpenConversation(chat As ChatItem)


        pnlMessageList.Controls.Clear()
        ' Setup panel untuk menampung pesan
        SetupMessagePanel()


        ' Contoh data pesan
        prosesOpenC(chat) ' Generate 100 pesan contoh
        Panel6.Visible = true
        PictureBox1.Visible = True
        Label1.Visible = True
        Label2.Visible = True


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

    Private Sub prosesOpenC(chat As ChatItem)

        CurrentChat = chat

        pnlMessageList.SuspendLayout()

        pnlMessageList.Controls.Clear()

        Label1.Tag = chat
        Label1.Text = chat.PhoneNumber
        Label2.Text = $"{chat.Platform}-{chat.PhoneSender}"

        Dim conv As List(Of Message) =
        chat.Conversation.
        OrderBy(Function(x) x.Timestamp).
        ToList()

        For Each item As Message In conv

            Dim isOutbox As Boolean =
            (item.Type = Message.MessageType.Outbox)

            Dim waktu As Date = item.Timestamp

            AddDateHeaderIfNeeded(waktu)

            Dim cleanText As String =
            item.ContentText?.ToString.Replace(vbLf, vbCrLf)

            Dim bubble As New MessageBubble()
            bubble.MsgId = item.MsgId
            bubble.TimeText = waktu.ToString("HH:mm")
            bubble.IsOutbox = isOutbox
            bubble.MessageText = cleanText


            If bubble.IsOutbox Then

                Dim ack As Integer = item.Ack
                Dim stateStatus As Message.AckStatus
                If [Enum].IsDefined(GetType(Message.AckStatus), ack) Then
                    stateStatus = CType(ack, Message.AckStatus)
                Else
                    stateStatus = Message.AckStatus.Failed
                End If

                bubble.StatusText = GetStatusIcon(stateStatus)

                bubble.SenderText =
                $"#{item.Sender}"

            Else

                bubble.SenderText =
                $"#{item.Sender}"

            End If

            ' content type
            Select Case item.MediaType

                Case Message.MediaTypes.Text

                    bubble.Content = MessageBubble.ContentType.Text
                    bubble.MessageText = item.ContentText

                Case Message.MediaTypes.Image

                    bubble.Content = MessageBubble.ContentType.Image
                    bubble.MediaUrl = item.MediaUrl

                Case Message.MediaTypes.Audio

                    bubble.Content = MessageBubble.ContentType.Voice

                Case Message.MediaTypes.Video

                    bubble.Content = MessageBubble.ContentType.Video

                Case Message.MediaTypes.Document

                    bubble.Content = MessageBubble.ContentType.File

            End Select

            bubble.Width = pnlMessageList.Width - 25

            pnlMessageList.Controls.Add(bubble)

        Next

        pnlMessageList.ResumeLayout()

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
        Dim chat As ChatItem = TryCast(Label1.Tag, ChatItem)

        If chat Is Nothing Then
            MessageBox.Show("Data chat tidak ditemukan")
            Return
        End If

        Dim redis = "wa:send:stream"
        Dim SenderNum As String = chat.PhoneSender
        Dim SessionId As String = chat.SessionId
        Dim fromNum As String = chat.PhoneNumber
        Dim platfrom As String = chat.Platform
        Dim textmsg As String = TextMessage.Text.Trim

        If (textmsg = "") Then
            MessageBox.Show("tidak ada message / kosong")
            Return
        End If


        AddDateHeaderIfNeeded(Date.Now)


        Dim newData As New JObject
        Dim jsArr As New JArray
        newData.Add("connection", "WhatsApp")
        newData.Add("device", "")
        newData.Add("to", fromNum)
        newData.Add("platform", platfrom)
        newData.Add("from", SessionId)
        newData.Add("text", textmsg)
        newData.Add("state", "")
        newData.Add("komu", "PU")
        newData.Add("tocall", 1)
        jsArr.Add(newData)

        Dim frm = TryCast(PnChatList.Controls(0), ChatListForm)
        If frm IsNot Nothing Then

            Dim msgnew As New Message
            msgnew.MsgId = ""
            msgnew.ContentText = textmsg
            msgnew.FromMe = True
            msgnew.Type = Message.MessageType.Outbox
            msgnew.Sender = SenderNum
            msgnew.Status = Message.AckStatus.Pending
            msgnew.Ack = 1
            msgnew.Timestamp = DateTime.Now

            frm.UpdateChatRealtime(fromNum, msgnew)

        End If

        TextMessage.Text = ""

        Dim payload As New JObject From {
          {"request_id", deEn.GenerateRandomString(16)},
          {"data", jsArr},
          {"type", redis},
          {"message", "send whatsapp via autocall"}
      }

        WSManager.Client.SendMessage(payload.ToString(Newtonsoft.Json.Formatting.None))
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
            PnChatList.Controls.Clear()
            PnMessage.Controls.Clear()
            Dim keyword As String = TextSearch.Text.Trim()

            Dim page As New ChatListForm
            page.ParentMsgForm = Me
            page.SendDataUser = DatR
            page.SearchFromDisplayed(keyword, "")

            page.TopLevel = False
            page.Dock = DockStyle.Fill

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

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        MenuChat.Show(BtnMenu, 0, BtnMenu.Height)
    End Sub

    Private Sub MenuChat_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuChat.ItemClicked
        Dim page As New ChatListForm
        PnChatList.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        page.SendDataUser = DatR
        page.ParentMsgForm = Me

        Select Case e.ClickedItem.Text

            Case "WAScanQR"

                page.SearchFromDisplayed("", "wascanqr")
                PnChatList.Controls.Add(page)
                page.Show()

            Case "WAServer"
                page.SearchFromDisplayed("", "waserver")
                PnChatList.Controls.Add(page)
                page.Show()



        End Select

    End Sub

    Private Function GetStatusIcon(status As MessageStatus) As String
        Select Case status
            Case MessageStatus.Pending : Return "🕓"
            Case MessageStatus.Sent : Return "✓"
            Case MessageStatus.Delivered : Return "✓✓"
            Case MessageStatus.Read : Return "✓✓●"
            Case MessageStatus.Failed : Return "!"
            Case Else : Return ""
        End Select
    End Function
End Class