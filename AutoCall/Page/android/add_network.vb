Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class add_network
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private adb As New adb
    Private DatR As String = String.Empty
    Private DataDevice = String.Empty
    Private PathDevice = String.Empty
    Private PathAdb As String = Application.StartupPath & "\Scrcpy\adb.exe"

    Private Sub BtnScanAll_Click(sender As Object, e As EventArgs) Handles BtnScanAll.Click
        Dim sq1 As Integer = Isq1.Text.Trim
        Dim sq2 As Integer = Isq2.Text.Trim
        Dim sq3 As Integer = Isq3.Text.Trim
        Dim sq4 As Integer = Isq4.Text.Trim

        Dim sq5 As Integer = Isq5.Text.Trim
        Dim sq6 As Integer = Isq6.Text.Trim
        Dim sq7 As Integer = Isq7.Text.Trim
        Dim sq8 As Integer = Isq8.Text.Trim

        Dim adport = sqport.Text.Trim

        If (sq4 > sq8) Then

            MsgBox("Data Ip Salah harus lebih kecil yang awal")
            Exit Sub
        End If

        For i As Integer = sq4 To sq8
            Dim ipNetwork = $"{sq1}.{sq2}.{sq3}.{i}:{adport}"

            Dim resp = adb.StartAdbCommand($"connect {ipNetwork}")

            If (resp.Contains("connected")) Then
                adb.deviceId = ipNetwork
                Dim getinfo = adb.GetDeviceInfo
                Dim jgetinfo = JsonConvert.SerializeObject(getinfo, Formatting.None)

                listDevLocal(jgetinfo.ToString)
            End If
        Next


    End Sub

    Private Sub listDevLocal(datjson As String)
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

        Dim DPar = jsonpa.Json2aray(datjson)
        Dim Dconnect As UConnectDevice
        Dim b = 0


        Dim idev = DPar("serial").ToString
        Dim idmod = DPar("android").ToString
        Dim brand = DPar("brand").ToString
        Dim model = DPar("model").ToString

        Dim wintitle = brand & "-" & model


        If Not (arrdev.Contains(idev)) Then

            Dconnect = New UConnectDevice
            Dconnect.lbname.Tag = idev
            Dconnect.lbname.Text = wintitle
            Dconnect.BtnSetup.Visible = False
            Dconnect.lbstatus.Text = "New Devices"
            Dconnect.lbstatus.Tag = "Network"
            Dconnect.Location = New Point(1, 1)

            PanelPusat.Controls.Add(Dconnect)
        End If

    End Sub

    Private Sub btnEnableP_Click(sender As Object, e As EventArgs) Handles btnEnableP.Click
        Dim adport = sqport.Text.Trim


        Dim DDevice As List(Of DeviceInfo) = adb.ListDevice().ToList

        Dim b = 0
        If (DDevice.Count > 0) Then
            For Each strLine In DDevice
                Dim idev = strLine.Serial
                Dim idmod = strLine.Model

                dbConn.OpenCmd(PathAdb, $"-s {idev} tcpip {adport}", "N")
            Next


            MessageBox.Show("restarting in TCP mode port: 5555 Lanjut Ke applikasi Termux", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Isq1_TextChanged(sender As Object, e As EventArgs) Handles Isq1.TextChanged
        Isq5.Text = Isq1.Text.Trim
    End Sub

    Private Sub Isq2_TextChanged(sender As Object, e As EventArgs) Handles Isq2.TextChanged
        Isq6.Text = Isq2.Text.Trim
    End Sub

    Private Sub Isq3_TextChanged(sender As Object, e As EventArgs) Handles Isq3.TextChanged
        Isq7.Text = Isq3.Text.Trim
    End Sub
End Class