Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Text.RegularExpressions
Imports System.Threading
Imports Newtonsoft.Json.Linq

Public Class FrmTraningWA
    Private DatR As String = String.Empty
    Private WApp As New WhatsAppClass
    Private Ap_mrjay59 As New mrjay59
    Private jsonpa As New ClassJson
    Private dbConn As New ClassConnect
    Private DataJson = Nothing
    Public Event SendDataJson As EventHandler(Of ClassData)
    Private cts As CancellationTokenSource


    Public Property SendDataUser() As String
        Get
            Return DatR
        End Get
        Set(ByVal value As String)
            DatR = value
        End Set
    End Property

    Private Function LoadDataServer()

        Dim DPar = jsonpa.Json2aray(DatR)
        Dim username = DPar("body")("apk_user")

        Dim param As New Dictionary(Of String, String)
        param.Add("username", username)
        param.Add("platform", "wascanqr")
        param.Add("all", "open")
        param.Add("carik", "")
        ' "wascanqr"
        Dim ListWA As String = WApp.OnListServer(param)
        '  Dim datSer As JArray = DatParse("body")("data")

        Return ListWA

    End Function

    Private Function LoadTema()

        Dim param As New Dictionary(Of String, String)
        param.Add("username", "")
        Dim ListWA As String = WApp.Onconversation(param)
        Dim DPar As JArray = jsonpa.Json2aray(ListWA)

        Return DPar
    End Function

    Private Sub LoadWarmer()
        PanelPusat.Controls.Clear()
        Dim WAdata = LoadDataServer()
        Dim TemAd As JArray = LoadTema()

        Dim AdJml As Integer = TotWA.Value
        Dim jml As Integer = Math.Round(AdJml / 2)
        For ix = 0 To jml - 1

            Dim CtWA As New UCWarmer

            Dim pin = ix * 70 + 3

            CtWA.Location = New Point(9, pin)
            CtWA.ServerLoad(WAdata)
            CtWA.LoadTema(TemAd)
            'AddHandler CtWA.SendDataJson, AddressOf ScanQrSingle
            PanelPusat.Controls.Add(CtWA)

        Next


    End Sub

    Private Async Sub BtnProses_Click(sender As Object, e As EventArgs) Handles BtnProses.Click
        Application.DoEvents()
        lblStatus.Text = "Memulai proses data..."
        BtnProses.Enabled = False
        PanelPusat.Enabled = False
        BtnProses.BackColor = Color.Red
        BtnCreate.Enabled = False

        ' Token source untuk pembatalan
        cts = New CancellationTokenSource()

        Dim control = PanelPusat.Controls.OfType(Of UCWarmer)()
        AddHandler Form1.SendDataJson, AddressOf OnReceiveData

        If (control.Count = 0) Then
            MsgBox("Data Form belum ada di create")

            BtnProses.Enabled = True
            PanelPusat.Enabled = True
            BtnProses.BackColor = Color.FromArgb(80, 65, 90)
            Exit Sub
        End If

        Try
            ' Kirim token ke fungsi proses
            Await Watalkp2p(cts.Token)
            Me.lblStatus.Text = "Percakapan Selesai"
        Catch ex As OperationCanceledException
            MessageBox.Show("Task dibatalkan.")
        Catch ex As Exception
            Me.lblStatus.Text = "Terjadi kesalahan: " & ex.Message
            MessageBox.Show("Terjadi kesalahan selama operasi: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            BtnProses.Enabled = True
            PanelPusat.Enabled = True
            BtnCreate.Enabled = True
            BtnProses.BackColor = Color.FromArgb(80, 65, 90)
        End Try

        RemoveHandler Form1.SendDataJson, AddressOf OnReceiveData
    End Sub
    Private Async Function Watalkp2p(token As CancellationToken) As Task
        Await Task.Run(Sub()
                           System.Threading.Thread.Sleep(1000)

                           For Each control As UCWarmer In PanelPusat.Controls.OfType(Of UCWarmer)()

                               Dim Waname1 As String = "", WAsender1 As String = "", Waname2 As String = "", WAsender2 As String = ""
                               Dim tema As String = "", valueTema As String = ""

                               Me.Invoke(Sub()
                                             Waname1 = control.CmNumber1.Text
                                             WAsender1 = control.CmNumber1.SelectedValue?.ToString()
                                             Waname2 = control.CmNumber2.Text
                                             WAsender2 = control.CmNumber2.SelectedValue?.ToString()
                                             tema = control.Tema.Text
                                             valueTema = control.Tema.SelectedValue?.ToString().Replace("""", "")
                                         End Sub)

                               Dim lines() As String = valueTema.Split({Environment.NewLine, vbLf}, StringSplitOptions.RemoveEmptyEntries)
                               Dim ax = 0

                               Me.Invoke(Sub()
                                             Me.lblStatus.Text = "Memuat Data Percakapan.. "
                                         End Sub)

                               For Each line As String In lines
                                   If token.IsCancellationRequested Then
                                       Throw New OperationCanceledException(token)
                                   End If

                                   ax += 1
                                   Dim colonPosition As Integer = line.IndexOf(":"c)
                                   If colonPosition > 0 Then
                                       Dim speaker As String = line.Substring(0, colonPosition).Trim()
                                       Dim dialog As String = line.Substring(colonPosition + 1).Trim()

                                       Dim WAname As String = ""
                                       Dim currentSender As String = ""
                                       Dim currentReceiver As String = ""
                                       Dim logMessage As String = ""

                                       Dim jsdata As New JObject
                                       Dim jsdata1 As New JObject
                                       Dim jsArr As New JArray

                                       If ax Mod 2 = 0 Then
                                           WAname = Waname2
                                           currentSender = WAsender2
                                           currentReceiver = WAsender1
                                           logMessage = $"Pg:{WAsender1.Substring(5)} Pn:{WAsender2.Substring(5)} Dialog:{dialog}"
                                       Else
                                           WAname = Waname1
                                           currentSender = WAsender1
                                           currentReceiver = WAsender2
                                           logMessage = $"Pg:{WAsender2.Substring(5)} Pn:{WAsender1.Substring(5)} Dialog:{dialog}"
                                       End If

                                       jsdata.Add("tonum", currentReceiver)
                                       jsdata.Add("tsender", currentSender)
                                       jsdata.Add("name", WAname)
                                       jsdata.Add("text", dialog)
                                       jsdata.Add("metCall", "wascanqr")
                                       jsdata.Add("func", "OnConversation")
                                       jsArr.Add(jsdata)
                                       jsdata1.Add("body", jsArr)

                                       Me.Invoke(Sub()
                                                     Me.lstLog.Items.Add(logMessage)
                                                     Me.lstLog.SelectedIndex = Me.lstLog.Items.Count - 1
                                                 End Sub)

                                       ' Delay
                                       For i = 1 To 250 ' total 25 detik
                                           If token.IsCancellationRequested Then
                                               Return
                                           End If
                                           System.Threading.Thread.Sleep(100) ' delay 100ms
                                       Next

                                       Me.Invoke(Sub()
                                                     RaiseEvent SendDataJson(Me, New ClassData(jsdata1.ToString))
                                                 End Sub)
                                   End If
                               Next
                           Next
                       End Sub)
    End Function

    Private Sub BtnCreate_Click(sender As Object, e As EventArgs) Handles BtnCreate.Click
        LoadWarmer()
    End Sub

    Private Sub OnReceiveData(sender As Object, e As ClassData)
        Dim msg = e.Data
        Dim DPar = jsonpa.Json2aray(msg)
        Dim seassionId As String = DPar("sessionId")
        Dim state As String = DPar("state")

        For Each control As UCWarmer In PnlogActivty.Controls.OfType(Of UCWarmer)()
            Dim ssId = control.CmNumber1.Text
            Dim ssId1 = control.CmNumber2.Text

            If (ssId = seassionId) Then
                control.CmNumber1.Tag = state
            ElseIf (ssId1 = seassionId) Then
                control.CmNumber2.Tag = state
            End If

        Next
    End Sub

    Private Sub BtnStopCall_Click(sender As Object, e As EventArgs) Handles BtnStopCall.Click
        If cts IsNot Nothing Then
            cts.Cancel()
        End If
        PnlogActivty.Controls.Clear()
        lstLog.Controls.Clear()

    End Sub
End Class