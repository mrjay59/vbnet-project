Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class WAScanQrForm
    Private mj As New mrjay59
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect

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
        Dim akunid As String = Cbx_AkunID.Text.Trim
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

        If (nprovide = "") Then
            MsgBox("nprovider blank/kosong")
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
        param.Add("akunid", akunid)
        param.Add("name", WAname)
        param.Add("username", username)
        param.Add("counwa", counwa)
        param.Add("navendor", nprovide)
        param.Add("platform", "wascanqr")
        param.Add("tipe", TipeSeassion)


        Dim respon = WApp.OnCreateWAScan(param)

        Dim jsonObject = JsonConvert.DeserializeObject(respon)

        If (jsonObject("status")("code") = 1) Then
            MsgBox(jsonObject("msg"))
            Exit Sub
        End If

        Dim page As New pgMultiBarcode()
        page.LoadBarcodeMulti(respon.ToString)
        page.SendDataUser = DatR

        page.ShowDialog()
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

    Private Sub naprovider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles naprovider.SelectedIndexChanged
        If naprovider.SelectedIndex >= 0 Then
            seassionid.Enabled = True
            CountWa.Enabled = True
        Else
            seassionid.Enabled = False
            CountWa.Enabled = False
        End If

    End Sub

    Private Sub listAkuns()
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", "wascanqr")
        param.Add("data", "akun")

        Dim response = mj.getAkunAkses(param)
        Dim resp2arr = jsonpa.Json2aray(response)

        Dim comboSource As New Dictionary(Of String, String)
        comboSource.Add("", "Pilih Akun")

        If (resp2arr("status")("code") = 0) Then

            If (resp2arr("body").Count = 0) Then
                'MsgBox("Akun tidak ditemukan, silahkan tambah akun di menu akun akses")
                Exit Sub
            End If

            For Each item In resp2arr("body")
                Dim akunid = item("akunid").ToString
                Dim concurrent = item("concurrent").ToString
                Dim appcount = item("appcount").ToString


                Dim serialN = $"{akunid}-{concurrent}-{appcount}"
                Dim nameD = akunid
                comboSource.Add(serialN, nameD)
                Cbx_AkunID.DataSource = New BindingSource(comboSource, Nothing)
                Cbx_AkunID.DisplayMember = "Value"
                Cbx_AkunID.ValueMember = "Key"
                Cbx_AkunID.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                Cbx_AkunID.AutoCompleteSource = AutoCompleteSource.CustomSource
            Next

        End If
    End Sub

    Private Sub Listvendors()
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("platform", "wascanqr")
        param.Add("data", "c_server")

        Dim response = WApp.OnListServer(param)
        Dim resp2arr = jsonpa.Json2aray(response)

        Dim comboSource As New Dictionary(Of String, String)
        comboSource.Add("", "Pilih Vendor")

        If (resp2arr("status")("code") = 0) Then

            For Each item In resp2arr("body")
                Dim vendor = item("aichat_vendor").ToString
                Dim _id = item("aichat_id").ToString



                Dim serialN = $"{vendor}-{_id}"
                Dim nameD = vendor
                comboSource.Add(serialN, nameD)
                naprovider.DataSource = New BindingSource(comboSource, Nothing)
                naprovider.DisplayMember = "Value"
                naprovider.ValueMember = "Key"
                naprovider.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                naprovider.AutoCompleteSource = AutoCompleteSource.CustomSource
            Next

        End If
    End Sub

    Private Sub WAScanQrForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        listAkuns()
        Listvendors()
    End Sub
End Class