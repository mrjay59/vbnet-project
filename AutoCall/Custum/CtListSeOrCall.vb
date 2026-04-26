Imports System.Drawing.Drawing2D
Imports Newtonsoft.Json.Linq

Public Class CtListSeOrCall
    Public Event DataSelected As EventHandler(Of ClassData)
    Private Sub Chk_CheckedChanged(sender As Object, e As EventArgs) Handles Chk.CheckedChanged
        Dim chetru = Chk.Checked
        Dim Name = lbSeOrCa.Text.Trim
        Dim pathx = lbpath.Text.Trim
        Dim prefix = lbpath.Tag

        Dim NeData As New JObject
        If (chetru = False) Then
            Me.BackColor = Color.FromArgb(41, 68, 77)
            '  Chkedwa.Checked = True
            NeData.Add("NamExe", Name)
            NeData.Add("PathEx", pathx)
            NeData.Add("prefix", prefix)
            NeData.Add("chk", False)
            NeData.Add("fun", "lolistDialler")
            Dim ObjString = NeData.ToString

            ' Raise the event and pass the selected data
            RaiseEvent DataSelected(Me, New ClassData(ObjString))
            'Console.WriteLine(ObjString)
        End If

        If (chetru = True) Then
            Me.BackColor = Color.FromArgb(41, 168, 77)
            NeData.Add("NamExe", Name)
            NeData.Add("PathEx", pathx)
            NeData.Add("prefix", prefix)
            NeData.Add("chk", True)
            NeData.Add("fun", "lolistDialler")
            Dim ObjString = NeData.ToString

            RaiseEvent DataSelected(Me, New ClassData(ObjString))
            '  Chkedwa.Checked = False
        End If
    End Sub

    Private Sub CtListSeOrCall_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim width = Me.Width
        Dim Height = Me.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)
    End Sub
End Class
