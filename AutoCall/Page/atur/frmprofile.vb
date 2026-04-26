Imports System.IO
Imports Newtonsoft.Json

Public Class frmprofile
    Private DatR As String = String.Empty
    Private EnDe As New DeEnCrypt
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson


    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub BtnChPass_Click(sender As Object, e As EventArgs) Handles BtnChPass.Click
        Dim pslama = UCformtext10.txtinput.Text.Trim
        Dim psbaruu = UCformtext9.txtinput.Text.Trim
        Dim psbarur = UCformtext8.txtinput.Text.Trim

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim msg = "Apa Yakin Mau Ganti Passwordnya?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            ' service register member
            Dim param As New Dictionary(Of String, String)
            param.Add("username", username)
            param.Add("passlama", pslama)
            param.Add("passbaru1", psbaruu)
            param.Add("passbaru2", psbarur)
            Dim apkname = dbConn.ApkProfile("name")
            Dim DbSource As String = dbConn.SearchPATH()
            Dim soudb = JsonConvert.DeserializeObject(DbSource)
            soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname) = ""

            Dim response = Ap_mrjay59.gantipass(param)
            Dim jsonrespon = JsonConvert.DeserializeObject(response)

            If (jsonrespon("status")("code") = 1) Then
                For Each item In jsonrespon("error")
                    MsgBox(item)
                Next
            Else
                MsgBox(jsonrespon("body"))
                Dim upjson = soudb.ToString
                File.WriteAllText(Application.StartupPath & "\Application\setting.json", upjson)


                Me.Close()
                Form1.Close()
                frmLayer1.Close()
                PgLoading.TopLevel = True
                PgLoading.Startimer()
                PgLoading.Show()
            End If
        End If

    End Sub

    Private Sub frmprofile_Load(sender As Object, e As EventArgs) Handles Me.Load
        UCformtext10.Lblname.Text = "Password Lama"
        UCformtext9.Lblname.Text = "Password Baru"
        UCformtext8.Lblname.Text = "Konfirmasi Password Baru"
        UCformtext10.Btneyes.Visible = True
        UCformtext9.Btneyes.Visible = True
        UCformtext8.Btneyes.Visible = True

        UCformtext10.txtinput.PasswordChar = "*"
        UCformtext9.txtinput.PasswordChar = "*"
        UCformtext8.txtinput.PasswordChar = "*"
        UCformtext10.txtinput.Tag = "N"
        UCformtext9.txtinput.Tag = "N"
        UCformtext8.txtinput.Tag = "N"
        UCformtext10.txtinput.ReadOnly = False
        UCformtext9.txtinput.ReadOnly = False
        UCformtext8.txtinput.ReadOnly = False

        UCformtext1.Lblname.Text = "Username"
        UCformtext2.Lblname.Text = "Nama"
        UCformtext3.Lblname.Text = "Paket"
        UCformtext4.Lblname.Text = "Status"
        UCformtext5.Lblname.Text = "Versi"

        UCformtext6.Lblname.Text = "HP BARU"
        UCformtext7.Lblname.Text = "HP TERDAFTAR"
        UCformtext7.txtinput.ReadOnly = True

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        Dim apk_user = DPar("body")("apk_user")
        Dim apk_fullname = DPar("body")("apk_fullname")
        Dim apk_hp = DPar("body")("apk_hp")
        Dim apk_stat = DPar("body")("apk_stat")
        Dim exptoken = DPar("body")("token")("exptoken")
        ' Dim data = jsonpa.Json2aray(ParData("body")("apk_data"))
        Dim prodname = DPar("body")("apk_data")(0)("apk_product")
        Dim prodversi = DPar("body")("apk_data")(0)("apk_versi")
        Dim paket = DPar("body")("apk_data")(0)("apk_status")

        UCformtext1.txtinput.Text = apk_user
        UCformtext2.txtinput.Text = apk_fullname
        UCformtext3.txtinput.Text = paket
        UCformtext4.txtinput.Text = IIf(apk_stat = "AK", "AKTIF", "TIDAK")
        UCformtext5.txtinput.Text = prodversi
        UCformtext7.txtinput.Text = apk_hp

    End Sub
End Class