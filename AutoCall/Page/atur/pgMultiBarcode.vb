Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports QRCoder

Public Class pgMultiBarcode

    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private qrControls As New Dictionary(Of String, UCScanQR)
    Private qrManagers As New Dictionary(Of String, QRManager)

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

    Public Sub LoadBarcodeMulti(ByVal DatObj As String)

        AddHandler WSManager.Client.MessageReceived, AddressOf wsClient_MessageReceived

        Dim PObj = jsonpa.Json2aray(DatObj)

        Dim ai = 0
        Dim x = 0
        Dim y = 0

        ' reset
        qrManagers.Clear()
        qrControls.Clear()
        PanelPusat.Controls.Clear()

        For Each item In PObj("body")

            Dim nama = item("name").ToString
            Dim navendor = item("navendor").ToString
            Dim tipe = item("tipe").ToString

            ai += 1

            Dim c As Integer
            Dim pin As Point

            ' ganjil (kiri)
            If (ai Mod 2 <> 0) Then
                x += 1
                c = x - 1
                pin = New Point(12, 255 * c + 6)
            Else
                ' genap (kanan)
                y += 1
                c = y - 1
                pin = New Point(450, 255 * c + 6)
            End If

            ' ======================
            ' CREATE UI
            ' ======================
            Dim ScanQr As New UCScanQR

            ScanQr.Location = pin
            ScanQr.LbWAnm.Text = nama
            ScanQr.Label1.Visible = False
            ScanQr.TxtNoWA.Visible = False
            ScanQr.BtnReqKode.Visible = False
            ScanQr.LblR.Visible = True
            ScanQr.LblR.Text = "Wait.."
            ScanQr.lstLog.Items.Add($"[Sesi : {nama}] Wait...")

            PanelPusat.Controls.Add(ScanQr)

            If (tipe = "rqQrkode") Then
                ' ======================
                ' CREATE MANAGER
                ' ======================
                Dim manager As New QRManager(nama, navendor, ScanQr.picQRCode)

                qrManagers.Add(nama, manager)
                qrControls.Add(nama, ScanQr)

                ' ======================
                ' BIND LOG EVENT (HARUS DI ATAS)
                ' ======================
                AddHandler manager.OnLog,
                Sub(msg)
                    HandleLog(nama, msg)
                End Sub

                ' ======================
                ' BARU JALANKAN
                ' ======================
                manager.OnScanRequired()

            Else
                ScanQr.LblR.Visible = False
                ScanQr.Label1.Visible = True
                ScanQr.TxtNoWA.Visible = True
                ScanQr.BtnReqKode.Visible = True
                ScanQr.lstLog.Items.Add($"[Sesi : Masukan No WA Exp:6281xx")

                ' ======================
                ' EVENT BUTTON REQUEST CODE
                ' ======================
                AddHandler ScanQr.BtnReqKode.Click,
                 Sub(s, ev)

                     Try

                         Dim nomor = ScanQr.TxtNoWA.Text.Trim()
                         ScanQr.BtnReqKode.Enabled = True
                         If String.IsNullOrEmpty(nomor) Then
                             ScanQr.lstLog.Items.Add("Nomor WA tidak boleh kosong")
                             Exit Sub
                         End If

                         ScanQr.lstLog.Items.Add($"[Sesi : {nama}] Request code ke {nomor}...")


                         Dim param As New JObject
                         param.Add("action", "request_code")
                         param.Add("name", nama)
                         param.Add("navendor", navendor)
                         param.Add("phoneNumber", nomor)

                         Dim res = WApp.OnSeassion(param)

                         If String.IsNullOrEmpty(res) Then
                             ScanQr.lstLog.Items.Add("Response kosong dari server")
                             Exit Sub
                         End If

                         Dim obj = JObject.Parse(res)

                         ' 🔥 HANDLE RESPONSE
                         If obj("message") IsNot Nothing Then

                             Dim status = obj("message").ToString()

                             If status.Contains("FAILED") Then
                                 ScanQr.LblR.Text = ""
                                 ScanQr.lstLog.Items.Add("Request code FAILED → logout session")
                                 ScanQr.lstLog.Items.Add("Klik Lagi Req kode")
                                 Dim objx As New JObject
                                 objx.Add("action", "logout")
                                 objx.Add("name", nama)
                                 objx.Add("navendor", navendor)

                                 ' optional restart
                                 WApp.OnSeassion(objx)

                                 Exit Sub
                             End If

                         End If

                         If obj("code") IsNot Nothing Then
                             ScanQr.LblR.Visible = True
                             ScanQr.LblR.Font = New Font(Font.FontFamily, 16, FontStyle.Bold)
                             ScanQr.LblR.Location = New Point(12, 90)
                             ScanQr.LblR.Text = obj("code").ToString
                             ScanQr.lstLog.Items.Add("KODE ANDA :" & obj("code").ToString)
                         End If


                     Catch ex As Exception
                         ScanQr.lstLog.Items.Add("Error: " & ex.Message)
                     End Try



                 End Sub
            End If

        Next

    End Sub

    Private Sub wsClient_MessageReceived(message As String)
        HandleEvent(message)
    End Sub

    Private Sub HandleLog(session As String, message As String)


        ' log ke masing-masing UI
        If qrControls.ContainsKey(session) Then

            Dim ctrl = qrControls(session)

            If ctrl.lstLog.InvokeRequired Then
                ctrl.lstLog.Invoke(Sub()



                                       ctrl.lstLog.Items.Add(message)

                                       If (message.Contains("QR displayed")) Then
                                           ctrl.LblR.Visible = False
                                           ctrl.picQRCode.Visible = True
                                           ctrl.picQRCode.Size = New Point(195, 195)
                                       ElseIf (Message.Contains("QR Manager STOPPED")) Then
                                           ctrl.LblR.Visible = True
                                           ctrl.picQRCode.Visible = False
                                           ctrl.LblR.Text = "STOPPED"

                                       End If

                                       ' auto scroll
                                       ctrl.lstLog.TopIndex = ctrl.lstLog.Items.Count - 1
                                   End Sub)
            Else
                ctrl.lstLog.Items.Add(message)

                If (message.Contains("QR displayed")) Then
                    ctrl.LblR.Visible = False
                    ctrl.picQRCode.Visible = True
                    ctrl.picQRCode.Size = New Point(195, 195)
                ElseIf (Message.Contains("QR Manager STOPPED")) Then
                    ctrl.LblR.Visible = True
                    ctrl.picQRCode.Visible = False
                    ctrl.LblR.Text = "STOPPED"
                End If

                ctrl.lstLog.TopIndex = ctrl.lstLog.Items.Count - 1
            End If

        End If

    End Sub

    Public Sub HandleEvent(json As String)

        Dim obj = JObject.Parse(json)

        Dim eventName = obj("event").ToString()
        Dim session = obj("session").ToString()

        If Not qrManagers.ContainsKey(session) Then Exit Sub

        Dim manager = qrManagers(session)

        If eventName = "session.status" Then

            Dim status = obj("payload")("status").ToString()

            Select Case status

                Case "SCAN_QR_CODE"
                    manager.OnScanRequired()

                Case "FAILED"
                ' biarkan manager handle restart logic

                Case "CONNECTED"
                    manager.Reset()

                Case "WORKING"
                    manager.Reset()

                Case "STOPPED"
                    manager.StopAll()

            End Select

        End If

    End Sub


End Class