Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports QRCoder

Public Class PgDaServer

    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private mjy As New mrjay59
    Public Event SendDataJson As EventHandler(Of ClassData)
    Private WithEvents paging As New PagingControl()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    ' Function untuk memeriksa apakah kontrol dengan nama tertentu sudah ada di Panel

    Private Sub PgDaServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnLocal_Click(sender, e)
    End Sub


    Private Sub BtnLocal_Click(sender As Object, e As EventArgs) Handles BtnLocal.Click
        Label1.Text = "Form WA SCANQR"
        LoadDataWA("wascanqr")

        BtnLocal.BackColor = Color.Transparent
        BtnClould.BackColor = Color.Gray
        BtnAddAkuns.BackColor = Color.Gray

        Panelgb.Visible = True
        Dim x = BtnLocal.Location.X
        Dim y = BtnLocal.Location.Y + BtnLocal.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnLocal.Width

        Try
            Dim page As New WAScanQrForm
            PnAddForm.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PnAddForm.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDataWA(ByVal tipe As String)
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", tipe)

        Dim response = mjy.getAkunAkses(param)


    End Sub

    Private Sub BtnClould_Click(sender As Object, e As EventArgs) Handles BtnClould.Click
        Label1.Text = "Form WA CLOULD"
        LoadDataWA("waserver")

        BtnLocal.BackColor = Color.Gray
        BtnClould.BackColor = Color.Transparent
        BtnAddAkuns.BackColor = Color.Gray

        Panelgb.Visible = True
        Dim x = BtnClould.Location.X
        Dim y = BtnClould.Location.Y + BtnClould.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnClould.Width

        Try
            Dim page As New WAServerForm
            PnAddForm.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PnAddForm.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddAkuns_Click(sender As Object, e As EventArgs) Handles BtnAddAkuns.Click
        Label1.Text = "Form Create AKUN WA"
        LoadDataWA("alls_wa")

        BtnLocal.BackColor = Color.Gray
        BtnClould.BackColor = Color.Gray
        BtnAddAkuns.BackColor = Color.Transparent

        Panelgb.Visible = True
        Dim x = BtnAddAkuns.Location.X
        Dim y = BtnAddAkuns.Location.Y + BtnAddAkuns.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnAddAkuns.Width

        Try
            Dim page As New WAServerForm
            PnAddForm.Controls.Clear()
            page.TopLevel = False
            page.SendDataUser = DatR
            page.Dock = DockStyle.Fill
            PnAddForm.Controls.Add(page)
            page.Show()


        Catch ex As Exception

        End Try
    End Sub
End Class