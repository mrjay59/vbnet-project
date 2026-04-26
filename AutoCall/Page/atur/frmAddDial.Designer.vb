<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmAddDial
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddDial))
        Me.LblHeader = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TotApk = New System.Windows.Forms.NumericUpDown()
        Me.BtnAdd = New System.Windows.Forms.Button()
        Me.LblNotif = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ComFrNumber = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ViewTabel = New System.Windows.Forms.DataGridView()
        Me.ViewTabel0 = New System.Windows.Forms.DataGridView()
        Me.namesip = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.prefixn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.totsip_n = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnDelete = New System.Windows.Forms.Button()
        Me.Pathexe = New AutoCall.UCformtext()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.BtnLink = New System.Windows.Forms.Button()
        CType(Me.TotApk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ViewTabel0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblHeader
        '
        Me.LblHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeader.ForeColor = System.Drawing.Color.White
        Me.LblHeader.Location = New System.Drawing.Point(21, 17)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(267, 30)
        Me.LblHeader.TabIndex = 139
        Me.LblHeader.Text = "Tambahkan Aplikasi SIP Local"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 13)
        Me.Label5.TabIndex = 140
        Me.Label5.Text = "Duplikat Apk SIP"
        '
        'TotApk
        '
        Me.TotApk.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotApk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotApk.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotApk.ForeColor = System.Drawing.Color.White
        Me.TotApk.Location = New System.Drawing.Point(15, 212)
        Me.TotApk.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.TotApk.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TotApk.Name = "TotApk"
        Me.TotApk.ReadOnly = True
        Me.TotApk.Size = New System.Drawing.Size(91, 29)
        Me.TotApk.TabIndex = 141
        Me.TotApk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotApk.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'BtnAdd
        '
        Me.BtnAdd.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnAdd.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdd.FlatAppearance.BorderSize = 0
        Me.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdd.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdd.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAdd.Location = New System.Drawing.Point(234, 205)
        Me.BtnAdd.Name = "BtnAdd"
        Me.BtnAdd.Size = New System.Drawing.Size(113, 35)
        Me.BtnAdd.TabIndex = 142
        Me.BtnAdd.Text = "Tambahkan"
        Me.BtnAdd.UseVisualStyleBackColor = False
        '
        'LblNotif
        '
        Me.LblNotif.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNotif.ForeColor = System.Drawing.Color.White
        Me.LblNotif.Location = New System.Drawing.Point(8, 293)
        Me.LblNotif.Name = "LblNotif"
        Me.LblNotif.Size = New System.Drawing.Size(354, 18)
        Me.LblNotif.TabIndex = 181
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'ComFrNumber
        '
        Me.ComFrNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComFrNumber.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComFrNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComFrNumber.ForeColor = System.Drawing.Color.White
        Me.ComFrNumber.FormattingEnabled = True
        Me.ComFrNumber.Items.AddRange(New Object() {"Blank", "062", "62", "0"})
        Me.ComFrNumber.Location = New System.Drawing.Point(138, 212)
        Me.ComFrNumber.Name = "ComFrNumber"
        Me.ComFrNumber.Size = New System.Drawing.Size(79, 28)
        Me.ComFrNumber.TabIndex = 183
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(135, 193)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 184
        Me.Label1.Text = "Prefix Dial"
        '
        'ViewTabel
        '
        Me.ViewTabel.AllowUserToAddRows = False
        Me.ViewTabel.AllowUserToDeleteRows = False
        Me.ViewTabel.AllowUserToResizeColumns = False
        Me.ViewTabel.AllowUserToResizeRows = False
        Me.ViewTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ViewTabel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ViewTabel.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.ViewTabel.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ViewTabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.DefaultCellStyle = DataGridViewCellStyle2
        Me.ViewTabel.EnableHeadersVisualStyles = False
        Me.ViewTabel.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel.Location = New System.Drawing.Point(3, 181)
        Me.ViewTabel.Name = "ViewTabel"
        Me.ViewTabel.ReadOnly = True
        Me.ViewTabel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ViewTabel.RowHeadersVisible = False
        Me.ViewTabel.RowHeadersWidth = 40
        Me.ViewTabel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewTabel.RowTemplate.Height = 20
        Me.ViewTabel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ViewTabel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ViewTabel.ShowCellToolTips = False
        Me.ViewTabel.Size = New System.Drawing.Size(547, 316)
        Me.ViewTabel.TabIndex = 186
        '
        'ViewTabel0
        '
        Me.ViewTabel0.AllowUserToAddRows = False
        Me.ViewTabel0.AllowUserToDeleteRows = False
        Me.ViewTabel0.AllowUserToResizeColumns = False
        Me.ViewTabel0.AllowUserToResizeRows = False
        Me.ViewTabel0.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel0.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel0.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ViewTabel0.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ViewTabel0.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.ViewTabel0.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel0.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.ViewTabel0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ViewTabel0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.namesip, Me.prefixn, Me.totsip_n})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel0.DefaultCellStyle = DataGridViewCellStyle5
        Me.ViewTabel0.EnableHeadersVisualStyles = False
        Me.ViewTabel0.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel0.Location = New System.Drawing.Point(3, 47)
        Me.ViewTabel0.Name = "ViewTabel0"
        Me.ViewTabel0.ReadOnly = True
        Me.ViewTabel0.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel0.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.ViewTabel0.RowHeadersVisible = False
        Me.ViewTabel0.RowHeadersWidth = 40
        Me.ViewTabel0.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ViewTabel0.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ViewTabel0.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewTabel0.RowTemplate.Height = 20
        Me.ViewTabel0.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel0.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ViewTabel0.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ViewTabel0.ShowCellToolTips = False
        Me.ViewTabel0.Size = New System.Drawing.Size(547, 86)
        Me.ViewTabel0.TabIndex = 187
        '
        'namesip
        '
        Me.namesip.HeaderText = "Nama SIP"
        Me.namesip.Name = "namesip"
        Me.namesip.ReadOnly = True
        Me.namesip.Width = 76
        '
        'prefixn
        '
        Me.prefixn.HeaderText = "prefix"
        Me.prefixn.Name = "prefixn"
        Me.prefixn.ReadOnly = True
        Me.prefixn.Width = 59
        '
        'totsip_n
        '
        Me.totsip_n.HeaderText = "Total SIP"
        Me.totsip_n.Name = "totsip_n"
        Me.totsip_n.ReadOnly = True
        Me.totsip_n.Width = 71
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(3, 343)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(359, 175)
        Me.Panel2.TabIndex = 188
        '
        'Label12
        '
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(9, 56)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(335, 110)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = "Untuk Isi Form Ini " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1. Siapkan Akun SIP beserta Aplikasi SIP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. pilih folder kl" &
    "ik icon tersebut cari alamat apk SIP" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. Duplikat isi 10 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. Pilih Prefix Dial " &
    "yang digunakan " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5. lalu Tambahkan"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(359, 41)
        Me.Panel3.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(5, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 23)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "User Guide"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.ViewTabel0)
        Me.Panel1.Controls.Add(Me.ViewTabel)
        Me.Panel1.Location = New System.Drawing.Point(368, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(560, 506)
        Me.Panel1.TabIndex = 189
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.BtnDelete)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(560, 41)
        Me.Panel4.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(5, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 23)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "List Multi SIP"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnDelete
        '
        Me.BtnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnDelete.FlatAppearance.BorderSize = 0
        Me.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnDelete.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnDelete.Image = CType(resources.GetObject("BtnDelete.Image"), System.Drawing.Image)
        Me.BtnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnDelete.Location = New System.Drawing.Point(425, 5)
        Me.BtnDelete.Name = "BtnDelete"
        Me.BtnDelete.Size = New System.Drawing.Size(132, 32)
        Me.BtnDelete.TabIndex = 185
        Me.BtnDelete.Text = "Delete All SIP"
        Me.BtnDelete.UseVisualStyleBackColor = False
        '
        'Pathexe
        '
        Me.Pathexe.BackColor = System.Drawing.Color.Transparent
        Me.Pathexe.Location = New System.Drawing.Point(-1, 87)
        Me.Pathexe.Name = "Pathexe"
        Me.Pathexe.Size = New System.Drawing.Size(334, 62)
        Me.Pathexe.TabIndex = 111
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Panel10.Location = New System.Drawing.Point(9, 51)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(350, 2)
        Me.Panel10.TabIndex = 231
        '
        'BtnLink
        '
        Me.BtnLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLink.Image = CType(resources.GetObject("BtnLink.Image"), System.Drawing.Image)
        Me.BtnLink.Location = New System.Drawing.Point(315, 112)
        Me.BtnLink.Name = "BtnLink"
        Me.BtnLink.Size = New System.Drawing.Size(32, 32)
        Me.BtnLink.TabIndex = 112
        Me.BtnLink.UseVisualStyleBackColor = True
        '
        'frmAddDial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(940, 530)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComFrNumber)
        Me.Controls.Add(Me.LblNotif)
        Me.Controls.Add(Me.BtnAdd)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TotApk)
        Me.Controls.Add(Me.LblHeader)
        Me.Controls.Add(Me.BtnLink)
        Me.Controls.Add(Me.Pathexe)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAddDial"
        Me.Text = "frmAddDial"
        CType(Me.TotApk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ViewTabel0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Pathexe As UCformtext
    Friend WithEvents BtnLink As Button
    Friend WithEvents LblHeader As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents TotApk As NumericUpDown
    Friend WithEvents BtnAdd As Button
    Friend WithEvents LblNotif As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ComFrNumber As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnDelete As Button
    Friend WithEvents ViewTabel As DataGridView
    Friend WithEvents ViewTabel0 As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents namesip As DataGridViewTextBoxColumn
    Friend WithEvents prefixn As DataGridViewTextBoxColumn
    Friend WithEvents totsip_n As DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel10 As Panel
End Class
