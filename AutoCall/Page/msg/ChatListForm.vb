Imports System.Drawing.Drawing2D
Imports Newtonsoft.Json.Linq

Public Class ChatListForm
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private WApp As New WhatsAppClass
    Private displayedChatItems As New List(Of ChatItem)()
    Private currentPage As Integer = 1
    Private pageSize As Integer = 20
    Private isLoading As Boolean = False
    Private selectedChatItem As ChatItem = Nothing
    Public Event SendDataJson As EventHandler(Of ClassData)
    Private DatR As String = String.Empty
    ' Warna untuk UI
    Private ReadOnly ColorBackground As Color = Color.FromArgb(60, 60, 60)
    Private ReadOnly ColorItemNormal As Color = Color.FromArgb(40, 40, 50)
    Private ReadOnly ColorItemUnread As Color = Color.FromArgb(50, 50, 60)
    Private ReadOnly ColorItemSelected As Color = Color.FromArgb(70, 70, 90)
    Private WithEvents pnlLayoutList As New FlowLayoutPanel()

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

    Private Sub LoadPage(page As Integer)
        If isLoading Then Return

        isLoading = True
        lblLoading.Visible = True

        ' Simulasi load data async
        Task.Run(Sub()
                     ' Simulasi delay jaringan/database
                     Threading.Thread.Sleep(800)

                     ' Generate data untuk halaman ini
                     Dim newItems = GeneratePageData(page, "", "")

                     Me.Invoke(Sub()
                                   ' Tambahkan ke daftar yang ditampilkan
                                   displayedChatItems.AddRange(newItems)

                                   ' Render item baru
                                   RenderChatItems(newItems)

                                   currentPage = page
                                   isLoading = False
                                   lblLoading.Visible = False

                               End Sub)
                 End Sub)
    End Sub

    Public Sub SearchFromDisplayed(keyword As String)
        If Not String.IsNullOrWhiteSpace(keyword) Then
            If isLoading Then Return

            isLoading = True
            lblLoading.Visible = True

            ' Jika keyword ada, lakukan filter
            Dim filteredItems = displayedChatItems.
                Where(Function(c) c.PhoneNumber.Contains(keyword)).
                ToList()

            ' Render hasil filter
            RenderChatItems(filteredItems)

            isLoading = False
            lblLoading.Visible = False
        Else
            ' Jika keyword kosong, reset dan reload
            SetupMessagePanel()
            InitializeUI()
            LoadPage(1)
        End If

    End Sub

    Private Function GeneratePageData(page As Integer, ByVal platform As String, nosender As String) As List(Of ChatItem)

        Dim items As New List(Of ChatItem)()

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("paging", page)
        param.Add("platform", platform)
        param.Add("tipe", "chatlist")
        param.Add("nosender", nosender)
        Dim ListWA As String = WApp.OnListMsg(param)
        ' Console.WriteLine(ListWA)
        Dim DatChat As JArray = jsonpa.Json2aray(ListWA)


        ' Contoh data dummy (ganti dengan data sebenarnya)
        For i As Integer = 0 To DatChat.Count - 1
            Dim tujuan As String = String.Empty
            Dim isgroup As String = DatChat(i)("aichat_isgroup")
            Dim waktu As DateTime = DatChat(i)("aichat_daterec")
            Dim isread As Integer = DatChat(i)("aichat_isread")

            If (isgroup = "true") Then
                tujuan = DatChat(i)("aichat_group")
            Else
                tujuan = DatChat(i)("aichat_to")
            End If

            Dim usernm As String = DatChat(i)("aichat_username")
            Dim wadah As String = DatChat(i)("aichat_platform")
            Dim tsender As String = DatChat(i)("aichat_from")
            Dim stateS As String = DatChat(i)("aichat_state")
            Dim sessionId As String = DatChat(i)("aichat_waname")


            Dim stateStatus As Message.DeliveryStatus

            If (stateS = "true") Then
                stateStatus = MessageStatus.Delivered
            ElseIf (stateS = "false") Then
                stateStatus = MessageStatus.Failed
            End If


            items.Add(New ChatItem With {
                .Id = i,
                .PhoneNumber = tujuan,
                .LastMessage = DatChat(i)("aichat_text"),
                .Time = waktu,
                .UnreadCount = isread,
                .Status = stateStatus,
                .Username = usernm,
                .Platform = wadah,
                .SessionId = sessionId,
                .PhoneSender = tsender
            })

        Next


        Return items
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
            ' Buat panel untuk item chat
            Dim chatPanel = CreateChatItemPanel(chat, yPos)
            pnlLayoutList.Controls.Add(chatPanel)
            yPos += chatPanel.Height + 5
        Next

        pnlLayoutList.ResumeLayout()
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
            .Text = chat.LastMessage,
            .Font = New Font("Segoe UI", 8),
            .ForeColor = Color.WhiteSmoke,
            .Location = New Point(15, 40),
            .AutoSize = True,
            .MaximumSize = New Size(chatPanel.Width - 100, 0)
        }

        ' Waktu (Putih, ukuran 10)
        Dim lblTime As New Label With {
            .Text = FormatTime(chat.Time),
            .Font = New Font("Segoe UI", 7),
            .ForeColor = Color.LightGray,
            .Location = New Point(chatPanel.Width - 80, chatPanel.Height - 25),
            .AutoSize = True
        }

        ' Status pesan (kanan atas)
        Dim lblStatus As New Label With {
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
        ' Hapus seleksi sebelumnya
        If selectedChatItem IsNot Nothing Then
            selectedChatItem.IsSelected = False
            UpdateChatItemAppearance(selectedChatItem)
        End If

        ' Set seleksi baru
        chat.IsSelected = True
        selectedChatItem = chat
        UpdateChatItemAppearance(chat)

        Dim DataJson As New JObject
        DataJson.Add("PhoneSender", chat.PhoneSender)
        DataJson.Add("SessionId", chat.SessionId)
        DataJson.Add("platform", chat.Platform)
        DataJson.Add("username", chat.Username)
        DataJson.Add("PhoneNumber", chat.PhoneNumber)
        DataJson.Add("Service", chat.Service)


        RaiseEvent SendDataJson(Me, New ClassData(DataJson.ToString))
        ' Buka message list

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
                LoadPage(currentPage + 1)
            End If
        End If
    End Sub

    ' Class untuk menyimpan data chat
    Public Class ChatItem
        Public Property Id As Integer
        Public Property PhoneNumber As String
        Public Property PhoneSender As String
        Public Property SessionId As String
        Public Property Service As String
        Public Property Username As String
        Public Property Platform As String
        Public Property Numto As String
        Public Property LastMessage As String
        Public Property Time As DateTime
        Public Property UnreadCount As Integer
        Public Property Status As MessageStatus
        Public Property IsSelected As Boolean = False
    End Class

    Public Enum MessageStatus
        Sent
        Delivered
        Read
        Failed
    End Enum
End Class