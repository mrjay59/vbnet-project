Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Newtonsoft.Json.Linq
Imports AdvancedSharpAdbClient

Public Class frmSender
    Private threadShouldStop As Boolean = False
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private DataJson = Nothing
    Private DatR As String = String.Empty
    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        TxtSender.Text = ""
        DataJson = Nothing
        Dim NObj As New JObject
        NObj.Add("title", "Pilih WA")
        NObj.Add("func", "lolistWA")
        Dim page As New PgDialog(NObj.ToString)
        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()

    End Sub


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
                MsgBox("Data Sudah Maksimal bisa dipilih hanya " & pgCount)
                Exit Sub
            End If

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtSender.Text &= NoWA & vbNewLine


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
                TxtSender.Text = Regex.Replace(TxtSender.Text.Replace(NoWA, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                jobject.Remove(DevNo)

                DataJson = jobject.ToString
            End If

            TotDial.Value = jobject.Count
        End If

    End Sub


    Private Sub TxtMessage_Paint(sender As Object, e As PaintEventArgs) Handles TxtMessage.Paint
        Dim width = TxtMessage.Width
        Dim Height = TxtMessage.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        TxtMessage.Region = New Region(path)
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "wasender\"

        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If Not (IO.Directory.Exists(Foldsdr)) Then
            IO.Directory.CreateDirectory(Foldsdr)
        End If

        If (TxtNumber.Text = "") Then
            MsgBox("Data Number Kosong")
            Exit Sub
        End If

        If (TxtMessage.Text = "") Then
            MsgBox("Text Pesan Kosong")
            Exit Sub
        End If

        If (TxtSender.Text = "") Then
            MsgBox("Data Sender Kosong")
            Exit Sub
        End If


        Dim DataNumber = TxtNumber.Text.Split(",")
        Dim TxtPesan = TxtMessage.Text
        Dim jmData As Integer = DataNumber.Length
        Dim jmDial As Integer = TotDial.Value
        Dim onefile As Integer = Math.Round(jmData / jmDial)
        Dim delay1 As Integer = TotDel1.Value
        Dim delay2 As Integer = TotDel2.Value
        Dim newDev, JObject As New JObject
        Dim GabDel = $"{delay1}-{delay2}"

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
                subData.Add("C1", 0)
                subData.Add("C2", 0)
                subData.Add("CB", 0)
                newData.Add("to", number)
                newData.Add("from", fornumWa)
                newData.Add("platform", platnumWa)
                newData.Add("txtpesan", TxtPesan)
                newData.Add("result", subData)


                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(DataDev)) Then
                    newDataArray.Add(newData)
                    logParse.Add("delay", GabDel)
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
            Threading.Thread.Sleep(1000)
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

            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = Trim(nameFile.Trim)
            Uiuse.lburut.Text = ai
            Uiuse.Location = New Point(0, pin)
            Uiuse.BtnStat.Visible = True
            Uiuse.BtnNext.Enabled = False
            Uiuse.ContextMenuStrip = Uiuse.KlikAnan
            PanelPusat.Controls.Add(Uiuse)


        Next
    End Sub

    Private Sub DoWork(ByVal data As Dictionary(Of String, String))
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\devices\"

        Dim b = data.Item("data").ToString
        Dim nameFile = data.Item("nameFile").ToString
        Dim pathFile = data.Item("pathFile").ToString
        Dim DatLog = jsonpa.Json2aray(b)

        Dim fiDev = FoldeQ & nameFile & ".json"
        Dim RDev As String = File.ReadAllText(fiDev)
        Dim Jdev = jsonpa.Json2aray(RDev)
        Dim idev = IIf(Jdev("connection") = "USB", Jdev("idev"), IIf(Jdev("connection") = "WIFI", Jdev("ipdev"), "")).ToString
        Dim Conn = Jdev("connection").ToString
        Dim JsObj As New JObject
        JsObj = JObject.Parse(b)
        Dim ttd As Integer = JsObj.SelectToken(nameFile).Count
        Dim demi = Jdev("texture")
        Dim ddl = DatLog("delay").ToString.Split("-")
        Dim dd1 = ddl(0) * 1000
        Dim dd2 = ddl(1) * 1000
        Dim ai = 0
        Dim dbApk As New ClassApk(idev, Conn)

        For Each item In DatLog(nameFile)
            ai = ai + 1
            Dim tonu As String = item("to")
            Dim from As String = item("from")
            Dim platform As String = item("platform")
            Dim txtpesan As String = item("txtpesan")
            Dim numnew = "0" & tonu.Substring(3, 2) & "****" & tonu.Substring(8)
            Dim index As Integer = jsonpa.FindIndex(RDev, $"apk.{platform}.data", "number", from)
            Dim ganda As Boolean = Jdev("apk")(platform)("clone")
            Dim apkdef As Boolean = IIf(Jdev("apk")(platform)("data")(index)("apk") = "default", True, False)
            Dim delay As String = Jdev("apk")(platform)("data")(index)("delay")
            Dim login As Boolean = Jdev("apk")(platform)("data")(index)("login")
            Dim ResCal = String.Empty

            If (login = False) Then
                Exit For
            End If
            Thread.Sleep(delay)
            dbApk.HomeBtn()
            Dim WhatsApp As String = platform.Replace("w4b", ".w4b")


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
            Thread.Sleep(delay)
            Dim elCall = dbApk.FindElement($"//node[@resource-id='com.{WhatsApp}:id/conversation_contact_name']")
            If (elCall Is Nothing) Then
                dbApk.OpenWhatsAppMakeMsg(tonu, apkdef, ganda, WhatsApp, txtpesan)
                Thread.Sleep(2000)
                Dim elFind = dbApk.FindElement("//node[@resource-id='android:id/message']")
                If Not (elFind Is Nothing) Then
                    Dim elText = elFind.Attributes("text")
                    If (elText.Contains("tidak terdaftar di WhatsApp")) Then
                        item("text") = "nomer noreg"
                        File.WriteAllText(pathFile, DatLog.ToString())

                    End If
                End If
            End If
            Thread.Sleep(dd2)
            Dim Els = dbApk.FindElements($"//node[@resource-id='com.{WhatsApp}:id/message_text']")
            If Not (Els Is Nothing) Then
                If (Els.Count > 0) Then
                    For Each ItemElm In Els
                        Dim StrEl = ItemElm.Attributes("text")
                        If (StrEl.Contains(txtpesan)) Then
                            item("text") = "Terkirim"
                            File.WriteAllText(pathFile, DatLog.ToString())
                        End If
                    Next
                End If

            End If

        Next
    End Sub

    Private Sub btnSend_Paint(sender As Object, e As PaintEventArgs) Handles btnSend.Paint
        Dim width = btnSend.Width
        Dim Height = btnSend.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        btnSend.Region = New Region(path)
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

    Private Sub BtnPaste_Click(sender As Object, e As EventArgs) Handles BtnPaste.Click
        Dim DataNumber = Clipboard.GetText().TrimEnd
        '
        LblTotData.Text = "Total Data " & DataNumber.Split(vbNewLine).Count
        Dim arnum As New ArrayList
        Dim number As String = String.Empty
        For Each strLine As String In DataNumber.Split(vbNewLine)
            If (Not strLine Is Nothing) Then
                Dim strnum = Trim(strLine.Trim)
                Dim nol As Integer = strnum.Substring(0, 1)
                If (nol = 0) Then
                    number = "+62" & strLine.Trim.ToString.Substring(1)
                Else
                    number = "+62" & strLine
                End If

                arnum.Add(number)
            End If
        Next

        Dim numbr As String = Join(arnum.ToArray, ",")
        TxtNumber.Text = numbr.Replace(vbLf, "")

        ' service data parameter
        Dim param As New Dictionary(Of String, String)
        param.Add("dnumber", numbr)

        Try
            '  Ap_mrjay59.inkontak(param)
        Catch ex As Exception

        End Try
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

    Private Sub BtnStat_Click(sender As Object, e As EventArgs) Handles BtnStat.Click
        threadShouldStop = True
        PanelPusat.Controls.Clear()
    End Sub

    Private Sub BtnContact_Click(sender As Object, e As EventArgs) Handles BtnContact.Click

    End Sub
End Class