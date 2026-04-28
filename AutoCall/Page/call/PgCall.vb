Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Collections.Concurrent

Public Class PgCall
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect

    Private Ap_mrjay59 As New mrjay59
    Public threadShouldStop As Boolean = False
    Private DatR As String = String.Empty
    Private DataJson = Nothing

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

    Private Async Sub SipLocal()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "caller\"
        Dim foldial = fodev & "\siploc"
        Dim komu As String = String.Empty
        If (rd0.Checked) Then
            komu = "PU"
        ElseIf (rd1.Checked) Then
            komu = "BE"
        Else
            MsgBox("Mau Call Secara apa checked dulu iya")
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

        If (TxtCaller.Text = "") Then
            MsgBox("Akun Caller kosong/blank harap dipilih dulu")
            Exit Sub
        End If

        If (TxtNumber.Text = "") Then
            MsgBox("Data Number belum di Isi")
            Exit Sub
        End If

        engine.Komu = komu ' "BE" atau "PU"
        engine.DelayMs = TotClose.Value * 1000
        engine.MaxPutaran = TotRecall.Value

        Dim DataNumber = TxtNumber.Text.Split(",")
        Dim ststop As String = btnCaller.Text
        Dim jmData As Integer = DataNumber.Length
        Dim jmDial As Integer = TotDial.Value
        Dim JmDurasi As Integer = TotDurasi.Value
        Dim JmRecall As Integer = TotRecall.Value
        Dim JmClose As Integer = TotClose.Value

        Dim jArrNumber As New JArray(
    TxtNumber.Text.Split(","c).
        Select(Function(x) New String(x.Where(Function(c) Char.IsDigit(c)).ToArray())).
        Where(Function(x) x <> "")
)

        BtnStateC.Enabled = True

        Dim newDev, JObject As New JObject
        Dim obj = JObject.Parse(DataJson)

        Dim appArray As New JArray(obj.Properties().Select(Function(p) p.Value("app").ToString()))


        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim param As New JObject
        param.Add("username", username)
        param.Add("app", appArray)
        param.Add("number", jArrNumber)
        param.Add("tipe_akun", "siplocal")

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

            For Each item In resp2arr("msg")
                MsgBox(item)
            Next
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

            ' Replace non-numeric characters
            Dim namdial As String = Regex.Replace(appName, "[^a-z]", "")
            Dim FiName As String = foldial & "\" & namdial & ".json"
            Dim RSIP As String = File.ReadAllText(FiName)
            Dim CekSip = JObject.Parse(RSIP)
            Dim prefix As String = CekSip("prefix_dial").ToString
            ' Dim pathSip As New JArray
            'pathSip = CekSip(namdial)

            Dim pathName = CekSip(namdial).FirstOrDefault(Function(x) x("name").ToString() = appName)?("path")?.ToString()
            Dim redev = 0
            Dim filog = Foldsdr & $"{appName}.json"
            If (File.Exists(filog)) Then
                File.Delete(filog)
            End If

            If Not (File.Exists(pathName)) Then
                MsgBox($"Folder {appName} tidak di temukan silahkan setting ulang")

                Exit Sub
            End If

            If Not (File.Exists(filog)) Then
                Dim ad = File.Create(filog)
                ad.Close()
                ad.Dispose()
            End If



            For Each number In app.Value
                Dim callnum As String = prefix & number.ToString
                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()
                subData.Add("MG", 0)
                subData.Add("BR", 0)
                subData.Add("AN", 0)
                newData.Add("device", appName)
                newData.Add("connection", "SIPLocal")
                newData.Add("komu", komu)
                newData.Add("to", callnum)
                newData.Add("from", pathName)
                newData.Add("platform", namdial)
                newData.Add("text", "")
                newData.Add("result", subData)
                newData.Add("recall", 0)
                newData.Add("tocall", JmRecall)
                newData.Add("status", "queued")
                newData.Add("retry", 0)
                newData.Add("lastError", "")
                newData.Add("delay", JmClose)

                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(appName)) Then
                    newDataArray.Add(newData)
                    logParse.Add("delay", JmClose)
                    logParse.Add("tocall", JmRecall)
                    logParse.Add("komu", komu)
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


            Dim DtObj As New JObject
            DtObj.Add("fitur", "siplocal")
            DtObj.Add("namedial", appName)
            DtObj.Add("pathFile", filog.ToString)
            DtObj.Add("pathexe", "")
            DtObj.Add("komu", komu)

            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = "Queued"
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
            PnlogActivty.Controls.Add(Uiuse)

            ' 🔴 REGISTER UI DEVICE
            DeviceUIMap(appName) = Uiuse
            engine.DeviceTotal(appName) = engine.DeviceQueues(appName).Count


        Next

        AddHandler engine.OnDeviceUpdate,
                Sub(device, status, info)
                    UpdateDeviceStatus(device, status, info)
                End Sub

        AddHandler engine.OnAllCompleted,
    Sub()

        If (engine._isRunning) Then
            For Each dev In DeviceUIMap.Keys
                UpdateDeviceStatus(dev, DeviceStatus.Done, "")
                DeviceTotal(dev) = 0
            Next

            engine._isRunning = False
            engine.ClearAll()
        End If


    End Sub

        Await engine.StartAsync()





    End Sub

    Private Async Sub sipse()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "caller\"

        Dim komu As String = String.Empty
        If (rd0.Checked) Then
            komu = "PU"
        ElseIf (rd1.Checked) Then
            komu = "BE"
        Else
            MsgBox("Mau Call Secara apa checked dulu iya")
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

        If (TxtCaller.Text = "") Then
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

        engine.Komu = komu ' "BE" atau "PU"
        engine.DelayMs = TotClose.Value * 1000
        engine.MaxPutaran = TotRecall.Value

        Dim DataNumber = TxtNumber.Text.Split(",")
        Dim ststop As String = btnCaller.Text
        Dim jmData As Integer = DataNumber.Length
        Dim jmDial As Integer = TotDial.Value
        Dim JmDurasi As Integer = TotDurasi.Value
        Dim JmRecall As Integer = TotRecall.Value
        Dim JmClose As Integer = TotClose.Value

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

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim param As New JObject

        param.Add("akunid", akunid)
        param.Add("username", username)
        param.Add("app", appArray)
        param.Add("number", jArrNumber)
        param.Add("tipe_akun", "sipserver")

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
            For Each item In resp2arr("msg")
                MsgBox(item)
            Next
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




            For Each number In app.Value
                Dim callnum As String = number
                Dim newData, subData As New JObject
                Dim newDataArray As New JArray()

                subData.Add("MG", 0)
                subData.Add("BR", 0)
                subData.Add("AN", 0)
                newData.Add("device", appName)
                newData.Add("connection", "SIPServer")
                newData.Add("komu", komu)
                newData.Add("to", callnum)
                newData.Add("req_id", reqid)
                newData.Add("from", appName)
                newData.Add("platform", appName)
                newData.Add("text", "")
                newData.Add("result", subData)
                newData.Add("recall", 0)
                newData.Add("tocall", JmRecall)
                newData.Add("status", "queued")
                newData.Add("retry", 0)
                newData.Add("lastError", "")
                newData.Add("delay", JmClose)

                Dim logParse As New JObject
                Dim Rlog As String = File.ReadAllText(filog)
                If Not (Rlog = "") Then
                    logParse = JObject.Parse(Rlog)
                End If

                If Not (logParse.ContainsKey(appName)) Then
                    newDataArray.Add(newData)
                    logParse.Add("delay", JmClose)
                    logParse.Add("tocall", JmRecall)
                    logParse.Add("komu", komu)
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


            Dim DtObj As New JObject
            DtObj.Add("fitur", "SIPServer")
            DtObj.Add("namedial", appName)
            DtObj.Add("pathFile", filog.ToString)
            DtObj.Add("pathexe", "")
            DtObj.Add("komu", komu)

            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = "Queued"
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
               varp.Add("tipeAk", "sipserver")
               varp.Add("type", "call_done")

               Ap_mrjay59.ws_receive(varp)
           End If

       End Sub

        ' 🔥 START ENGINE
        Await engine.StartAsync()



    End Sub

    Private Async Sub LocalAndro()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "caller\"
        Dim komu As String = String.Empty
        If (rd0.Checked) Then
            komu = "PU"
        ElseIf (rd1.Checked) Then
            komu = "BE"
        Else
            MsgBox("Mau Call Secara apa checked dulu iya")
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

        If (TxtCaller.Text = "") Then
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

        ' 🔥 SET CONFIG
        engine.Komu = komu
        engine.DelayMs = TotClose.Value * 1000
        engine.MaxPutaran = TotRecall.Value


        Dim DataNumber = TxtNumber.Text.Split(",")
        Dim ststop As String = btnCaller.Text
        Dim jmData As Integer = DataNumber.Length
        Dim jmDial As Integer = TotDial.Value
        Dim JmDurasi As Integer = TotDurasi.Value
        Dim JmRecall As Integer = TotRecall.Value
        Dim JmClose As Integer = TotClose.Value

        Dim jArrNumber As New JArray(
    TxtNumber.Text.Split(","c).
        Select(Function(x) New String(x.Where(Function(c) Char.IsDigit(c)).ToArray())).
        Where(Function(x) x <> "")
)

        threadShouldStop = False
        BtnStateC.Enabled = True

        Dim newDev, JObject As New JObject
        Dim obj = JObject.Parse(DataJson)

        Dim appArray As New JArray(
    obj.Properties().
        First().
        Value.
        Select(Function(x) x("app").ToString()))


        Dim DeviceArray As New JArray(
    obj.Properties().
        Select(Function(p) p.Name)
)

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim param As New JObject


        param.Add("username", username)
        param.Add("app", appArray)
        param.Add("number", jArrNumber)
        param.Add("device", DeviceArray)
        param.Add("tipe_akun", "lodevice")

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
            For Each item In resp2arr("msg")
                MsgBox(item)
            Next
            Exit Sub
        End If

        Dim reqid As String = resp2arr("data")("req_id").ToString
        Dim devArr As IEnumerable(Of JProperty) = resp2arr("data").Properties()

        Dim ur = 0
        Dim aw = 0
        Dim ak = 0
        Dim indx As Integer = 0
        Dim ai = 0
        ' Create and start 10 threads
        Dim control = PnlogActivty.Controls.OfType(Of UCDeviceUse)()
        Dim datc = control.Count
        Dim pin As Integer = 0
        BatchSize = devArr.Count
        BtnLog.Tag = reqid


        For Each devprop In devArr

            If devprop.Value.Type <> JTokenType.Object Then Continue For

            Dim noserial As String = devprop.Name

            Dim appArr = resp2arr(noserial)
            Dim approp As IEnumerable(Of JProperty) = appArr.Properties()

            Dim redev = 0
            Dim filog = Foldsdr & $"{noserial}.json"
            If (File.Exists(filog)) Then
                File.Delete(filog)

            End If

            If Not (File.Exists(filog)) Then
                Dim ad = File.Create(filog)
                ad.Close()
                ad.Dispose()
            End If

            Dim devc As Integer = 0
            Dim ux = 0
            For Each prop As JProperty In approp
                Dim DataDev = prop.Name
                Dim numbers As JArray = resp2arr(noserial)(DataDev)
                devc = devc + numbers.Count
                Dim result = obj(noserial).FirstOrDefault(Function(x) x("app").ToString().ToLower = DataDev.ToLower)
                Dim prefix = If(result?("prefix")?.ToString(), Nothing)
                Dim nohp = If(result?("NoHp")?.ToString(), Nothing)
                Dim sim = nohp 'nohp.Replace("sim1", 0).Replace("sim2", 1).ToString

                For Each number In numbers
                    Dim callnum = prefix & number.ToString
                    Dim newData, subData As New JObject
                    Dim newDataArray As New JArray()
                    subData.Add("MG", 0)
                    subData.Add("BR", 0)
                    subData.Add("AN", 0)
                    newData.Add("device", noserial)
                    newData.Add("connection", "TERMUX")
                    newData.Add("permission", "call")
                    newData.Add("type", "voice")
                    newData.Add("to", callnum)
                    newData.Add("from", nohp)
                    newData.Add("sim", sim)
                    newData.Add("platform", DataDev)
                    newData.Add("text", "")
                    newData.Add("result", subData)
                    newData.Add("recall", 0)
                    newData.Add("tocall", JmRecall)
                    newData.Add("status", "queued")
                    newData.Add("retry", 0)
                    newData.Add("lastError", "")
                    newData.Add("delay", JmClose)

                    Dim logParse As New JObject
                    Dim Rlog As String = File.ReadAllText(filog)
                    If Not (Rlog = "") Then
                        logParse = JObject.Parse(Rlog)
                    End If

                    If Not (logParse.ContainsKey(noserial)) Then
                        newDataArray.Add(newData)
                        logParse.Add("delay", JmClose)
                        logParse.Add("tocall", JmRecall)
                        logParse.Add(noserial, newDataArray)
                        File.WriteAllText(filog, logParse.ToString())
                    Else
                        Dim japkx As JArray = logParse.SelectToken(noserial)
                        japkx.Add(newData)

                        File.WriteAllText(filog, logParse.ToString())
                    End If

                    If Not engine.DeviceQueues.ContainsKey(noserial) Then
                        engine.DeviceQueues(noserial) = New Concurrent.ConcurrentQueue(Of JObject)
                    End If

                    engine.DeviceQueues(noserial).Enqueue(newData)

                Next
                ux = ux + 1
            Next

            Dim nameFile As String = noserial
            ai = ai + 1
            Dim c = ai - 1

            If (datc > 0) Then
                Dim ab = datc + c
                pin = 35 * ab
            Else
                pin = 35 * c
            End If


            Dim DtObj As New JObject
            DtObj.Add("fitur", "cloAndro")
            DtObj.Add("namedial", noserial)
            DtObj.Add("pathFile", filog.ToString)
            DtObj.Add("pathexe", "")
            DtObj.Add("komu", komu)

            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = "Queued"
            Uiuse.lbname.Tag = DtObj.ToString
            Uiuse.lburut.Text = ai
            Uiuse.Location = New Point(0, pin)
            If (komu = "Ya") Then
                Uiuse.BtnStat.Visible = True
            Else
                Uiuse.BtnNext.Enabled = False
            End If

            PnlogActivty.Controls.Add(Uiuse)

            ' 🔴 REGISTER UI DEVICE
            DeviceUIMap(noserial) = Uiuse
            engine.DeviceTotal(noserial) = engine.DeviceQueues(noserial).Count
            DeviceTotal(noserial) = devc
            DeviceProgress(noserial) = 0

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
        End If

    End Sub

        ' 🔥 START ENGINE
        Await engine.StartAsync()



    End Sub

    Private Async Sub clouldAndro()

        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\log\"
        Dim Foldsdr = FoldeQ & "caller\"
        Dim komu As String = String.Empty
        If (rd0.Checked) Then
            komu = "PU"
        ElseIf (rd1.Checked) Then
            komu = "BE"
        Else
            MsgBox("Mau Call Secara apa checked dulu iya")
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

        If (TxtCaller.Text = "") Then
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



        ' 🔥 SET CONFIG
        engine.Komu = komu
        engine.DelayMs = TotClose.Value * 1000
        engine.MaxPutaran = TotRecall.Value


        Dim DataNumber = TxtNumber.Text.Split(",")
        Dim ststop As String = btnCaller.Text
        Dim jmData As Integer = DataNumber.Length
        Dim jmDial As Integer = TotDial.Value
        Dim JmDurasi As Integer = TotDurasi.Value
        Dim JmRecall As Integer = TotRecall.Value
        Dim JmClose As Integer = TotClose.Value

        Dim jArrNumber As New JArray(
    TxtNumber.Text.Split(","c).
        Select(Function(x) New String(x.Where(Function(c) Char.IsDigit(c)).ToArray())).
        Where(Function(x) x <> "")
)

        threadShouldStop = False
        BtnStateC.Enabled = True

        Dim newDev, JObject As New JObject
        Dim obj = JObject.Parse(DataJson)

        Dim appArray As New JArray(
    obj.Properties().
        First().
        Value.
        Select(Function(x) x("app").ToString()))

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim param As New JObject

        '  param.Add("akun", idAArray)
        param.Add("username", username)
        param.Add("app", appArray)
        param.Add("number", jArrNumber)
        param.Add("tipe_akun", "cldevice")

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
            For Each item In resp2arr("msg")
                MsgBox(item)
            Next
            Exit Sub
        End If


        Dim reqid As String = resp2arr("data")("req_id").ToString
        Dim devArr As IEnumerable(Of JProperty) = resp2arr("data").Properties()

        Dim ur = 0
        Dim aw = 0
        Dim ak = 0
        Dim indx As Integer = 0
        Dim ai = 0
        ' Create and start 10 threads
        Dim control = PnlogActivty.Controls.OfType(Of UCDeviceUse)()
        Dim datc = control.Count
        Dim pin As Integer = 0
        BatchSize = devArr.Count
        BtnLog.Tag = reqid


        For Each devprop In devArr

            If devprop.Value.Type <> JTokenType.Object Then Continue For

            Dim noserial As String = devprop.Name

            Dim appArr = resp2arr(noserial)
            Dim approp As IEnumerable(Of JProperty) = appArr.Properties()

            Dim redev = 0
            Dim filog = Foldsdr & $"{noserial}.json"
            If (File.Exists(filog)) Then
                File.Delete(filog)

            End If

            If Not (File.Exists(filog)) Then
                Dim ad = File.Create(filog)
                ad.Close()
                ad.Dispose()
            End If

            Dim devc As Integer = 0
            For Each prop As JProperty In approp
                Dim DataDev = prop.Name
                Dim numbers As JArray = resp2arr(noserial)(DataDev)
                devc = devc + numbers.Count
                For Each number In numbers
                    Dim callnum As String = number
                    Dim newData, subData As New JObject
                    Dim newDataArray As New JArray()
                    subData.Add("MG", 0)
                    subData.Add("BR", 0)
                    subData.Add("AN", 0)
                    newData.Add("device", noserial)
                    newData.Add("connection", "TERMUX")
                    newData.Add("permission", "call")
                    newData.Add("type", "voice")
                    newData.Add("to", callnum)
                    newData.Add("from", noserial)
                    'newData.Add("sim", sim)
                    newData.Add("platform", DataDev)
                    newData.Add("text", "")
                    newData.Add("result", subData)
                    newData.Add("recall", 0)
                    newData.Add("tocall", JmRecall)
                    newData.Add("status", "queued")
                    newData.Add("retry", 0)
                    newData.Add("lastError", "")
                    newData.Add("delay", JmClose)

                    Dim logParse As New JObject
                    Dim Rlog As String = File.ReadAllText(filog)
                    If Not (Rlog = "") Then
                        logParse = JObject.Parse(Rlog)
                    End If

                    If Not (logParse.ContainsKey(noserial)) Then
                        newDataArray.Add(newData)
                        logParse.Add("delay", JmClose)
                        logParse.Add("tocall", JmRecall)
                        logParse.Add(noserial, newDataArray)
                        File.WriteAllText(filog, logParse.ToString())
                    Else
                        Dim japkx As JArray = logParse.SelectToken(noserial)
                        japkx.Add(newData)

                        File.WriteAllText(filog, logParse.ToString())
                    End If

                    If Not engine.DeviceQueues.ContainsKey(noserial) Then
                        engine.DeviceQueues(noserial) = New Concurrent.ConcurrentQueue(Of JObject)
                    End If

                    engine.DeviceQueues(noserial).Enqueue(newData)

                Next

            Next

            Dim nameFile As String = noserial
            ai = ai + 1
            Dim c = ai - 1

            If (datc > 0) Then
                Dim ab = datc + c
                pin = 35 * ab
            Else
                pin = 35 * c
            End If


            Dim DtObj As New JObject
            DtObj.Add("fitur", "cloAndro")
            DtObj.Add("namedial", noserial)
            DtObj.Add("pathFile", filog.ToString)
            DtObj.Add("pathexe", "")
            DtObj.Add("komu", komu)

            Dim Uiuse As New UCDeviceUse
            Uiuse.lbname.Text = "Queued"
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
            PnlogActivty.Controls.Add(Uiuse)

            ' 🔴 REGISTER UI DEVICE
            DeviceUIMap(noserial) = Uiuse
            engine.DeviceTotal(noserial) = engine.DeviceQueues(noserial).Count
            DeviceTotal(noserial) = devc
            DeviceProgress(noserial) = 0

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
           End If

       End Sub

        ' 🔥 START ENGINE
        Await engine.StartAsync()




    End Sub

    Private Sub ShowSipCall_log()
        DatTable1.Rows.Clear()

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim param As New JObject

        param.Add("username", username)
        param.Add("tipe_akun", "")
        param.Add("data", "log")

        Dim response = Ap_mrjay59.callsip(param)

        Dim resp2arr = jsonpa.Json2aray(response)
        If (resp2arr("status")("code") = 0) Then
            Dim ax = 0
            For Each item In resp2arr("body")
                ax = ax + 1
                Dim reqid = item("reqid").ToString
                Dim method = item("tipe").ToString
                Dim create = item("create").ToString
                Dim totnum As Integer = item("count")("total_number")
                Dim totdev As Integer = item("count")("total_device")


                Dim row As String() = New String() {ax, reqid, method, create, totnum, totdev}
                DatTable1.Rows.Add(row)

            Next

        End If
    End Sub

    Private Sub SendBatchToWSS(batch As JArray, ByVal reqid As String)

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()

        Dim payload As New JObject From {
            {"request_id", reqid},
            {"to", username},
            {"data", batch},
            {"message", "call sip via autocall"}
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
    $"{maskedNumber} Method:{komu} Ke {putaran} TotData:{posisi}/{total}"

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

        While batchTimerRunning

            Await Task.Delay(BatchDelayMs)

            SyncLock WSSLock
                If WSSBuffer.Count > 0 Then
                    FlushWSS(reqid)
                End If
            End SyncLock

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

    Private Sub DataMasuk(sender As Object, e As ClassData)
        Dim RData As String = e.Data
        Dim DatObj = e.Data
        Dim TotD = TotDial.Value
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim akustat = ParData("body")("apk_stat").ToString
        Dim pgCount As Integer = ParData("body")("apk_data")(0)("fitur")("siplocal")
        Dim DatParse = jsonpa.Json2aray(DatObj)
        Dim fun = DatParse("fun").ToString


        If (fun = "Vi_Siploc") Then
            Dim NamExe = DatParse("appname")
            Dim PathEx = DatParse("PathEx")
            Dim chk As Boolean = DatParse("chk")
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

                TxtCaller.Text &= NamExe & vbNewLine


                numData.Add("app", NamExe)
                numData.Add("patexe", PathEx)
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

            TotDial.Value = jobject.Count
        ElseIf (fun = "Vi_Sipser") Then
            Dim Naplatform = DatParse("Naplatform")
            Dim noserial = DatParse("noserial")
            ' Dim connection = DatParse("connection")
            Dim chk As Boolean = DatParse("chk")


            Dim DevNo = Naplatform & "-" & noserial
            Dim newDataArray As New JArray()

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtCaller.Text &= DevNo & vbNewLine

                numData.Add("app", Naplatform)
                ' numData.Add("connection", connection)
                numData.Add("noserial", noserial)

                ' ---- cek apakah key sudah ada ----
                If Not jobject.ContainsKey(noserial) Then
                    ' buat array baru
                    Dim newArr As New JArray()
                    newArr.Add(numData)
                    jobject.Add(noserial, newArr)

                Else
                    ' sudah ada → ambil array lalu append
                    Dim arr As JArray = jobject.SelectToken(noserial)
                    arr.Add(numData)
                End If

                DataJson = jobject.ToString()
            ElseIf (chk = False) Then
                TxtCaller.Text = Regex.Replace(TxtCaller.Text.Replace(DevNo, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                If jobject.ContainsKey(noserial) Then
                    Dim arr As JArray = jobject.SelectToken(noserial)

                    ' Cari item dengan app = whatsappmessage
                    Dim target As JObject = arr.
        FirstOrDefault(Function(x) x("app") IsNot Nothing AndAlso
                                 x("app").ToString() = Naplatform)

                    ' Jika ditemukan → hapus
                    If target IsNot Nothing Then
                        arr.Remove(target)
                    End If
                End If

                DataJson = jobject.ToString
            End If

            Dim appArray As New JArray(jobject.Properties().First().Value.Select(Function(x) x("app").ToString()))
            TotDial.Value = appArray.Count

        ElseIf (fun = "Vi_WADES") Then
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

            TotDial.Value = jobject.Count
        ElseIf (fun = "Vi_LocAn") Then
            Dim NaDev = DatParse("NaDev")
            Dim Naplatform = DatParse("Naplatform")
            Dim noserial = DatParse("noserial")
            Dim connection = DatParse("connection")
            Dim chk As Boolean = DatParse("chk")
            Dim NoHp = DatParse("NoHp").ToString.Split(" ")
            Dim prefix = DatParse("prefix").ToString

            Dim DevNo = noserial.ToString.Substring(8) & "-" & Naplatform & "-" & NoHp(0).ToString
            Dim newDataArray As New JArray()

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtCaller.Text &= DevNo & vbNewLine

                numData.Add("app", Naplatform)
                numData.Add("connection", connection)
                numData.Add("noserial", noserial)
                numData.Add("prefix", prefix)
                numData.Add("NoHp", NoHp(0))


                ' ---- cek apakah key sudah ada ----
                If Not jobject.ContainsKey(noserial) Then
                    ' buat array baru
                    Dim newArr As New JArray()
                    newArr.Add(numData)
                    jobject.Add(noserial, newArr)

                Else
                    ' sudah ada → ambil array lalu append
                    Dim arr As JArray = jobject.SelectToken(noserial)
                    arr.Add(numData)
                End If

                DataJson = jobject.ToString()
            ElseIf (chk = False) Then
                TxtCaller.Text = Regex.Replace(TxtCaller.Text.Replace(DevNo, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                If jobject.ContainsKey(noserial) Then
                    Dim arr As JArray = jobject.SelectToken(noserial)

                    ' Cari item dengan app = whatsappmessage
                    Dim target As JObject = arr.
        FirstOrDefault(Function(x) x("app") IsNot Nothing AndAlso
                                 x("app").ToString() = Naplatform)

                    ' Jika ditemukan → hapus
                    If target IsNot Nothing Then
                        arr.Remove(target)
                    End If
                End If

                DataJson = jobject.ToString
            End If

            TotDial.Value = jobject.Count

        ElseIf (fun = "Vi_SerAn") Then

            Dim Naplatform = DatParse("Naplatform")
            Dim noserial = DatParse("noserial")
            Dim connection = DatParse("connection")
            Dim chk As Boolean = DatParse("chk")


            Dim DevNo = Naplatform & "-" & noserial
            Dim newDataArray As New JArray()

            ' Parse the JSON string into a JArray
            Dim numData, PaData, jobject As New JObject
            Dim fDa = DataJson
            If Not (fDa Is Nothing) Then
                jobject = JObject.Parse(fDa)

            End If


            If (chk = True) Then

                TxtCaller.Text &= DevNo & vbNewLine

                numData.Add("app", Naplatform)
                numData.Add("connection", connection)
                numData.Add("noserial", noserial)

                ' ---- cek apakah key sudah ada ----
                If Not jobject.ContainsKey(noserial) Then
                    ' buat array baru
                    Dim newArr As New JArray()
                    newArr.Add(numData)
                    jobject.Add(noserial, newArr)

                Else
                    ' sudah ada → ambil array lalu append
                    Dim arr As JArray = jobject.SelectToken(noserial)
                    arr.Add(numData)
                End If

                DataJson = jobject.ToString()
            ElseIf (chk = False) Then
                TxtCaller.Text = Regex.Replace(TxtCaller.Text.Replace(DevNo, String.Empty).Trim & vbNewLine, "^\s+", "", RegexOptions.Multiline)
                If jobject.ContainsKey(noserial) Then
                    Dim arr As JArray = jobject.SelectToken(noserial)

                    ' Cari item dengan app = whatsappmessage
                    Dim target As JObject = arr.
        FirstOrDefault(Function(x) x("app") IsNot Nothing AndAlso
                                 x("app").ToString() = Naplatform)

                    ' Jika ditemukan → hapus
                    If target IsNot Nothing Then
                        arr.Remove(target)
                    End If
                End If

                DataJson = jobject.ToString
            End If

            TotDial.Value = jobject.Count

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

        If (jmDial <= 0) Then
            MsgBox("Opp belum ada  dialler pilih dulu iya")
            TxtNumber.Text = ""
            Exit Sub
        End If

        Dim onefile As Integer = Math.Round(jmData / jmDial)
        Dim totdx = onefile * jmDial ' data 36 per dial 4*10=40
        Dim rhal = totdx - jmData
        Dim adx = onefile - rhal
        LblTotData.Text = "Total Data " & jmData

        If (onefile < 1) Then
            MsgBox("Minimal Pembagian 1 nomer per apk dial ")
            TxtNumber.Text = ""
            Exit Sub
        End If

        If (adx <= 0) Then
            MsgBox($"Total Data {jmData} Total Dialler {jmDial} tambahkan {onefile}")
            Exit Sub
        End If

        If (Rownum > 1) Then
            Rownum = Math.Round(Rownum / Rowdial)
            Dim dx As Integer = Math.Round(dudetik / Rownum)
            Dim Result As Integer = Math.Round(dx / timer)


            If (Result > 0) And (Result <= 30) Then
                TotRecall.Value = Result
            End If
        End If

        '


        Dim numbr As String = Join(arnum.ToArray, ", ")
        TxtNumber.Text = numbr.Replace(vbLf, "")

        Dim prefix = TxtNumber.Text.Replace(", ", ", +62")
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

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click
        Dim metCal As String = String.Empty
        Dim type As String = String.Empty
        Dim title As String = String.Empty
        If (Rc0.Checked) Then
            metCal = "Vi_Siploc"
            type = ""
            title = "Pilih SIP Local"
        ElseIf (Rc1.Checked) Then
            metCal = "Vi_Sipser"
            type = ""
            title = "Pilih SIP Server"
        ElseIf (RD_WD.Checked) Then
            metCal = "Vi_WADES"
            type = ""
            title = "Pilih WA Desktop"
        ElseIf (LcAndroid.Checked) Then
            metCal = "Vi_LocAn"
            type = "call"
            title = "Pilih Local Android"
        ElseIf (ClAndroid.Checked) Then
            metCal = "Vi_SerAn"
            type = "call"
            title = "Pilih Clould Android"
        Else
            MsgBox("pilih metode Call terlebih dahulu")
        End If


        TxtCaller.Text = ""
        TotDial.Value = 0
        DataJson = Nothing
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user").ToString()


        Dim NObj As New JObject
        NObj.Add("title", title)
        NObj.Add("func", metCal)
        NObj.Add("permission", type)
        NObj.Add("username", username)
        Dim page As New PgDialog(NObj.ToString)

        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()
        RemoveHandler page.DataSelected, AddressOf DataMasuk

    End Sub

    Private Sub BtnPaste_Paint(sender As Object, e As PaintEventArgs) Handles BtnPaste.Paint
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

    Private Sub btnCaller_Click(sender As Object, e As EventArgs) Handles btnCaller.Click

        BtnResumeCall.Text = "Stop All"
        BtnResumeCall.Image = My.Resources.icons8_stop_20
        BtnStateC.BackColor = Color.Orange

        If (Rc0.Checked) Then
            SipLocal()
        ElseIf (RD_WD.Checked) Then
            'WAServerCall()
        ElseIf (Rc1.Checked) Then
            sipse()
        ElseIf (LcAndroid.Checked) Then
            LocalAndro()
        ElseIf (ClAndroid.Checked) Then
            clouldAndro()
        Else
            MsgBox("pilih metode Call terlebih dahulu")
        End If

        ShowSipCall_log()
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

    Private Sub TotDurasi_ValueChanged(sender As Object, e As EventArgs) Handles TotDurasi.ValueChanged
        Dim Rowdial As Integer = TotDial.Value
        Dim dumenit As Integer = TotDurasi.Value
        Dim Rownum As Integer = TxtNumber.Text.Trim.Split(", ").Count
        Dim timer As Integer = TotClose.Value
        Dim second As Integer = 60
        Dim dudetik As Integer = dumenit * second

        If (Rownum > 1) Then
            Rownum = Math.Round(Rownum / Rowdial)
            Dim dx As Integer = Math.Round(dudetik / Rownum)
            Dim Result As Integer = Math.Round(dx / timer)


            If (Result > 0) And (Result <= 30) Then
                TotRecall.Value = Result
            End If
        End If
    End Sub

    Private Sub TotRecall_ValueChanged(sender As Object, e As EventArgs) Handles TotRecall.ValueChanged
        Dim Rowdial As Integer = TotDial.Value
        Dim Repeat As Integer = TotRecall.Value
        Dim Rownum As Integer = TxtNumber.Text.Trim.Split(", ").Count
        Dim timer As Integer = TotClose.Value
        Dim jmDial As Integer = TotDial.Value
        Dim jmdurasi = TotDurasi.Value

        Try
            ' Dim addt = Rownum * 3
            Rownum = Math.Round(Rownum / Rowdial)
            Dim ResMen = Repeat * Rownum * timer

            TotDurasi.Value = Math.Round(ResMen / 60)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TotClose_ValueChanged(sender As Object, e As EventArgs) Handles TotClose.ValueChanged
        Dim Rowdial As Integer = TotDial.Value
        Dim Repeat As Integer = TotRecall.Value
        Dim Rownum As Integer = TxtNumber.Text.Trim.Split(", ").Count
        Dim timer As Integer = TotClose.Value
        Dim jmDial As Integer = TotDial.Value
        Dim jmdurasi = TotDurasi.Value

        Dim second As Integer = 60
        Dim dudetik As Integer = jmdurasi * second

        Try
            If (Rownum >= 2) Then
                Rownum = Math.Round(Rownum / Rowdial)
                Dim ResMen = Repeat * Rownum * timer

                TotDurasi.Value = Math.Round(ResMen / 60)


                Dim dx As Integer = Math.Round(dudetik / Rownum)
                Dim Result As Integer = Math.Round(dx / timer)


                If (Result > 0) And (Result <= 30) Then
                    TotRecall.Value = Result
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RC_AWS_CheckedChanged(sender As Object, e As EventArgs)
        TotRecall.Maximum = 10
        Dim page As New pgVerifyNumber
        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()
    End Sub

    Private Sub RC_AW_CheckedChanged(sender As Object, e As EventArgs)
        TotRecall.Maximum = 10
        Dim page As New pgVerifyNumber
        AddHandler page.DataSelected, AddressOf DataMasuk
        page.ShowDialog()
    End Sub

    Private Sub PgCall_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ShowSipCall_log()
    End Sub

    Private Sub Rc0_CheckedChanged(sender As Object, e As EventArgs) Handles Rc0.CheckedChanged
        GroupBox1.Enabled = True
        TotRecall.Value = 1
        TotRecall.Maximum = 20
    End Sub

    Private Sub RD_WD_CheckedChanged(sender As Object, e As EventArgs) Handles RD_WD.CheckedChanged
        GroupBox1.Enabled = True
    End Sub

    Private Sub Rc1_CheckedChanged(sender As Object, e As EventArgs) Handles Rc1.CheckedChanged
        GroupBox1.Enabled = True
    End Sub

    Private Sub DatTable1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable1.CellContentClick
        Dim indcol = e.ColumnIndex
        Dim indrow = e.RowIndex
        If (indcol = 6) Then
            Dim reqid = DatTable1.Rows.Item(indrow).Cells(1).Value.ToString

            Dim DPar = jsonpa.Json2aray(DatR)
            Dim username = DPar("body")("apk_user").ToString()

            Dim NObj As New JObject
            NObj.Add("title", "Cek LogCall Reqid " & reqid)
            NObj.Add("func", "log_sip")
            NObj.Add("reqid", reqid)
            NObj.Add("username", username)
            Dim page As New PgDialog(NObj.ToString)
            page.ShowDialog()
        End If



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

