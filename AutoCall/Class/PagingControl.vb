Public Class PagingControl
    Inherits Panel

    Public Event PageChanged(page As Integer)

    Private currentPage As Integer = 1
    Private totalPages As Integer = 1
    Private Const maxVisible As Integer = 5

    Public Sub Setup(totalPages As Integer, Optional current As Integer = 1)
        Me.totalPages = totalPages
        Me.currentPage = current
        Me.Controls.Clear()

        Dim btnWidth = 35
        Dim spacing = 5
        Dim startX = 0

        ' Tombol "<"
        Dim prevBtn As Button = CreatePagingButton("<", currentPage > 1)
        prevBtn.Tag = "prev"
        prevBtn.Location = New Point(startX, 0)
        AddHandler prevBtn.Click, AddressOf PageButtonClick
        Me.Controls.Add(prevBtn)
        startX += btnWidth + spacing

        ' Hitung range halaman yang ditampilkan
        Dim startPage = Math.Max(1, currentPage - 2)
        Dim endPage = Math.Min(totalPages, startPage + maxVisible - 1)
        If endPage - startPage < maxVisible - 1 Then
            startPage = Math.Max(1, endPage - maxVisible + 1)
        End If

        ' Nomor halaman
        For i = startPage To endPage
            Dim btn As Button = CreatePagingButton(i.ToString(), True)
            btn.Tag = i
            btn.Location = New Point(startX, 0)

            If i = currentPage Then
                btn.BackColor = Color.LightBlue
            End If

            AddHandler btn.Click, AddressOf PageButtonClick
            Me.Controls.Add(btn)
            startX += btnWidth + spacing
        Next

        ' Tombol ">"
        Dim nextBtn As Button = CreatePagingButton(">", currentPage < totalPages)
        nextBtn.Tag = "next"
        nextBtn.Location = New Point(startX, 0)
        AddHandler nextBtn.Click, AddressOf PageButtonClick
        Me.Controls.Add(nextBtn)
    End Sub

    Private Function CreatePagingButton(text As String, enabled As Boolean) As Button
        Dim btn As New Button()
        btn.Text = text
        btn.Font = New Font("Microsoft Sans Serif", 8.25!)
        btn.FlatStyle = FlatStyle.Flat
        btn.FlatAppearance.BorderSize = 0
        btn.BackColor = Color.Transparent
        btn.Size = New Size(35, 28)
        btn.Enabled = enabled
        Return btn
    End Function

    Private Sub PageButtonClick(sender As Object, e As EventArgs)
        Dim btn As Button = CType(sender, Button)
        Dim tag = btn.Tag.ToString()

        If tag = "prev" AndAlso currentPage > 1 Then
            currentPage -= 1
        ElseIf tag = "next" AndAlso currentPage < totalPages Then
            currentPage += 1
        ElseIf IsNumeric(tag) Then
            currentPage = Integer.Parse(tag)
        End If

        RaiseEvent PageChanged(currentPage)
        Setup(totalPages, currentPage)
    End Sub
End Class
