Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class WhatsAppDesktop
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
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
        comboSource.Add("whatsapp", "WhatsApp")
        comboSource.Add("whatsappbta", "WhatsApp Beta")


        ComApk.DataSource = New BindingSource(comboSource, Nothing)
        ComApk.DisplayMember = "Value"
        ComApk.ValueMember = "Key"
        ComApk.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComApk.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub


    Private Sub LoadDataSIP()

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\wa\"
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

            Dim row As String() = New String() {ur, NaApp, NumberWA, NamaWA, prefix}
            DatTable1.Rows.Add(row)

        Next


    End Sub





    Private Sub WhatsAppDesktop_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDataSIP()

        Aplikasi()
    End Sub

    Private Sub BtnS_Click(sender As Object, e As EventArgs) Handles BtnS.Click
        Dim ApkWaV As String = ComApk.SelectedValue
        Dim apkText As String = ComApk.Text
        Dim prefx As String = ComPrefix.Text
        Dim NamWA As String = textName.Text
        Dim newobj As New JObject


        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\wa\"
        Dim FiNamJson = FoldeQ & "whatsapp.json"


        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If


        Dim b As String = ""

        If Not File.Exists(FiNamJson) Then
            Dim a = File.Create(FiNamJson)
            a.Dispose()
            a.Close()
        End If


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

        Dim UiAuto As New WhatsAppAutomation
        Dim pathWa As String = String.Empty

        If (apkText = "WhatsApp") Then
            pathWa = Path.Combine(UiAuto.GetWhatsAppUWPInstallPath(), "WhatsApp.exe")
        Else
            pathWa = "whatsapp://send?phone={notujuan}"
        End If

        newobj.Add("prefix", prefx)
        newobj.Add("idapk", ApkWaV.Trim)
        newobj.Add("aplikasi", apkText)
        newobj.Add("NamaWA", NamWA)
        newobj.Add("NumberWA", txtNumber.Text)
        newobj.Add("path", pathWa)
        newobj.Add("status", "AKTIF")

        Dim found As Boolean = False

        For Each app In DPar
            Dim NaApp As String = app("aplikasi")?.ToString()

            If NaApp = apkText Then
                ' Update data lama
                app("prefix") = prefx
                app("NamaWA") = NamWA
                app("NumberWA") = txtNumber.Text
                app("path") = pathWa
                app("status") = "AKTIF"
                found = True
                Exit For
            End If
        Next

        ' Jika tidak ditemukan, tambahkan data baru
        If Not found Then
            DPar.Add(newobj)
        End If

        File.WriteAllText(FiNamJson, DPar.ToString())

        LblNotif.Text = "Berhasil diTambahkan " & apkText
    End Sub

    Private Sub DatTable1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable1.CellContentClick
        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex
        'Dim namefile = DatTable1.Rows.Item(indrow).Cells(1).Value
        'Dim pathfile = DatTable1.Rows.Item(indrow).Cells(2).Value & $"\{namefile}.exe"
        'Dim pathfileIni = DatTable1.Rows.Item(indrow).Cells(2).Value & $"\{namefile}.ini"
    End Sub
End Class