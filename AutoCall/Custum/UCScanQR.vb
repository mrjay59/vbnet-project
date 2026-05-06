Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class UCScanQR
    Private Sub TxtNoWA_TextChanged(sender As Object, e As EventArgs) Handles TxtNoWA.TextChanged
        Dim txt As String = TxtNoWA.Text
        Dim angkaOnly As String = System.Text.RegularExpressions.Regex.Replace(txt, "[^0-9]", "")

        If txt <> angkaOnly Then
            Dim pos = TxtNoWA.SelectionStart
            TxtNoWA.Text = angkaOnly
            TxtNoWA.SelectionStart = pos - 1
        End If
    End Sub

    Private Sub TxtNoWA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNoWA.KeyPress
        ' hanya izinkan angka dan backspace
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub
End Class
