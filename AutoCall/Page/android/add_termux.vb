Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class add_termux

    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private adb As New adb
    Private DatR As String = String.Empty
    Private DataDevice = String.Empty
    Private PathDevice = String.Empty
    Private PathAdb As String = Application.StartupPath & "\Scrcpy\adb.exe"

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles BtnCopy.Click
        ' Salin teks label ke clipboard
        Clipboard.SetText(lbltext1.Text)

        MessageBox.Show("Teks berhasil disalin!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnEnableport_Click(sender As Object, e As EventArgs) Handles btnEnableport.Click
        Dim Adport = Eport.Text.Trim

        Dim DDevice As List(Of DeviceInfo) = adb.ListDevice().ToList

        Dim b = 0
        If (DDevice.Count > 0) Then
            For Each strLine In DDevice
                Dim idev = strLine.Serial
                Dim idmod = strLine.Model

                dbConn.OpenCmd(PathAdb, $"-s {idev} tcpip {Adport}", "N")
            Next


            MessageBox.Show("restarting in TCP mode port: 5555 Lanjut Ke applikasi Termux", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub BtnChecking_Click(sender As Object, e As EventArgs) Handles BtnChecking.Click
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim SnNoAndro = txtNoseri.Text.Trim

        Dim param As New Dictionary(Of String, String)
        param.Add("serial", SnNoAndro)
        param.Add("username", username)
        param.Add("tipe", "cekSerial")

        If (SnNoAndro = "") Then
            MsgBox("Data serial Kosong/blank")
            Exit Sub
        End If
        Try
            Dim response = Ap_mrjay59.dev_state(param)


            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 0) Then


                Dim msg = jsonObject("msg").ToString
                Dim act As Boolean = jsonObject("active")

                If (act) Then
                    BtnChecking.Enabled = False
                    txtNoseri.Enabled = False
                    txtToken.Enabled = True
                End If
                MsgBox(msg)
            Else
                MsgBox(jsonObject("msg").ToString)
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub btnverify_Click(sender As Object, e As EventArgs) Handles btnverify.Click
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim TokenAndro = txtToken.Text.Trim
        Dim SnNoAndro = txtNoseri.Text.Trim

        If (TokenAndro = "") Then
            MsgBox("Token Masih kosong /belum diinput")
            Exit Sub
        End If
        Dim param As New Dictionary(Of String, String)
        param.Add("serial", SnNoAndro)
        param.Add("username", username)
        param.Add("Token", TokenAndro)
        param.Add("tipe", "cekToken")

        Try
            Dim response = Ap_mrjay59.dev_state(param)

            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 0) Then

                txtNoseri.Enabled = False
                txtToken.Enabled = False
                listDevLocal(response)
                MsgBox("Silahkan Add perangkat klik setup ")
                btnverify.Enabled = False
            End If
        Catch ex As Exception

        End Try

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

        Dim username = DPar("data")("username")
        Dim Token = DPar("data")("Token")
        Dim idev = DPar("data")("serial")
        Dim idmod = DPar("data")("devinfo").ToString
        Dim listj = jsonpa.Json2aray(idmod)
        Dim brand = listj("brand")
        Dim model = listj("model")

        Dim wintitle = brand & "-" & model & "-" & idev
        Dim datTag As New JObject
        datTag.Add("username", username)
        datTag.Add("serial", idev)
        datTag.Add("Token", Token)

        If Not (arrdev.Contains(idev)) Then

            Dconnect = New UConnectDevice
            Dconnect.Width = 300
            Dconnect.Height = 50
            Dconnect.Dock = DockStyle.Top
            Dconnect.lbname.Tag = datTag.ToString
            Dconnect.lbname.Text = wintitle
            Dconnect.BtnSetup.Visible = False
            Dconnect.lbstatus.Text = "New Devices"
            Dconnect.lbstatus.Tag = "Termux"
            Dconnect.BtnCon.Image = My.Resources.icons8_plus_30


            PanelPusat.Controls.Add(Dconnect)
        End If

    End Sub

    Private Sub Label21_Click(sender As Object, e As EventArgs) Handles Label21.Click
        txtNoseri.Enabled = True
        BtnChecking.Enabled = True
    End Sub


End Class