Imports Newtonsoft.Json.Linq
Imports QRCoder
Imports QRCoder.PayloadGenerator

Public Class pgset1
    Private EnDe As New DeEnCrypt
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private serial As String = EnDe.GenerateRandomString(15)
    Public Event DataSelected As EventHandler(Of ClassData)
    Private DatR As String = String.Empty
    Private Sub pgset1_Load(sender As Object, e As EventArgs) Handles Me.Load
        getbarkode()
        Timer1.Enabled = True
        Timer1.Start()
    End Sub

    Private Sub getbarkode()

        Dim msg As String = "Saya Ingin Melakukan Pendaftaran Aplikasi AutoCall " & vbNewLine & "ID:" & serial

        Dim param As New Dictionary(Of String, String)
        param.Add("username", "akudemo")
        param.Add("platform", "wascanqr")
        param.Add("all", "open")
        param.Add("carik", "")
        Dim ListWA As String = Ap_mrjay59.getservnum(param)
        Dim DatParse = jsonpa.Json2aray(ListWA)
        Dim datSer As JArray = DatParse("body")("data")

        If (datSer.Count > 0) Then
            Dim listNumSe As New List(Of String)
            For Each item In datSer
                Dim Name As String = item("aichat_name")
                Dim number = item("aichat_number")
                Dim host = item("aichat_ipserv")
                Dim port = item("aichat_port")
                Dim service = item("aichat_service")
                Dim msend As Integer = item("aichat_masend")
                listNumSe.Add(number)
            Next
            Dim rnd As New Random()
            Dim ix As Integer = listNumSe.Count - 1
            Dim intArray(0 To ix) As String

            For x = 0 To ix
                intArray(x) = listNumSe.Item(x)
            Next
            Dim numsend = intArray(rnd.Next(0, ix))

            Dim LinkWa = "https://wa.me/" & numsend & "?text=" & msg

            Dim generator As Url = New Url(LinkWa)
            Dim payload As String = generator.ToString()
            Dim qrGenerator As QRCodeGenerator = New QRCodeGenerator()
            Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q)
            Dim qrCode As QRCode = New QRCode(qrCodeData)
            Dim qrCodeAsBitmap = qrCode.GetGraphic(5)
            Pcbarcode.Image = qrCodeAsBitmap
        End If

    End Sub
    Private Function getvalid()

        Dim param As New Dictionary(Of String, String)
        param.Add("serial", serial)
        param.Add("status", 0)
        Dim ListValid As String = Ap_mrjay59.getvalid(param)
        Return ListValid

    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim respon = getvalid()
        Dim DatParse = jsonpa.Json2aray(respon)
        If Not (DatParse Is Nothing) Then
            Dim numfrom As String = DatParse("body")(0)("apk_numfro").ToString
            Dim serserv As String = DatParse("body")(0)("apk_serial").ToString

            If (serserv = serial) Then
                Timer1.Stop()
                LbValid.Visible = True
                BtnNext.Visible = True
                Pcbarcode.Visible = False
                Dim msg = "Data Valid " & numfrom & " Silahkan Klik Next Form"
                DatR = respon.ToString
                MsgBox(msg)



            End If
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles BtnNext.Click
        Dim NeData As New JObject
        NeData.Add("menu", "signup")
        NeData.Add("data", DatR)

        Dim ObjString = NeData.ToString
        ' Raise the event and pass the selected data
        RaiseEvent DataSelected(Me, New ClassData(ObjString))
    End Sub

    Private Sub BtnNext_Paint(sender As Object, e As PaintEventArgs) Handles BtnNext.Paint

    End Sub
End Class