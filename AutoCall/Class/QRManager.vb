Imports System.Net.Http
Imports System.Text
Imports System.Timers
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Newtonsoft.Json.Linq


Public Class QRManager

    Private session As String
    Private vendor As String

    Private qrCount As Integer = 0
    Private maxQR As Integer = 6

    Private restartCount As Integer = 0
    Private maxRestart As Integer = 3

    Private qrTimer As Timer
    Private isRunning As Boolean = True

    Public Property Picture As PictureBox

    Private BaseUrl As String = "https://www.mrjay59.com"

    ' EVENT LOG
    Public Event OnLog(message As String)

    Private Sub Log(msg As String)
        RaiseEvent OnLog($"[{session}] {msg}")
    End Sub

    Public Sub New(sessionName As String, navendor As String, pic As PictureBox)
        session = sessionName
        Picture = pic
        vendor = navendor
    End Sub

    ' =========================
    ' EVENT: SCAN_QR_CODE
    ' =========================
    Public Async Sub OnScanRequired()

        If Not isRunning Then Exit Sub

        qrCount += 1

        If qrCount > maxQR Then
            Log("QR limit reached")
            Await HandleRestart()
            Return
        End If

        Log($"Generate QR #{qrCount}")

        Dim qr = Await GetQRCode()

        If qr IsNot Nothing Then
            ShowQR(qr)
            StartTimer()
        Else
            Log("Failed get QR")
        End If

    End Sub

    ' =========================
    ' TIMER
    ' =========================
    Private Sub StartTimer()

        If qrTimer IsNot Nothing Then
            qrTimer.Stop()
        End If

        qrTimer = New Timer()

        If qrCount = 1 Then
            qrTimer.Interval = 60000
        Else
            qrTimer.Interval = 20000
        End If

        AddHandler qrTimer.Elapsed, AddressOf OnQRExpired
        qrTimer.AutoReset = False
        qrTimer.Start()

        Log($"Timer start {qrTimer.Interval / 1000}s")

    End Sub

    Private Async Sub OnQRExpired(sender As Object, e As ElapsedEventArgs)

        If Not isRunning Then Exit Sub

        Log("QR expired")

        Await Task.Delay(100)
        OnScanRequired()

    End Sub

    ' =========================
    ' GET QR
    ' =========================
    Private Async Function GetQRCode() As Task(Of String)

        Try
            Dim endpoint As String = "/api/cpost/whatsapp/OnSeassion?"

            Dim param As New JObject
            param.Add("action", "qr")
            param.Add("name", session)
            param.Add("navendor", vendor)

            Dim res = Await PostAsync(endpoint, param.ToString)

            If String.IsNullOrEmpty(res) Then
                Log("QR API empty response")
                Return Nothing
            End If

            Dim obj = JObject.Parse(res)

            ' 🔥 HANDLE ERROR RESPONSE
            If obj("status") IsNot Nothing Then

                Dim status = obj("status").ToString()

                If status = "FAILED" Then
                    Log("Session FAILED → restarting...")

                    ' 🔥 restart session
                    Await HandleRestart()

                    ' tunggu sebentar biar ready
                    Await Task.Delay(2000)

                    ' 🔥 retry ambil QR
                    Return Await GetQRCode()
                End If

            End If

            ' normal ambil QR
            If obj("data") IsNot Nothing Then
                Return obj("data").ToString()
            End If

        Catch ex As Exception
            Log("QR Error: " & ex.Message)
        End Try

        Return Nothing

    End Function

    ' =========================
    ' SHOW QR
    ' =========================
    Private Sub ShowQR(base64Qr As String)


        Try
            Dim bytes = Convert.FromBase64String(base64Qr)

            Using ms As New IO.MemoryStream(bytes)
                Picture.Image = Image.FromStream(ms)
            End Using

            Log("QR displayed")

        Catch ex As Exception
            Log("Show QR Error: " & ex.Message)
        End Try

    End Sub

    ' =========================
    ' HANDLE RESTART
    ' =========================
    Private Async Function HandleRestart() As Task

        restartCount += 1

        If restartCount > maxRestart Then
            Log("Max restart reached → STOP")
            StopAll()
            Return
        End If

        Log($"Restart session ({restartCount}/{maxRestart})")

        qrCount = 0

        Await RestartSession()

    End Function

    ' =========================
    ' RESTART API
    ' =========================
    Private Async Function RestartSession() As Task

        Try
            Dim endpoint As String = "/api/cpost/whatsapp/OnSeassion?"

            Dim param As New JObject
            param.Add("action", "restart")
            param.Add("name", session)
            param.Add("navendor", vendor)

            Dim res = Await PostAsync(endpoint, param.ToString)

            If res Is Nothing Then
                Log("Restart failed (no response)")
            Else
                Log("Restart request sent")
            End If

        Catch ex As Exception
            Log("Restart Error: " & ex.Message)
        End Try

    End Function

    ' =========================
    ' STOP
    ' =========================
    Public Sub StopAll()

        isRunning = False

        If qrTimer IsNot Nothing Then
            qrTimer.Stop()
        End If

        Log("QR Manager STOPPED")

    End Sub

    ' =========================
    ' RESET
    ' =========================
    Public Sub Reset()

        qrCount = 0
        restartCount = 0

        If qrTimer IsNot Nothing Then
            qrTimer.Stop()
        End If

        Log("QR Reset")

    End Sub

    Private Async Function PostAsync(endpoint As String, Optional jsonBody As String = "") As Task(Of String)

        Try
            Dim url = BaseUrl & endpoint

            Dim content As New StringContent(jsonBody, Encoding.UTF8, "application/json")
            Dim client As New HttpClient()


            Dim res = Await client.PostAsync(url, content)
            Console.WriteLine($"POST {url} - Status: {res.StatusCode} {res}")
            If res.IsSuccessStatusCode Then
                Return Await res.Content.ReadAsStringAsync()
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Class



