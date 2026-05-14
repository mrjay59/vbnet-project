Imports System.Collections.Concurrent
Imports Newtonsoft.Json.Linq

Public Class QueueEngine
    Private dbConn As New ClassConnect
    Public Property DeviceQueues As New ConcurrentDictionary(Of String, ConcurrentQueue(Of JObject))
    Public Property DeviceTotal As New Dictionary(Of String, Integer)

    Public Property Komu As String = "BE" ' BE / PU
    Public Property DelayMs As Integer = 20000
    Public Property MaxPutaran As Integer = 1

    Public _isRunning As Boolean = False
    ' status stop per device
    Private DeviceStopFlags As New ConcurrentDictionary(Of String, Boolean)

    ' 🔥 EVENT (optional UI update)
    Public Event OnLog(message As String)
    Public Event OnDeviceUpdate(deviceKey As String, status As DeviceStatus, info As String)
    Public Event OnSendWSS(item As JObject)
    Public Event OnAllCompleted()

    Public Enum DeviceStatus
        Idle
        Queued
        Sending
        Paused
        Retry
        ErrorState
        Done
    End Enum

    ' STOP hanya device tertentu
    Public Sub StopDevice(deviceKey As String)

        DeviceStopFlags.AddOrUpdate(deviceKey,
        True,
        Function(k, v) True)

        RaiseEvent OnDeviceUpdate(deviceKey,
        DeviceStatus.Paused,
        "Device stopped")

    End Sub

    ' RESUME hanya device tertentu
    Public Sub ResumeDevice(deviceKey As String)

        DeviceStopFlags.AddOrUpdate(deviceKey,
        False,
        Function(k, v) False)

        RaiseEvent OnDeviceUpdate(deviceKey,
        DeviceStatus.Idle,
        "Device resumed")

    End Sub

    ' cek apakah device stop
    Private Function IsDeviceStopped(deviceKey As String) As Boolean

        Dim val As Boolean = False

        If DeviceStopFlags.TryGetValue(deviceKey, val) Then
            Return val
        End If

        Return False

    End Function
    ' 🔥 START ENGINE
    Public Async Function StartAsync() As Task
        _isRunning = True

        If Komu = "BE" Then
            Await RunBE()
        ElseIf Komu = "PU" Then
            Await RunPU()
        End If

        RaiseEvent OnAllCompleted()
        RaiseEvent OnLog("Queue selesai semua")
    End Function

    Public Sub [Stop]()
        _isRunning = False
    End Sub

    Public Async Function ResumeAsync() As Task

        If _isRunning Then Exit Function

        _isRunning = True

        If Komu = "BE" Then
            Await RunBE()
        ElseIf Komu = "PU" Then
            Await RunPU()
        End If

    End Function

    Public Sub ClearAll()

        For Each key In DeviceQueues.Keys
            DeviceQueues(key) = New Concurrent.ConcurrentQueue(Of JObject)
        Next

    End Sub

    Public Sub ClearDevice(deviceKey As String)

        If DeviceQueues.ContainsKey(deviceKey) Then
            DeviceQueues(deviceKey) = New Concurrent.ConcurrentQueue(Of JObject)
        End If

    End Sub

    ' =========================================
    ' 🔴 MODE BE (BERUNTUN)
    ' =========================================
    Private Async Function RunBE() As Task

        Dim tasks As New List(Of Task)

        For Each device In DeviceQueues.Keys

            Dim dev = device

            tasks.Add(Task.Run(Async Function()

                                   Dim q = DeviceQueues(dev)

                                   While _isRunning AndAlso q.Count > 0

                                       ' 🔥 skip jika device di stop
                                       If IsDeviceStopped(dev) Then
                                           Await Task.Delay(1000)
                                           Continue While
                                       End If

                                       Dim item As JObject = Nothing

                                       If q.TryDequeue(item) Then
                                           Await ProcessItem(item)
                                       End If

                                   End While

                               End Function))

        Next

        Await Task.WhenAll(tasks)

    End Function

    ' =========================================
    ' 🔵 MODE PU (PUTARAN)
    ' =========================================
    Private Async Function RunPU() As Task

        For putaran As Integer = 1 To MaxPutaran

            If Not _isRunning Then Exit For



            RaiseEvent OnLog($"Putaran {putaran}")

            Dim tasks As New List(Of Task)

            For Each device In DeviceQueues.Keys

                Dim dev = device

                'RaiseEvent OnDeviceUpdate(dev, DeviceStatus.Sending,
                '   $"Putaran {putaran}/{MaxPutaran}")

                tasks.Add(Task.Run(Async Function()

                                       Dim q = DeviceQueues(dev)

                                       Dim listData As New List(Of JObject)

                                       ' ambil semua data
                                       While q.Count > 0
                                           Dim tmp As JObject = Nothing
                                           If q.TryDequeue(tmp) Then
                                               listData.Add(tmp)
                                           End If
                                       End While

                                       ' 🔥 jalankan TANPA RECALL
                                       For Each item In listData

                                           If IsDeviceStopped(dev) Then
                                               Exit For
                                           End If

                                           Await ProcessItem(item, True)

                                       Next

                                       ' kembalikan ke queue
                                       For Each item In listData
                                           q.Enqueue(item)
                                       Next

                                   End Function))

            Next

            Await Task.WhenAll(tasks)

        Next

    End Function

    ' =========================================
    ' 🔧 PROCESS ITEM (CALL ENGINE)
    ' =========================================
    Private Async Function ProcessItem(item As JObject, Optional isPU As Boolean = False) As Task

        Try
            Dim dev = item("device").ToString()
            Dim number = item("to").ToString()
            Dim con = item("connection").ToString()
            Dim platform = item("platform").ToString()
            Dim path = If(item("from") IsNot Nothing, item("from").ToString(), "")
            Dim tocall As Integer = CInt(item("tocall"))

            Dim loopCount As Integer = If(isPU, 1, tocall)
            Dim komu = If(isPU, "PU", "BE")
            Dim uiAuto As New WhatsAppAutomation

            For i = 1 To loopCount

                If IsDeviceStopped(dev) Then

                    RaiseEvent OnDeviceUpdate(dev,
                    DeviceStatus.Paused,
                    $"STOPPED {number}")

                    Exit For

                End If

                If Not _isRunning Then Exit For

                RaiseEvent OnDeviceUpdate(dev, DeviceStatus.Sending,
                   $"START to {number} Method {komu}")

                Select Case con

                    Case "USB", "WIFI"

                        Await Task.Run(Sub()
                                           Dim devapk As New ClassApk(dev, con)

                                           If (platform = "wao") Or (platform = "wab") Then
                                               Dim waTipe = If(platform = "wao", "WhatsAppMessage", "WhatsAppBusiness")
                                               devapk.OpenWA(waTipe, "", number, "call", "")
                                               Threading.Thread.Sleep(DelayMs)
                                               devapk.EndCall()
                                           ElseIf (platform = "tlc") Then
                                               devapk.MakeCellularCall(number, 0)
                                               Threading.Thread.Sleep(DelayMs)
                                           End If
                                       End Sub)

                    Case "SIPLocal"

                        Await Task.Run(Sub()
                                           dbConn.OpenCmd(path, "/exit", "")
                                           Threading.Thread.Sleep(1500)
                                           dbConn.OpenCmd(path, number, "")
                                           Threading.Thread.Sleep(DelayMs)
                                       End Sub)

                    Case "TERMUX"

                        RaiseEvent OnSendWSS(item)
                        Await Task.Delay(DelayMs)

                    Case "WhatsApp"

                        RaiseEvent OnSendWSS(item)
                        Await Task.Delay(DelayMs)

                    Case "SIPServer"

                        RaiseEvent OnSendWSS(item)
                        Await Task.Delay(DelayMs)

                    Case "WAD"

                        Await Task.Run(Sub()

                                           If (platform = "WhatsApp") Then ' Untuk WhatsApp Biasa
                                               Process.Start(path)
                                               Task.Delay(2000)

                                               If Not uiAuto.ClickCallIconInSidebar() Then
                                                   Return ' Keluar dari task ini, bukan dari semua task
                                               End If

                                               If Not uiAuto.ClickCallNumberAndHandlePopup(number, platform) Then
                                                   Return
                                               End If
                                           Else
                                               uiAuto.AutomateWhatsAppCallDirect(number)

                                           End If

                                           uiAuto.HandleVoiceCall(platform)
                                       End Sub)

                End Select

            Next

        Catch ex As Exception
            RaiseEvent OnDeviceUpdate(item("device").ToString(),
            DeviceStatus.ErrorState, ex.Message)
        End Try

    End Function

End Class