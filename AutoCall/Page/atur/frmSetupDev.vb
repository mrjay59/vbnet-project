Imports System.Drawing.Drawing2D
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Public Class frmSetupDev
    Private mj As New mrjay59
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private adb As New adb
    Private DataDevice = String.Empty
    Private PathDevice = String.Empty
    Private username = String.Empty
    Private PathAdb As String = Application.StartupPath & "\Scrcpy\adb.exe"
    Public Sub RecData(ByVal Data As Dictionary(Of String, String))
        DataDevice = Data.Item("DataDevice")
        PathDevice = Data.Item("PathDevice")
        username = Data.Item("username")
        Dim J2Object = jsonpa.Json2aray(DataDevice)

        Dim NameDev As String = J2Object("name")
        Dim idev = IIf(J2Object("connection") = "USB", J2Object("idev"), IIf(J2Object("connection") = "NETWORK", J2Object("ipdev"), ""))
        Dim Conn = J2Object("connection")
        Dim confg = J2Object("config").ToString
        adb.Connect(idev, Conn)
        txtusbname.txtinput.Text = NameDev
        txtusbserial.txtinput.Text = J2Object("idev")

        ' Write the JSON string back to the file
        ' IO.File.WriteAllText(PathDevice, DataDevice)


        Dim ConUSB As Boolean = IIf(J2Object("connection").ToString.ToUpper = "USB", True, False)
        Dim ConWIFI As Boolean = IIf(J2Object("connection").ToString.ToUpper = "WIFI", True, False)
        Dim ConTemux As Boolean = IIf(J2Object("connection").ToString.ToUpper = "TERMUX", True, False)
        Dim AOT0 As Boolean = IIf(confg.Contains("--always-on-top"), True, False)
        Dim STA0 As Boolean = IIf(confg.Contains("--stay-awake"), True, False)
        Dim TSO0 As Boolean = IIf(confg.Contains("--turn-screen-off"), True, False)
        Dim bitra, maxsize As String
        If Not (confg = "") Then
            maxsize = confg.Substring(InStr(confg, " --max-size=") + 11, 4)
            bitra = confg.Substring(InStr(confg, " --video-bit-rate=") + 17, 3)
            Dim bitrx As String = Regex.Replace(bitra, "[^0-9]", "")
            Dim Spda As String = IIf(bitra.Trim.Contains("M"), "Mbps", "Kbps")

            figSize.SelectedItem = maxsize.Trim
            txtbitR.Text = bitrx
            Ukur.SelectedItem = Spda
        End If


        aot.Checked = AOT0
        sta.Checked = STA0
        tso.Checked = TSO0
        RUsb.Checked = ConUSB
        RWifi.Checked = ConWIFI
        termux.Checked = ConTemux

        Dim serialdev = IIf(J2Object("connection") = "USB", J2Object("idev"), IIf(J2Object("connection") = "NETWORK", J2Object("ipdev"), ""))
        Dim ipv4 As String = String.Empty
        Dim ipv4x As String() = J2Object("ipdev").ToString.Split(":")
        If (ConUSB = True) Then
            ipv4 = adb.IpDevices
        Else
            ipv4 = ipv4x(0)
        End If


        txtusbname.Lblname.Text = "Change Name Device"
        txtusbname.txtinput.ReadOnly = False

        txtusbserial.Enabled = False
        txtusbserial.Lblname.Text = "Serial Device"

        txtwifIp.Lblname.Text = "Ip Addreas Device"
        txtwifPort.Lblname.Text = "Port Device"

        txtwifIp.txtinput.Enabled = False
        txtwifPort.txtinput.Enabled = False

        txtwifPort.txtinput.Text = 5555
        txtwifIp.txtinput.Text = ipv4

        Dim applist = J2Object("apk")
        Dim approp As IEnumerable(Of JProperty) = applist.Properties()
        Dim a = 0
        For Each prop As JProperty In approp
            Dim appname = prop.Name

            For Each item In applist(appname)
                If (appname = "whatsappmessage") Then
                    Dim ValuWAOC As Integer = item("limit_perday")("call")
                    Dim ValuWAOReC As Integer = item("limit_maxspam")("call")
                    Dim ValuWAOM As Integer = item("limit_perday")("message")
                    Dim ValuWAOReM As Integer = item("limit_maxspam")("message")
                    WAO_Caller.Value = ValuWAOC
                    WAO_Caller_recall.Value = ValuWAOReC
                    WAO_Message.Value = ValuWAOM
                    WAO_Message_mspam.Value = ValuWAOReM
                    WAO_Caller.Tag = appname
                    WAO_Message.Tag = appname

                    Label10.Tag = a
                    Label15.Tag = a
                ElseIf (appname = "whatsappbusiness") Then
                    Dim ValuWABC As Integer = item("limit_perday")("call")
                    Dim ValuWABReC As Integer = item("limit_maxspam")("call")
                    Dim ValuWABM As Integer = item("limit_perday")("message")
                    Dim ValuWABReM As Integer = item("limit_maxspam")("message")
                    WAB_Caller.Value = ValuWABC
                    WAB_Caller_recall.Value = ValuWABReC
                    WAB_Message.Value = ValuWABM
                    WAB_Message_mspam.Value = ValuWABReM
                    WAB_Caller.Tag = appname
                    WAB_Message.Tag = appname

                    Label11.Tag = a
                    Label14.Tag = a

                ElseIf (appname = "telponselular") Then
                    Dim ValuWAOC As Integer = item("limit_perday")("call")
                    Dim ValuWAOReC As Integer = item("limit_maxspam")("call")

                    TLC_Caller.Value = ValuWAOC
                    TLC_Caller_recall.Value = ValuWAOReC
                    TLC_Caller.Tag = appname
                    Label12.Tag = a


                ElseIf (appname = "sms") Then
                    Dim ValuWAOC As Integer = item("limit_perday")("message")
                    Dim ValuWAOCReM As Integer = item("limit_maxspam")("message")
                    SMS.Value = ValuWAOC
                    SMS_mspam.Value = ValuWAOCReM
                    SMS.Tag = appname

                    Label13.Tag = a
                End If


            Next
            a = a + 1
        Next





        Dim liDev As List(Of DeviceInfo) = adb.ListDevice().ToList
        'For Each strLine In liDev
        '    If (strLine.Contains(ipv4)) Then
        '        lbstatus.Text = "Online"
        '    End If
        'Next



    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click

        Dim namedev = txtusbname.txtinput.Text

        If (namedev = "") Then
            MsgBox("Nama Device Masih blank/kosong")
            Exit Sub
        End If

        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        J2Obj("name") = namedev

        ' Write the JSON string back to the file
        IO.File.WriteAllText(PathDevice, J2Obj.ToString)
        DataDevice = J2Obj.ToString
        MsgBox("Sudah disimpan")
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        Dim ipdev = txtwifIp.txtinput.Text
        Dim prdev = txtwifPort.txtinput.Text
        Dim ipad = $"{ipdev}:{prdev}"
        Dim serdev = txtusbserial.txtinput.Text
        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        J2Obj("ipdev") = ipad

        ' Write the JSON string back to the file
        IO.File.WriteAllText(PathDevice, J2Obj.ToString)

        dbConn.OpenCmd(PathAdb, $"-s {serdev} tcpip {prdev}", "N")
        'Threading.Thread.Sleep(1000)
        dbConn.OpenCmd(PathAdb, $"-s {serdev} connect {ipad}", "N")

        DataDevice = J2Obj.ToString
        MsgBox("Sudah disimpan")
    End Sub

    Private Sub Btn6_Click(sender As Object, e As EventArgs) Handles Btn6.Click
        Dim ipdev = txtwifIp.txtinput.Text
        Dim prdev = txtwifPort.txtinput.Text
        Dim idev = txtusbserial.txtinput.Text

        Dim ac = String.Empty
        If (RUsb.Checked) Then
            ac = "USB"
        ElseIf (RWifi.Checked) Then
            ac = "WIFI"
        ElseIf (termux.Checked) Then
            ac = "TERMUX"
        Else
            MsgBox("Pilih Dulu Connection apa")
            Exit Sub
        End If



        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        J2Obj("connection") = ac

        Dim ipdevx = J2Obj("ipdev").ToString
        ' Write the JSON string back to the file
        IO.File.WriteAllText(PathDevice, J2Obj.ToString)
        DataDevice = J2Obj.ToString
        Threading.Thread.Sleep(1000)
        'adb.StartAdbCommand($"disconnect {ipdevx}")
        ' dbConn.OpenCmd(PathAdb, $"-s {idev} disconnect {ipdevx}", "N")
        MsgBox("Sudah disimpan")
    End Sub

    Private Sub Btn3_Click(sender As Object, e As EventArgs) Handles Btn3.Click
        Dim maxsize As String = figSize.Text.Trim
        Dim ukr = Ukur.Text.Trim.ToString.Replace("bps", "")
        Dim bitrate As String = txtbitR.Text.Trim & ukr
        Dim config = String.Empty
        If (aot.Checked) Then
            config = aot.Text & " "
        End If
        If (tso.Checked) Then
            config += tso.Text & " "
        End If
        If (sta.Checked) Then
            config += sta.Text & " "
        End If

        If Not (bitrate = "") Then
            config += $"--video-bit-rate={bitrate} "
        End If

        If Not (maxsize = "") Then
            config += $"--max-size={maxsize} "
        End If

        Dim J2Obj = jsonpa.Json2aray(DataDevice)

        J2Obj("config") = config

        ' Write the JSON string back to the file
        IO.File.WriteAllText(PathDevice, J2Obj.ToString)
        DataDevice = J2Obj.ToString
        MsgBox("Sudah disimpan")
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        Dim J2Object = jsonpa.Json2aray(DataDevice)
        Dim nameDev As String = J2Object("name")
        Dim seriDev As String = J2Object("idev")
        Dim scrpy As String = J2Object("scrcpy").ToString.Replace("{serial}", seriDev).Replace("{winheader}", nameDev)
        Dim config As String = J2Object("config")
        Dim idev = IIf(J2Object("connection") = "USB", J2Object("idev"), IIf(J2Object("connection") = "WIFI", J2Object("ipdev"), ""))
        Dim Conn = J2Object("connection")

        Dim devapk As New ClassApk(idev, Conn)
        devapk.OpenScrcpy(scrpy & config)
    End Sub

    'Private Sub Btn5_Click(sender As Object, e As EventArgs) Handles Btn5.Click
    '    Dim J2Object = jsonpa.Json2aray(DataDevice)
    '    Dim nameDev As String = J2Object("name")
    '    Dim seriDev As String = J2Object("ipdev")
    '    Dim scrpy As String = J2Object("scrcpy").ToString.Replace("{serial}", seriDev).Replace("{winheader}", nameDev.ToString & "-" & J2Object("connection"))
    '    Dim config As String = J2Object("config")
    '    Dim idev = IIf(J2Object("connection") = "USB", J2Object("idev"), IIf(J2Object("connection") = "WIFI", J2Object("ipdev"), ""))
    '    Dim Conn = J2Object("connection")

    '    Dim devapk As New ClassApk(idev, Conn)
    '    devapk.OpenScrcpy(scrpy & config)
    'End Sub

    Private Sub BtnRestar_Click(sender As Object, e As EventArgs) Handles BtnRestar.Click

        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        Dim idev = IIf(J2Obj("connection") = "USB", J2Obj("idev"), IIf(J2Obj("connection") = "WIFI", J2Obj("ipdev"), ""))
        Dim Conn = J2Obj("connection")
        Dim config = J2Obj("config").ToString

        Dim devapk As New ClassApk(idev, Conn)


        devapk.StartAdbCommand("reboot")

        MsgBox("Sedang Proses Restart")
    End Sub

    Private Sub BtnRestar_Paint(sender As Object, e As PaintEventArgs) Handles BtnRestar.Paint
        Dim width = BtnRestar.Width
        Dim Height = BtnRestar.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnRestar.Region = New Region(path)
    End Sub

    Private Sub BtnMenu_Click(sender As Object, e As EventArgs) Handles BtnMenu.Click
        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        Dim idev = IIf(J2Obj("connection") = "USB", J2Obj("idev"), IIf(J2Obj("connection") = "WIFI", J2Obj("ipdev"), ""))
        Dim Conn = J2Obj("connection")
        Dim config = J2Obj("config").ToString

        Dim devapk As New ClassApk(idev, Conn)
        ' devapk.SendKeyEvent("KEYCODE_MENU")
    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles BtnHome.Click
        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        Dim idev = IIf(J2Obj("connection") = "USB", J2Obj("idev"), IIf(J2Obj("connection") = "WIFI", J2Obj("ipdev"), ""))
        Dim Conn = J2Obj("connection")
        Dim config = J2Obj("config").ToString

        Dim devapk As New ClassApk(idev, Conn)
        'devapk.HomeBtn()

    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles BtnBack.Click
        Dim J2Obj = jsonpa.Json2aray(DataDevice)
        Dim idev = IIf(J2Obj("connection") = "USB", J2Obj("idev"), IIf(J2Obj("connection") = "WIFI", J2Obj("ipdev"), ""))
        Dim Conn = J2Obj("connection")
        Dim config = J2Obj("config").ToString

        Dim devapk As New ClassApk(idev, Conn)
        '  devapk.BackBtn()
    End Sub

    Private Sub BtnLimitCall_Click(sender As Object, e As EventArgs) Handles BtnLimitCall.Click
        Dim WAO_call As Integer = WAO_Caller.Value
        Dim WAB_call As Integer = WAB_Caller.Value
        Dim TLC_call As Integer = TLC_Caller.Value

        Dim WAO_mcall As Integer = WAO_Caller_recall.Value
        Dim WAB_mcall As Integer = WAB_Caller_recall.Value
        Dim TLC_mcall As Integer = TLC_Caller_recall.Value

        Dim WAO_tag = WAO_Caller.Tag.ToString
        Dim WAB_tag = WAB_Caller.Tag.ToString
        Dim TLC_tag = TLC_Caller.Tag.ToString

        Dim WAO_inde As Integer = Label10.Tag
        Dim WAB_inde As Integer = Label11.Tag
        Dim TLC_inde As Integer = Label12.Tag

        Dim serial = txtusbserial.txtinput.Text.Trim
        Dim J2Obj = jsonpa.Json2aray(DataDevice)

        Dim applist = J2Obj("apk")
        Dim approp As IEnumerable(Of JProperty) = applist.Properties()


        For Each prop As JProperty In approp
            Dim appname = prop.Name

            For Each item In applist(appname)
                If (appname = WAO_tag) Then
                    item("limit_perday")("call") = WAO_call
                    item("limit_maxspam")("call") = WAO_mcall
                ElseIf (appname = WAB_tag) Then
                    item("limit_perday")("call") = WAB_call
                    item("limit_maxspam")("call") = WAB_mcall
                ElseIf (appname = TLC_tag) Then
                    item("limit_perday")("call") = TLC_call
                    item("limit_maxspam")("call") = TLC_mcall
                End If
            Next
        Next

        ' Write the JSON string back to the file
        IO.File.WriteAllText(PathDevice, J2Obj.ToString)
        DataDevice = J2Obj.ToString

        'simpan ke server
        Dim param As New JObject
        param.Add("username", username)
        param.Add("data", J2Obj.ToString)
        param.Add("serial", serial)


        Dim response = mj.regapp(param)

        MsgBox("Sudah disimpan")

    End Sub

    Private Sub BtnLimitMsg_Click(sender As Object, e As EventArgs) Handles BtnLimitMsg.Click

        Dim WAO_msg As Integer = WAO_Message.Value
        Dim WAB_msg As Integer = WAB_Message.Value
        Dim SMS_msg As Integer = SMS.Value

        Dim WAO_mmsg As Integer = WAO_Message_mspam.Value
        Dim WAB_mmsg As Integer = WAB_Message_mspam.Value
        Dim SMS_mmsg As Integer = SMS_mspam.Value

        Dim WAO_tag = WAO_Message.Tag.ToString
        Dim WAB_tag = WAB_Message.Tag.ToString
        Dim SMS_tag = SMS.Tag.ToString

        Dim WAO_inde As Integer = Label15.Tag
        Dim WAB_inde As Integer = Label14.Tag
        Dim TLC_inde As Integer = Label13.Tag
        Dim serial = txtusbserial.txtinput.Text.Trim
        Dim J2Obj = jsonpa.Json2aray(DataDevice)

        Dim applist = J2Obj("apk")
        Dim approp As IEnumerable(Of JProperty) = applist.Properties()


        For Each prop As JProperty In approp
            Dim appname = prop.Name

            For Each item In applist(appname)
                If (appname = WAO_tag) Then
                    item("limit_perday")("message") = WAO_msg
                    item("limit_perday")("message") = WAO_mmsg
                ElseIf (appname = WAB_tag) Then
                    item("limit_perday")("message") = WAB_msg
                    item("limit_perday")("message") = WAB_mmsg
                ElseIf (appname = SMS_tag) Then
                    item("limit_perday")("message") = SMS_msg
                    item("limit_perday")("message") = SMS_mmsg
                End If
            Next
        Next

        ' Write the JSON string back to the file
        IO.File.WriteAllText(PathDevice, J2Obj.ToString)
        DataDevice = J2Obj.ToString

        'simpan ke server
        Dim param As New JObject
        param.Add("username", username)
        param.Add("data", J2Obj.ToString)
        param.Add("serial", serial)


        Dim response = mj.regapp(param)


        MsgBox("Sudah disimpan")
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click

        ' Write the JSON string back to the file
        IO.File.Delete(PathDevice)

        'simpan 
        MsgBox("Data Android local berhasil di hapus")
    End Sub
End Class