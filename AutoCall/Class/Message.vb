Public Class Message
    Public Enum MessageType
        Inbox
        Outbox
    End Enum

    Public Enum DeliveryStatus
        Sending
        Sent
        Delivered
        Read
        Failed
        None
    End Enum

    Public Property Content As String
    Public Property ContentText As String
    Public Property Sender As String
    Public Property Time As DateTime
    Public Property Type As MessageType
    Public Property Status As DeliveryStatus
    Public Property IsRead As Boolean

    Public Enum ContentType
        Text
        Image
        Audio
    End Enum

    Public Property MediaType As ContentType
End Class