Public Class WAServerForm
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property


End Class