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

    Public BatchSenderStarted As Boolean = False
    Public DeviceUIMap As New Dictionary(Of String, UCDeviceUse)
    Public engine As New QueueEngine()

    Private WSSBuffer As New List(Of JObject)
    Private WSSLock As New Object()
    Private BatchSize As Integer = 5
    Private BatchDelayMs As Integer = 1000

    Private batchTimerRunning As Boolean = False
    Public IsStopped As Boolean = False

    Private DeviceTotal As New Dictionary(Of String, Integer)
    Private DeviceProgress As New Dictionary(Of String, Integer)
    Private DeviceDelay As New Dictionary(Of String, Integer)

    Private _akunid As New JArray
    Private _appArray As New JArray

    Public Enum DeviceStatus
        Idle
        Queued
        Sending
        Paused
        Retry
        ErrorState
        Done
    End Enum

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

    Private Async Sub kirim_msg()
        Dim metCal As String = String.Empty
        Dim templchk As String = String.Empty
        Dim TempTex As String = String.Empty
        Dim Coone As String = String.Empty
        If (rd0.Checked) Then
            metCal = "waserver"
            Coone = "WhatsApp"
        ElseIf (rd1.Checked) Then
            metCal = "wascanqr"
            Coone = "WhatsApp"
        ElseIf (rd2.Checked) Then
            metCal = "wadesktop"
            Coone = "Local"
        ElseIf (rd3.Checked) Then
            metCal = "LcAndroid"
            Coone = "TERMUX"
        ElseIf (rd4.Checked) Then
            metCal = "ClAndroid"
            Coone = "TERMUX"
        Else
            MsgBox("pilih metode kirim pesan terlebih dahulu")
            Exit Sub
        End If

        Dim tsender = TxtSender.Text.Trim
        Dim tmsg = TxtMessage.Text
        Dim tnumber = TxtNumber.Text

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "msg\"

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        If Not (IO.Directory.Exists(Foldsdr)) Then
            IO.Directory.CreateDirectory(Foldsdr)
        End If

        If (tsender = "") Then
            MsgBox("Akun Caller kosong/blank harap dipilih dulu")
            Exit Sub
        End If

        If (TxtNumber.Text = "") Then
            MsgBox("Data Number belum di Isi")
            Exit Sub
        End If

        If WSManager.Client Is Nothing OrElse Not WSManager.Client.IsConnected Then
            MsgBox("Web Socket belum terhubung silahkan close buka lagi ")
            Exit Sub
        End If

        If (Rsm.Checked) Then
            templchk = "manual"
        ElseIf (Rrm.Checked) Then
            templchk = "multi"
        Else
            MsgBox("pilih Template Single / multi")
            Exit Sub
        End If

        Dim jArrNumber As New JArray(
    TxtNumber.Text.Split(","c).
        Select(Function(x) New String(x.Where(Function(c) Char.IsDigit(c)).ToArray())).
        Where(Function(x) x <> "")
)

        BtnStateC.Enabled = True

        Dim newDev, JObject As New JObject
        Dim obj = JObject.Parse(DataJson)

        Dim appArray As New JArray(
    obj.Properties().
        First().
        Value.
        Select(Function(x) x("app").ToString()))

        Dim akunid As New JArray(obj.Properties().Select(Function(x) x.Name).ToArray())


        engine.Komu = "PU" '  
        engine.DelayMs = Delay.Value * 1000
        engine.MaxPutaran = 1

        Dim param As New JObject

        param.Add("akunid", akunid)
        param.Add("username", username)
        param.Add("app", appArray)
        param.Add("number", jArrNumber)
        param.Add("tipe_akun", metCal)

        Dim response = Ap_mrjay59.callsip(param)

        ' 🔥 VALIDASI STRING RESPONSE
        If String.IsNullOrWhiteSpace(response) Then

            MsgBox("Response Dari server gagal coba ulangi lagi ")
            Exit Sub
        End If

        Dim resp2arra As JObject = Nothing

        Try
            resp2arra = jsonpa.Json2aray(response)
        Catch ex As Exception
            MsgBox("Response bukan JSON valid: " & ex.Message)

            Exit Sub
        End Try

        ' 🔥 VALIDASI OBJECT
        If resp2arra Is Nothing OrElse Not resp2arra.HasValues Then
            MsgBox("JSON kosong")

            Exit Sub
        End If

        Dim resp2arr = jsonpa.Json2aray(response)
        If (resp2arr("status")("code") = 1) Then
            MsgBox(resp2arr("msg"))
            Exit Sub
        End If

        Dim reqid As String = resp2arr("data")("req_id").ToString
        Dim devArr As IEnumerable(Of JProperty) = resp2arr("data").Properties()

        Dim ai = 0
        Dim control = PnlogActivty.Controls.OfType(Of UCDeviceUse)()
        Dim datc = control.Count
        Dim pin As Integer = 0
        BtnLog.Tag = reqid


        For Each app In devArr
            Dim appName As String = app.Name

            If (appName = "req_id") Then
                Continue For
            End If

            Dim redev = 0
            Dim filog = Foldsdr & $"{appName}.json"
            If (File.Exists(filog)) Then
                File.Delete(filog)

            End If

            If Not (File.Exists(filog)) Then
                Dim ad = File.Create(filog)
                ad.Close()
                ad.Dispose()
            End If



            Dim oe = 0
            For Each number In app.Value
                Dim callnum As String = number
                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()

                If (templchk = "manual") Then
                    TempTex = tmsg
                ElseIf (templchk = "multi") Then
                    Dim TempT As Integer = oe Mod DatTemp.Count
                    TempTex = DatTemp(TempT)("IsiPesan").ToString
                End If

                newData.Add("connection", Coone)
                newData.Add("device", appName)
                newData.Add("to", callnum)
                newData.Add("platform", metCal)
                newData.Add("from", appName)
                newData.Add("text", TempTex)
                newData.Add("state", "")
                newData.Add("komu", "PU")

                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(appName)) Then
                    newDataArray.Add(newData)
                    logParse.Add("delay", Delay.Value)
                    'logParse.Add("tocall", JmRecall)
                    logParse.Add("komu", "PU")
                    logParse.Add(appName, newDataArray)
                    File.WriteAllText(filog, logParse.ToString())
                Else
                    Dim japkx As JArray = logParse.SelectToken(appName)
                    japkx.Add(newData)

                    File.WriteAllText(filog, logParse.ToString())
                End If

                If Not engine.DeviceQueues.ContainsKey(appName) Then
                    engine.DeviceQueues(appName) = New Concurrent.ConcurrentQueue(Of JObject)
                End If

                engine.DeviceQueues(appName).Enqueue(newData)


            Next

            Dim nameFile As String = appName
            ai = ai + 1
            Dim c = ai - 1

            If (datc > 0) Then
                Dim ab = datc + c
                pin = 35 * ab
            Else
                pin = 35 * c
            End If


            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = "Queued"
            Uiuse.lburut.Text = ai
            Uiuse.Location = New Point(0, pin)

            PnlogActivty.Controls.Add(Uiuse)

            ' 🔴 REGISTER UI DEVICE
            DeviceUIMap(appName) = Uiuse
            engine.DeviceTotal(appName) = engine.DeviceQueues(appName).Count
            DeviceTotal(appName) = app.Value.Count
            DeviceProgress(appName) = 0

        Next


        ' 🔥 CONNECT UI STATUS
        AddHandler engine.OnDeviceUpdate,
        Sub(dev, status, info)
            UpdateDeviceStatus(dev, status, info)
        End Sub

        ' 🔥 CONNECT WSS BATCHING (INI YANG KAMU TANYA)
        AddHandler engine.OnSendWSS,
        Sub(item)

            SyncLock WSSLock
                WSSBuffer.Add(item)

                If WSSBuffer.Count >= BatchSize Then
                    FlushWSS(reqid)
                End If
            End SyncLock

        End Sub

        ' 🔥 START TIMER BATCH (optional tapi recommended)
        StartBatchTimer(reqid)

        _akunid = akunid
        _appArray = appArray
        AddHandler engine.OnAllCompleted,
       Sub()

           ' stop timer batch
           batchTimerRunning = False

           ' flush sisa data
           FlushWSS(reqid)

           If (engine._isRunning) Then
               For Each dev In DeviceUIMap.Keys
                   UpdateDeviceStatus(dev, DeviceStatus.Done, "")
                   DeviceTotal(dev) = 0
               Next
               engine._isRunning = False
               engine.ClearAll()

               username = DPar("body")("apk_user").ToString()

               Dim varp As New JObject

               varp.Add("username", username)
               varp.Add("akunid", _akunid)
               varp.Add("app", _appArray)
               varp.Add("tipeAk", metCal)
               varp.Add("type", "msg_done")

               Ap_mrjay59.ws_receive(varp)
           End If

       End Sub

        ' 🔥 START ENGINE
        Await engine.StartAsync()
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

        kirim_msg()

    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim metCal As String = String.Empty
        If (rd0.Checked) Then
            metCal = "waserver"
        ElseIf (rd1.Checked) Then
            metCal = "wascanqr"
            ' ElseIf (rd2.Checked) Then
            '   metCal = "wadevice"
        ElseIf (rd3.Checked) Then
            metCal = "smsdevice"
        ElseIf (rd4.Checked) Then
            metCal = "smsserver"
            ' ElseIf (rd5.Checked) Then
            '     metCal = "emailserver"
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

    Private Sub InData(ByVal DataNumber As String)
        Dim arnum As New ArrayList
        Dim number As String = String.Empty
        For Each strLine As String In DataNumber.Split(vbNewLine)
            Dim strnum = Trim(strLine.Trim).Replace("-", "").Replace("+", "")

            If strnum.All(AddressOf Char.IsDigit) Then
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
        Dim DataNumber = Clipboard.GetText().TrimEnd.Replace("+", "")
        InData(DataNumber)
    End Sub

    Private Sub SendBatchToWSS(batch As JArray, ByVal reqid As String)

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim payload As New JObject From {
            {"request_id", reqid},
            {"to", username},
            {"data", batch},
            {"message", "send whatsapp via autocall"}
        }

        ' 🚀 KIRIM KE WSS (1x)
        RaiseEvent SendDataJson(Me, New ClassData(payload.ToString(Newtonsoft.Json.Formatting.None)))

        ' 🔥 UPDATE UI PER DEVICE
        For Each itm As JObject In batch

            Dim dev = itm("device").ToString()
            Dim number = itm("to").ToString()
            Dim komu = itm("komu").ToString().ToUpper()

            ' 🔥 progress +
            If DeviceProgress.ContainsKey(dev) Then
                DeviceProgress(dev) += 1
            Else
                DeviceProgress(dev) = 1
            End If

            Dim total = If(DeviceTotal.ContainsKey(dev), DeviceTotal(dev), 0)
            Dim current = DeviceProgress(dev)

            ' 🔥 Hitung putaran (cycle)
            ' contoh total=5
            ' current=1..5   => putaran 1
            ' current=6..10  => putaran 2
            ' current=11..15 => putaran 3

            Dim putaran As Integer = Math.Ceiling(current / total)

            ' posisi di putaran saat ini
            Dim posisi As Integer = current Mod total
            If posisi = 0 Then posisi = total

            ' 🔥 Format UI
            ' contoh:
            ' 6281xx PU Ke 1 2/5
            ' 6281xx PU Ke 2 5/5

            Dim maskedNumber As String = number

            If number.Length > 8 Then
                maskedNumber =
        number.Substring(0, 4) &
        New String("x"c, number.Length - 8) &
        number.Substring(number.Length - 4)
            End If

            Dim statusText As String =
    $"{maskedNumber} TotData:{posisi}/{total}"

            UpdateDeviceStatus(dev,
        DeviceStatus.Sending,
        statusText)

        Next

    End Sub

    Private Sub FlushWSS(ByVal reqid As String)

        If WSSBuffer.Count = 0 Then Exit Sub

        Dim arr As New JArray(WSSBuffer)
        WSSBuffer.Clear()

        SendBatchToWSS(arr, reqid)

    End Sub

    Private Async Sub StartBatchTimer(ByVal reqid As String)

        If batchTimerRunning Then Exit Sub
        batchTimerRunning = True

        Dim rnd As New Random()

        ' tracking waktu delay panjang terakhir
        Dim lastLongDelayTime As DateTime = DateTime.Now

        While batchTimerRunning

            ' =========================
            ' DELAY NORMAL
            ' =========================
            Await Task.Delay(BatchDelayMs)

            SyncLock WSSLock
                If WSSBuffer.Count > 0 Then
                    FlushWSS(reqid)
                End If
            End SyncLock

            ' =========================
            ' DELAY TAMBAHAN (SETIAP 5 MENIT)
            ' =========================
            Dim elapsed = DateTime.Now - lastLongDelayTime

            If elapsed.TotalMinutes >= breakmsg.Value Then

                ' random delay 1 - 5 menit
                Dim delayMinutes As Integer = rnd.Next(1, 6) ' 1 sampai 5
                Dim delayMs As Integer = delayMinutes * 60 * 1000

                Console.WriteLine($"[BATCH] Long delay triggered: {delayMinutes} menit")

                Await Task.Delay(delayMs)

                ' reset timer
                lastLongDelayTime = DateTime.Now

            End If

        End While

    End Sub




    Private Sub UpdateDeviceStatus(deviceKey As String,
                               status As DeviceStatus,
                               Optional info As String = "")

        If Not DeviceUIMap.ContainsKey(deviceKey) Then Exit Sub

        Dim ui = DeviceUIMap(deviceKey)

        If ui.InvokeRequired Then
            ui.Invoke(Sub() UpdateDeviceStatus(deviceKey, status, info))
            Exit Sub
        End If
        ui.lburut.Visible = True
        ui.lbname.Text = deviceKey

        Select Case status
            Case DeviceStatus.Idle

                ui.lbstatus.Text = "Idle"
                ui.lbstatus.ForeColor = Color.Gray

            Case DeviceStatus.Queued
                ui.lbstatus.Text = $"Queue {info}"
                ui.lbstatus.ForeColor = Color.Orange

            Case DeviceStatus.Sending

                If info <> "" Then
                    ui.lbstatus.Text = "Proses " & info
                Else
                    ui.lbstatus.Text = "Proses"
                End If

                ui.lbstatus.ForeColor = Color.White

            Case DeviceStatus.Paused
                ui.lbstatus.Text = "Paused"
                ui.lbstatus.ForeColor = Color.DarkOrange

            Case DeviceStatus.Retry
                ui.lbstatus.Text = $"Retry {info}"
                ui.lbstatus.ForeColor = Color.Purple

            Case DeviceStatus.ErrorState
                ui.lbstatus.Text = "Error"
                ui.lbstatus.ForeColor = Color.Red

            Case DeviceStatus.Done
                ui.lbstatus.Text = "Done"
                ui.lbstatus.ForeColor = Color.Green
        End Select
    End Sub

    Private Sub BtnTmpl_Click(sender As Object, e As EventArgs) Handles BtnTmpl.Click
        Dim metCal As String = String.Empty
        If (rd0.Checked) Then
            metCal = "waserver"
        ElseIf (rd1.Checked) Then
            metCal = "wascanqr"
            'ElseIf (rd2.Checked) Then
            '    metCal = "wadevice"
        ElseIf (rd3.Checked) Then
            metCal = "smsdevice"
        ElseIf (rd4.Checked) Then
            metCal = "smsserver"
            'ElseIf (rd5.Checked) Then
            '    metCal = "emailserver"
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

    Private Async Sub BtnResumeCall_Click(sender As Object, e As EventArgs) Handles BtnResumeCall.Click

        If (engine._isRunning) Then

            BtnResumeCall.Text = "Play All"
            BtnResumeCall.Image = My.Resources.icons8_play_20
            BtnStateC.BackColor = Color.Red

            For Each deviceKey In DeviceUIMap.Keys
                UpdateDeviceStatus(deviceKey, DeviceStatus.Paused)
            Next

            engine.Stop()

        Else

            If (DeviceUIMap.Keys.Count = 0) Then
                MsgBox("Data sudah habis silahkan klik clear ")
                Exit Sub
            End If

            BtnResumeCall.Text = "Stop All"
            BtnResumeCall.Image = My.Resources.icons8_stop_20
            BtnStateC.BackColor = Color.Orange


            For Each deviceKey In DeviceUIMap.Keys
                UpdateDeviceStatus(deviceKey, DeviceStatus.Sending)
            Next

            Await engine.ResumeAsync()

        End If
    End Sub

    Private Sub BtnRemoveCall_Click(sender As Object, e As EventArgs) Handles BtnRemoveCall.Click

        If engine._isRunning Then

            Dim result = MessageBox.Show(
        "Proses masih berjalan!" & vbCrLf &
        "Hapus semua data?",
        "Warning",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Warning
    )

            If result = DialogResult.No Then Exit Sub

        End If

        ' 🔴 Stop dulu
        engine.Stop()

        ' 🔴 Clear queue
        engine.ClearAll()


        ' 🔴 Update UI
        For Each deviceKey In DeviceUIMap.Keys
            DeviceTotal(deviceKey) = 0
            UpdateDeviceStatus(deviceKey, DeviceStatus.Idle, "Cleared")
        Next
        BtnStateC.BackColor = Color.DimGray
        PnlogActivty.Controls.Clear()
    End Sub

    Private Sub BtnLog_Click(sender As Object, e As EventArgs) Handles BtnLog.Click
        Dim reqid = BtnLog.Tag.ToString.Trim

        If (reqid Is Nothing) Then
            MsgBox("reqid kosong silahkan create call")
            Exit Sub
        End If

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim NObj As New JObject
        NObj.Add("title", "Cek LogCall Reqid " & reqid)
        NObj.Add("func", "log_sip")
        NObj.Add("reqid", reqid)
        NObj.Add("username", username)
        Dim page As New PgDialog(NObj.ToString)
        page.ShowDialog()
    End Sub
End Class