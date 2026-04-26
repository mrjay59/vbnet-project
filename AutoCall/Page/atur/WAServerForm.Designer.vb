<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WAServerForm
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
        Me.ViewTabel0 = New System.Windows.Forms.DataGridView()
        Me.DataTableControl1 = New AutoCall.DataTableControl()
        CType(Me.ViewTabel0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Cyan
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.ViewTabel0.DefaultCellStyle = DataGridViewCellStyle2
        Me.ViewTabel0.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ViewTabel0.EnableHeadersVisualStyles = False
        Me.ViewTabel0.GridColor = System.Drawing.Color.Lime
        Me.ViewTabel0.Location = New System.Drawing.Point(0, 0)
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
        Me.ViewTabel0.Size = New System.Drawing.Size(523, 181)
        Me.ViewTabel0.TabIndex = 189
        '
        'DataTableControl1
        '
        Me.DataTableControl1.AlternateRowColor = System.Drawing.Color.Lavender
        Me.DataTableControl1.BackColor = System.Drawing.Color.Transparent
        Me.DataTableControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DataTableControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataTableControl1.HeaderBackColor = System.Drawing.Color.SteelBlue
        Me.DataTableControl1.HeaderForeColor = System.Drawing.Color.White
        Me.DataTableControl1.Location = New System.Drawing.Point(0, 0)
        Me.DataTableControl1.Name = "DataTableControl1"
        Me.DataTableControl1.RowBackColor = System.Drawing.Color.White
        Me.DataTableControl1.RowForeColor = System.Drawing.Color.Black
        Me.DataTableControl1.Size = New System.Drawing.Size(523, 181)
        Me.DataTableControl1.TabIndex = 190
        '
        'WAServerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(523, 181)
        Me.Controls.Add(Me.DataTableControl1)
        Me.Controls.Add(Me.ViewTabel0)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WAServerForm"
        Me.Text = "WAServerForm"
        CType(Me.ViewTabel0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ViewTabel0 As DataGridView
    Friend WithEvents DataTableControl1 As DataTableControl
End Class
