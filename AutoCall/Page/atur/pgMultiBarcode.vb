Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports QRCoder

Public Class pgMultiBarcode
    Private qrManagers As New Dictionary(Of String, QRManager)
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private qrControls As New Dictionary(Of String, UCScanQR)


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


    Public Sub LoadMultiRegKode(ByVal DatObj As String)
        AddHandler WSManager.Client.MessageReceived, AddressOf wsClient_MessageReceived

        Dim PObj = jsonpa.Json2aray(DatObj)

        Dim ai = 0
        Dim x = 0
        Dim y = 0

        PanelPusat.Controls.Clear()

        For Each item In PObj("body")

            Dim nama = item("name").ToString
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
            ScanQr.LblR.Visible = False
            ScanQr.Label1.Visible = True
            ScanQr.TxtNoWA.Visible = True
            ScanQr.BtnReqKode.Visible = True
            ScanQr.lstLog.Items.Add($"[Sesi : {nama}] Wait...")

            PanelPusat.Controls.Add(ScanQr)



        Next
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

            ' ======================
            ' CREATE MANAGER
            ' ======================
            Dim manager As New QRManager(nama, ScanQr.picQRCode)

            qrManagers.Add(nama, manager)
            qrControls.Add(nama, ScanQr)

            ' ======================
            ' BIND LOG EVENT (IMPORTANT)
            ' ======================
            AddHandler manager.OnLog,
            Sub(msg)
                HandleLog(nama, msg)
            End Sub

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

                                       ' auto scroll
                                       ctrl.lstLog.TopIndex = ctrl.lstLog.Items.Count - 1
                                   End Sub)
            Else
                ctrl.lstLog.Items.Add(message)
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

                Case "STOPPED"
                    manager.StopAll()

            End Select

        End If

    End Sub


End Class