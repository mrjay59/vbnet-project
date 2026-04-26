Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmAddNumber

    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private adb As New adb
    Private Sub WhatsApp()
        Dim comboSource As New Dictionary(Of String, String)
        comboSource.Add("", "Pilih WhatsApp")
        comboSource.Add("whatsapp", "WhatsApp Message")
        comboSource.Add("whatsappw4b", "WhatsApp Business")


        ComApk.DataSource = New BindingSource(comboSource, Nothing)
        ComApk.DisplayMember = "Value"
        ComApk.ValueMember = "Key"
        ComApk.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        ComApk.AutoCompleteSource = AutoCompleteSource.CustomSource
    End Sub

    Private Sub listDevice()
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\devices\"

        Dim files As String() = IO.Directory.GetFiles(fodev)

        Dim comboSource As New Dictionary(Of String, String)
        comboSource.Add("", "Pilih Devices")
        For Each filex As String In files
            Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")


            comboSource.Add(filex, nameFile)
            ComDev.DataSource = New BindingSource(comboSource, Nothing)
            ComDev.DisplayMember = "Value"
            ComDev.ValueMember = "Key"
            ComDev.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            ComDev.AutoCompleteSource = AutoCompleteSource.CustomSource
        Next
    End Sub

    Private Sub listNumberWa()
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\Devices\"

        Dim files As String() = IO.Directory.GetFiles(fodev)

        ViewTabel.Rows.Clear()

        For Each filex As String In files
            Dim Datajson As String = File.ReadAllText(filex)
            Dim ax = 0
            ' Parse the JSON string into a JArray
            Dim soudb = JsonConvert.DeserializeObject(Datajson)
            If Not (soudb Is Nothing) Then
                Dim NameDev = soudb("name")


                If Not (soudb("apk") Is Nothing) Then
                    For Each item In soudb("apk")
                        Dim apkName = item.Name

                        For Each item1 In soudb("apk")(apkName)("data")
                            ax = ax + 1
                            Dim NumberWa = item1("number")


                            Dim row As String() = New String() {NameDev, apkName, NumberWa, ax - 1}
                            ViewTabel.Rows.Add(row)

                        Next
                    Next
                End If

            End If
        Next
    End Sub

    Private Sub hapusNumberWA()
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\Devices\"

        Dim files As String() = IO.Directory.GetFiles(fodev)


        For Each filex As String In files
            jsonpa.DeleteInFile(filex, "apk")
        Next
    End Sub

    Private Sub frmAddNumber_Load(sender As Object, e As EventArgs) Handles Me.Load
        listDevice()
        WhatsApp()
        listNumberWa()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim patdev As String = ComDev.SelectedValue
        Dim wakey As String = ComApk.SelectedValue
        Dim numac1 As String = num1.Text.Trim
        Dim numac2 As String = num2.Text.Trim
        Dim tosend1 As String = TotSend1.Value
        Dim tosend2 As String = TotSend2.Value
        Dim TwoAc As Boolean
        If (rd0.Checked) Then
            TwoAc = False
        ElseIf (rd1.Checked) Then
            TwoAc = True
        Else
            MsgBox("belum pilih 2 account false Or true? ")
            Exit Sub
        End If

        If (numac1 = "") Then
            MsgBox("Data Masih Kosong Account 1")
            Exit Sub
        End If

        If (wakey = "") Then
            MsgBox("belum pilih whatsapp")
            Exit Sub
        End If

        If (patdev = "") Then
            MsgBox("belum pilih devices")
            Exit Sub
        End If
        Dim numData, numData1, addObj, jobject, addObj1 As New JObject
        Dim Jarr As New JArray
        Dim Datajson As String = File.ReadAllText(patdev)
        jobject = JObject.Parse(Datajson)



        numData.Add("number", numac1)
        numData.Add("blocked", False)
        numData.Add("login", True)
        numData.Add("recovery", False)
        numData.Add("max_send", tosend1)
        numData.Add("delay", 500)
        numData.Add("use", True)
        numData.Add("apk", "default")
        Jarr.Add(numData)
        Dim totarr As JArray = jobject.SelectToken($"apk.{wakey}.data")
        Dim dtClone = jobject.SelectToken($"apk.{wakey}.clone")
        If (TwoAc) Then
            If (numac2 = "") Then
                MsgBox("Data Masih Kosong Account 2")
                Exit Sub
            End If

            If (totarr.Count = 2) Then
                MsgBox("Data Number account 2 sudah ada silahkan hapus")
                Exit Sub
            End If

            numData1.Add("number", numac2)
            numData1.Add("blocked", False)
            numData1.Add("login", True)
            numData1.Add("recovery", False)
            numData1.Add("max_send", tosend2)
            numData1.Add("delay", 500)
            numData1.Add("use", True)
            numData1.Add("apk", "clone")
            Jarr.Add(numData1)

        End If


        addObj.Add("data", Jarr)
        Dim dwakey As JObject = jobject.SelectToken($"apk.{wakey}")

        If (dwakey Is Nothing) Then

            addObj.Add("clone", TwoAc)
            Dim apk As JObject = jobject.SelectToken("apk")
            If Not (apk Is Nothing) Then
                apk.Add(wakey, addObj)
            Else
                addObj1.Add(wakey, addObj)
                jobject.Add("apk", addObj1)
            End If
        ElseIf (TwoAc) Then
            dwakey("clone") = TwoAc
            totarr.Add(numData)
            totarr.Add(numData1)
        ElseIf (totarr.Count = 0) Then
            dwakey("clone") = TwoAc
            totarr.Add(numData)
        End If
        ' Write the JSON string back to the file
        IO.File.WriteAllText(patdev, jobject.ToString)

        listNumberWa()
        MsgBox("Data Berhasil Di Simpan")




    End Sub

    Private Sub num1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles num1.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub num2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles num2.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BtnSave_Paint(sender As Object, e As PaintEventArgs) Handles BtnSave.Paint
        Dim width = BtnSave.Width
        Dim Height = BtnSave.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnSave.Region = New Region(path)
    End Sub

    Private Sub ViewTabel_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ViewTabel.CellContentClick
        Dim columi As Integer = e.ColumnIndex
        Dim rowi As Integer = e.RowIndex
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & $"\{dbConn.ApkProfile("name")}\Devices\"

        Dim dtdevice As String = ViewTabel.Rows(rowi).Cells("dev").Value
        Dim platform As String = ViewTabel.Rows(rowi).Cells("Platform").Value
        Dim wanumber As String = ViewTabel.Rows(rowi).Cells("WaNumber").Value
        Dim waid As Integer = ViewTabel.Rows(rowi).Cells("idwa").Value
        Dim FileD = fodev & dtdevice & ".json"
        Dim json As JObject = JObject.Parse(File.ReadAllText(FileD))
        Dim dwakey As JArray = json.SelectToken($"apk.{platform}.data")

        Dim files As String() = IO.Directory.GetFiles(fodev)
        Dim ax = 0

        Dim msg = $"Data {dtdevice} Untuk Platform {platform} Nomer WA {wanumber} Apa Mau dihapus ?." + Environment.NewLine

        If (columi = 4) Then

            If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                dwakey.Item(waid).Remove()

                ' Save the modified JSON data back to the file
                File.WriteAllText(FileD, json.ToString())

                listNumberWa()
            End If

        End If


    End Sub

    Private Sub rd0_CheckedChanged(sender As Object, e As EventArgs) Handles rd0.CheckedChanged
        num1.ReadOnly = False
        num2.ReadOnly = True
        num2.Text = ""

        num1.Enabled = True
        num2.Enabled = False
    End Sub

    Private Sub rd1_CheckedChanged(sender As Object, e As EventArgs) Handles rd1.CheckedChanged
        num1.ReadOnly = False
        num2.ReadOnly = False

        num1.Enabled = True
        num2.Enabled = True
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click


        Dim msg = "Yakin Mau Hapus Data Semua Number WA ..? " + Environment.NewLine

        Dim RowD As Integer = ViewTabel.Rows.Count

        If (RowD > 0) Then
            If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                hapusNumberWA()
            End If

            listNumberWa()
            MsgBox("Data Berhasil Di Hapus")
        End If



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

    Private Sub Btn4_Click(sender As Object, e As EventArgs) Handles Btn4.Click
        Dim patdev As String = ComDev.SelectedValue

        If (patdev = "") Then
            MsgBox("belum pilih devices")
            Exit Sub
        End If

        Dim J2Object = jsonpa.Json2aray(File.ReadAllText(patdev))
        Dim nameDev As String = J2Object("name")
        Dim seriDev As String = J2Object("idev")
        Dim scrpy As String = J2Object("scrcpy").ToString.Replace("{serial}", seriDev).Replace("{winheader}", nameDev)
        Dim config As String = J2Object("config")

        Dim idev = IIf(J2Object("connection") = "USB", J2Object("idev"), IIf(J2Object("connection") = "WIFI", J2Object("ipdev"), ""))
        Dim Conn = J2Object("connection")

        Dim devapk As New ClassApk(idev, Conn)
        devapk.OpenScrcpy(scrpy & config)

    End Sub

    Private Sub Btn4_Paint(sender As Object, e As PaintEventArgs) Handles Btn4.Paint
        Dim width = Btn4.Width
        Dim Height = Btn4.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        Btn4.Region = New Region(path)
    End Sub
End Class