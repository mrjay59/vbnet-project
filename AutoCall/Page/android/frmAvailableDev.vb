Imports System.IO


Public Class frmAvailableDev
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private adb As New adb
    Private Sub frmAvailableDev_Load(sender As Object, e As EventArgs) Handles Me.Load

        listDevices()

    End Sub

    Private Sub listDevices()
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\LocAn\"

        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        Dim files As String() = IO.Directory.GetFiles(fodev)


        Dim arrdev As New ArrayList
        If (files.Count > 0) Then
            For Each filex As String In files
                Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
                arrdev.Add(nameFile)
            Next
        End If


        Dim DDevice As List(Of DeviceInfo) = adb.ListDevice().ToList

        Dim Dconnect As UConnectDevice
        Dim b = 0
        If (DDevice.Count > 0) Then

            For Each strLine In DDevice
                Dim idev = strLine.Serial
                Dim idmod = strLine.Model

                Dim wintitle = idmod & "-" & idev


                If Not (arrdev.Contains(idev)) Then
                    b = b + 1
                    Dim c = b - 1
                    Dconnect = New UConnectDevice
                    Dconnect.lblnum.Text = b
                    Dconnect.lbname.Tag = idev
                    Dconnect.lbname.Text = wintitle
                    Dconnect.Location = New Point(60 * c + 1, 1)
                    Dconnect.BtnSetup.Visible = False
                    Dconnect.lbstatus.Text = "New Devices"
                    Dconnect.lbstatus.Tag = "USB"
                    PanelPusat.Controls.Add(Dconnect)
                End If
            Next
        End If






    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        listDevices()
    End Sub
End Class