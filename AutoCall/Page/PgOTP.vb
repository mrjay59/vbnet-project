Public Class PgOTP

    Private DatR As String = String.Empty
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

    Private Sub kode1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kode1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub kode2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kode2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub kode3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kode3.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub kode4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kode4.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub kode5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kode5.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub kode6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles kode6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub kode1_TextChanged(sender As Object, e As EventArgs) Handles kode1.TextChanged
        If (kode1.Text.Length = 1) Then
            kode2.Focus()
        End If
    End Sub

    Private Sub kode2_TextChanged(sender As Object, e As EventArgs) Handles kode2.TextChanged
        If (kode2.Text.Length = 1) Then
            kode3.Focus()
        End If
    End Sub

    Private Sub kode3_TextChanged(sender As Object, e As EventArgs) Handles kode3.TextChanged
        If (kode3.Text.Length = 1) Then
            kode4.Focus()
        End If
    End Sub

    Private Sub kode4_TextChanged(sender As Object, e As EventArgs) Handles kode4.TextChanged
        If (kode4.Text.Length = 1) Then
            kode5.Focus()
        End If
    End Sub

    Private Sub kode5_TextChanged(sender As Object, e As EventArgs) Handles kode5.TextChanged
        If (kode5.Text.Length = 1) Then
            kode6.Focus()
        End If
    End Sub


End Class