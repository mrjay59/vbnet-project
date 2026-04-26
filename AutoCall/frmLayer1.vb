Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.NetworkInformation
Imports Newtonsoft.Json.Linq

Public Class frmLayer1
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New System.Drawing.Point
    Private dbConn As New ClassConnect
    Private dbJson As New ClassJson
    Private mrjay59 As New mrjay59
    Private Async Function CekseasionAsync(sender As Object, e As EventArgs) As Task

        Dim DRes As String = Await Task.Run(Function() mrjay59.DataUser)

        If String.IsNullOrWhiteSpace(DRes) Then
            MsgBox("Response Tidak ada dari Server login ulang/ gunakan jaringan lain")
            Exit Function
        End If

        Dim json As JObject = Nothing

        Try
            json = JObject.Parse(DRes)
        Catch ex As Exception
            MsgBox("JSON invalid")
            Exit Function
        End Try

        Dim Result = dbJson.Json2aray(DRes)
        If Result("status")("code") = 1 Then
            For Each item In Result("error")
                MsgBox(item.ToString())
            Next

        Else
            Dim statoken As Boolean = Result("body")("token")("statexp")

            If (statoken = False) Then
                Form1.BukaMenu("home", sender, e)
                Form1.Show()
                Me.TopLevel = False
            Else
                Me.BtnLogin_Click(sender, e)
            End If

        End If





    End Function

    Private Sub PanelHeader_MouseDown(sender As Object, e As MouseEventArgs) Handles PanelHeader.MouseDown
        allowCoolMove = True
        myCoolPoint = New System.Drawing.Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub PanelHeader_MouseMove(sender As Object, e As MouseEventArgs) Handles PanelHeader.MouseMove
        If allowCoolMove = True Then
            Me.Location = New System.Drawing.Point(Me.Location.X + e.X - myCoolPoint.X, Me.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub PanelHeader_MouseUp(sender As Object, e As MouseEventArgs) Handles PanelHeader.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
        PgLoading.Close()
    End Sub

    Private Async Sub frmLayer1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try

            ' tampilkan dulu UI
            Await Task.Delay(300)

            If Not dbConn.IsInternetAvailable() Then
                MsgBox("Cek Koneksi Internet Anda")
                Exit Sub
            End If
            BtnLogin_Click(sender, e)
            '  Await CekseasionAsync(sender, e)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        lbheader.Text = "Form Login"
        BtnSignup.BackColor = Color.FromArgb(80, 65, 190)
        BtnLogin.BackColor = Color.Transparent
        Dim page As New frmLogin
        PanelPusat.Controls.Clear()
        page.Dock = DockStyle.Fill
        PanelPusat.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub BtnSignup_Click(sender As Object, e As EventArgs) Handles BtnSignup.Click
        lbheader.Text = "Form SignUp"
        BtnSignup.BackColor = Color.Transparent
        BtnLogin.BackColor = Color.FromArgb(80, 65, 190)
        'Dim page As New frmSignUp
        'PanelPusat.Controls.Clear()
        'page.Dock = DockStyle.Fill
        'PanelPusat.Controls.Add(page)
        'page.Show()

        Dim page As New PgValidation
        page.ShowDialog()

    End Sub

    Private Sub BtnLogin_Paint(sender As Object, e As PaintEventArgs) Handles BtnLogin.Paint
        Dim width = BtnLogin.Width
        Dim Height = BtnLogin.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnLogin.Region = New Region(path)
    End Sub

    Private Sub BtnSignup_Paint(sender As Object, e As PaintEventArgs) Handles BtnSignup.Paint
        Dim width = BtnSignup.Width
        Dim Height = BtnSignup.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnSignup.Region = New Region(path)
    End Sub
End Class