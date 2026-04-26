Imports System.Drawing.Drawing2D

Public Class CustomDataTable
    ' Panel untuk header kolom
    Private headerPanel As Panel
    ' Panel untuk data baris
    Private dataPanel As Panel
    ' Scrollbar untuk scrolling
    Private vScrollBar As VScrollBar
    ' Simpan nama kolom
    Private columnNames As List(Of String)

    Public Sub New()
        ' Inisialisasi kontrol
        Me.InitializeComponent()

        columnNames = New List(Of String)()

        ' Header Panel
        headerPanel = New Panel() With {
            .Dock = DockStyle.Top,
            .Height = 30,
            .BackColor = Color.LightGray
        }
        Me.Controls.Add(headerPanel)

        ' Data Panel
        dataPanel = New Panel() With {
            .Dock = DockStyle.Fill,
            .Height = 30,
            .AutoScroll = False
        }
        Me.Controls.Add(dataPanel)

        ' Vertical ScrollBar
        vScrollBar = New VScrollBar() With {
            .Dock = DockStyle.Right
        }
        Me.Controls.Add(vScrollBar)

        ' Event untuk Scroll
        AddHandler vScrollBar.Scroll, AddressOf OnScrollx
    End Sub

    ' Metode untuk menambahkan kolom
    Public Sub AddColumn(columnName As String)
        columnNames.Add(columnName)
        RefreshHeader()
    End Sub

    ' Refresh header untuk menggambar ulang kolom
    Private Sub RefreshHeader()
        headerPanel.Controls.Clear()

        Dim colWidth As Integer = headerPanel.Width / columnNames.Count
        For i As Integer = 0 To columnNames.Count - 1

            Dim lbl As New Label() With {
                .Text = columnNames(i),
                .Width = colWidth,
                .Height = headerPanel.Height,
                .Left = i * colWidth,
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle,
                .BackColor = Color.FromArgb(80, 60, 51)
            }
            headerPanel.Controls.Add(lbl)
        Next
    End Sub

    ' Metode untuk menambahkan baris
    Public Sub AddRow(values As List(Of String))
        Dim rowPanel As New Panel() With {
            .Height = 20,
            .Dock = DockStyle.Top,
            .BackColor = Color.Transparent
        }

        Dim colWidth As Integer = headerPanel.Width / columnNames.Count
        For i As Integer = 0 To values.Count - 1
            Dim lbl As New Label() With {
                .Text = values(i),
                .Width = colWidth,
                .Height = rowPanel.Height,
                .Left = i * colWidth,
                .TextAlign = ContentAlignment.MiddleCenter,
                .BorderStyle = BorderStyle.FixedSingle
            }
            rowPanel.Controls.Add(lbl)
        Next

        dataPanel.Controls.Add(rowPanel)

    End Sub

    ' Event untuk menangani scrolling
    Private Sub OnScrollx(sender As Object, e As ScrollEventArgs)
        dataPanel.AutoScrollPosition = New Point(0, vScrollBar.Value)
    End Sub

    Private Sub CustomDataTable_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim width = Me.Width
        Dim Height = Me.Height
        Dim rect As New Rectangle(0, 0, width, Height)
        Dim path As New GraphicsPath()
        Dim cornerRadius As Integer = 10 ' Adjust this value to change the roundness of the corners

        path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90)
        path.AddArc(rect.Width - cornerRadius, rect.Height - cornerRadius, cornerRadius, cornerRadius, 0, 90)
        path.AddArc(rect.X, rect.Height - cornerRadius, cornerRadius, cornerRadius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)
    End Sub
End Class
