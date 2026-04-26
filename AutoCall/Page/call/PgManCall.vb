Imports System.IO
Imports System.Text.RegularExpressions
Imports AutoCall
Imports Newtonsoft.Json.Linq
Imports System.Windows.Forms
Imports System.Runtime.InteropServices
Imports System.Threading
Imports System.Windows.Automation

Public Class PgManCall
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private Ap_mrjay59 As New mrjay59
    Public threadShouldStop As Boolean = False
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private DataJson = Nothing
    Public Event SendDataJson As EventHandler(Of ClassData)

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub SipLocal()
        Dim pathfile As String = "SipLocal.json"
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "dialcaller\"
        Dim jmData As Integer = TxtNumber.Text.Split(",").Count
        Dim jmDial As Integer = TxtCaller.Text.Split(vbNewLine).Count

        Dim onefile As Integer = Math.Round(jmData / jmDial)
        Dim komu As String = String.Empty
        Dim totd = onefile * jmDial ' data 36 per dial 4*10=40
        Dim sisa As Integer = jmData Mod jmDial

        Dim allData As List(Of String) = TxtNumber.Text.Split(",").ToList
        Dim dataPerSession(jmDial - 1) As List(Of String)
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If Not (IO.Directory.Exists(Foldsdr)) Then
            IO.Directory.CreateDirectory(Foldsdr)
        End If




        'If (jmData <= 9) Then
        '    MsgBox("Data number minimal 10 nomer")
        '    Exit Sub
        'End If

        'If (jmDial >= jmData) Then
        '    MsgBox("Data harus lebih besar dari data jumlah apk dial")
        '    Exit Sub
        'End If

        If (jmData >= 1001) Then
            MsgBox("Max Data 1000")
            Exit Sub
        End If

        ' validasi dialler sedang digunakan

        Dim newDev, JObject As New JObject


        JObject = JObject.Parse(DataJson)

        'Dim axa = JObject.Count
        ' Get the properties (keys) from the JObject
        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()

        Dim ur = 0
        Dim aw = 0
        Dim ak = 0

        Dim ai = 0

        Dim filog = Foldsdr & $"{pathfile}"
        If (File.Exists(filog)) Then
            File.Delete(filog)
        End If

        '0-8
        '9-18
        If Not (File.Exists(filog)) Then
            Dim ad = File.Create(filog)
            ad.Close()
            ad.Dispose()
        End If

        Dim pin As Integer = 0
        Dim indx As Integer = 0
        ' Iterate through the properties and output the keys
        For Each prop As JProperty In properties


            Dim DataDev = prop.Name
            Dim jmCaller = JObject.Count

            Dim abx = 0
            Dim axa = jmCaller
            Dim NameDial = JObject.SelectToken(DataDev).Item("namexe").ToString
            Dim pathDial = JObject.SelectToken(DataDev).Item("patexe").ToString
            Dim prefix = JObject.SelectToken(DataDev).Item("prefix").ToString
            ur = ur + 1
            Dim xr = ur - 1

            Dim count As Integer = onefile
            If xr < sisa Then count += 1


            ' Pastikan tidak melebihi panjang data
            If indx + count > allData.Count Then
                count = allData.Count - indx
            End If

            dataPerSession(xr) = allData.GetRange(indx, count)
            indx += count



            Dim rs = 0

            For Each nomor As String In dataPerSession(xr)

                Dim number = nomor


                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()
                newData.Add("to", prefix & number)
                newData.Add("from", NameDial)
                newData.Add("path", pathDial)
                newData.Add("prefix", pathDial)
                newData.Add("keterangan", "")
                newData.Add("state", False)

                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(NameDial)) Then
                    newDataArray.Add(newData)
                    logParse.Add(NameDial, newDataArray)
                    File.WriteAllText(filog, logParse.ToString())
                Else
                    Dim japkx As JArray = logParse.SelectToken(NameDial)
                    japkx.Add(newData)

                    File.WriteAllText(filog, logParse.ToString())
                End If

            Next





        Next

        LoadDataCallSIP()
        LoadDataCallWA()

    End Sub

    Private Sub LoadDataCallSIP()
        ' Bersihkan DataGridView jika sudah ada data
        DatTable2.Columns.Clear()
        DatTable2.Rows.Clear()
        DatTable2.AutoGenerateColumns = False


        ' Buat kolom secara dinamis
        Dim kolom As New DataGridViewTextBoxColumn()
        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Nomor_Urut"
        kolom.HeaderText = "Nomor Urut"
        kolom.DataPropertyName = "No"
        kolom.Width = 150
        DatTable2.Columns.Add(kolom)


        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Aplikasi_SIP"
        kolom.HeaderText = "Aplikasi SIP"
        kolom.DataPropertyName = "apksip"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable2.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "notujuan"
        kolom.HeaderText = "NO TUJUAN"
        kolom.DataPropertyName = "notujuan"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable2.Columns.Add(kolom)



        Dim tombolRecall As New DataGridViewButtonColumn()
        tombolRecall.Name = "Recall_Type"
        tombolRecall.HeaderText = "ReCall Type"
        tombolRecall.Text = "ReCall"
        tombolRecall.UseColumnTextForButtonValue = True
        tombolRecall.Width = 100
        DatTable2.Columns.Add(tombolRecall)

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "dialcaller\"
        Dim pathfile As String = String.Empty

        pathfile = Foldsdr & "SipLocal.json"


        If Not (File.Exists(pathfile)) Then
            Exit Sub
        End If

        Dim JObject As New JObject

        Dim Rlog As String = File.ReadAllText(pathfile)
        JObject = JObject.Parse(Rlog)


        'Dim axa = JObject.Count
        ' Get the properties (keys) from the JObject
        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()

        Dim ur As Integer

        For Each prop As JProperty In properties
            Dim DataDev = prop.Name.Replace(" ", "")
            Dim rowIndex As Integer = DatTable2.Rows.Add()
            Dim datCaall As JArray = JObject(DataDev)

            Dim tonum As String = String.Empty
            Dim namawa As String = String.Empty
            Dim pathexe As String = String.Empty
            Dim app As String = String.Empty

            ur += 1
            For i As Integer = 0 To datCaall.Count - 1
                Dim StatC As Boolean = datCaall(i)("state")
                tonum = datCaall(i)("to").ToString
                namawa = datCaall(i)("from").ToString
                pathexe = datCaall(i)("path").ToString

                If (StatC = False) Then
                    DatTable2.Rows(rowIndex).Cells("Nomor_Urut").Value = ur
                    DatTable2.Rows(rowIndex).Cells("Aplikasi_SIP").Value = namawa
                    DatTable2.Rows(rowIndex).Cells("notujuan").Value = tonum
                    DatTable2.Rows(rowIndex).Cells("Aplikasi_SIP").Tag = pathexe
                End If



            Next

        Next


    End Sub

    Private Sub LoadDataCallWA()
        ' Bersihkan DataGridView jika sudah ada data
        DatTable1.Columns.Clear()
        DatTable1.Rows.Clear()
        DatTable1.AutoGenerateColumns = False


        ' Buat kolom secara dinamis
        Dim kolom As New DataGridViewTextBoxColumn()
        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Nomor_Urut"
        kolom.HeaderText = "Nomor Urut"
        kolom.DataPropertyName = "No"
        kolom.Width = 150
        DatTable1.Columns.Add(kolom)


        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Nama_Akun_WA"
        kolom.HeaderText = "Nama Akun WA"
        kolom.DataPropertyName = "nama"
        kolom.Width = 150
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "Aplikasi_SIP"
        kolom.HeaderText = "Aplikasi SIP"
        kolom.DataPropertyName = "apksip"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "notujuan"
        kolom.HeaderText = "NO TUJUAN"
        kolom.DataPropertyName = "notujuan"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)



        Dim tombolRecall As New DataGridViewButtonColumn()
        tombolRecall.Name = "Recall_Type"
        tombolRecall.HeaderText = "ReCall Type"
        tombolRecall.Text = "ReCall"
        tombolRecall.UseColumnTextForButtonValue = True
        tombolRecall.Width = 100
        DatTable1.Columns.Add(tombolRecall)

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "dialcaller\"
        Dim pathfile As String = String.Empty

        pathfile = Foldsdr & "Whatsapp.json"



        If Not (File.Exists(pathfile)) Then
            Exit Sub
        End If

        Dim JObject As New JObject

        Dim Rlog As String = File.ReadAllText(pathfile)
        JObject = JObject.Parse(Rlog)


        'Dim axa = JObject.Count
        ' Get the properties (keys) from the JObject
        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()

        Dim ur As Integer

        For Each prop As JProperty In properties
            Dim DataDev = prop.Name.Replace(" ", "")
            Dim rowIndex As Integer = DatTable1.Rows.Add()
            Dim datCaall As JArray = JObject(DataDev)

            Dim tonum As String = String.Empty
            Dim namawa As String = String.Empty
            Dim pathexe As String = String.Empty
            Dim app As String = String.Empty

            ur += 1
            For i As Integer = 0 To datCaall.Count - 1
                Dim StatC As Boolean = datCaall(i)("state")
                tonum = datCaall(i)("to").ToString
                namawa = datCaall(i)("from").ToString
                pathexe = datCaall(i).Item("pathexe").ToString
                app = datCaall(i)("app").ToString


                If (StatC = False) Then

                    DatTable1.Rows(rowIndex).Cells("Nomor_Urut").Value = ur
                    DatTable1.Rows(rowIndex).Cells("Nama_Akun_WA").Value = namawa
                    DatTable1.Rows(rowIndex).Cells("Aplikasi_SIP").Value = app
                    DatTable1.Rows(rowIndex).Cells("notujuan").Value = tonum
                    DatTable1.Rows(rowIndex).Cells("notujuan").Tag = i
                    DatTable1.Rows(rowIndex).Cells("Aplikasi_SIP").Tag = pathexe
                End If



            Next

        Next


    End Sub

    Private Sub btnCaller_Click(sender As Object, e As EventArgs) Handles btnCaller.Click
        If (Rc0.Checked) Then
            SipLocal()
        ElseIf (RD_WD.Checked) Then
            WaDesktop
        Else
            MsgBox("pilih metode call terlebih dahulu")
        End If

    End Sub

    Private Sub WaDesktop()
        Dim pathfile As String = "Whatsapp.json"

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "dialcaller\"
        Dim jmData As Integer = TxtNumber.Text.Split(",").Count
        Dim jmDial As Integer = TxtCaller.Text.Split(vbNewLine).Count

        Dim onefile As Integer = Math.Round(jmData / jmDial)
        Dim komu As String = String.Empty
        Dim sisa As Integer = jmData Mod jmDial

        Dim allData As List(Of String) = TxtNumber.Text.Split(",").ToList
        Dim dataPerSession(jmDial - 1) As List(Of String)
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If Not (IO.Directory.Exists(Foldsdr)) Then
            IO.Directory.CreateDirectory(Foldsdr)
        End If

        'If (jmData <= 9) Then
        '    MsgBox("Data number minimal 10 nomer")
        '    Exit Sub
        'End If

        'If (jmDial >= jmData) Then
        '    MsgBox("Data harus lebih besar dari data jumlah apk dial")
        '    Exit Sub
        'End If

        If (jmData >= 1001) Then
            MsgBox("Max Data 1000")
            Exit Sub
        End If

        ' validasi dialler sedang digunakan

        Dim newDev, JObject As New JObject


        JObject = JObject.Parse(DataJson)

        Dim filog = Foldsdr & $"{pathfile}"
        If (File.Exists(filog)) Then
            File.Delete(filog)
        End If

        '0-8
        '9-18


        If Not (File.Exists(filog)) Then
            Dim ad = File.Create(filog)
            ad.Close()
            ad.Dispose()
        End If


        'Dim axa = JObject.Count
        ' Get the properties (keys) from the JObject
        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()

        Dim ur = 0
        Dim aw = 0
        Dim ak = 0

        Dim ai = 0


        Dim pin As Integer = 0
        Dim indx As Integer = 0
        ' Iterate through the properties and output the keys
        For Each prop As JProperty In properties


            Dim DataDev = prop.Name.Replace(" ", "")
            Dim jmCaller = JObject.Count

            Dim abx = 0
            Dim axa = jmCaller
            Dim txsender = JObject.SelectToken(DataDev).Item("number").ToString
            Dim prefix = JObject.SelectToken(DataDev).Item("prefix").ToString
            Dim platform = JObject.SelectToken(DataDev).Item("platform").ToString
            Dim path = JObject.SelectToken(DataDev).Item("path").ToString
            ur = ur + 1
            Dim xr = ur - 1

            Dim count As Integer = onefile
            If xr < sisa Then count += 1


            ' Pastikan tidak melebihi panjang data
            If indx + count > allData.Count Then
                count = allData.Count - indx
            End If

            dataPerSession(xr) = allData.GetRange(indx, count)
            indx += count



            Dim rs = 0

            For Each nomor As String In dataPerSession(xr)

                Dim number = nomor


                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()
                newData.Add("to", prefix & number)
                newData.Add("app", platform)
                newData.Add("from", DataDev)
                newData.Add("pathexe", path.Replace("{notujuan}", prefix & number))
                newData.Add("state", False)

                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(DataDev)) Then
                    newDataArray.Add(newData)
                    logParse.Add(DataDev, newDataArray)
                    File.WriteAllText(filog, logParse.ToString())
                Else
                    Dim japkx As JArray = logParse.SelectToken(DataDev)
                    japkx.Add(newData)

                    File.WriteAllText(filog, logParse.ToString())
                End If

            Next





        Next



    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim metCal As String = String.Empty
        If (Rc0.Checked) Then
            metCal = "siploc"
        ElseIf (RD_WD.Checked) Then
            metCal = "wadesktop"
        Else
            MsgBox("pilih metode call terlebih dahulu")
        End If


        TxtCaller.Text = ""
        DataJson = Nothing

        If (metCal = "siploc") Then
            Dim NObj As New JObject
            NObj.Add("title", "Pilih SIP Local")
            NObj.Add("func", "lolistDialler")
            Dim page As New PgDialog(NObj.ToString)
            AddHandler page.DataSelected, AddressOf DataMasuk
            page.ShowDialog()
            RemoveHandler page.DataSelected, AddressOf DataMasuk
        ElseIf (metCal = "wadesktop") Then
            Dim NObj As New JObject
            NObj.Add("title", "Pilih WA DESKTOP")
            NObj.Add("func", "lolistWADes")
            Dim page As New PgDialog(NObj.ToString)
            AddHandler page.DataSelected, AddressOf DataMasuk
            page.ShowDialog()

            RemoveHandler page.DataSelected, AddressOf DataMasuk
        End If

    End Sub

    Private Sub DataMasuk(sender As Object, e As ClassData)
        Dim RData As String = e.Data
        Dim DatObj = e.Data

        Dim TotD = TxtCaller.Text.Split(vbNewLine).Count
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim akustat = ParData("body")("apk_stat").ToString
        Dim DatParse = jsonpa.Json2aray(DatObj)
        Dim fun = DatParse("fun").ToString


        If (fun = "lolistDialler") Then
            Dim NamExe = DatParse("NamExe")
            Dim PathEx = DatParse("PathEx")
            Dim chk As Boolean = DatParse("chk")
            Dim prefix = DatParse("prefix")
            Dim newDataArray As New JArray()

            If (TotD > 4) Then
                MsgBox("Data Sudah Maksimal bisa pilih 4")
                Exit Sub
            End If

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtCaller.Text &= NamExe & vbNewLine


                numData.Add("namexe", NamExe)
                numData.Add("patexe", PathEx)
                numData.Add("prefix", prefix)
                ' newDataArray.Add(numData)

                If Not (jobject.ContainsKey(NamExe)) Then
                    jobject.Add(NamExe, numData)
                    DataJson = jobject.ToString
                Else
                    Dim japkx As JArray = jobject.SelectToken(NamExe)
                    japkx.Add(numData)
                    DataJson = jobject.ToString
                End If

            ElseIf (chk = False) Then
                TxtCaller.Text = Regex.Replace(TxtCaller.Text.Replace(NamExe, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                jobject.Remove(NamExe)

                DataJson = jobject.ToString
            End If


        ElseIf (fun = "lolistWADesktop") Then
            Dim NaDev = DatParse("NaDev")
            Dim Naplatform = DatParse("Naplatform")
            Dim NaLog = DatParse("NaLog")
            Dim NoWA = DatParse("NoWA")
            Dim prefix = DatParse("prefix")
            Dim chk As Boolean = DatParse("chk")
            Dim path = DatParse("path")
            Dim DevNo = NaDev
            Dim newDataArray As New JArray()

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtCaller.Text &= NaDev & vbNewLine


                numData.Add("number", NoWA)
                numData.Add("platform", Naplatform)
                numData.Add("login", NaLog)
                numData.Add("NaDev", NaDev)
                numData.Add("prefix", prefix)
                numData.Add("path", path)
                ' newDataArray.Add(numData)

                If Not (jobject.ContainsKey(DevNo)) Then
                    jobject.Add(DevNo, numData)
                    DataJson = jobject.ToString
                Else
                    Dim japkx As JArray = jobject.SelectToken(DevNo)
                    japkx.Add(numData)
                    DataJson = jobject.ToString
                End If

            ElseIf (chk = False) Then
                TxtCaller.Text = Regex.Replace(TxtCaller.Text.Replace(NaDev, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                jobject.Remove(DevNo)

                DataJson = jobject.ToString
            End If

            ' TxtCaller.Value = jobject.Count

        ElseIf (fun = "lolistKontak") Then
            Dim DataNumber As String = DatParse("number")

            InData(DataNumber)

        End If
    End Sub

    Private Sub InData(ByVal DataNumber As String)
        Dim arnum As New ArrayList
        Dim number As String = String.Empty
        For Each strLine As String In DataNumber.Split(vbNewLine)
            Dim strnum = Trim(strLine.Trim).Replace("-", "")
            If Not (strnum = "") Then
                Dim nol As Integer = strnum.Substring(0, 1)
                Dim endua As Integer = strnum.Substring(0, 2)
                If (nol = 0) Then
                    number = strLine.Trim.ToString.Substring(1)
                ElseIf (endua = 62) Then
                    number = strLine.Trim.ToString.Substring(2)
                Else
                    number = strLine
                End If

                arnum.Add(number)
            End If
        Next

        Dim jmData As Integer = TxtNumber.Text.Split(",").Count
        Dim jmDial As Integer = TxtCaller.Text.Split(vbNewLine).Count

        If (jmDial <= 0) Then
            MsgBox("Opp belum ada  Dialer pilih dulu iya")
            TxtNumber.Text = ""
            Exit Sub
        End If


        LblTotData.Text = "Total Data " & arnum.Count



        Dim numbr As String = Join(arnum.ToArray, ",")
        TxtNumber.Text = numbr.Replace(vbLf, "")

        Dim prefix = TxtNumber.Text.Replace(",", ",+62")
        ' service data parameter
        Dim param As New Dictionary(Of String, String)
        param.Add("dnumber", prefix)

        Try
            Ap_mrjay59.inkontak(param)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        Dim DataNumber = Clipboard.GetText().TrimEnd

        InData(DataNumber)
    End Sub

    Private Sub PgManCall_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadDataCallSIP()
        LoadDataCallWA()

    End Sub

    Private Sub CallingBtn1_Click(sender As Object, e As EventArgs) Handles CallingBtn1.Click

        Dim pathfile As String = "Whatsapp.json"

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "dialcaller\"
        Dim filog = Foldsdr & $"{pathfile}"

        Dim b As String = File.ReadAllText(filog)
        Dim DatCase = jsonpa.Json2aray(b)

        Dim UiAuto As New WhatsAppAutomation

        For Each row As DataGridViewRow In DatTable1.Rows
            If row.IsNewRow Then Continue For

            Dim Nama_Akun_WA = row.Cells("Nama_Akun_WA").Value?.ToString()
            Dim nomorTujuan = row.Cells("notujuan").Value?.ToString()
            Dim Aplikasi_SIP = row.Cells("Aplikasi_SIP").Value?.ToString()
            Dim pathExe = TryCast(row.Cells("Aplikasi_SIP").Tag, String)
            Dim uid = row.Cells("notujuan").Tag

            If Not String.IsNullOrEmpty(pathExe) AndAlso Not String.IsNullOrEmpty(nomorTujuan) Then

                Task.Run(Sub()
                             Process.Start(pathExe)
                             Threading.Thread.Sleep(3000)
                         End Sub)


                If (Aplikasi_SIP = "WhatsApp") Then
                    ' 2. Klik ikon panggilan di sidebar
                    If Not UiAuto.ClickCallIconInSidebar() Then
                        Console.WriteLine("Gagal mengklik ikon panggilan. Otomatisasi dibatalkan.")
                        ' Console.ReadKey()
                        Return
                    End If


                    If Not UiAuto.ClickCallNumberAndHandlePopup(nomorTujuan, Aplikasi_SIP) Then
                        Console.WriteLine($"Gagal melakukan panggilan ke {nomorTujuan}. Otomatisasi dibatalkan.")
                        ' Console.ReadKey()
                        Return
                    End If
                Else
                    UiAuto.AutomateWhatsAppCallDirect(nomorTujuan)
                End If

                'Thread.Sleep(5000)
                ' UiAuto.HandleVoiceCall(Aplikasi_SIP)

            End If

            Dim NomHP As String = DatCase(Nama_Akun_WA)(uid)("to")
            If (nomorTujuan = NomHP) Then
                DatCase(Nama_Akun_WA)(uid)("state") = True
            End If

            File.WriteAllText(filog, DatCase.ToString())
        Next
    End Sub

    Private Async Sub DatTable1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable1.CellContentClick
        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex
        Dim ApkName = DatTable1.Rows.Item(indrow).Cells(2).Value?.ToString
        Dim pathExe = DatTable1.Rows.Item(indrow).Cells(2).Tag?.ToString
        Dim nomorTujuan = DatTable1.Rows.Item(indrow).Cells(3).Value?.ToString
        Dim UiAuto As New WhatsAppAutomation
        If (indcol = 4) Then
            Process.Start(pathExe.Replace("{notujuan}", nomorTujuan))

            Await Task.Delay(3000) ' delay 3 detik antar pemanggilan

            If (ApkName = "WhatsApp") Then
                ' 2. Klik ikon panggilan di sidebar
                If Not UiAuto.ClickCallIconInSidebar() Then
                    Console.WriteLine("Gagal mengklik ikon panggilan. Otomatisasi dibatalkan.")
                    ' Console.ReadKey()
                    Return
                End If


                If Not UiAuto.ClickCallNumberAndHandlePopup(nomorTujuan, ApkName) Then
                    Console.WriteLine($"Gagal melakukan panggilan ke {nomorTujuan}. Otomatisasi dibatalkan.")
                    ' Console.ReadKey()
                    Return
                End If
            Else
                UiAuto.AutomateWhatsAppCallDirect(nomorTujuan)
            End If

            ' Thread.Sleep(20000)
            ' UiAuto.HandleVoiceCall(ApkName)
        End If
    End Sub

    Private Sub BtnNext1_Click(sender As Object, e As EventArgs) Handles BtnNext1.Click
        'LoadDataCallWA()
        Dim UiAuto As New WhatsAppAutomation
        ' UiAuto.HandleVoiceCall("WhatsApp")

        UiAuto.HandleMinimizedWhatsAppCall()
    End Sub

    Private Sub CallingBtn2_Click(sender As Object, e As EventArgs) Handles CallingBtn2.Click

        Dim pathfile As String = "SipLocal.json"

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "dialcaller\"
        Dim filog = Foldsdr & $"{pathfile}"

        Dim b As String = File.ReadAllText(filog)
        Dim DatCase = jsonpa.Json2aray(b)

        Dim UiAuto As New WhatsAppAutomation

        For Each row As DataGridViewRow In DatTable2.Rows
            If row.IsNewRow Then Continue For

            Dim nomorTujuan = row.Cells("notujuan").Value?.ToString()
            Dim Aplikasi_SIP = row.Cells("Aplikasi_SIP").Value?.ToString()
            Dim pathExe = TryCast(row.Cells("Aplikasi_SIP").Tag, String)
            Dim uid = row.Cells("notujuan").Tag

            Task.Run(Sub()
                         dbConn.OpenCmd(pathExe, $"{nomorTujuan}", "")
                         Threading.Thread.Sleep(1000)
                     End Sub)

            Dim NomHP As String = DatCase(Aplikasi_SIP)(uid)("to")
            If (nomorTujuan = NomHP) Then
                DatCase(Aplikasi_SIP)(uid)("state") = True
            End If

            File.WriteAllText(filog, DatCase.ToString())
        Next
    End Sub

    Private Sub BtnN_Click(sender As Object, e As EventArgs) Handles BtnN.Click

    End Sub

    Private Sub DatTable2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable2.CellContentClick
        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex
        Dim ApkName = DatTable2.Rows.Item(indrow).Cells(1).Value?.ToString
        Dim pathExe = DatTable2.Rows.Item(indrow).Cells(1).Tag?.ToString
        Dim nomorTujuan = DatTable2.Rows.Item(indrow).Cells(2).Value?.ToString
        Dim UiAuto As New WhatsAppAutomation
        If (indcol = 3) Then
            Task.Run(Sub()
                         dbConn.OpenCmd(pathExe, $"{nomorTujuan}", "")
                         Threading.Thread.Sleep(1000)
                     End Sub)




        End If
    End Sub
End Class