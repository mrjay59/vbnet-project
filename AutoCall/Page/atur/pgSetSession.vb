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
        ' Dim func As String = PObj("func")

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
        Dim username As String = PObj("username")
        Dim platform As String = PObj("platform")
        Dim name As String = PObj("name")


        param.Add("username", username)
        param.Add("platform", platform.ToLower)
        param.Add("data", "c_seassion")
        param.Add("name", name)

        Dim ListWA As String = WApp.OnListServer(param)
        'Console.WriteLine(ListWA)
        Dim DatParse = jsonpa.Json2aray(ListWA)


        UCformtext1.Lblname.Text = "Tanggal Buat"
        UCformtext2.Lblname.Text = "Subscribe"
        UCformtext3.Lblname.Text = "Tanggal Expired"
        UCformtext4.Lblname.Text = "Alamat Link"
        UCformtext5.Lblname.Text = "Server WhatsApp"
        UCformtext6.Lblname.Text = "Nama Session"
        UCformtext7.Lblname.Text = "Nomer Session"


        UCformtext1.txtinput.Text = DatParse("body")("created")
        UCformtext2.txtinput.Text = DatParse("body")("subscribe")
        UCformtext3.txtinput.Text = DatParse("body")("datexp")
        UCformtext4.txtinput.Text = ""
        UCformtext5.txtinput.Text = DatParse("body")("vendr")
        UCformtext6.txtinput.Text = DatParse("body")("appkode")
        'UCformtext7.txtinput.Text = DatParse("body")("number")

        'UCformtext1.txtinput.Enabled = IsReadOnline
        'UCformtext2.txtinput.Enabled = IsReadOnline
        'UCformtext3.txtinput.Enabled = IsReadOnline
        UCformtext4.txtinput.Enabled = True
        UCformtext6.txtinput.Enabled = True
        'UCformtext7.txtinput.Enabled = IsReadOnline


        'UCformtext2.txtinput.ReadOnly = Not IsReadOnline
        'UCformtext3.txtinput.ReadOnly = Not IsReadOnline
        'UCformtext6.txtinput.ReadOnly = Not IsReadOnline
        'UCformtext7.txtinput.ReadOnly = Not IsReadOnline

        MaxSPDay.Value = DatParse("body")("limit_perday")
        MaxSPNum.Value = DatParse("body")("limit_pernumber")



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

        param.Add("func", "SerUpdate")

        Dim msg = "yakin akan diubah ?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim response = WApp.OnUpdateServer(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            MsgBox(jsonObject("body"))
        End If
    End Sub



End Class