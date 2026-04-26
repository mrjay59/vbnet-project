Public Class PgLoading
    Private dbConn As New ClassConnect
    Private dbJson As New ClassJson
    Private mrjay59 As New mrjay59

    Private Sub Timer_Tick(sender As Object, e As EventArgs) Handles Timer.Tick
        Try
            Loading.Width += 10
            If Loading.Width >= 289 Then
                Timer.Stop()
                frmLayer1.Show()
                Me.TopLevel = False
                Me.Hide()
                ' Me.Close()
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan! " & ex.Message)
        End Try
    End Sub

    Private Async Sub frmLoading_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Try
        '    Timer.Start()
        'Catch ex As Exception
        '    MsgBox("Terjadi kesalahan! " & ex.Message)
        'End Try

        Try
            Loading.Width = 0

            ' animasi jalan
            Dim taskAnim = Task.Run(Sub()
                                        For i = 1 To 30
                                            Invoke(Sub() Loading.Width += 10)
                                            Threading.Thread.Sleep(50)
                                        Next
                                    End Sub)

            ' cek session
            Dim isOK As Boolean = Await mrjay59.CheckSessionGlobal()

            Await taskAnim

            If isOK = False Then

                Form1.BukaMenu("home", sender, e)
                Form1.Show()
                '  Me.TopLevel = False

            End If

            Me.Hide()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Startimer()
        Timer.Start()
        Loading.Width = 0
    End Sub
End Class