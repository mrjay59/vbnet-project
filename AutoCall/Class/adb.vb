Imports System.Xml.Linq
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Diagnostics


Public Class DeviceInfo
    Public Property Serial As String
    Public Property Product As String
    Public Property Model As String
    Public Property Device As String
    Public Property TransportId As Integer
    Public Overrides Function ToString() As String
        Return $"{Model} - {Serial}"
    End Function
End Class

Public Class adb

    Public deviceId As String = ""
    Public platform As String = ""
    Private PathAdb As String = Application.StartupPath & "\Scrcpy\adb.exe"

    Public Function Shell(command As String) As String
        Dim psi As New ProcessStartInfo("adb", "shell " & command) With {
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .UseShellExecute = False,
            .CreateNoWindow = True
        }

        Using p As Process = Process.Start(psi)
            Return p.StandardOutput.ReadToEnd().Trim()
        End Using
    End Function

    Public Function GetDeviceInfo() As Dictionary(Of String, String)
        Try
            Dim brand As String = StartAdbCommand("getprop ro.product.manufacturer").Trim()
            Dim model As String = StartAdbCommand("getprop ro.product.model").Trim()
            Dim androidVer As String = StartAdbCommand("getprop ro.build.version.release").Trim()

            ' Serial number (fallback aman)
            Dim serial As String = StartAdbCommand("getprop ro.serialno").Trim()
            If String.IsNullOrEmpty(serial) Then
                serial = StartAdbCommand("getprop ro.boot.serialno").Trim()
            End If

            Dim info As New Dictionary(Of String, String) From {
            {"brand", brand},
            {"model", model},
            {"android", androidVer},
            {"serial", serial}
        }

            Return info

        Catch ex As Exception
            Return New Dictionary(Of String, String)
        End Try
    End Function


    '=========================================
    '   CONNECT DEVICE
    '=========================================
    Public Sub Connect(device As String, ByVal connectType As String)
        Try
            ' List devices
            Dim proc As New Process()
            proc.StartInfo.FileName = "adb"
            proc.StartInfo.Arguments = "devices"
            proc.StartInfo.RedirectStandardOutput = True
            proc.StartInfo.UseShellExecute = False
            proc.StartInfo.CreateNoWindow = True
            proc.Start()

            Dim output = proc.StandardOutput.ReadToEnd()
            proc.WaitForExit()

            For Each line In output.Split(ControlChars.Lf)
                If line.Contains(device) Then
                    If connectType = "USB" Then
                        deviceId = device
                    ElseIf connectType = "NETWORK" Then
                        RunADB($"connect {device}")
                        deviceId = device
                    End If
                End If
            Next

        Catch ex As Exception
        End Try
    End Sub

    '=========================================
    '   ADB COMMAND (SYNC)
    '=========================================
    Public Function StartAdbCommand(cmd As String) As String
        Try
            Dim p As New Process()
            p.StartInfo.FileName = PathAdb
            p.StartInfo.Arguments = $"-s {deviceId} {cmd}"
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()

            Dim result = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '=========================================
    '   ADB COMMAND (ASYNC)
    '=========================================
    Public Async Function StartAdbCommandAsync(cmd As String) As Task
        Try
            Await Task.Run(Sub() StartAdbCommand(cmd))
        Catch ex As Exception
        End Try
    End Function

    '=========================================
    '   SIMPLE RUN ADB
    '=========================================
    Private Function RunADB(args As String)

        Try
            Dim p As New Process()
            p.StartInfo.FileName = PathAdb
            p.StartInfo.Arguments = args
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()

            Dim result = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            Return result
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '=========================================
    '   GET DEVICE IP
    '=========================================
    Public Function IpDevices()
        Dim a = StartAdbCommand("shell ip route")
        Dim ipdev = ""

        If a IsNot Nothing Then
            For Each line In a.Split(ControlChars.Lf)
                If line.Contains("wlan0") AndAlso line.Contains("src") Then
                    Dim pos = line.IndexOf("src") + 4
                    ipdev = line.Substring(pos).Trim()
                End If
            Next
        End If

        Return ipdev
    End Function

    Public Sub StartServerAdb()
        Try
            ' Jalankan perintah adb start-server
            Dim p As New Process()
            p.StartInfo.FileName = PathAdb     ' contoh: "C:\adb\adb.exe"
            p.StartInfo.Arguments = "start-server"
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.RedirectStandardError = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True

            p.Start()

            Dim output As String = p.StandardOutput.ReadToEnd()
            Dim err As String = p.StandardError.ReadToEnd()

            p.WaitForExit()

            If Not String.IsNullOrEmpty(err) Then
                Console.WriteLine("ADB Error: " & err)
            End If

        Catch ex As Exception
            Console.WriteLine("StartServerAdb ERR: " & ex.Message)
        End Try
    End Sub


    Public Function ListDevice() As List(Of DeviceInfo)
        Dim results As New List(Of DeviceInfo)

        Try
            ' Pastikan adb server berjalan (panggil fungsi StartServerAdb yang sudah ada)
            StartServerAdb()

            ' Ambil output dari adb devices -l
            Dim output = RunADB("devices -l")

            ' Bagi per baris dan buang baris kosong
            Dim lines = output.Split(New String() {vbCrLf, vbLf}, StringSplitOptions.RemoveEmptyEntries)

            For Each line In lines
                If line.Contains("device") AndAlso Not line.Contains("List of devices") Then
                    ' Split per spasi (menggunakan Char() agar kompatibel)
                    Dim parts = line.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)

                    Dim dev As New DeviceInfo()

                    ' Serial biasanya di bagian pertama
                    If parts.Length > 0 Then
                        dev.Serial = parts(0).Trim()
                    End If

                    ' Parse atribut selanjutnya product:, model:, device:, transport_id:
                    For Each p In parts
                        If p.StartsWith("product:") Then
                            dev.Product = p.Substring("product:".Length).Trim()
                        ElseIf p.StartsWith("model:") Then
                            dev.Model = p.Substring("model:".Length).Trim()
                        ElseIf p.StartsWith("device:") Then
                            dev.Device = p.Substring("device:".Length).Trim()
                        ElseIf p.StartsWith("transport_id:") Then
                            Dim s = p.Substring("transport_id:".Length).Trim()
                            Dim tid As Integer = 0
                            Integer.TryParse(s, tid)
                            dev.TransportId = tid
                        End If
                    Next

                    results.Add(dev)
                End If
            Next

        Catch ex As Exception
            Console.WriteLine("Err ListDevice: " & ex.Message)
        End Try

        Return results
    End Function


    '=========================================
    '   SCREENSHOT
    '=========================================
    Public Function Screenshot() As Image
        Try
            Dim p As New Process()
            p.StartInfo.FileName = "adb"
            p.StartInfo.Arguments = $"-s {deviceId} exec-out screencap -p"
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()

            Dim ms As New IO.MemoryStream()
            p.StandardOutput.BaseStream.CopyTo(ms)
            p.WaitForExit()

            If ms.Length = 0 Then Return Nothing

            ms.Position = 0
            Return Image.FromStream(ms)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    '=========================================
    '   DUMP UI XML
    '=========================================
    Public Function DumpScreenString() As String
        Try
            Dim p As New Process()
            p.StartInfo.FileName = "adb"
            p.StartInfo.Arguments = $"-s {deviceId} exec-out uiautomator dump /dev/tty"
            p.StartInfo.RedirectStandardOutput = True
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()

            Dim xml = p.StandardOutput.ReadToEnd()
            p.WaitForExit()
            Return xml
        Catch ex As Exception
            Return ""
        End Try
    End Function

    '=========================================
    '   ELEMENT NODE (TAP)
    '=========================================
    Public Class ElementNode
        Public Property X As Integer
        Public Property Y As Integer
        Public Property Raw As XElement

        Public Sub Click()
            Dim p As New Process()
            p.StartInfo.FileName = "adb"
            p.StartInfo.Arguments = $"-s {adbInstance.deviceId} shell input tap {X} {Y}"
            p.StartInfo.UseShellExecute = False
            p.StartInfo.CreateNoWindow = True
            p.Start()
            p.WaitForExit()
        End Sub

        Public Async Sub ClickAsync()
            Await Task.Run(Sub() Click())
        End Sub
    End Class

    Private Shared adbInstance As adb
    Public Sub New()
        adbInstance = Me
    End Sub

    '=========================================
    '   FIND ELEMENT (XPath sederhana)
    '=========================================
    Public Function FindElement(xpath As String) As ElementNode
        Dim xml = DumpScreenString()
        If xml.Trim() = "" Then Return Nothing

        Dim doc As XDocument = XDocument.Parse(xml)
        Dim cond = ParseXPath(xpath)

        Dim n = doc.Descendants("node").
            Where(Function(x) CheckNodeMatch(x, cond)).
            FirstOrDefault()

        If n Is Nothing Then Return Nothing
        Return ConvertToElementNode(n)
    End Function

    '=========================================
    '   FIND ELEMENTS
    '=========================================
    Public Function FindElements(xpath As String) As List(Of ElementNode)
        Dim xml = DumpScreenString()
        Dim results As New List(Of ElementNode)
        If xml.Trim() = "" Then Return results

        Dim doc As XDocument = XDocument.Parse(xml)
        Dim cond = ParseXPath(xpath)

        Dim nodes = doc.Descendants("node").
            Where(Function(x) CheckNodeMatch(x, cond)).
            ToList()

        For Each n In nodes
            results.Add(ConvertToElementNode(n))
        Next

        Return results
    End Function

    '=========================================
    '   PARSE XPATH ATTR
    '=========================================
    Private Function ParseXPath(xpath As String) As Dictionary(Of String, String)
        Dim dict As New Dictionary(Of String, String)

        If xpath.Contains("@") Then
            Dim part = xpath.Split("@"c)(1)
            part = part.Replace("]", "").Replace("'", "")

            Dim key = part.Split("="c)(0)
            Dim val = part.Split("="c)(1)

            dict(key) = val
        End If

        Return dict
    End Function

    '=========================================
    '   CHECK MATCH
    '=========================================
    Private Function CheckNodeMatch(n As XElement, cond As Dictionary(Of String, String)) As Boolean
        For Each k In cond.Keys
            If n.Attribute(k) Is Nothing Then Return False
            If n.Attribute(k).Value <> cond(k) Then Return False
        Next
        Return True
    End Function

    '=========================================
    '   CONVERT NODE → ELEMENTNODE
    '=========================================
    Private Function ConvertToElementNode(n As XElement) As ElementNode
        Dim bounds = n.Attribute("bounds").Value
        Dim nums = bounds.Replace("[", "").Replace("]", ",").Split(","c)
        Dim x1 = Integer.Parse(nums(0))
        Dim y1 = Integer.Parse(nums(1))
        Dim x2 = Integer.Parse(nums(2))
        Dim y2 = Integer.Parse(nums(3))

        Return New ElementNode() With {
            .X = (x1 + x2) \ 2,
            .Y = (y1 + y2) \ 2,
            .Raw = n
        }
    End Function

End Class
