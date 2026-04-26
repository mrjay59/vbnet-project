Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.IO
Imports Tesseract

Public Class ClassAdb
    Private scrcpyProcess As Process
    Private cmdProcess As Process
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson

    Public Function ListDev(ByVal serial As String)
        Dim res = adbcommad($"{serial} devices -l")
        Dim a = 0
        Dim arrdev As New ArrayList
        For Each strLine As String In res.ToString.Split(vbNewLine)
            a = a + 1
            If (a > 1) Then
                If (strLine.Contains(":5959")) Then
                    Dim ddevice = strLine.Split(":")
                    Dim dataseri = ddevice(0).ToString.Trim
                    arrdev.Add(dataseri & ":5959")
                Else
                    Dim ddevice = strLine.Split(":")
                    Dim dataseri = ddevice(0).Replace("device product", "").ToString.Trim

                    arrdev.Add(dataseri)
                End If


            End If
        Next

        Return arrdev
    End Function
    Public Function IpDevices(ByVal serial As String)
        Dim a = adbcommad($"{serial} shell ip route")
        Dim txtipData = a.ToString.Split(ControlChars.CrLf.ToCharArray, StringSplitOptions.RemoveEmptyEntries)
        Dim ipdev = String.Empty
        If Not (a = "") Then
            For Each iptext As String In txtipData
                If (iptext.Contains("wlan0")) Then
                    Dim ipech = iptext.Split(" ")
                    ipdev = ipech(11).Trim
                End If

            Next

        Else
            ipdev = Nothing
        End If
        ' 192.168.8.0/24 dev wlan0  proto kernel  scope link  src 192.168.8.122


        Return ipdev
    End Function

    Public Function Getexture(ByVal DataRespon As String)
        Dim dtexture = String.Empty
        For Each strLine As String In DataRespon.ToString.Split(vbNewLine)
            If (strLine.Contains("INFO: Texture:")) Then
                dtexture = strLine.Replace("INFO: Texture:", "")
            End If
        Next
        Return dtexture
    End Function
    Public Sub OpenScrcpy(ByVal arg As String)

        Dim fodev = Application.StartupPath & "\"

        Dim direxe = fodev & "Scrcpy\Scrcpy.exe"
        ' Create a new process
        Dim process As New Process()

        ' Set the process start info
        Dim processStartInfo As New ProcessStartInfo()
        processStartInfo.FileName = direxe
        processStartInfo.Arguments = arg
        processStartInfo.RedirectStandardOutput = True
        processStartInfo.UseShellExecute = False
        processStartInfo.CreateNoWindow = True

        ' Assign the start info to the process
        process.StartInfo = processStartInfo

        ' Start the process
        process.Start()


    End Sub

    Public Sub OpenCmd(ByVal DirApk As String, ByVal Argu As String, ByVal WT As String)
        Thread.Sleep(1000)
        Dim cmdProcess = New ProcessStartInfo()
        cmdProcess.FileName = DirApk
        cmdProcess.Arguments = Argu
        cmdProcess.UseShellExecute = False
        cmdProcess.RedirectStandardInput = True
        cmdProcess.CreateNoWindow = True

        If (WT = "Y") Then
            Process.Start(cmdProcess).WaitForExit()
        Else
            Process.Start(cmdProcess)
        End If


    End Sub

    Public Sub OpenApk()

        scrcpyProcess = New Process()
        scrcpyProcess.StartInfo.FileName = "cmd.exe"
        scrcpyProcess.StartInfo.Arguments = "/K scrcpy"
        scrcpyProcess.StartInfo.UseShellExecute = False
        scrcpyProcess.StartInfo.RedirectStandardInput = True
        scrcpyProcess.StartInfo.CreateNoWindow = True
        scrcpyProcess.Start()
        scrcpyProcess.StandardInput.WriteLine("scrcpy")

        ' Install APK file
        Dim apkPath As String = "C:\path\to\myapp.apk"
        Dim adbProcess As Process = Process.Start("adb", $"install -r ""{apkPath}""")
        adbProcess.WaitForExit()

        ' Launch app
        Dim packageName As String = "com.example.myapp"
        adbProcess = Process.Start("adb", $"shell monkey -p {packageName} -c android.intent.category.LAUNCHER 1")
        adbProcess.WaitForExit()
    End Sub



    Public Sub kirimpesan(ByVal serial As String, ByVal txt As String)
        Thread.Sleep(500)
        adbcommad($"{serial} shell am broadcast -a ADB_INPUT_TEXT --es msg '{txt}'")
        Thread.Sleep(500)
        'adbcommad($"{serial} shell input text '{txt}'")
    End Sub


    Public Sub OpenWhatsAppBusiness(ByVal serial As String)
        Thread.Sleep(500)
        Dim a = adbcommad($"{serial} shell am start -n com.whatsapp.w4b/com.whatsapp.Main")
        Console.WriteLine(a)
    End Sub

    Public Function GetDemi(ByVal serial As String)
        Dim texture As String = Nothing
        Try
            Dim apkname = dbConn.ApkProfile("name")
            Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
            Dim FoldeQ = fodev & "\devices\"
            Dim seriala = serial.Substring(Len(serial) - 4, 4)
            Dim GetNameFile = IO.Directory.GetFiles(FoldeQ, "*-" & seriala & ".json")
            Dim fiDev = GetNameFile(0)

            Dim RDev As String = File.ReadAllText(fiDev)
            Dim Jdev = jsonpa.Json2aray(RDev)
            texture = Jdev("texture")

        Catch ex As Exception

        End Try

        Return texture

    End Function



    Public Sub OpenWhatsApp(ByVal serial As String)
        Thread.Sleep(500)
        Dim a = adbcommad($"{serial} shell am start -n com.whatsapp/com.whatsapp.Main")
        Console.WriteLine(a)
    End Sub

    Public Sub sendsms(ByVal serial As String, ByVal phone_number As Integer, ByVal message_body As String)
        adbcommad($"{serial} shell am start -a android.intent.action.SENDTO -d sms: {phone_number} --es sms_body ""{message_body}"" --ez exit_on_sent true")
    End Sub

    Public Sub KlikTouch(ByVal serial As String, ByVal demi As String, ByVal valxy As String)
        Dim fodev = Application.StartupPath & "\"

        Dim filePath = fodev & "resolution.json"
        Dim b As String = File.ReadAllText(filePath)
        Dim DatKlik = jsonpa.Json2aray(b)
        Dim data = DatKlik(demi)(valxy)
        Dim dtxy = data.ToString.Split(",")
        Dim x As String = dtxy(0)
        Dim y As String = dtxy(1)


        adbcommad($"{serial} shell input tap {x} {y}")
    End Sub

    Public Sub backbtn(ByVal serial As String)
        adbcommad($"{serial} shell input keyevent 4")
    End Sub
    Public Sub back2home(ByVal serial As String)
        adbcommad($"{serial} shell input keyevent 3")
    End Sub

    Public Function GetImageDimensions(ByVal imagePath As String)
        ' Load the image
        Using img As Image = Image.FromFile(imagePath)
            ' Get the width and height of the image
            Dim width As Integer = img.Width
            Dim height As Integer = img.Height
            Dim demi = $"{width}x{height}"

            Return demi
        End Using


    End Function

    Public Function adbcommad(ByVal perintah As String)

        Dim fodev = Application.StartupPath & "\"

        Dim direxe = fodev & "scrcpy\adb.exe"
        ' Create a new process
        Dim process As New Process()

        ' Set the process start info
        Dim processStartInfo As New ProcessStartInfo()
        processStartInfo.FileName = direxe
        processStartInfo.Arguments = perintah
        processStartInfo.RedirectStandardOutput = True
        processStartInfo.UseShellExecute = False
        processStartInfo.CreateNoWindow = True

        ' Assign the start info to the process
        process.StartInfo = processStartInfo

        ' Start the process
        process.Start()

        ' Read the output of the command
        Dim output As String = process.StandardOutput.ReadToEnd


        Return output.TrimEnd
    End Function

    Public Function GetFileSize(ByVal TheFile As String) As String
        If TheFile.Length = 0 Then Return ""
        If Not System.IO.File.Exists(TheFile) Then Return ""
        '---
        Dim TheSize As ULong = My.Computer.FileSystem.GetFileInfo(TheFile).Length
        Dim SizeType As String = ""
        '---
        Dim DoubleBytes As Double
        Try
            Select Case TheSize
                Case Is >= 1099511627776
                    DoubleBytes = CDbl(TheSize / 1099511627776) 'TB
                    Return FormatNumber(DoubleBytes, 2) & " TB"
                Case 1073741824 To 1099511627775
                    DoubleBytes = CDbl(TheSize / 1073741824) 'GB
                    Return FormatNumber(DoubleBytes, 2) & " GB"
                Case 1048576 To 1073741823
                    DoubleBytes = CDbl(TheSize / 1048576) 'MB
                    Return FormatNumber(DoubleBytes, 2) & " MB"
                Case 1024 To 1048575
                    DoubleBytes = CDbl(TheSize / 1024) 'KB
                    Return FormatNumber(DoubleBytes, 2) & " KB"
                Case 0 To 1023
                    DoubleBytes = TheSize ' bytes
                    Return FormatNumber(DoubleBytes, 2) & " bytes"
                Case Else
                    Return ""
            End Select
        Catch
            Return ""
        End Try
    End Function

    Public Function screencap(ByVal serial As String)
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\screencap\"
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        Dim filename = serial.Replace("-s ", "").Trim
        Dim apkpath As String = FoldeQ & $"{filename}.png"

        'If (IO.File.Exists(apkpath)) Then
        '    IO.File.Delete(apkpath)
        'End If

        Try
            adbcommad($"{serial} shell screencap -p /sdcard/screen.png")
            Thread.Sleep(500)
            adbcommad($"{serial} pull /sdcard/screen.png {apkpath}")
            'Dim a = adbcommad($"{serial} shell screencap {apkpath}")


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim Filesize = GetFileSize(apkpath)
        If (Filesize = "0.00 bytes") Then
            screencap(serial)
        End If

        Return apkpath

    End Function

    Public Function ImageToText(ByVal imagePath As String) As ArrayList



        ' Dim fodev = Environment.GetFolderPath(Application.StartupPath) & "\"
        Dim filePath = Application.StartupPath & "\tessdata\"
        'MsgBox(filePath)
        Dim engine As TesseractEngine = Nothing
        Dim arrtxt As New ArrayList
        Try
            ' Create an instance of the Tesseract engine
            engine = New TesseractEngine(filePath, "eng", EngineMode.Default)

            ' Load the image
            Using image As Pix = Pix.LoadFromFile(imagePath)
                ' Set page segmentation mode if needed
                engine.DefaultPageSegMode = PageSegMode.Auto

                ' Process the image and extract text
                Using page As Page = engine.Process(image)
                    Dim result As String = page.GetText()
                    For Each strLine As String In result.Split(vbLf)
                        If Not (strLine = "") Then
                            arrtxt.Add(strLine.Trim)
                            Console.WriteLine(strLine)
                        End If

                    Next

                End Using
            End Using
        Catch ex As Exception
            ' Handle any exceptions
            'MsgBox(ex.Message)
        Finally
            ' Dispose of the Tesseract engine
            If engine IsNot Nothing Then
                engine.Dispose()
            End If
        End Try
        engine.Dispose()
        Return arrtxt
    End Function



End Class
