Imports System.IO
Imports Newtonsoft.Json

Public Class FrmReqToken
    Private dbConn As New ClassConnect
    Private Ap_mrjay59 As New mrjay59

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles BtnClose.Click

        Form1.BtnHome.BackColor = Color.Transparent
        Form1.BtnPaket.BackColor = Color.FromArgb(60, 60, 60)


        Form1.PanelView.Controls.Clear()
        Try
            Dim page As New frmApk
            Form1.PanelView.Controls.Clear()
            page.TopLevel = False
            page.Dock = DockStyle.Fill
            'page.BukaMenu("dialler", sender, e)
            Form1.PanelView.Controls.Add(page)
            page.Show()

        Catch ex As Exception

        End Try


    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles BtnDownload.Click
        Dim startpath As String = Path.GetDirectoryName(Application.ExecutablePath)


        Dim cmb As String = startpath & "\Petunjuk Autocall.pdf"
        If (File.Exists(cmb)) Then
            Process.Start(cmb)
        End If
    End Sub
End Class