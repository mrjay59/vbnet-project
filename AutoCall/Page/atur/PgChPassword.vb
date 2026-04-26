Imports System.Drawing.Drawing2D
Imports System.IO
Imports Newtonsoft.Json

Public Class PgChPassword
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private DatR As String = String.Empty
    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property
    Private Sub PgChPassword_Load(sender As Object, e As EventArgs) Handles Me.Load
        UCformtext1.Lblname.Text = "Password Lama"
        UCformtext2.Lblname.Text = "Password Baru"
        UCformtext3.Lblname.Text = "Konfirmasi Password Baru"
        UCformtext1.Btneyes.Visible = True
        UCformtext2.Btneyes.Visible = True
        UCformtext3.Btneyes.Visible = True

        UCformtext1.txtinput.PasswordChar = "*"
        UCformtext2.txtinput.PasswordChar = "*"
        UCformtext3.txtinput.PasswordChar = "*"
        UCformtext1.txtinput.Tag = "N"
        UCformtext2.txtinput.Tag = "N"
        UCformtext3.txtinput.Tag = "N"
        UCformtext1.txtinput.ReadOnly = False
        UCformtext2.txtinput.ReadOnly = False
        UCformtext3.txtinput.ReadOnly = False
    End Sub

    Private Sub BtnChPass_Click(sender As Object, e As EventArgs) Handles BtnChPass.Click
        Dim pslama = UCformtext1.txtinput.Text.Trim
        Dim psbaruu = UCformtext2.txtinput.Text.Trim
        Dim psbarur = UCformtext3.txtinput.Text.Trim
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim msg = "Apa Yakin Mau Ganti Passwordnya?"

        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
            ' service register member
            Dim param As New Dictionary(Of String, String)
            param.Add("username", username)
            param.Add("passlama", pslama)
            param.Add("passbaru1", psbaruu)
            param.Add("passbaru2", psbarur)
            Dim apkname = dbConn.ApkProfile("name")
            Dim DbSource As String = dbConn.SearchPATH()
            Dim soudb = JsonConvert.DeserializeObject(DbSource)
            soudb("SERVICE")("MRJAY59")("HEADER")("userToken")(apkname) = ""

            Dim response = Ap_mrjay59.gantipass(param)
            Dim jsonrespon = JsonConvert.DeserializeObject(response)

            If (jsonrespon("status")("code") = 1) Then
                For Each item In jsonrespon("error")
                    MsgBox(item)
                Next
            Else
                MsgBox(jsonrespon("body"))
                Dim upjson = soudb.ToString
                File.WriteAllText(Application.StartupPath & "\Application\setting.json", upjson)


                Me.Close()
                Form1.Close()
                frmLayer1.Close()
                PgLoading.TopLevel = True
                PgLoading.Startimer()
                PgLoading.Show()
            End If
        End If



    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub BtnChPass_Paint(sender As Object, e As PaintEventArgs) Handles BtnChPass.Paint
        Dim width = BtnChPass.Width
        Dim Height = BtnChPass.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnChPass.Region = New Region(path)
    End Sub
End Class