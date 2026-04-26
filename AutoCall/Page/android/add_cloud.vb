Imports Newtonsoft.Json

Public Class add_cloud
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private adb As New adb
    Private DatR As String = String.Empty
    Private DataDevice = String.Empty
    Private PathDevice = String.Empty

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnscan_Click(sender As Object, e As EventArgs) Handles btnscan.Click
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim TokenTxt As String = txtToken.Text.Trim

        Dim param As New Dictionary(Of String, String)
        param.Add("token", TokenTxt)
        param.Add("username", username)
        param.Add("tipe", "cekClould")

        Try
            Dim response = Ap_mrjay59.dev_state(param)

            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 0) Then



                Dim bodyDa = jsonObject("body")

                Dim AkunId = bodyDa("apk_akunid")
                Dim Concurrent = bodyDa("apk_concurrent")
                Dim TglBuat = bodyDa("apk_create")
                Dim TglExp = bodyDa("apk_expire")
                Dim tipeAk = bodyDa("tipe_akun")
                Dim idleDe = bodyDa("apk_idle")

                Dim unixTime As Long = TglBuat
                Dim epoch As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                Dim localTime As DateTime = epoch.AddSeconds(unixTime).ToLocalTime()

                Dim unixTimeEx As Long = TglExp
                Dim epochEx As New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                Dim localTimeEx As DateTime = epochEx.AddSeconds(unixTimeEx).ToLocalTime()

                LblAkunId.Lblname.Text = "Akun ID"
                LblAkunId.txtinput.Enabled = True
                LblAkunId.txtinput.ReadOnly = True
                LblAkunId.txtinput.Text = AkunId

                LblConcurrent.Lblname.Text = "Concurrent"
                LblConcurrent.txtinput.Enabled = True
                LblConcurrent.txtinput.ReadOnly = True
                LblConcurrent.txtinput.Text = Concurrent

                LblTglCreate.Lblname.Text = "Tgl Buat"
                LblTglCreate.txtinput.Enabled = True
                LblTglCreate.txtinput.ReadOnly = True
                LblTglCreate.txtinput.Text = localTime

                LblTglExpire.Lblname.Text = "Tgl Expire"
                LblTglExpire.txtinput.Enabled = True
                LblTglExpire.txtinput.ReadOnly = True
                LblTglExpire.txtinput.Text = localTimeEx

                lbTipeAkun.Lblname.Text = "Tipe Akun"
                lbTipeAkun.txtinput.Enabled = True
                lbTipeAkun.txtinput.ReadOnly = True
                lbTipeAkun.txtinput.Text = tipeAk

                lbIdle.Lblname.Text = "Idle"
                lbIdle.txtinput.Enabled = True
                lbIdle.txtinput.ReadOnly = True
                lbIdle.txtinput.Text = idleDe

            Else
                MsgBox(jsonObject("msg"))
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub nameL()
        LblAkunId.Lblname.Text = "Akun ID"
        LblConcurrent.Lblname.Text = "Concurrent"
        LblTglCreate.Lblname.Text = "Tgl Buat"
        LblTglExpire.Lblname.Text = "Tgl Expire"
        lbTipeAkun.Lblname.Text = "Tipe Akun"
        lbIdle.Lblname.Text = "Idle"


    End Sub
    Private Sub BtnAdding_Click(sender As Object, e As EventArgs) Handles BtnAdding.Click
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim TokenTxt As String = txtToken.Text.Trim

        Dim param As New Dictionary(Of String, String)
        param.Add("token", TokenTxt)
        param.Add("username", username)
        param.Add("tipe", "cekActive")

        Try
            Dim response = Ap_mrjay59.dev_state(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)
            MsgBox(jsonObject("msg"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub add_cloud_Load(sender As Object, e As EventArgs) Handles Me.Load
        nameL()
    End Sub
End Class