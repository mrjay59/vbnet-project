Imports System.Drawing.Drawing2D

Public Class WAForwardForm
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Public Event SendDataJson As EventHandler(Of ClassData)

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub seassionid_TextChanged(sender As Object, e As EventArgs) Handles seassionid.TextChanged
        ' Simpan posisi cursor sebelum perubahan
        Dim selectionStart As Integer = seassionid.SelectionStart
        Dim selectionLength As Integer = seassionid.SelectionLength

        ' Hilangkan spasi dan konversi ke huruf besar
        seassionid.Text = seassionid.Text.Replace(" ", "").ToUpper()

        ' Kembalikan posisi cursor
        seassionid.SelectionStart = selectionStart
        seassionid.SelectionLength = selectionLength

        If (seassionid.Text.Length > 7) Then
            MsgBox("maksimal 8 karakter")
            Exit Sub
        End If
    End Sub

    Private Sub LoadWAscanQr()

    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        ' Izinkan hanya angka 0-9, backspace, dan delete
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        ' Simpan posisi cursor sebelum perubahan
        Dim selectionStart As Integer = TextBox1.SelectionStart
        Dim selectionLength As Integer = TextBox1.SelectionLength

        ' Hilangkan spasi dan konversi ke huruf besar
        TextBox1.Text = TextBox1.Text.Replace(" ", "").ToUpper()

        ' Kembalikan posisi cursor
        TextBox1.SelectionStart = selectionStart
        TextBox1.SelectionLength = selectionLength

    End Sub

    Private Sub BtnTambahkan_Click(sender As Object, e As EventArgs) Handles BtnTambahkan.Click
        Dim numberMe = TextBox1.Text
        Dim NameWa = seassionid.Text
        Dim prefix = ComboBox2.Text

        If (NameWa = "") Then
            MsgBox("Na WA Blank/kosong")
            Exit Sub

        End If

        If (numberMe = "") Then
            MsgBox("Nomor WA Blank/kosong")
            Exit Sub

        End If

        'If (numberMe.Length < 15) Then
        '    MsgBox("Tidak bisa lebih 15 karakter")
        '    Exit Sub
        'End If


        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim param As New Dictionary(Of String, String)
        param.Add("name", NameWa)
        param.Add("ipserv", "localhost")
        param.Add("port", "5001")
        param.Add("username", username)
        param.Add("platform", "waforward")
        param.Add("wacenter", "")
        param.Add("kode", prefix)
        param.Add("number", prefix & numberMe)

        Dim Respn = WApp.OnCreateServer(param)
        Dim DParx = jsonpa.Json2aray(Respn)
        Dim body = DParx("body")

        MsgBox(body)
    End Sub

    Private Sub BtnTambahkan_Paint(sender As Object, e As PaintEventArgs) Handles BtnTambahkan.Paint
        Dim width = BtnTambahkan.Width
        Dim Height = BtnTambahkan.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnTambahkan.Region = New Region(path)
    End Sub
End Class