Public Class add_device
    Private DatR As String = String.Empty

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub rd0_CheckedChanged(sender As Object, e As EventArgs) Handles rd0.CheckedChanged

        PanelPusat.Controls.Clear()
        Try
            Dim page As New add_usb
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub rd1_CheckedChanged(sender As Object, e As EventArgs) Handles rd1.CheckedChanged
        PanelPusat.Controls.Clear()
        Try
            Dim page As New add_network
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        PanelPusat.Controls.Clear()
        Try
            Dim page As New add_termux
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DatR
            PanelPusat.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class