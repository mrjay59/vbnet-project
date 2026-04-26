Imports System.ComponentModel
Imports System.Drawing

Public Class PlaceholderTextBox
    Inherits TextBox

    Private _placeholder As String = "Placeholder"
    Private _isPlaceholderActive As Boolean = True

    <Category("Behavior"), Description("Teks placeholder yang muncul saat kosong.")>
    Public Property PlaceholderText As String
        Get
            Return _placeholder
        End Get
        Set(value As String)
            _placeholder = value
            ShowPlaceholder()
        End Set
    End Property

    Public Sub New()
        MyBase.New()
        ShowPlaceholder()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        ShowPlaceholder()
    End Sub

    Protected Overrides Sub OnGotFocus(e As EventArgs)
        MyBase.OnGotFocus(e)
        If _isPlaceholderActive Then
            Me.Text = ""
            Me.ForeColor = SystemColors.WindowText
            _isPlaceholderActive = False
        End If
    End Sub

    Protected Overrides Sub OnLostFocus(e As EventArgs)
        MyBase.OnLostFocus(e)
        ShowPlaceholder()
    End Sub

    Private Sub ShowPlaceholder()
        If String.IsNullOrEmpty(Me.Text) AndAlso Not Me.Focused Then
            _isPlaceholderActive = True
            Me.Text = _placeholder
            Me.ForeColor = Color.Gray
        End If
    End Sub

    Public Function IsPlaceholderVisible() As Boolean
        Return _isPlaceholderActive
    End Function

    Protected Overrides Sub OnTextChanged(e As EventArgs)
        MyBase.OnTextChanged(e)
        If Not _isPlaceholderActive AndAlso String.IsNullOrEmpty(Me.Text) Then
            ShowPlaceholder()
        End If
    End Sub
End Class
