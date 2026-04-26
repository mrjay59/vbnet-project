Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Xml
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Security.Cryptography
Imports Newtonsoft.Json.Linq
Imports System.Xml.Linq



Public Class ClassApk
    Inherits adb

    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private idevice As String = String.Empty

    Public Sub New(Device As String, Connect As String)
        Me.Connect(Device, Connect)
        idevice = Device

    End Sub

    Public Sub OpenWA(ByVal wa As String, ByVal userclone As String, ByVal phoneNumber As String, ByVal fungsi As String, ByVal txtpes As String)
        Dim pkg As String = String.Empty
        If (wa = "WhatsAppMessage") Then
            pkg = "com.whatsapp"
        ElseIf (wa = "WhatsAppBusiness") Then
            pkg = "com.whatsapp.w4b"
        End If
        ' --user 10
        Me.StartAdbCommand($"am start {userclone} -a android.intent.action.VIEW -d ""https://wa.me/{phoneNumber}"" {pkg}")
        Thread.Sleep(1500)


        If (fungsi = "message") Then
            ' 5️⃣ Tekan tombol kirim
            Thread.Sleep(1000)
            KlikTouch("entry", pkg)

            ' 4️⃣ Ketik seperti manusia
            Thread.Sleep(1000)
            TypeTextLikeHuman(txtpes)

            ' 5️⃣ Tekan tombol kirim
            Thread.Sleep(1000)
            SendMessage()



        ElseIf (fungsi = "call") Then
            Dim elCall = Me.FindElement($"//node[@resource-id='{pkg}:id/conversation_contact_name']")
            If Not (elCall Is Nothing) Then
                TapButton("e2ee_description_close_button")
                Thread.Sleep(1500)
                VoiceCall()

            End If
        End If
    End Sub

    Public Sub CropQRCode(sourcePath As String, outputPath As String)
        Try
            Using original As New Bitmap(sourcePath)
                ' ⚙️ Rasio area QR di layar WhatsApp biasanya di sekitar tengah layar
                ' kita potong kira-kira 55% dari lebar dan tinggi layar dari tengah
                Dim cropWidth As Integer = CInt(original.Width * 0.75)
                Dim cropHeight As Integer = CInt(original.Height * 0.35)
                Dim cropX As Integer = CInt((original.Width - cropWidth) / 2)
                Dim cropY As Integer = CInt(original.Height * 0.35)

                ' Pastikan area crop tidak keluar dari gambar
                cropX = Math.Max(0, cropX)
                cropY = Math.Max(0, cropY)
                If cropX + cropWidth > original.Width Then cropWidth = original.Width - cropX
                If cropY + cropHeight > original.Height Then cropHeight = original.Height - cropY

                Dim rect As New Rectangle(cropX, cropY, cropWidth, cropHeight)
                Using cropped As Bitmap = original.Clone(rect, original.PixelFormat)
                    cropped.Save(outputPath, Imaging.ImageFormat.Png)
                End Using
            End Using

            Console.WriteLine("✅ QR code berhasil di-crop dan disimpan ke: " & outputPath)

        Catch ex As Exception
            Console.WriteLine("❌ CropQRCode error: " & ex.Message)
        End Try
    End Sub

    Public Function Login_QRCode(ByVal wa As String, Optional logAction As Action(Of String) = Nothing) As String
        Try
            Dim pkg As String = If(wa = "WhatsAppBusiness", "com.whatsapp.w4b", "com.whatsapp")

            Dim apkname = dbConn.ApkProfile("name")
            Dim fodev = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), apkname)
            Dim folderQ = Path.Combine(fodev, "screencap")
            Directory.CreateDirectory(folderQ)

            Dim devId As String = idevice.Replace(":", "")
            Dim qrPath As String = Path.Combine(folderQ, $"{devId}_qr.png")
            Dim lastHash As String = ""

            LogUpdate(logAction, "🔍 Menunggu halaman QR WhatsApp...")

            ' pastikan file QR lama dihapus
            If File.Exists(qrPath) Then IO.File.Delete(qrPath)

            ' buka menu titik tiga jika masih di halaman awal
            Dim elreg = Me.FindElement($"//node[@resource-id='{pkg}:id/register_phone_layout']")
            If elreg IsNot Nothing Then
                Thread.Sleep(500)
                TapButton("menuitem_overflow")
                Thread.Sleep(500)
                TapButton("title") ' tautkan perangkat
            End If

            ' loop deteksi QR
            Dim startTime As DateTime = DateTime.Now
            Do
                ' dump UI
                Dim xml As String = Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
                Thread.Sleep(400)
                xml = Me.StartAdbCommand("cat /sdcard/window_dump.xml")

                ' cek apakah sudah login
                If Not xml.Contains($"{pkg}:id/toolbar_title_text_v2") Then
                    LogUpdate(logAction, "✅ WhatsApp sudah login atau QR sudah discan.")
                    Return "logged_in"
                End If


                If xml.Contains($"{pkg}:id/reload_qr_button") Then
                    LogUpdate(logAction, "✅ Perbaharui qrcode")
                    Thread.Sleep(500)
                    TapButton("reload_qr_button") ' tautkan perangkat
                End If

                ' cek profile
                If Not xml.Contains($"{pkg}:id/toolbar_title_text_v2") Then
                    LogUpdate(logAction, "✅ WhatsApp sudah login atau QR sudah discan.")
                    Return "logged_in"
                End If

                ' ambil screenshot
                Dim shotPath As String = GetScreenShot()
                If Not File.Exists(shotPath) Then
                    Thread.Sleep(1000)
                    Continue Do
                End If

                ' hitung hash untuk deteksi QR berubah
                Dim newHash As String = GetFileHash(shotPath)
                If newHash <> lastHash Then
                    lastHash = newHash
                    CropQRCode(shotPath, qrPath)
                    LogUpdate(logAction, $"📸 lakukan scan barkode ...")
                End If

                ' timeout 2 menit
                If (DateTime.Now - startTime).TotalSeconds > 120 Then
                    LogUpdate(logAction, "⚠️ Timeout menunggu pemindaian QR.")
                    Return "timeout"
                End If

                Thread.Sleep(5000)
            Loop

            Return "done"

        Catch ex As Exception
            LogUpdate(logAction, "❌ Login_QRCode error:  " & ex.Message)
            Return "error"
        End Try
    End Function

    Public Function Login_byNumber(ByVal wa As String, Optional logAction As Action(Of String) = Nothing) As String
        Try
            Dim pkg As String = If(wa = "WhatsAppBusiness", "com.whatsapp.w4b", "com.whatsapp")

            ' ===== 1️⃣ Baca halaman input negara & nomor =====
            logAction?.Invoke("📱 Membaca halaman input nomor WhatsApp...")

            Dim xml As String = Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
            Thread.Sleep(300)
            xml = Me.StartAdbCommand("cat /sdcard/window_dump.xml")

            ' Cari field negara dan nomor
            Dim elCountry = Me.FindElement($"//node[@resource-id='{pkg}:id/registration_country']") ' contoh id
            Dim elPhone = Me.FindElement($"//node[@resource-id='{pkg}:id/registration_phone']")

            If elCountry IsNot Nothing AndAlso elPhone IsNot Nothing Then
                logAction?.Invoke("✍️ Mengisi negara & nomor telepon...")
                Me.StartAdbCommand("input text '+62'")
                Thread.Sleep(500)
                Me.StartAdbCommand("input keyevent 61") ' tab ke field berikut
                Me.StartAdbCommand("input text '88290714697'") ' contoh nomor
                Thread.Sleep(1000)

                ' klik lanjut
                Dim elNext = Me.FindElement($"//node[@resource-id='{pkg}:id/registration_submit']") ' tombol lanjut
                If elNext IsNot Nothing Then
                    TapButton("registration_submit")
                    logAction?.Invoke("➡️ Klik tombol Lanjut")
                End If
            End If

            ' ===== 2️⃣ Tunggu pop konfirmasi (loginui1.xml) =====
            Thread.Sleep(2000)
            xml = Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
            Thread.Sleep(300)
            xml = Me.StartAdbCommand("cat /sdcard/window_dump.xml")

            If xml.Contains("Apakah ini nomor yang benar?") Then
                logAction?.Invoke("📋 Konfirmasi nomor ditemukan, klik YA")
                TapByText("Ya")
                Thread.Sleep(2000)
            End If

            ' ===== 3️⃣ Tunggu halaman verifikasi OTP (loginui2.xml) =====
            Dim startWait As DateTime = DateTime.Now
            Do
                xml = Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
                Thread.Sleep(300)
                xml = Me.StartAdbCommand("cat /sdcard/window_dump.xml")

                If xml.Contains("Kode verifikasi") Then
                    logAction?.Invoke("📩 Halaman verifikasi OTP terdeteksi.")
                    Exit Do
                End If

                If (DateTime.Now - startWait).TotalSeconds > 30 Then
                    logAction?.Invoke("⚠️ Timeout menunggu halaman OTP.")
                    Return "timeout"
                End If
                Thread.Sleep(1000)
            Loop

            ' ===== 4️⃣ Input OTP atau klik "Tidak menerima kode" =====
            Dim otpInput = Me.FindElement($"//node[@resource-id='{pkg}:id/verify_sms_code_input']")
            If otpInput IsNot Nothing Then
                logAction?.Invoke("⌨️ Masukkan kode OTP (contoh: 123456)")
                Me.StartAdbCommand("input text '123456'")
                Thread.Sleep(1000)
            Else
                logAction?.Invoke("📞 Tidak menerima kode, klik tombol fallback.")
                Dim elFallback = Me.FindElement($"//node[@resource-id='{pkg}:id/fallback_methods_entry_button']")
                If elFallback IsNot Nothing Then
                    TapButton("fallback_methods_entry_button")
                    Thread.Sleep(2000)
                End If
            End If

            logAction?.Invoke("✅ Login dengan nomor selesai.")
            Return "success"

        Catch ex As Exception
            logAction?.Invoke("❌ Error Login_byNumber: " & ex.Message)
            Return "error"
        End Try
    End Function

    ' Tap berdasarkan teks node (umum)
    Private Function TapByText(ByVal targetText As String) As Boolean
        Dim xml As String = Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
        Thread.Sleep(300)
        xml = Me.StartAdbCommand("cat /sdcard/window_dump.xml")

        Dim m As Match = Regex.Match(xml, $"text=\""{Regex.Escape(targetText)}\""[\s\S]+?bounds=\""\[(\d+),(\d+)\]\[(\d+),(\d+)\]\""")
        If m.Success Then
            Dim x1 = CInt(m.Groups(1).Value)
            Dim y1 = CInt(m.Groups(2).Value)
            Dim x2 = CInt(m.Groups(3).Value)
            Dim y2 = CInt(m.Groups(4).Value)
            Dim cx = (x1 + x2) \ 2
            Dim cy = (y1 + y2) \ 2
            Me.StartAdbCommand($"input tap {cx} {cy}")
            Return True
        End If
        Return False
    End Function

    Public Function ckprofile(ByVal wa As String, Optional logAction As Action(Of String) = Nothing) As String
        Try
            Dim pkg As String = If(wa = "WhatsAppBusiness", "com.whatsapp.w4b", "com.whatsapp")

            ' buka menu titik tiga jika masih di halaman awal
            Dim elreg = Me.FindElement($"//node[@resource-id='{pkg}:id/toolbar_logo']")
            If elreg IsNot Nothing Then
                Thread.Sleep(500)
                TapButton("menuitem_overflow")
                LogUpdate(logAction, "klik Menu titik 3 ")
                Thread.Sleep(500)

                LogUpdate(logAction, "klik Pengaturan ")
                TapMenuByText("Pengaturan", wa)

                LogUpdate(logAction, "Cari halaman profile")
                Dim elprofile = Me.FindElement($"//node[@resource-id='{pkg}:id/profile_info_name']")
                If elprofile IsNot Nothing Then
                    elprofile.Click()
                End If



            End If

            Return ""
        Catch ex As Exception
            LogUpdate(logAction, "❌ Login_QRCode error:  " & ex.Message)
            Return "error"
        End Try
    End Function

    Public Function ParseWhatsAppProfileXml(xmlPath As String, ByVal wa As String) As JObject

        Dim pkg As String = If(wa = "WhatsAppBusiness", "com.whatsapp.w4b", "com.whatsapp")
        Dim doc As New XmlDocument()
        doc.Load(xmlPath)

        Dim json As New JObject()
        Dim profile As New JObject()
        Dim info As New JObject()

        ' Nama
        Dim nameNode = doc.SelectSingleNode($"//node[@resource-id='{pkg}:id/profile_settings_row_text' and @text='Nama']")
        If nameNode IsNot Nothing Then
            Dim nameValue = nameNode.ParentNode.SelectSingleNode($"node[@resource-id='{pkg}:id/profile_settings_row_subtext']")
            info("name") = New JObject(
            New JProperty("label", nameNode.Attributes("text").Value),
            New JProperty("value", nameValue?.Attributes("text")?.Value)
        )
        End If

        ' Tentang
        Dim aboutNode = doc.SelectSingleNode($"//node[@resource-id='{pkg}:id/profile_settings_row_text' and @text='Tentang']")
        If aboutNode IsNot Nothing Then
            Dim aboutValue = aboutNode.ParentNode.SelectSingleNode($"node[@resource-id='{pkg}:id/profile_settings_row_subtext']")
            info("about") = New JObject(
            New JProperty("label", aboutNode.Attributes("text").Value),
            New JProperty("value", aboutValue?.Attributes("text")?.Value)
        )
        End If

        ' Telepon
        Dim phoneNode = doc.SelectSingleNode($"//node[@resource-id='{pkg}:id/profile_settings_row_text' and @text='Telepon']")
        If phoneNode IsNot Nothing Then
            Dim phoneValue = phoneNode.ParentNode.SelectSingleNode($"node[@resource-id='{pkg}:id/profile_settings_row_subtext']")
            info("phone") = New JObject(
            New JProperty("label", phoneNode.Attributes("text").Value),
            New JProperty("value", phoneValue?.Attributes("text")?.Value)
        )
        End If

        ' Tautan
        Dim linkNode = doc.SelectSingleNode($"//node[@resource-id='{pkg}:id/profile_settings_row_text' and @text='Tautan']")
        If linkNode IsNot Nothing Then
            Dim linkValue = linkNode.ParentNode.SelectSingleNode($"node[@resource-id='{pkg}:id/profile_settings_row_subtext']")
            info("link") = New JObject(
            New JProperty("label", linkNode.Attributes("text").Value),
            New JProperty("value", linkValue?.Attributes("text")?.Value)
        )
        End If

        profile("info") = info
        json("profile") = profile
        Return json
    End Function

    ' 🧩 Fungsi pembantu: update log ke UI safely (Invoke di thread UI)
    Private Sub LogUpdate(logAction As Action(Of String), message As String)
        If logAction IsNot Nothing Then
            logAction.Invoke(message)
        Else
            '  Console.WriteLine(message)
        End If
    End Sub

    ' 🧩 Fungsi pembantu: hash MD5 file
    Private Function GetFileHash(filePath As String) As String
        Using fs As FileStream = File.OpenRead(filePath)
            Dim md5 As New MD5CryptoServiceProvider()
            Dim hashBytes As Byte() = md5.ComputeHash(fs)
            Return BitConverter.ToString(hashBytes).Replace("-", "")
        End Using
    End Function

    Public Sub OpenMakeSMS(ByVal serial As String, ByVal phone_number As Integer, ByVal message_body As String)
        Me.StartAdbCommand($"am start -a android.intent.action.SENDTO -d sms: {phone_number} --es sms_body ""{message_body}"" --ez exit_on_sent true")
    End Sub

    Public Sub KlikTouch(ByVal IcalK As String, ByVal platform As String)

        Try
            Thread.Sleep(500)
            Dim el As ElementNode

            If (IcalK = "PV") Then
                el = Me.FindElement("//node[@content-desc='Panggilan video']")
                el?.Click()

            ElseIf (IcalK = "PS") Then
                Dim Els = Me.FindElements("//node[@class='android.widget.ImageButton']")
                For Each ItemElm In Els
                    Thread.Sleep(1500)
                    Dim StrEl = ItemElm.Raw.Attribute("content-desc")?.Value.ToLower()
                    If StrEl Is Nothing Then Continue For

                    If (StrEl.Contains("telepon suara")) Then
                        ItemElm.Click()
                    ElseIf (StrEl = "panggil") Then
                        ItemElm.ClickAsync()
                    End If
                Next

            ElseIf (IcalK = "PV1") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/video_call_item']")
                el?.ClickAsync()

            ElseIf (IcalK = "PS1") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/audio_call_item']")
                el?.ClickAsync()

            ElseIf (IcalK = "BAT") Then
                el = Me.FindElement("//node[@resource-id='android:id/button2']")
                el?.ClickAsync()

            ElseIf (IcalK = "PAG") Then
                el = Me.FindElement("//node[@resource-id='android:id/button1']")
                el?.ClickAsync()

            ElseIf (IcalK = "ENC") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/footer_end_call_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "MUT") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/mute_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "SWV") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/toggle_video_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "SPE") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/speaker_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "ENT") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/entry']")
                el?.ClickAsync()

            ElseIf (IcalK = "CCB") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/cancel_call_back_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "KIP") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/message_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "REC") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/call_back_btn']")
                el?.ClickAsync()

            ElseIf (IcalK = "AP1") Then
                el = Me.FindElement("//node[@resource-id='android.miui:id/app1']")
                el?.ClickAsync()

            ElseIf (IcalK = "AP2") Then
                el = Me.FindElement("//node[@resource-id='android.miui:id/app2']")
                el?.ClickAsync()

            ElseIf (IcalK = "entry") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/entry']")
                el?.ClickAsync()

            ElseIf (IcalK = "action_button") Then
                el = Me.FindElement($"//node[@resource-id='{platform}:id/conversation_entry_action_button']")
                el?.ClickAsync()

            ElseIf (IcalK = "HOP") Then
                If (platform = "com.whatsapp.w4b") Then
                    el = Me.FindElement($"//node[@resource-id='{platform}:id/fab']")
                Else
                    el = Me.FindElement($"//node[@resource-id='{platform}:id/fabText']")
                End If
                el?.Click()

            End If

        Catch ex As Exception
            Console.WriteLine("Bagian klik")
        End Try

    End Sub

    Public Function GetScreenShot()
        Dim apkname = dbConn.ApkProfile("name")
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\screencap\"
        If Not (IO.Directory.Exists(fodev)) Then
            IO.Directory.CreateDirectory(fodev)
        End If

        If Not (IO.Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If

        Dim image = Me.Screenshot()
        Dim bmg = New Bitmap(image)
        Dim NaPng = idevice.Replace(":", "")
        image.Save($"{FoldeQ}{NaPng}.png")
        Thread.Sleep(500)
        Dim pathss = $"{FoldeQ}{NaPng}.png"

        Return pathss
    End Function

    Public Sub OpenScrcpy(ByVal arg As String)

        Dim fodev = Application.StartupPath & "\"

        Dim direxe = fodev & "Scrcpy\Scrcpy.exe"
        ' Create a new process
        Dim process As New Process()

        ' Set the process start info
        Dim processStartInfo As New ProcessStartInfo()
        processStartInfo.FileName = direxe
        processStartInfo.Arguments = arg
        processStartInfo.RedirectStandardOutput = True
        processStartInfo.UseShellExecute = False
        processStartInfo.CreateNoWindow = True

        ' Assign the start info to the process
        process.StartInfo = processStartInfo

        ' Start the process
        process.Start()


    End Sub

    ''' <summary>
    ''' Mengambil status panggilan saat ini di WhatsApp (idle, in_call, Berdering, dsb.)
    ''' </summary>
    Public Function GetCallStatus() As String
        Try
            ' 1️⃣ Dump UI dari layar aktif
            Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
            Thread.Sleep(400)

            Dim xml As String = Me.StartAdbCommand("cat /sdcard/window_dump.xml")
            If Not xml.Contains("<?xml") Then Return "idle"

            ' 2️⃣ Parse XML UI
            Dim root As XElement = XElement.Parse(xml.Substring(xml.IndexOf("<?xml")))

            ' 3️⃣ Cek apakah UI sedang di aktivitas panggilan
            Dim isVoip As Boolean = False
            For Each node As XElement In root.Descendants("node")
                Dim resId = node.Attribute("resource-id")?.Value
                Dim desc = node.Attribute("content-desc")?.Value
                Dim txt = node.Attribute("text")?.Value

                ' Deteksi aktivitas panggilan
                If (resId IsNot Nothing AndAlso resId.ToLower().Contains("call")) OrElse
               (desc IsNot Nothing AndAlso desc.ToLower().Contains("call")) Then
                    isVoip = True
                    Exit For
                End If
            Next

            If Not isVoip Then
                Return "idle"
            End If

            ' 4️⃣ Cari teks status panggilan seperti “Berdering”, “Memanggil”, “Sedang menelepon”, “Ended”
            Dim statusCandidates As New List(Of String) From {
            "Berdering", "Memanggil", "Sedang", "Ended", "Panggilan", "Calling", "Ringing", "Connected"
        }

            For Each node As XElement In root.Descendants("node")
                Dim txt = node.Attribute("text")?.Value
                If Not String.IsNullOrEmpty(txt) Then
                    For Each s In statusCandidates
                        If txt.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0 Then
                            Return txt.Trim()
                        End If
                    Next
                End If
            Next

            ' 5️⃣ Jika tidak ketemu teks spesifik, kembalikan default
            Return "in_call"

        Catch ex As Exception
            Console.WriteLine("GetCallStatus error: " & ex.Message)
            Return "unknown"
        End Try
    End Function

    Public Function TapImageButtonByLabel(targetLabel As String) As Boolean
        Try
            ' 1️⃣ Dump UI hierarki layar aktif
            Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
            Thread.Sleep(400)

            Dim xml As String = Me.StartAdbCommand("cat /sdcard/window_dump.xml")
            If Not xml.Contains("<?xml") Then Return False

            Dim xmlStart As Integer = xml.IndexOf("<?xml")
            Dim root As XElement = XElement.Parse(xml.Substring(xmlStart))

            ' 2️⃣ Normalisasi label target
            Dim normalizedTarget = targetLabel.Trim().ToLowerInvariant()

            ' 3️⃣ Loop semua node yang class-nya ImageButton
            For Each node As XElement In root.Descendants("node")
                Dim cls = node.Attribute("class")?.Value
                If cls Is Nothing OrElse Not cls.Equals("android.widget.ImageButton", StringComparison.OrdinalIgnoreCase) Then
                    Continue For
                End If

                Dim desc = node.Attribute("content-desc")?.Value?.Trim()
                Dim resId = node.Attribute("resource-id")?.Value?.Trim()
                Dim txt = node.Attribute("text")?.Value?.Trim()

                ' 4️⃣ Bandingkan target dengan konten yang relevan
                Dim match As Boolean =
                (Not String.IsNullOrEmpty(desc) AndAlso desc.ToLowerInvariant().Contains(normalizedTarget)) OrElse
                (Not String.IsNullOrEmpty(resId) AndAlso resId.ToLowerInvariant().Contains(normalizedTarget)) OrElse
                (Not String.IsNullOrEmpty(txt) AndAlso txt.ToLowerInvariant().Contains(normalizedTarget))

                If match Then
                    ' 5️⃣ Ambil koordinat dan lakukan tap
                    Dim bounds = node.Attribute("bounds")?.Value
                    If Not String.IsNullOrEmpty(bounds) Then
                        Dim nums = Regex.Matches(bounds, "\d+")
                        If nums.Count = 4 Then
                            Dim x1 = Integer.Parse(nums(0).Value)
                            Dim y1 = Integer.Parse(nums(1).Value)
                            Dim x2 = Integer.Parse(nums(2).Value)
                            Dim y2 = Integer.Parse(nums(3).Value)

                            Dim cx = (x1 + x2) \ 2
                            Dim cy = (y1 + y2) \ 2

                            ' Lakukan tap ke posisi tombol
                            Me.StartAdbCommand($"input tap {cx} {cy}")
                            Thread.Sleep(500)
                            Return True
                        End If
                    End If
                End If
            Next

        Catch ex As Exception
            Console.WriteLine("TapImageButtonByLabel error: " & ex.Message)
        End Try

        Return False
    End Function

    Public Function TapMenuByText(targetText As String, wa As String) As Boolean
        Try

            Dim pkg As String = If(wa = "WhatsAppBusiness", "com.whatsapp.w4b", "com.whatsapp")

            ' Dump UI XML dari perangkat
            Dim xmlPath As String = "/sdcard/window_dump.xml"
            Me.StartAdbCommand($"uiautomator dump {xmlPath}")
            Dim xmlContent As String = Me.StartAdbCommand($"cat {xmlPath}")

            ' Parse XML untuk cari node sesuai text dan resource-id
            Dim regex As New Regex($"<node[^>]*text=""{Regex.Escape(targetText)}""[^>]*resource-id=""{Regex.Escape(pkg)}:id/title""[^>]*bounds=""\[(\d+),(\d+)\]\[(\d+),(\d+)\]""")
            Dim m As Match = regex.Match(xmlContent)
            If m.Success Then
                Dim x1 As Integer = Integer.Parse(m.Groups(1).Value)
                Dim y1 As Integer = Integer.Parse(m.Groups(2).Value)
                Dim x2 As Integer = Integer.Parse(m.Groups(3).Value)
                Dim y2 As Integer = Integer.Parse(m.Groups(4).Value)

                ' Hitung titik tengah untuk ketuk
                Dim cx As Integer = (x1 + x2) \ 2
                Dim cy As Integer = (y1 + y2) \ 2

                ' Ketuk posisi tersebut
                Me.StartAdbCommand($"input tap {cx} {cy}")
                Thread.Sleep(500)
                Return True
            Else
                Console.WriteLine($"⚠️ Tidak menemukan menu dengan teks '{targetText}'.")
            End If
        Catch ex As Exception
            Console.WriteLine($"❌ TapMenuByText error: {ex.Message}")
        End Try
        Return False
    End Function
    ''' <summary>
    ''' Tekan tombol di layar berdasarkan id (misal "end_call_button").
    ''' </summary>

    Public Function TapButton(buttonId As String) As Boolean
        Try
            ' Dump UI hierarchy real dari layar
            Me.StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
            Thread.Sleep(500)
            Dim xml As String = Me.StartAdbCommand("cat /sdcard/window_dump.xml")

            If Not xml.Contains("<?xml") Then Return False

            Dim root As XElement = XElement.Parse(xml.Substring(xml.IndexOf("<?xml")))
            For Each node As XElement In root.Descendants("node")
                Dim resId = node.Attribute("resource-id")?.Value
                If resId IsNot Nothing AndAlso resId.Contains(buttonId) Then
                    Dim bounds As String = node.Attribute("bounds")?.Value
                    If Not String.IsNullOrEmpty(bounds) Then
                        Dim m As MatchCollection = Regex.Matches(bounds, "\d+")
                        If m.Count = 4 Then
                            Dim x1 As Integer = Integer.Parse(m(0).Value)
                            Dim y1 As Integer = Integer.Parse(m(1).Value)
                            Dim x2 As Integer = Integer.Parse(m(2).Value)
                            Dim y2 As Integer = Integer.Parse(m(3).Value)
                            Dim cx As Integer = (x1 + x2) \ 2
                            Dim cy As Integer = (y1 + y2) \ 2
                            Me.StartAdbCommand($"input tap {cx} {cy}")
                            Thread.Sleep(700)
                            Return True
                        End If
                    End If
                End If
            Next
        Catch ex As Exception
            Console.WriteLine("_tap_button error: " & ex.Message)
        End Try
        Return False
    End Function

    ' ===== Wrapper Functions =====

    ''' <summary>
    ''' Akhiri panggilan (setara tombol "End Call").
    ''' </summary>
    Public Function EndCall() As Boolean
        Return TapButton("end_call_button")
    End Function

    ''' <summary>
    ''' Toggle mute microphone.
    ''' </summary>
    Public Function ToggleMute() As Boolean
        Return TapButton("mute_button")
    End Function

    ''' <summary>
    ''' Toggle speaker on/off.
    ''' </summary>
    Public Function ToggleSpeaker() As Boolean
        Return TapButton("audio_route_button")
    End Function

    ''' <summary>
    ''' Toggle kamera on/off saat video call.
    ''' </summary>
    Public Function ToggleCamera() As Boolean
        Return TapButton("camera_button")
    End Function

    Public Function VoiceCall() As Boolean
        Return TapImageButtonByLabel("Telepon suara")
    End Function

    Public Function SendMessage() As Boolean
        Return TapImageButtonByLabel("Kirim")
    End Function

    Private Sub TypeTextLikeHuman(txtpes As String)
        Try
            Thread.Sleep(800) ' sedikit delay sebelum mengetik

            For Each ch As Char In txtpes
                Select Case ch
                    Case " "c
                        ' Spasi
                        Me.StartAdbCommand("input keyevent 62") ' 62 = KEYCODE_SPACE

                    Case vbCr, vbLf
                        ' Enter / baris baru
                        Me.StartAdbCommand("input keyevent 66") ' 66 = KEYCODE_ENTER

                    Case Else
                        ' Karakter normal
                        Dim key As String = EscapeAdbText(ch)
                        Me.StartAdbCommand($"input text {key}")
                End Select

                ' Delay antar karakter
                Thread.Sleep(RandomDelay(80, 160))
            Next
        Catch ex As Exception
            Console.WriteLine("TypeTextLikeHuman error: " & ex.Message)
        End Try
    End Sub

    Private Function EscapeAdbText(ch As Char) As String
        Select Case ch
            Case "'"
                Return "\""'"
            Case "&", "|", ">", "<", "(", ")", ";", "!", "#", "$", "`", "\", """"
                Return "\" & ch
            Case Else
                Return ch
        End Select
    End Function

    Private Function RandomDelay(minMs As Integer, maxMs As Integer) As Integer
        Static rnd As New Random()
        Return rnd.Next(minMs, maxMs)
    End Function

    Public Function CleanPhoneNumber(number As String) As String
        If String.IsNullOrWhiteSpace(number) Then Return ""

        ' Hanya izinkan angka dan +
        Dim cleaned As String = Regex.Replace(number.ToString(), "[^\d+]", "")

        ' Format Indonesia
        If cleaned.StartsWith("0") AndAlso Not cleaned.StartsWith("+") Then
            cleaned = "+62" & cleaned.Substring(1)
        ElseIf Not cleaned.StartsWith("+") Then
            cleaned = "+62" & cleaned
        End If

        Return cleaned
    End Function

    Public Function MakeCellularCall(number As String, Optional sim As Integer = 0) As Boolean
        Try
            Dim phone As String = CleanPhoneNumber(number)
            Dim simIndex As Integer = sim

            Dim intents As String() = {
            $"am start -a android.intent.action.CALL -d tel:{phone} --ei android.telecom.extra.SIM_SLOT_INDEX {simIndex}",
            $"am start -a android.intent.action.CALL -d tel:{phone} --ei subscription {simIndex}",
            $"am start -a android.intent.action.CALL -d tel:{phone} --ei com.android.phone.extra.slot {simIndex}",
            $"am start -a android.intent.action.CALL -d tel:{phone} --ei slot {simIndex}"
        }

            For Each cmd In intents
                Try
                    StartAdbCommand(cmd)
                    Thread.Sleep(2000)

                    ' Tangani popup pilih SIM
                    HandleSimChooser(simIndex)

                    Return True
                Catch
                    Continue For
                End Try
            Next

            ' Fallback tanpa SIM slot
            Try
                StartAdbCommand($"am start -a android.intent.action.CALL -d tel:{phone}")
                Thread.Sleep(2000)
                HandleSimChooser(simIndex)
                Return True
            Catch
            End Try

            Return False

        Catch ex As Exception
            Console.WriteLine("Cellular call error: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function MakeCellularCallViaUSSD(number As String, Optional sim As Integer = 0) As Boolean
        Try
            Dim phone As String = CleanPhoneNumber(number)
            Dim simIndex As Integer = sim

            Dim encodedNumber As String = Uri.EscapeDataString(phone)

            Dim intents As String() = {
            $"am start -a android.intent.action.CALL -d tel:{encodedNumber} --ei android.telecom.extra.SIM_SLOT_INDEX {simIndex}",
            $"am start -a android.intent.action.CALL -d tel:{encodedNumber} --ei subscription {simIndex}"
        }

            For Each cmd In intents
                Try
                    StartAdbCommand(cmd)
                    Thread.Sleep(3000)

                    HandleSimChooser(simIndex)
                    Return True
                Catch
                    Continue For
                End Try
            Next

            Return False

        Catch ex As Exception
            Console.WriteLine("USSD call error: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function HandleSimChooser(simIndex As Integer) As Boolean
        Try
            Thread.Sleep(1200)

            StartAdbCommand("uiautomator dump /sdcard/window_dump.xml")
            Thread.Sleep(300)

            Dim xml As String = StartAdbCommand("cat /sdcard/window_dump.xml")

            If Not xml.Contains("<?xml") Then Return False

            xml = xml.Substring(xml.IndexOf("<?xml"))
            Dim doc As XDocument = XDocument.Parse(xml)

            ' 1️⃣ Pastikan ini dialog SIM
            Dim isSimDialog As Boolean =
            doc.Descendants("node").Any(Function(n)
                                            Dim rid = CStr(n.Attribute("resource-id"))
                                            Dim txt = CStr(n.Attribute("text"))
                                            Return rid = "com.android.dialer:id/alertTitle" AndAlso
                                                   txt IsNot Nothing AndAlso txt.ToLower().Contains("sim")
                                        End Function)

            If Not isSimDialog Then Return False

            ' 2️⃣ Ambil semua row SIM
            Dim simRows = doc.Descendants("node").
                Where(Function(n)
                          Dim cls = n.Attribute("class")
                          Dim pkg = n.Attribute("package")
                          Dim bnd = n.Attribute("bounds")

                          Return cls IsNot Nothing AndAlso
                                 pkg IsNot Nothing AndAlso
                                 bnd IsNot Nothing AndAlso
                                 cls.Value = "android.widget.LinearLayout" AndAlso
                                 pkg.Value = "com.android.dialer"
                      End Function).
                Select(Function(n) n.Attribute("bounds").Value).
                ToList()


            If simRows.Count <= simIndex Then Return False

            ' 3️⃣ Tap SIM sesuai index
            Dim bounds As String = simRows(simIndex)
            Dim nums = Regex.Matches(bounds, "\d+").
                    Cast(Of Match)().
                    Select(Function(m) Integer.Parse(m.Value)).
                    ToArray()

            If nums.Length <> 4 Then Return False

            Dim cx As Integer = (nums(0) + nums(2)) \ 2
            Dim cy As Integer = (nums(1) + nums(3)) \ 2

            StartAdbCommand($"input tap {cx} {cy}")
            Return True

        Catch ex As Exception
            Console.WriteLine("handle_sim_chooser error: " & ex.Message)
            Return False
        End Try
    End Function


End Class
