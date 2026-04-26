Imports Newtonsoft.Json.Linq

Public Class DataTableControl
    Inherits UserControl

    ' Komponen utama
    Private WithEvents pnlHeader As New Panel()
    Private pnlRows As New FlowLayoutPanel()
    Private scrollPanel As New Panel()
    Private WithEvents scrollBar As New VScrollBar()

    ' Style properties
    Public Property HeaderBackColor As Color = Color.SteelBlue
    Public Property HeaderForeColor As Color = Color.White
    Public Property RowBackColor As Color = Color.White
    Public Property AlternateRowColor As Color = Color.Lavender
    Public Property RowForeColor As Color = Color.Black

    'Public Event DataSelected As EventHandler(Of ClassData

    Public Sub New()
        InitializeComponents()
        ApplyStyling()
    End Sub

    Private Sub InitializeComponents()

        ' Setup scroll panel
        scrollPanel.Dock = DockStyle.Fill
        scrollPanel.AutoScroll = False
        scrollPanel.Controls.Add(pnlRows)
        scrollPanel.AutoScroll = True ' Aktifkan scroll setelah kontrol ditambahkan

        ' Setup rows panel
        pnlRows.FlowDirection = FlowDirection.TopDown
        pnlRows.WrapContents = False
        pnlRows.AutoSize = True
        pnlRows.AutoSizeMode = AutoSizeMode.GrowAndShrink


        ' Setup header
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 25

        ' Add controls
        Me.Controls.Add(scrollPanel)
        Me.Controls.Add(pnlHeader)

        ' Default size
        Me.Size = New Size(600, 300)
    End Sub

    Private Sub ApplyStyling()
        ' Header style
        pnlHeader.BackColor = HeaderBackColor
        pnlHeader.ForeColor = HeaderForeColor

        ' Border style
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.BackColor = Color.FromArgb(240, 240, 240)

        ' Scrollbar style
        scrollBar.Dock = DockStyle.Right
        scrollBar.Width = 17
    End Sub

    ' Method untuk menambahkan kolom header
    Public Sub AddHeader(columns As Dictionary(Of String, Integer))
        pnlHeader.Controls.Clear()

        Dim totalWidth = Me.Width - SystemInformation.VerticalScrollBarWidth
        Dim xPos As Integer = 0

        For Each col In columns
            Dim lbl As New Label()
            lbl.Text = col.Key
            lbl.Width = CInt(totalWidth * col.Value / 100)
            lbl.Left = xPos
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.Font = New Font("Segoe UI", 9, FontStyle.Bold)
            lbl.ForeColor = HeaderForeColor
            lbl.Height = pnlHeader.Height

            ' Add border
            lbl.BorderStyle = BorderStyle.FixedSingle
            lbl.Padding = New Padding(2, 0, 0, 0)

            pnlHeader.Controls.Add(lbl)
            xPos += lbl.Width
        Next
    End Sub

    ' Method untuk menambahkan row data
    '    Dim rowData As New List(Of KeyValuePair(Of String, Object)) From {
    '    New KeyValuePair(Of String, Object)("Zaenul", "628123456789"),
    '    New KeyValuePair(Of String, Object)("Admin", 1),
    '    New KeyValuePair(Of String, Object)("Online", True)
    '}
    'dtControl.AddRow(rowData, withCheckbox:=True)
    Public Sub AddRow(values As List(Of KeyValuePair(Of String, Object)), Optional buttons As List(Of String) = Nothing, Optional withCheckbox As Boolean = False)
        Dim rowPanel As New Panel()
        rowPanel.Width = pnlHeader.Width
        rowPanel.Height = 35
        rowPanel.Margin = New Padding(0, 0, 0, 1)

        ' Warna baris bergantian
        If pnlRows.Controls.Count Mod 2 = 0 Then
            rowPanel.BackColor = RowBackColor
        Else
            rowPanel.BackColor = AlternateRowColor
        End If

        Dim xPos As Integer = 0

        If withCheckbox Then
            Dim chk As New CheckBox()
            chk.Width = 20
            chk.Height = rowPanel.Height
            chk.Top = 0
            chk.Left = xPos
            chk.TextAlign = ContentAlignment.MiddleCenter


            ' Tambahkan handler
            AddHandler chk.CheckedChanged, Sub(s, eArgs)
                                               Dim cb = DirectCast(s, CheckBox)
                                               Dim panel = DirectCast(cb.Parent, Panel)
                                               Dim idx = pnlRows.Controls.IndexOf(panel)

                                               ' Ganti warna
                                               If cb.Checked Then
                                                   panel.BackColor = Color.LightCoral
                                               Else
                                                   panel.BackColor = If(idx Mod 2 = 0, RowBackColor, AlternateRowColor)
                                               End If

                                               ' Ambil data dari label
                                               Dim rowData As New List(Of String)
                                               For Each lbl In panel.Controls.OfType(Of Label)()
                                                   rowData.Add(lbl.Text)
                                               Next

                                               ' Raise event
                                               'RaiseEvent RowCheckedChanged(Me, New RowCheckedEventArgs(idx, cb.Checked, rowData))
                                           End Sub

            rowPanel.Controls.Add(chk)
            xPos += chk.Width
        End If

        For i = 0 To values.Count - 1
            Dim displayText = values(i).Key
            Dim actualValue = values(i).Value

            Dim lbl As New Label()
            lbl.Text = displayText
            lbl.Tag = actualValue ' ← Simpan data asli
            lbl.AutoSize = False
            lbl.Height = rowPanel.Height
            lbl.Width = pnlHeader.Controls(i).Width
            lbl.Left = xPos
            lbl.TextAlign = ContentAlignment.MiddleLeft
            lbl.ForeColor = RowForeColor
            lbl.Font = New Font("Segoe UI", 9)
            lbl.Padding = New Padding(5, 0, 0, 0)

            rowPanel.Controls.Add(lbl)
            xPos += lbl.Width
        Next

        ' Tambahkan tombol opsi jika ada
        If buttons IsNot Nothing Then
            Dim btnWidth As Integer = 70
            Dim btnSpacing As Integer = 5

            For Each btnText In buttons
                Dim btn As New Button()
                btn.Text = btnText
                btn.Width = btnWidth
                btn.Height = 25
                btn.Top = (rowPanel.Height - btn.Height) \ 2
                btn.Left = xPos + btnSpacing
                btn.FlatStyle = FlatStyle.Flat
                btn.BackColor = Color.WhiteSmoke
                btn.ForeColor = Color.DimGray
                btn.Font = New Font("Segoe UI", 8)
                btn.Cursor = Cursors.Hand

                ' Style flat button
                btn.FlatAppearance.BorderColor = Color.Silver
                btn.FlatAppearance.BorderSize = 1

                ' Event handler dinamis
                AddHandler btn.Click, AddressOf RowButtonClick

                rowPanel.Controls.Add(btn)
                xPos += btn.Width + btnSpacing
            Next
        End If

        pnlRows.Controls.Add(rowPanel)

        pnlRows.PerformLayout()
        scrollPanel.Invalidate()
    End Sub

    ' Event handler untuk tombol row
    Private Sub RowButtonClick(sender As Object, e As EventArgs)
        Dim btn = DirectCast(sender, Button)
        Dim rowPanel = DirectCast(btn.Parent, Panel)
        Dim rowIndex = pnlRows.Controls.IndexOf(rowPanel)

        ' Raise custom event
        RaiseEvent RowButtonClicked(Me, New RowButtonEventArgs(rowIndex, btn.Text))
    End Sub

    ' Custom event untuk button click
    Public Event RowButtonClicked As EventHandler(Of RowButtonEventArgs)

    ' Class untuk event args
    Public Class RowButtonEventArgs
        Inherits EventArgs

        Public Property RowIndex As Integer
        Public Property ButtonText As String

        Public Sub New(index As Integer, text As String)
            RowIndex = index
            ButtonText = text
        End Sub
    End Class

    Public Sub RemoveRow(rowIndex As Integer)
        If rowIndex >= 0 AndAlso rowIndex < pnlRows.Controls.Count Then
            pnlRows.Controls.RemoveAt(rowIndex)

            ' Perbarui warna baris setelah penghapusan
            For i As Integer = 0 To pnlRows.Controls.Count - 1
                Dim row = DirectCast(pnlRows.Controls(i), Panel)
                row.BackColor = If(i Mod 2 = 0, RowBackColor, AlternateRowColor)
            Next
        End If
    End Sub

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        MyBase.OnSizeChanged(e)
        UpdateLayout()
    End Sub

    Private Sub UpdateLayout()



        scrollPanel.Top = pnlHeader.Bottom
        scrollPanel.Width = Me.Width
        scrollPanel.Height = Me.Height - scrollPanel.Top

        ' Update row width
        For Each row As Panel In pnlRows.Controls
            row.Width = pnlHeader.Width
        Next

        ' Update posisi tombol
        For Each row As Panel In pnlRows.Controls
            Dim lastLabel = row.Controls.OfType(Of Label)().LastOrDefault()
            Dim xPos = If(lastLabel Is Nothing, 0, lastLabel.Right)

            For Each btn In row.Controls.OfType(Of Button)()
                btn.Left = xPos + 5
                xPos = btn.Right
            Next
        Next
    End Sub

    Public Function GetCellValue(rowIndex As Integer, columnIndex As Integer) As String
        If rowIndex < 0 OrElse rowIndex >= pnlRows.Controls.Count Then
            Throw New ArgumentOutOfRangeException("Row index out of range.")
        End If

        Dim row = DirectCast(pnlRows.Controls(rowIndex), Panel)
        Dim labels = row.Controls.OfType(Of Label)().ToList()

        If columnIndex < 0 OrElse columnIndex >= labels.Count Then
            Throw New ArgumentOutOfRangeException("Column index out of range.")
        End If

        Return labels(columnIndex).Text
    End Function

    Public Function GetRowData(rowIndex As Integer) As List(Of String)
        If rowIndex < 0 OrElse rowIndex >= pnlRows.Controls.Count Then
            Throw New ArgumentOutOfRangeException("Row index out of range.")
        End If

        Dim row = DirectCast(pnlRows.Controls(rowIndex), Panel)
        Return row.Controls.OfType(Of Label)().Select(Function(lbl) lbl.Text).ToList()
    End Function

    'Dim nomorWA = dtControl.GetCellTag(0, 0).ToString()
    Public Function GetCellTag(rowIndex As Integer, columnIndex As Integer) As Object
        If rowIndex < 0 OrElse rowIndex >= pnlRows.Controls.Count Then Return Nothing

        Dim row = DirectCast(pnlRows.Controls(rowIndex), Panel)
        Dim labels = row.Controls.OfType(Of Label)().ToList()

        If columnIndex < 0 OrElse columnIndex >= labels.Count Then Return Nothing

        Return labels(columnIndex).Tag
    End Function

End Class