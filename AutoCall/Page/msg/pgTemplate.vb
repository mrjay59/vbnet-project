Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class pgTemplate
    Public Event DataSelected As EventHandler(Of ClassData)
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private Ap_mrjay59 As New mrjay59
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

    Private Sub pgTemplate_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadData()
    End Sub

    Private Sub HapusKontrol(sender As Object, e As ClassData)
        Dim DatObj = e.Data

        Dim Objon = jsonpa.Json2aray(DatObj)
        Dim title = Objon("title")


        Dim ParData = jsonpa.Json2aray(DatR)
        Dim username = ParData("body")("apk_user")


        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("title", title)
        param.Add("tipe", "Delete")

        Dim msg = "Apa Yakin Mau Hapus Template ini ?"



        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim response = WApp.OnTemplate(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 1) Then


                MsgBox(jsonObject("error"))
                Exit Sub
            Else
                MsgBox(jsonObject("body"))

            End If


        End If

        'Dim ctrl As InfoLabelControl = CType(sender, InfoLabelControl)
        'PanelPusat.Controls.Remove(ctrl)
        'ctrl.Dispose()

        LoadData()
    End Sub

    Private Sub OnInfoCheckedChanged(sender As Object, e As ClassData)
        Dim DatObj = e.Data

        RaiseEvent DataSelected(Me, New ClassData(DatObj.ToString))
    End Sub

    Private Sub LoadData()
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim username = ParData("body")("apk_user")
        Dim spacing As Integer = 5 ' Jarak antar kontrol
        Dim currentTop As Integer = 0

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", "loadData")

        Dim response = WApp.OnTemplate(param)
        Dim PTemp = jsonpa.Json2aray(response)
        Dim datSer As JArray = PTemp("body")
        Panel4.Controls.Clear()

        If (datSer.Count > 0) Then
            For Each item In datSer
                Dim Titlea = item("aichat_judul")
                Dim IsiTemp = item("aichat_text")


                Dim info As New InfoLabelControl()
                info.SetData(Titlea, IsiTemp)

                info.Width = Panel4.Width - 20 ' Sesuaikan dengan lebar panel
                info.Left = 10
                info.Top = currentTop
                info.Anchor = AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Top


                AddHandler info.HapusDiklik, AddressOf HapusKontrol
                AddHandler info.CheckedStatusChanged, AddressOf OnInfoCheckedChanged
                Panel4.Controls.Add(info)

                ' Update currentTop untuk posisi berikutnya
                currentTop += info.Height + spacing
            Next
        End If

    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub

    Private Sub Txtjudul_TextChanged(sender As Object, e As EventArgs) Handles Txtjudul.TextChanged
        ' Simpan posisi cursor sebelum perubahan
        Dim selectionStart As Integer = Txtjudul.SelectionStart
        Dim selectionLength As Integer = Txtjudul.SelectionLength

        ' Hilangkan spasi dan konversi ke huruf besar
        Txtjudul.Text = Txtjudul.Text.Replace(" ", "").ToUpper()

        ' Kembalikan posisi cursor
        Txtjudul.SelectionStart = selectionStart
        Txtjudul.SelectionLength = selectionLength
    End Sub

    Private Sub btnS_Click(sender As Object, e As EventArgs) Handles btnS.Click
        Dim ParData = jsonpa.Json2aray(DatR)
        Dim username = ParData("body")("apk_user")
        Dim title = Txtjudul.Text.Trim
        Dim IsiPesan = TxtMessage.Text

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("title", title)
        param.Add("textmessage", IsiPesan)
        param.Add("tipe", "create")

        Dim msg = "Apa Sudah Yakin Untuk Input Template ini ?"



        If (MessageBox.Show(msg, "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes) Then

            Dim response = WApp.OnTemplate(param)
            Dim jsonObject = JsonConvert.DeserializeObject(response)

            If (jsonObject("status")("code") = 1) Then


                MsgBox(jsonObject("error"))
                Exit Sub
            Else
                MsgBox(jsonObject("body"))
                LoadData()
            End If


        End If
    End Sub
End Class