Imports System.Drawing.Drawing2D

Public Class RoundedPanel
    Inherits Panel

    Public Enum RoundStyle
        All
        Left
        Right
        Top
        Bottom
        None
    End Enum

    Private _cornerRadius As Integer = 10
    Private _roundingStyle As RoundStyle = RoundStyle.All
    Private _borderColor As Color = Color.Gray
    Private _borderWidth As Integer = 1
    Private _autoSizeHeight As Boolean = False

    Public Property CornerRadius As Integer
        Get
            Return _cornerRadius
        End Get
        Set(value As Integer)
            _cornerRadius = value
            Me.Invalidate()
        End Set
    End Property

    Public Property RoundingStyle As RoundStyle
        Get
            Return _roundingStyle
        End Get
        Set(value As RoundStyle)
            _roundingStyle = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor As Color
        Get
            Return _borderColor
        End Get
        Set(value As Color)
            _borderColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderWidth As Integer
        Get
            Return _borderWidth
        End Get
        Set(value As Integer)
            _borderWidth = value
            Me.Invalidate()
        End Set
    End Property

    Public Property AutoSizeHeight As Boolean
        Get
            Return _autoSizeHeight
        End Get
        Set(value As Boolean)
            _autoSizeHeight = value
            If value Then Me.Height = CalculateTotalHeight()
        End Set
    End Property

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim rect As New Rectangle(0, 0, Me.Width, Me.Height)
        rect.Inflate(-_borderWidth, -_borderWidth)

        Using path As GraphicsPath = GetRoundedRectPath(rect, _cornerRadius, _roundingStyle)
            ' Draw background
            Using brush As New SolidBrush(Me.BackColor)
                e.Graphics.FillPath(brush, path)
            End Using

            ' Draw border
            If _borderWidth > 0 Then
                Using pen As New Pen(_borderColor, _borderWidth)
                    e.Graphics.DrawPath(pen, path)
                End Using
            End If
        End Using
    End Sub

    Private Function GetRoundedRectPath(rect As Rectangle, radius As Integer, style As RoundStyle) As GraphicsPath
        Dim path As New GraphicsPath()

        Dim diameter As Integer = radius * 2

        Select Case style
            Case RoundStyle.All
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90) ' Top-left
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90) ' Top-right
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90) ' Bottom-right
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90) ' Bottom-left

            Case RoundStyle.Left
                path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90) ' Top-left
                path.AddLine(rect.Right, rect.Y, rect.Right, rect.Bottom) ' Top-right to bottom-right
                path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90) ' Bottom-left

            Case RoundStyle.Right
                path.AddLine(rect.X, rect.Y, rect.Right - diameter, rect.Y) ' Top-left to top-right
                path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90) ' Top-right
                path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90) ' Bottom-right
                path.AddLine(rect.X, rect.Bottom, rect.Right - diameter, rect.Bottom) ' Bottom-left to bottom-right

            Case Else
                path.AddRectangle(rect)
        End Select

        path.CloseFigure()
        Return path
    End Function

    Private Function CalculateTotalHeight() As Integer
        If Me.Controls.Count = 0 Then Return 0

        Dim totalHeight As Integer = Me.Padding.Top + Me.Padding.Bottom
        Dim maxRightColumnHeight As Integer = 0

        For Each ctrl As Control In Me.Controls
            totalHeight += ctrl.Height + ctrl.Margin.Top + ctrl.Margin.Bottom
        Next

        Return totalHeight
    End Function

    Protected Overrides Sub OnControlAdded(e As ControlEventArgs)
        MyBase.OnControlAdded(e)
        If _autoSizeHeight Then Me.Height = CalculateTotalHeight()
    End Sub

    Protected Overrides Sub OnControlRemoved(e As ControlEventArgs)
        MyBase.OnControlRemoved(e)
        If _autoSizeHeight Then Me.Height = CalculateTotalHeight()
    End Sub

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        Me.Invalidate()
    End Sub
End Class