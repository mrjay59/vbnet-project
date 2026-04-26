Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Newtonsoft.Json

Public Class UCAutoCall
    Private dbcon As New ClassConnect
    Private jsonpa As New ClassJson
    Private threadShouldStop As Boolean = False


    Private Sub ThreadDial(ByVal data As Dictionary(Of String, String))
        Dim apkdia = data.Item("apkdial").Trim
        Dim CallMenit As Integer = calldurasi.Value
        Dim Repeat As Integer = Ulangi.Value
        Dim wksleep As Integer = Dtsleep.Value * 1000
        Dim APKname As String

        Dim PathUp As String = TxtLink.Text
        Dim komu As String = String.Empty
        If (rd0.Checked) Then
            komu = "Ya"
        ElseIf (rd1.Checked) Then
            komu = "Tidak"
        End If
        APKname = dbcon.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & APKname
        Dim FoldeQ = fodev & "\dial"

        ' Replace non-numeric characters
        Dim namdial As String = Regex.Replace(apkdia, "[^a-z]", "")
        Dim numpath As Integer = apkdia.Replace(namdial, "")
        Dim FiName As String = FoldeQ & "\" & namdial & ".json"
        Dim Rlog As String = File.ReadAllText(FiName)
        Dim logParse = jsonpa.Json2aray(Rlog)

        Dim prefix As String = logParse("prefix_dial")
        Dim pathexe As String = logParse(namdial)(numpath - 1)("path")
        Dim number As String = String.Empty
        If Not (PathUp = "") Then
            Dim line() As String
            ' Create new columns
            Dim ai As Integer = 0

            line = File.ReadAllLines(PathUp)
            Dim ttd = line.Length
            For i = 0 To line.Length - 1
                ai = ai + 1

                Dim strnum = Trim(line(i))
                Dim nol As Integer = strnum.Substring(0, 1)
                If (nol = 0) Then
                    number = line(i).Trim.ToString.Substring(1)
                Else
                    number = line(i)
                End If


                Threading.Thread.Sleep(200)
                Dim numCall = prefix & number
                Dim numnew = "0" & number.Substring(0, 2) & "****" & number.Substring(7)
                If (Not number Is Nothing) Then
                    If (komu = "Ya") Then

                        If (lbstatus.InvokeRequired) Then
                            lbstatus.Invoke(Sub()
                                                lbstatus.Text = $"{numnew} TD:{ai}/{ttd} "
                                            End Sub)

                        End If

                        Threading.Thread.Sleep(500)
                        dbcon.OpenCmd(pathexe, $"{numCall}", "Y")
                        Threading.Thread.Sleep(500)
                    ElseIf (komu = "Tidak") Then
                        For id = 1 To Repeat
                            Dim a = id
                            If (lbstatus.InvokeRequired) Then
                                lbstatus.Invoke(Sub()
                                                    lbstatus.Text = $"{numnew} {a}x/{Repeat}x TD:{ai}/{ttd} "
                                                End Sub)

                            End If

                            Threading.Thread.Sleep(500)
                            dbcon.OpenCmd(pathexe, $"{numCall}", "")
                            Threading.Thread.Sleep(wksleep)

                            dbcon.OpenCmd(pathexe, "/exit", "")
                            Threading.Thread.Sleep(500)




                        Next
                    End If

                    ' Check if the thread should be stopped
                    If threadShouldStop Then
                        ' Exit the loop to stop the thread
                        Exit Sub
                    End If

                End If

            Next


        End If


        If (BtnStart.InvokeRequired) Then
            BtnStart.Invoke(Sub()

                                BtnStart.Text = "Start Call"
                                BtnStart.BackColor = Color.Blue
                                BtnStart.ForeColor = Color.White
                            End Sub)
        End If

    End Sub

    Private Sub calldurasi_ValueChanged(sender As Object, e As EventArgs) Handles calldurasi.ValueChanged
        Dim dumenit As Integer = calldurasi.Value
        Dim Rownum As Integer = TotData.Value
        Dim timer As Integer = Dtsleep.Value
        Dim second As Integer = 60
        Dim dudetik As Integer = dumenit * second

        Try
            If (Rownum > 0) Then
                Dim dx As Integer = Math.Round(dudetik / Rownum)
                Dim Result As Integer = Math.Round(dx / timer)


                If (Result > 0) And (Result <= 30) Then
                    Ulangi.Value = Result
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Ulangi_ValueChanged(sender As Object, e As EventArgs) Handles Ulangi.ValueChanged
        Dim Repeat As Integer = Ulangi.Value
        Dim Rownum As Integer = TotData.Value
        Dim timer As Integer = Dtsleep.Value

        Try
            Dim ResMen = Repeat * Rownum * timer

            calldurasi.Value = Math.Round(ResMen / 60)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnLink_Click(sender As Object, e As EventArgs) Handles BtnLink.Click
        'Dim PageForm As New Form1
        'Dim GetUser As Object = PageForm.getDuser

        ''cek status aplikasi free or premium

        'If (GetUser("status")("code") = 1) Then
        '    For Each item In GetUser("error")
        '        MsgBox(item)
        '    Next
        'End If

        '' Dim apkdata = JsonConvert.DeserializeObject(jsonObject("body")("apk_data"))
        'Dim apk_exe = GetUser("body")("apk_data")(0)("apk_exe")
        'Dim apdialco = GetUser("body")("apk_data")(0)("apk_dial_count")

        Dim apkname = dbcon.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\dial\"
        Dim files As String() = IO.Directory.GetFiles(FoldeQ)

        With OpenFileDialog1
            .FileName = String.Empty
            .InitialDirectory = "c:\"
            .Title = "Open Excel File"
            .Filter = "TXT|*.txt"
        End With
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            TxtLink.Text = OpenFileDialog1.FileName

        End If

        Dim PathUp As String = TxtLink.Text
        Dim GetFil As String = Path.GetFileName(PathUp)
        lblfiname.Text = GetFil
        If Not (TxtLink.Text = "") Then

            Dim line() As String
            ' Create new columns

            line = File.ReadAllLines(PathUp)
            Dim jmlh = line.Length
            TotData.Value = jmlh
            If (jmlh >= 200) Then
                MsgBox("maksimum 200 number")
                Exit Sub
            End If
            Dim comboSource As New Dictionary(Of String, String)
            comboSource.Add("", "Pilih Apk")
            For Each filex As String In files
                Dim nameFile As String = Path.GetFileName(filex).Replace(".json", "")
                Dim b As String = File.ReadAllText(filex)
                Dim DatDial = jsonpa.Json2aray(b)

                For Each item In DatDial(nameFile)
                    Dim apname = item("name").ToString
                    Dim Apkpath = item("path").ToString

                    comboSource.Add(Apkpath, apname)
                    ComApk.DataSource = New BindingSource(comboSource, Nothing)
                    ComApk.DisplayMember = "Value"
                    ComApk.ValueMember = "Key"
                    ComApk.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                    ComApk.AutoCompleteSource = AutoCompleteSource.CustomSource
                Next


            Next




        End If


        BtnStart.Enabled = True
        Dtsleep.Enabled = True
        calldurasi.Enabled = True
        TotData.Enabled = True
        ComApk.Enabled = True
        Ulangi.Enabled = True
    End Sub

    Private Sub RdapkClman_CheckedChanged(sender As Object, e As EventArgs)
        Ulangi.Value = 1
        Dtsleep.Enabled = False
        calldurasi.Enabled = False
    End Sub

    Private Sub RdClapktime_CheckedChanged(sender As Object, e As EventArgs)
        Dtsleep.Enabled = True
        calldurasi.Enabled = True
        Ulangi.Enabled = True
    End Sub

    Private Sub UCAutoCall_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dtsleep.Enabled = False
        calldurasi.Enabled = False
        TotData.Enabled = False
        ComApk.Enabled = False
        Ulangi.Enabled = False
        BtnStart.Enabled = False

    End Sub

    Private Sub Dtsleep_ValueChanged(sender As Object, e As EventArgs) Handles Dtsleep.ValueChanged

        Dim Repeat As Integer = Ulangi.Value
        Dim Rownum As Integer = TotData.Value
        Dim timer As Integer = Dtsleep.Value

        Dim jmdurasi = calldurasi.Value

        Dim second As Integer = 60
        Dim dudetik As Integer = jmdurasi * second

        Try
            If (Rownum >= 3) Then

                Dim ResMen = Repeat * Rownum * timer

                calldurasi.Value = Math.Round(ResMen / 60)


                Dim dx As Integer = Math.Round(dudetik / Rownum)
                Dim Result As Integer = Math.Round(dx / timer)


                If (Result > 0) And (Result <= 30) Then
                    Ulangi.Value = Result
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub lblfiname_Click(sender As Object, e As EventArgs) Handles lblfiname.Click
        Dim startpath As String = Path.GetDirectoryName(Application.ExecutablePath)


        Dim cmb As String = startpath & "\contohFile.txt"

        Dim filen = lblfiname.Text
        Dim filpat = TxtLink.Text
        If (filen = "Contoh File") Then
            Process.Start(cmb)
        Else
            Process.Start(filpat)
        End If



    End Sub

    Private Sub BtnStart_Paint(sender As Object, e As PaintEventArgs) Handles BtnStart.Paint
        Dim width = BtnStart.Width
        Dim Height = BtnStart.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnStart.Region = New Region(path)
    End Sub

    Private Sub lburut_Paint(sender As Object, e As PaintEventArgs) Handles lburut.Paint
        Dim width = lburut.Width
        Dim Height = lburut.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 20 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        lburut.Region = New Region(path)
    End Sub

    Private Sub BtnStart_Click(sender As Object, e As EventArgs) Handles BtnStart.Click
        Dim ststop As String = BtnStart.Text

        Dim komu As String = String.Empty
        If (ComApk.SelectedValue = "") Then
            MsgBox("Pilih Apk Dial Dulu")
            Exit Sub
        End If

        If (rd0.Checked) Then
            komu = "Ya"
            BtnClose.Visible = True
        ElseIf (rd1.Checked) Then
            komu = "Tidak"
        Else
            MsgBox("Mau Komunikasi Atau Tidak ? pilih dulu")
            Exit Sub
        End If

        Dim apkdial = ComApk.Text.Trim

        If (ststop = "Start Call") Then
            Dim param As New Dictionary(Of String, String)
            param.Add("apkdial", apkdial)
            Dim t As Thread = New Thread(AddressOf ThreadDial)
            t.IsBackground = True
            t.Start(param)
            BtnStart.Text = "Stop Call"
            threadShouldStop = False

            BtnStart.BackColor = Color.Red
            BtnStart.ForeColor = Color.Black
        ElseIf (ststop = "Stop Call") Then

            threadShouldStop = True
            BtnStart.Text = "Start Call"

            BtnStart.BackColor = Color.Blue
            BtnStart.ForeColor = Color.White

        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Dim apkdia = ComApk.Text.Trim

        Dim APKname = dbcon.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & APKname
        Dim FoldeQ = fodev & "\dial"

        ' Replace non-numeric characters
        Dim namdial As String = Regex.Replace(apkdia, "[^a-z]", "")
        Dim numpath As Integer = apkdia.Replace(namdial, "")
        Dim FiName As String = FoldeQ & "\" & namdial & ".json"
        Dim Rlog As String = File.ReadAllText(FiName)
        Dim logParse = jsonpa.Json2aray(Rlog)


        Dim pathexe As String = logParse(namdial)(numpath - 1)("path")


        dbcon.OpenCmd(pathexe, "/exit", "")
    End Sub

    Private Sub BtnClose_Paint(sender As Object, e As PaintEventArgs) Handles BtnClose.Paint
        Dim width = BtnClose.Width
        Dim Height = BtnClose.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnClose.Region = New Region(path)
    End Sub
End Class
