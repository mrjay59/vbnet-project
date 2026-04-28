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
    End Sub

    Private Sub BtnChecking_Click(sender As Object, e As EventArgs) Handles BtnChecking.Click
        Dim TokenIn = txtToken.Text.Trim

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


End Class