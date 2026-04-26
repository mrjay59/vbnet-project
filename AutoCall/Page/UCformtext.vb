Public Class UCformtext
    Private Sub Btneyes_Click(sender As Object, e As EventArgs) Handles Btneyes.Click
        If (txtinput.Tag = "N") Then
            txtinput.Tag = "Y"
            txtinput.PasswordChar = ""
        Else
            txtinput.PasswordChar = "*"
            txtinput.Tag = "N"
        End If
    End Sub
End Class
