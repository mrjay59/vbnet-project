<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PgDaServer
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.PnListH = New System.Windows.Forms.Panel()
        Me.BtnAddAkuns = New System.Windows.Forms.Button()
        Me.Panelgb = New System.Windows.Forms.Panel()
        Me.BtnClould = New System.Windows.Forms.Button()
        Me.BtnLocal = New System.Windows.Forms.Button()
        Me.PnPaging = New System.Windows.Forms.Panel()
        Me.PnListServer = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.BtnReqkode = New System.Windows.Forms.Button()
        Me.BtnQr = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        Me.BtnLogout = New System.Windows.Forms.Button()
        Me.BtnRestart = New System.Windows.Forms.Button()
        Me.BtnStop = New System.Windows.Forms.Button()
        Me.DatTable1 = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.PnScanQR = New System.Windows.Forms.Panel()
        Me.PnDScanQr = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PnAddForm = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.RequestKodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QRCODEToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AturSeassionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PnListH.SuspendLayout()
        Me.PnListServer.SuspendLayout()
        CType(Me.DatTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.PnScanQR.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PnListH
        '
        Me.PnListH.Controls.Add(Me.BtnAddAkuns)
        Me.PnListH.Controls.Add(Me.Panelgb)
        Me.PnListH.Controls.Add(Me.BtnClould)
        Me.PnListH.Controls.Add(Me.BtnLocal)
        Me.PnListH.Controls.Add(Me.PnPaging)
        Me.PnListH.Controls.Add(Me.PnListServer)
        Me.PnListH.Controls.Add(Me.Panel2)
        Me.PnListH.Location = New System.Drawing.Point(12, 12)
        Me.PnListH.Name = "PnListH"
        Me.PnListH.Size = New System.Drawing.Size(461, 566)
        Me.PnListH.TabIndex = 193
        '
        'BtnAddAkuns
        '
        Me.BtnAddAkuns.BackColor = System.Drawing.Color.Gray
        Me.BtnAddAkuns.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAddAkuns.FlatAppearance.BorderSize = 0
        Me.BtnAddAkuns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAddAkuns.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAddAkuns.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAddAkuns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAddAkuns.Location = New System.Drawing.Point(260, 47)
        Me.BtnAddAkuns.Name = "BtnAddAkuns"
        Me.BtnAddAkuns.Size = New System.Drawing.Size(132, 21)
        Me.BtnAddAkuns.TabIndex = 209
        Me.BtnAddAkuns.Text = "+ AkunID WhatsApp"
        Me.BtnAddAkuns.UseVisualStyleBackColor = False
        '
        'Panelgb
        '
        Me.Panelgb.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Panelgb.Location = New System.Drawing.Point(9, 69)
        Me.Panelgb.Name = "Panelgb"
        Me.Panelgb.Size = New System.Drawing.Size(176, 5)
        Me.Panelgb.TabIndex = 208
        Me.Panelgb.Visible = False
        '
        'BtnClould
        '
        Me.BtnClould.BackColor = System.Drawing.Color.Gray
        Me.BtnClould.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClould.FlatAppearance.BorderSize = 0
        Me.BtnClould.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClould.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClould.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnClould.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnClould.Location = New System.Drawing.Point(137, 47)
        Me.BtnClould.Name = "BtnClould"
        Me.BtnClould.Size = New System.Drawing.Size(117, 21)
        Me.BtnClould.TabIndex = 207
        Me.BtnClould.Text = "Cloud WAServer"
        Me.BtnClould.UseVisualStyleBackColor = False
        '
        'BtnLocal
        '
        Me.BtnLocal.BackColor = System.Drawing.Color.Gray
        Me.BtnLocal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLocal.FlatAppearance.BorderSize = 0
        Me.BtnLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLocal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLocal.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnLocal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLocal.Location = New System.Drawing.Point(9, 47)
        Me.BtnLocal.Name = "BtnLocal"
        Me.BtnLocal.Size = New System.Drawing.Size(122, 21)
        Me.BtnLocal.TabIndex = 206
        Me.BtnLocal.Text = "Local WAScanQr"
        Me.BtnLocal.UseVisualStyleBackColor = False
        '
        'PnPaging
        '
        Me.PnPaging.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PnPaging.Location = New System.Drawing.Point(0, 525)
        Me.PnPaging.Name = "PnPaging"
        Me.PnPaging.Size = New System.Drawing.Size(461, 41)
        Me.PnPaging.TabIndex = 205
        '
        'PnListServer
        '
        Me.PnListServer.AutoScroll = True
        Me.PnListServer.Controls.Add(Me.Label2)
        Me.PnListServer.Controls.Add(Me.BtnReqkode)
        Me.PnListServer.Controls.Add(Me.BtnQr)
        Me.PnListServer.Controls.Add(Me.BtnStart)
        Me.PnListServer.Controls.Add(Me.BtnLogout)
        Me.PnListServer.Controls.Add(Me.BtnRestart)
        Me.PnListServer.Controls.Add(Me.BtnStop)
        Me.PnListServer.Controls.Add(Me.DatTable1)
        Me.PnListServer.Location = New System.Drawing.Point(0, 74)
        Me.PnListServer.Name = "PnListServer"
        Me.PnListServer.Size = New System.Drawing.Size(461, 445)
        Me.PnListServer.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(19, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 19)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "Button Aksi :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnReqkode
        '
        Me.BtnReqkode.BackColor = System.Drawing.Color.DimGray
        Me.BtnReqkode.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnReqkode.FlatAppearance.BorderSize = 0
        Me.BtnReqkode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnReqkode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnReqkode.ForeColor = System.Drawing.Color.White
        Me.BtnReqkode.Image = Global.AutoCall.My.Resources.Resources.icons8_code_18
        Me.BtnReqkode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnReqkode.Location = New System.Drawing.Point(128, 5)
        Me.BtnReqkode.Name = "BtnReqkode"
        Me.BtnReqkode.Size = New System.Drawing.Size(82, 30)
        Me.BtnReqkode.TabIndex = 216
        Me.BtnReqkode.Text = "Req Kode"
        Me.BtnReqkode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnReqkode.UseVisualStyleBackColor = False
        '
        'BtnQr
        '
        Me.BtnQr.BackColor = System.Drawing.Color.DimGray
        Me.BtnQr.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnQr.FlatAppearance.BorderSize = 0
        Me.BtnQr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnQr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnQr.ForeColor = System.Drawing.Color.Black
        Me.BtnQr.Image = Global.AutoCall.My.Resources.Resources.icons8_qr_code_19
        Me.BtnQr.Location = New System.Drawing.Point(212, 5)
        Me.BtnQr.Name = "BtnQr"
        Me.BtnQr.Size = New System.Drawing.Size(34, 30)
        Me.BtnQr.TabIndex = 215
        Me.BtnQr.UseVisualStyleBackColor = False
        '
        'BtnStart
        '
        Me.BtnStart.BackColor = System.Drawing.Color.DimGray
        Me.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStart.FlatAppearance.BorderSize = 0
        Me.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.Color.White
        Me.BtnStart.Image = Global.AutoCall.My.Resources.Resources.icons8_play_20
        Me.BtnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStart.Location = New System.Drawing.Point(253, 5)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(70, 30)
        Me.BtnStart.TabIndex = 214
        Me.BtnStart.Text = "START"
        Me.BtnStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnStart.UseVisualStyleBackColor = False
        '
        'BtnLogout
        '
        Me.BtnLogout.BackColor = System.Drawing.Color.DimGray
        Me.BtnLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnLogout.FlatAppearance.BorderSize = 0
        Me.BtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnLogout.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLogout.ForeColor = System.Drawing.Color.White
        Me.BtnLogout.Image = Global.AutoCall.My.Resources.Resources.icons8_logout_18
        Me.BtnLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnLogout.Location = New System.Drawing.Point(429, 5)
        Me.BtnLogout.Name = "BtnLogout"
        Me.BtnLogout.Size = New System.Drawing.Size(29, 30)
        Me.BtnLogout.TabIndex = 213
        Me.BtnLogout.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnLogout.UseVisualStyleBackColor = False
        '
        'BtnRestart
        '
        Me.BtnRestart.BackColor = System.Drawing.Color.DimGray
        Me.BtnRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRestart.FlatAppearance.BorderSize = 0
        Me.BtnRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRestart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRestart.ForeColor = System.Drawing.Color.White
        Me.BtnRestart.Image = Global.AutoCall.My.Resources.Resources.icons8_restart_20
        Me.BtnRestart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRestart.Location = New System.Drawing.Point(396, 5)
        Me.BtnRestart.Name = "BtnRestart"
        Me.BtnRestart.Size = New System.Drawing.Size(31, 30)
        Me.BtnRestart.TabIndex = 212
        Me.BtnRestart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRestart.UseVisualStyleBackColor = False
        '
        'BtnStop
        '
        Me.BtnStop.BackColor = System.Drawing.Color.DimGray
        Me.BtnStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStop.FlatAppearance.BorderSize = 0
        Me.BtnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStop.ForeColor = System.Drawing.Color.White
        Me.BtnStop.Image = Global.AutoCall.My.Resources.Resources.icons8_stop_20
        Me.BtnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStop.Location = New System.Drawing.Point(325, 5)
        Me.BtnStop.Name = "BtnStop"
        Me.BtnStop.Size = New System.Drawing.Size(62, 30)
        Me.BtnStop.TabIndex = 211
        Me.BtnStop.Text = "STOP"
        Me.BtnStop.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnStop.UseVisualStyleBackColor = False
        '
        'DatTable1
        '
        Me.DatTable1.AllowUserToAddRows = False
        Me.DatTable1.AllowUserToDeleteRows = False
        Me.DatTable1.AllowUserToResizeColumns = False
        Me.DatTable1.AllowUserToResizeRows = False
        Me.DatTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DatTable1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.DatTable1.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle13.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatTable1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.DatTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle14.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatTable1.DefaultCellStyle = DataGridViewCellStyle14
        Me.DatTable1.EnableHeadersVisualStyles = False
        Me.DatTable1.GridColor = System.Drawing.Color.DarkOliveGreen
        Me.DatTable1.Location = New System.Drawing.Point(6, 41)
        Me.DatTable1.Name = "DatTable1"
        Me.DatTable1.ReadOnly = True
        Me.DatTable1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatTable1.RowHeadersDefaultCellStyle = DataGridViewCellStyle15
        Me.DatTable1.RowHeadersVisible = False
        Me.DatTable1.RowHeadersWidth = 40
        Me.DatTable1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DatTable1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DatTable1.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DatTable1.RowTemplate.Height = 20
        Me.DatTable1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatTable1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DatTable1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DatTable1.ShowCellToolTips = False
        Me.DatTable1.Size = New System.Drawing.Size(450, 314)
        Me.DatTable1.TabIndex = 189
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(461, 41)
        Me.Panel2.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(3, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(173, 23)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "List Data WhatsApp"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnScanQR
        '
        Me.PnScanQR.Controls.Add(Me.PnDScanQr)
        Me.PnScanQR.Controls.Add(Me.Panel4)
        Me.PnScanQR.Location = New System.Drawing.Point(479, 286)
        Me.PnScanQR.Name = "PnScanQR"
        Me.PnScanQR.Size = New System.Drawing.Size(549, 292)
        Me.PnScanQR.TabIndex = 202
        '
        'PnDScanQr
        '
        Me.PnDScanQr.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnDScanQr.Location = New System.Drawing.Point(0, 41)
        Me.PnDScanQr.Name = "PnDScanQr"
        Me.PnDScanQr.Size = New System.Drawing.Size(549, 251)
        Me.PnDScanQr.TabIndex = 4
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Gray
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(549, 41)
        Me.Panel4.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "SCAN WhatsApp"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PnAddForm)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Location = New System.Drawing.Point(479, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(549, 268)
        Me.Panel1.TabIndex = 203
        '
        'PnAddForm
        '
        Me.PnAddForm.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnAddForm.Location = New System.Drawing.Point(0, 41)
        Me.PnAddForm.Name = "PnAddForm"
        Me.PnAddForm.Size = New System.Drawing.Size(549, 227)
        Me.PnAddForm.TabIndex = 4
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Gray
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(549, 41)
        Me.Panel7.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(240, 23)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Silahkan dipilih Data Server"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RequestKodeToolStripMenuItem, Me.QRCODEToolStripMenuItem, Me.AturSeassionToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(147, 70)
        '
        'RequestKodeToolStripMenuItem
        '
        Me.RequestKodeToolStripMenuItem.Name = "RequestKodeToolStripMenuItem"
        Me.RequestKodeToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.RequestKodeToolStripMenuItem.Text = "Request Kode"
        '
        'QRCODEToolStripMenuItem
        '
        Me.QRCODEToolStripMenuItem.Name = "QRCODEToolStripMenuItem"
        Me.QRCODEToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.QRCODEToolStripMenuItem.Text = "QRCODE"
        '
        'AturSeassionToolStripMenuItem
        '
        Me.AturSeassionToolStripMenuItem.Name = "AturSeassionToolStripMenuItem"
        Me.AturSeassionToolStripMenuItem.Size = New System.Drawing.Size(146, 22)
        Me.AturSeassionToolStripMenuItem.Text = "Atur Seassion"
        '
        'PgDaServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1040, 590)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnScanQR)
        Me.Controls.Add(Me.PnListH)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgDaServer"
        Me.Text = "PgDaServer"
        Me.PnListH.ResumeLayout(False)
        Me.PnListServer.ResumeLayout(False)
        Me.PnListServer.PerformLayout()
        CType(Me.DatTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PnScanQR.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnListH As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PnScanQR As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents PnListServer As Panel
    Friend WithEvents PnDScanQr As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PnAddForm As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PnPaging As Panel
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnClould As Button
    Friend WithEvents BtnLocal As Button
    Friend WithEvents DatTable1 As DataGridView
    Friend WithEvents Panelgb As Panel
    Friend WithEvents BtnAddAkuns As Button
    Friend WithEvents BtnLogout As Button
    Friend WithEvents BtnRestart As Button
    Friend WithEvents BtnStop As Button
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnReqkode As Button
    Friend WithEvents BtnQr As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents RequestKodeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QRCODEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AturSeassionToolStripMenuItem As ToolStripMenuItem
End Class
