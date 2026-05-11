Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.Http
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
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
    Public ChatCache As New Dictionary(Of String, ChatItem)
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
        ' Console.WriteLine(message)
        If (message Is Nothing) Then Exit Sub

        Dim arrj = jsonpa.Json2aray(message)

        If (arrj("event") IsNot Nothing) Then
            Dim usern = arrj("metadata")("username").ToString
            Dim session = arrj("session").ToString
            Dim DPar = jsonpa.Json2aray(DatR)
            Dim username = DPar("body")("apk_user").ToString

            If username = usern And arrj("event").ToString = "message" Then
                OnMessageReceived(message)
            ElseIf (arrj("event").ToString = "messageack") Then
                ' OnMessageReceived(message)
            End If
        End If

    End Sub

    Private Sub OnMessageReceived(json As String)

        Try
            Dim newobj As New Object
            Dim obj = JObject.Parse(json)

            Dim phone As String = obj("payload")("from").ToString
            Dim text As String = obj("payload")("body").ToString
            Dim msgid As String = obj("payload")("id").ToString
            Dim hasMedia As Boolean = obj("payload")("hasMedia").ToString
            Dim Timestamp As DateTime = obj("payload")("timestamp")
            Dim fromMe As Boolean = obj("payload")("fromMe")
            Dim MediaUrl As String = obj("media")("url").ToString
            newobj.add(obj("media"))
            Dim MediaType As String = jsonpa.DetectMediaType(newobj.ToString)


            Dim msg As New Message With {
            .MsgId = msgid,
            .ContentText = text,
            .Timestamp = Timestamp,
            .FromMe = fromMe,
            .MediaUrl = MediaUrl,
            .MediaType = MediaType
        }

            UpdateChatRealtime(phone, msg)

        Catch ex As Exception

            Console.WriteLine(ex.Message)

        End Try

    End Sub

    Private Sub UpdateChatRealtime(
    phone As String,
    msg As Message
)

        If InvokeRequired Then

            Invoke(Sub()
                       UpdateChatRealtime(phone, msg)
                   End Sub)

            Return

        End If

        If ChatCache.ContainsKey(phone) Then

            Dim chat = ChatCache(phone)

            ' update data
            chat.LastMessage = msg.ContentText

            chat.Time = msg.Timestamp

            chat.Conversation.Add(msg)

            ' unread
            If Not chat.IsSelected Then
                chat.UnreadCount += 1
            End If

            ' update list ui
            ChatListForm.UpdateChatUI(chat)

            ' update bubble jika aktif
            If CurrentChat Is chat Then

                AddBubbleMessage(msg)

            End If

        Else

            ' chat baru
            Dim newChat As New ChatItem With {
            .PhoneNumber = phone,
            .LastMessage = msg.ContentText,
            .Time = msg.Timestamp
        }

            newChat.Conversation.Add(msg)

            ChatCache.Add(phone, newChat)

            ChatListForm.AddChatItem(newChat)

        End If

    End Sub

    Private Sub AddBubbleMessage(msg As Message)

        If InvokeRequired Then

            Invoke(Sub()
                       AddBubbleMessage(msg)
                   End Sub)

            Return

        End If

        Try

            Dim bubble As New MessageBubble()

            ' ==================================
            ' BASIC
            ' ==================================

            bubble.TimeText =
            msg.Timestamp.ToString("HH:mm")

            bubble.IsOutbox =
            msg.FromMe

            bubble.MessageText =
            msg.ContentText

            bubble.SenderText =
            msg.Sender

            ' ==================================
            ' MEDIA
            ' ==================================

            bubble.MediaUrl = msg.MediaUrl

            Select Case msg.MediaType

                Case "Image"
                    bubble.BubbleContentType =
                    MessageBubble.ContentType.Image

                Case "Audio"
                    bubble.BubbleContentType =
                    MessageBubble.ContentType.Voice

                Case "Video"
                    bubble.BubbleContentType =
                    MessageBubble.ContentType.Video

                Case "Document"
                    bubble.BubbleContentType =
                    MessageBubble.ContentType.File

                Case Else
                    bubble.BubbleContentType =
                    MessageBubble.ContentType.Text

            End Select

            ' ==================================
            ' STATUS
            ' ==================================

            If msg.FromMe Then

                Select Case msg.Status

                    Case Message.AckStatus.Pending
                        bubble.StatusText = "⌛"

                    Case Message.AckStatus.Server
                        bubble.StatusText = "✓"

                    Case Message.AckStatus.Delivered
                        bubble.StatusText = "✓✓"

                    Case Message.AckStatus.Read
                        bubble.StatusText = "✓✓ Dibaca"

                    Case Message.AckStatus.Played
                        bubble.StatusText = "▶ Diputar"

                    Case Else
                        bubble.StatusText = "!!"

                End Select

            End If

            ' ==================================
            ' WIDTH
            ' ==================================

            bubble.Width =
            pnlMessageList.Width - 25

            ' ==================================
            ' ADD TO PANEL
            ' ==================================

            pnlMessageList.Controls.Add(bubble)

            bubble.BringToFront()

            ' ==================================
            ' AUTO SCROLL
            ' ==================================

            ScrollToBottom()

        Catch ex As Exception

            Console.WriteLine(ex.Message)

        End Try

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

        Dim conv As List(Of Message) = chat.Conversation

        For Each item As Message In conv

            Dim isOutbox As Boolean =
            (item.Type = Message.MessageType.Outbox)

            Dim waktu As Date = item.Timestamp

            AddDateHeaderIfNeeded(waktu)

            Dim cleanText As String =
            item.ContentText.Replace(vbLf, vbCrLf)

            Dim bubble As New MessageBubble()

            bubble.TimeText = waktu.ToString("HH:mm")
            bubble.IsOutbox = isOutbox
            bubble.MessageText = cleanText

            If bubble.IsOutbox Then

                bubble.StatusText =
                item.AckName.ToString()

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
        Dim bubble As New MessageBubble()

        bubble.IsOutbox = True
        bubble.MessageText = textmsg
        bubble.TimeText = DateTime.Now.ToString("T")
        bubble.SenderText = SenderNum
        bubble.Width = pnlMessageList.Width - 25

        pnlMessageList.Controls.Add(bubble)

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


End Class