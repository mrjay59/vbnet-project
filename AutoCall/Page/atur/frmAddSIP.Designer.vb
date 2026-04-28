<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddSIP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAddSIP))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.LblHeader = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ViewTabel0 = New System.Windows.Forms.DataGridView()
        Me.No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDAKUN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Concurrent = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.State = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idlea = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelPusat = New AutoCall.RoundedPanel()
        Me.lbIdle = New AutoCall.UCformtext()
        Me.lbTipeAkun = New AutoCall.UCformtext()
        Me.LblConcurrent = New AutoCall.UCformtext()
        Me.BtnAdding = New System.Windows.Forms.Button()
        Me.LblTglExpire = New AutoCall.UCformtext()
        Me.LblTglCreate = New AutoCall.UCformtext()
        Me.LblAkunId = New AutoCall.UCformtext()
        Me.BtnChecking = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.appkode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.subscribe = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lim_perday = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lim_recall = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pick_tg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idle = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.worker = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.ViewTabel0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelPusat.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Panel10.Location = New System.Drawing.Point(9, 43)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(420, 2)
        Me.Panel10.TabIndex = 233
        '
        'LblHeader
        '
        Me.LblHeader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHeader.ForeColor = System.Drawing.Color.White
        Me.LblHeader.Location = New System.Drawing.Point(21, 9)
        Me.LblHeader.Name = "LblHeader"
        Me.LblHeader.Size = New System.Drawing.Size(267, 30)
        Me.LblHeader.TabIndex = 232
        Me.LblHeader.Text = "Tambahkan Akun SIP Server"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.ViewTabel0)
        Me.Panel1.Location = New System.Drawing.Point(440, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(588, 189)
        Me.Panel1.TabIndex = 245
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(588, 41)
        Me.Panel4.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(14, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(191, 23)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Data Akun SIP Server"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel0.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ViewTabel0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.ViewTabel0.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.No, Me.IDAKUN, Me.Concurrent, Me.State, Me.idlea})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel0.DefaultCellStyle = DataGridViewCellStyle2
        Me.ViewTabel0.EnableHeadersVisualStyles = False
        Me.ViewTabel0.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel0.Location = New System.Drawing.Point(3, 47)
        Me.ViewTabel0.Name = "ViewTabel0"
        Me.ViewTabel0.ReadOnly = True
        Me.ViewTabel0.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel0.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
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
        Me.ViewTabel0.Size = New System.Drawing.Size(571, 139)
        Me.ViewTabel0.TabIndex = 187
        '
        'No
        '
        Me.No.HeaderText = "No"
        Me.No.Name = "No"
        Me.No.ReadOnly = True
        Me.No.Width = 44
        '
        'IDAKUN
        '
        Me.IDAKUN.HeaderText = "AKUN ID"
        Me.IDAKUN.Name = "IDAKUN"
        Me.IDAKUN.ReadOnly = True
        Me.IDAKUN.Width = 72
        '
        'Concurrent
        '
        Me.Concurrent.HeaderText = "Concurrent"
        Me.Concurrent.Name = "Concurrent"
        Me.Concurrent.ReadOnly = True
        Me.Concurrent.Width = 85
        '
        'State
        '
        Me.State.HeaderText = "State"
        Me.State.Name = "State"
        Me.State.ReadOnly = True
        Me.State.Width = 56
        '
        'idlea
        '
        Me.idlea.HeaderText = "IDLE"
        Me.idlea.Name = "idlea"
        Me.idlea.ReadOnly = True
        Me.idlea.Width = 52
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Bodoni MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(10, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(420, 28)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "Step 1 : Input Token"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(13, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 248
        Me.Label7.Text = "Masukin Token :"
        '
        'txtToken
        '
        Me.txtToken.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToken.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtToken.Enabled = False
        Me.txtToken.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToken.ForeColor = System.Drawing.Color.White
        Me.txtToken.Location = New System.Drawing.Point(10, 108)
        Me.txtToken.Multiline = True
        Me.txtToken.Name = "txtToken"
        Me.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtToken.Size = New System.Drawing.Size(424, 59)
        Me.txtToken.TabIndex = 247
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Bodoni MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(9, 203)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(423, 28)
        Me.Label2.TabIndex = 250
        Me.Label2.Text = "Step  2 : Data Akun"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoSizeHeight = False
        Me.PanelPusat.BorderColor = System.Drawing.Color.Gray
        Me.PanelPusat.BorderWidth = 1
        Me.PanelPusat.Controls.Add(Me.lbIdle)
        Me.PanelPusat.Controls.Add(Me.lbTipeAkun)
        Me.PanelPusat.Controls.Add(Me.LblConcurrent)
        Me.PanelPusat.Controls.Add(Me.BtnAdding)
        Me.PanelPusat.Controls.Add(Me.LblTglExpire)
        Me.PanelPusat.Controls.Add(Me.LblTglCreate)
        Me.PanelPusat.Controls.Add(Me.LblAkunId)
        Me.PanelPusat.CornerRadius = 10
        Me.PanelPusat.Location = New System.Drawing.Point(9, 234)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.RoundingStyle = AutoCall.RoundedPanel.RoundStyle.All
        Me.PanelPusat.Size = New System.Drawing.Size(420, 312)
        Me.PanelPusat.TabIndex = 249
        '
        'lbIdle
        '
        Me.lbIdle.BackColor = System.Drawing.Color.Transparent
        Me.lbIdle.Location = New System.Drawing.Point(189, 201)
        Me.lbIdle.Name = "lbIdle"
        Me.lbIdle.Size = New System.Drawing.Size(179, 62)
        Me.lbIdle.TabIndex = 238
        '
        'lbTipeAkun
        '
        Me.lbTipeAkun.BackColor = System.Drawing.Color.Transparent
        Me.lbTipeAkun.Location = New System.Drawing.Point(0, 201)
        Me.lbTipeAkun.Name = "lbTipeAkun"
        Me.lbTipeAkun.Size = New System.Drawing.Size(195, 62)
        Me.lbTipeAkun.TabIndex = 237
        '
        'LblConcurrent
        '
        Me.LblConcurrent.BackColor = System.Drawing.Color.Transparent
        Me.LblConcurrent.Location = New System.Drawing.Point(176, 19)
        Me.LblConcurrent.Name = "LblConcurrent"
        Me.LblConcurrent.Size = New System.Drawing.Size(192, 63)
        Me.LblConcurrent.TabIndex = 236
        '
        'BtnAdding
        '
        Me.BtnAdding.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnAdding.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdding.FlatAppearance.BorderSize = 0
        Me.BtnAdding.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdding.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdding.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAdding.Image = CType(resources.GetObject("BtnAdding.Image"), System.Drawing.Image)
        Me.BtnAdding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdding.Location = New System.Drawing.Point(304, 271)
        Me.BtnAdding.Name = "BtnAdding"
        Me.BtnAdding.Size = New System.Drawing.Size(103, 30)
        Me.BtnAdding.TabIndex = 235
        Me.BtnAdding.Text = "Aktifkan"
        Me.BtnAdding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAdding.UseVisualStyleBackColor = False
        '
        'LblTglExpire
        '
        Me.LblTglExpire.BackColor = System.Drawing.Color.Transparent
        Me.LblTglExpire.Location = New System.Drawing.Point(3, 143)
        Me.LblTglExpire.Name = "LblTglExpire"
        Me.LblTglExpire.Size = New System.Drawing.Size(365, 62)
        Me.LblTglExpire.TabIndex = 115
        '
        'LblTglCreate
        '
        Me.LblTglCreate.BackColor = System.Drawing.Color.Transparent
        Me.LblTglCreate.Location = New System.Drawing.Point(3, 79)
        Me.LblTglCreate.Name = "LblTglCreate"
        Me.LblTglCreate.Size = New System.Drawing.Size(365, 62)
        Me.LblTglCreate.TabIndex = 114
        '
        'LblAkunId
        '
        Me.LblAkunId.BackColor = System.Drawing.Color.Transparent
        Me.LblAkunId.Location = New System.Drawing.Point(4, 20)
        Me.LblAkunId.Name = "LblAkunId"
        Me.LblAkunId.Size = New System.Drawing.Size(191, 62)
        Me.LblAkunId.TabIndex = 112
        '
        'BtnChecking
        '
        Me.BtnChecking.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnChecking.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnChecking.FlatAppearance.BorderSize = 0
        Me.BtnChecking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnChecking.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnChecking.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnChecking.Image = CType(resources.GetObject("BtnChecking.Image"), System.Drawing.Image)
        Me.BtnChecking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnChecking.Location = New System.Drawing.Point(326, 170)
        Me.BtnChecking.Name = "BtnChecking"
        Me.BtnChecking.Size = New System.Drawing.Size(107, 31)
        Me.BtnChecking.TabIndex = 251
        Me.BtnChecking.Text = "Checking"
        Me.BtnChecking.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnChecking.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(440, 207)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(588, 339)
        Me.Panel2.TabIndex = 252
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(588, 41)
        Me.Panel3.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "List Tasker"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.appkode, Me.subscribe, Me.lim_perday, Me.Lim_recall, Me.pick_tg, Me.idle, Me.worker})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.EnableHeadersVisualStyles = False
        Me.DataGridView1.GridColor = System.Drawing.Color.Lime
        Me.DataGridView1.Location = New System.Drawing.Point(3, 47)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidth = 40
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGridView1.RowTemplate.Height = 20
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.Size = New System.Drawing.Size(571, 139)
        Me.DataGridView1.TabIndex = 187
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "No"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 44
        '
        'appkode
        '
        Me.appkode.HeaderText = "appkode"
        Me.appkode.Name = "appkode"
        Me.appkode.ReadOnly = True
        Me.appkode.Width = 72
        '
        'subscribe
        '
        Me.subscribe.HeaderText = "subscribe"
        Me.subscribe.Name = "subscribe"
        Me.subscribe.ReadOnly = True
        Me.subscribe.Width = 79
        '
        'lim_perday
        '
        Me.lim_perday.HeaderText = "Limit perday"
        Me.lim_perday.Name = "lim_perday"
        Me.lim_perday.ReadOnly = True
        Me.lim_perday.Width = 89
        '
        'Lim_recall
        '
        Me.Lim_recall.HeaderText = "Limit Recall"
        Me.Lim_recall.Name = "Lim_recall"
        Me.Lim_recall.ReadOnly = True
        Me.Lim_recall.Width = 84
        '
        'pick_tg
        '
        Me.pick_tg.HeaderText = "Pick Tg"
        Me.pick_tg.Name = "pick_tg"
        Me.pick_tg.ReadOnly = True
        Me.pick_tg.Width = 65
        '
        'idle
        '
        Me.idle.HeaderText = "idle"
        Me.idle.Name = "idle"
        Me.idle.ReadOnly = True
        Me.idle.Width = 47
        '
        'worker
        '
        Me.worker.HeaderText = "worker"
        Me.worker.Name = "worker"
        Me.worker.ReadOnly = True
        Me.worker.Width = 66
        '
        'frmAddSIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 590)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnChecking)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtToken)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.LblHeader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmAddSIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SIP Server"
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.ViewTabel0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelPusat.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel10 As Panel
    Friend WithEvents LblHeader As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents ViewTabel0 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtToken As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents PanelPusat As RoundedPanel
    Friend WithEvents lbIdle As UCformtext
    Friend WithEvents lbTipeAkun As UCformtext
    Friend WithEvents LblConcurrent As UCformtext
    Friend WithEvents BtnAdding As Button
    Friend WithEvents LblTglExpire As UCformtext
    Friend WithEvents LblTglCreate As UCformtext
    Friend WithEvents LblAkunId As UCformtext
    Friend WithEvents BtnChecking As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents No As DataGridViewTextBoxColumn
    Friend WithEvents IDAKUN As DataGridViewTextBoxColumn
    Friend WithEvents Concurrent As DataGridViewTextBoxColumn
    Friend WithEvents State As DataGridViewTextBoxColumn
    Friend WithEvents idlea As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents appkode As DataGridViewTextBoxColumn
    Friend WithEvents subscribe As DataGridViewTextBoxColumn
    Friend WithEvents lim_perday As DataGridViewTextBoxColumn
    Friend WithEvents Lim_recall As DataGridViewTextBoxColumn
    Friend WithEvents pick_tg As DataGridViewTextBoxColumn
    Friend WithEvents idle As DataGridViewTextBoxColumn
    Friend WithEvents worker As DataGridViewTextBoxColumn
End Class
