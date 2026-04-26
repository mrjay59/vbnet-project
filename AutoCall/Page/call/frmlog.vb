Public Class frmlog

    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect

    Public Sub DataIn(ByVal Data As Dictionary(Of String, String))
        Dim namCaller = Data.Item("namCaller")
        Dim DataJson = Data.Item("DataJson")
        lbltext.Text = "Log Call WhatsApp " & namCaller
        Dim logParse = jsonpa.Json2aray(DataJson)
        Dim a = 0
        For Each item In logParse(namCaller)
            a = a + 1
            Dim tos As String = item("to").ToString
            Dim from As String = item("from").ToString
            Dim platform As String = item("platform").ToString
            Dim text As String = item("text").ToString
            Dim toMg As Integer = item("result")("MG")
            Dim toBr As Integer = item("result")("BR")
            Dim toAn As Integer = item("result")("AN")
            Dim recall As Integer = item("recall")
            Dim tocall As Integer = item("tocall")


            Dim row As String() = New String() {a, tos, from, platform, toMg, toBr, toAn, text, recall, tocall}
            ViewTabel.Rows.Add(row)
        Next

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub


End Class