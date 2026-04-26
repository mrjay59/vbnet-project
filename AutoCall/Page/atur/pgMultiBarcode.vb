Imports QRCoder
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.IO

Public Class pgMultiBarcode

    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Public Event SendDataJson As EventHandler(Of ClassData)
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


    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub

    Public Sub OnReceiveData(sender As Object, e As ClassData)
        Dim msg = e.Data
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

            Dim QrrArr = jsonpa.Json2aray(XXmsg)
            '  Dim WCanResp As String = XXmsg(2)
            QQrode = QrrArr("qr")

            If Not IsNothing(QQrode) Then
                sessionId = WSanArr("sessionId").ToString
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



        For Each control As UCScanQR In PanelPusat.Controls.OfType(Of UCScanQR)()
            Dim sesid = control.LbWAnm.Text.Trim

            If (sesid = sessionId) Then
                Dim qrcodePath As String = FoldeQ & $"\qrcode_{sesid}.png"

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

    Public Sub LoadBarcodeMulti(ByVal DatObj As String)
        Dim PObj = jsonpa.Json2aray(DatObj)
        Dim ai = 0
        Dim x = 0
        Dim y = 0



        For Each item In PObj("body")
            Dim nama = item("name").ToString
            ai = ai + 1

            Dim c As Integer
            Dim pin As Point
            ' ganjil
            If (ai Mod 2 <> 0) Then
                x = x + 1
                c = x - 1
                pin = New Point(12, 255 * c + 6)
            End If
            ' genap
            If (ai Mod 2 = 0) Then
                y = y + 1
                c = y - 1
                pin = New Point(450, 255 * c + 6)
            End If
            Dim ScanQr As New UCScanQR
            ScanQr.Location = pin
            ScanQr.LbWAnm.Text = nama
            ScanQr.LblR.Visible = True
            ScanQr.LblR.Text = "Wait.."
            ScanQr.lstLog.Items.Add(String.Format("[Sesi : {0}] .Wait... ", nama))
            PanelPusat.Controls.Add(ScanQr)

        Next



    End Sub
End Class