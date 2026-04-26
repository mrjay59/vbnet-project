Imports System.Drawing.Drawing2D
Imports System.IO

Public Class frmConfigD
    Private PathFileIni As String = String.Empty
    Public Sub New(ByVal IniFile As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim NameFile As String = Path.GetFileName(IniFile).Replace(".ini", "")
        Dim ReadFileIn As New IniFileReader(IniFile)
        PathFileIni = IniFile
        lbltext.Text = "Config Akun " & NameFile
        DAkunSIP.Lblname.Text = "Nama Akun "
        DDomainSIP.Lblname.Text = "Domain SIP"
        DServerSIP.Lblname.Text = "Server SIP"
        DUserSIP.Lblname.Text = "Username SIP"
        DAkunSIP.txtinput.Text = ReadFileIn.ReadValue("Account1", "label")
        DDomainSIP.txtinput.Text = ReadFileIn.ReadValue("Account1", "domain")
        DServerSIP.txtinput.Text = ReadFileIn.ReadValue("Account1", "server")
        DUserSIP.txtinput.Text = ReadFileIn.ReadValue("Account1", "username")

        DAkunSIP.txtinput.ReadOnly = False
        DDomainSIP.txtinput.ReadOnly = False
        DServerSIP.txtinput.ReadOnly = False
        DUserSIP.txtinput.ReadOnly = False

    End Sub

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles BtnSave.Click
        Dim AkunSip = DAkunSIP.txtinput.Text
        Dim DomainSip = DDomainSIP.txtinput.Text
        Dim ServerSip = DServerSIP.txtinput.Text
        Dim UserSip = DUserSIP.txtinput.Text

        Dim WriteFileIn As New IniFileReader(PathFileIni)

        WriteFileIn.WriteValue("Account1", "label", AkunSip)
        WriteFileIn.WriteValue("Account1", "domain", DomainSip)
        WriteFileIn.WriteValue("Account1", "server", ServerSip)
        WriteFileIn.WriteValue("Account1", "username", UserSip)

        MsgBox("sudah diupdate")
    End Sub

    Private Sub BtnSave_Paint(sender As Object, e As PaintEventArgs) Handles BtnSave.Paint
        Dim width = BtnSave.Width
        Dim Height = BtnSave.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnSave.Region = New Region(path)
    End Sub
End Class