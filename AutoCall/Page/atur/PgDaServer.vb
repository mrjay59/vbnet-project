Imports System.Diagnostics.Eventing.Reader
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Google.Apis.Sheets.v4.Data
Imports Microsoft.VisualBasic.ApplicationServices
Imports Mysqlx.Datatypes
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Schema
Imports Org.BouncyCastle.Asn1.Crmf
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
    Private qrControls As New Dictionary(Of String, UCScanQR)
    Private qrManagers As New Dictionary(Of String, QRManager)

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
        PanAksi.Enabled = True
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
                    rowIndex = DatTable1.Rows.Add(ax, akunid, concurrent, appcount, idle, STATE)
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
        PanAksi.Enabled = False
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


        ' CheckAll()

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
        PanAksi.Enabled = False
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
            Dim page As New WACreateAForm
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
            Dim nameS As String = DatTable1.Rows(rowindex).Cells("appname").Value
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
        Dim chkint As Integer = 0
        For Each row As DataGridViewRow In DatTable1.Rows

            If Not row.IsNewRow Then

                Dim chk As Boolean = False

                If row.Cells("CheckBoxColumn").Value IsNot Nothing Then
                    chk = Convert.ToBoolean(row.Cells("CheckBoxColumn").Value)
                End If

                If chk Then
                    chkint = chkint + 1
                    Dim tagValue = row.Cells("CheckBoxColumn").Tag

                    If tagValue IsNot Nothing Then

                        ' 🔥 parse string JSON ke JObject
                        Dim obj As JObject = JObject.Parse(tagValue.ToString())
                        obj.Add("tipe", tipe)
                        newDataArray.Add(obj)

                    End If

                End If

            End If

        Next

        newData.Add("body", newDataArray)

        If ((chkint = 1) And (tipe = "rqQrkode")) Or ((chkint = 1) And (tipe = "rqRegcode")) Then
            showQR_One(newData.ToString)
        Else

            If ((tipe = "rqQrkode") Or (tipe = "rqRegcode")) Then
                Dim page As New pgMultiBarcode()
                page.LoadBarcodeMulti(newData.ToString)
                page.SendDataUser = DatR

                page.ShowDialog()

            Else
                rq_seassions(newData.ToString)
            End If
        End If
    End Sub

    Private Sub rq_seassions(newData As String)
        Dim PObj = jsonpa.Json2aray(newData)
        For Each item In PObj("body")
            Dim nama = item("name").ToString
            Dim navendor = item("navendor").ToString
            Dim tipe = item("tipe").ToString


            Dim param As New JObject
            param.Add("action", tipe.Replace("rq", "").ToString)
            param.Add("name", nama)
            param.Add("navendor", navendor)

            Dim res = WApp.OnSeassion(param)

            HandleTab(res)
        Next
    End Sub

    Private Sub showQR_One(toString As String)
        AddHandler WSManager.Client.MessageReceived, AddressOf wsClient_MessageReceived

        Dim PObj = jsonpa.Json2aray(toString)

        qrManagers.Clear()
        qrControls.Clear()
        PnDScanQr.Controls.Clear()
        Dim ai = 0
        For Each item In PObj("body")

            Dim nama = item("name").ToString
            Dim navendor = item("navendor").ToString
            Dim tipe = item("tipe").ToString
            ai += 1

            Dim pin As Point

            pin = New Point(74, 1)

            ' ======================
            ' CREATE UI
            ' ======================
            Dim ScanQr As New UCScanQR

            ScanQr.Location = pin
            ScanQr.LbWAnm.Text = nama
            ScanQr.Label1.Visible = False
            ScanQr.TxtNoWA.Visible = False
            ScanQr.BtnReqKode.Visible = False
            ScanQr.LblR.Visible = True
            ScanQr.LblR.Text = "Wait.."
            ScanQr.lstLog.Items.Add($"[Sesi : {nama}] Wait...")

            PnDScanQr.Controls.Add(ScanQr)

            If (tipe = "rqQrkode") Then
                ' ======================
                ' CREATE MANAGER
                ' ======================
                Dim manager As New QRManager(nama, navendor, ScanQr.picQRCode)

                qrManagers.Add(nama, manager)
                qrControls.Add(nama, ScanQr)

                ' ======================
                ' BIND LOG EVENT (HARUS DI ATAS)
                ' ======================
                AddHandler manager.OnLog,
                Sub(msg)
                    HandleLog(nama, msg)
                End Sub

                ' ======================
                ' BARU JALANKAN
                ' ======================
                manager.OnScanRequired()
            Else
                ScanQr.LblR.Visible = False
                ScanQr.Label1.Visible = True
                ScanQr.TxtNoWA.Visible = True
                ScanQr.BtnReqKode.Visible = True
                ScanQr.lstLog.Items.Add($"[Masukan No WA Exp:6281xx")
                ' ======================
                ' EVENT BUTTON REQUEST CODE
                ' ======================
                AddHandler ScanQr.BtnReqKode.Click,
                 Sub(s, ev)

                     Try

                         Dim nomor = ScanQr.TxtNoWA.Text.Trim()
                         ScanQr.BtnReqKode.Enabled = True
                         If String.IsNullOrEmpty(nomor) Then
                             ScanQr.lstLog.Items.Add("Nomor WA tidak boleh kosong")
                             Exit Sub
                         End If

                         ScanQr.lstLog.Items.Add($"[Sesi : {nama}] Request code ke {nomor}...")


                         Dim param As New JObject
                         param.Add("action", "request_code")
                         param.Add("name", nama)
                         param.Add("navendor", navendor)
                         param.Add("phoneNumber", nomor)

                         Dim res = WApp.OnSeassion(param)

                         If String.IsNullOrEmpty(res) Then
                             ScanQr.lstLog.Items.Add("Response kosong dari server")
                             Exit Sub
                         End If

                         Dim obj = JObject.Parse(res)

                         ' 🔥 HANDLE RESPONSE
                         If obj("message") IsNot Nothing Then

                             Dim status = obj("message").ToString()

                             If status.Contains("FAILED") Then
                                 ScanQr.LblR.Text = ""
                                 ScanQr.lstLog.Items.Add("Request code FAILED → logout session")
                                 ScanQr.lstLog.Items.Add("Klik Lagi Req kode")
                                 Dim objx As New JObject
                                 objx.Add("action", "logout")
                                 objx.Add("name", nama)
                                 objx.Add("navendor", navendor)

                                 ' optional restart
                                 WApp.OnSeassion(objx)

                                 Exit Sub
                             End If

                         End If

                         If obj("code") IsNot Nothing Then
                             ScanQr.LblR.Visible = True
                             ScanQr.LblR.Font = New Font(Label1.Font.FontFamily, 16, FontStyle.Bold)
                             ScanQr.LblR.Location = New Point(12, 90)
                             ScanQr.LblR.Text = obj("code").ToString
                             ScanQr.lstLog.Items.Add("KODE ANDA :" & obj("code").ToString)
                         End If


                     Catch ex As Exception
                         ScanQr.lstLog.Items.Add("Error: " & ex.Message)
                     End Try



                 End Sub
            End If

        Next
    End Sub

    Private Sub HandleTab(res As String)
        Dim jres = jsonpa.Json2aray(res)
        Dim name = jres("name").ToString
        Dim status = jres("status").ToString
        Dim presence = jres("presence").ToString
        For Each row As DataGridViewRow In DatTable1.Rows
            If Not row.IsNewRow Then
                Dim Tabseasion = row.Cells("appname").Value.ToString

                If (Tabseasion = name) Then
                    row.Cells("state").Value = presence
                    row.Cells("state_wa").Value = status
                End If

            End If
        Next
    End Sub

    Private Sub HandleLog(session As String, Message As String)

        ' log ke masing-masing UI
        If qrControls.ContainsKey(session) Then

            Dim ctrl = qrControls(session)

            If ctrl.lstLog.InvokeRequired Then
                ctrl.lstLog.Invoke(Sub()



                                       ctrl.lstLog.Items.Add(Message)

                                       If (Message.Contains("QR displayed")) Then
                                           ctrl.LblR.Visible = False
                                           ctrl.picQRCode.Visible = True
                                           ctrl.picQRCode.Size = New Point(195, 195)
                                       ElseIf (Message.Contains("QR Manager STOPPED")) Then
                                           ctrl.LblR.Visible = True
                                           ctrl.picQRCode.Visible = False
                                           ctrl.LblR.Text = "STOPPED"


                                       End If

                                       ' auto scroll
                                       ctrl.lstLog.TopIndex = ctrl.lstLog.Items.Count - 1
                                   End Sub)
            Else
                ctrl.lstLog.Items.Add(Message)

                If (Message.Contains("QR displayed")) Then
                    ctrl.LblR.Visible = False
                    ctrl.picQRCode.Visible = True
                    ctrl.picQRCode.Size = New Point(195, 195)

                ElseIf (Message.Contains("QR Manager STOPPED")) Then
                    ctrl.LblR.Visible = True
                    ctrl.picQRCode.Visible = False
                    ctrl.LblR.Text = "STOPPED"
                End If
                ctrl.lstLog.TopIndex = ctrl.lstLog.Items.Count - 1
            End If

        End If
    End Sub

    Private Sub wsClient_MessageReceived(message As String)
        Throw New NotImplementedException()
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        proses_chk("rqstart")
    End Sub

    Private Sub BtnStop_Click(sender As Object, e As EventArgs) Handles BtnStop.Click
        Dim msg = "yakin akan mau stopped ?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            proses_chk("rqstop")
        End If
    End Sub

    Private Sub BtnRestart_Click(sender As Object, e As EventArgs) Handles BtnRestart.Click


        Dim msg = "yakin akan mau restart ?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            proses_chk("rqrestart")
        End If

    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles BtnLogout.Click
        Dim msg = "yakin akan logout ?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            proses_chk("rqlogout")
        End If



    End Sub


End Class