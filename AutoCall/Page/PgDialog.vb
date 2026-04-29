Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class PgDialog
    Public Event DataSelected As EventHandler(Of ClassData)
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private Mjay59 As New mrjay59
    Private WApp As New WhatsAppClass
    Private DatR As String = String.Empty
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New System.Drawing.Point
    Private DatRec As String

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub PgDialog_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        allowCoolMove = True
        myCoolPoint = New System.Drawing.Point(e.X, e.Y)
        Me.Cursor = Cursors.SizeAll
    End Sub

    Private Sub PgDialog_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        If allowCoolMove = True Then
            Me.Location = New System.Drawing.Point(Me.Location.X + e.X - myCoolPoint.X, Me.Location.Y + e.Y - myCoolPoint.Y)
        End If
    End Sub

    Private Sub PgDialog_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        allowCoolMove = False
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CheckeData(sender As Object, e As ClassData)
        Dim DatObj = e.Data
        '  Console.WriteLine(DatObj)
        'Dim PObj = jsonpa.Json2aray(DatObj)
        'Dim func As String = PObj("fun")
        ''Console.WriteLine(DatObj)
        'If (Func = "close") Then
        '    Me.Close()
        'End If
        RaiseEvent DataSelected(Me, New ClassData(DatObj))
    End Sub

    Public Sub New(ByVal DatObj As String)

        ' This call is required by the designer.
        InitializeComponent()
        Me.DatRec = DatObj

        ' Add any initialization after the InitializeComponent() call.
        Dim PObj = jsonpa.Json2aray(DatObj)
        Dim title As String = PObj("title")
        Dim func As String = PObj("func")
        Dim user As String = PObj("username")

        lblheader.Text = title
        lblheader.Tag = func

        If (func = "Vi_Siploc") Then
            LoadSIP()
            ChkAll.Visible = False
        ElseIf (func = "Vi_Sipser") Then
            LoadSIPServ("sipserver", user)
            ChkAll.Visible = False
        ElseIf (func = "Vi_WADES") Then
            LoadWADesktop()
            ChkAll.Visible = False
        ElseIf (func = "Vi_LocAn") Then
            Dim privilageType As String = PObj("permission")
            LoadDataAndroid(privilageType, "local", user)
            'ChkAll.Visible = True
        ElseIf (func = "Vi_SerAn") Then
            Dim privilageType As String = PObj("permission")
            LoadDataAndroid(privilageType, "clould", user)
            ChkAll.Visible = False
        ElseIf (func = "Vi_Email") Then

        ElseIf (func = "Vi_WASER") Then
            '  LoadWASer
        ElseIf (func = "log_sip") Then
            Dim reqid As String = PObj("reqid")
            LoadSip_log(user, reqid)

        End If


    End Sub

    Private Sub CheckAll()
        Dim checkBoxColumn As New DataGridViewCheckBoxColumn()
        checkBoxColumn.HeaderText = "Pilih"
        checkBoxColumn.Name = "CheckBoxColumn"
        checkBoxColumn.Width = 50
        DatTable1.Columns.Insert(0, checkBoxColumn)
    End Sub

    Private Sub LoadSIPServ(ByVal type As String, ByVal user As String)

        TabSipServer()

        Dim param As New Dictionary(Of String, String)
        param.Add("username", user)
        param.Add("tipe", "sipserver")

        Dim response = Mjay59.getAkunAkses(param)
        '  Console.WriteLine(response)
        Dim resp2arr = jsonpa.Json2aray(response)

        If (resp2arr("status")("code") = 0) Then
            Dim ax = 0
            For Each item In resp2arr("body")
                Dim akunid = item("akunid").ToString
                Dim concurrent = item("concurrent").ToString
                Dim listapp = item("listapp").ToString
                ' Dim unix_exp = item("unix_exp").ToString
                ' Dim date_exp = item("date_exp").ToString
                ' Dim idle = item("idle").ToString
                ' Dim limit_perday As Integer = item("limit_perday")
                ' Dim limit_pernumber As Integer = item("limit_recall")

                Dim Datitem = jsonpa.Json2aray(listapp)
                Dim applist = Datitem("apk")
                Dim approp As IEnumerable(Of JProperty) = applist.Properties()

                For Each prop As JProperty In approp
                    Dim appname = prop.Name

                    ax = ax + 1
                    Dim appco = applist(appname)("appkode").ToString

                    Dim limit_perday_use_call As Integer = applist(appname)("limit_perday")("use_call")
                    Dim limit_perday_call As Integer = applist(appname)("limit_perday")("call")
                    Dim limit_pernumber_use_call = applist(appname)("limit_pernumber")("use_call")
                    Dim limit_pernumber_call = applist(appname)("limit_pernumber")("call")

                    Dim limit_perday = $"{limit_perday_use_call}/{limit_perday_call}"
                    Dim limit_pernumber = $"{limit_pernumber_use_call}/{limit_pernumber_call}"

                    Dim state = applist(appname)("state").ToString
                    Dim subscribe = applist(appname)("subscribe").ToString
                    Dim datexp = applist(appname)("datexp").ToString
                    Dim state_exp As Boolean = applist(appname)("state_exp")


                    ' Tambah row dulu
                    Dim rowIndex As Integer = DatTable1.Rows.Add(False, ax, akunid, appco, datexp, subscribe, limit_perday, limit_pernumber, state, state_exp)


                    ' Jika BUSY
                    If state = "BUSY" Then

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


                'Dim row As String() = New String() {False, ax, akunid, String.Join(",", arrApp.ToArray), concurrent, date_exp, limit_perday, limit_pernumber, idle}
                'DatTable1.Rows.Add(row)

            Next

        End If

    End Sub

    Private Sub TabSIPData()
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
        kolom.HeaderText = "Nama App SIP"
        kolom.DataPropertyName = "appname"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "appath"
        kolom.HeaderText = "Local Path"
        kolom.DataPropertyName = "appath"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "appuse"
        kolom.HeaderText = "Used"
        kolom.DataPropertyName = "appuse"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


    End Sub

    Private Sub TabAndroData()
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
        kolom.Name = "name"
        kolom.HeaderText = "Nama Device"
        kolom.DataPropertyName = "name"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "noserial"
        kolom.HeaderText = "SN Device"
        kolom.DataPropertyName = "noserial"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "connection"
        kolom.HeaderText = "connection"
        kolom.DataPropertyName = "connection"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "usedev"
        kolom.HeaderText = "usedev"
        kolom.DataPropertyName = "usedev"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Application"
        kolom.HeaderText = "Application"
        kolom.DataPropertyName = "Application"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "NoHp"
        kolom.HeaderText = "NoHp"
        kolom.DataPropertyName = "NoHp"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "prefix"
        kolom.HeaderText = "prefix"
        kolom.DataPropertyName = "prefix"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


    End Sub

    Private Sub TabAndroCl()
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
        kolom.HeaderText = "AkunID"
        kolom.DataPropertyName = "akunid"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "app"
        kolom.HeaderText = "app"
        kolom.DataPropertyName = "app"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "concurrent"
        kolom.HeaderText = "concurrent"
        kolom.DataPropertyName = "concurrent"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "subscribe"
        kolom.HeaderText = "subscribe"
        kolom.DataPropertyName = "subscribe"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "limit_perday"
        kolom.HeaderText = "limit_perday"
        kolom.DataPropertyName = "limit_perday"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "limit_recall"
        kolom.HeaderText = "limit_recall"
        kolom.DataPropertyName = "limit_recall"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "idle"
        kolom.HeaderText = "idle"
        kolom.DataPropertyName = "idle"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

    End Sub

    Private Sub TabSipServer()
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
        kolom.HeaderText = "AkunID"
        kolom.DataPropertyName = "akunid"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "app"
        kolom.HeaderText = "app"
        kolom.DataPropertyName = "app"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Expire"
        kolom.HeaderText = "Expired"
        kolom.DataPropertyName = "Expired"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "subscribe"
        kolom.HeaderText = "subscribe"
        kolom.DataPropertyName = "subscribe"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "limit_perday"
        kolom.HeaderText = "limit_perday"
        kolom.DataPropertyName = "limit_perday"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "limit_recall"
        kolom.HeaderText = "limit_recall"
        kolom.DataPropertyName = "limit_recall"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "idle"
        kolom.HeaderText = "idle"
        kolom.DataPropertyName = "idle"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "state_exp"
        kolom.HeaderText = "state_exp"
        kolom.DataPropertyName = "STATE_EXP"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

    End Sub

    Private Sub TabWAServer()
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
        kolom.Name = "name"
        kolom.HeaderText = "Nama WA"
        kolom.DataPropertyName = "name"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "platform"
        kolom.HeaderText = "platform"
        kolom.DataPropertyName = "platform"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "NumberWa"
        kolom.HeaderText = "Nomer WA"
        kolom.DataPropertyName = "NumberWa"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Service"
        kolom.HeaderText = "SERVICE"
        kolom.DataPropertyName = "Service"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "StateLogin"
        kolom.HeaderText = "State Login"
        kolom.DataPropertyName = "StateLogin"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Used"
        kolom.HeaderText = "Used"
        kolom.DataPropertyName = "Used"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "prefix"
        kolom.HeaderText = "prefix"
        kolom.DataPropertyName = "prefix"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

    End Sub

    Private Sub TabWADESKTOP()
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
        kolom.Name = "name"
        kolom.HeaderText = "Nama WA"
        kolom.DataPropertyName = "name"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "platform"
        kolom.HeaderText = "platform"
        kolom.DataPropertyName = "platform"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "NumberWa"
        kolom.HeaderText = "Nomer WA"
        kolom.DataPropertyName = "NumberWa"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "prefix"
        kolom.HeaderText = "prefix"
        kolom.DataPropertyName = "prefix"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "StateLogin"
        kolom.HeaderText = "State Login"
        kolom.DataPropertyName = "StateLogin"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Used"
        kolom.HeaderText = "Used"
        kolom.DataPropertyName = "Used"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)
    End Sub

    Private Sub TabLogSipCall()
        DatTable1.Columns.Clear()
        DatTable1.Rows.Clear()
        DatTable1.AutoGenerateColumns = False

        'CheckAll()
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
        kolom.Name = "waktu"
        kolom.HeaderText = "waktu"
        kolom.DataPropertyName = "waktu"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "device"
        kolom.HeaderText = "device"
        kolom.DataPropertyName = "device"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "tipeA"
        kolom.HeaderText = "Method"
        kolom.DataPropertyName = "tipeA"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "app"
        kolom.HeaderText = "app"
        kolom.DataPropertyName = "app"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "number"
        kolom.HeaderText = "number"
        kolom.DataPropertyName = "number"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "status"
        kolom.HeaderText = "status"
        kolom.DataPropertyName = "status"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "msg"
        kolom.HeaderText = "msg"
        kolom.DataPropertyName = "msg"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

    End Sub

    Private Sub LoadSip_log(ByVal user As String, ByVal reqid As String)

        TabLogSipCall()
        Dim param As New JObject
        param.Add("username", user)
        param.Add("tipe_akun", "")
        param.Add("reqid", reqid)
        param.Add("data", "detail")

        Dim response = Mjay59.callsip(param)

        Dim resp2arr = jsonpa.Json2aray(response)
        If (resp2arr("status")("code") = 0) Then
            Dim ax = 0
            For Each item In resp2arr("body")
                ax = ax + 1
                Dim device = item("device").ToString
                Dim method = item("tipe").ToString
                Dim waktu = IIf(item("waktu").ToString = "", "", item("waktu").ToString)
                Dim app = item("app").ToString
                Dim number = item("number").ToString
                Dim status = item("status").ToString
                Dim msg = item("msg").ToString

                Dim row As String() = New String() {ax, waktu, device, method, app, number, status, msg}
                DatTable1.Rows.Add(row)
            Next
        End If


    End Sub

    Private Sub LoadSIP()

        TabSIPData()

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim files As String() = IO.Directory.GetFiles(FoldeQ)
        Dim x, y, z As Integer
        x = 0
        y = 0
        z = 0
        Dim ax = 0
        For Each filex As String In files
            Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
            Dim b As String = File.ReadAllText(filex)
            Dim DatDial = jsonpa.Json2aray(b)
            Dim prefix = DatDial("prefix_dial")

            For Each item In DatDial(nameFile)
                ax = ax + 1
                Dim namexe = item("name")
                Dim pathexe = item("path")
                Dim used = item("use")
                Dim FDial = Path.GetDirectoryName(pathexe)

                Dim row As String() = New String() {False, ax, namexe, FDial, used}
                DatTable1.Rows.Add(row)

            Next


        Next
    End Sub

    Private Sub LoadDataAndroid(ByVal permission As String, ByVal type As String, ByVal user As String)

        If (type = "local") Then
            Dim apkname = dbConn.ApkProfile("name")
            TabAndroData()
            Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
            Dim FoldeQ = fodev & "\LocAn\"
            Dim files As String() = IO.Directory.GetFiles(FoldeQ)

            Dim ax = 0
            For Each filex As String In files
                Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
                Dim b As String = File.ReadAllText(filex)
                Dim Datitem = jsonpa.Json2aray(b)
                Dim name = Datitem("name")
                Dim idev = Datitem("idev")
                Dim connection = Datitem("connection")
                Dim usedev = Datitem("usedev")
                Dim applist = Datitem("apk")
                Dim approp As IEnumerable(Of JProperty) = applist.Properties()

                For Each prop As JProperty In approp
                    Dim appname = prop.Name

                    For Each item In applist(appname)

                        Dim package = item("package").ToString
                        Dim appkode = item("appkode").ToString
                        Dim privilageType As JArray = item("permission")
                        Dim useran = item("user")
                        Dim prefnumx = item("prefix")
                        Dim number As JArray = item("number")

                        If privilageType.Any(Function(x) x.ToString() = permission) Then

                            For Each itm As String In number
                                ax = ax + 1
                                Dim num = itm.Split(" ")

                                Dim row As String() = New String() {False, ax, name, idev, connection, usedev, appkode, num(0), prefnumx}
                                DatTable1.Rows.Add(row)
                            Next



                        End If

                    Next
                Next

            Next
        ElseIf (type = "clould") Then
            TabAndroCl()


            Dim param As New Dictionary(Of String, String)
            param.Add("username", user)
            param.Add("tipe", "cldevice")

            Dim response = Mjay59.getAkunAkses(param)

            Dim resp2arr = jsonpa.Json2aray(response)


            If (resp2arr("status")("code") = 0) Then
                Dim ax = 0
                For Each item In resp2arr("body")
                    Dim akunid = item("akunid").ToString
                    Dim concurrent = item("concurrent").ToString
                    Dim listapp = item("listapp").ToString
                    Dim unix_exp = item("unix_exp").ToString
                    Dim date_exp = item("date_exp").ToString
                    Dim idle = item("idle").ToString

                    Dim Datitem = jsonpa.Json2aray(listapp)
                    Dim applist = Datitem("apk")
                    Dim approp As IEnumerable(Of JProperty) = applist.Properties()
                    For Each prop As JProperty In approp
                        Dim appname = prop.Name

                        Dim privilageType As JArray = applist(appname)("permission")
                        If privilageType.Any(Function(x) x.ToString() = permission) Then
                            ax = ax + 1
                            Dim appco = applist(appname)("appkode").ToString

                            Dim limit_perday_use_call As Integer = applist(appname)("limit_perday")("use_call")
                            Dim limit_perday_call As Integer = applist(appname)("limit_perday")("call")
                            Dim limit_pernumber_use_call = applist(appname)("limit_pernumber")("use_call")
                            Dim limit_pernumber_call = applist(appname)("limit_pernumber")("call")

                            Dim limit_perday = $"{limit_perday_use_call}/{limit_perday_call}"
                            Dim limit_pernumber = $"{limit_pernumber_use_call}/{limit_pernumber_call}"


                            Dim row As String() = New String() {False, ax, akunid, appco, concurrent, date_exp, limit_perday, limit_pernumber, idle}
                            DatTable1.Rows.Add(row)
                        End If
                    Next



                Next

            End If

        End If

    End Sub

    Private Sub LoadWASer(ByVal tipe As String, ByVal username As String)
        TabWAServer()

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("platform", tipe)
        param.Add("all", "open")
        param.Add("carik", "")
        ' "wascanqr"
        Dim ListWA As String = WApp.OnListServer(param)
        Dim DatParse = jsonpa.Json2aray(ListWA)
        Dim ax = 0

        Dim datSer As JArray = DatParse("body")("data")


        For Each item In datSer
            Dim useA As Integer = item("aichat_use")
            Dim Name As String = item("aichat_name")
            Dim service = item("aichat_service")
            Dim use = IIf(useA = 0, "Tidak", "YA")
            Dim platform = item("aichat_platform")
            Dim NumberWa = item("aichat_number")
            Dim numkey = item("aichat_numkey")
            Dim kodcontry = item("aichat_CountryCode")
            Dim login = IIf(IsDBNull(item("aichat_number")), "TIDAK", "YA")

            ax = ax + 1


            Dim row As String() = New String() {False, ax, Name, platform, NumberWa, service, login, use}
            DatTable1.Rows.Add(row)


        Next

    End Sub

    Private Sub LoadWADesktop()

        TabWADESKTOP()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\wadesktop\"
        Dim FiNamJson = FoldeQ & "whatsapp.json"


        Dim b As String = ""

        If File.Exists(FiNamJson) Then
            b = File.ReadAllText(FiNamJson)

        End If

        If String.IsNullOrWhiteSpace(b) Then
            b = "[]"
        End If



        Dim DPar As JArray = Nothing
        Try
            DPar = jsonpa.Json2aray(b)
        Catch ex As Exception
            MessageBox.Show("JSON tidak valid: " & ex.Message)
            DPar = New JArray()
        End Try


        Dim ur = 0
        For Each app In DPar
            ur += 1
            Dim NamaWA As String = app("NamaWA")?.ToString()
            Dim NaApp As String = app("aplikasi")?.ToString()
            Dim NumberWA As String = app("NumberWA")?.ToString()
            Dim prefix As String = app("prefix")?.ToString()
            Dim status As String = app("status")?.ToString()
            Dim path As String = app("path")?.ToString()
            Dim used As String = app("used")?.ToString()

            Dim row As String() = New String() {False, ur, NamaWA, NaApp, NumberWA, prefix, status, used}
            DatTable1.Rows.Add(row)

        Next







    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub btnclose_Paint(sender As Object, e As PaintEventArgs) Handles btnclose.Paint
        Dim width = btnclose.Width
        Dim Height = btnclose.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        btnclose.Region = New Region(path)
    End Sub

    Private Sub ChkAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChkAll.CheckedChanged
        Dim PObj = jsonpa.Json2aray(Me.DatRec)
        Dim title As String = PObj("title")
        Dim func As String = PObj("func")


        If (func = "Vi_Siploc") Then
            chkLi_SIP()
        ElseIf (func = "Vi_Sipser") Then
            chkLi_SIP_s()
        ElseIf (func = "Vi_WADES") Then
            chkliWADesktop()
        ElseIf (func = "Vi_LocAn") Then
            chklilocalAndro
        ElseIf (func = "Vi_SerAn") Then

        ElseIf (func = "Vi_WASER") Then
            chklistWAqr()
        ElseIf (func = "Vi_Email") Then

        End If

        'Me.Close()
    End Sub

    Private Sub chkLi_SIP_s()
        Throw New NotImplementedException()
    End Sub

    Private Sub chklilocalAndro()

        Dim ChkA = ChkAll.Checked
        If (ChkA = True) Then

            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = True

                    Dim name = row.Cells("name").Value
                    Dim connection = row.Cells("connection").Value
                    Dim Application = row.Cells("Application").Value
                    Dim permission = row.Cells("permission").Value
                    Dim useran = row.Cells("useran").Value
                    Dim noserial = row.Cells("noserial").Value

                    Dim NeData As New JObject
                    NeData.Add("NaDev", name)
                    NeData.Add("Naplatform", Application)
                    NeData.Add("connection", connection)
                    NeData.Add("noserial", noserial)
                    NeData.Add("chk", True)
                    NeData.Add("fun", "Vi_LocAn")
                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next


        ElseIf (ChkA = False) Then
            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = False

                    Dim name = row.Cells("name").Value
                    Dim connection = row.Cells("connection").Value
                    Dim Application = row.Cells("Application").Value
                    Dim permission = row.Cells("permission").Value
                    Dim useran = row.Cells("useran").Value
                    Dim noserial = row.Cells("noserial").Value

                    Dim NeData As New JObject

                    NeData.Add("NaDev", name)
                    NeData.Add("Naplatform", Application)
                    NeData.Add("connection", connection)
                    NeData.Add("noserial", noserial)
                    NeData.Add("chk", False)
                    NeData.Add("fun", "Vi_LocAn")
                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next
        End If
    End Sub

    Private Sub chkliWADesktop()

        Dim ChkA = ChkAll.Checked
        If (ChkA = True) Then

            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = True
                    Dim Name = row.Cells("name").Value
                    Dim platform = row.Cells("platform").Value
                    Dim NumberWa = row.Cells("NumberWa").Value
                    Dim prefix = row.Cells("prefix").Value

                    Dim NeData As New JObject

                    NeData.Add("NaDev", Name)
                    NeData.Add("Naplatform", platform)
                    NeData.Add("NoWA", NumberWa)
                    NeData.Add("prefix", prefix)
                    NeData.Add("chk", True)
                    NeData.Add("fun", "Vi_WADES")
                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next


        ElseIf (ChkA = False) Then
            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = False
                    Dim Name = row.Cells("name").Value
                    Dim platform = row.Cells("platform").Value
                    Dim NumberWa = row.Cells("NumberWa").Value
                    Dim prefix = row.Cells("prefix").Value

                    Dim NeData As New JObject

                    NeData.Add("NaDev", Name)
                    NeData.Add("Naplatform", platform)
                    NeData.Add("NoWA", NumberWa)
                    NeData.Add("prefix", prefix)
                    NeData.Add("chk", False)
                    NeData.Add("fun", "Vi_WADES")
                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next
        End If

    End Sub

    Private Sub chklistWAqr()

        Dim ChkA = ChkAll.Checked
        If (ChkA = True) Then

            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = True
                    Dim Name = row.Cells("name").Value
                    Dim platform = row.Cells("platform").Value
                    Dim NumberWa = row.Cells("NumberWa").Value
                    Dim prefix = row.Cells("prefix").Value
                    Dim Service = row.Cells("Service").Value

                    Dim NeData As New JObject
                    NeData.Add("NaDev", Name)
                    NeData.Add("Naplatform", platform)
                    NeData.Add("NoWA", NumberWa)
                    NeData.Add("prefix", prefix)
                    NeData.Add("Service", Service)
                    NeData.Add("chk", True)
                    NeData.Add("fun", "Vi_WASER")


                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next


        ElseIf (ChkA = False) Then
            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = False
                    Dim Name = row.Cells("name").Value
                    Dim platform = row.Cells("platform").Value
                    Dim NumberWa = row.Cells("NumberWa").Value
                    Dim prefix = row.Cells("prefix").Value
                    Dim Service = row.Cells("Service").Value



                    Dim NeData As New JObject
                    NeData.Add("NaDev", Name)
                    NeData.Add("Naplatform", platform)
                    NeData.Add("NoWA", NumberWa)
                    NeData.Add("prefix", prefix)
                    NeData.Add("Service", Service)
                    NeData.Add("chk", False)
                    NeData.Add("fun", "Vi_WASER")


                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next
        End If


    End Sub

    Private Sub chkLi_SIP()
        For Each row As DataGridViewRow In DatTable1.Rows
            If Not row.IsNewRow Then ' Hindari row baru

                Dim Name As String = row.Cells("appname").Value
                Dim appath As String = row.Cells("appath").Value
                Dim PathAsli = appath & "\" & Name & ".exe"

                Dim currentValue As Boolean = False
                If row.Cells("CheckBoxColumn").Value IsNot Nothing Then
                    currentValue = CBool(row.Cells("CheckBoxColumn").Value)
                End If
                ' toggle nilai
                Dim newValue As Boolean = Not currentValue

                ' update nilai checkbox
                row.Cells("CheckBoxColumn").Value = newValue

                ' jika user uncheck (false) → keluar saja
                If (newValue) Then
                    row.DefaultCellStyle.ForeColor = Color.Black
                    row.DefaultCellStyle.BackColor = Color.OrangeRed
                Else
                    row.DefaultCellStyle.ForeColor = Color.White
                    row.DefaultCellStyle.BackColor = Color.Black
                End If

                Dim NeData As New JObject
                NeData.Add("appname", Name)
                NeData.Add("PathEx", PathAsli)
                NeData.Add("chk", newValue)
                NeData.Add("fun", "Vi_Siploc")
                Dim ObjString = NeData.ToString

                ' Raise the event and pass the selected data
                RaiseEvent DataSelected(Me, New ClassData(ObjString))

            End If
        Next
    End Sub

    Private Sub DatTable1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable1.CellContentClick
        Dim colindex = e.ColumnIndex
        Dim rowindex = e.RowIndex
        Dim funTag = lblheader.Tag.ToString
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


            If (funTag = "Vi_Siploc") Then
                ' jika true, kirim event
                Dim Name As String = DatTable1.Rows(rowindex).Cells("appname").Value.ToString()
                Dim appath As String = DatTable1.Rows(rowindex).Cells("appath").Value.ToString()
                Dim PathAsli As String = appath & "\" & Name & ".exe"

                Dim NeData As New JObject
                NeData.Add("appname", Name)
                NeData.Add("PathEx", PathAsli)
                NeData.Add("chk", newValue)
                NeData.Add("fun", funTag)

                Dim ObjString = NeData.ToString()

                RaiseEvent DataSelected(Me, New ClassData(ObjString))
            ElseIf (funTag = "Vi_Sipser") Then
                'Dim connection = DatTable1.Rows(rowindex).Cells("concurrent").Value.ToString()
                Dim Application = DatTable1.Rows(rowindex).Cells("app").Value.ToString()
                Dim noserial = DatTable1.Rows(rowindex).Cells("akunid").Value.ToString()
                Dim idle = DatTable1.Rows(rowindex).Cells("idle").Value.ToString()
                Dim state_exp As Boolean = DatTable1.Rows(rowindex).Cells("state_exp").Value

                If (idle = "BUSY") Then
                    MsgBox($"pick {Application} status busy / sedang sibuk ")
                    DatTable1.Rows(rowindex).Cells("CheckBoxColumn").Value = False
                    DatTable1.Rows(rowindex).Cells("CheckBoxColumn").ReadOnly = True
                    Exit Sub
                End If

                If (state_exp) Then
                    MsgBox($"pick {Application} Sudah expired ")
                    DatTable1.Rows(rowindex).Cells("CheckBoxColumn").Value = False
                    DatTable1.Rows(rowindex).Cells("CheckBoxColumn").ReadOnly = True
                    Exit Sub
                End If


                Dim NeData As New JObject

                NeData.Add("Naplatform", Application)
                '  NeData.Add("connection", connection)
                NeData.Add("noserial", noserial)
                NeData.Add("chk", newValue)
                NeData.Add("fun", funTag)
                Dim ObjString = NeData.ToString

                ' Raise the event and pass the selected data
                RaiseEvent DataSelected(Me, New ClassData(ObjString))

                If (newValue) Then
                    DatTable1.Rows(rowindex).Cells("idle").Value = "booked"
                Else
                    DatTable1.Rows(rowindex).Cells("idle").Value = "IDLE"
                End If
            ElseIf (funTag = "Vi_WADES") Then

                Dim Name = DatTable1.Rows(rowindex).Cells("name").Value.ToString()
                Dim platform = DatTable1.Rows(rowindex).Cells("platform").Value.ToString()
                Dim NumberWa = DatTable1.Rows(rowindex).Cells("NumberWa").Value.ToString()
                Dim prefix = DatTable1.Rows(rowindex).Cells("prefix").Value.ToString()

                Dim NeData As New JObject

                NeData.Add("NaDev", Name)
                NeData.Add("Naplatform", platform)
                NeData.Add("NoWA", NumberWa)
                NeData.Add("prefix", prefix)
                NeData.Add("chk", newValue)
                NeData.Add("fun", funTag)
                Dim ObjString = NeData.ToString

                ' Raise the event and pass the selected data
                RaiseEvent DataSelected(Me, New ClassData(ObjString))


            ElseIf (funTag = "Vi_LocAn") Then

                Dim name = DatTable1.Rows(rowindex).Cells("name").Value.ToString()
                Dim connection = DatTable1.Rows(rowindex).Cells("connection").Value.ToString()
                Dim Application = DatTable1.Rows(rowindex).Cells("Application").Value.ToString()
                Dim noserial = DatTable1.Rows(rowindex).Cells("noserial").Value.ToString()
                Dim NoHp = DatTable1.Rows(rowindex).Cells("NoHp").Value.ToString()
                Dim prefix = DatTable1.Rows(rowindex).Cells("prefix").Value.ToString()

                Dim NeData As New JObject
                NeData.Add("NaDev", name)
                NeData.Add("Naplatform", Application)
                NeData.Add("NoHp", NoHp)
                NeData.Add("connection", connection)
                NeData.Add("noserial", noserial)
                NeData.Add("prefix", prefix)
                NeData.Add("chk", newValue)
                NeData.Add("fun", funTag)
                Dim ObjString = NeData.ToString

                ' Raise the event and pass the selected data
                RaiseEvent DataSelected(Me, New ClassData(ObjString))

            ElseIf (funTag = "Vi_SerAn") Then



                Dim connection = DatTable1.Rows(rowindex).Cells("concurrent").Value.ToString()
                Dim Application = DatTable1.Rows(rowindex).Cells("app").Value.ToString()
                Dim noserial = DatTable1.Rows(rowindex).Cells("akunid").Value.ToString()


                Dim NeData As New JObject

                NeData.Add("Naplatform", Application)
                NeData.Add("connection", connection)
                NeData.Add("noserial", noserial)
                NeData.Add("chk", newValue)
                NeData.Add("fun", funTag)
                Dim ObjString = NeData.ToString

                ' Raise the event and pass the selected data
                RaiseEvent DataSelected(Me, New ClassData(ObjString))

                If (newValue) Then
                    DatTable1.Rows(rowindex).Cells("idle").Value = "booked"
                Else
                    DatTable1.Rows(rowindex).Cells("idle").Value = "idle"
                End If


            ElseIf (funTag = "Vi_Email") Then

            ElseIf (funTag = "Vi_WASER") Then

            End If
        End If


    End Sub

    Private Sub chkserverclould()
        Dim ChkA = ChkAll.Checked
        If (ChkA = True) Then

            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = True

                    Dim connection = row.Cells("concurrent").Value
                    Dim Application = row.Cells("app").Value
                    Dim noserial = row.Cells("akunid").Value
                    Dim subscribe = row.Cells("subscribe").Value
                    Dim limit_perday = row.Cells("limit_perday").Value
                    Dim limit_pernumber = row.Cells("limit_pernumber").Value

                    Dim NeData As New JObject
                    NeData.Add("Naplatform", Application)
                    NeData.Add("connection", connection)
                    NeData.Add("noserial", noserial)
                    NeData.Add("chk", True)
                    NeData.Add("fun", "Vi_SerAn")
                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next


        ElseIf (ChkA = False) Then
            For Each row As DataGridViewRow In DatTable1.Rows
                If Not row.IsNewRow Then ' Hindari row baru
                    row.Cells("CheckBoxColumn").Value = False

                    Dim connection = row.Cells("concurrent").Value
                    Dim Application = row.Cells("app").Value
                    Dim noserial = row.Cells("akunid").Value
                    Dim subscribe = row.Cells("subscribe").Value
                    Dim limit_perday = row.Cells("limit_perday").Value
                    Dim limit_pernumber = row.Cells("limit_pernumber").Value

                    Dim NeData As New JObject
                    NeData.Add("Naplatform", Application)
                    NeData.Add("connection", connection)
                    NeData.Add("noserial", noserial)
                    NeData.Add("chk", False)
                    NeData.Add("fun", "Vi_SerAn")
                    Dim ObjString = NeData.ToString

                    ' Raise the event and pass the selected data
                    RaiseEvent DataSelected(Me, New ClassData(ObjString))

                End If
            Next
        End If

    End Sub



End Class