Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports AdvancedSharpAdbClient
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmCaller
    Public threadShouldStop As Boolean = False
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private _data As String
    Private DatR As String = String.Empty
    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub btnCaller_Click(sender As Object, e As EventArgs) Handles btnCaller.Click

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "wacaller\"
        Dim komu As String = String.Empty
        If (rd0.Checked) Then
            komu = "Ya"
        ElseIf (rd1.Checked) Then
            komu = "Tidak"
        Else
            MsgBox("Mau Komunikasi Atau Tidak pilih dulu")
            Exit Sub
        End If

        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If Not (IO.Directory.Exists(Foldsdr)) Then
            IO.Directory.CreateDirectory(Foldsdr)
        End If

        Dim DataNumber = TxtNumber.Text.Split(",")
        Dim ststop As String = btnCaller.Text
        Dim jmData As Integer = DataNumber.Length
        Dim jmDial As Integer = TotDial.Value
        Dim JmDurasi As Integer = TotDurasi.Value
        Dim JmRecall As Integer = TotRecall.Value
        Dim JmClose As Integer = TotClose.Value
        Dim onefile As Integer = Math.Round(jmData / jmDial)
        ' Dim threads As New List(Of Thread)()
        Dim minDataNumber = onefile * jmDial


        Dim rec As Integer = 0
        Dim re As Integer = 0
        Dim jr As Integer = 0

        If (onefile <= 1) Then
            MsgBox("Minimal Pembagian 1 nomer per whatsApp ")
            Exit Sub
        End If

        'If (jmData <= 10) Then
        '    MsgBox("Data number minimal 10 nomer")
        '    Exit Sub
        'End If

        'If (jmDial >= jmData) Then
        '    MsgBox("Data harus lebih besar dari data Device")
        '    Exit Sub
        'End If

        'If (jmData >= 201) Then
        '    MsgBox("Max Data 200")
        '    Exit Sub
        'End If
        Dim newDev, JObject As New JObject
        JObject = JObject.Parse(DataJson)

        Dim axa = JObject.Count
        ' Get the properties (keys) from the JObject
        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()

        Dim ur = 0
        Dim aw = 0
        Dim ak = 0

        Dim ai = 0
        ' Create and start 10 threads
        Dim control = PanelPusat.Controls.OfType(Of UCDeviceUse)()
        Dim datc = control.Count
        Dim pin As Integer = 0
        ' Iterate through the properties and output the keys
        For Each prop As JProperty In properties

            ur = ur + 1
            Dim xr = ur - 1
            Dim DataDev = prop.Name.Replace("-whatsapp", "").Replace("-whatsappw4b", "")
            Dim jmCaller As JArray = JObject.SelectToken($"{prop.Name}")
            Dim redev = 0
            Dim filog = Foldsdr & $"{DataDev}.json"
            If (File.Exists(filog)) Then
                File.Delete(filog)

            End If


            '0-8
            '9-18
            Dim DatNum = TxtNumber.Text.Split(",")
            If (ur = axa) Then
                If (axa = 1) Then
                    aw = 0
                    ak = DatNum.Count
                Else
                    aw = xr * onefile
                    ak = DatNum.Count
                End If
            Else
                aw = xr * onefile
                ak = onefile * ur
            End If

            If Not (File.Exists(filog)) Then
                Dim ad = File.Create(filog)
                ad.Close()
                ad.Dispose()
            End If

            Dim rs = 0

            For ix = aw To ak - 1

                Dim number = DatNum(ix)
                redev = redev + 1

                Dim ax = redev - 1
                Dim fornumWa As String = JObject.SelectToken($"{prop.Name}[{ax}].number")
                Dim platnumWa As String = JObject.SelectToken($"{prop.Name}[{ax}].platform")

                If (redev = jmCaller.Count) Then
                    redev = 0
                End If



                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()
                subData.Add("MG", 0)
                subData.Add("BR", 0)
                subData.Add("AN", 0)
                newData.Add("to", number)
                newData.Add("from", fornumWa)
                newData.Add("platform", platnumWa)
                newData.Add("text", "")
                newData.Add("result", subData)
                newData.Add("recall", 0)
                newData.Add("tocall", JmRecall)
                newData.Add("status", "")
                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(DataDev)) Then
                    newDataArray.Add(newData)
                    logParse.Add("delay", JmClose)
                    ' logParse.Add("count", japkx.Count)
                    logParse.Add(DataDev, newDataArray)
                    File.WriteAllText(filog, logParse.ToString())
                Else
                    Dim japkx As JArray = logParse.SelectToken(DataDev)
                    japkx.Add(newData)

                    File.WriteAllText(filog, logParse.ToString())
                End If

            Next

            Dim nameFile As String = DataDev
            Dim b As String = File.ReadAllText(filog)
            ai = ai + 1
            Dim c = ai - 1
            Dim param As New Dictionary(Of String, String)
            param.Add("data", b)
            param.Add("nameFile", nameFile)
            param.Add("pathFile", filog)
            param.Add("komu", komu)
            Threading.Thread.Sleep(500)
            Dim thread As New Thread(AddressOf DoWork)
            thread.IsBackground = True
            thread.Start(param)
            'threads.Add(thread)
            ' param.Clear()

            If (datc > 0) Then
                Dim ab = datc + c
                pin = 35 * ab
            Else
                pin = 35 * c
            End If


            Dim DtObj As New JObject
            DtObj.Add("fitur", "WaCaller")
            DtObj.Add("namedial", DataDev)
            DtObj.Add("pathFile", filog.ToString)
            DtObj.Add("pathexe", "")
            DtObj.Add("komu", komu)

            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = Trim(nameFile.Trim)
            Uiuse.lbname.Tag = DtObj.ToString
            Uiuse.lburut.Text = ai
            Uiuse.Location = New Point(0, pin)
            If (komu = "Ya") Then
                Uiuse.BtnStat.Visible = True
            Else
                Uiuse.BtnNext.Enabled = False
            End If
            Uiuse.ContextMenuStrip = Uiuse.KlikAnan
            AddHandler Uiuse.DataSelected, AddressOf DataMasuk
            PanelPusat.Controls.Add(Uiuse)


        Next

        threadShouldStop = False



    End Sub

    Private Sub DoWork(ByVal data As Dictionary(Of String, String))
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\devices\"


        Dim b = data.Item("data").ToString
        Dim nameFile = data.Item("nameFile").ToString
        Dim pathFile = data.Item("pathFile").ToString
        Dim komu = data.Item("komu").ToString
        Dim DatLog = jsonpa.Json2aray(b)

        Dim fiDev = FoldeQ & nameFile & ".json"
        Dim RDev As String = File.ReadAllText(fiDev)
        Dim Jdev = jsonpa.Json2aray(RDev)
        Dim idev = IIf(Jdev("connection") = "USB", Jdev("idev"), IIf(Jdev("connection") = "WIFI", Jdev("ipdev"), ""))
        Dim Conn = Jdev("connection")

        Dim dbApk As New ClassApk(idev, Conn)

        Dim JsObj As New JObject
        JsObj = JObject.Parse(b)
        Dim ttd As Integer = JsObj.SelectToken(nameFile).Count
        Dim demi = Jdev("texture")
        Dim ai = 0



        For Each item In DatLog(nameFile)
            ai = ai + 1
            Dim tonu As String = item("to")
            Dim from As String = item("from")
            Dim platform As String = item("platform")
            Dim tocall As Integer = item("tocall")
            Dim statWa As String = item("status")
            Dim toMG As Integer = item("result")("MG")
            Dim toBR As Integer = item("result")("BR")
            Dim toAN As Integer = item("result")("AN")
            Dim numnew = "0" & tonu.Substring(3, 2) & "****" & tonu.Substring(9)

            Dim index As Integer = jsonpa.FindIndex(RDev, $"apk.{platform}.data", "number", from)
            Dim ganda As Boolean = Jdev("apk")(platform)("clone")
            Dim apkdef As Boolean = IIf(Jdev("apk")(platform)("data")(index)("apk") = "default", True, False)
            Dim delay As String = Jdev("apk")(platform)("data")(index)("delay")
            Dim login As Boolean = Jdev("apk")(platform)("data")(index)("login")
            Dim ResCal = String.Empty
            Dim ddl As Integer = DatLog("delay")
            If (login = False) Then
                Exit For
            End If
            dbApk.HomeBtn()
            'Dim nexnum As String = DatLog(nameFile)(ai)("to")
            Dim WhatsApp As String = platform.Replace("w4b", ".w4b")

            If ((statWa = "") Or (statWa = "procces")) Then
                Thread.Sleep(delay)
                item("status") = "procces"
                File.WriteAllText(pathFile, DatLog.ToString())


                If (komu = "Ya") Then


                    For Each control As UCDeviceUse In PanelPusat.Controls.OfType(Of UCDeviceUse)()
                        ' Update properties or call methods on each user control
                        Dim txtname = control.lbname.Text
                        If (txtname = nameFile) Then
                            If (control.InvokeRequired) Then
                                control.Invoke(Sub()
                                                   control.lbstatus.Text = $"{numnew} TD:{ai}/{ttd} "
                                               End Sub)

                            End If

                        End If
                    Next


                    Dim elCall = dbApk.FindElement($"//node[@resource-id='com.{WhatsApp}:id/conversation_contact_name']")
                    If (elCall Is Nothing) Then
                        dbApk.OpenWhatsAppCall(tonu, apkdef, ganda, WhatsApp)
                        Thread.Sleep(500)
                        Dim elFind = dbApk.FindElement("//node[@resource-id='android:id/message']")
                        If Not (elFind Is Nothing) Then
                            Dim elText = elFind.Attributes("text")
                            If (elText.Contains("tidak terdaftar di WhatsApp")) Then
                                item("text") = "nomer noreg"
                                File.WriteAllText(pathFile, DatLog.ToString())
                                dbApk.BackBtn()
                                Exit For
                            End If
                        End If
                    Else
                        Dim atEl = elCall.Attributes("text").Replace(" ", "").Replace("-", "").Trim
                        If (atEl.Contains(tonu)) Then
                            dbApk.KlikTouch("PS", WhatsApp)
                            Thread.Sleep(500)
                            Dim Els = dbApk.FindElements("//node[@text]") 'bar ic VOICE
                            For Each ItemElm In Els
                                Dim StrEl = ItemElm.Attributes("text")
                                If (StrEl.Contains("Mulai panggilan suara?")) Then
                                    Thread.Sleep(500)
                                    dbApk.KlikTouch("PAG", WhatsApp)
                                ElseIf (StrEl.Contains("Pilih tipe panggilan")) Then
                                    Thread.Sleep(500)
                                    dbApk.KlikTouch("PS1", WhatsApp)
                                End If
                            Next
                        End If
                    End If

                    Thread.Sleep(2500)
                    ResCal = dbApk.WaitCallStat(WhatsApp, "Y")

                    If (ResCal = "MG") Then
                        item("text") = "memanggil"
                        Dim au As Integer = au + 1
                        item("result")("MG") = au
                        Thread.Sleep(5000)

                        ddl = DatLog("delay")
                        dbApk.KlikTouch("ENC", WhatsApp)
                        File.WriteAllText(pathFile, DatLog.ToString())


                    ElseIf (ResCal = "BR") Then
                        threadShouldStop = True
                        item("text") = "bedering"

                        Dim ab As Integer = item("result")("BR") + 1
                        item("result")("MG") = 0
                        item("result")("BR") = ab

                        ddl = DatLog("delay")
                        File.WriteAllText(pathFile, DatLog.ToString())

                        Thread.Sleep(5000)
                        ' dbApk.KlikTouch("ENC", platform)

                        If threadShouldStop Then
                            ' Exit the loop to stop the thread
                            Exit Sub
                        End If
                    ElseIf (ResCal = "AN") Then
                        threadShouldStop = True
                        item("text") = "terima panggilan"
                        Thread.Sleep(5000)
                        Dim an As Integer = item("result")("AN") + 1
                        item("result")("AN") = an
                        item("result")("MG") = 0

                        ' dbApk.KlikTouch("", platform)
                        ddl = DatLog("delay")
                        File.WriteAllText(pathFile, DatLog.ToString())

                        If threadShouldStop Then
                            ' Exit the loop to stop the thread
                            Exit Sub
                        End If

                    ElseIf (ResCal = "BL") Then ' nomer keblok
                        item("text") = "sender terblokir"
                        Jdev("apk")(platform)("data")(index)("blocked") = True
                        Jdev("apk")(platform)("data")(index)("login") = False
                        Jdev("apk")(platform)("data")(index)("use") = False
                        File.WriteAllText(fiDev, Jdev.ToString())
                        File.WriteAllText(pathFile, DatLog.ToString())
                        Exit For
                    End If


                ElseIf (komu = "Tidak") Then


                    For rc = 1 To tocall

                        For Each control As UCDeviceUse In PanelPusat.Controls.OfType(Of UCDeviceUse)()
                            ' Update properties or call methods on each user control
                            Dim txtname = control.lbname.Text
                            Dim a = rc
                            If (txtname = nameFile) Then
                                If (control.InvokeRequired) Then
                                    control.Invoke(Sub()
                                                       control.lbstatus.Text = $"{numnew} {a}x/{tocall}x TD:{ai}/{ttd} "
                                                       control.lbstatus.Tag = $"{numnew}|{ai}"
                                                   End Sub)

                                End If

                            End If
                        Next
                        Dim ResC = String.Empty

                        Dim elCall = dbApk.FindElement($"//node[@resource-id='com.{WhatsApp}:id/conversation_contact_name']")
                        If (elCall Is Nothing) Then
                            dbApk.OpenWhatsAppCall(tonu, apkdef, ganda, WhatsApp)
                            Thread.Sleep(1000)
                            Dim elFind = dbApk.FindElement("//node[@resource-id='android:id/message']")

                            If Not (elFind Is Nothing) Then

                                Dim elText = elFind.Attributes("text")
                                If (elText.Contains("tidak terdaftar di WhatsApp")) Then
                                    item("text") = "nomer noreg"
                                    File.WriteAllText(pathFile, DatLog.ToString())
                                    dbApk.BackBtn()
                                    Exit For
                                End If
                            End If

                        Else
                            Dim atEl = elCall.Attributes("text").Replace(" ", "").Replace("-", "").Trim
                            If (atEl.Contains(tonu)) Then
                                Dim Eltimer = dbApk.FindElement($"//node[@resource-id='com.{WhatsApp}:id/ephemeral_nux_ok']")

                                If Not (Eltimer Is Nothing) Then
                                    Eltimer.Click()
                                    Thread.Sleep(500)
                                    dbApk.KlikTouch("PS", WhatsApp)
                                Else
                                    dbApk.KlikTouch("PS", WhatsApp)
                                    Thread.Sleep(1500)
                                    Dim Elspgsuara = dbApk.FindElement("//node[@text='Mulai panggilan suara?']")
                                    If Not (Elspgsuara Is Nothing) Then
                                        Thread.Sleep(500)
                                        dbApk.KlikTouch("PAG", WhatsApp)
                                    End If

                                    Dim Elstpaggil = dbApk.FindElement("//node[@text='Pilih tipe panggilan']")
                                    If Not (Elstpaggil Is Nothing) Then
                                        Thread.Sleep(500)
                                        dbApk.KlikTouch("PS1", WhatsApp)

                                        Dim Elspgsuara1 = dbApk.FindElement("//node[@text='Mulai panggilan suara?']")
                                        If Not (Elspgsuara1 Is Nothing) Then
                                            Thread.Sleep(500)
                                            dbApk.KlikTouch("PAG", WhatsApp)
                                        End If
                                    End If
                                End If


                            Else
                                Dim Eltimer = dbApk.FindElement($"//node[@resource-id='com.{WhatsApp}:id/ephemeral_nux_ok']")
                                If Not (Eltimer Is Nothing) Then
                                    Eltimer.Click()
                                    Thread.Sleep(1000)
                                    dbApk.KlikTouch("PS", WhatsApp)
                                End If
                            End If
                        End If


                        ddl = ddl - 5
                        Thread.Sleep(5000)
                        ResCal = dbApk.WaitCallStat(WhatsApp, "")

                        item("recall") = rc
                        If (ResCal = "MG") Then
                            item("text") = "memanggil"
                            Dim au As Integer = au + 1
                            item("result")("MG") = au
                            Thread.Sleep(ddl * 1000)
                            dbApk.KlikTouch("ENC", WhatsApp)
                            File.WriteAllText(pathFile, DatLog.ToString())
                            If (au >= 2) Then
                                au = 0
                                Exit For
                            End If
                        ElseIf (ResCal = "BR") Then
                            item("text") = "bedering"

                            Dim ab As Integer = item("result")("BR") + 1
                            item("result")("MG") = 0
                            item("result")("BR") = ab

                            File.WriteAllText(pathFile, DatLog.ToString())
                            Thread.Sleep(ddl * 1000)
                            dbApk.KlikTouch("ENC", WhatsApp)
                        ElseIf (ResCal = "AN") Then
                            item("text") = "terima panggilan"

                            Dim an As Integer = item("result")("AN") + 1
                            item("result")("AN") = an
                            item("result")("MG") = 0

                            File.WriteAllText(pathFile, DatLog.ToString())
                            Thread.Sleep(ddl * 1000)
                            dbApk.KlikTouch("ENC", WhatsApp)
                        ElseIf (ResCal = "BL") Then ' nomer keblok
                            item("text") = "sender terblokir"
                            Jdev("apk")(platform)("data")(index)("blocked") = True
                            Jdev("apk")(platform)("data")(index)("login") = False
                            Jdev("apk")(platform)("data")(index)("use") = False
                            File.WriteAllText(fiDev, Jdev.ToString())
                            File.WriteAllText(pathFile, DatLog.ToString())
                            Exit For
                        End If

                        ddl = DatLog("delay")


                        If threadShouldStop Then
                            ' Exit the loop to stop the thread
                            Exit Sub
                        End If

                    Next
                End If

                item("status") = "Done"
                File.WriteAllText(pathFile, DatLog.ToString())
            End If

        Next




    End Sub

    Private Sub btnCaller_Paint(sender As Object, e As PaintEventArgs) Handles btnCaller.Paint
        Dim width = btnCaller.Width
        Dim Height = btnCaller.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        btnCaller.Region = New Region(path)
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        TxtCaller.Text = ""
        TotDial.Value = 0
        DataJson = Nothing
        Dim NObj As New JObject
        NObj.Add("title", "Pilih WA")
        NObj.Add("func", "lolistWA")
        Dim page As New PgDialog(NObj.ToString)
        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()


    End Sub
    Private DataJson = Nothing
    Private DatStop = Nothing
    Private Sub DataMasuk(sender As Object, e As ClassData)
        ' Cast the event arguments to the appropriate type
        Dim DatObj = e.Data
        Dim DatParse = jsonpa.Json2aray(DatObj)
        Dim fun = DatParse("fun").ToString
        Dim TotD = TotDial.Value
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim akustat = ParData("body")("apk_stat").ToString
        Dim pgCount As Integer = ParData("body")("apk_data")(0)("apk_exe")(1)("count")



        If (fun = "lolistWA") Then
            Dim NaDev = DatParse("NaDev")
            Dim Naplatform = DatParse("Naplatform")
            Dim NaLog = DatParse("NaLog")
            Dim NoWA = DatParse("NoWA")
            Dim chk As Boolean = DatParse("chk")
            Dim DevNo = NaDev
            Dim newDataArray As New JArray()

            If (TotD >= pgCount) Then
                MsgBox("Data Sudah Maksimal bisa dipilih " & pgCount)
                Exit Sub
            End If

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtCaller.Text &= NoWA & vbNewLine


                numData.Add("number", NoWA)
                numData.Add("platform", Naplatform)
                numData.Add("login", NaLog)
                numData.Add("NaDev", NaDev)
                newDataArray.Add(numData)

                If Not (jobject.ContainsKey(DevNo)) Then
                    jobject.Add(DevNo, newDataArray)
                    DataJson = jobject.ToString
                Else
                    Dim japkx As JArray = jobject.SelectToken(DevNo)
                    japkx.Add(numData)
                    DataJson = jobject.ToString
                End If



            ElseIf (chk = False) Then
                TxtCaller.Text = Regex.Replace(TxtCaller.Text.Replace(NoWA, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                jobject.Remove(DevNo)

                DataJson = jobject.ToString
            End If

            TotDial.Value = jobject.Count
        ElseIf (fun = "lolistKontak") Then
            Dim DataNumber As String = DatParse("number")
            InData(DataNumber)
        Else

            If (fun = "StartService") Then
                Dim namedial = DatParse("namedial")
                Dim pathFile = DatParse("pathFile")
                Dim komu = DatParse("komu")
                Dim b As String = File.ReadAllText(pathFile)
                Dim param As New Dictionary(Of String, String)
                param.Add("data", b)
                param.Add("nameFile", namedial)
                param.Add("pathFile", pathFile)
                param.Add("komu", komu)
                Threading.Thread.Sleep(1000)
                Dim thread As New Thread(AddressOf DoWork)
                thread.IsBackground = True
                thread.Start(param)

            ElseIf (fun = "StopService") Then
                DatStop = DatObj.ToString


            End If


        End If




    End Sub

    Private Sub BtnSelect_Paint(sender As Object, e As PaintEventArgs) Handles BtnSelect.Paint
        Dim width = BtnSelect.Width
        Dim Height = BtnSelect.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnSelect.Region = New Region(path)
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
                    number = "+62" & strLine.Trim.ToString.Substring(1)
                ElseIf (endua = 62) Then
                    number = "+" & strLine.Trim.ToString
                Else
                    number = "+62" & strLine
                End If

                arnum.Add(number)
            End If
        Next


        Dim Rowdial As Integer = TotDial.Value
        Dim dumenit As Integer = TotDurasi.Value
        Dim Rownum As Integer = arnum.Count
        Dim timer As Integer = TotClose.Value
        Dim Repeat As Integer = TotRecall.Value

        Dim second As Integer = 60
        Dim dudetik As Integer = dumenit * second

        Dim jmData As Integer = arnum.Count
        Dim jmDial As Integer = TotDial.Value
        Dim JmDurasi As Integer = TotDurasi.Value
        Dim JmRecall As Integer = TotRecall.Value
        Dim JmClose As Integer = TotClose.Value
        Dim onefile As Integer = Math.Round(jmData / jmDial)
        Dim totd = onefile * jmDial ' data 36 per dial 4*10=40
        Dim rhal = totd - jmData
        Dim adx = onefile - rhal
        LblTotData.Text = "Total Data " & jmData
        If (onefile < 1) Then
            MsgBox("Minimal Pembagian 1 nomer per apk dial ")
            TxtNumber.Text = ""
            Exit Sub
        End If

        If (jmData <= 1) Then
            MsgBox("Data number minimal 1 number")
            TxtNumber.Text = ""
            Exit Sub
        End If

        If (adx <= 0) Then
            MsgBox($"Total Data {jmData} Total Dialler {jmDial} Coba dibanyakin Datanya")
            Exit Sub
        End If


        If (Rownum > 1) Then
            Rownum = Math.Round(Rownum / Rowdial)
            Dim dx As Integer = Math.Round(dudetik / Rownum)
            Dim Result As Integer = Math.Round(dx / timer)


            If (Result > 0) Then
                TotRecall.Value = Result
            End If
        End If

        '


        Dim numbr As String = Join(arnum.ToArray, ",")
        TxtNumber.Text = numbr.Replace(vbLf, "")

        ' service data parameter
        Dim param As New Dictionary(Of String, String)
        param.Add("dnumber", TxtNumber.Text)

        Try
            Ap_mrjay59.inkontak(param)
        Catch ex As Exception

        End Try
    End Sub
    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        Dim DataNumber = Clipboard.GetText().TrimEnd
        InData(DataNumber)


    End Sub

    Private Sub TxtNumber_TextChanged(sender As Object, e As EventArgs) Handles TxtNumber.TextChanged

    End Sub

    Private Sub TxtNumber_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumber.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TotDurasi_ValueChanged(sender As Object, e As EventArgs) Handles TotDurasi.ValueChanged
        Dim Rowdial As Integer = TotDial.Value
        Dim dumenit As Integer = TotDurasi.Value
        Dim Rownum As Integer = TxtNumber.Text.Trim.Split(",").Count
        Dim timer As Integer = TotClose.Value
        Dim second As Integer = 60
        Dim dudetik As Integer = dumenit * second

        If (Rownum > 1) Then
            Rownum = Math.Round(Rownum / Rowdial)
            Dim dx As Integer = Math.Round(dudetik / Rownum)
            Dim Result As Integer = Math.Round(dx / timer)


            If (Result > 0) Then
                TotRecall.Value = Result
            End If
        End If
    End Sub

    Private Sub TotRecall_ValueChanged(sender As Object, e As EventArgs) Handles TotRecall.ValueChanged
        Dim Rowdial As Integer = TotDial.Value
        Dim Repeat As Integer = TotRecall.Value
        Dim Rownum As Integer = TxtNumber.Text.Trim.Split(",").Count
        Dim timer As Integer = TotClose.Value
        Dim jmDial As Integer = TotDial.Value
        Dim jmdurasi = TotDurasi.Value

        Try
            Rownum = Math.Round(Rownum / Rowdial)
            Dim ResMen = Repeat * Rownum * timer

            TotDurasi.Value = Math.Round(ResMen / 60)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TotClose_ValueChanged(sender As Object, e As EventArgs) Handles TotClose.ValueChanged
        Dim Rowdial As Integer = TotDial.Value
        Dim Repeat As Integer = TotRecall.Value
        Dim Rownum As Integer = TxtNumber.Text.Trim.Split(",").Count
        Dim timer As Integer = TotClose.Value
        Dim jmDial As Integer = TotDial.Value
        Dim jmdurasi = TotDurasi.Value

        Dim second As Integer = 60
        Dim dudetik As Integer = jmdurasi * second

        Try
            Rownum = Math.Round(Rownum / Rowdial)
            Dim ResMen = Repeat * Rownum * timer

            TotDurasi.Value = Math.Round(ResMen / 60)


            Dim dx As Integer = Math.Round(dudetik / Rownum)
            Dim Result As Integer = Math.Round(dx / timer)


            If (Result > 0) Then
                TotRecall.Value = Result
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnStat_Click(sender As Object, e As EventArgs) Handles BtnStat.Click
        threadShouldStop = True
        PanelPusat.Controls.Clear()
    End Sub

    Private Sub rd0_CheckedChanged(sender As Object, e As EventArgs) Handles rd0.CheckedChanged
        TotRecall.Value = 1
    End Sub

    Private Sub BtnContact_Click(sender As Object, e As EventArgs) Handles BtnContact.Click
        TxtNumber.Text = ""


        Dim jmDial As Integer = TotDial.Value
        If (jmDial <= 0) Then
            MsgBox("Opp belum ada dialer pilih dulu iya")
            TxtNumber.Text = ""
            Exit Sub
        End If

        Dim NObj As New JObject
        NObj.Add("title", "Connect Link Spreadsheet")
        NObj.Add("func", "lolistKontak")
        Dim page As New PgDialog(NObj.ToString)
        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()
    End Sub

    Private Sub BtnTxt_Click(sender As Object, e As EventArgs) Handles BtnTxt.Click

    End Sub

    Private Sub BtnCsv_Click(sender As Object, e As EventArgs) Handles BtnCsv.Click

    End Sub
End Class