Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmAddDial
    Private EnDe As New DeEnCrypt
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
    Private Sub multidial()



        ViewTabel0.Rows.Clear()

        Dim btnHapus As New DataGridViewButtonColumn
        btnHapus.FlatStyle = FlatStyle.Flat
        btnHapus.HeaderText = "Hapus"
        btnHapus.Text = "Hapus"
        btnHapus.Name = "btnHapus"
        btnHapus.UseColumnTextForButtonValue = True

        Dim btnConfig As New DataGridViewButtonColumn
        btnConfig.FlatStyle = FlatStyle.Flat
        btnConfig.HeaderText = "Edit SIP"
        btnConfig.Text = "EDIT"
        btnConfig.Name = "btnConfig"
        btnConfig.UseColumnTextForButtonValue = True

        ViewTabel0.Columns.Add(btnHapus)
        ViewTabel0.Columns.Add(btnConfig)


        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim files As String() = IO.Directory.GetFiles(FoldeQ)


        If (files.Length > 0) Then
            For Each filex As String In files
                Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
                Dim b As String = File.ReadAllText(filex)
                Dim DatDial = jsonpa.Json2aray(b)
                Dim prefix As String = DatDial("prefix_dial")


                Dim JsObj As New JObject
                JsObj = JObject.Parse(b)
                Dim totsip = JsObj.SelectToken(nameFile).Count

                Dim row As String() = New String() {nameFile, prefix, totsip}
                ViewTabel0.Rows.Add(row)


            Next
        End If

    End Sub
    Private Sub ListDial()

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim files As String() = IO.Directory.GetFiles(FoldeQ)

        ViewTabel.ColumnCount = 1
        Dim kol1 As New DataGridViewTextBoxColumn()
        kol1.HeaderText = "Apk SIP"
        kol1.Name = "Apk_Dial"

        Dim kol2 As New DataGridViewTextBoxColumn()
        kol2.HeaderText = "Path"
        kol2.Name = "path"

        ViewTabel.Columns.Add(kol1)
        ViewTabel.Columns.Add(kol2)

        Dim btnOpen As New DataGridViewButtonColumn
        btnOpen.FlatStyle = FlatStyle.Flat
        btnOpen.HeaderText = "Buka"
        btnOpen.Text = "Buka"
        btnOpen.Name = "btnOpen"
        btnOpen.UseColumnTextForButtonValue = True

        Dim btnHapus As New DataGridViewButtonColumn
        btnHapus.FlatStyle = FlatStyle.Flat
        btnHapus.HeaderText = "Hapus"
        btnHapus.Text = "Hapus"
        btnHapus.Name = "btnHapus"
        btnHapus.UseColumnTextForButtonValue = True

        Dim btnConfig As New DataGridViewButtonColumn
        btnConfig.FlatStyle = FlatStyle.Flat
        btnConfig.HeaderText = "Atur Kode SIP"
        btnConfig.Text = "Config"
        btnConfig.Name = "btnConfig"
        btnConfig.UseColumnTextForButtonValue = True

        ViewTabel.Columns.Add(btnHapus)
        ViewTabel.Columns.Add(btnOpen)
        ViewTabel.Columns.Add(btnConfig)
        Dim ax = 0
        ViewTabel.Rows.Clear()

        If (files.Length > 0) Then
            For Each filex As String In files
                Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
                Dim b As String = File.ReadAllText(filex)
                Dim DatDial = jsonpa.Json2aray(b)

                For Each item In DatDial(nameFile)
                    ax = ax + 1
                    Dim namexe = item("name")
                    Dim pathexe = item("path")
                    Dim directoryPath As String = Path.GetDirectoryName(pathexe)
                    Dim row As String() = New String() {ax, namexe, directoryPath}
                    ViewTabel.Rows.Add(row)

                Next


            Next
        End If



    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles BtnAdd.Click

        '  Dim apkname = dbConn.ApkProfile("name")
        Dim PathUp As String = Pathexe.txtinput.Text
        Dim TotIns As String = TotApk.Value

        Dim fexe As String = Path.GetFileName(PathUp).Replace(".exe", "").ToLower
        Dim numDial As String = ComFrNumber.Text.Trim.ToString.Replace("Blank", "")
        ' Parse the JSON string into a JArray
        Dim jobject As New JObject

        If (PathUp = "") Then
            MsgBox("Folder masih Kosong ")
            Exit Sub
        End If

        Dim directoryPath As String = Path.GetDirectoryName(PathUp)
        If Not System.IO.Directory.Exists(directoryPath) Then
            MsgBox("Folder Installer Aplikasi Dialler Tidak Ditemukan ")
            Exit Sub
        End If

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim GetNameFile = IO.Directory.GetFiles(FoldeQ, fexe & "*.json")

        Dim filePath = FoldeQ & $"{fexe}.json"
        Dim b As String = Nothing
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If


        If (fexe = "") Then
            MsgBox("Nama file belum dipilih")
            Exit Sub
        End If

        If File.Exists(filePath) Then
            b = File.ReadAllText(filePath)
        End If

        If (GetNameFile.Length = 1) Then
            MsgBox("Data Application Dialler sudah ada " & GetNameFile(0) & " Hapus Data dulu jika ingin update")
            Exit Sub
        End If

        'If (numDial = "") Then
        '    MsgBox("Data Prefix Belum dipilih ")
        '    Exit Sub
        'End If


        If Not (b Is Nothing) Then
            jobject = JObject.Parse(b)
        End If

        Application.DoEvents()
        LblNotif.Text = "Wait..."


        For i As Integer = 1 To TotIns

            'Dim cekprocces = Process.GetProcessesByName(fexe & i & ".exe")

            'If (cekprocces.Length > 0) Then
            '    For Each p In cekprocces
            '        p.CloseMainWindow()
            '        p.Close()
            '    Next
            'End If


            Dim xpath As String = directoryPath & i & "\"
            If System.IO.Directory.Exists(xpath) Then
                System.IO.Directory.Delete(xpath, True)

            End If
        Next

        Dim fini As String = Path.GetFileName(PathUp).Replace(".exe", "")
        Dim fileini As String = String.Empty

        If (IO.File.Exists(directoryPath & $"\{fini}.ini")) Then
            fileini = directoryPath & $"\{fini}.ini"
        Else
            fileini = directoryPath.Replace("Local", "Roaming") & $"\{fini}.ini"
        End If


        For i As Integer = 1 To TotIns
            Dim ApkIPath As String = directoryPath & i
            If Not System.IO.Directory.Exists(ApkIPath) Then
                System.IO.Directory.CreateDirectory(ApkIPath)

            End If
            Application.DoEvents()
            LblNotif.Text = "Create Folder..." & fini & i

            Dim WriteFileIn As New IniFileReader(fileini)
            WriteFileIn.WriteValue("Account1", "label", fini & i)
            WriteFileIn.WriteValue("Settings", "softtitle", fini & i)
            Dim files() As String = IO.Directory.GetFiles(directoryPath)



            Try
                For Each file As String In files
                    Application.DoEvents()
                    LblNotif.Text = "Copy File.." & file
                    Dim nameFile As String = Path.GetFileName(file)
                    Dim splexe = nameFile.Split(".")

                    ' Do work, example
                    If (splexe(1) = "exe") Then
                        IO.File.Copy(file, ApkIPath & "\" & splexe(0) & i & ".exe")
                        IO.File.Copy(fileini, ApkIPath & "\" & fini & i & ".ini")
                    Else
                        IO.File.Copy(file, ApkIPath & "\" & nameFile)
                    End If


                Next
            Catch ex As Exception

            End Try

            'create object
            Dim newData As New JObject
            Dim newDataArray As New JArray()
            newData.Add("name", fexe & i)
            newData.Add("path", ApkIPath & "\" & fexe & i & ".exe")
            newData.Add("use", False)
            newDataArray.Add(newData)

            If Not (jobject.ContainsKey(fexe)) Then
                jobject.Add("prefix_dial", numDial)
                jobject.Add(fexe, newDataArray)

                File.WriteAllText(filePath, jobject.ToString())
            Else
                If Not (jobject.ContainsKey(fexe & i)) Then
                    Dim japkx As JArray = jobject.SelectToken(fexe)
                    japkx.Add(newData)

                    File.WriteAllText(filePath, jobject.ToString())
                End If

            End If
        Next
        ListDial()
        LblNotif.Text = "Selesai "
    End Sub

    Public Sub CopyFolder(sourcePath As String, destPath As String)

        If Not Directory.Exists(sourcePath) Then
            MsgBox("Folder sumber tidak ditemukan")
            Exit Sub
        End If

        ' buat folder tujuan jika belum ada
        If Not Directory.Exists(destPath) Then
            Directory.CreateDirectory(destPath)
        End If

        ' copy semua file
        For Each filePath As String In Directory.GetFiles(sourcePath)

            Dim fileName As String = Path.GetFileName(filePath)
            Dim destFile As String = Path.Combine(destPath, fileName)

            File.Copy(filePath, destFile, True)

        Next

        ' copy subfolder
        For Each folder As String In Directory.GetDirectories(sourcePath)
            Dim folderName As String = Path.GetFileName(folder)
            Dim newDest As String = Path.Combine(destPath, folderName)

            CopyFolder(folder, newDest)
        Next

    End Sub
    Private Sub frmAddDial_Load(sender As Object, e As EventArgs) Handles Me.Load
        Pathexe.Lblname.Text = "Alamat Folder SIP"
        ListDial()
        multidial()
        Dim userdev = EnDe.GetUserName
        Dim apath = $"C:\Users\{userdev}\AppData\Local\"

        Pathexe.txtinput.Text = apath
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim totdup As Integer = ParData("body")("apk_data")(0)("fitur")("siplocal")

        TotApk.Maximum = totdup
        TotApk.Value = totdup

    End Sub

    Private Sub BtnLink_Click(sender As Object, e As EventArgs) Handles BtnLink.Click

        Dim userdev = EnDe.GetUserName
        Dim apath = $"C:\Users\{userdev}\AppData\Local\"


        With OpenFileDialog1
            .FileName = String.Empty
            .InitialDirectory = apath
            .Title = "Open File Dialler exe"
            .Filter = "EXE|*.exe"
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            Pathexe.txtinput.Text = OpenFileDialog1.FileName
        End If

    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim files As String() = IO.Directory.GetFiles(FoldeQ)

        Dim msg = "Semua Data Dialler terhapus ? "



        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            If (files.Count > 0) Then
                For Each filex As String In files
                    File.Delete(filex)
                    Dim cekprocces = Process.GetProcessesByName(filex)

                    If (cekprocces.Length > 0) Then
                        For Each p In cekprocces
                            p.CloseMainWindow()
                            p.Close()
                        Next
                    End If

                Next
            End If
            ListDial()
        End If


    End Sub

    Private Sub BtnAdd_Paint(sender As Object, e As PaintEventArgs) Handles BtnAdd.Paint
        Dim width = BtnAdd.Width
        Dim Height = BtnAdd.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnAdd.Region = New Region(path)
    End Sub

    Private Sub BtnDelete_Paint(sender As Object, e As PaintEventArgs) Handles BtnDelete.Paint
        Dim width = BtnDelete.Width
        Dim Height = BtnDelete.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnDelete.Region = New Region(path)
    End Sub

    Private Sub ViewTabel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel.CellContentClick
        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex
        Dim namefile = ViewTabel.Rows.Item(indrow).Cells(1).Value
        Dim pathfile = ViewTabel.Rows.Item(indrow).Cells(2).Value & $"\{namefile}.exe"
        Dim pathfileIni = ViewTabel.Rows.Item(indrow).Cells(2).Value & $"\{namefile}.ini"

        If (indcol = 4) Then
            Threading.Thread.Sleep(500)
            dbConn.OpenCmd(pathfile, "", "")
        ElseIf (indcol = 5) Then
            Dim pg As New frmConfigD(pathfileIni)
            pg.ShowDialog()
        End If
    End Sub

    Private Sub ViewTabel0_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel0.CellContentClick
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\siploc\"
        Dim files As String() = IO.Directory.GetFiles(FoldeQ)

        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex
        Dim namefile = ViewTabel0.Rows.Item(indrow).Cells(0).Value
        Dim prefixa = ViewTabel0.Rows.Item(indrow).Cells(1).Value
        Dim tosip = ViewTabel0.Rows.Item(indrow).Cells(2).Value

        Dim msg = "Yakin Mau Hapus SIP " & namefile

        If (indcol = 3) Then
            If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Dim filex As String = FoldeQ & namefile & ".json"
                If (files.Count > 0) Then
                    File.Delete(filex)
                End If

            End If

        ElseIf (indcol = 4) Then
            LblHeader.Text = "Update Aplikasi SIP Local"
            BtnAdd.Text = "Update SIP"
            ComFrNumber.Text = prefixa
            TotApk.Value = tosip
        End If

        ListDial()


    End Sub


End Class