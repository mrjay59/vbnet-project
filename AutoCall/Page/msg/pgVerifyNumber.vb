Public Class pgVerifyNumber

    Public Event DataSelected As EventHandler(Of ClassData)
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private DataJson = Nothing
    Public Event SendDataJson As EventHandler(Of ClassData)


    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property


    Private Sub InData(ByVal DataNumber As String)
        Dim arnum As New ArrayList
        Dim number As String = String.Empty
        For Each strLine As String In DataNumber.Split(vbNewLine)
            Dim strnum = Trim(strLine.Trim).Replace("-", "")
            If Not (strnum = "") Then
                Dim nol As Integer = strnum.Substring(0, 1)
                Dim endua As Integer = strnum.Substring(0, 2)
                If (nol = 0) Then
                    number = strLine.Trim.ToString.Substring(1)
                ElseIf (endua = 62) Then
                    number = strLine.Trim.ToString.Substring(2)
                Else
                    number = strLine
                End If

                arnum.Add(number)
            End If
        Next



    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

    End Sub

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        Dim DataNumber = Clipboard.GetText().TrimEnd.Replace("+", "")


        InData(DataNumber)
    End Sub
End Class