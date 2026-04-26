Public Class PgAturvb

    Private DatR As String = String.Empty
    Private DataJson = Nothing

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property
    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        Btn2.BackColor = Color.Transparent
        Btn1.BackColor = Color.FromArgb(90, 80, 91)
        Btn4.BackColor = Color.FromArgb(90, 80, 91)
        Btn3.BackColor = Color.FromArgb(90, 80, 91)
        Btn5.BackColor = Color.FromArgb(90, 80, 91)
        BtnSIPServer.BackColor = Color.FromArgb(90, 80, 91)

        Dim x = Btn2.Location.X
        Dim y = Btn2.Location.Y + Btn2.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn2.Width

        Try
            Dim page As New frmAddDial
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        Btn2.BackColor = Color.FromArgb(90, 80, 91)
        Btn1.BackColor = Color.FromArgb(90, 80, 91)
        Btn4.BackColor = Color.Transparent
        Btn3.BackColor = Color.FromArgb(90, 80, 91)
        Btn5.BackColor = Color.FromArgb(90, 80, 91)
        BtnSIPServer.BackColor = Color.FromArgb(90, 80, 91)


        Dim x = Btn4.Location.X
        Dim y = Btn4.Location.Y + Btn4.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn4.Width

        Try
            Dim page As New frmprofile
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        Btn2.BackColor = Color.FromArgb(90, 80, 91)
        Btn1.BackColor = Color.FromArgb(90, 80, 91)
        Btn4.BackColor = Color.FromArgb(90, 80, 91)
        Btn3.BackColor = Color.Transparent
        Btn5.BackColor = Color.FromArgb(90, 80, 91)
        BtnSIPServer.BackColor = Color.FromArgb(90, 80, 91)

        Dim x = Btn3.Location.X
        Dim y = Btn3.Location.Y + Btn3.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn3.Width

        If PanelPusat.Controls.Count > 0 Then
            Dim oldPage As PgDaServer = TryCast(PanelPusat.Controls(0), PgDaServer)
            If oldPage IsNot Nothing Then
                RemoveHandler oldPage.SendDataJson, AddressOf Form1.OnMessageSendServer
                oldPage.Dispose()
            End If
            PanelPusat.Controls.Clear()
        End If

        Try
            ' CloseAllForms()
            Dim page As New PgDaServer
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
            PanelPusat.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click
        Btn2.BackColor = Color.FromArgb(90, 80, 91)
        Btn1.BackColor = Color.Transparent
        Btn4.BackColor = Color.FromArgb(90, 80, 91)
        Btn3.BackColor = Color.FromArgb(90, 80, 91)
        Btn5.BackColor = Color.FromArgb(90, 80, 91)
        BtnSIPServer.BackColor = Color.FromArgb(90, 80, 91)

        Dim x = Btn1.Location.X
        Dim y = Btn1.Location.Y + Btn1.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn1.Width


        Try
            Dim page As New frmAddDevices
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub PgAturvb_Load(sender As Object, e As EventArgs) Handles Me.Load
        Btn2_Click(sender, e)
    End Sub

    Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
        Btn2.BackColor = Color.FromArgb(90, 80, 91)
        Btn1.BackColor = Color.FromArgb(90, 80, 91)
        Btn4.BackColor = Color.FromArgb(90, 80, 91)
        Btn3.BackColor = Color.FromArgb(90, 80, 91)
        Btn5.BackColor = Color.Transparent
        BtnSIPServer.BackColor = Color.FromArgb(90, 80, 91)

        Dim x = Btn5.Location.X
        Dim y = Btn5.Location.Y + Btn5.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn1.Width

        Try
            Dim page As New WhatsAppDesktop
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            ' page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnSIPServer_Click(sender As Object, e As EventArgs) Handles BtnSIPServer.Click
        Btn2.BackColor = Color.FromArgb(90, 80, 91)
        Btn1.BackColor = Color.FromArgb(90, 80, 91)
        Btn4.BackColor = Color.FromArgb(90, 80, 91)
        Btn3.BackColor = Color.FromArgb(90, 80, 91)
        Btn5.BackColor = Color.FromArgb(90, 80, 91)
        BtnSIPServer.BackColor = Color.Transparent


        Dim x = BtnSIPServer.Location.X
        Dim y = BtnSIPServer.Location.Y + BtnSIPServer.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnSIPServer.Width

        Try
            Dim page As New frmAddSIP
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PanelPusat.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub
End Class