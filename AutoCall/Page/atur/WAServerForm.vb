Public Class WAServerForm
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Public Event SendDataJson As EventHandler(Of ClassData)

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub LoadDataServerWA()
        ' 1. ATUR HEADER DULU
        Dim columns As New Dictionary(Of String, Integer) From {
        {"ID", 10},
        {"Provider", 15},
        {"Limit", 20},
        {"Nomer", 15},
        {"Prefix", 15},
        {"Aksi", 15}
    }
        DataTableControl1.AddHeader(columns)

        ' 2. ATUR UKURAN CONTROL (PENTING!)
        DataTableControl1.Size = New Size(600, 300)
        DataTableControl1.Dock = DockStyle.Fill ' Atau atur manual


    End Sub
End Class