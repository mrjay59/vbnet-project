Imports System.Drawing.Drawing2D
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Mysqlx.Datatypes
Imports Newtonsoft.Json.Linq

Public Class WACreateAForm
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

    Private Sub BtnAdding_Click(sender As Object, e As EventArgs) Handles BtnAdding.Click
        ProsesToken("aktifkan_akun")
    End Sub

    Private Sub txtToken_KeyDown(sender As Object, e As KeyEventArgs) Handles txtToken.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            ' tunggu paste selesai
            BeginInvoke(Sub()
                            ProsesToken("cek_Token")
                        End Sub)

            txtToken.Enabled = False

        End If
    End Sub

    Private Sub ProsesToken(tipe As String)
        Dim token = txtToken.Text.Trim()
        Dim akunid = txtAkunID.Text.Trim()
        Dim Subscribe = TxtSubscribe.Text.Trim()
        Dim platform As String = String.Empty
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        If (qwascanqr.Checked) Then
            platform = "wascanqr"
        ElseIf (qwaserver.Checked) Then
            platform = "waserver"
        Else
            MsgBox("belum dicheklist pilih dulu")
            Exit Sub
        End If

        If String.IsNullOrEmpty(token) Then Exit Sub

        Dim param As New JObject
        param.Add("username", username)
        param.Add("platform", platform)
        param.Add("data", tipe)
        param.Add("Token", token)
        param.Add("akunid", akunid)
        ' param.Add("Subscribe", Subscribe)


        Dim res = WApp.OnCreateServer(param)

        If String.IsNullOrEmpty(res) Then
            MsgBox("respon kosong/blank")
            Exit Sub
        End If

        Dim dparse = jsonpa.Json2aray(res)

        If (dparse("status")("code") = 1) Then
            MsgBox(dparse("msg"))
            Exit Sub
        End If

        If (tipe = "cek_Token") Then
            BtnAdding.Enabled = True
            txtAkunID.Text = dparse("body")("akunid").ToString
            TxtMaxWA.Text = dparse("body")("max_wa").ToString
            TxtSubscribe.Text = dparse("body")("subscribe").ToString
            TxtTglExpired.Text = dparse("body")("expired").ToString

        ElseIf (tipe = "aktifkan_akun") Then
            MsgBox(dparse("msg"))
        End If

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        txtToken.Enabled = True
        BtnAdding.Enabled = True
    End Sub
End Class