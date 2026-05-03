Imports System.Net.Http
Imports System.Timers
Imports Newtonsoft.Json.Linq


Public Class QRManager

    Private session As String

    Private qrCount As Integer = 0
    Private maxQR As Integer = 6

    Private restartCount As Integer = 0
    Private maxRestart As Integer = 3

    Private qrTimer As Timer
    Private isRunning As Boolean = True
    Private ApiClient As New ClassApi

    Public Property Picture As PictureBox

    ' EVENT LOG
    Public Event OnLog(message As String)

    Private Sub Log(msg As String)
        RaiseEvent OnLog($"[{session}] {msg}")
    End Sub

    Public Sub New(sessionName As String, pic As PictureBox)
        session = sessionName
        Picture = pic
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
    Private Function GetQRCode()

        Try

            Dim param As New JObject
            param.Add("name", session)
            param.Add("action", "qr")

            Dim response = ApiClient.PostData("OnSeassion", param, "MRJAY59")

            Dim obj = JObject.Parse(response)

            Return obj("data").ToString()


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
    Private Function RestartSession()

        Try

            Dim param As New JObject
            param.Add("name", session)
            param.Add("action", "restart")

            Dim response = ApiClient.PostData("OnSeassion", param, "MRJAY59")

            Dim obj = JObject.Parse(response)

            Return obj("data").ToString()


        Catch ex As Exception
            Log("QR Error: " & ex.Message)
        End Try

        Return Nothing

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

End Class

