Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq

Public Class UCDeviceUse

    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect

    Public Event DataSelected As EventHandler(Of ClassData)
    Private Sub UCDeviceUse_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
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

    Private Sub BtnStat_Click(sender As Object, e As EventArgs) Handles BtnStat.Click
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\dial"

        Dim NameDevice = lbname.Text.Trim
        Dim pathData = lbname.Tag.Trim
        ' Replace non-numeric characters



        Dim btn = BtnStat.Text.Trim
        Dim nxt = BtnStat.Tag.Trim

        Dim namdial As String = Regex.Replace(NameDevice, "[^a-z]", "")
        Dim numpath As Integer = NameDevice.Replace(namdial, "")
        Dim FiName As String = FoldeQ & "\" & namdial & ".json"

        Dim Rlog As String = File.ReadAllText(FiName)

        Dim logParse = jsonpa.Json2aray(Rlog)
        Dim pathexe As String = logParse(namdial)(numpath - 1)("path")
        dbConn.OpenCmd(pathexe, "/exit", "")
    End Sub

    Private Sub BtnStat_Paint(sender As Object, e As PaintEventArgs) Handles BtnStat.Paint
        Dim width = BtnStat.Width
        Dim Height = BtnStat.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 5 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnStat.Region = New Region(path)
    End Sub

    Private Sub lbstatus_Click(sender As Object, e As EventArgs) Handles lbstatus.Click

    End Sub

    Private Sub UCDeviceUse_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Right Then
            KlikAnan.Show(Cursor.Position, ToolStripDropDownDirection.AboveRight)
        End If
    End Sub

    Private Sub KlikAnan_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles KlikAnan.Opening

    End Sub



    Private Sub SkipNumberToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\dial"
        Dim Foldel = fodev & "\log"
        Dim NameDevice = lbname.Text.Trim
        Dim keterstat = lbstatus.Tag.Trim


    End Sub

    Private Sub btnVlog_Click(sender As Object, e As EventArgs) Handles btnVlog.Click


        Dim DatObj = lbname.Tag
        Dim DatPar = jsonpa.Json2aray(DatObj)
        Dim fitur = DatPar("fitur")
        Dim namedial = DatPar("namedial")
        Dim pathFile = DatPar("pathFile")
        Dim pathexe = DatPar("pathexe")

        'If (fitur = "Dialler") Then

        'End If

        Dim RFilog As String = File.ReadAllText(pathFile)

        Dim param As New Dictionary(Of String, String)
        param.Add("namCaller", namedial)
        param.Add("DataJson", RFilog)

        Dim page As New frmlog
        page.DataIn(param)
        page.ShowDialog()

    End Sub

    'Private Sub OpenMirrorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenMirrorToolStripMenuItem.Click

    '    Dim NameDevice = lbname.Text.Trim


    '    Dim apkname = dbConn.ApkProfile("name")
    '    Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
    '    Dim PathLog = fodev & "\devices\" & NameDevice & ".json"
    '    Dim RFile = File.ReadAllText(PathLog)

    '    Dim J2Object = jsonpa.Json2aray(RFile)
    '    Dim nameDev As String = J2Object("name")
    '    Dim seriDev As String = J2Object("idev")
    '    Dim scrpy As String = J2Object("scrcpy").ToString.Replace("{serial}", seriDev).Replace("{winheader}", nameDev.ToString & "-" & J2Object("connection"))
    '    Dim config As String = J2Object("config")
    '    Dim idev = IIf(J2Object("connection") = "USB", J2Object("idev"), IIf(J2Object("connection") = "WIFI", J2Object("ipdev"), ""))
    '    Dim Conn = J2Object("connection")

    '    Dim devapk As New ClassApk(idev, Conn)
    '    devapk.OpenScrcpy(scrpy & config)



    '    Dim DatObj = lbname.Tag
    '    Dim DatPar = jsonpa.Json2aray(DatObj)
    '    Dim fitur = DatPar("fitur")
    '    Dim namedial = DatPar("namedial")
    '    Dim pathFile = DatPar("pathFile")
    '    Dim pathexe = DatPar("pathexe")

    '    'If (fitur = "Dialler") Then

    '    'End If
    'End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        Dim DatObj = lbname.Tag
        Dim DatPar = jsonpa.Json2aray(DatObj)
        Dim fitur = DatPar("fitur")
        Dim namedial = DatPar("namedial")
        Dim pathFile = DatPar("pathFile")
        Dim pathexe = DatPar("pathexe")
        Dim komu = DatPar("komu")
        Dim stat = BtnStop.Text
        Dim NeData As New JObject
        If (stat = "Stop Service") Then
            BtnStop.Text = "Start Service"
            Me.BackColor = Color.FromArgb(18, 180, 60)

            NeData.Add("namedial", namedial)
            NeData.Add("pathFile", pathFile)
            NeData.Add("komu", komu)
            NeData.Add("fun", "StopService")
            Dim ObjString = NeData.ToString

            ' Raise the event and pass the selected data
            RaiseEvent DataSelected(Me, New ClassData(ObjString))
            ''Console.WriteLine(ObjString)
        ElseIf (stat = "Start Service") Then
            BtnStop.Text = "Stop Service"
            Me.BackColor = Color.FromArgb(70, 71, 90)

            NeData.Add("namedial", namedial)
            NeData.Add("pathFile", pathFile)
            NeData.Add("komu", komu)
            NeData.Add("fun", "StartService")
            Dim ObjString = NeData.ToString

            ' Raise the event and pass the selected data
            RaiseEvent DataSelected(Me, New ClassData(ObjString))
        End If


    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Dim DatObj = lbname.Tag
        Dim DatPar = jsonpa.Json2aray(DatObj)
        Dim fitur = DatPar("fitur")
        Dim namedial = DatPar("namedial")
        Dim pathFile = DatPar("pathFile")
        Dim pathexe = DatPar("pathexe")

        If (fitur = "Dialler") Then
            dbConn.OpenCmd(pathexe, "/exit", "")
        End If
    End Sub
End Class
