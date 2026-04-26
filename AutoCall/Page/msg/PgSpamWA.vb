Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports AutoCall
Imports Newtonsoft.Json.Linq

Public Class PgSpamWA
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

    Private Sub BtnCreaForm_Click(sender As Object, e As EventArgs) Handles BtnCreaForm.Click
        ' Jumlah pasangan Label + TextBox yang ingin dibuat
        Dim jumlahInput As Integer = JCount.Value
        BtnCreaForm.Enabled = False
        JCount.Enabled = False
        ' Posisi awal vertikal
        Dim posisiY As Integer = 10
        Panel1.Controls.Clear()

        For i As Integer = 1 To jumlahInput
            ' Buat Label
            Dim lbl As New Label()
            lbl.Name = "Label" & i
            lbl.Text = "Nomor Ke " & i
            lbl.Location = New Point(10, posisiY)
            lbl.AutoSize = True
            lbl.ForeColor = Color.White
            lbl.Font = New Font("Segoe UI", 10)

            ' Buat TextBox
            Dim tb As New TextBox()
            tb.Name = "TextBox" & i
            tb.Width = 200
            tb.BackColor = Color.FromArgb(60, 80, 60)
            tb.Font = New Font("Segoe UI", 12)
            tb.Location = New Point(100, posisiY - 3) ' sejajar dengan label
            tb.ForeColor = Color.White


            ' Validasi: hanya angka saat diketik
            AddHandler tb.KeyPress, AddressOf HanyaAngka_KeyPress

            ' Validasi panjang digit: 9-14
            AddHandler tb.TextChanged, AddressOf ValidasiPanjangDigit


            ' Tambahkan ke panel
            Panel1.Controls.Add(lbl)
            Panel1.Controls.Add(tb)

            ' Geser posisi vertikal untuk input berikutnya
            posisiY += tb.Height + 10
        Next
    End Sub

    ' Hanya izinkan angka
    Private Sub HanyaAngka_KeyPress(sender As Object, e As KeyPressEventArgs)
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    ' Validasi panjang digit harus 9–14
    Private Sub ValidasiPanjangDigit(sender As Object, e As EventArgs)
        Dim tb As TextBox = CType(sender, TextBox)
        Dim panjang As Integer = tb.Text.Length

        ' Batasi maksimal 14 digit
        If panjang > 13 Then
            MessageBox.Show("Maksimal hanya 13 digit!", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            tb.Text = tb.Text.Substring(0, 13)
            tb.SelectionStart = tb.Text.Length ' Kembalikan kursor ke akhir
            Return
        End If

        ' Validasi minimal (optional)
        If panjang > 0 AndAlso panjang < 9 Then
            tb.BackColor = Color.FromArgb(60, 60, 95) ' tandai error

        Else
            tb.BackColor = Color.FromArgb(60, 60, 60) ' reset jika valid
        End If
    End Sub

    Private Async Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        BtnCreaForm.Enabled = False
        btnSend.Enabled = False
        JCount.Enabled = False
        Dim jmlCount = Panel1.Controls.OfType(Of TextBox)().Count()
        Dim TextMsg = TxtMessage.Text
        Dim del_msg As Integer = Delay.Value




        Dim Tsend As String = TotSender.Text
        Dim newDev, JObject As New JObject
        JObject = JObject.Parse(DataJson)

        If (jmlCount = 0) Then
            MsgBox("Error Data form Number Kosong")
            Exit Sub
        End If

        If (Tsend = "") Then
            MsgBox("Data Sender kosong")
            Exit Sub
        End If

        If (JObject.Count = 0) Then
            MsgBox("Data Sender kosong")
            Exit Sub
        End If



        Dim pingResult As PingReply = dbConn.PingDomain("www.mrjay59.com")
        ' Tampilkan hasil ping
        If pingResult.Status = 11010 Then
            MsgBox("Sepertinya Koneksi Ke Server Gagal Coba Gunakan Jaringan lain")

            Exit Sub
        End If


        Dim properties As IEnumerable(Of JProperty) = JObject.Properties()

        Dim NumArr As New JArray
        For Each prop As JProperty In properties
            Dim DataDev = prop.Name
            Dim txsender = JObject.SelectToken(DataDev).Item("number").ToString
            Dim prefix = JObject.SelectToken(DataDev).Item("prefix").ToString
            Dim NumObj As New JObject
            NumObj.Add("waname", DataDev)
            NumObj.Add("tsender", txsender)
            NumObj.Add("prefix", prefix)
            NumArr.Add(NumObj)

        Next

        Dim AllArr As New JArray
        For Each ctrl As Control In Panel1.Controls
            ' Misalnya ambil semua TextBox
            If TypeOf ctrl Is TextBox Then
                Dim tb As TextBox = CType(ctrl, TextBox)

                Dim DatObj As New JObject
                Dim DatNum = tb.Text.Trim
                DatObj.Add("message", TextMsg)
                DatObj.Add("sender", NumArr)
                DatObj.Add("to", DatNum)
                DatObj.Add("delay", del_msg)

                AllArr.Add(DatObj)


            End If
        Next


        Try
            ' Panggil metode asinkron yang menjalankan pekerjaan berat
            Await Work(AllArr)

            BtnCreaForm.Enabled = True
            btnSend.Enabled = True
            JCount.Enabled = True
        Catch ex As Exception

            MessageBox.Show("Terjadi kesalahan selama operasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            btnSend.Enabled = True ' Aktifkan kembali tombol
        End Try





    End Sub

    Private Async Function Work(DatArr As JArray) As Task

        Await Task.Run(Sub()

                           ' Loop isi JArray
                           For Each item As JObject In DatArr
                               Dim message As String = item("message").ToString()
                               Dim NumTo As String = item("to").ToString()
                               Dim delay As Integer = item("delay").ToString()

                               Dim sender As JArray = item("sender")



                               For Each item1 As JObject In sender
                                   Dim waname As String = item1("waname").ToString()
                                   Dim tsender As String = item1("tsender").ToString()
                                   Dim prefix As String = item1("prefix").ToString()
                                   Dim NumAsli As String = prefix & NumTo
                                   Dim jsArr As New JArray
                                   Dim jsdata As New JObject
                                   Dim jsdata1 As New JObject

                                   jsdata.Add("tonum", NumAsli)
                                   jsdata.Add("tsender", tsender)
                                   jsdata.Add("name", waname)
                                   jsdata.Add("text", message)
                                   jsdata.Add("metCall", "wascanqr")
                                   jsdata.Add("func", "OnConversation")
                                   jsArr.Add(jsdata)
                                   jsdata1.Add("body", jsArr)

                                   Me.Invoke(Sub()
                                                 lstLog.Items.Add(String.Format("Spam WA ke {0} Sender {1}-{2}", NumAsli, tsender, waname))
                                                 lstLog.SelectedIndex = lstLog.Items.Count - 1
                                             End Sub)

                                   Dim rnd As New Random()
                                   Dim angkaAcak As Integer = rnd.Next(20, delay)

                                   ' Penundaan waktu yang berat tetap di background thread
                                   System.Threading.Thread.Sleep(angkaAcak * 1000) ' TIDUR 25 DETIK DI BACKGROUND THREAD

                                   RaiseEvent SendDataJson(Me, New ClassData(jsdata1.ToString))


                                   ' Check if the thread should be stopped
                                   If threadShouldStop Then
                                       Exit For
                                       Exit For
                                       Exit Sub


                                   End If

                               Next



                           Next



                       End Sub)
    End Function

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles BtnSelect.Click

        Dim JValue As Integer = Panel1.Controls.OfType(Of TextBox)().Count()
        TxtSender.Text = ""
        DataJson = Nothing
        If (JValue = 0) Then
            MsgBox("Data Kosong")
            Exit Sub
        End If



        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        Dim NObj As New JObject
        NObj.Add("title", "Pilih WA SCANQr")
        NObj.Add("func", "loadWA")
        NObj.Add("username", username)
        Dim page As New PgDialog(NObj.ToString)

        AddHandler page.DataSelected, AddressOf DataMasuk

        page.ShowDialog()
    End Sub

    Private Sub DataMasuk(sender As Object, e As ClassData)
        Dim RData As String = e.Data
        Dim DatObj = e.Data
        '  Dim TotD = TotDial.Value
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim akustat = ParData("body")("apk_stat").ToString
        Dim DatParse = jsonpa.Json2aray(DatObj)
        Dim fun = DatParse("fun").ToString
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
    End Sub

    Private Sub BtnSSpam_Click(sender As Object, e As EventArgs) Handles BtnSSpam.Click
        threadShouldStop = True

        Threading.Thread.Sleep(3000)
        PnlogActivty.Controls.Clear()

        btnSend.Enabled = True
    End Sub
End Class