Imports System.IO
Imports System.Net.WebSockets
Imports System.Text
Imports System.Threading

Public Class WebSocketClient
    Private client As ClientWebSocket
    Private uri As Uri

    ' Event untuk pesan yang diterima
    Public Event MessageReceived(message As String)
    ' Event untuk status perubahan koneksi
    Public Event ConnectionStateChanged(state As WebSocketState)
    Public Event OnConnected()
    Public Event OnDisconnected()
    Public Event OnMessage(msg As String)

    Public IsConnected As Boolean = False
    Private cancellationToken As CancellationTokenSource



    Public Async Function ConnectAsync(uri As String) As Task
        Try
            Me.uri = New Uri(uri)
            client = New ClientWebSocket()
            cancellationToken = New CancellationTokenSource()

            Await client.ConnectAsync(Me.uri, cancellationToken.Token)
            IsConnected = True
            RaiseEvent OnConnected()
            HandleConnectionStateChange(client.State)

            Await ReceiveMessagesAsync()

        Catch ex As Exception
            Console.WriteLine("Error: " & ex.Message)
        End Try
    End Function

    Private Async Function ReceiveMessagesAsync() As Task
        Dim buffer As Byte() = New Byte(8191) {}
        Dim sb As New StringBuilder()

        Try
            While client.State = WebSocketState.Open

                Using ms As New IO.MemoryStream()
                    Dim result As WebSocketReceiveResult
                    Do
                        result = Await client.ReceiveAsync(New ArraySegment(Of Byte)(buffer), cancellationToken.Token)
                        ms.Write(buffer, 0, result.Count)
                    Loop While Not result.EndOfMessage

                    Dim message As String = Encoding.UTF8.GetString(ms.ToArray())
                    RaiseEvent OnMessage(message)
                    sb.Append(message)

                    Try
                        ' Try parse as JObject
                        'Dim parsed = JObject.Parse(sb.ToString())
                        RaiseEvent MessageReceived(sb.ToString())
                        sb.Clear()
                    Catch ex As Exception
                        ' Incomplete JSON, wait for next loop
                        Console.WriteLine("Waiting for complete JSON...")
                    End Try

                    HandleConnectionStateChange(client.State)
                End Using
            End While
        Catch ex As Exception
            RaiseEvent OnDisconnected()
            Console.WriteLine("Receive error: " & ex.Message)
            HandleConnectionStateChange(client.State)
        End Try
    End Function

    Public Async Sub SendMessage(ByVal msg As String)
        Try
            If client Is Nothing Then Exit Sub
            If client.State <> WebSocketState.Open Then Exit Sub
            If String.IsNullOrEmpty(msg) Then Exit Sub

            Dim messageBytes As Byte() = Encoding.UTF8.GetBytes(msg)
            Dim messageBuffer As New ArraySegment(Of Byte)(messageBytes)

            Await client.SendAsync(messageBuffer, WebSocketMessageType.Text, True, cancellationToken.Token)

        Catch ex As Exception
            Console.WriteLine("Send error: " & ex.Message)
        End Try
    End Sub
    Private Async Function SendHeartbeatAsync() As Task
        Try
            While client.State = WebSocketState.Open
                Dim pingMessage As Byte() = Encoding.UTF8.GetBytes("ping")
                Await client.SendAsync(New ArraySegment(Of Byte)(pingMessage), WebSocketMessageType.Text, True, cancellationToken.Token)
                Console.WriteLine("Sent: ping")
                Await Task.Delay(10000) ' Kirim ping setiap 5 detik
            End While
        Catch ex As Exception
            Console.WriteLine("Error sending heartbeat: " & ex.Message)
        End Try
    End Function

    Public Async Sub DisconnectAsync()
        If client IsNot Nothing AndAlso client.State = WebSocketState.Open Then
            Await client.CloseAsync(WebSocketCloseStatus.NormalClosure, "Closing", cancellationToken.Token)
            Console.WriteLine("Disconnected from WebSocket server.")
        End If
    End Sub

    ' Fungsi untuk menangani perubahan status koneksi
    Private Sub HandleConnectionStateChange(state As WebSocketState)
        Console.WriteLine("Connection State: " & state.ToString())
        RaiseEvent ConnectionStateChanged(state)
        If state = WebSocketState.Closed OrElse state = WebSocketState.Aborted Then
            ReconnectAsync()
        End If
    End Sub


    ' Fungsi untuk mencoba reconnect jika koneksi terputus
    Private Async Sub ReconnectAsync()
        Try
            Console.WriteLine("Attempting to reconnect...")

            If client IsNot Nothing Then client.Dispose()

            cancellationToken = New CancellationTokenSource() ' 🔥 RESET TOKEN
            client = New ClientWebSocket()

            Await client.ConnectAsync(uri, cancellationToken.Token)

            IsConnected = True

            Console.WriteLine("Reconnected.")
            Await ReceiveMessagesAsync()

        Catch ex As Exception
            Console.WriteLine("Reconnect failed: " & ex.Message)
        End Try
    End Sub

End Class





