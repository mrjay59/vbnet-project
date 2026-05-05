Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Org.BouncyCastle.Utilities
Imports QRCoder
Imports SIPSorcery.SIP

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

    Private Sub PgDaServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BtnLocal_Click(sender, e)
    End Sub

    Private Sub BtnLocal_Click(sender As Object, e As EventArgs) Handles BtnLocal.Click
        Label1.Text = "Form WA SCANQR"
        TabWAScanQr()

        LoadDataWA("wascanqr", "applist")

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

    Private Sub LoadDataWA(ByVal tipe As String, ByVal data As String)
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", tipe)
        param.Add("data", data)

        Dim response = mjy.getAkunAkses(param)

        Dim resp2arr = jsonpa.Json2aray(response)

        If (resp2arr("status")("code") = 0) Then
            Dim ax = 0
            For Each item In resp2arr("body")
                ax = ax + 1
                Dim appkode = item("appkode").ToString
                Dim STATE = item("state").ToString
                Dim state_exp As Boolean = item("state_exp")
                Dim datexp = item("datexp").ToString
                Dim state_wa = item("state_wa").ToString
                Dim subscribe = item("subscribe").ToString


                ' Tambah row dulu
                Dim rowIndex As Integer = DatTable1.Rows.Add(False, ax, appkode, datexp, STATE, state_wa)

                'DatTable1.Rows(rowIndex).Cells("CheckBoxColumn").Tag = 
                ' Jika BUSY
                If STATE = "BUSY" Then

                    ' disable checkbox / cell kolom pertama
                    DatTable1.Rows(rowIndex).Cells("CheckBoxColumn").ReadOnly = True
                    DatTable1.Rows(rowIndex).Cells("CheckBoxColumn").Value = False

                    ' warna merah seluruh baris
                    DatTable1.Rows(rowIndex).DefaultCellStyle.BackColor = Color.Red
                    DatTable1.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black

                End If

                ' Jika BUSY
                If state_exp = True Then

                    ' disable checkbox / cell kolom pertama
                    DatTable1.Rows(rowIndex).Cells("CheckBoxColumn").ReadOnly = True
                    DatTable1.Rows(rowIndex).Cells("CheckBoxColumn").Value = False

                    ' warna merah seluruh baris
                    DatTable1.Rows(rowIndex).DefaultCellStyle.BackColor = Color.IndianRed
                    DatTable1.Rows(rowIndex).DefaultCellStyle.ForeColor = Color.Black

                End If

            Next

        End If

    End Sub

    Private Sub BtnClould_Click(sender As Object, e As EventArgs) Handles BtnClould.Click
        Label1.Text = "Form WA CLOULD"
        LoadDataWA("waserver", "applist")

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

    Private Sub CheckAll()
        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = "Pilih"
        checkBoxColumn.Name = "CheckBoxColumn"
        checkBoxColumn.Width = 50
        DatTable1.Columns.Insert(0, checkBoxColumn)
    End Sub

    Private Sub TabWAScanQr()
        DatTable1.Columns.Clear()
        DatTable1.Rows.Clear()
        DatTable1.AutoGenerateColumns = False


        CheckAll()

        ' Buat kolom secara dinamis
        Dim kolom As New DataGridViewTextBoxColumn()
        Dim kolomb As New DataGridViewButtonColumn()
        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "id"
        kolom.HeaderText = "NO"
        kolom.DataPropertyName = "id"
        kolom.Width = 70
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "appname"
        kolom.HeaderText = "Nama SEASSION"
        kolom.DataPropertyName = "appname"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "expired"
        kolom.HeaderText = "EXPIRED"
        kolom.DataPropertyName = "expired"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "state"
        kolom.HeaderText = "STATE"
        kolom.DataPropertyName = "state"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "state_wa"
        kolom.HeaderText = "STATE WA"
        kolom.DataPropertyName = "state_wa"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        Dim btnConfig As New DataGridViewButtonColumn
        btnConfig.FlatStyle = FlatStyle.Flat
        btnConfig.HeaderText = "ATUR"
        btnConfig.Text = "EDIT"
        btnConfig.Name = "btnConfig"
        btnConfig.UseColumnTextForButtonValue = True

        DatTable1.Columns.Add(btnConfig)


    End Sub

    Private Sub BtnAddAkuns_Click(sender As Object, e As EventArgs) Handles BtnAddAkuns.Click
        Label1.Text = "Form Create AKUN WA"
        LoadDataWA("alls_wa", "akun")

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

    Private Sub DatTable1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable1.CellContentClick
        Dim colindex = e.ColumnIndex
        Dim rowindex = e.RowIndex
        Dim nameS As String = DatTable1.Rows(rowindex).Cells("appname").Value
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        ' pastikan baris valid
        If rowindex < 0 Then Exit Sub

        ' kolom checkbox (0)
        If colindex = 0 Then
            ' ambil nilai lama
            Dim currentValue As Boolean = False
            If DatTable1.Rows(rowindex).Cells("CheckBoxColumn").Value IsNot Nothing Then
                currentValue = CBool(DatTable1.Rows(rowindex).Cells("CheckBoxColumn").Value)
            End If
            ' toggle nilai
            Dim newValue As Boolean = Not currentValue

            ' update nilai checkbox
            DatTable1.Rows(rowindex).Cells("CheckBoxColumn").Value = newValue

            ' jika user uncheck (false) → keluar saja
            If (newValue) Then
                DatTable1.Rows(rowindex).DefaultCellStyle.ForeColor = Color.Black
                DatTable1.Rows(rowindex).DefaultCellStyle.BackColor = Color.OrangeRed
            Else
                DatTable1.Rows(rowindex).DefaultCellStyle.ForeColor = Color.White
                DatTable1.Rows(rowindex).DefaultCellStyle.BackColor = Color.Black
            End If

        ElseIf colindex = 6 Then
            Dim NObj As New JObject
            NObj.Add("title", $"EDIT Seassion {nameS}")
            NObj.Add("platform", "wascanqr")
            NObj.Add("name", nameS)
            NObj.Add("username", username)
            Dim page As New pgSetSession(NObj.ToString)
            page.ShowDialog()
        End If


    End Sub

    Private Sub BtnReqkode_Click(sender As Object, e As EventArgs) Handles BtnReqkode.Click

    End Sub
End Class