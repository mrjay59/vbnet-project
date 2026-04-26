Public Class ChatUser
    Private jsonpa As New ClassJson
    Private Sub ChatUser_Click(sender As Object, e As EventArgs) Handles Me.Click

        Dim DatJson As String = idUser.Tag
        Dim DPar = jsonpa.Json2aray(DatJson)
        Dim platform = DPar("platform")
        Dim tonu = DPar("tonu")
        Dim isgroup As Boolean = DPar("isgroup")

        Dim pgMsg As pgMsg = Application.OpenForms.OfType(Of pgMsg)().FirstOrDefault()
        pgMsg.LoadetailMessages(platform, isgroup, tonu)


        For Each control As ChatUser In pgMsg.PnUser.Controls.OfType(Of ChatUser)()
            Dim itemiduser As String = control.idUser.Text

            If (itemiduser = tonu) Then
                control.BackColor = Color.Gray
            Else
                control.BackColor = Color.FromArgb(60, 70, 60)
            End If
        Next

    End Sub

    Private Sub idUser_Click(sender As Object, e As EventArgs) Handles idUser.Click
        Dim DatJson As String = idUser.Tag
        Dim DPar = jsonpa.Json2aray(DatJson)
        Dim platform = DPar("platform")
        Dim tonu = DPar("tonu")
        Dim isgroup As Boolean = DPar("isgroup")

        Dim pgMsg As pgMsg = Application.OpenForms.OfType(Of pgMsg)().FirstOrDefault()
        pgMsg.LoadetailMessages(platform, isgroup, tonu)


        For Each control As ChatUser In pgMsg.PnUser.Controls.OfType(Of ChatUser)()
            Dim itemiduser As String = control.idUser.Text

            If (itemiduser = tonu) Then
                control.BackColor = Color.Gray
            Else
                control.BackColor = Color.FromArgb(60, 70, 60)
            End If
        Next
    End Sub


End Class
