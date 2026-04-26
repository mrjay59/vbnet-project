Imports System.Drawing.Drawing2D

Public Class ChatBubble
    Inherits UserControl

    Private _message As String = ""
    Private _isOutgoing As Boolean = False
    Private _borderRadius As Integer = 15
    Private _showTime As Boolean = True
    Private _messageTime As DateTime = DateTime.Now
    Private lblTime As Label
    Private _showAvatar As Boolean = True
    Private _avatarImage As Image
    Private picAvatar As PictureBox
    Public Const AVATAR_SIZE As Integer = 40
    Public Const AVATAR_MARGIN As Integer = 10
    Public Enum MessageStatus
        Sending
        Sent
        Delivered
        Read
        Failed
    End Enum

    Private _status As MessageStatus = MessageStatus.Sending
    Private statusLabel As New Label()
    Private statusIcon As New PictureBox()

    Public Property Status() As MessageStatus
        Get
            Return _status
        End Get
        Set(value As MessageStatus)
            _status = value
            UpdateStatusDisplay()
        End Set
    End Property
    Public Property ShowAvatar() As Boolean
        Get
            Return _showAvatar
        End Get
        Set(value As Boolean)
            _showAvatar = value
            picAvatar.Visible = value
            UpdateLayout()
        End Set
    End Property

    Public Property AvatarImage() As Image
        Get
            Return _avatarImage
        End Get
        Set(value As Image)
            _avatarImage = value
            picAvatar.Image = value
            UpdateLayout()
        End Set
    End Property
    Public Property Message() As String
        Get
            Return _message
        End Get
        Set(value As String)
            _message = value
            UpdateLayout()
            Invalidate() ' Redraw control
        End Set
    End Property

    Public Property IsOutgoing() As Boolean
        Get
            Return _isOutgoing
        End Get
        Set(value As Boolean)
            _isOutgoing = value
            UpdateLayout()
            Invalidate()
        End Set
    End Property

    Public Property BorderRadius() As Integer
        Get
            Return _borderRadius
        End Get
        Set(value As Integer)
            _borderRadius = value
            Invalidate()
        End Set
    End Property

    Private lblText As Label
    Private maxWidth As Integer = 350 ' Lebar maksimum bubble

    Public Sub New()
        ' Setup dasar UserControl
        Me.DoubleBuffered = True
        Me.BackColor = Color.White
        Me.Font = New Font("Segoe UI", 9)
        Me.Padding = New Padding(10)

        ' Inisialisasi label
        lblText = New Label()
        lblText.AutoSize = True
        lblText.MaximumSize = New Size(maxWidth - Me.Padding.Horizontal, 0)
        lblText.BackColor = Color.Transparent
        lblText.Text = _message
        Me.Controls.Add(lblText)

        ' Inisialisasi label waktu
        lblTime = New Label()
        lblTime.AutoSize = True
        lblTime.Font = New Font("Segoe UI", 7, FontStyle.Regular)
        lblTime.ForeColor = Color.Gray
        lblTime.Text = _messageTime.ToString("HH:mm")
        lblTime.BackColor = Color.Transparent
        Me.Controls.Add(lblTime)

        ' Inisialisasi PictureBox untuk avatar
        picAvatar = New PictureBox()
        picAvatar.Size = New Size(AVATAR_SIZE, AVATAR_SIZE)
        picAvatar.SizeMode = PictureBoxSizeMode.Zoom
        picAvatar.Image = _avatarImage
        picAvatar.BackColor = Color.Transparent
        Me.Controls.Add(picAvatar)

        ' Posisikan avatar
        If _isOutgoing Then
            picAvatar.Left = Me.Width - AVATAR_SIZE - AVATAR_MARGIN
        Else
            picAvatar.Left = AVATAR_MARGIN
        End If
        picAvatar.Top = AVATAR_MARGIN

        ' Setup status controls
        statusIcon.Size = New Size(12, 12)
        statusIcon.BackColor = Color.Transparent

        statusLabel.Font = New Font("Segoe UI", 7)
        statusLabel.ForeColor = Color.Gray
        statusLabel.AutoSize = True

        Me.Controls.Add(statusIcon)
        Me.Controls.Add(statusLabel)
    End Sub

    Private Sub UpdateStatusDisplay()
        Select Case _status
            Case MessageStatus.Sending
                statusIcon.Image = My.Resources.ClockIcon ' Icon jam loading
                statusLabel.Text = "Mengirim..."
            Case MessageStatus.Sent
                statusIcon.Image = My.Resources.SingleCheck
                statusLabel.Text = "Terkirim"
            Case MessageStatus.Delivered
                statusIcon.Image = My.Resources.DoubleCheck
                statusLabel.Text = "Terkirim"
            Case MessageStatus.Read
                statusIcon.Image = My.Resources.DoubleCheckBlue
                statusLabel.Text = "Dibaca " & DateTime.Now.ToString("HH:mm")
            Case MessageStatus.Failed
                statusIcon.Image = My.Resources.ErrorIcon
                statusLabel.Text = "Gagal mengirim"
        End Select

        ' Atur posisi
        statusIcon.Location = New Point(
            Me.Width - statusIcon.Width - 25,
            Me.Height - statusIcon.Height - 5)

        statusLabel.Location = New Point(
            statusIcon.Left - statusLabel.Width - 5,
            statusIcon.Top - 2)

        Me.Invalidate()
    End Sub

    Public Property ShowTime() As Boolean
        Get
            Return _showTime
        End Get
        Set(value As Boolean)
            _showTime = value
            lblTime.Visible = value
            UpdateLayout()
        End Set
    End Property

    Public Property MessageTime() As DateTime
        Get
            Return _messageTime
        End Get
        Set(value As DateTime)
            _messageTime = value
            lblTime.Text = value.ToString("HH:mm")
            UpdateLayout()
        End Set
    End Property

    Private Sub UpdateBubbleStyle()
        Select Case _status
            Case MessageStatus.Failed
                Me.BackColor = Color.FromArgb(255, 230, 230)
                Me.ForeColor = Color.FromArgb(200, 0, 0)
            Case MessageStatus.Read
                Me.BackColor = Color.FromArgb(230, 245, 255)
            Case Else
                Me.BackColor = If(_isOutgoing, Color.FromArgb(220, 248, 198), Color.White)
        End Select
    End Sub

    Private Sub UpdateLayout()
        ' Update teks
        lblText.Text = _message

        ' Hitung ulang ukuran dengan memperhitungkan waktu
        Dim textSize As Size = TextRenderer.MeasureText(_message, Me.Font,
            New Size(maxWidth - Me.Padding.Horizontal - 40, Integer.MaxValue),
            TextFormatFlags.WordBreak)

        ' Posisikan label teks
        lblText.Size = textSize
        lblText.Location = New Point(Me.Padding.Left, Me.Padding.Top)

        ' Posisikan label waktu di kanan bawah
        lblTime.Location = New Point(
            Me.Width - lblTime.Width - 10,
            Me.Height - lblTime.Height - 5)

        ' Sesuaikan warna waktu berdasarkan arah pesan
        If _isOutgoing Then
            lblTime.ForeColor = Color.FromArgb(100, 130, 80)
        Else
            lblTime.ForeColor = Color.Gray
        End If

        ' Update warna berdasarkan jenis pesan
        If _isOutgoing Then
            Me.BackColor = Color.FromArgb(220, 248, 198) ' Warna untuk pesan keluar
        Else
            Me.BackColor = Color.White ' Warna untuk pesan masuk
        End If


        ' Sesuaikan margin berdasarkan ada/tidaknya avatar
        Dim leftMargin As Integer = If(_showAvatar AndAlso Not _isOutgoing,
                                    AVATAR_SIZE + AVATAR_MARGIN * 2,
                                    Me.Padding.Left)
        Dim rightMargin As Integer = If(_showAvatar AndAlso _isOutgoing,
                                     AVATAR_SIZE + AVATAR_MARGIN * 2,
                                     Me.Padding.Right)

        ' Atur ukuran UserControl
        Me.Size = New Size(
            Math.Min(textSize.Width + leftMargin + rightMargin + 40, maxWidth),
            Math.Max(textSize.Height + Me.Padding.Vertical + If(_showTime, 15, 0),
            AVATAR_SIZE + AVATAR_MARGIN * 2))

        ' Posisikan avatar
        If _isOutgoing Then
            picAvatar.Left = Me.Width - AVATAR_SIZE - AVATAR_MARGIN
        Else
            picAvatar.Left = AVATAR_MARGIN
        End If
        picAvatar.Top = AVATAR_MARGIN
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Buat path untuk border cembung
        Dim path As GraphicsPath = GetRoundedRectPath(New Rectangle(0, 0, Me.Width - 1, Me.Height - 1), _borderRadius)

        ' Isi background
        Using brush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(brush, path)
        End Using

        ' Gambar border
        Using pen As New Pen(Color.FromArgb(200, 200, 200))
            e.Graphics.DrawPath(pen, path)
        End Using

        ' Gambar ekor bubble (opsional)
        If _isOutgoing Then
            ' Ekor di kanan
            Dim tailPoints() As Point = {
                New Point(Me.Width - 10, Me.Height - 15),
                New Point(Me.Width, Me.Height - 10),
                New Point(Me.Width - 10, Me.Height - 5)
            }
            e.Graphics.FillPolygon(New SolidBrush(Me.BackColor), tailPoints)
            e.Graphics.DrawPolygon(New Pen(Color.FromArgb(200, 200, 200)), tailPoints)
        Else
            ' Ekor di kiri
            Dim tailPoints() As Point = {
                New Point(10, Me.Height - 15),
                New Point(0, Me.Height - 10),
                New Point(10, Me.Height - 5)
            }
            e.Graphics.FillPolygon(New SolidBrush(Me.BackColor), tailPoints)
            e.Graphics.DrawPolygon(New Pen(Color.FromArgb(200, 200, 200)), tailPoints)
        End If

        ' Gambar waktu langsung jika ingin lebih presisi
        If _showTime Then
            Dim timeText As String = _messageTime.ToString("HH:mm")
            Dim timeSize As Size = TextRenderer.MeasureText(timeText, lblTime.Font)
            Dim timeX As Integer = Me.Width - timeSize.Width - 10
            Dim timeY As Integer = Me.Height - timeSize.Height - 5

            TextRenderer.DrawText(e.Graphics, timeText, lblTime.Font,
                New Point(timeX, timeY), lblTime.ForeColor)
        End If
    End Sub

    Public Function GetRoundedRectPath(rect As Rectangle, radius As Integer) As GraphicsPath
        Dim path As New GraphicsPath()
        path.StartFigure()

        ' Sudut kiri atas
        path.AddArc(rect.X, rect.Y, radius, radius, 180, 90)
        ' Sudut kanan atas
        path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90)
        ' Sudut kanan bawah
        path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90)
        ' Sudut kiri bawah
        path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90)

        path.CloseFigure()
        Return path
    End Function

    Protected Overrides Sub OnMouseEnter(e As EventArgs)
        MyBase.OnMouseEnter(e)
        lblTime.ForeColor = Color.DarkGray
    End Sub

    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        If _isOutgoing Then
            lblTime.ForeColor = Color.FromArgb(100, 130, 80)
        Else
            lblTime.ForeColor = Color.Gray
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        Me.Invalidate() ' Pastikan tampilan diperbarui saat ukuran berubah
    End Sub
End Class