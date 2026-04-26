Imports System.Drawing.Drawing2D
Imports Newtonsoft.Json.Linq

Public Class UClistScanQr

    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Public Event SendDataJson As EventHandler(Of ClassData)
    Public Event ButtonClicked(sender As Object, isActive As Boolean)
    Public Property IsActive As Boolean = False
    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property
    Private Sub Btnstt_Click(sender As Object, e As EventArgs) Handles Btnstt.Click
        IsActive = Not IsActive
        RaiseEvent ButtonClicked(Me, IsActive)

        Dim txtbtn = Btnstt.Text
        Dim SesiId = LblSeassionId.Text.Trim
        Dim Seassionid As String() = SesiId.Split("-")
        Dim pl = LblSeassionId.Tag
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        If (pl = "wascanqr") Then
            If (txtbtn = "Start Service") Then

                Dim DaService, Param As New JObject
                Dim ArService As New JArray
                DaService.Add("name", Seassionid(0))
                DaService.Add("username", username)
                DaService.Add("func", "OnService")
                DaService.Add("msg", "Wait..")
                ArService.Add(DaService)
                Param.Add("body", ArService)



                RaiseEvent SendDataJson(Me, New ClassData(Param.ToString))

                Btnstt.Text = "Stop Service"
                Btnstt.BackColor = Color.Red
                Btnstt.ForeColor = Color.White

                BtnLOut.Visible = True
            ElseIf (txtbtn = "Stop Service") Then
                Dim DaService, Param As New JObject
                Dim ArService As New JArray
                DaService.Add("name", Seassionid(0))
                DaService.Add("username", username)
                DaService.Add("func", "OffService")
                DaService.Add("msg", "Wait..")
                ArService.Add(DaService)
                Param.Add("body", ArService)

                BtnLOut.Visible = False
                RaiseEvent SendDataJson(Me, New ClassData(Param.ToString))

                Btnstt.Text = "Start Service"
                Btnstt.BackColor = Color.FromArgb(80, 165, 190)
                Btnstt.ForeColor = Color.Black


            End If
        ElseIf (pl = "waforward") Then
            Dim stat As String = String.Empty
            If (txtbtn = "Start Service") Then
                stat = "OPEN"


                Btnstt.Text = "Stop Service"
                Btnstt.BackColor = Color.Red
                Btnstt.ForeColor = Color.White

                BtnLOut.Visible = True

            ElseIf (txtbtn = "Stop Service") Then
                stat = "CLOSE"

                Btnstt.Text = "Start Service"
                Btnstt.BackColor = Color.FromArgb(80, 165, 190)
                Btnstt.ForeColor = Color.Black


            End If
            Dim param As New Dictionary(Of String, String)
            param.Add("number", Seassionid(1))
            param.Add("func", "WASTAT")
            param.Add("WAName", Seassionid(0))
            param.Add("WAstat", stat)

            WApp.OnUpdateServer(param)
        End If

    End Sub


    Private Sub BtnLOut_Click(sender As Object, e As EventArgs) Handles BtnLOut.Click
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim txtbtn = Btnstt.Text
        Dim SesiId = LblSeassionId.Text.Trim
        Dim Seassionid As String() = SesiId.Split("-")
        Dim DaService, Param As New JObject
        Dim pl = LblSeassionId.Tag
        Dim ArService As New JArray
        DaService.Add("name", Seassionid(0))
        DaService.Add("username", username)
        DaService.Add("func", "Logout")
        DaService.Add("msg", "Wait..")
        ArService.Add(DaService)
        Param.Add("body", ArService)


        If (pl = "wascanqr") Then
            Dim msg = "Fungsi ini akan MENGHAPUS sesi koneksi ke Whatsapp Web." + Environment.NewLine +
                 "Jadi Anda harus melakukan scan ulang qrcode." + Environment.NewLine + Environment.NewLine +
                 "Apakah ingin dilanjutkan"


            If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then
                Btnstt.Text = "Start Service"


                RaiseEvent SendDataJson(Me, New ClassData(Param.ToString))
            End If
        ElseIf (pl = "waforward") Then
            Dim params As New Dictionary(Of String, String)
            params.Add("number", Seassionid(1))
            params.Add("func", "WADELETE")
            params.Add("WAName", Seassionid(0))
            params.Add("WAstat", "DELETE")

            WApp.OnUpdateServer(params)
        End If


    End Sub

    Private Sub UClistScanQr_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim width = Me.Width
        Dim Height = Me.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 5 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)
    End Sub

    Private Sub PnState_Paint(sender As Object, e As PaintEventArgs) Handles PnState.Paint

    End Sub

    Private Sub HapusHistoryPesanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HapusHistoryPesanToolStripMenuItem.Click

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim txtbtn = Btnstt.Text
        Dim SesiId = LblSeassionId.Text.Trim
        Dim Seassionid As String() = SesiId.Split("-")
        Dim DaService, Param As New JObject
        Dim pl = LblSeassionId.Tag
        Dim ArService As New JArray
        DaService.Add("name", Seassionid(0))
        DaService.Add("username", username)
        DaService.Add("func", "DeleteChat")
        DaService.Add("msg", "Wait..")
        ArService.Add(DaService)
        Param.Add("body", ArService)


        If (pl = "wascanqr") Then
            Dim msg = "Fungsi ini akan MENGHAPUS semua pesan." + Environment.NewLine +
                 "Apakah ingin dilanjutkan"


            If MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then


                RaiseEvent SendDataJson(Me, New ClassData(Param.ToString))
            End If

        End If

    End Sub

    Private Sub AturToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AturToolStripMenuItem.Click
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")
        Dim SesiId = LblSeassionId.Text.Trim
        Dim Seassionid As String() = SesiId.Split("-")
        Dim DaService As New JObject
        Dim pl = LblSeassionId.Tag

        DaService.Add("name", Seassionid(0))
        DaService.Add("username", username)
        DaService.Add("title", $"Setup Session {Seassionid(0)} - {pl}")
        DaService.Add("platform", pl)

        Dim page As New pgSetSession(DaService.ToString)
        page.SendDataUser = DatR
        page.ShowDialog()
    End Sub
End Class
