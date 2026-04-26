Public Class NewsItemControl
    Inherits UserControl

    Private lblTitle As New Label()
    Private lblContent As New Label()
    Private lblDate As New Label()
    Private WithEvents btnMore As New Button()

    Public Property NewsTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
            AdjustLayout()
        End Set
    End Property

    Public Property NewsContent As String
        Get
            Return If(lblContent.Tag?.ToString(), String.Empty)
        End Get
        Set(value As String)
            Dim safeValue = If(value, String.Empty)
            lblContent.Tag = safeValue

            ' Potong teks menjadi 50 karakter + "More" jika perlu
            If safeValue.Length > 50 Then
                lblContent.Text = safeValue.Substring(0, 50) & "..."
                btnMore.Visible = True
            Else
                lblContent.Text = safeValue
                btnMore.Visible = False
            End If

            AdjustLayout()
        End Set
    End Property

    Public Property NewsDate As DateTime
        Get
            Dim result As DateTime
            If DateTime.TryParse(lblDate.Tag?.ToString(), result) Then
                Return result
            Else
                Return DateTime.Now
            End If
        End Get
        Set(value As DateTime)
            lblDate.Tag = value
            lblDate.Text = value.ToString("dd MMM yyyy")
            AdjustLayout()
        End Set
    End Property

    Public Sub New()
        InitializeComponents()
        ApplyStyling()

        ' Inisialisasi default
        lblContent.Tag = String.Empty
        lblContent.Text = String.Empty
    End Sub

    Private Sub InitializeComponents()
        Me.Size = New Size(250, 120)
        Me.Controls.AddRange({lblTitle, lblContent, lblDate, btnMore})
    End Sub

    Private Sub ApplyStyling()
        ' Style untuk container
        Me.BackColor = Color.Transparent
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Padding = New Padding(8)

        ' Style judul
        lblTitle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        lblTitle.ForeColor = Color.DarkBlue
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(10, 10)

        ' Style konten
        lblContent.Font = New Font("Segoe UI", 8)
        lblContent.ForeColor = Color.DimGray
        lblContent.Location = New Point(10, 35)
        lblContent.Size = New Size(Me.Width - 20, 40)
        lblContent.MaximumSize = New Size(Me.Width - 20, 0)

        ' Style tanggal
        lblDate.Font = New Font("Segoe UI", 7, FontStyle.Italic)
        lblDate.ForeColor = Color.Gray
        lblDate.AutoSize = True
        lblDate.TextAlign = ContentAlignment.MiddleRight

        ' Style tombol More
        btnMore.Text = "More"
        btnMore.FlatStyle = FlatStyle.Flat
        btnMore.BackColor = Color.SteelBlue
        btnMore.ForeColor = Color.White
        btnMore.Size = New Size(60, 20)
        btnMore.Cursor = Cursors.Hand
        btnMore.Visible = False
    End Sub

    Private Sub AdjustLayout()
        ' Atur posisi tanggal
        lblDate.Location = New Point(Me.Width - lblDate.Width - 15, Me.Height - lblDate.Height - 10)

        ' Atur posisi tombol More
        btnMore.Location = New Point(10, Me.Height - btnMore.Height - 10)

        ' Atur tinggi konten
        lblContent.Height = Me.Height - 70
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        AdjustLayout()
    End Sub

    Private Sub btnMore_Click(sender As Object, e As EventArgs) Handles btnMore.Click
        MessageBox.Show(lblContent.Tag.ToString(), "Full Content: " & lblTitle.Text)
    End Sub
End Class