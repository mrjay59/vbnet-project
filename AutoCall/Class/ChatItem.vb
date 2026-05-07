
Imports Newtonsoft.Json.Linq

Public Class ChatItem
    Public Property Id As Integer
    Public Property PhoneNumber As String
    Public Property PhoneSender As String
    Public Property SessionId As String
    Public Property Service As String
    Public Property Username As String
    Public Property Platform As String
    Public Property Numto As String
    Public Property LastMessage As String
    Public Property Time As DateTime
    Public Property UnreadCount As Integer
    Public Property Status As MessageStatus
    Public Property IsSelected As Boolean = False
    Public Property Conversation As New List(Of Message)
End Class

Public Enum MessageStatus
    Sent
    Delivered
    Read
    Failed
End Enum