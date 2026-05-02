Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports QRCoder

Public Class PgDaServer

    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private mjy As New mrjay59
    Public Event SendDataJson As EventHandler(Of ClassData)
    Private WithEvents paging As New PagingControl()
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    ' Function untuk memeriksa apakah kontrol dengan nama tertentu sudah ada di Panel
    Private Function IsControlInPanelByName(panel As Panel, controlName As String) As Boolean
        For Each ctrl As Control In panel.Controls
            If ctrl.Name = controlName Then
                Return True
            End If
        Next
        Return False
    End Function

    Function GenerateQRCode(inputText As String) As Bitmap
        ' Buat objek QRCodeGenerator
        Dim qrGenerator As New QRCodeGenerator()
        ' Buat data QR Code
        Dim qrCodeData As QRCodeData = qrGenerator.CreateQrCode(inputText, QRCodeGenerator.ECCLevel.Q)
        ' Buat QR Code dari data
        Dim qrCode As New QRCode(qrCodeData)
        ' Render QR Code sebagai gambar Bitmap
        Dim qrCodeImage As Bitmap = qrCode.GetGraphic(30)

        Return qrCodeImage
    End Function

    Public Sub OnReceiveData(sender As Object, e As ClassData)
        Dim msg = e.Data
        Console.WriteLine(msg)
        Dim apkname = dbConn.ApkProfile("name")
        Dim mmsg As String = String.Empty
        Dim sessionId As String = String.Empty
        '  "message": "connectionState: {\"qr\":\"2@FnC3ruK/Bm+qit4aPtDUYhJlxQj9yzq9dpFJZuG/galDHpzIIEPBDM2cpC/KCj2h+r2VvhYwkLKhsJzZZ8JH3esL8Xt5IliwG0c=,ur9ZoJVGz17aS49PrcQQMONoQgqHs9UZYebw+KKNkAw=,ME9d0DA7K+H5ELtxOqIdNNTCKRCuc0+BxA7StEzSRmo=,ROWyoH7rWGKVVTGoGDvphYvGcNO6KnN2KMBTTD2ajD4=\"}",
        Dim fodev = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\" & apkname
        Dim FoldeQ = fodev & "\WASCANQR"

        If Not (Directory.Exists(FoldeQ)) Then
            IO.Directory.CreateDirectory(FoldeQ)
        End If


        If msg.IndexOf("connectionState") > 0 AndAlso msg.IndexOf("qr") > 0 Then
            Dim QQrode As String = String.Empty
            Dim WSanArr = jsonpa.Json2aray(msg)
            Dim XXmsg As String = WSanArr("message").ToString.Replace("connectionState:", "")
            sessionId = WSanArr("sessionId").ToString
            Dim QrrArr = jsonpa.Json2aray(XXmsg)
            '  Dim WCanResp As String = XXmsg(2)
            QQrode = QrrArr("qr")

            If Not IsNothing(QQrode) Then
                'Dim payload As String = QQrode.ToString()
                ' Panggil function untuk generate QR Code
                Dim qrCodeImage As Bitmap = GenerateQRCode(QQrode)

                ' Simpan QR Code sebagai file gambar
                Dim filePath As String = FoldeQ & $"\qrcode_{sessionId}.png"

                If (IO.File.Exists(filePath)) Then
                    File.Delete(filePath)
                End If

                qrCodeImage.Save(filePath, Imaging.ImageFormat.Png)
            End If

            mmsg = "Create Qrcode...." & QQrode

        ElseIf msg.IndexOf("connectionState") > 0 AndAlso msg.IndexOf("connection") > 0 Then
            Dim WSanArr = jsonpa.Json2aray(msg)
            Dim XXmsg As String = WSanArr("message").ToString.Replace("connectionState:", "")
            sessionId = WSanArr("sessionId").ToString
            Dim QrrArr = jsonpa.Json2aray(XXmsg)
            mmsg = QrrArr("connection").ToString

        Else

            Dim XXmsg As String = jsonpa.dencode(msg, "message")
            sessionId = jsonpa.dencode(msg, "sessionId")
            mmsg = XXmsg
        End If

        For Each ctrl As Control In PnListServer.Controls
            If TypeOf ctrl Is UClistScanQr Then
                Dim item = DirectCast(ctrl, UClistScanQr)
                Dim lblText = item.LblSeassionId.Text
                Dim Seassionid As String() = lblText.Split("-")


                If Not (Seassionid(0) = sessionId) Then
                    If msg.IndexOf("Ready") >= 0 OrElse msg.IndexOf("Failure") >= 0 _
                                                         OrElse msg.IndexOf("Timeout") >= 0 OrElse msg.IndexOf("ERR_NAME") >= 0 Then
                        item.Btnstt.Enabled = True
                        item.BtnLOut.Enabled = True
                    End If
                End If

            End If
        Next



        For Each control As UCScanQR In PnDScanQr.Controls.OfType(Of UCScanQR)()
            Dim sesid = control.LbWAnm.Text.Trim

            If (sesid = sessionId) Then
                Dim qrcodePath As String = FoldeQ & $"\qrcode_{sessionId}.png"

                Try

                    If File.Exists(qrcodePath) Then

                        Dim qrCode As Image


                        Using originalImage As New Bitmap(qrcodePath)
                            qrCode = New Bitmap(originalImage, New Point(195, 195))

                        End Using

                        If msg.IndexOf("Ready") >= 0 OrElse msg.IndexOf("Failure") >= 0 _
                                                          OrElse msg.IndexOf("Timeout") >= 0 OrElse msg.IndexOf("ERR_NAME") >= 0 Then



                            'image close 
                            control.LblR.Visible = True
                            control.LblR.Text = "Ready"
                            control.picQRCode.Visible = False
                            File.Delete(qrcodePath)

                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)
                        Else
                            ' update UI dari thread yang berbeda
                            control.LblR.Visible = False
                            control.picQRCode.Invoke(
                                                                              Sub()
                                                                                  control.picQRCode.Visible = True
                                                                                  control.picQRCode.Image = qrCode
                                                                              End Sub)


                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)


                        End If


                    Else

                        If msg.IndexOf("Ready") >= 0 OrElse msg.IndexOf("Failure") >= 0 _
                                                          OrElse msg.IndexOf("Timeout") >= 0 OrElse msg.IndexOf("ERR_NAME") >= 0 Then



                            'image close 
                            control.LblR.Visible = True
                            control.LblR.Text = "Ready"
                            control.picQRCode.Visible = False


                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)
                        Else


                            ' update UI dari thread yang berbeda
                            control.lstLog.Invoke(
                                                                              Sub()
                                                                                  control.lstLog.Items.Add(String.Format("{0} ", mmsg))
                                                                                  control.lstLog.SelectedIndex = control.lstLog.Items.Count - 1
                                                                              End Sub)


                        End If
                    End If

                Catch ex As Exception

                End Try




            End If
        Next


    End Sub

    Public Sub ScanQrSingle(sender As Object, e As ClassData)
        PnDScanQr.Controls.Clear()
        ' Add any initialization after the InitializeComponent() call.
        Dim DatObj = e.Data
        RaiseEvent SendDataJson(Me, New ClassData(DatObj.ToString))
        Dim PObj = jsonpa.Json2aray(DatObj)
        Dim sessionId As String = PObj("body")(0)("name")
        Dim msg As String = PObj("body")(0)("msg")
        Dim funcx As String = PObj("body")(0)("func")

        If (funcx = "OnService") Then
            Dim ScanQr As New UCScanQR
            ScanQr.Location = New Point(31, 31)
            ScanQr.LbWAnm.Text = sessionId
            ScanQr.LblR.Text = msg
            ScanQr.LblR.Visible = True
            ScanQr.lstLog.Items.Add(String.Format("[Sesi : {0}]  {1} ", sessionId, msg))
            PnDScanQr.Controls.Add(ScanQr)
        End If


    End Sub





    Private Sub PgDaServer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' CreateButton()

    End Sub

    ' Atur placeholder dinamis
    Private Const PlaceholderText As String = "Cari nomor..."


    Private Sub TextSearch_KeyPress(sender As Object, e As KeyPressEventArgs)
        ' Izinkan hanya angka 0-9, backspace, dan delete
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub


    Private Sub BtnLocal_Click(sender As Object, e As EventArgs) Handles BtnLocal.Click
        Label1.Text = "Form WA SCANQR"
        LoadDataWA("wascanqr")
    End Sub

    Private Sub LoadDataWA(ByVal tipe As String)
        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")


        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("tipe", tipe)

        Dim response = mjy.getAkunAkses(param)


    End Sub

    Private Sub BtnClould_Click(sender As Object, e As EventArgs) Handles BtnClould.Click
        Label1.Text = "Form WA CLOULD"
        LoadDataWA("waserver")
    End Sub
End Class