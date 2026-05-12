Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.VisualBasic.Devices
Imports Newtonsoft.Json.Linq

Public Class ChatListForm
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private WApp As New WhatsAppClass
    Private currentPage As Integer = 1
    Private pageSize As Integer = 20
    Private isLoading As Boolean = False
    Private selectedChatItem As ChatItem = Nothing

    Private DatR As String = String.Empty
    ' Warna untuk UI
    Private ReadOnly ColorBackground As Color = Color.FromArgb(60, 60, 60)
    Private ReadOnly ColorItemNormal As Color = Color.FromArgb(40, 40, 50)
    Private ReadOnly ColorItemUnread As Color = Color.FromArgb(50, 50, 60)
    Private ReadOnly ColorItemSelected As Color = Color.FromArgb(70, 70, 90)
    Private WithEvents pnlLayoutList As New FlowLayoutPanel()
    Public Property PendingSearchKeyword As String = ""
    Private displayedChatItems As List(Of ChatItem)
    Public Property ParentMsgForm As pgMsg
    Public ChatPanels As New Dictionary(Of String, Panel)
    Private CurrentChat As ChatItem = Nothing

    Public ReadOnly Property ChatItems As List(Of ChatItem)
        Get
            Return displayedChatItems
        End Get
    End Property
    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    ' Kontrol UI
    Private WithEvents pnlChatList As New Panel With {
        .Dock = DockStyle.Fill,
        .AutoScroll = True,
        .BackColor = ColorBackground,
        .Padding = New Padding(5)
    }

    Private WithEvents lblLoading As New Label With {
        .Text = "Memuat data...",
        .ForeColor = Color.White,
        .Font = New Font("Segoe UI", 10),
        .TextAlign = ContentAlignment.MiddleCenter,
        .Dock = DockStyle.Bottom,
        .Height = 40,
        .Visible = False
    }

    Public Sub New()
        Me.Text = "Daftar Chat"
        Me.Size = New Size(300, 497)
        Me.BackColor = ColorBackground
        Me.FormBorderStyle = FormBorderStyle.None



    End Sub

    Private Sub SetupMessagePanel()
        pnlLayoutList.Dock = DockStyle.Fill
        pnlLayoutList.AutoScroll = True
        pnlLayoutList.FlowDirection = FlowDirection.TopDown
        pnlLayoutList.WrapContents = False
        pnlLayoutList.AutoSize = False
        pnlLayoutList.AutoScrollMinSize = New Size(0, 0)
        pnlLayoutList.HorizontalScroll.Enabled = False
        pnlLayoutList.HorizontalScroll.Visible = False
        pnlLayoutList.VerticalScroll.Enabled = True
        pnlLayoutList.VerticalScroll.Visible = True
        pnlLayoutList.Width = 290 ' Lebar sesuai permintaan
        pnlChatList.Controls.Add(pnlLayoutList)
    End Sub
    Private Sub InitializeUI()

        Me.Controls.Add(pnlChatList)
        Me.Controls.Add(lblLoading)
    End Sub

    Private Sub LoadPage(page As Integer, platform As String)

        If isLoading Then Return

        isLoading = True
        lblLoading.Visible = True

        Task.Run(Sub()

                     Threading.Thread.Sleep(800)

                     Dim newItems = GeneratePageData(page, platform, "")

                     Me.Invoke(Sub()

                                   ' =========================
                                   ' SIMPAN KE MEMORY
                                   ' =========================

                                   If displayedChatItems Is Nothing Then
                                       displayedChatItems = New List(Of ChatItem)
                                   End If

                                   displayedChatItems.AddRange(newItems)

                                   ' =========================
                                   ' RENDER UI
                                   ' =========================

                                   RenderChatItems(displayedChatItems)

                                   currentPage = page

                                   isLoading = False

                                   lblLoading.Visible = False

                               End Sub)

                 End Sub)

    End Sub

    Public Sub SearchFromDisplayed(keyword As String, platform As String)
        ' Jika keyword kosong, reset dan reload
        SetupMessagePanel()
        InitializeUI()
        If Not String.IsNullOrWhiteSpace(keyword) Then
            If isLoading Then Return

            isLoading = True
            lblLoading.Visible = True

            Task.Run(Sub()

                         Threading.Thread.Sleep(800)

                         Dim newItems = GeneratePageData(1, platform, keyword)

                         Me.Invoke(Sub()

                                       RenderChatItems(newItems)


                                       isLoading = False
                                       lblLoading.Visible = False

                                   End Sub)

                     End Sub)


        Else

            LoadPage(1, platform)
        End If

    End Sub

    Private Function GeneratePageData(page As Integer, ByVal platform As String, keyword As String) As List(Of ChatItem)

        Dim items As New List(Of ChatItem)()

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("paging", page)
        param.Add("platform", platform)
        param.Add("tipe", "chatlist")
        param.Add("keyword", keyword)
        Dim ListWA As String = WApp.OnListMsg(param)
        ' Console.WriteLine(ListWA)
        Dim DatChat As JArray = jsonpa.Json2aray(ListWA)

        'If (DatChat.Count = 0) Then
        '    Exit Function
        'End If

        If (DatChat.Count > 0) Then
            ' Contoh data dummy (ganti dengan data sebenarnya)
            For i As Integer = 0 To DatChat.Count - 1
                Dim from As String = DatChat(i)("from").ToString
                Dim Sender As String = DatChat(i)("Sender")
                Dim isgroup As Boolean = DatChat(i)("isgroup")
                Dim waktu As DateTime = DatChat(i)("timestamp")
                Dim isread As Boolean = DatChat(i)("isread")
                Dim pushName = DatChat(i)("pushName").ToString
                Dim tujuan As String = IIf((isgroup), pushName, from)
                Dim usernm As String = DatChat(i)("username")
                Dim wadah As String = DatChat(i)("platform")

                Dim sessionId As String = DatChat(i)("session")
                Dim last_text As String = DatChat(i)("last_text")
                Dim detailmsg As List(Of Message) =
    DatChat(i)("conversation").ToObject(Of List(Of Message))()

                Dim ack As Integer = DatChat(i)?("ack")
                Dim stateStatus As Message.AckStatus
                If [Enum].IsDefined(GetType(Message.AckStatus), ack) Then
                    stateStatus = CType(ack, Message.AckStatus)
                Else
                    stateStatus = Message.AckStatus.Failed
                End If

                items.Add(New ChatItem With {
                    .Id = i,
                    .PhoneNumber = tujuan,
                    .LastMessage = last_text,
                    .Time = waktu,
                    .UnreadCount = isread,
                    .Status = stateStatus,
                    .Username = usernm,
                    .Platform = wadah,
                    .SessionId = sessionId,
                    .PhoneSender = Sender,
                    .Conversation = detailmsg
                })

            Next

        End If

        Return items

    End Function

    Private Function GetAckIcon(ack As Integer) As String

        Select Case ack
            Case 1
                Return "🕓"

            Case 1
                Return "✓"

            Case 2
                Return "✓✓"

            Case 3
                Return "✓✓"

            Case Else
                Return "❌"

        End Select

    End Function

    Private Sub RenderChatItems(items As List(Of ChatItem))
        pnlLayoutList.SuspendLayout()

        ' Hitung posisi Y mulai (di bawah item terakhir)
        Dim yPos As Integer = 0
        If pnlLayoutList.Controls.Count > 0 Then
            Dim lastControl = pnlLayoutList.Controls(pnlLayoutList.Controls.Count - 1)
            yPos = lastControl.Bottom + 5
        End If

        For Each chat In items

            Dim chatPanel = CreateChatItemPanel(chat, yPos)

            pnlLayoutList.Controls.Add(chatPanel)
            yPos += chatPanel.Height + 5

            If Not ChatPanels.ContainsKey(chat.PhoneNumber) Then
                ChatPanels.Add(chat.PhoneNumber, chatPanel)
            End If


        Next

        pnlLayoutList.ResumeLayout()
    End Sub

    Public Sub UpdateChatRealtime(phone As String, msg As Message)

        If InvokeRequired Then
            Invoke(Sub() UpdateChatRealtime(phone, msg))
            Return
        End If

        Dim chat =
        displayedChatItems.
        FirstOrDefault(Function(c) c.PhoneNumber = phone)

        ' ==================================
        ' CHAT BELUM ADA
        ' ==================================

        Dim isNewChat As Boolean = False

        If chat Is Nothing Then

            isNewChat = True

            chat = New ChatItem With {
        .PhoneNumber = phone,
        .Conversation = New List(Of Message)
    }

            displayedChatItems.Insert(0, chat)

        End If

        chat.LastMessage = msg.ContentText
        chat.PhoneSender = msg.Sender
        chat.Time = msg.Timestamp.ToString()

        If Not msg.FromMe Then
            chat.UnreadCount += 1
        End If

        chat.Conversation.Add(msg)

        If isNewChat Then

            AddChatItem(chat)

        Else

            UpdateChatItem(chat)

        End If


        ' ==================================
        ' SORT TERBARU KE ATAS
        ' ==================================

        displayedChatItems =
        displayedChatItems.
        OrderByDescending(
            Function(x)
                Return x.Conversation.LastOrDefault()?.Timestamp
            End Function
        ).ToList()

        ' ==================================
        ' JIKA CHAT SEDANG DIBUKA
        ' ==================================

        If selectedChatItem IsNot Nothing Then

            If selectedChatItem.PhoneNumber = phone Then

                ParentMsgForm?.AddMessageBubble(msg)

            End If

        End If

    End Sub

    Private Sub UpdateChatItem(chat As ChatItem)

        For Each ctrl As Control In pnlLayoutList.Controls

            Dim data =
            TryCast(ctrl.Tag, ChatItem)

            If data Is Nothing Then Continue For

            If data.PhoneNumber = chat.PhoneNumber Then

                ' =========================
                ' UPDATE DATA
                ' =========================

                data.LastMessage = chat.LastMessage
                data.Time = chat.Time
                data.UnreadCount = chat.UnreadCount

                ' =========================
                ' UPDATE UI
                ' =========================

                Dim lblMessage =
                TryCast(
                    ctrl.Controls("lblMessage"),
                    Label
                )

                If lblMessage IsNot Nothing Then
                    lblMessage.Text = chat.LastMessage
                End If

                Dim lblTime =
                TryCast(
                    ctrl.Controls("lblTime"),
                    Label
                )

                If lblTime IsNot Nothing Then
                    lblTime.Text = FormatTime(chat.Time)
                End If

                Dim lblStatus =
                TryCast(
                    ctrl.Controls("lblStatus"),
                    Label
                )

                If lblStatus IsNot Nothing Then
                    lblStatus.Text = GetStatusIcon(chat.Status)
                    lblStatus.ForeColor = GetStatusColor(chat.Status)
                End If

                ' =========================
                ' UPDATE UNREAD
                ' =========================

                Dim lblUnread =
                TryCast(
                    ctrl.Controls("lblUnread"),
                    Label
                )

                If chat.UnreadCount > 0 Then

                    If lblUnread Is Nothing Then

                        lblUnread = New Label With {
                        .Name = "lblUnread",
                        .Font = New Font("Segoe UI", 7, FontStyle.Bold),
                        .ForeColor = Color.White,
                        .BackColor = Color.Red,
                        .TextAlign = ContentAlignment.MiddleCenter,
                        .Size = New Size(15, 15),
                        .Location = New Point(ctrl.Width - 60, ctrl.Height \ 2 - 7)
                    }

                        Dim path As New Drawing2D.GraphicsPath()
                        path.AddEllipse(New Rectangle(0, 0, 15, 15))
                        lblUnread.Region = New Region(path)

                        ctrl.Controls.Add(lblUnread)

                    End If

                    lblUnread.Text = chat.UnreadCount.ToString()

                Else

                    If lblUnread IsNot Nothing Then
                        ctrl.Controls.Remove(lblUnread)
                    End If

                End If

                ' =========================
                ' MOVE TO TOP
                ' =========================

                pnlLayoutList.Controls.SetChildIndex(ctrl, 0)

                Exit For

            End If

        Next

    End Sub

    Public Sub AddChatItem(chat As ChatItem)

        Dim yPos As Integer = 0

        If pnlLayoutList.Controls.Count > 0 Then

            Dim lastControl =
            pnlLayoutList.Controls(
                pnlLayoutList.Controls.Count - 1
            )

            yPos = lastControl.Bottom + 5

        End If

        Dim pnl =
        CreateChatItemPanel(chat, yPos)

        pnlLayoutList.Controls.Add(pnl)

        ChatPanels(chat.PhoneNumber) = pnl

    End Sub

    Private Function CreateChatItemPanel(chat As ChatItem, yPos As Integer) As Panel
        Dim chatPanel As New Panel With {
            .Width = pnlLayoutList.Width - 30,
            .Height = 80,
            .Location = New Point(10, yPos),
            .BackColor = If(chat.IsSelected, ColorItemSelected,
                         If(chat.UnreadCount > 0, ColorItemUnread, ColorItemNormal)),
            .Tag = chat,
            .Cursor = Cursors.Hand
        }

        ' Rounded corners
        chatPanel.Region = CreateRoundedRegion(chatPanel.Width, chatPanel.Height, 10)

        ' Nomor HP (Putih, ukuran 12)
        Dim lblNumber As New Label With {
            .Text = chat.PhoneNumber,
            .Font = New Font("Segoe UI", 10, FontStyle.Bold),
            .ForeColor = Color.White,
            .Location = New Point(15, 15),
            .AutoSize = True
        }

        ' Last Message (Putih, ukuran 10)
        Dim lblMessage As New Label With {
            .Name = "lblMessage",
            .Text = chat.LastMessage,
            .Font = New Font("Segoe UI", 8),
            .ForeColor = Color.WhiteSmoke,
            .Location = New Point(15, 40),
            .AutoSize = True,
            .MaximumSize = New Size(chatPanel.Width - 100, 0)
        }

        ' Waktu (Putih, ukuran 10)
        Dim lblTime As New Label With {
            .Name = "lblTime",
            .Text = FormatTime(chat.Time),
            .Font = New Font("Segoe UI", 7),
            .ForeColor = Color.LightGray,
            .Location = New Point(chatPanel.Width - 80, chatPanel.Height - 25),
            .AutoSize = True
        }

        ' Status pesan (kanan atas)
        Dim lblStatus As New Label With {
            .Name = "lblStatus",
            .Text = GetStatusIcon(chat.Status),
            .Font = New Font("Segoe UI", 7),
            .ForeColor = GetStatusColor(chat.Status),
            .Location = New Point(chatPanel.Width - 60, 15),
            .AutoSize = True
        }

        ' Unread count (bulat, kanan tengah)
        If chat.UnreadCount > 0 Then
            Dim unreadSize As Integer = 15
            Dim lblUnread As New Label With {
                .Name = "lblUnread",
                .Text = chat.UnreadCount.ToString(),
                .Font = New Font("Segoe UI", 7, FontStyle.Bold),
                .ForeColor = Color.White,
                .BackColor = Color.Red,
                .TextAlign = ContentAlignment.MiddleCenter,
                .Size = New Size(unreadSize, unreadSize),
                .Location = New Point(chatPanel.Width - 60, chatPanel.Height \ 2 - unreadSize \ 2)
            }

            ' Buat bentuk lingkaran
            Dim path As New Drawing2D.GraphicsPath()
            path.AddEllipse(New Rectangle(0, 0, unreadSize, unreadSize))
            lblUnread.Region = New Region(path)
            chatPanel.Controls.Add(lblUnread)
        End If

        ' Tambahkan semua kontrol
        chatPanel.Controls.Add(lblNumber)
        chatPanel.Controls.Add(lblMessage)
        chatPanel.Controls.Add(lblTime)
        chatPanel.Controls.Add(lblStatus)

        ' Event klik untuk memilih item
        AddHandler chatPanel.Click, Sub(sender, e)
                                        SelectChatItem(chat)
                                    End Sub

        Return chatPanel
    End Function

    Private Sub SelectChatItem(chat As ChatItem)

        If selectedChatItem IsNot Nothing Then
            selectedChatItem.IsSelected = False
            UpdateChatItemAppearance(selectedChatItem)
        End If

        chat.IsSelected = True
        selectedChatItem = chat
        UpdateChatItemAppearance(chat)

        ' langsung panggil parent

        ParentMsgForm?.OpenConversation(chat)
    End Sub

    Private Sub UpdateChatItemAppearance(chat As ChatItem)
        ' Cari panel yang sesuai dengan chat item
        For Each ctrl As Control In pnlLayoutList.Controls
            If TypeOf ctrl Is Panel AndAlso ctrl.Tag Is chat Then
                Dim panel = DirectCast(ctrl, Panel)
                panel.BackColor = If(chat.IsSelected, ColorItemSelected,
                                  If(chat.UnreadCount > 0, ColorItemUnread, ColorItemNormal))
                Exit For
            End If
        Next
    End Sub

    ' Format waktu dengan perbedaan hari
    Private Function FormatTime(time As DateTime) As String
        Dim today = DateTime.Today

        If time.Date = today Then
            Return time.ToString("HH:mm") ' Jam:menit untuk hari ini
        ElseIf time.Date = today.AddDays(-1) Then
            Return "Kemarin"
        ElseIf time.Date > today.AddDays(-7) Then
            Return time.ToString("dddd") ' Nama hari
        Else
            Return time.ToString("dd/MM") ' Tanggal/bulan
        End If
    End Function

    ' Fungsi bantu untuk membuat rounded corners
    Private Function CreateRoundedRegion(width As Integer, height As Integer, radius As Integer) As Region
        Dim path As New GraphicsPath()
        path.StartFigure()
        path.AddArc(0, 0, radius, radius, 180, 90) ' Top-left
        path.AddLine(radius, 0, width - radius, 0)
        path.AddArc(width - radius, 0, radius, radius, 270, 90) ' Top-right
        path.AddLine(width, radius, width, height - radius)
        path.AddArc(width - radius, height - radius, radius, radius, 0, 90) ' Bottom-right
        path.AddLine(width - radius, height, radius, height)
        path.AddArc(0, height - radius, radius, radius, 90, 90) ' Bottom-left
        path.CloseFigure()
        Return New Region(path)
    End Function

    ' Fungsi untuk status pesan
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

    Private Function GetStatusColor(status As MessageStatus) As Color
        Select Case status
            Case MessageStatus.Read : Return Color.Cyan
            Case Else : Return Color.LightGray
        End Select
    End Function

    ' Event untuk load halaman berikutnya saat scroll
    Private Sub pnlLayoutList_Scroll(sender As Object, e As ScrollEventArgs) Handles pnlLayoutList.Scroll
        ' Cek apakah user sudah scroll sampai ke bawah
        If pnlLayoutList.VerticalScroll.Value + pnlLayoutList.Height >= pnlLayoutList.VerticalScroll.Maximum - 50 Then
            If Not isLoading Then
                LoadPage(currentPage + 1, "")
            End If
        End If
    End Sub



End Class