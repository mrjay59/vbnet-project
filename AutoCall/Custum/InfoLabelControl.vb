Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq

Public Class InfoLabelControl
    Inherits UserControl

    Public chkPilih As CheckBox
    Public lblJudul As Label
    Public lblIsiText As Label
    Private tooltip As ToolTip
    Private WithEvents btnHapus As Button
    Public Event HapusDiklik As EventHandler(Of ClassData)
    Public Event CheckedStatusChanged As EventHandler(Of ClassData)

    Private IsiText As String = String.Empty

    Public Sub New()
        InitializeComponents()
    End Sub

    Private Sub InitializeComponents()
        Me.Size = New Size(450, 30)
        Me.BackColor = Color.Transparent

        ' Tooltip
        tooltip = New ToolTip With {
            .AutoPopDelay = 10000,
            .InitialDelay = 500,
            .ReshowDelay = 300,
            .IsBalloon = True,
            .ToolTipTitle = "Isi Template",
            .ToolTipIcon = ToolTipIcon.Info,
            .UseFading = True,
            .UseAnimation = True
        }

        ' Checkbox
        chkPilih = New CheckBox With {
            .Location = New Point(5, 7),
            .Size = New Size(15, 15)
        }
        AddHandler chkPilih.CheckedChanged, AddressOf chkPilih_CheckedChanged

        ' Label Judul
        lblJudul = New Label With {
            .AutoSize = True,
            .Font = New Font("Segoe UI", 9, FontStyle.Regular),
            .Location = New Point(25, 7),
            .Text = "Judul:"
        }

        ' Label Isi Text
        lblIsiText = New Label With {
            .AutoSize = False,
            .Font = New Font("Segoe UI", 9),
            .Location = New Point(130, 5),
            .Size = New Size(300, 20),
            .BackColor = Color.Transparent,
            .ForeColor = Color.Black,
            .TextAlign = ContentAlignment.MiddleLeft
        }

        ' Tombol Hapus
        btnHapus = New Button()
        btnHapus.Text = "✕"
        btnHapus.Font = New Font("Segoe UI", 8, FontStyle.Bold)
        btnHapus.Size = New Size(25, 25)
        btnHapus.FlatStyle = FlatStyle.Flat
        btnHapus.FlatAppearance.BorderSize = 0
        btnHapus.BackColor = Color.Transparent
        btnHapus.ForeColor = Color.Red
        btnHapus.Cursor = Cursors.Hand
        btnHapus.Anchor = AnchorStyles.Right
        btnHapus.Location = New Point(Me.Width - btnHapus.Width - 5, (Me.Height - btnHapus.Height) \ 2)
        btnHapus.BringToFront()


        ' Tambahkan ke UserControl
        Me.Controls.Add(btnHapus)
        Me.Controls.Add(chkPilih)
        Me.Controls.Add(lblJudul)
        Me.Controls.Add(lblIsiText)
    End Sub

    Private Sub chkPilih_CheckedChanged(sender As Object, e As EventArgs)
        Dim title = lblJudul.Text
        Dim IsiPesan = IsiText

        Dim ObjO As New JObject
        ObjO.Add("fun", "OnTemp")
        ObjO.Add("title", title)
        ObjO.Add("IsiPesan", IsiPesan)
        ObjO.Add("chk", IsChecked)


        RaiseEvent CheckedStatusChanged(Me, New ClassData(ObjO.ToString))
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim title = lblJudul.Text
        Dim IsiPesan = IsiText

        Dim ObjO As New JObject
        ObjO.Add("fun", "OnTemp")
        ObjO.Add("title", title)
        ObjO.Add("IsiPesan", IsiPesan)
        ObjO.Add("chk", IsChecked)

        RaiseEvent HapusDiklik(Me, New ClassData(ObjO.ToString))
    End Sub



    ''' <summary>
    ''' Menetapkan judul dan isi text (dengan pemotongan dan tooltip).
    ''' </summary>
    Public Sub SetData(judul As String, isiLengkap As String)
        lblJudul.Text = judul
        IsiText = isiLengkap
        If isiLengkap.Length > 40 Then
            lblIsiText.Text = isiLengkap.Substring(0, 40) & "..."
        Else
            lblIsiText.Text = isiLengkap
        End If

        tooltip.SetToolTip(lblIsiText, isiLengkap)
    End Sub

    ''' <summary>
    ''' Ambil status checkbox
    ''' </summary>
    Public Function IsChecked() As Boolean
        Return chkPilih.Checked
    End Function

    ''' <summary>
    ''' Atur status checkbox
    ''' </summary>
    Public Sub SetChecked(status As Boolean)
        chkPilih.Checked = status
    End Sub
End Class
