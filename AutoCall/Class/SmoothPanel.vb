Public Class SmoothPanel
    Inherits Panel

    Public Sub New()
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
                   ControlStyles.AllPaintingInWmPaint Or
                   ControlStyles.UserPaint, True)
        Me.UpdateStyles()
    End Sub

    Protected Overrides Sub OnScroll(e As ScrollEventArgs)
        Me.Invalidate()
        MyBase.OnScroll(e)
    End Sub
End Class