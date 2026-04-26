Imports Newtonsoft.Json.Linq

Public Class AddataServer
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

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    'Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
    '    Dim DatJson As New JObject
    '    Dim Json2 As New JObject
    '    Dim Json3 As New JObject
    '    Dim Jarr As New JArray
    '    Json3.Add("idsender", "")
    '    Json3.Add("nasender", "")
    '    Json3.Add("tglbuat", "")
    '    Json3.Add("tglexp", "")
    '    Json3.Add("numkey", "")
    '    Json3.Add("apikey", "")
    '    Json3.Add("service", "") 'OPEN CLOSE
    '    Json3.Add("subscribe", False)
    '    Json3.Add("use", False)
    '    Jarr.Add(Json3)
    '    Json2.Add("totuse", 0)
    '    Json2.Add("maxuse", 0)
    '    Json2.Add("state", "")
    '    Json2.Add("listreg", Jarr)
    '    If (ChkWAServer.Checked) Then
    '        DatJson.Add("waserver", Json2)
    '    End If

    '    If (ChkWAScanQr.Checked) Then
    '        DatJson.Add("wascanqr", Json2)
    '    End If

    '    If (ChkWAFwd.Checked) Then
    '        DatJson.Add("waforward", Json2)
    '    End If

    '    If (ChkSmsServer.Checked) Then
    '        DatJson.Add("smsserver", Json2)
    '    End If

    '    If (ChkEmailServer.Checked) Then
    '        DatJson.Add("emailserver", Json2)
    '    End If

    '    If (ChkSipServer.Checked) Then
    '        DatJson.Add("sipserver", Json2)
    '    End If

    '    Console.WriteLine(DatJson.ToString)
    'End Sub


    Private Sub BtnValidasi_Click(sender As Object, e As EventArgs) Handles BtnValidasi.Click
        Dim kodeRe As String = kode1.Text.Trim & kode2.Text.Trim & kode3.Text.Trim & kode4.Text.Trim & kode5.Text.Trim & kode6.Text.Trim


    End Sub
End Class