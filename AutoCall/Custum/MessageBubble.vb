Imports System.IO
Imports System.Media

Public Class MessageBubble
    Inherits UserControl

    Public Enum ContentType
        Text
        Image
        Voice
        Video
    End Enum

    Private _contentType As ContentType = ContentType.Text
    Private _isOutbox As Boolean = False
    Private _messageText As String = ""
    Private _timeText As String = ""
    Private _statusText As String = ""
    Private _senderText As String = ""
    Private _mediaPath As String = ""
    Private _duration As Integer = 0 ' Untuk voice/video (dalam detik)

    ' UI Components
    Private pnlBubble As Panel
    Private txtMessage As TextBox
    Private picMedia As PictureBox
    Private WithEvents btnPlay As Button
    Private progressTimer As Timer
    Private progressBar As ProgressBar
    Private lblDuration As Label
    Private lblTime As Label
    Private lblStatus As Label
    Private lblSender As Label
    Private WithEvents btnPlayVideo As Button

    ' Constants
    Private Const PADDING_HORIZONTAL As Integer = 15
    Private Const PADDING_VERTICAL As Integer = 10
    Private Const TIME_STATUS_HEIGHT As Integer = 15
    Private Const BUBBLE_MARGIN As Integer = 5
    Private Const MAX_BUBBLE_WIDTH As Integer = 500
    Private Const MEDIA_WIDTH As Integer = 300
    Private Const MEDIA_HEIGHT As Integer = 200

    ' Properties
    Public Property IsOutbox() As Boolean
        Get
            Return _isOutbox
        End Get
        Set(value As Boolean)
            _isOutbox = value
            UpdateLayout()
        End Set
    End Property

    Public Property MessageText() As String
        Get
            Return _messageText
        End Get
        Set(value As String)
            _messageText = value
            UpdateLayout()
        End Set
    End Property

    Public Property TimeText() As String
        Get
            Return _timeText
        End Get
        Set(value As String)
            _timeText = value
            If lblTime IsNot Nothing Then lblTime.Text = value
        End Set
    End Property

    Public Property StatusText() As String
        Get
            Return _statusText
        End Get
        Set(value As String)
            _statusText = value
            If lblStatus IsNot Nothing Then lblStatus.Text = value
        End Set
    End Property

    Public Property SenderText() As String
        Get
            Return _senderText
        End Get
        Set(value As String)
            _senderText = value
            If lblSender IsNot Nothing Then lblSender.Text = value
        End Set
    End Property

    Public Property Content() As ContentType
        Get
            Return _contentType
        End Get
        Set(value As ContentType)
            _contentType = value
            UpdateLayout()
        End Set
    End Property

    Public Property MediaPath() As String
        Get
            Return _mediaPath
        End Get
        Set(value As String)
            _mediaPath = value
            LoadMedia()
        End Set
    End Property

    Public Property Duration() As Integer
        Get
            Return _duration
        End Get
        Set(value As Integer)
            _duration = value
            UpdateDurationDisplay()
        End Set
    End Property

    Public Sub New()
        DoubleBuffered = True
        InitializeBubbleComponents()
        UpdateLayout()
    End Sub

    Private Sub InitializeBubbleComponents()
        ' Setup UserControl
        Size = New Size(400, 150)
        BackColor = Color.Transparent
        Margin = New Padding(0, 5, 0, 5)

        ' Bubble Panel
        pnlBubble = New Panel()
        pnlBubble.BackColor = Color.LightGray
        pnlBubble.Padding = New Padding(5)
        pnlBubble.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        Controls.Add(pnlBubble)

        ' Text Message (Selectable, looks like label)
        txtMessage = New TextBox()
        txtMessage.Multiline = True
        txtMessage.ReadOnly = True
        txtMessage.BorderStyle = BorderStyle.None
        txtMessage.Font = New Font("Segoe UI", 9.5F)
        txtMessage.Margin = New Padding(5)
        txtMessage.AutoSize = False
        txtMessage.Dock = DockStyle.None
        txtMessage.Cursor = Cursors.IBeam
        txtMessage.WordWrap = True
        txtMessage.ShortcutsEnabled = True
        txtMessage.BackColor = pnlBubble.BackColor
        txtMessage.ForeColor = Color.Black
        txtMessage.TabStop = False
        pnlBubble.Controls.Add(txtMessage)

        ' Media Display (Image/Video)
        picMedia = New PictureBox()
        picMedia.SizeMode = PictureBoxSizeMode.Zoom
        picMedia.BackColor = Color.Transparent
        picMedia.Visible = False
        pnlBubble.Controls.Add(picMedia)

        ' Play Button (for voice/video)
        btnPlay = New Button()
        btnPlay.Text = "▶"
        btnPlay.FlatStyle = FlatStyle.Flat
        btnPlay.BackColor = Color.White
        btnPlay.Visible = False
        btnPlay.Size = New Size(30, 30)
        AddHandler btnPlay.Click, AddressOf PlayMedia
        pnlBubble.Controls.Add(btnPlay)

        btnPlayVideo = New Button()
        btnPlayVideo.Text = "▶"
        btnPlayVideo.FlatStyle = FlatStyle.Flat
        btnPlayVideo.BackColor = Color.Transparent
        btnPlayVideo.ForeColor = Color.White
        btnPlayVideo.Font = New Font("Arial", 16, FontStyle.Bold)
        btnPlayVideo.FlatAppearance.BorderSize = 0
        btnPlayVideo.Size = New Size(50, 50)
        btnPlayVideo.Visible = False
        AddHandler btnPlayVideo.Click, AddressOf PlayMedia
        pnlBubble.Controls.Add(btnPlayVideo)

        progressBar = New ProgressBar()
        progressBar.Visible = False
        progressBar.Height = 8
        pnlBubble.Controls.Add(progressBar)

        lblDuration = New Label()
        lblDuration.Visible = False
        lblDuration.Font = New Font("Segoe UI", 7)
        lblDuration.ForeColor = Color.Gray
        pnlBubble.Controls.Add(lblDuration)

        progressTimer = New Timer()
        progressTimer.Interval = 100
        AddHandler progressTimer.Tick, AddressOf ProgressTimer_Tick

        Dim bottomPanel As New Panel()
        bottomPanel.Dock = DockStyle.Bottom
        bottomPanel.Height = TIME_STATUS_HEIGHT + 5
        bottomPanel.BackColor = Color.Transparent
        pnlBubble.Controls.Add(bottomPanel)

        lblTime = New Label()
        lblTime.AutoSize = True
        lblTime.Font = New Font("Segoe UI", 7)
        lblTime.ForeColor = Color.Gray
        lblTime.TextAlign = ContentAlignment.MiddleRight
        lblTime.Dock = DockStyle.Right
        bottomPanel.Controls.Add(lblTime)

        lblStatus = New Label()
        lblStatus.AutoSize = True
        lblStatus.Font = New Font("Segoe UI", 7, FontStyle.Bold)
        lblStatus.TextAlign = ContentAlignment.MiddleRight
        lblStatus.Dock = DockStyle.Right
        lblStatus.Padding = New Padding(0, 0, 5, 0)
        bottomPanel.Controls.Add(lblStatus)

        lblSender = New Label()
        lblSender.AutoSize = True
        lblSender.Font = New Font("Segoe UI", 7)
        lblSender.ForeColor = Color.DarkBlue
        lblSender.TextAlign = ContentAlignment.MiddleRight
        lblSender.Dock = DockStyle.Right
        lblSender.Padding = New Padding(0, 0, 5, 0)
        bottomPanel.Controls.Add(lblSender)
    End Sub

    Private Sub LoadMedia()
        If String.IsNullOrEmpty(_mediaPath) Then Return

        Try
            Select Case _contentType
                Case ContentType.Image
                    ' Load image
                    If File.Exists(_mediaPath) Then
                        picMedia.Image = Image.FromFile(_mediaPath)
                    Else
                        ' Placeholder if image not found
                        picMedia.Image = My.Resources.ImagePlaceholder
                    End If

                Case ContentType.Video
                    ' Load video thumbnail (in a real app, you'd generate this)
                    If File.Exists(_mediaPath) Then
                        picMedia.Image = My.Resources.VideoThumbnail
                    Else
                        picMedia.Image = My.Resources.VideoPlaceholder
                    End If

                Case ContentType.Voice
                    ' No visual for voice
            End Select
        Catch ex As Exception
            ' Handle error
            picMedia.Image = My.Resources.ErrorPlaceholder
        End Try

        UpdateLayout()
    End Sub

    Private Sub UpdateLayout()
        If pnlBubble Is Nothing Then Return

        ' Reset visibility
        txtMessage.Visible = False
        picMedia.Visible = False
        btnPlay.Visible = False
        btnPlayVideo.Visible = False
        progressBar.Visible = False
        lblDuration.Visible = False

        Dim contentSize As Size = Size.Empty
        Dim bubbleHeight As Integer = 0
        Dim bubbleWidth As Integer = 0

        Select Case _contentType
            Case ContentType.Text
                txtMessage.Visible = True
                txtMessage.Text = _messageText
                txtMessage.WordWrap = True
                txtMessage.Multiline = True
                txtMessage.ScrollBars = ScrollBars.None
                txtMessage.Dock = DockStyle.None
                txtMessage.BorderStyle = BorderStyle.None

                ' Hitung tinggi dan lebar teks menggunakan MeasureString (bukan TextRenderer)
                Dim textSize As Size
                Using g As Graphics = txtMessage.CreateGraphics()
                    Dim measured = g.MeasureString(_messageText, txtMessage.Font, MAX_BUBBLE_WIDTH - PADDING_HORIZONTAL * 2)
                    textSize = TextRenderer.MeasureText(_messageText, txtMessage.Font, New Size(MAX_BUBBLE_WIDTH - 30, Integer.MaxValue), TextFormatFlags.WordBreak)
                End Using

                ' Set ukuran TextBox berdasarkan ukuran teks
                txtMessage.Size = New Size(textSize.Width + 10, textSize.Height + 5)

                ' Letakkan TextBox manual (karena tidak pakai Dock)
                txtMessage.Location = New Point(PADDING_HORIZONTAL, PADDING_VERTICAL)

                contentSize = txtMessage.Size
                bubbleWidth = txtMessage.Width + PADDING_HORIZONTAL * 2
                bubbleHeight = txtMessage.Height + PADDING_VERTICAL * 2 + TIME_STATUS_HEIGHT + 10

            Case ContentType.Image
                ' Image content
                picMedia.Visible = True
                picMedia.Size = New Size(MEDIA_WIDTH, MEDIA_HEIGHT)
                contentSize = picMedia.Size
                bubbleHeight = MEDIA_HEIGHT + PADDING_VERTICAL * 2 + TIME_STATUS_HEIGHT
                bubbleWidth = MEDIA_WIDTH + PADDING_HORIZONTAL * 2

            Case ContentType.Voice
                ' Voice content
                btnPlay.Visible = True
                progressBar.Visible = True
                lblDuration.Visible = True

                ' Size for voice player
                contentSize = New Size(250, 40)
                bubbleHeight = 70 + PADDING_VERTICAL * 2 + TIME_STATUS_HEIGHT
                bubbleWidth = 280

                ' Position elements
                btnPlay.Location = New Point(10, 10)
                progressBar.Location = New Point(50, 20)
                progressBar.Width = 180
                lblDuration.Location = New Point(240, 20)
                UpdateDurationDisplay()

            Case ContentType.Video
                ' Video content
                picMedia.Visible = True
                btnPlayVideo.Visible = True
                picMedia.Size = New Size(MEDIA_WIDTH, MEDIA_HEIGHT)
                contentSize = picMedia.Size
                bubbleHeight = MEDIA_HEIGHT + PADDING_VERTICAL * 2 + TIME_STATUS_HEIGHT
                bubbleWidth = MEDIA_WIDTH + PADDING_HORIZONTAL * 2

                ' Center play button
                btnPlayVideo.Location = New Point(
                    (bubbleWidth - btnPlayVideo.Width) \ 2 - 10,
                    (MEDIA_HEIGHT - btnPlayVideo.Height) \ 2
                )
        End Select

        ' Ensure minimum width
        If bubbleWidth < 150 Then bubbleWidth = 150

        ' Set bubble size
        pnlBubble.Size = New Size(bubbleWidth, bubbleHeight)

        ' Set position based on message type
        If _isOutbox Then
            pnlBubble.BackColor = Color.LightBlue
            txtMessage.BackColor = Color.LightBlue
            pnlBubble.Anchor = AnchorStyles.Top Or AnchorStyles.Right
            pnlBubble.Location = New Point(Width - pnlBubble.Width - BUBBLE_MARGIN, BUBBLE_MARGIN)
        Else
            pnlBubble.BackColor = Color.WhiteSmoke
            txtMessage.BackColor = Color.WhiteSmoke
            pnlBubble.Anchor = AnchorStyles.Top Or AnchorStyles.Left
            pnlBubble.Location = New Point(BUBBLE_MARGIN, BUBBLE_MARGIN)
        End If

        ' Set media background
        picMedia.BackColor = pnlBubble.BackColor

        ' Update control height to fit content
        Me.Height = pnlBubble.Height + BUBBLE_MARGIN * 2

        ' Set visibility
        lblStatus.Visible = _isOutbox
        lblSender.Visible = Not _isOutbox

        ' Apply rounded corners
        RoundCorners()
    End Sub

    Private Sub UpdateDurationDisplay()
        If _duration > 0 Then
            lblDuration.Text = $"{_duration \ 60}:{_duration Mod 60:00}"
        Else
            lblDuration.Text = "0:00"
        End If
    End Sub

    Private Sub PlayMedia(sender As Object, e As EventArgs)
        Select Case _contentType
            Case ContentType.Voice
                ' Simulate voice playback
                progressTimer.Start()
                btnPlay.Text = "❚❚"
                RemoveHandler btnPlay.Click, AddressOf PlayMedia
                AddHandler btnPlay.Click, AddressOf PauseMedia

            Case ContentType.Video
                ' Simulate video playback
                MessageBox.Show($"Playing video: {Path.GetFileName(_mediaPath)}", "Video Playback")
        End Select
    End Sub

    Private Sub PauseMedia(sender As Object, e As EventArgs)
        progressTimer.Stop()
        btnPlay.Text = "▶"
        RemoveHandler btnPlay.Click, AddressOf PauseMedia
        AddHandler btnPlay.Click, AddressOf PlayMedia
    End Sub

    Private Sub ProgressTimer_Tick(sender As Object, e As EventArgs)
        If progressBar.Value < progressBar.Maximum Then
            progressBar.Value += 1
        Else
            progressTimer.Stop()
            btnPlay.Text = "▶"
            progressBar.Value = 0
            RemoveHandler btnPlay.Click, AddressOf PauseMedia
            AddHandler btnPlay.Click, AddressOf PlayMedia
        End If
    End Sub

    Private Sub RoundCorners()
        Dim radius As Integer = 15
        Dim path As New Drawing2D.GraphicsPath()
        Dim rect As New Rectangle(0, 0, pnlBubble.Width, pnlBubble.Height)

        If _isOutbox Then
            ' Outbox: rounded left corners
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        Else
            ' Inbox: rounded right corners
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90)
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90)
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90)
        End If

        path.CloseFigure()
        pnlBubble.Region = New Region(path)
    End Sub

    ' Event to handle text selection
    'Private Sub txtMessage_MouseDown(sender As Object, e As MouseEventArgs) Handles txtMessage.MouseDown
    '    If txtMessage.Text.Length > 0 Then
    '        txtMessage.SelectAll()
    '    End If
    'End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        UpdateLayout()
    End Sub
End Class