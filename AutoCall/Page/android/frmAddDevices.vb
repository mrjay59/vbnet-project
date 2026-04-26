Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class frmAddDevices
    Private mj As New mrjay59
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private adb As New adb
    Private DatR As String = String.Empty

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub Aplikasi()
        Dim comboSource As New Dictionary(Of String, String)
        comboSource.Add("", "Pilih Aplikasi")
        comboSource.Add("com.android.phone|TLC", "Telpon selular")
        comboSource.Add("com.android.mms|SMS", "SMS")
        comboSource.Add("com.whatsapp|WAO", "WhatsApp Message")
        comboSource.Add("com.whatsapp.w4b|WAB", "WhatsApp Business")


        ComApk.DataSource = New BindingSource(comboSource, Nothing)
        ComApk.DisplayMember = "Value"
        ComApk.ValueMember = "Key"
        ComApk.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComApk.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub listDevice()
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", "LocAn")

        Dim response = mj.getAkunAkses(param)
        Dim resp2arr = jsonpa.Json2aray(response)

        Dim comboSource As New Dictionary(Of String, String)
        comboSource.Add("", "Pilih Devices")

        If (resp2arr("status")("code") = 0) Then

            For Each item In resp2arr("body")
                Dim devname = item("apk_deviceinfo").ToString
                Dim devApk = item("apk_list").ToString
                Dim devArr = jsonpa.Json2aray(devname)

                Dim serialN = devArr("serial").ToString
                Dim nameD = devArr("device_name").ToString & "-" & serialN
                comboSource.Add(serialN, nameD)
                ComDev.DataSource = New BindingSource(comboSource, Nothing)
                ComDev.DisplayMember = "Value"
                ComDev.ValueMember = "Key"
                ComDev.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                ComDev.AutoCompleteSource = AutoCompleteSource.CustomSource
            Next

        End If


    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles BtnRefresh.Click

    End Sub


    Private Sub frmAddDevices_Load(sender As Object, e As EventArgs) Handles Me.Load
        listDevice()
        Aplikasi()
        BtnNewA_Click(sender, e)
        listApp()
    End Sub

    Private Sub listApp()
        Dim apkname = dbConn.ApkProfile("name")
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
            Dim arrApp As New ArrayList
            For Each prop As JProperty In approp
                Dim appname = prop.Name

                For Each item In applist(appname)
                    Dim appKode = item("appkode").ToString
                    arrApp.Add(appKode)
                Next

            Next
            Dim JoinKodeApp As String = String.Join(" ", arrApp.ToArray)

            ax = ax + 1
            Dim row As String() = New String() {ax, idev, JoinKodeApp, usedev}
            ViewTabel.Rows.Add(row)


        Next
    End Sub

    Private Sub AddPermissionIfNotExists(permArr As JArray, perm As String)
        If permArr Is Nothing Then Exit Sub

        'Remember: No duplicate
        If Not permArr.Any(Function(p) p.ToString().
        Equals(perm, StringComparison.OrdinalIgnoreCase)) Then
            permArr.Add(perm)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim folderQ = Path.Combine(fodev, "LocAn")
        Dim comDevValue As String = ComDev.SelectedValue.ToString()
        Dim napkg As String = ComApk.Text.Trim.Replace(" ", "").ToLowerInvariant()
        Dim filePath = Path.Combine(folderQ, $"{comDevValue}.json")
        Dim clone As String = String.Empty
        Dim metde As String = String.Empty
        Dim num1 As String = txtnum1.Text
        Dim num2 As String = txtnum2.Text
        Dim prefnum As String = PilPrefix.Text.Trim
        Dim ComApkValue() As String = ComApk.SelectedValue.Split("|")
        Dim pacValue = ComApkValue(0)
        Dim appKode = ComApkValue(1)

        If (appKode = "TLC") Or (appKode = "SMS") Then
            If (num1 = "") Or (num2 = "") Then
                MessageBox.Show("Isi Nomer SIM 1 , SIM 2 ")
                Exit Sub
            End If
        Else
            If (num1 = "") Then
                MessageBox.Show("Isi Nomer Akun WA  ")
                Exit Sub
            End If
        End If


        If (prefnum = "") Then
            MessageBox.Show("prefix harap diisi " & filePath)
            Exit Sub
        End If


        If Not File.Exists(filePath) Then
            MessageBox.Show("File device JSON tidak ditemukan: " & filePath)
            Exit Sub
        End If

        If (comDevValue = "") Then
            MessageBox.Show("Pilih Devices Dulu ")
            Exit Sub
        End If

        Dim b As String = File.ReadAllText(filePath)
        Dim jobjDev As JObject = JObject.Parse(b)


        Dim userpkg As String = String.Empty

        If (rd0.Checked) Then
            clone = "Tidak"
            userpkg = ""
        ElseIf (rd1.Checked) Then
            clone = "YA"
            userpkg = txtuser.Text

            If (txtuser.Text = "") Then
                MessageBox.Show($"Error Data user kosong cek di termux pm list users ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If


        ' ===== Siapkan struktur utama =====
        If jobjDev("apk") Is Nothing Then
            jobjDev("apk") = New JObject()
        End If

        Dim apkObj As JObject = CType(jobjDev("apk"), JObject)
        Dim subKey As String = napkg ' contoh: whatsapp atau wabisnis

        ' Jika belum ada array di subKey, buat
        If apkObj(subKey) Is Nothing Then
            apkObj(subKey) = New JArray()
        End If

        Dim arr As JArray = CType(apkObj(subKey), JArray)

        Dim Permission As New JArray()
        Dim numbers As New JArray
        Dim limit As New JObject
        Dim limitmspam As New JObject

        Select Case appKode
            Case "WAO", "WAB"
                Permission.Add("message")
                Permission.Add("call")
                numbers.Add("WA1 " & num1)
                limit.Add("message", 50)
                limit.Add("call", 80)
                limitmspam.Add("message", 10)
                limitmspam.Add("call", 5)
            Case "TLC"
                Permission.Add("call")
                numbers.Add("sim1 " & num1)
                numbers.Add("sim2 " & num2)
                limit.Add("call", 20)
                limitmspam.Add("call", 5)
            Case "SMS"
                Permission.Add("message")
                numbers.Add("sim1 " & num1)
                numbers.Add("sim2 " & num2)
                limit.Add("message", 20)
                limitmspam.Add("message", 5)
        End Select


        ' ===== Bentuk data baru =====
        Dim newData As New JObject From {
            {"package", pacValue},
            {"appkode", appKode},
            {"user", userpkg},
            {"prefix", prefnum},
            {"number", numbers},
            {"cloning", clone},
            {"permission", Permission},
            {"limit_perday", limit},
            {"limit_maxspam", limitmspam}
        }

        ' ===== CEK DUPLIKAT =====
        ' 1️⃣ Jika cloning "Tidak" sudah ada
        If clone = "Tidak" Then
            Dim existsNonClone = arr.Any(Function(x)
                                             Dim obj As JObject = CType(x, JObject)
                                             Return obj("cloning")?.ToString() = "Tidak"
                                         End Function)
            If existsNonClone Then
                MessageBox.Show($"Data dengan cloning 'Tidak' sudah ada di {subKey}.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        ' 2️⃣ Jika cloning "YA" dan user sudah sama
        If clone = "YA" AndAlso Not String.IsNullOrEmpty(userpkg) Then
            Dim existsUser = arr.Any(Function(x)
                                         Dim obj As JObject = CType(x, JObject)
                                         Return obj("cloning")?.ToString() = "YA" AndAlso
                                            obj("user")?.ToString().Trim().Equals(userpkg, StringComparison.OrdinalIgnoreCase)
                                     End Function)
            If existsUser Then
                MessageBox.Show($"Data cloning 'YA' dengan user '{userpkg}' sudah ada di {subKey}.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        ' ===== Tambahkan data baru =====
        arr.Add(newData)

        ' Simpan ke file
        File.WriteAllText(filePath, jobjDev.ToString(Newtonsoft.Json.Formatting.Indented))

        'simpan ke server
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()
        Dim param As New JObject
        param.Add("username", username)
        param.Add("data", jobjDev.ToString)
        param.Add("serial", comDevValue)


        Dim response = mj.regapp(param)

        MessageBox.Show($"Data berhasil ditambahkan ke {subKey}.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        PilPrefix.Text = ""
        txtnum1.Text = ""
        txtnum2.Text = ""
    End Sub

    Private Sub BtnNewA_Click(sender As Object, e As EventArgs) Handles BtnNewA.Click
        Label9.Text = "List Data Aplikasi Local Android"
        Label1.Text = "Add Aplikasi Local Android"
        BtnNewA.BackColor = Color.Transparent
        BtnListA.BackColor = Color.Gray

        Dim x = BtnNewA.Location.X
        Dim y = BtnNewA.Location.Y + BtnNewA.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnNewA.Width
        Panelgb.Visible = True

        PanelPusat.Controls.Clear()
        Try
            Dim page As New local_device
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DatR
            PanelPusat.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnListA_Click(sender As Object, e As EventArgs) Handles BtnListA.Click
        Label1.Text = "Add Aplikasi Clould Android"

        BtnNewA.BackColor = Color.Gray
        BtnListA.BackColor = Color.Transparent



        Dim x = BtnListA.Location.X
        Dim y = BtnListA.Location.Y + BtnListA.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnListA.Width
        Panelgb.Visible = True

        PanelPusat.Controls.Clear()
        Try
            Dim page As New cloud_device
            PanelPusat.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            page.SendDataUser = DatR
            PanelPusat.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnNewA_Paint(sender As Object, e As PaintEventArgs) Handles BtnNewA.Paint
        Dim width = BtnNewA.Width
        Dim Height = BtnNewA.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 30 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnNewA.Region = New Region(path)
    End Sub

    Private Sub BtnListA_Paint(sender As Object, e As PaintEventArgs) Handles BtnListA.Paint
        Dim width = BtnListA.Width
        Dim Height = BtnListA.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 30 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnListA.Region = New Region(path)
    End Sub

    Private Sub rd1_CheckedChanged(sender As Object, e As EventArgs) Handles rd1.CheckedChanged
        txtuser.Visible = True
        Label5.Visible = True
    End Sub

    Private Sub rd0_CheckedChanged(sender As Object, e As EventArgs) Handles rd0.CheckedChanged
        txtuser.Visible = False
        Label5.Visible = False
    End Sub

    Private Sub BtnRef_Click(sender As Object, e As EventArgs) Handles BtnRef.Click

    End Sub

    Private Sub ComApk_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComApk.SelectedIndexChanged
        Dim apkpil = ComApk.Text

        If (apkpil = "Telpon selular") Then

            GroupBox1.Text = "DATA SIM"
            lbl1.Text = "SIM1"
            lbl2.Text = "SIM2"
            txtnum2.Visible = True
            lbl2.Visible = True
            PilPrefix.SelectedIndex = 3
        ElseIf (apkpil = "SMS") Then
            GroupBox1.Text = "DATA SIM"
            lbl1.Text = "SIM1"
            lbl2.Text = "SIM2"
            txtnum2.Visible = True
            lbl2.Visible = True
            PilPrefix.SelectedIndex = 3
        ElseIf (apkpil = "WhatsApp Message") Then

            GroupBox1.Text = "Data Akun"
            lbl1.Text = "NO WA"
            txtnum2.Visible = False
            lbl2.Visible = False

            PilPrefix.SelectedIndex = 2
        ElseIf (apkpil = "WhatsApp Business") Then

            lbl1.Text = "NO WA"
            GroupBox1.Text = "Data Akun"

            txtnum2.Visible = False
            lbl2.Visible = False

            PilPrefix.SelectedIndex = 2
        End If

    End Sub

    Private Sub txtnum1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnum1.KeyPress
        ' Izinkan hanya angka 0-9, backspace, dan delete
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnum2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnum2.KeyPress
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub ViewTabel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel.CellContentClick

    End Sub
End Class