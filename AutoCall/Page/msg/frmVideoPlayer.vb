Imports LibVLCSharp.Shared

Public Class frmVideoPlayer

    Private vlcLib As LibVLC
    Private mediaPlayer As MediaPlayer

    Public Property VideoUrl As String

    Private Sub frmVideoPlayer_Load(
        sender As Object,
        e As EventArgs
    ) Handles MyBase.Load

        Try

            Core.Initialize()

            vlcLib = New LibVLC()

            mediaPlayer = New MediaPlayer(vlcLib)

            VideoView1.MediaPlayer = mediaPlayer

            Dim media As New Media(
                vlcLib,
                New Uri(VideoUrl)
            )

            mediaPlayer.Play(media)

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub frmVideoPlayer_FormClosing(
        sender As Object,
        e As FormClosingEventArgs
    ) Handles Me.FormClosing

        Try

            mediaPlayer?.Stop()
            mediaPlayer?.Dispose()

            vlcLib?.Dispose()

        Catch
        End Try

    End Sub

End Class