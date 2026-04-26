Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.NetworkInformation
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmLogin
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private dbJson As New ClassJson
    Private EnDe As New DeEnCrypt
    Private Sub BtnLogin_Click(sender As Object, e As EventArgs) Handles BtnLogin.Click
        Dim username = txtuser.Text.Trim
        Dim userpass = txtpass.Text.Trim
        Dim apkname = dbConn.ApkProfile("name")
        Dim serial As String = EnDe.GetIdDevice
        Dim apkvers = dbConn.ApkProfile("versi")
        Dim userpc As String = EnDe.GetUserName

        Dim result = dbConn.CheckServerHealthy("autocall.my.id")

        If Not result.Item1 Then
            MsgBox("Server bermasalah: " & result.Item2)
            Exit Sub
        End If



        If (username = "" Or userpass = "") Then
            MsgBox("Ada field yang belum di isi dicek lagi")
            Exit Sub
        End If

        Dim DbSource As String = dbConn.SearchPATH()
        Dim soudb = JsonConvert.DeserializeObject(DbSource)
        Dim token As String = soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname)

        ' service register member
        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("userpass", userpass)
        param.Add("apk_produk", apkname)
        param.Add("prdmsin", serial)
        param.Add("devname", userpc)
        param.Add("prdversi", apkvers.ToString)
        param.Add("token", token.ToString)
        Try
            Dim response = Ap_mrjay59.login(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            'If (jsonObject = "") Then
            '    MsgBox("konek ke server tidak bisa mungkin coba direstar modem wifi/perangkatnya")
            '    Exit Sub
            'End If

            If (jsonObject("status")("code") = 1) Then
                For Each item In jsonObject("error")
                    MsgBox(item)
                Next
                Exit Sub
            Else
                Dim restoken = Ap_mrjay59.getoken(param)
                MsgBox(jsonObject("body"), MsgBoxStyle.Information, "Informasi")

                If (MsgBoxResult.Ok) Then

                    Dim dejsontoken = JsonConvert.DeserializeObject(restoken)


                    soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname) = dejsontoken("body")("apk_getoken")


                    Dim upjson = soudb.ToString
                    File.WriteAllText(Application.StartupPath & "\Application\setting.json", upjson)

                    Dim DRes = Ap_mrjay59.DataUser
                    Form1.ReceivedData = DRes
                    Form1.Show()
                    frmLayer1.Hide()
                End If

            End If
        Catch generatedExceptionName As JsonSerializationException
            Console.WriteLine("The string is not valid JSON.")
        End Try
    End Sub

    Private Sub Btneyes_Click(sender As Object, e As EventArgs) Handles Btneyes.Click
        If (txtpass.Tag = "N") Then
            txtpass.Tag = "Y"
            txtpass.PasswordChar = ""
        Else
            txtpass.PasswordChar = "*"
            txtpass.Tag = "N"
        End If
    End Sub

    Private Sub BtnLogin_Paint(sender As Object, e As PaintEventArgs) Handles BtnLogin.Paint
        Dim width = BtnLogin.Width
        Dim Height = BtnLogin.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnLogin.Region = New Region(path)
    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim apkvers = dbConn.ApkProfile("versi")

        lblversi.Text = "Versi " & apkvers
    End Sub
End Class
