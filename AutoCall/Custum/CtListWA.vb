Imports Newtonsoft.Json.Linq

Public Class CtListWA
    Public Event DataSelected As EventHandler(Of ClassData)

    Private Sub Chk_CheckedChanged(sender As Object, e As EventArgs) Handles Chk.CheckedChanged
        Dim chetru = Chk.Checked
        Dim NaDev = lbDevice.Text?.Trim
        Dim func = lbDevice.Tag?.ToString
        Dim Naplatform = lbplatform.Text?.Trim
        Dim kodecontr = lbplatform.Tag?.ToString
        Dim NoWA = LbNomorWA.Text?.Trim
        Dim Numkey = LbNomorWA?.Tag?.ToString
        Dim NaLog As String = LbLogin.Text?.Trim.Replace("scan:", "")
        Dim NaUse = LbUse.Text?.Trim.Replace("Use:", "")

        Dim pathEx = LbLogin.Tag?.ToString
        'If (NaUse = "YA") Then
        '    MsgBox("WhatsApp sudah digunakan")
        '    Return
        'End If

        'If (NoWA = "") Then
        '    MsgBox("Tidak ada No Sender Harap rescan")
        '    Return
        'End If


        Dim NeData As New JObject
        If (chetru = False) Then
            Me.BackColor = Color.FromArgb(41, 68, 77)
            '  Chkedwa.Checked = True
            NeData.Add("NaDev", NaDev.ToString)
            NeData.Add("Naplatform", Naplatform.ToString)
            NeData.Add("NoWA", NoWA.ToString)
            NeData.Add("NaLog", NaLog.ToString)
            NeData.Add("path", pathEx.ToString)
            NeData.Add("prefix", kodecontr.ToString)
            NeData.Add("chk", False)
            NeData.Add("fun", func.ToString)
            Dim ObjString = NeData.ToString

            ' Raise the event and pass the selected data
            RaiseEvent DataSelected(Me, New ClassData(ObjString))
            ''Console.WriteLine(ObjString)
        End If

        If (chetru = True) Then
            Me.BackColor = Color.FromArgb(41, 168, 77)
            NeData.Add("NaDev", NaDev.ToString)
            NeData.Add("Naplatform", Naplatform.ToString)
            NeData.Add("NoWA", NoWA.ToString)
            NeData.Add("NaLog", NaLog.ToString)
            NeData.Add("path", pathEx.ToString)
            NeData.Add("prefix", kodecontr.ToString)
            NeData.Add("chk", True)
            NeData.Add("fun", func.ToString)
            Dim ObjString = NeData.ToString

            '  Console.WriteLine(ObjString)
            RaiseEvent DataSelected(Me, New ClassData(ObjString))
            ''  Chkedwa.Checked = False
        End If
    End Sub
End Class
