Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class WAScanQrForm
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

    Private Sub BtnADD_Click(sender As Object, e As EventArgs) Handles BtnADD.Click
        Dim TipeSeassion = String.Empty
        Dim WAname = String.Empty

        Dim nprovide As String = naprovider.Text.Trim
        WAname = seassionid.Text.Trim

        If (rqQrcode.Checked) Then
            TipeSeassion = "rqQrkode"
        ElseIf (RqRegCode.Checked) Then
            TipeSeassion = "rqRegcode"
        Else
            MsgBox("belum dipilih silahkan checked ")
            Exit Sub
        End If


        If (WAname = "") Then
            MsgBox("seassionid blank/kosong")
            Exit Sub
        End If

        If (WAname.Length > 8) Then
            MsgBox("Tidak bisa lebih 8 karakter")
            Exit Sub
        End If


        Dim valid As Boolean = Regex.IsMatch(WAname, "^[a-zA-Z0-9\-_]+$")

        If Not valid Then
            MsgBox("Tidak Boleh ada karakter simbol")
            Exit Sub
        End If

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim counwa = CountWa.Value
        Dim param As New Dictionary(Of String, String)
        param.Add("name", WAname)
        param.Add("username", username)
        param.Add("counwa", counwa)
        param.Add("navendor", nprovide)
        param.Add("platform", "wascanqr")
        param.Add("tipe", TipeSeassion)


        Dim respon = WApp.OnCreateWAScan(param)
        Dim jsonObject = JsonConvert.DeserializeObject(respon)


        If (jsonObject("status")("code") = 1) Then
            MsgBox(jsonObject("error"))
            Exit Sub
        Else


            ' RaiseEvent SendDataJson(Me, New ClassData(respon.ToString))
            ' Threading.Thread.Sleep(500)
            Dim page As New pgMultiBarcode()
            page.LoadBarcodeMulti(respon.ToString)
            page.SendDataUser = DatR
            '  AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
            AddHandler Form1.SendDataJson, AddressOf page.OnReceiveData

            page.ShowDialog()
            LoadDataWAScan()

            RemoveHandler Form1.SendDataJson, AddressOf page.OnReceiveData
            ' RemoveHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
        End If
    End Sub

    Private Sub RdTipe1_CheckedChanged(sender As Object, e As EventArgs) Handles rqQrcode.CheckedChanged

        CountWa.Maximum = 4
    End Sub

    Private Sub RdTipe2_CheckedChanged(sender As Object, e As EventArgs) Handles RqRegCode.CheckedChanged

        CountWa.Maximum = 1
    End Sub

    Private Sub BtnADD_Paint(sender As Object, e As PaintEventArgs) Handles BtnADD.Paint
        Dim width = BtnADD.Width
        Dim Height = BtnADD.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnADD.Region = New Region(path)
    End Sub

    Private Sub LoadDataWAScan()
        Dim param As New Dictionary(Of String, String)
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        param.Add("username", username)


        Dim ListWA As String = WApp.OnListWAScan(param)
        Dim DatParse = jsonpa.Json2aray(ListWA)
        Dim WaScan As JArray = DatParse("body")


        If (WaScan.Count > 0) Then

            naprovider.Controls.Clear()
            ' Isi ComboBox
            naprovider.DataSource = WaScan
            naprovider.DisplayMember = "aichat_name"
            naprovider.ValueMember = "aichat_count"

            naprovider.SelectedIndex = 0
        End If
    End Sub

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
End Class