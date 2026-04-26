Imports System.IO


Public Class frmListDevice

    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private adb As New adb
    Private Sub listDevices()
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\LocAn\"
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If
        Dim files As String() = IO.Directory.GetFiles(fodev)

        Dim DDevice As List(Of DeviceInfo) = adb.ListDevice().ToList
        Dim arrdev As New ArrayList
        Dim Dconnect As UConnectDevice
        Dim a = 0
        Dim b = -1

        If (DDevice.Count > 0) Then
            For Each strLine In DDevice
                Dim idev = strLine.Serial
                Dim idmod = strLine.Model
                Dim wintitle = idmod & "-" & idev
                arrdev.Add(idev)
            Next
        End If

        For Each filex As String In files
            b = b + 1
            Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
            Dim xd As String = File.ReadAllText(filex)
            Dim DatDevice = jsonpa.Json2aray(xd)
            Dim namedev = DatDevice("name")
            Dim idsndev = DatDevice("idev")
            If Not (DatDevice Is Nothing) Then
                Dim contion As String = DatDevice("connection")
                Dconnect = New UConnectDevice
                Dconnect.lblnum.Text = b + 1
                Dconnect.lbname.Tag = filex
                Dconnect.lbname.Text = namedev
                Dconnect.BtnCon.Image = My.Resources.icons8_connected_25
                Dconnect.BtnCon.Tag = "Connect"

                Dim pin As Point
                pin = New Point(6, 60 * b + 6)
                Dconnect.Location = pin

                If (arrdev.Contains(nameFile)) Then
                    Dconnect.lbstatus.Text = "Connect via " & contion
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 160)
                    Dconnect.BackColor = Color.FromArgb(80, 180, 60)

                Else
                    Dconnect.lbstatus.Text = "Offline"
                    Dconnect.BtnCon.BackColor = Color.FromArgb(80, 80, 60)
                    Dconnect.BackColor = Color.FromArgb(60, 80, 60)

                End If
                PanelPusat.Controls.Add(Dconnect)
            End If

        Next

    End Sub

    Private Sub frmListDevice_Load(sender As Object, e As EventArgs) Handles Me.Load


        listDevices()

    End Sub
End Class