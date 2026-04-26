Imports Newtonsoft.Json.Linq
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports System.Threading
Public Class frmkirim
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private Ap_mrjay59 As New mrjay59
    Public threadShouldStop As Boolean = False
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private DataJson = Nothing
    Private DatTemp As New JArray
    Public Event SendDataJson As EventHandler(Of ClassData)
    Public cts As CancellationTokenSource
    Private sessionMap As New Dictionary(Of String, SessionData)
    Private sessionActive As New HashSet(Of String)()


    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub DataMasuk(sender As Object, e As ClassData)
        Dim RData As String = e.Data
        Dim DatObj = e.Data

        '  Console.WriteLine(DatObj)
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim akustat = ParData("body")("apk_stat").ToString
        Dim DatParse = jsonpa.Json2aray(DatObj)
        Dim fun = DatParse("fun").ToString

        If (fun = "WASCANQR") Then
            Dim NaDev = DatParse("NaDev")
            Dim Naplatform = DatParse("Naplatform")
            Dim NaLog = DatParse("NaLog")
            Dim NoWA = DatParse("NoWA")
            Dim prefix = DatParse("prefix")
            Dim Numkey = DatParse("numkey")
            Dim chk As Boolean = DatParse("chk")
            Dim DevNo = NaDev
            Dim newDataArray As New JArray()


            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtSender.Text &= NoWA & vbNewLine


                numData.Add("number", NoWA)
                numData.Add("numkey", Numkey)
                numData.Add("platform", Naplatform)
                numData.Add("login", NaLog)
                numData.Add("NaDev", NaDev)
                numData.Add("prefix", prefix)
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
                TxtSender.Text = Regex.Replace(TxtSender.Text.Replace(NoWA, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                jobject.Remove(DevNo)

                DataJson = jobject.ToString
            End If

            TotSender.Value = jobject.Count

        ElseIf (fun = "OnTemp") Then
            Dim title = DatParse("title")
            Dim IsiPesan = DatParse("IsiPesan")
            Dim chk As Boolean = DatParse("chk")

            If (chk = True) Then
                TxtMessage.Text &= title & vbNewLine

                Dim ObjO As New JObject
                ObjO.Add("title", title)
                ObjO.Add("IsiPesan", IsiPesan)
                DatTemp.Add(ObjO)
            ElseIf (chk = False) Then
                TxtMessage.Text = Regex.Replace(TxtMessage.Text.Replace(title, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)

                Dim itemToRemove As JObject = DatTemp.FirstOrDefault(Function(x) x("title")?.ToString() = title)

                If itemToRemove IsNot Nothing Then
                    DatTemp.Remove(itemToRemove)
                End If

                '  Console.WriteLine(DatTemp.ToString)
            End If


        End If



    End Sub

    Private Sub BtnSelect_Paint(sender As Object, e As PaintEventArgs)
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

    Private Sub btnSend_Paint(sender As Object, e As PaintEventArgs)
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

    Private Async Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "msg\"

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim tsender = TxtSender.Text.Trim
        Dim tmsg = TxtMessage.Text
        Dim tnumber = TxtNumber.Text
        Dim DataNumber = tnumber.Split(",")
        Dim jmData As Integer = TxtNumber.Text.Split(",").Count
        Dim jmSend As Integer = TotSender.Value
        Dim onefile As Integer = jmData / jmSend
        Dim metCal As String = String.Empty
        Dim del_msg As Integer = Delay.Value
        Dim bre_msg As Integer = breakmsg.Value
        Dim bre_time As Integer = Breaktime.Value
        Dim sisa As Integer = jmData Mod jmSend

        Dim allData As List(Of String) = DataNumber.ToList
        Dim dataPerSession(jmSend - 1) As List(Of String)

        Dim rnd As New Random()
        Dim delradom As Integer = rnd.Next(del_msg - 10, del_msg)
        Dim templchk As String = String.Empty

        If (rd0.Checked) Then
            metCal = "waserver"
        ElseIf (rd1.Checked) Then
            metCal = "wascanqr"
        ElseIf (rd2.Checked) Then
            metCal = "wadevice"
        ElseIf (rd3.Checked) Then
            metCal = "smsdevice"
        ElseIf (rd4.Checked) Then
            metCal = "smsserver"
        ElseIf (rd5.Checked) Then
            metCal = "emailserver"
        Else
            MsgBox("pilih metode kirim pesan terlebih dahulu")
            Exit Sub
        End If

        If (Rsm.Checked) Then
            templchk = "manual"
        ElseIf (Rrm.Checked)
            templchk = "multi"
        Else
            MsgBox("pilih Template Single / multi")
            Exit Sub
        End If

        If (tnumber = "") Then
            MsgBox("Data Number kosong ")
            Exit Sub
        End If

        If (tmsg = "") Then
            MsgBox("Data Message Kosong ")
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
        btnSend.Enabled = False


        Dim pingResult As PingReply = dbConn.PingDomain("www.mrjay59.com")
        ' Tampilkan hasil ping
        If pingResult.Status = 11010 Then
            MsgBox("Sepertinya Koneksi Ke Server Gagal Coba Gunakan Jaringan lain")

            Exit Sub
        End If


        Dim newDev, JObject As New JObject
        JObject = JObject.Parse(DataJson)
        Dim ur = 0
        Dim aw = 0
        Dim ak = 0

        Dim ai = 0
        Dim af = 0
        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()
        Dim control = PnlogActivty.Controls.OfType(Of UCDeviceUse)()
        Dim datc = control.Count
        Dim pin As Integer = 0
        Dim indx As Integer = 0
        AddHandler Form1.SendDataJson, AddressOf OnReceiveData

        Dim TempTex As String = String.Empty

        For Each prop As JProperty In properties
            Dim DataDev = prop.Name
            Dim jmsender = JObject.Count
            Dim txsender = JObject.SelectToken(DataDev).Item("number").ToString
            Dim numkey = JObject.SelectToken(DataDev).Item("numkey").ToString
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


            Dim filog = Foldsdr & $"{DataDev}.json"
            If (File.Exists(filog)) Then
                File.Delete(filog)
            End If


            If Not (File.Exists(filog)) Then
                Dim ad = File.Create(filog)
                ad.Close()
                ad.Dispose()
            End If

            Dim oe = 0
            For Each nomor As String In dataPerSession(xr)

                If (templchk = "manual") Then
                    TempTex = tmsg
                ElseIf (templchk = "multi") Then
                    Dim TempT As Integer = oe Mod DatTemp.Count
                    TempTex = DatTemp(TempT)("IsiPesan").ToString
                End If

                Dim number = nomor
                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()
                newData.Add("to", prefix & number)
                newData.Add("from", txsender)
                newData.Add("text", TempTex)
                newData.Add("numkey", numkey)
                newData.Add("state", "")

                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(DataDev)) Then
                    newDataArray.Add(newData)
                    logParse.Add("delay", del_msg)
                    logParse.Add("breakm", bre_msg)
                    logParse.Add("breakt", bre_time)
                    logParse.Add("username", username)
                    logParse.Add("metCal", metCal)

                    logParse.Add(DataDev, newDataArray)
                    File.WriteAllText(filog, logParse.ToString())
                Else
                    Dim japkx As JArray = logParse.SelectToken(DataDev)
                    japkx.Add(newData)

                    File.WriteAllText(filog, logParse.ToString())
                End If
                oe += 1
            Next

            Try


                Dim nameFile As String = DataDev
                Dim b As String = File.ReadAllText(filog)
                Dim jObj = JObject.Parse(b)
                ai = ai + 1
                Dim c = ai - 1


                If (datc > 0) Then
                    Dim ab = datc + c
                    pin = 35 * ab
                Else
                    pin = 35 * c
                End If

                Dim dataList As New List(Of JObject)

                If jObj.ContainsKey(nameFile) Then
                    dataList = jObj(nameFile).Select(Function(x) CType(x, JObject)).ToList()
                End If

                Dim sessionData As New SessionData With {
                    .Messages = dataList,
                    .Username = username,
                    .MetCall = metCal
                }


                sessionMap(nameFile) = sessionData
                sessionActive.Add(nameFile)


                Dim Uiuse As New UCDeviceUse
                Uiuse.lbname.Text = Trim(DataDev.Trim)
                Uiuse.lburut.Text = ai
                Uiuse.lbstatus.Text = "Wait.."
                Uiuse.Location = New Point(0, pin)
                Uiuse.OpenMirrorToolStripMenuItem.Visible = False
                Uiuse.BtnStat.Visible = False
                Uiuse.BtnNext.Visible = False
                Uiuse.ContextMenuStrip = Uiuse.KlikAnan
                PnlogActivty.Controls.Add(Uiuse)


            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try
        Next
        cts = New CancellationTokenSource()
        Dim index As Integer = 0
        Dim ure As Integer = 0

        Try

            Do While sessionActive.Count > 0
                ure = ure + 1
                Dim batchTasks As New List(Of Task(Of JObject))()

                ' Cek semua session yang masih aktif
                For Each sessionName In sessionActive.ToList() ' Salin ke list agar bisa diubah saat iterasi
                    Dim session = sessionMap(sessionName)

                    Dim messages = session.Messages
                    Dim userna = session.Username
                    Dim metCall = session.MetCall

                    ' Kirim data ke session ini
                    If index < messages.Count Then
                        Dim item = messages(index)
                        batchTasks.Add(Task.Run(Function()
                                                    Return SendSingleMessageAsync(item, sessionName, userna, metCall, index, messages.Count, cts.Token)
                                                End Function))
                    Else
                        ' Data habis → keluarkan dari set aktif
                        sessionActive.Remove(sessionName)

                        ' Update UI atau status
                        Dim controlx = PnlogActivty.Controls.OfType(Of UCDeviceUse)().
                              FirstOrDefault(Function(x) x.lbname.Text = sessionName)
                        If controlx IsNot Nothing Then
                            controlx.Invoke(Sub()
                                                controlx.lbstatus.Text = "SELESAI - Semua pesan terkirim"
                                            End Sub)
                        End If
                    End If
                Next


                ' Tunggu semua task dalam batch ini
                If batchTasks.Count > 0 Then
                    Dim hasil = Await Task.WhenAll(batchTasks)
                    Dim hasilJArray As New JArray()
                    Dim ObjBody As New JObject
                    hasilJArray.Add(hasil)
                    ObjBody.Add("body", hasilJArray)

                    RaiseEvent SendDataJson(Me, New ClassData(ObjBody.ToString(Newtonsoft.Json.Formatting.None)))

                    'Console.WriteLine(ObjBody.ToString)
                    Dim aaWait As Integer = 0

                    If (ure = bre_msg) Then
                        aaWait = bre_time * 60
                        ure = 0
                    Else
                        aaWait = delradom
                    End If


                    Dim waitTime As TimeSpan = TimeSpan.FromSeconds(aaWait)
                    Dim interval As TimeSpan = TimeSpan.FromSeconds(30) ' Cek setiap 30 detik

                    While waitTime > TimeSpan.Zero
                        Dim delayTime = If(waitTime > interval, interval, waitTime)
                        Await Task.Delay(delayTime, cts.Token)
                        waitTime -= delayTime

                        ' Update UI dengan sisa waktu
                        lblCountState.Text = $"Menunggu {waitTime:mm\:ss} lagi..."
                    End While
                End If

                index += 1
            Loop

        Catch ex As OperationCanceledException
            MsgBox("Task dibatalkan")
        End Try



        RemoveHandler Form1.SendDataJson, AddressOf OnReceiveData

        btnSend.Enabled = True



    End Sub

    Private Async Function SendSingleMessageAsync(item As JObject, sessionName As String, username As String, metCall As String, ur As Integer,
                                              totalCount As Integer, ct As CancellationToken) As Task(Of JObject)
        ct.ThrowIfCancellationRequested()

        Dim tonu = item("to").ToString()
        Dim fromx = item("from").ToString()
        Dim numkey = item("numkey").ToString()
        Dim text = item("text").ToString()

        Dim jsdata As New JObject From {
        {"name", sessionName},
        {"username", username},
        {"tonum", tonu},
        {"tsender", fromx},
        {"text", text},
        {"metCall", metCall},
        {"func", "OnReceive"}
    }

        ' --- Update UI (status pengiriman) ---
        Dim control = PnlogActivty.Controls.
                  OfType(Of UCDeviceUse)().
                  FirstOrDefault(Function(x) x.lbname IsNot Nothing AndAlso
                                               x.lbname.Text.Trim().Equals(sessionName.Trim(), StringComparison.OrdinalIgnoreCase))

        If control IsNot Nothing Then
            control.Invoke(Sub()
                               control.lbstatus.Text = $"SEND ke {tonu} [{Now:HH:mm:ss}] TTL:{ur}/{totalCount}"
                           End Sub)
        End If

        ' Simulasi delay + UI
        Await Task.Delay(200, ct)
        Return jsdata
    End Function


    Private Sub OnReceiveData(sender As Object, e As ClassData)
        Dim msg = e.Data
        'Console.WriteLine(msg.ToString)
        Try
            Dim DPar = jsonpa.Json2aray(msg)
            Dim seassionId As String = DPar("sessionId")
            Dim state As String = DPar("state")
            Dim message As String = DPar("message")

            If (state = "CLOSE") Then
                ' Data habis → keluarkan dari set aktif
                sessionActive.Remove(seassionId)
            End If

            ' Update UI atau status
            Dim controlx = PnlogActivty.Controls.OfType(Of UCDeviceUse)().
                          FirstOrDefault(Function(x) x.lbname.Text = seassionId)

            If controlx IsNot Nothing Then
                controlx.Invoke(Sub()
                                    controlx.lbstatus.Text = message

                                    If (state = "CLOSE") Then

                                        controlx.BackColor = Color.DarkGreen
                                        controlx.ForeColor = Color.White
                                    End If
                                End Sub)
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim metCal As String = String.Empty
        If (rd0.Checked) Then
            metCal = "waserver"
        ElseIf (rd1.Checked) Then
            metCal = "wascanqr"
        ElseIf (rd2.Checked) Then
            metCal = "wadevice"
        ElseIf (rd3.Checked) Then
            metCal = "smsdevice"
        ElseIf (rd4.Checked) Then
            metCal = "smsserver"
        ElseIf (rd5.Checked) Then
            metCal = "emailserver"
        Else
            MsgBox("pilih metode kirim pesan terlebih dahulu")

            Exit Sub
        End If

        TxtSender.Text = ""
        DataJson = Nothing
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        If (metCal = "waserver") Then
            Dim NObj As New JObject
            NObj.Add("title", "Pilih WA SERVER")
            NObj.Add("func", "lolistDialler")
            Dim page As New PgDialog(NObj.ToString)
            page.SendDataUser = DatR
            AddHandler page.DataSelected, AddressOf DataMasuk
            page.ShowDialog()
            RemoveHandler page.DataSelected, AddressOf DataMasuk
        ElseIf (metCal = "wascanqr") Then
            Dim NObj As New JObject
            NObj.Add("title", "Pilih WA SCANQr")
            NObj.Add("func", "loadWA")
            NObj.Add("username", username)
            Dim page As New PgDialog(NObj.ToString)

            AddHandler page.DataSelected, AddressOf DataMasuk

            page.ShowDialog()

            RemoveHandler page.DataSelected, AddressOf DataMasuk
        End If
    End Sub

    Private Sub BtnContact_Click(sender As Object, e As EventArgs) Handles BtnContact.Click
        TxtNumber.Text = ""

        Dim NObj As New JObject
        NObj.Add("title", "Connect Link Spreadsheet")
        NObj.Add("func", "lolistKontak")
        Dim page As New PgDialog(NObj.ToString)
        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()
    End Sub

    Private Sub InData(ByVal DataNumber As String)
        Dim arnum As New ArrayList
        Dim number As String = String.Empty
        For Each strLine As String In DataNumber.Split(vbNewLine)
            Dim strnum = Trim(strLine.Trim).Replace("-", "").Replace("\n", "")
            If Not (strnum = "") Then
                Dim nol As Integer = strnum.Substring(0, 1)
                Dim endua As Integer = strnum.Substring(0, 2)
                If (nol = 0) Then
                    number = strnum.Trim.ToString.Substring(1)
                ElseIf (endua = 62) Then
                    number = strnum.Trim.ToString.Substring(2)
                Else
                    number = strnum
                End If

                arnum.Add(number)
            End If
        Next


        Dim jmDial As Integer = TotSender.Text

        If (jmDial <= 0) Then
            MsgBox("Opp belum ada  sender pilih dulu iya")
            TxtNumber.Text = ""
            Exit Sub
        End If

        LblTotData.Text = "Total Data :" & arnum.Count
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

    Private Sub BtnStopCall_Click(sender As Object, e As EventArgs) Handles BtnStopCall.Click
        If cts IsNot Nothing Then
            cts.Cancel()

            PnlogActivty.Controls.Clear()

            RemoveHandler Form1.SendDataJson, AddressOf OnReceiveData
        End If
    End Sub

    Public Class SessionData
        Public Property Messages As List(Of JObject)
        Public Property Username As String
        Public Property MetCall As String
    End Class

    Private Sub BtnTmpl_Click(sender As Object, e As EventArgs) Handles BtnTmpl.Click
        Dim metCal As String = String.Empty
        If (rd0.Checked) Then
            metCal = "waserver"
        ElseIf (rd1.Checked) Then
            metCal = "wascanqr"
        ElseIf (rd2.Checked) Then
            metCal = "wadevice"
        ElseIf (rd3.Checked) Then
            metCal = "smsdevice"
        ElseIf (rd4.Checked) Then
            metCal = "smsserver"
        ElseIf (rd5.Checked) Then
            metCal = "emailserver"
        Else
            MsgBox("pilih metode kirim pesan terlebih dahulu")

            Exit Sub
        End If

        Dim templchk As String = String.Empty
        If (Rsm.Checked) Then
            templchk = "manual"
        ElseIf (Rrm.Checked)
            templchk = "multi"
        Else
            MsgBox("pilih Template Single / multi")
            Exit Sub
        End If

        If (TxtNumber.Text = "") Then
            MsgBox("Input Data Number Tidak Ada")
            Exit Sub
        End If

        If (Rrm.Checked) Then
            TxtMessage.Text = ""
            DatTemp.RemoveAll()
            Dim page As New pgTemplate
            page.SendDataUser = DatR
            AddHandler page.DataSelected, AddressOf DataMasuk

            page.ShowDialog()


            RemoveHandler page.DataSelected, AddressOf DataMasuk
        End If

    End Sub

    Private Sub Rrm_CheckedChanged(sender As Object, e As EventArgs) Handles Rrm.CheckedChanged
        BtnTmpl.Enabled = True
        TxtMessage.ReadOnly = True
    End Sub

    Private Sub Rsm_CheckedChanged(sender As Object, e As EventArgs) Handles Rsm.CheckedChanged
        BtnTmpl.Enabled = False
        TxtMessage.ReadOnly = False
    End Sub
End Class