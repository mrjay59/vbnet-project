Public Class pgNotifikasi

    Private flowPanel As New FlowLayoutPanel()

    'Public Sub New()

    '    'Me.StartPosition = FormStartPosition.CenterScreen

    '    ' Setup FlowLayoutPanel
    '    flowPanel.Dock = DockStyle.Fill
    '    flowPanel.AutoScroll = True
    '    flowPanel.FlowDirection = FlowDirection.TopDown
    '    flowPanel.WrapContents = False
    '    PanelPusat.Controls.Add(flowPanel)

    '    ' Tambahkan notifikasi contoh
    '    TambahNotifikasi("Pembayaran berhasil diproses", DateTime.Now.AddHours(-1))
    '    TambahNotifikasi("Pesanan telah dikirim", DateTime.Now.AddMinutes(-30))
    '    TambahNotifikasi("Promo spesial untuk Anda", DateTime.Now.AddDays(-1))
    '    TambahNotifikasi("Peringatan: Password akan kadaluarsa", DateTime.Now.AddDays(-2))
    '    TambahNotifikasi("Selamat! Anda mendapatkan reward", DateTime.Now.AddHours(-3))
    'End Sub

    Private Sub loadNotif()
        ' Setup FlowLayoutPanel
        flowPanel.Dock = DockStyle.Fill
        flowPanel.AutoScroll = True
        flowPanel.FlowDirection = FlowDirection.TopDown
        flowPanel.WrapContents = False
        PanelPusat.Controls.Add(flowPanel)

        ' Tambahkan notifikasi contoh
        TambahNotifikasi("Pembayaran berhasil diproses", DateTime.Now.AddHours(-1))
        TambahNotifikasi("Pesanan telah dikirim", DateTime.Now.AddMinutes(-30))
        TambahNotifikasi("Promo spesial untuk Anda", DateTime.Now.AddDays(-1))
        TambahNotifikasi("Peringatan: Password akan kadaluarsa", DateTime.Now.AddDays(-2))
        TambahNotifikasi("Selamat! Anda mendapatkan reward", DateTime.Now.AddHours(-3))
    End Sub

    Private Sub pgNotifikasi_Load(sender As Object, e As EventArgs) Handles Me.Load
        loadNotif()
    End Sub

    Private Sub TambahNotifikasi(pesan As String, waktu As DateTime)
        Dim notifPanel As New Panel With {
            .Width = flowPanel.ClientSize.Width - 25,
            .Height = 70,
            .Margin = New Padding(10, 5, 10, 5),
            .BackColor = Color.FromArgb(60, 80, 60),
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' Label Pesan
        Dim lblPesan As New Label With {
            .Text = pesan,
            .Font = New Font("Segoe UI", 10, FontStyle.Regular),
            .Location = New Point(10, 10),
            .ForeColor = Color.White,
            .AutoSize = True,
            .MaximumSize = New Size(notifPanel.Width - 20, 0)
        }

        ' Label Waktu
        Dim lblWaktu As New Label With {
            .Text = GetRelativeTime(waktu),
            .Font = New Font("Segoe UI", 8, FontStyle.Italic),
            .ForeColor = Color.Gray,
            .Location = New Point(10, lblPesan.Bottom + 20),
            .AutoSize = True
        }

        notifPanel.Controls.Add(lblPesan)
        notifPanel.Controls.Add(lblWaktu)
        flowPanel.Controls.Add(notifPanel)
    End Sub

    Private Function GetRelativeTime(waktu As DateTime) As String
        Dim selisih As TimeSpan = DateTime.Now - waktu

        If waktu.Date = DateTime.Today Then
            If selisih.TotalHours >= 1 Then
                Return $"{CInt(selisih.TotalHours)} jam yang lalu"
            ElseIf selisih.TotalMinutes >= 1 Then
                Return $"{CInt(selisih.TotalMinutes)} menit yang lalu"
            Else
                Return "Baru saja"
            End If
        ElseIf waktu.Date = DateTime.Today.AddDays(-1) Then
            Return "Kemarin"
        Else
            Return waktu.ToString("dd/MM/yyyy")
        End If
    End Function

    Private Sub btnclose_Click(sender As Object, e As EventArgs) Handles btnclose.Click
        Me.Close()
    End Sub
End Class