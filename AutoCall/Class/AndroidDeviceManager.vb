Imports AdvancedSharpAdbClient
Imports System.Net.Sockets
Imports System.Timers
Imports AdvancedSharpAdbClient.Exceptions

Public Class AndroidDeviceManager
    Private client As AdbClient
    Private WithEvents devicePollTimer As System.Timers.Timer
    Private lastConnectedDevices As New List(Of String)

    ' Event Handler
    Public Event OnDeviceConnected(serial As String)
    Public Event OnDeviceDisconnected(serial As String)

    Public Sub New(Optional pollIntervalMs As Integer = 5000)
        client = New AdbClient()
        devicePollTimer = New System.Timers.Timer(pollIntervalMs)
        AddHandler devicePollTimer.Elapsed, AddressOf CheckConnectedDevices
    End Sub

    Public Sub Start()
        RefreshAdbServer()
        devicePollTimer.Start()
    End Sub

    Public Sub [Stop]()
        devicePollTimer.Stop()
    End Sub

    Public Sub RefreshAdbServer()
        Dim server As New AdbServer()
        server.StartServer("adb.exe", restartServerIfNewer:=True)
    End Sub

    Public Function GetConnectedDevices() As List(Of DeviceData)
        Return client.GetDevices()
    End Function

    ' 🔁 Called every interval to detect device changes
    Private Sub CheckConnectedDevices(sender As Object, e As ElapsedEventArgs)
        Dim currentDevices = GetConnectedDevices().Select(Function(d) d.Serial).ToList()

        ' New device connected
        For Each serial In currentDevices.Except(lastConnectedDevices)
            RaiseEvent OnDeviceConnected(serial)
        Next

        ' Device disconnected
        For Each serial In lastConnectedDevices.Except(currentDevices)
            RaiseEvent OnDeviceDisconnected(serial)
        Next

        lastConnectedDevices = currentDevices
    End Sub

    ' ✅ Safe command execution with retry
    Public Function ExecuteCommandWithRetry(device As DeviceData, command As String, Optional retries As Integer = 3) As String
        Dim result = ""
        For i = 1 To retries
            Try
                Dim receiver = New ConsoleOutputReceiver()
                client.ExecuteRemoteCommand(command, device, receiver)
                result = receiver.ToString()
                Exit For
            Catch ex As AdbException
                Console.WriteLine($"[ADB ERROR] {device.Serial}: {ex.Message}")
            Catch ex As SocketException
                Console.WriteLine($"[SOCKET ERROR] {device.Serial}: {ex.Message}")
            Catch ex As Exception
                Console.WriteLine($"[ERROR] {device.Serial}: {ex.Message}")
            End Try
            Threading.Thread.Sleep(1000)
        Next
        Return result
    End Function

End Class
