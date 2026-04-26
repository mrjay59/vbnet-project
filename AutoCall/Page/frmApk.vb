Imports System.Drawing.Drawing2D
Imports System.Globalization
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq

Public Class frmApk
    Private dbConn As New ClassConnect
    Private jsonpa As New ClassJson
    Private DatR As String = String.Empty
    Private Ap_mrjay59 As New mrjay59
    Private DataRespon As String = String.Empty
    Private DataParse As Object = Nothing

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Sub loadpaket()
        Dim apkname = dbConn.ApkProfile("name")
        ' service register member
        Dim param As New Dictionary(Of String, String)
        param.Add("prdname", apkname)
        Dim culture As CultureInfo = New CultureInfo("id-ID")

        DataRespon = Ap_mrjay59.gepaket(param)
        DataParse = JsonConvert.DeserializeObject(DataRespon)
        Dim apkdes = JsonConvert.DeserializeObject(DataParse("apk_desc"))

        Dim a = 0
        For Each item In apkdes("data")
            a = a + 1
            Dim b = a - 1
            Dim paket = item("paket").ToString
            Dim harga As Decimal = item("harga")
            Dim desc As JArray = item("desc")
            Dim frmhrg As String = harga.ToString("C", culture)
            Dim ctpaket As New CtPackageUser
            ctpaket.lbPaket.Text = paket
            ctpaket.LblPrice.Text = frmhrg
            ctpaket.Location = New Point(b * 300 + 20, 20)
            PanelPusat.Controls.Add(ctpaket)

            Dim ax = 0
            For Each xitem As String In desc
                ax = ax + 1
                Dim bx = ax - 1
                Dim ctlist As New CtList
                ctlist.Lblname.Text = xitem
                ctlist.Location = New Point(5, bx * 30 + 3)
                ctpaket.PanelPusat.Controls.Add(ctlist)

            Next
        Next

    End Sub
    Private Sub BtnPaket_Click(sender As Object, e As EventArgs) Handles BtnPaket.Click

        BtnPaket.BackColor = Color.Transparent
        BtnProduk.BackColor = Color.Gray



        Dim x = BtnPaket.Location.X
        Dim y = BtnPaket.Location.Y + BtnPaket.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnPaket.Width
        Panelgb.Visible = True

        loadpaket()
    End Sub

    Private Sub BtnPaket_Paint(sender As Object, e As PaintEventArgs) Handles BtnPaket.Paint
        Dim width = BtnPaket.Width
        Dim Height = BtnPaket.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 20 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnPaket.Region = New Region(path)
    End Sub

    Private Sub BtnProduk_Click(sender As Object, e As EventArgs) Handles BtnProduk.Click
        BtnPaket.BackColor = Color.Gray
        BtnProduk.BackColor = Color.Transparent



        Dim x = BtnProduk.Location.X
        Dim y = BtnProduk.Location.Y + BtnProduk.Height
        Panelgb.Location = New Point(x, y)
        Panelgb.Width = BtnProduk.Width
        Panelgb.Visible = True


    End Sub

    Private Sub BtnProduk_Paint(sender As Object, e As PaintEventArgs) Handles BtnProduk.Paint
        Dim width = BtnProduk.Width
        Dim Height = BtnProduk.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 20 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        BtnProduk.Region = New Region(path)
    End Sub

    Private Sub frmApk_Load(sender As Object, e As EventArgs) Handles Me.Load
        BtnPaket_Click(sender, e)
    End Sub
End Class