Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports System.Threading
Imports AutoCall
Imports Newtonsoft.Json.Linq

Public Class PgKirim
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private Ap_mrjay59 As New mrjay59
    Public threadShouldStop As Boolean = False
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private DataJson = Nothing
    Public Event SendDataJson As EventHandler(Of ClassData)

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click

        Btn1.BackColor = Color.FromArgb(80, 65, 90)
        Btn2.BackColor = Color.Transparent
        Button1.BackColor = Color.Transparent
        Btn4.BackColor = Color.Transparent

        Dim x = Btn1.Location.X
        Dim y = Btn1.Location.Y + Btn1.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn1.Width
        Panelgb.Visible = True

        Dim page As New frmkirim
        PanelPusat.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        page.SendDataUser = DatR
        AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
        PanelPusat.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub Btn2_Click(sender As Object, e As EventArgs) Handles Btn2.Click
        Btn1.BackColor = Color.Transparent
        Btn2.BackColor = Color.FromArgb(80, 65, 90)
        Button1.BackColor = Color.Transparent
        Btn4.BackColor = Color.Transparent


        Dim x = Btn2.Location.X
        Dim y = Btn2.Location.Y + Btn2.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Btn2.Width
        Panelgb.Visible = True

        Dim page As New FrmTraningWA
        PanelPusat.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        page.SendDataUser = DatR

        AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
        PanelPusat.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Dim frmkirim As frmkirim = Application.OpenForms.OfType(Of frmkirim)().FirstOrDefault()
        If frmkirim IsNot Nothing Then
            ' Kirim data ke Form2
            If frmkirim.cts IsNot Nothing Then
                frmkirim.cts.Cancel()

                frmkirim.PnlogActivty.Controls.Clear()


            End If
        End If

        Me.Close()
    End Sub

    Private Sub PgKirim_Load(sender As Object, e As EventArgs) Handles Me.Load
        Btn1_Click(sender, e)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Btn1.BackColor = Color.Transparent
        Btn2.BackColor = Color.Transparent
        Button1.BackColor = Color.FromArgb(80, 65, 90)
        Btn4.BackColor = Color.Transparent
        Dim x = Button1.Location.X
        Dim y = Button1.Location.Y + Button1.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Button1.Width
        Panelgb.Visible = True

        Dim page As New PgSpamWA
        PanelPusat.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        page.SendDataUser = DatR

        AddHandler page.SendDataJson, AddressOf Form1.OnMessageSendServer
        PanelPusat.Controls.Add(page)
        page.Show()
    End Sub

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        Btn1.BackColor = Color.Transparent
        Btn2.BackColor = Color.Transparent
        Button1.BackColor = Color.Transparent
        Btn4.BackColor = Color.FromArgb(80, 65, 90)

        Dim x = Btn4.Location.X
        Dim y = Btn4.Location.Y + Btn4.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = Button1.Width
        Panelgb.Visible = True

        Dim page As New PgEmail
        PanelPusat.Controls.Clear()
        page.TopLevel = False
        page.Dock = DockStyle.Fill
        'page.SendDataUser = DatR


        PanelPusat.Controls.Add(page)
        page.Show()
    End Sub
End Class