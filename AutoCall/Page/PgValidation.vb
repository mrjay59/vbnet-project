
Imports System.Globalization
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class PgValidation
    Private jsonpa As New ClassJson
    Private DatR As String = String.Empty
    Private Ap_mrjay59 As New mrjay59
    Private dbConn As New ClassConnect

    Private Sub DataMasuk(sender As Object, e As ClassData)
        Dim RData As String = e.Data
        Dim ParData = jsonpa.Json2aray(RData)

        Dim menu = ParData("menu")

        If (menu = "signup") Then
            BtnSt1.Enabled = False
            DatR = ParData("data")
            BtnSt2.ForeColor = Color.White
            BtnSt2_Click(sender, e)


        ElseIf (menu = "paket") Then
            DatR = ParData("data")
            Dim DatParse = jsonpa.Json2aray(DatR)
            Dim username As String = DatParse("username").ToString
            Dim userpass As String = DatParse("userpass").ToString
            login(username, userpass)
            Threading.Thread.Sleep(1000)
            BtnSt3.ForeColor = Color.White
            BtnSt3_Click(sender, e)


        End If
    End Sub


    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub BtnSt1_Click(sender As Object, e As EventArgs) Handles BtnSt1.Click
        lblheader.Text = "Buat Akun->Validasi"
        BtnSt1.BackColor = Color.Transparent
        BtnSt2.BackColor = Color.FromArgb(80, 65, 190)
        BtnSt3.BackColor = Color.FromArgb(80, 65, 190)
        Dim page As New pgset1
        PanelPusat.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        AddHandler page.DataSelected, AddressOf DataMasuk
        PanelPusat.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub PgValidation_Load(sender As Object, e As EventArgs) Handles Me.Load
        BtnSt1_Click(sender, e)
    End Sub

    Private Sub login(ByVal username As String, ByVal userpass As String)
        Dim apkname = dbConn.ApkProfile("name")
        ' service register member
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("userpass", userpass)
        param.Add("apk_produk", apkname)

        Try
            Dim restoken = Ap_mrjay59.getoken(param)
            Dim dejsontoken = JsonConvert.DeserializeObject(restoken)

            Dim DbSource As String = dbConn.SearchPATH()
            Dim soudb = JsonConvert.DeserializeObject(DbSource)
            soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname) = dejsontoken("body")("apk_getoken")


            Dim upjson = soudb.ToString
            File.WriteAllText(Application.StartupPath & "\Application\setting.json", upjson)
        Catch generatedExceptionName As JsonSerializationException
            Console.WriteLine("The string is not valid JSON.")
        End Try
    End Sub
    Private Sub BtnSt2_Click(sender As Object, e As EventArgs) Handles BtnSt2.Click
        lblheader.Text = "Buat Akun->Isi Form"
        BtnSt1.BackColor = Color.FromArgb(80, 65, 190)
        BtnSt2.BackColor = Color.Transparent
        BtnSt3.BackColor = Color.FromArgb(80, 65, 190)

        Form1.PanelView.Controls.Clear()
        Try
            Dim page As New frmSignUp
            PanelPusat.Controls.Clear()
            page.Dock = DockStyle.Fill
            page.ReceivedData = DatR
            AddHandler page.DataSelected, AddressOf DataMasuk
            PanelPusat.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnSt3_Click(sender As Object, e As EventArgs) Handles BtnSt3.Click
        lblheader.Text = "Buat Akun->Pilih Paket"
        BtnSt1.BackColor = Color.FromArgb(80, 65, 190)
        BtnSt2.BackColor = Color.FromArgb(80, 65, 190)
        BtnSt3.BackColor = Color.Transparent

        PanelPusat.Controls.Clear()

        pilihpaket()



    End Sub

    Private Sub pilihpaket()
        Dim DataRespon = Ap_mrjay59.DataUser
        Dim J2Object = jsonpa.Json2aray(DataRespon)
        Dim apkprd As String = J2Object("body")("apk_produk")("apk_desc").ToString
        Dim culture As CultureInfo = New CultureInfo("id-ID")

        Dim JObject As New JObject
        JObject = JObject.Parse(apkprd)
        Dim JArr As JArray = JObject.Item("data")
        For ix = 0 To JArr.Count - 1
            Dim napaket As String = JArr(ix).Item("paket").ToString
            Dim Hapaket As Decimal = JArr(ix).Item("harga")
            Dim ArDesc As JArray = JArr(ix).Item("desc")
            Dim fiprice As Decimal = Hapaket
            Dim frmhrg As String = fiprice.ToString("C", culture)





            Dim Uiuse As New CtPackageUser
            Uiuse.lbPaket.Text = napaket
            Uiuse.LblPrice.Text = frmhrg


            For iy = 0 To ArDesc.Count - 1
                Dim itDesc As String = ArDesc(iy).ToString
                Dim uiLab As New CtUserProfile
                uiLab.Lblname.Text = itDesc

                uiLab.Location = New Point(4, iy * 37)
                Uiuse.PanelPusat.Controls.Add(uiLab)
            Next


            Uiuse.Location = New Point(ix * 247, 4)
            PanelPusat.Controls.Add(Uiuse)
        Next

    End Sub

End Class