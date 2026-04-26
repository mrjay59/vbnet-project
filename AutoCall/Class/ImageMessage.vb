Imports System.Drawing.Drawing2D

Public Class ImageMessage
    Inherits ChatBubble

    Private picMessageImage As PictureBox
    Private Const IMAGE_MAX_WIDTH As Integer = 250
    Private Const IMAGE_MAX_HEIGHT As Integer = 250

    Public Sub New(image As Image, Optional isOutgoing As Boolean = False)
        MyBase.New()
        Me.IsOutgoing = isOutgoing

        ' Setup gambar pesan
        picMessageImage = New PictureBox()
        picMessageImage.SizeMode = PictureBoxSizeMode.Zoom
        SetImage(image)
        Me.Controls.Add(picMessageImage)
        Me.Controls.SetChildIndex(picMessageImage, 0)
    End Sub

    Public Sub SetImage(image As Image)
        ' Hitung ukuran yang proporsional
        Dim ratio As Double = Math.Min(
            IMAGE_MAX_WIDTH / image.Width,
            IMAGE_MAX_HEIGHT / image.Height)

        Dim newWidth As Integer = CInt(image.Width * ratio)
        Dim newHeight As Integer = CInt(image.Height * ratio)

        picMessageImage.Image = image
        picMessageImage.Size = New Size(newWidth, newHeight)

        ' Update ukuran bubble
        Me.Size = New Size(
            newWidth + Me.Padding.Horizontal + If(Me.ShowAvatar, AVATAR_SIZE + AVATAR_MARGIN * 2, 0),
            newHeight + Me.Padding.Vertical + If(Me.ShowTime, 20, 0))

        ' Posisikan gambar
        picMessageImage.Location = New Point(
            If(Me.IsOutgoing, Me.Width - newWidth - Me.Padding.Right, Me.Padding.Left),
            Me.Padding.Top)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        ' Gambar bubble hanya di sekitar gambar
        Dim bubbleRect As New Rectangle(
            picMessageImage.Left - 5,
            picMessageImage.Top - 5,
            picMessageImage.Width + 10,
            picMessageImage.Height + 10)

        Dim path As GraphicsPath = GetRoundedRectPath(bubbleRect, Me.BorderRadius)

        Using brush As New SolidBrush(Me.BackColor)
            e.Graphics.FillPath(brush, path)
        End Using

        Using pen As New Pen(Color.FromArgb(200, 200, 200))
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub
End Class