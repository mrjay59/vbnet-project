Imports System.Drawing.Drawing2D
Imports System.Text
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmSignUp
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private EnDe As New DeEnCrypt
    Private DatR As String = String.Empty
    Private jsonpa As New ClassJson
    Public Event DataSelected As EventHandler(Of ClassData)
    Public Property ReceivedData() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub Btneyes_Click(sender As Object, e As EventArgs) Handles Btneyes.Click
        If (txtpass.Tag = "N") Then
            txtpass.Tag = "Y"
            txtpass.PasswordChar = ""
        Else
            txtpass.PasswordChar = "*"
            txtpass.Tag = "N"
        End If

    End Sub

    Private Sub Btndaftar_Click(sender As Object, e As EventArgs) Handles Btndaftar.Click

        Dim username = Txtuser.Text.Trim
        Dim userpass = txtpass.Text.Trim
        Dim namauser = txtname.Text
        Dim userhape = txthape.Text.Trim
        Dim userreff = ""
        Dim IDReg = TxtIdReg.Text.Trim

        Dim apkname = dbConn.ApkProfile("name")
        Dim apkvers = dbConn.ApkProfile("versi")

        Dim key As Byte() = Encoding.UTF8.GetBytes(EnDe.GetWMI("Win32_Processor", "ProcessorId"))
        Dim serial As String = EnDe.GetIdDevice
        Dim enmesin = EnDe.GetWMI("Win32_Processor", "ProcessorId")
        Dim userdev = EnDe.GetUserName

        If (username = "" Or userpass = "" Or namauser = "" Or userhape = "") Then
            MsgBox("Ada field yang belum di isi dicek lagi")
            Exit Sub
        End If

        Dim luser As Integer = Len(username)
        Dim lhp As Integer = Len(userhape)

        If (luser <= 5) Or (luser >= 9) Then
            MsgBox("username min 6 sd 8 char")
            Exit Sub
        End If

        If (lhp <= 9) Or (lhp >= 15) Then
            MsgBox("NO HP min 10 sd 14 digit")
            Exit Sub
        End If

        ' service register member
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("userpass", userpass)
        param.Add("namauser", namauser)
        param.Add("userhape", userhape)
        param.Add("userreff", userreff)
        param.Add("userIdReg", IDReg)

        param.Add("prdname", apkname)
        param.Add("prdvrsi", apkvers)
        param.Add("prdserl", serial)
        param.Add("prdkeys", EnDe.GetWMI("Win32_Processor", "ProcessorId"))
        param.Add("prdmsin", enmesin)
        param.Add("devname", userdev)



        Dim parameters As String = JsonConvert.SerializeObject(param, Formatting.None)

        Dim NeData As New JObject
        NeData.Add("menu", "paket")
        NeData.Add("data", parameters)


        Try
            Dim response = Ap_mrjay59.register(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 1) Then
                For Each item In jsonObject("error")
                    MsgBox(item)
                Next
            Else
                MsgBox(jsonObject("body"))
            End If
        Catch generatedExceptionName As JsonSerializationException
            Console.WriteLine("The string is not valid JSON.")
        End Try

        RaiseEvent DataSelected(Me, New ClassData(NeData.ToString))

    End Sub

    Private Sub txthape_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txthape.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub Btndaftar_Paint(sender As Object, e As PaintEventArgs) Handles Btndaftar.Paint
        Dim width = Btndaftar.Width
        Dim Height = Btndaftar.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        Btndaftar.Region = New Region(path)
    End Sub

    Private Sub frmSignUp_Load(sender As Object, e As EventArgs) Handles Me.Load

        Dim DatParse = jsonpa.Json2aray(DatR)
        Dim numfrom As String = DatParse("body")(0)("apk_numfro").ToString
        Dim apkmsgid As String = DatParse("body")(0)("apk_msgid").ToString
        TxtIdReg.Text = apkmsgid
        txthape.Text = numfrom
    End Sub
End Class
