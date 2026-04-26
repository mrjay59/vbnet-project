Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class pgSetSession

    Public Event DataSelected As EventHandler(Of ClassData)
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private Mjay59 As mrjay59
    Private WApp As New WhatsAppClass
    Private DatR As String = String.Empty
    Private allowCoolMove As Boolean = False
    Private myCoolPoint As New System.Drawing.Point
    Private DatRec As String

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Public Sub New(ByVal DatObj As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim PObj = jsonpa.Json2aray(DatObj)
        Dim title As String = PObj("title")
        Dim func As String = PObj("func")

        LoadData(DatObj)
        lbltext.Text = title

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub LoadData(ByVal DatObj As String)
        Dim param As New Dictionary(Of String, String)
        Dim PObj = jsonpa.Json2aray(DatObj)
        Dim title As String = PObj("title")
        Dim func As String = PObj("func")
        Dim username As String = PObj("username")
        Dim platform As String = PObj("platform")
        Dim name As String = PObj("name")
        Dim IsReadOnline As Boolean = False
        Dim linkweb As String = String.Empty


        param.Add("username", username)
        param.Add("platform", platform.ToLower)
        param.Add("paging", 1)
        param.Add("carik", name)
        param.Add("all", "no")

        Dim ListWA As String = WApp.OnListServer(param)
        ' Console.WriteLine(ListWA)
        Dim DatParse = jsonpa.Json2aray(ListWA)
        Dim totpage As Integer = DatParse("body")("totalpage")
        Dim datSer As JArray = DatParse("body")("data")

        If (platform = "waserver") Then
            IsReadOnline = False
            linkweb = ""
        ElseIf (platform = "wascanqr") Then
            IsReadOnline = False
            linkweb = ""
        ElseIf (platform = "waforward") Then
            IsReadOnline = True
            linkweb = "https://chat.mrjay59.com?token=" & datSer(0)("aichat_webToken").ToString
        End If


        UCformtext1.Lblname.Text = "Tanggal Buat"
        UCformtext2.Lblname.Text = "Subscribe"
        UCformtext3.Lblname.Text = "Tanggal Expired"
        UCformtext4.Lblname.Text = "Alamat Link"
        UCformtext5.Lblname.Text = "Server WhatsApp"
        UCformtext6.Lblname.Text = "Nama Session"
        UCformtext7.Lblname.Text = "Nomer Session"

        If (datSer.Count = 0) Then
            MsgBox("Tidak ada data ditemukan harap di refresh")
            Exit Sub
        End If

        Dim funS = datSer(0)("aichat_func").ToString
        If (funS = "R") Then
            Rd0.Checked = True
        ElseIf (funS = "S") Then
            Rd1.Checked = True
        ElseIf (funS = "F") Then
            Rd2.Checked = True
        End If


        UCformtext1.txtinput.Text = datSer(0)("aichat_create")
        UCformtext2.txtinput.Text = datSer(0)("aichat_subs")
        UCformtext3.txtinput.Text = datSer(0)("aichat_expire")
        UCformtext4.txtinput.Text = linkweb
        UCformtext5.txtinput.Text = datSer(0)("aichat_ipserv")
        UCformtext5.txtinput.Tag = datSer(0)("aichat_platform")
        UCformtext6.txtinput.Text = datSer(0)("aichat_name")
        UCformtext7.txtinput.Text = datSer(0)("aichat_number")

        UCformtext1.txtinput.Enabled = IsReadOnline
        UCformtext2.txtinput.Enabled = IsReadOnline
        UCformtext3.txtinput.Enabled = IsReadOnline
        UCformtext4.txtinput.Enabled = IsReadOnline
        UCformtext6.txtinput.Enabled = IsReadOnline
        UCformtext7.txtinput.Enabled = IsReadOnline


        UCformtext2.txtinput.ReadOnly = Not IsReadOnline
        UCformtext3.txtinput.ReadOnly = Not IsReadOnline
        UCformtext6.txtinput.ReadOnly = Not IsReadOnline
        UCformtext7.txtinput.ReadOnly = Not IsReadOnline

        MaxSPDay.Value = datSer(0)("aichat_masend")
        MaxSPNum.Value = datSer(0)("aichat_csend")

        MaxSPNum.Tag = datSer(0)("aichat_id")

    End Sub

    Private Sub Btn1_Click(sender As Object, e As EventArgs) Handles Btn1.Click

        Dim ParData = jsonpa.Json2aray(DatR)
        Dim username = ParData("body")("apk_user")
        Dim sessionId = UCformtext6.txtinput.Text.Trim
        Dim numberMe = UCformtext7.txtinput.Text.Trim
        Dim SrverWA = UCformtext5.txtinput.Text.Trim
        Dim platform = UCformtext5.txtinput.Tag
        Dim SubS = UCformtext2.txtinput.Text.Trim
        Dim ExpireD = UCformtext3.txtinput.Text.Trim
        Dim MSPDay As Integer = MaxSPDay.Value
        Dim MSPNum As Integer = MaxSPNum.Value
        Dim IDServ As Integer = MaxSPNum.Tag

        Dim FunctS As String = String.Empty
        If (Rd0.Checked) Then
            FunctS = "R"
        ElseIf (Rd1.Checked) Then
            FunctS = "S"
        ElseIf (Rd2.Checked) Then
            FunctS = "F"
        End If

        Dim param As New Dictionary(Of String, String)
        param.Add("idserver", IDServ)
        param.Add("username", username)
        param.Add("sessionid", sessionid)
        param.Add("number", numberMe)
        param.Add("serverWA", SrverWA)
        param.Add("SubS", SubS)
        param.Add("ExpireD", ExpireD)
        param.Add("MaxSPDay", MSPDay)
        param.Add("MaxSPNum", MSPNum)
        param.Add("platform", platform)
        param.Add("fung", FunctS)
        param.Add("func", "SerUpdate")

        Dim msg = "yakin akan diubah ?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim response = WApp.OnUpdateServer(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            MsgBox(jsonObject("body"))
        End If
    End Sub

    Private Sub BtnDel_Click(sender As Object, e As EventArgs) Handles BtnDel.Click

    End Sub
End Class