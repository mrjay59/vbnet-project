Public Class Message

    Public Enum MessageType
        Inbox
        Outbox
    End Enum

    Public Enum MediaTypes
        Text
        Image
        Audio
        Video
        Document
        Sticker
        Unknown
    End Enum

    Public Enum AckStatus
        Pending = 0
        Server = 1
        Delivered = 2
        Read = 3
        Played = 4
        Failed = -1
    End Enum

    Public Property MsgId As String

    Public Property FromMe As Boolean

    Public Property Sender As String

    Public Property Group As String


    Public Property Timestamp As DateTime

    Public Property ContentText As String

    Public Property HasMedia As Boolean

    Public Property Media As String

    Public Property AckName As String

    Public Property Ack As Integer

    Public Property Source As String

    Public Property Location As String

    Public Property Id As String

    Public Property Type As MessageType

    Public Property MediaType As MediaTypes

    Public Property MediaUrl As String

    Public Property Status As AckStatus

End Class