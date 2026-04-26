Public Class cloud_device
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private mj As New mrjay59
    Private adb As New adb
    Private DatR As String = String.Empty

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click
        Dim page As New add_cloud
        page.SendDataUser = DatR
        page.ShowDialog()
    End Sub

    Private Sub cloud_device_Load(sender As Object, e As EventArgs) Handles Me.Load
        ClouldAn()
    End Sub

    Private Sub ClouldAn()
        Dim a = 0
        Dim b = -1
        Dim Dconnect As UConnectDevice

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", "cldevice")

        Dim response = mj.getAkunAkses(param)
        Dim resp2arr = jsonpa.Json2aray(response)

        If (resp2arr("status")("code") = 0) Then
            For Each item In resp2arr("body")
                b = b + 1
                Dim apk_akunid = item("akunid").ToString
                Dim apk_idle = item("idle").ToString
                Dim concurrent = item("concurrent").ToString
                Dim date_exp = item("date_exp").ToString

                Dconnect = New UConnectDevice
                Dconnect.lblnum.Text = b + 1
                Dconnect.lbname.Tag = apk_akunid
                Dconnect.lbname.Text = apk_akunid
                Dconnect.BtnCon.Visible = False
                ' Dconnect.BtnCon.Image = My.Resources.icons8_connected_25
                ' Dconnect.BtnCon.Tag = "Connect"

                Dim pin As Point
                pin = New Point(6, 60 * b + 6)
                Dconnect.Location = pin

                If (apk_idle = "idle") Then
                    Dconnect.lbstatus.Text = "state:idle, Exp:" & date_exp & ", Tot Connect: " & concurrent
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 160)
                    Dconnect.BackColor = Color.FromArgb(80, 180, 60)
                ElseIf (apk_idle = "busy") Then
                    Dconnect.lbstatus.Text = "busy, Exp:" & date_exp & ", Tot Connect: " & concurrent
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 160)
                    Dconnect.BackColor = Color.OrangeRed
                Else
                    Dconnect.lbstatus.Text = "booked, Exp:" & date_exp & ", Tot Connect: " & concurrent
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 60)
                    Dconnect.BackColor = Color.FromArgb(60, 80, 60)
                End If


                PanelPusat.Controls.Add(Dconnect)
            Next
        End If


    End Sub


End Class