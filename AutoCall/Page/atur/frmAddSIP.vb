Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmAddSIP
    Private EnDe As New DeEnCrypt
    Private dbConn As New ClassConnect
    Private mj As New mrjay59
    Private jsonpa As New ClassJson
    Private DatR As String = String.Empty


    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub lodsipserver()

        ViewTabel0.Rows.Clear()

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", "sipserver")

        Dim response = mj.getAkunAkses(param)

        Dim resp2arr = jsonpa.Json2aray(response)

        If (resp2arr("status")("code") = 0) Then
            Dim ax = 0
            For Each item In resp2arr("body")
                Dim akunid = item("akunid").ToString
                Dim concurrent = item("concurrent").ToString
                Dim listapp = item("listapp").ToString
                Dim unix_exp = item("unix_exp").ToString
                Dim date_exp = item("date_exp").ToString
                Dim idle = item("idle").ToString
                Dim state = IIf(item("state").ToString = "AK", "AKTIF", "NOT AKTIF")
                Dim limit_perday As Integer = item("limit_perday")
                Dim limit_pernumber As Integer = item("limit_recall")

                Dim Datitem = jsonpa.Json2aray(listapp)
                Dim applist = Datitem("apk")
                Dim approp As IEnumerable(Of JProperty) = applist.Properties()
                ax = ax + 1
                For Each prop As JProperty In approp
                    Dim appname = prop.Name
                Next

                Dim row As String() = New String() {ax, akunid, concurrent, idle, state}
                Dim rowIndex As Integer = ViewTabel0.Rows.Add(row)

                ViewTabel0.Rows(rowIndex).Cells("IDAKUN").Tag = listapp

            Next

        End If
    End Sub

    Private Sub frmAddSIP_Load(sender As Object, e As EventArgs) Handles Me.Load
        lodsipserver()
        nameL()
    End Sub

    Private Sub BtnChecking_Click(sender As Object, e As EventArgs) Handles BtnChecking.Click

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim TokenAndro = txtToken.Text.Trim


        If (TokenAndro = "") Then
            MsgBox("Token Masih kosong /belum diinput")
            Exit Sub
        End If
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("token", TokenAndro)
        param.Add("tipe", "csipserver")

        Try
            Dim response = mj.dev_state(param)

            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 1) Then
                MsgBox(jsonObject("msg"))
                Exit Sub
            End If

            If (jsonObject("status")("code") = 0) Then

                Dim bodyDa = jsonObject("body")

                Dim AkunId = bodyDa("apk_akunid")
                Dim Concurrent = bodyDa("apk_concurrent")
                Dim TglBuat = bodyDa("apk_create")
                Dim TglExp = bodyDa("apk_expire")
                Dim tipeAk = bodyDa("tipe_akun")
                Dim state = bodyDa("apk_state")
                Dim ap_sub = bodyDa("apk_subscribe")

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
                LblTglExpire.txtinput.Tag = TglExp

                lbTipeAkun.Lblname.Text = "Tipe Akun"
                lbTipeAkun.txtinput.Enabled = True
                lbTipeAkun.txtinput.ReadOnly = True
                lbTipeAkun.txtinput.Text = tipeAk

                lbIdle.Lblname.Text = "State"
                lbIdle.txtinput.Enabled = True
                lbIdle.txtinput.ReadOnly = True
                lbIdle.txtinput.Text = IIf(state = "AK", "AKTIF", "TIDAK AKTIF")

                uc_subscribe.Lblname.Text = "Subscribe"
                uc_subscribe.txtinput.Enabled = True
                uc_subscribe.txtinput.ReadOnly = True
                uc_subscribe.txtinput.Text = ap_sub

                BtnChecking.Enabled = False
                txtToken.Enabled = False
            End If
        Catch ex As Exception

        End Try

        BtnChecking.Enabled = False
        txtToken.Enabled = False
    End Sub

    Private Sub nameL()
        LblAkunId.Lblname.Text = "Akun ID"
        LblConcurrent.Lblname.Text = "Concurrent"
        LblTglCreate.Lblname.Text = "Tgl Buat"
        LblTglExpire.Lblname.Text = "Tgl Expire"
        lbTipeAkun.Lblname.Text = "Tipe Akun"
        lbIdle.Lblname.Text = "State"
        uc_subscribe.Lblname.Text = "Subscribe"


    End Sub

    Private Sub ViewTabel0_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel0.CellContentClick
        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex

        DataGridView1.Rows.Clear()

        Dim listapp = ViewTabel0.Rows(indrow).Cells("IDAKUN").Tag.ToString.Trim

        Dim Datitem = jsonpa.Json2aray(listapp)
        Dim applist = Datitem("apk")
        Dim approp As IEnumerable(Of JProperty) = applist.Properties()
        Dim ax As Integer = 0
        For Each prop As JProperty In approp
            ax = ax + 1
            Dim appname = prop.Name
            Dim appkode = applist(appname)("appkode").ToString
            Dim subscribe = applist(appname)("subscribe").ToString
            Dim state = applist(appname)("state").ToString
            Dim busy_by = applist(appname)("busy_by").ToString
            Dim expired As Double = applist(appname)("expired")

            Dim limit_perday_use_call As Integer = applist(appname)("limit_perday")("use_call")
            Dim limit_perday_call As Integer = applist(appname)("limit_perday")("call")
            Dim limit_pernumber_use_call = applist(appname)("limit_pernumber")("use_call")
            Dim limit_pernumber_call = applist(appname)("limit_pernumber")("call")

            Dim limit_perday = $"{limit_perday_use_call}/{limit_perday_call}"
            Dim limit_pernumber = $"{limit_pernumber_use_call}/{limit_pernumber_call}"


            Dim row As String() = New String() {ax, appkode, subscribe, limit_perday, limit_pernumber, state}
            Dim rowIndex As Integer = DataGridView1.Rows.Add(row)
        Next
    End Sub

    Private Sub BtnAdding_Click(sender As Object, e As EventArgs) Handles BtnAdding.Click
        Dim akunid = LblAkunId.txtinput.Text
        Dim concurrent As Integer = LblConcurrent.txtinput.Text
        Dim tipeA = lbTipeAkun.txtinput.Text
        Dim subscribe = uc_subscribe.txtinput.Text
        Dim Expired = LblTglExpire.txtinput.Tag

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        'simpan ke server
        Dim param As New JObject
        param.Add("username", username)
        param.Add("concurrent", concurrent)
        param.Add("akunid", akunid)
        param.Add("subscribe", subscribe)
        param.Add("expired", Expired)
        param.Add("tipe", tipeA)

        Try
            Dim response = mj.regapp(param)

            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 1) Then
                MsgBox(jsonObject("msg"))
                Exit Sub
            End If

            If (jsonObject("status")("code") = 0) Then
                MsgBox(jsonObject("msg"))
                lodsipserver()
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        txtToken.Enabled = True
        BtnChecking.Enabled = True
    End Sub
End Class