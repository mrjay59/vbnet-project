<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmlog
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
        Me.lbltext = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.ViewTabel = New System.Windows.Forms.DataGridView()
        Me.number = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.from = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Platform = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToMg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotBr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TotAN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.result = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Recall = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToCall = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Panel1.SuspendLayout()
        Me.PanelPusat.SuspendLayout()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbltext
        '
        Me.lbltext.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltext.ForeColor = System.Drawing.Color.White
        Me.lbltext.Location = New System.Drawing.Point(3, 9)
        Me.lbltext.Name = "lbltext"
        Me.lbltext.Size = New System.Drawing.Size(362, 30)
        Me.lbltext.TabIndex = 139
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnclose)
        Me.Panel1.Controls.Add(Me.lbltext)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(613, 45)
        Me.Panel1.TabIndex = 140
        '
        'btnclose
        '
        Me.btnclose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(563, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(50, 45)
        Me.btnclose.TabIndex = 140
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = True
        '
        'PanelPusat
        '
        Me.PanelPusat.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelPusat.Controls.Add(Me.ViewTabel)
        Me.PanelPusat.Location = New System.Drawing.Point(0, 45)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(613, 216)
        Me.PanelPusat.TabIndex = 141
        '
        'ViewTabel
        '
        Me.ViewTabel.AllowUserToAddRows = False
        Me.ViewTabel.AllowUserToDeleteRows = False
        Me.ViewTabel.AllowUserToResizeColumns = False
        Me.ViewTabel.AllowUserToResizeRows = False
        Me.ViewTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
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
        Me.ViewTabel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.number, Me.toes, Me.from, Me.Platform, Me.ToMg, Me.TotBr, Me.TotAN, Me.result, Me.Recall, Me.ToCall})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(30, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ControlDarkDark
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.DefaultCellStyle = DataGridViewCellStyle2
        Me.ViewTabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTabel.EnableHeadersVisualStyles = False
        Me.ViewTabel.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel.Location = New System.Drawing.Point(0, 0)
        Me.ViewTabel.Name = "ViewTabel"
        Me.ViewTabel.ReadOnly = True
        Me.ViewTabel.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Century", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ViewTabel.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.ViewTabel.RowHeadersVisible = False
        Me.ViewTabel.RowHeadersWidth = 40
        Me.ViewTabel.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ViewTabel.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ViewTabel.RowTemplate.Height = 20
        Me.ViewTabel.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.ViewTabel.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.ViewTabel.ShowCellToolTips = False
        Me.ViewTabel.Size = New System.Drawing.Size(613, 216)
        Me.ViewTabel.TabIndex = 75
        '
        'number
        '
        Me.number.HeaderText = "No"
        Me.number.Name = "number"
        Me.number.ReadOnly = True
        Me.number.Width = 44
        '
        'toes
        '
        Me.toes.HeaderText = "Tujuan"
        Me.toes.Name = "toes"
        Me.toes.ReadOnly = True
        Me.toes.Width = 63
        '
        'from
        '
        Me.from.HeaderText = "Sumber"
        Me.from.Name = "from"
        Me.from.ReadOnly = True
        Me.from.Width = 68
        '
        'Platform
        '
        Me.Platform.HeaderText = "platform"
        Me.Platform.Name = "Platform"
        Me.Platform.ReadOnly = True
        Me.Platform.Width = 70
        '
        'ToMg
        '
        Me.ToMg.HeaderText = "Tot Mg"
        Me.ToMg.Name = "ToMg"
        Me.ToMg.ReadOnly = True
        Me.ToMg.Width = 62
        '
        'TotBr
        '
        Me.TotBr.HeaderText = "Tot BR"
        Me.TotBr.Name = "TotBr"
        Me.TotBr.ReadOnly = True
        Me.TotBr.Width = 62
        '
        'TotAN
        '
        Me.TotAN.HeaderText = "Tot AN"
        Me.TotAN.Name = "TotAN"
        Me.TotAN.ReadOnly = True
        Me.TotAN.Width = 62
        '
        'result
        '
        Me.result.HeaderText = "Hasil"
        Me.result.Name = "result"
        Me.result.ReadOnly = True
        Me.result.Width = 54
        '
        'Recall
        '
        Me.Recall.HeaderText = "ReCall"
        Me.Recall.Name = "Recall"
        Me.Recall.ReadOnly = True
        Me.Recall.Width = 61
        '
        'ToCall
        '
        Me.ToCall.HeaderText = "TotCall"
        Me.ToCall.Name = "ToCall"
        Me.ToCall.ReadOnly = True
        Me.ToCall.Width = 62
        '
        'frmlog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(613, 261)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmlog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.PanelPusat.ResumeLayout(False)
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lbltext As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents ViewTabel As DataGridView
    Friend WithEvents number As DataGridViewTextBoxColumn
    Friend WithEvents toes As DataGridViewTextBoxColumn
    Friend WithEvents from As DataGridViewTextBoxColumn
    Friend WithEvents Platform As DataGridViewTextBoxColumn
    Friend WithEvents ToMg As DataGridViewTextBoxColumn
    Friend WithEvents TotBr As DataGridViewTextBoxColumn
    Friend WithEvents TotAN As DataGridViewTextBoxColumn
    Friend WithEvents result As DataGridViewTextBoxColumn
    Friend WithEvents Recall As DataGridViewTextBoxColumn
    Friend WithEvents ToCall As DataGridViewTextBoxColumn
    Friend WithEvents btnclose As Button
End Class
