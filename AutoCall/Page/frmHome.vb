Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmHome
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private DatR As String = String.Empty
    Private Ap_mrjay59 As New mrjay59
    Private EnDe As New DeEnCrypt
    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub loadata()
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim siplocal As Integer = ParData("body")("apk_data")(0)("fitur")("siplocal")
        Dim waserver_send As Integer = ParData("body")("apk_data")(0)("fitur")("waserver_send")
        Dim wascanqr As Integer = ParData("body")("apk_data")(0)("fitur")("wascanqr")
        Dim android As Integer = ParData("body")("apk_data")(0)("fitur")("android")
        Dim wordsay = ParData("body")("wordsay")
        Dim gretting = ParData("body")("gretting")

        Dim imgpath As String = Application.StartupPath & "\img\"
        'USERBOOTUN1
        UserButton1.PictureBox1.Image = New Bitmap(imgpath & "waserver.png")
        UserButton1.lbtitle.Text = "WA Server"
        UserButton1.LbCount.Text = "/" & waserver_send

        UserButton2.PictureBox1.Image = New Bitmap(imgpath & "sip.png")
        UserButton2.lbtitle.Text = "SIP Local"
        UserButton2.LbCount.Text = "/" & siplocal

        UserButton3.PictureBox1.Image = New Bitmap(imgpath & "android.png")
        UserButton3.lbtitle.Text = "Android"
        UserButton3.LbCount.Text = "/" & android

        UserButton4.PictureBox1.Image = New Bitmap(imgpath & "wascanqr.png")
        UserButton4.lbtitle.Text = "WA Scanqr"
        UserButton4.LbCount.Text = "/" & wascanqr


        UcLbl1.BackColor = Color.Transparent
        UcLbl1.Lblinfo.Text = gretting

        UcLbl2.BackColor = Color.Transparent
        UcLbl2.Lblinfo.Text = wordsay

    End Sub

    Private Sub loadprofil()
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim apk_user = ParData("body")("apk_user")
        Dim apk_fullname = ParData("body")("apk_fullname")
        Dim apk_hp = ParData("body")("apk_hp")
        Dim apk_stat = ParData("body")("apk_stat")
        Dim exptoken = ParData("body")("token")("exptoken")
        ' Dim data = jsonpa.Json2aray(ParData("body")("apk_data"))
        Dim prodname = ParData("body")("apk_data")(0)("apk_product")
        Dim prodversi = ParData("body")("apk_data")(0)("apk_versi")
        Dim paket = ParData("body")("apk_data")(0)("apk_status")


        CtUserProfile1.Lblname.Text = "Username : " & apk_user
        CtUserProfile2.Lblname.Text = "Nama     : " & apk_fullname
        CtUserProfile3.Lblname.Text = "Hp       : " & apk_hp
        CtUserProfile4.Lblname.Text = "Status   : " & IIf(apk_stat = "AK", "AKTIF", "TIDAK")
        CtUserProfile5.Lblname.Text = "Sesi log : " & exptoken
        CtUserProfile6.Lblname.Text = "Produk : " & prodname
        CtUserProfile7.Lblname.Text = "Versi  : " & prodversi
        CtUserProfile8.Lblname.Text = "Paket  : " & paket

        CtUserProfile1.BackColor = Color.Transparent
        CtUserProfile2.BackColor = Color.Transparent
        CtUserProfile3.BackColor = Color.Transparent
        CtUserProfile4.BackColor = Color.Transparent
        CtUserProfile5.BackColor = Color.Transparent
        CtUserProfile6.BackColor = Color.Transparent
        CtUserProfile7.BackColor = Color.Transparent
        CtUserProfile8.BackColor = Color.Transparent


    End Sub

    Private Sub info()

        Dim DatUser = jsonpa.Json2aray(DatR)
        DatTable1.Controls.Clear()
        Dim datNews As JArray = DatUser("body")("news")
        Dim ai = 0
        If (datNews.Count = 0) Then
            Exit Sub
        End If

        For Each item As JObject In datNews
            Dim titleNe = item("info_title")
            Dim contentNe = item("info_text")
            Dim newDate As Date = item("info_tglcrea")

            Dim news As New NewsItemControl()
            news.NewsTitle = titleNe
            news.NewsContent = contentNe
            news.NewsDate = newDate
            news.Location = New Point(20, ai * 150 + 20)
            PnInfo.Controls.Add(news)

            ai += 1
        Next


    End Sub

    Private Sub TableDataLogDevice()
        DatTable1.Columns.Clear()
        DatTable1.Rows.Clear()
        DatTable1.AutoGenerateColumns = False

        ' Buat kolom secara dinamis
        Dim kolom As New DataGridViewTextBoxColumn()
        Dim kolomb As New DataGridViewButtonColumn()
        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "id"
        kolom.HeaderText = "NO"
        kolom.DataPropertyName = "id"
        kolom.Width = 150
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "devname"
        kolom.HeaderText = "Device Name"
        kolom.DataPropertyName = "devname"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "serial"
        kolom.HeaderText = "No Seri"
        kolom.DataPropertyName = "serial"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "devupdate"
        kolom.HeaderText = "Last Update"
        kolom.DataPropertyName = "devupdate"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "devTokenExp   "
        kolom.HeaderText = "Token Exp"
        kolom.DataPropertyName = "devTokenExp"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)

        kolom = New DataGridViewTextBoxColumn()
        kolom.Name = "devstate"
        kolom.HeaderText = "Status"
        kolom.DataPropertyName = "devstate"
        kolom.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolom)


        kolomb = New DataGridViewButtonColumn()
        kolomb.Name = "delete"
        kolomb.HeaderText = "DELETE"
        kolomb.Text = "Delete"
        kolomb.UseColumnTextForButtonValue = True
        kolomb.DataPropertyName = "delete"
        kolomb.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DatTable1.Columns.Add(kolomb)

        Dim DatR = Ap_mrjay59.DataUser
        Dim DatUser = jsonpa.Json2aray(DatR)
        DatTable1.Controls.Clear()

        Dim ai = 0

        If (DatUser("status")("code") = 1) Then
            For Each item In DatUser("error")
                MsgBox(item)
            Next
            Exit Sub

        End If

        Dim DatlogDev As JArray = DatUser("body")("devLog")
        If (DatlogDev.Count = 0) Then

            MsgBox("Data log Sudah tidak ada silahkan login kembali")
            Exit Sub

        End If
        For Each item As JObject In DatlogDev
            ai = ai + 1
            Dim devname = item("dev_name")
            Dim dev_serial = item("dev_serial")
            Dim dev_update = item("dev_update")
            Dim dev_tokenexp = item("dev_tokenexp")
            Dim dev_status = item("dev_status")



            Dim row As String() = New String() {ai, devname, dev_serial, dev_update, dev_tokenexp, dev_status}
            DatTable1.Rows.Add(row)


        Next
    End Sub
    Private Sub frmHome_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadata()
        loadprofil()
        TableDataLogDevice()
        info()
    End Sub

    Private Sub DatTable1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DatTable1.CellContentClick
        Dim RowIndex = e.RowIndex
        Dim ColIndex = e.ColumnIndex

        Dim ParData = jsonpa.Json2aray(DatR)
        Dim username = ParData("body")("apk_user")
        Dim serial As String = ""
        Dim userpc As String = ""
        Dim apkname = dbConn.ApkProfile("name")



        If (ColIndex = 6) Then
            serial = DatTable1.Rows.Item(RowIndex).Cells(2).Value
            userpc = DatTable1.Rows.Item(RowIndex).Cells(1).Value
            Dim param As New Dictionary(Of String, String)
            param.Add("username", username)
            param.Add("apk_produk", apkname)
            param.Add("prdmsin", serial)
            param.Add("devname", userpc)
            param.Add("tipe", "delby")

            Dim msg = "Semua Log device Akan Di HAPUS ." + Environment.NewLine +
                     "Apakah ingin dilanjutkan"


            If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

                Dim response = Ap_mrjay59.delLog(param)
                Dim jsonObject = JsonConvert.DeserializeObject(response)

                MsgBox(jsonObject("body"))
                TableDataLogDevice()
            End If

        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles BtnDelete.Click
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim username = ParData("body")("apk_user")
        Dim serial As String = EnDe.GetWMI("Win32_Processor", "ProcessorId")
        Dim userpc As String = EnDe.GetUserName
        Dim apkname = dbConn.ApkProfile("name")


        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("apk_produk", apkname)
        param.Add("prdmsin", serial)
        param.Add("devname", userpc)
        param.Add("tipe", "delAll")

        Dim msg = "Semua Log device Akan Di HAPUS ." + Environment.NewLine +
                 "Apakah ingin dilanjutkan"


        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim response = Ap_mrjay59.delLog(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            MsgBox(jsonObject("body"))
            TableDataLogDevice()
        End If



    End Sub
End Class