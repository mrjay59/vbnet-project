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
                Dim limit_perday As Integer = item("limit_perday")
                Dim limit_pernumber As Integer = item("limit_recall")

                Dim Datitem = jsonpa.Json2aray(listapp)
                Dim applist = Datitem("apk")
                Dim approp As IEnumerable(Of JProperty) = applist.Properties()
                ax = ax + 1
                For Each prop As JProperty In approp
                    Dim appname = prop.Name
                Next

                Dim row As String() = New String() {ax, akunid, concurrent, date_exp, limit_perday, limit_pernumber, idle}
                ViewTabel0.Rows.Add(row)

            Next

        End If
    End Sub

    Private Sub frmAddSIP_Load(sender As Object, e As EventArgs) Handles Me.Load
        lodsipserver()
    End Sub

    Private Sub BtnChecking_Click(sender As Object, e As EventArgs) Handles BtnChecking.Click
        Dim TokenIn = txtToken.Text.Trim

    End Sub
End Class