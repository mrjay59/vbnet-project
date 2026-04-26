<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class dialog_device
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.ViewTabel = New System.Windows.Forms.DataGridView()
        Me.Nourut = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.idev = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.model = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Connection = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.STATUS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apps = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cloning = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Pilih = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(153, 15)
        Me.Label4.TabIndex = 208
        Me.Label4.Text = "Filter Aplikasi local Android"
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(186, 35)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(97, 17)
        Me.rd1.TabIndex = 210
        Me.rd1.TabStop = True
        Me.rd1.Text = "Telpon Android"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(82, 35)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(94, 17)
        Me.rd0.TabIndex = 209
        Me.rd0.TabStop = True
        Me.rd0.Text = "Whatsapp Call"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.ForeColor = System.Drawing.Color.White
        Me.RadioButton1.Location = New System.Drawing.Point(13, 35)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(58, 17)
        Me.RadioButton1.TabIndex = 211
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Semua"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'ViewTabel
        '
        Me.ViewTabel.AllowUserToAddRows = False
        Me.ViewTabel.AllowUserToDeleteRows = False
        Me.ViewTabel.AllowUserToResizeColumns = False
        Me.ViewTabel.AllowUserToResizeRows = False
        Me.ViewTabel.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.ViewTabel.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.ViewTabel.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
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
        Me.ViewTabel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Nourut, Me.idev, Me.model, Me.Connection, Me.STATUS, Me.Apps, Me.Cloning, Me.Pilih})
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
        Me.ViewTabel.Location = New System.Drawing.Point(12, 58)
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
        Me.ViewTabel.Size = New System.Drawing.Size(623, 273)
        Me.ViewTabel.TabIndex = 212
        '
        'Nourut
        '
        Me.Nourut.HeaderText = "URUT"
        Me.Nourut.Name = "Nourut"
        Me.Nourut.ReadOnly = True
        Me.Nourut.Width = 58
        '
        'idev
        '
        Me.idev.HeaderText = "ID SERIAL"
        Me.idev.Name = "idev"
        Me.idev.ReadOnly = True
        Me.idev.Width = 79
        '
        'model
        '
        Me.model.HeaderText = "model"
        Me.model.Name = "model"
        Me.model.ReadOnly = True
        Me.model.Width = 59
        '
        'Connection
        '
        Me.Connection.HeaderText = "KONEKSI"
        Me.Connection.Name = "Connection"
        Me.Connection.ReadOnly = True
        Me.Connection.Width = 75
        '
        'STATUS
        '
        Me.STATUS.HeaderText = "STATUS"
        Me.STATUS.Name = "STATUS"
        Me.STATUS.ReadOnly = True
        Me.STATUS.Width = 70
        '
        'Apps
        '
        Me.Apps.HeaderText = "Aplikasi"
        Me.Apps.Name = "Apps"
        Me.Apps.ReadOnly = True
        Me.Apps.Width = 68
        '
        'Cloning
        '
        Me.Cloning.HeaderText = "CLONE"
        Me.Cloning.Name = "Cloning"
        Me.Cloning.ReadOnly = True
        Me.Cloning.Width = 65
        '
        'Pilih
        '
        Me.Pilih.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Pilih.HeaderText = "Pilih"
        Me.Pilih.Name = "Pilih"
        Me.Pilih.ReadOnly = True
        Me.Pilih.UseColumnTextForButtonValue = True
        Me.Pilih.Width = 30
        '
        'dialog_device
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(68, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(647, 347)
        Me.Controls.Add(Me.ViewTabel)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.rd0)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "dialog_device"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "dialog_device"
        CType(Me.ViewTabel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents ViewTabel As DataGridView
    Friend WithEvents Nourut As DataGridViewTextBoxColumn
    Friend WithEvents idev As DataGridViewTextBoxColumn
    Friend WithEvents model As DataGridViewTextBoxColumn
    Friend WithEvents Connection As DataGridViewTextBoxColumn
    Friend WithEvents STATUS As DataGridViewTextBoxColumn
    Friend WithEvents Apps As DataGridViewTextBoxColumn
    Friend WithEvents Cloning As DataGridViewTextBoxColumn
    Friend WithEvents Pilih As DataGridViewButtonColumn
End Class
