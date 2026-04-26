Public Class local_device
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
        Dim page As New add_device
        page.SendDataUser = DatR
        page.ShowDialog()
    End Sub

    Private Sub local_device_Load(sender As Object, e As EventArgs) Handles Me.Load

        PanelPusat.Controls.Clear()
        DataAndroid()
    End Sub

    Private Sub DataAndroid()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\LocAn\"

        Dim a = 0
        Dim b = -1
        Dim Dconnect As UConnectDevice

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", "LocAn")

        Dim response = mj.getAkunAkses(param)
        Dim resp2arr = jsonpa.Json2aray(response)

        If (resp2arr("status")("code") = 0) Then
            For Each item In resp2arr("body")
                b = b + 1
                Dim contion = item("apk_platform").ToString
                Dim state = item("apk_state").ToString
                Dim devname = item("apk_deviceinfo").ToString
                Dim devArr = jsonpa.Json2aray(devname)

                Dim serialN = devArr("serial").ToString
                Dim filePath = FoldeQ & $"{serialN}.json"
                Dim nameD = devArr("device_name").ToString & "-" & serialN
                Dconnect = New UConnectDevice
                Dconnect.lblnum.Text = b + 1
                Dconnect.lbname.Tag = filePath
                Dconnect.lbname.Text = nameD

                Dconnect.BtnCon.Image = My.Resources.icons8_connected_25
                Dconnect.BtnCon.Tag = "Connect"
                Dconnect.lbstatus.Tag = username

                If (contion = "USB") Or (contion = "NETWORK") Then
                    Dconnect.BtnCon.Visible = True
                Else
                    Dconnect.BtnCon.Visible = False
                End If
                Dim pin As Point
                pin = New Point(6, 60 * b + 6)
                Dconnect.Location = pin

                If (state = "online") Then
                    Dconnect.lbstatus.Text = "Connect via " & contion
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 160)
                    Dconnect.BackColor = Color.FromArgb(80, 180, 60)
                Else
                    Dconnect.lbstatus.Text = "Offline"
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 60)
                    Dconnect.BackColor = Color.FromArgb(60, 80, 60)
                End If


                PanelPusat.Controls.Add(Dconnect)
            Next
        End If






    End Sub

End Class