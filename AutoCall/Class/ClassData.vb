Public Class ClassData
    Inherits EventArgs

    Public Property Data As String

    Public Sub New(data As String)
        Me.Data = data
    End Sub
End Class




Public Class DataItem
    Public Property aichat_number As String
    Public Property aichat_name As String

    Public Property value As String

    ' Override ToString() agar ComboBox menampilkan 'name'
    Public Overrides Function ToString() As String
        Return Me.aichat_name
    End Function

End Class