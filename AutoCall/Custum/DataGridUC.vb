Public Class DataGridUC
    Inherits UserControl

    Private WithEvents scrollPanel As New Panel()
    Private WithEvents headerPanel As New Panel()
    Private dataPanel As New Panel()
    Private columnHeaders As New List(Of Label)()
    Private rows As New List(Of List(Of Control))()
    Private columnWidths As New List(Of Integer)()

    Public Sub New()
        ' Setup dasar
        Me.DoubleBuffered = True
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Size = New Size(600, 400)

        ' Setup scroll panel
        scrollPanel.Dock = DockStyle.Fill
        scrollPanel.AutoScroll = True
        Me.Controls.Add(scrollPanel)

        ' Setup header
        headerPanel.BackColor = Color.SteelBlue
        headerPanel.ForeColor = Color.White
        headerPanel.Height = 30
        headerPanel.Dock = DockStyle.Top
        scrollPanel.Controls.Add(headerPanel)

        ' Setup data panel
        dataPanel.Top = headerPanel.Bottom
        dataPanel.Left = 0
        dataPanel.Width = scrollPanel.Width
        scrollPanel.Controls.Add(dataPanel)
    End Sub

    Public Sub SetColumns(ParamArray columns As String())
        ' Clear existing headers
        headerPanel.Controls.Clear()
        columnHeaders.Clear()
        columnWidths.Clear()

        ' Hitung lebar kolom
        Dim totalWidth As Integer = 0
        For Each col In columns
            Dim width As Integer = TextRenderer.MeasureText(col, New Font("Segoe UI", 10, FontStyle.Bold)).Width + 20
            columnWidths.Add(width)
            totalWidth += width
        Next

        ' Buat header kolom
        Dim leftPos As Integer = 0
        For i As Integer = 0 To columns.Length - 1
            Dim lbl As New Label()
            lbl.Text = columns(i)
            lbl.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Size = New Size(columnWidths(i), headerPanel.Height)
            lbl.Location = New Point(leftPos, 0)
            headerPanel.Controls.Add(lbl)
            columnHeaders.Add(lbl)
            leftPos += columnWidths(i)
        Next

        ' Atur lebar scroll panel
        headerPanel.Width = totalWidth
        dataPanel.Width = totalWidth
    End Sub


    Public Sub AddRow(ParamArray values As String())
        ' Validasi
        If values.Length <> columnHeaders.Count Then
            Throw New ArgumentException("Jumlah nilai tidak sesuai dengan jumlah kolom")
        End If

        ' Buat row baru
        Dim newRow As New List(Of Control)
        Dim topPos As Integer = rows.Count * 30
        Dim leftPos As Integer = 0

        For i As Integer = 0 To values.Length - 1
            Dim cell As New Label()
            cell.Text = values(i)
            cell.Font = New Font("Segoe UI", 9)
            cell.BorderStyle = BorderStyle.FixedSingle
            cell.Size = New Size(columnWidths(i), 30)
            cell.Location = New Point(leftPos, topPos)
            cell.TextAlign = ContentAlignment.MiddleLeft
            cell.Tag = rows.Count ' Simpan index row

            ' Warna berselang-seling
            If rows.Count Mod 2 = 0 Then
                cell.BackColor = Color.White
            Else
                cell.BackColor = Color.FromArgb(240, 240, 240)
            End If

            dataPanel.Controls.Add(cell)
            newRow.Add(cell)
            leftPos += columnWidths(i)
        Next

        rows.Add(newRow)
        dataPanel.Height = rows.Count * 30
    End Sub

    'Private Sub HeaderClick(sender As Object, e As EventArgs) Handles headerPanel.ControlAdded
    '    Dim clickedHeader = CType(sender, Label)
    '    Dim columnIndex = columnHeaders.IndexOf(clickedHeader)

    '    ' Sort data berdasarkan kolom
    '    Dim sortedRows = rows.OrderBy(Function(r) CType(r(columnIndex), Label).Text).ToList()

    '    ' Update tampilan
    '    For i As Integer = 0 To sortedRows.Count - 1
    '        For j As Integer = 0 To sortedRows(i).Count - 1
    '            sortedRows(i)(j).Top = i * 30
    '        Next
    '    Next

    '    rows = sortedRows
    'End Sub

    Private Sub DataGridUC_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        scrollPanel.Width = Me.Width - 2 ' Adjust for border
        scrollPanel.Height = Me.Height - 2
        dataPanel.Width = headerPanel.Width
    End Sub

    Private columnResizing As Boolean = False
    Private resizingColumnIndex As Integer = -1

    Private Sub HeaderPanel_MouseDown(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseDown
        ' Cek jika mouse di area resize (5px dari kanan header)
        For i As Integer = 0 To columnHeaders.Count - 1
            Dim headerRight = columnHeaders(i).Right
            If Math.Abs(e.X - headerRight) < 5 Then
                columnResizing = True
                resizingColumnIndex = i
                Exit For
            End If
        Next
    End Sub

    Private Sub HeaderPanel_MouseMove(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseMove
        If columnResizing Then
            Dim newWidth = e.X - columnHeaders(resizingColumnIndex).Left
            If newWidth > 50 Then ' Minimum width
                columnWidths(resizingColumnIndex) = newWidth
                columnHeaders(resizingColumnIndex).Width = newWidth
                UpdateLayout()
            End If
        End If
    End Sub

    Private Sub HeaderPanel_MouseUp(sender As Object, e As MouseEventArgs) Handles headerPanel.MouseUp
        columnResizing = False
    End Sub

    Private Sub UpdateLayout()
        ' Update posisi semua header
        Dim leftPos As Integer = 0
        For i As Integer = 0 To columnHeaders.Count - 1
            columnHeaders(i).Left = leftPos
            leftPos += columnWidths(i)
        Next
        headerPanel.Width = leftPos
        dataPanel.Width = leftPos

        ' Update posisi semua cell
        For Each row In rows
            leftPos = 0
            For i As Integer = 0 To row.Count - 1
                row(i).Left = leftPos
                row(i).Width = columnWidths(i)
                leftPos += columnWidths(i)
            Next
        Next


    End Sub
End Class