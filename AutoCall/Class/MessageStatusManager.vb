Public Class MessageStatusManager
    Private WithEvents timer As New Timer()
    Private messages As New Dictionary(Of Guid, ChatBubble)

    Public Sub New()
        timer.Interval = 1000 ' Cek setiap 1 detik
        timer.Start()
    End Sub

    Public Sub TrackMessage(bubble As ChatBubble)
        Dim id As Guid = Guid.NewGuid()
        messages.Add(id, bubble)

        ' Simulasikan proses pengiriman
        Task.Delay(1500).ContinueWith(Sub()
                                          If bubble.Status = ChatBubble.MessageStatus.Sending Then
                                              bubble.Status = ChatBubble.MessageStatus.Sent

                                              ' Simulasi diterima
                                              Task.Delay(1000).ContinueWith(Sub()
                                                                                bubble.Status = ChatBubble.MessageStatus.Delivered

                                                                                ' Simulasi dibaca
                                                                                Task.Delay(2000).ContinueWith(Sub()
                                                                                                                  bubble.Status = ChatBubble.MessageStatus.Read
                                                                                                                  messages.Remove(id)
                                                                                                              End Sub, TaskScheduler.FromCurrentSynchronizationContext())
                                                                            End Sub, TaskScheduler.FromCurrentSynchronizationContext())
                                          End If
                                      End Sub, TaskScheduler.FromCurrentSynchronizationContext())
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        ' Cek pesan gagal (timeout 10 detik)
        For Each kvp In messages.ToList()
            If Date.Now.Subtract(kvp.Value.MessageTime).TotalSeconds > 10 AndAlso
               kvp.Value.Status = ChatBubble.MessageStatus.Sending Then

                kvp.Value.Status = ChatBubble.MessageStatus.Failed
                messages.Remove(kvp.Key)
            End If
        Next
    End Sub
End Class