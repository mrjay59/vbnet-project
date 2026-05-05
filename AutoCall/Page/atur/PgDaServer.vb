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

                Dim appkode As String = String.Empty
                Dim STATE As String = String.Empty
                Dim state_exp As Boolean
                Dim datexp As String = String.Empty
                Dim state_wa As String = String.Empty
                Dim subscribe As String = String.Empty
                Dim navendor As String = String.Empty
                Dim rowIndex As Integer

                Dim akunid As String = String.Empty
                Dim concurrent As Integer
                Dim appcount As Integer
                Dim idle As String = String.Empty
                Dim create As String = String.Empty

                If (data = "akun") Then
                    akunid = item("akunid").ToString
                    concurrent = item("concurrent")
                    appcount = item("appcount")
                    idle = item("idle").ToString
                    STATE = item("state").ToString
                    create = item("create").ToString



                    ' Tambah row dulu
                    rowIndex = DatTable1.Rows.Add(False, ax, akunid, concurrent, appcount, idle, STATE)
                Else
                    appkode = item("appkode").ToString
                    STATE = item("state").ToString
                    state_exp = item("state_exp")
                    datexp = item("datexp").ToString
                    state_wa = item("state_wa").ToString
                    subscribe = item("subscribe").ToString
                    navendor = item("vendr").ToString

                    ' Tambah row dulu
                    rowIndex = DatTable1.Rows.Add(False, ax, appkode, datexp, STATE, state_wa)
                    Dim obj As New JObject
                    obj.Add("name", appkode)
                    obj.Add("navendor", navendor)
                    DatTable1.Rows(rowIndex).Cells("CheckBoxColumn").Tag = obj.ToString
                End If





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
        TabWAScanQr()

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

    Private Sub TabWAAkunID()
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
        kolom.Name = "akunid"
        kolom.HeaderText = "AKUN ID"
        kolom.DataPropertyName = "akunid"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "max_id"
        kolom.HeaderText = "MAX WA"
        kolom.DataPropertyName = "max_id"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "TOTWA"
        kolom.HeaderText = "Total WA"
        kolom.DataPropertyName = "TOTWA"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "idle"
        kolom.HeaderText = "idle"
        kolom.DataPropertyName = "idle"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "state"
        kolom.HeaderText = "state"
        kolom.DataPropertyName = "state"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


    End Sub

    Private Sub BtnAddAkuns_Click(sender As Object, e As EventArgs) Handles BtnAddAkuns.Click
        Label1.Text = "Form Create AKUN WA"

        TabWAAkunID()


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
        proses_chk("rqRegcode")
    End Sub

    Private Sub BtnQr_Click(sender As Object, e As EventArgs) Handles BtnQr.Click
        proses_chk("rqQrkode")
    End Sub

    Private Sub proses_chk(ByVal tipe As String)
        If (DatTable1.Rows.Count = 0) Then
            MessageBox.Show("Data kosong")
            Exit Sub
        End If

        Dim selectedRows = DatTable1.Rows.Cast(Of DataGridViewRow)().
    Where(Function(r) Not r.IsNewRow AndAlso
          r.Cells("CheckBoxColumn").Value IsNot Nothing AndAlso
          Convert.ToBoolean(r.Cells("CheckBoxColumn").Value))

        If Not selectedRows.Any() Then
            MessageBox.Show("Silahkan pilih minimal 1 data")
            Exit Sub
        End If

        Dim newData As New JObject()
        Dim newDataArray As New JArray()

        For Each row As DataGridViewRow In DatTable1.Rows

            If Not row.IsNewRow Then

                Dim chk As Boolean = False

                If row.Cells("CheckBoxColumn").Value IsNot Nothing Then
                    chk = Convert.ToBoolean(row.Cells("CheckBoxColumn").Value)
                End If

                If chk Then

                    Dim tagValue = row.Cells("CheckBoxColumn").Tag

                    If tagValue IsNot Nothing Then

                        ' 🔥 parse string JSON ke JObject
                        Dim obj As JObject = JObject.Parse(tagValue.ToString())

                        newDataArray.Add(obj)

                    End If

                End If

            End If

        Next

        newData.Add("body", newDataArray)


        If (tipe = "rqQrkode") Then
            Dim page As New pgMultiBarcode()
            page.LoadBarcodeMulti(newData.ToString)
            page.SendDataUser = DatR

            page.ShowDialog()
        ElseIf (tipe = "rqRegcode") Then
            Dim page As New pgMultiBarcode()
            page.LoadMultiRegKode(newData.ToString)
            page.SendDataUser = DatR

            page.ShowDialog()

        ElseIf (tipe = "rqstart") Then

        ElseIf (tipe = "rqrestart") Then

        ElseIf (tipe = "rqstop") Then


        End If

    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        proses_chk("rqstart")
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        proses_chk("rqstop")
    End Sub

    Private Sub BtnRestart_Click(sender As Object, e As EventArgs) Handles BtnRestart.Click
        proses_chk("rqrestart")
    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        proses_chk("rqlogout")
    End Sub
End Class