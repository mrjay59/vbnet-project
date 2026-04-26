<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PgDialog
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.ChkAll = New System.Windows.Forms.CheckBox()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.DatTable1 = New System.Windows.Forms.DataGridView()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.PanelField = New System.Windows.Forms.Panel()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.PanelPusat.SuspendLayout()
        CType(Me.DatTable1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelField.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(12, 37)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(530, 1)
        Me.Panel2.TabIndex = 179
        '
        'lblheader
        '
        Me.lblheader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.White
        Me.lblheader.Location = New System.Drawing.Point(10, 5)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(589, 28)
        Me.lblheader.TabIndex = 175
        Me.lblheader.Text = "Text Header"
        '
        'ChkAll
        '
        Me.ChkAll.AutoSize = True
        Me.ChkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ChkAll.Location = New System.Drawing.Point(17, 45)
        Me.ChkAll.Name = "ChkAll"
        Me.ChkAll.Size = New System.Drawing.Size(68, 17)
        Me.ChkAll.TabIndex = 0
        Me.ChkAll.Text = "Check All"
        Me.ChkAll.UseVisualStyleBackColor = True
        Me.ChkAll.Visible = False
        '
        'PanelPusat
        '
        Me.PanelPusat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Controls.Add(Me.DatTable1)
        Me.PanelPusat.Location = New System.Drawing.Point(4, 71)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(647, 347)
        Me.PanelPusat.TabIndex = 176
        '
        'DatTable1
        '
        Me.DatTable1.AllowUserToAddRows = False
        Me.DatTable1.AllowUserToDeleteRows = False
        Me.DatTable1.AllowUserToResizeColumns = False
        Me.DatTable1.AllowUserToResizeRows = False
        Me.DatTable1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DatTable1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DatTable1.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.DatTable1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DatTable1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.DatTable1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatTable1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DatTable1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DatTable1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DatTable1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DatTable1.EnableHeadersVisualStyles = False
        Me.DatTable1.GridColor = System.Drawing.Color.Lime
        Me.DatTable1.Location = New System.Drawing.Point(0, 0)
        Me.DatTable1.Name = "DatTable1"
        Me.DatTable1.ReadOnly = True
        Me.DatTable1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DatTable1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
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
        Me.DatTable1.Size = New System.Drawing.Size(647, 347)
        Me.DatTable1.TabIndex = 188
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Gray
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(605, 5)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(42, 29)
        Me.btnclose.TabIndex = 180
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'PanelField
        '
        Me.PanelField.Controls.Add(Me.Panel2)
        Me.PanelField.Controls.Add(Me.lblheader)
        Me.PanelField.Controls.Add(Me.ChkAll)
        Me.PanelField.Controls.Add(Me.PanelPusat)
        Me.PanelField.Controls.Add(Me.btnclose)
        Me.PanelField.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelField.Location = New System.Drawing.Point(0, 0)
        Me.PanelField.Name = "PanelField"
        Me.PanelField.Size = New System.Drawing.Size(654, 421)
        Me.PanelField.TabIndex = 183
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'PgDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(654, 421)
        Me.Controls.Add(Me.PanelField)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PgDialog"
        Me.PanelPusat.ResumeLayout(False)
        CType(Me.DatTable1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelField.ResumeLayout(False)
        Me.PanelField.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblheader As Label
    Friend WithEvents ChkAll As CheckBox
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents PanelField As Panel
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents DatTable1 As DataGridView
End Class
