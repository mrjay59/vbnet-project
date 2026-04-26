Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class UConnectDevice
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
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

    Private Sub UConnectDevice_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim width = Me.Width
        Dim Height = Me.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 5 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)
    End Sub

    Private Sub BtnCon_Click(sender As Object, e As EventArgs) Handles BtnCon.Click
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\LocAn\"

        Dim DatTag = jsonpa.Json2aray(lbname.Tag.ToString.Trim)
        Dim dataseri = DatTag("serial")
        Dim connTipe = lbstatus.Tag.ToString.Trim
        Dim btnC = BtnCon.Tag
        Dim winheader = lbname.Text.ToString.Trim
        Dim filePath = FoldeQ & $"{dataseri}.json"
        Dim b As String = String.Empty
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If File.Exists(filePath) Then
            b = File.ReadAllText(filePath)
        End If

        Dim param As New Dictionary(Of String, String)
        param.Add("serial", dataseri)
        param.Add("Token", DatTag("Token"))
        param.Add("username", DatTag("username"))
        param.Add("tipe", "cekActive")


        If (btnC = "Setup") Then
            BtnCon.Image = My.Resources.icons8_setup_25

            If (connTipe = "Termux") Then
                Dim response = Ap_mrjay59.dev_state(param)

                Dim jsonObject = JsonConvert.DeserializeObject(response)

                If (jsonObject("status")("code") = 0) Then
                    If Not File.Exists(filePath) Then
                        Dim ad = IO.File.Create(filePath)
                        ad.Close()
                        ad.Dispose()

                        Dim DatAndroid = jsonObject("apk_list").ToString

                        ' Write the JSON string back to the file
                        IO.File.WriteAllText(filePath, DatAndroid)

                        MsgBox(jsonObject("msg"))
                    End If



                End If

            ElseIf (connTipe = "USB")
                If Not File.Exists(filePath) Then
                    Dim ad = IO.File.Create(filePath)
                    ad.Close()
                    ad.Dispose()

                    Dim newdata As New JObject
                    newdata.Add("name", winheader)
                    newdata.Add("idev", dataseri)
                    newdata.Add("ipdev", "")
                    newdata.Add("connection", connTipe)
                    newdata.Add("config", "")
                    newdata.Add("scrcpy", "--serial={serial} --window-title={winheader} ")
                    newdata.Add("texture", "")
                    newdata.Add("usedev", False)
                    newdata.Add("apk", New JObject)

                    ' Write the JSON string back to the file
                    IO.File.WriteAllText(filePath, newdata.ToString)

                    Dim DataParam As New Dictionary(Of String, String)
                    DataParam.Add("DataDevice", newdata.ToString)
                    DataParam.Add("PathDevice", filePath)
                    DataParam.Add("username", DatTag("username").ToString)
                    Dim PageSetup As New frmSetupDev
                    PageSetup.lbltext.Text = "Setup Device " & winheader
                    PageSetup.RecData(DataParam)
                    PageSetup.ShowDialog()
                End If
            End If

        ElseIf (btnC = "Connect") Then
            Dim pathData = lbname.Tag.ToString.Trim
            b = File.ReadAllText(pathData)
            Dim J2Obj = jsonpa.Json2aray(b)
            Dim namedev = J2Obj("name")
            Dim connection = IIf(J2Obj("connection") = "USB", J2Obj("idev"), J2Obj("ipdev"))
            Dim scrcpy = J2Obj("scrcpy").ToString.Replace("{serial}", connection.ToString).Replace("{winheader}", namedev.ToString & "-" & J2Obj("connection"))
            Dim config = J2Obj("config")
            J2Obj("usedev") = True
            BtnCon.Tag = "DisConnect"
            BtnCon.Image = My.Resources.icons8_disconnected_25
            BtnCon.BackColor = Color.FromArgb(61, 81, 161)
            Dim idev = IIf(J2Obj("connection") = "USB", J2Obj("idev"), IIf(J2Obj("connection") = "WIFI", J2Obj("ipdev"), ""))
            Dim Conn = J2Obj("connection")

            Dim devapk As New ClassApk(idev, Conn)
            devapk.OpenScrcpy(scrcpy & config)



            IO.File.WriteAllText(pathData, J2Obj.ToString)
            Timer1.Enabled = True
        ElseIf (btnC = "DisConnect") Then
            BtnCon.BackColor = Color.FromArgb(80, 80, 160)
            Dim DatDevice = jsonpa.Json2aray(b)
            Dim NameDev = DatDevice("name")
            Dim ConOption = DatDevice("connection")
            Dim WinTitle = NameDev & "-" & ConOption

            Dim cekprocces = Process.GetProcessesByName("scrcpy")
            For Each p In cekprocces
                Dim maintitle = p.MainWindowTitle.ToString
                If (WinTitle = maintitle) Then
                    p.CloseMainWindow()
                    p.Close()

                    BtnCon.Image = My.Resources.icons8_connected_25
                    BtnCon.Tag = "Connect"
                End If

            Next

            Timer1.Enabled = False
        End If
    End Sub

    Private Sub BtnCon_Paint(sender As Object, e As PaintEventArgs) Handles BtnCon.Paint
        Dim width = BtnCon.Width
        Dim Height = BtnCon.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnCon.Region = New Region(path)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim cekprocces = Process.GetProcessesByName("scrcpy")
        Dim pathData = lbname.Tag.ToString.Trim
        If (File.Exists(pathData)) Then
            Dim b = File.ReadAllText(pathData)

            Dim J2Obj = jsonpa.Json2aray(b)
            Dim namedev = J2Obj("name")
            Dim ConOption = J2Obj("connection")
            Dim connection = IIf(J2Obj("connection") = "USB", J2Obj("idev"), J2Obj("ipdev"))
            Dim WinTitle = namedev & "-" & ConOption

            If (cekprocces.Length = 0) Then
                'IO.File.Delete(file)
                BtnCon.Tag = "Connect"

                J2Obj("usedev") = False

                IO.File.WriteAllText(pathData, J2Obj.ToString)
            Else
                For Each p In cekprocces
                    Dim maintitle = p.MainWindowTitle.ToString
                    If (WinTitle = maintitle) Then
                        BtnCon.Tag = "DisConnect"
                    End If
                Next
            End If

        End If

    End Sub

    Private Sub BtnSetup_Click(sender As Object, e As EventArgs) Handles BtnSetup.Click
        Dim filePath = lbname.Tag.Trim
        Dim nameDev = lbname.Text.Trim
        Dim username = lbstatus.Tag
        Dim b As String = File.ReadAllText(filePath)
        Dim DataParam As New Dictionary(Of String, String)
        DataParam.Add("DataDevice", b)
        DataParam.Add("PathDevice", filePath)
        DataParam.Add("username", username)
        Dim PageSetup As New frmSetupDev
        PageSetup.lbltext.Text = "Setup Device " & nameDev
        PageSetup.RecData(DataParam)
        PageSetup.ShowDialog()

    End Sub

    Private Sub lbstatus_Click(sender As Object, e As EventArgs) Handles lbstatus.Click

    End Sub

    Private Sub lbstatus_Paint(sender As Object, e As PaintEventArgs) Handles lbstatus.Paint
        Dim width = lbstatus.Width
        Dim Height = lbstatus.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 5 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        lbstatus.Region = New Region(path)
    End Sub


End Class
