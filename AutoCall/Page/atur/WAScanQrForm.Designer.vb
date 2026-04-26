<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WAScanQrForm
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
        Me.CountWa = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnADD = New System.Windows.Forms.Button()
        Me.seassionid = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.RdTipe1 = New System.Windows.Forms.RadioButton()
        Me.RdTipe2 = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        CType(Me.CountWa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CountWa
        '
        Me.CountWa.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.CountWa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CountWa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CountWa.ForeColor = System.Drawing.Color.White
        Me.CountWa.Location = New System.Drawing.Point(252, 104)
        Me.CountWa.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.CountWa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.CountWa.Name = "CountWa"
        Me.CountWa.ReadOnly = True
        Me.CountWa.Size = New System.Drawing.Size(80, 31)
        Me.CountWa.TabIndex = 204
        Me.CountWa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.CountWa.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(251, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 205
        Me.Label6.Text = "Jumlah WA"
        '
        'BtnADD
        '
        Me.BtnADD.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnADD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnADD.FlatAppearance.BorderSize = 0
        Me.BtnADD.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnADD.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnADD.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnADD.Location = New System.Drawing.Point(338, 104)
        Me.BtnADD.Name = "BtnADD"
        Me.BtnADD.Size = New System.Drawing.Size(173, 31)
        Me.BtnADD.TabIndex = 207
        Me.BtnADD.Text = "Tambahkan "
        Me.BtnADD.UseVisualStyleBackColor = False
        '
        'seassionid
        '
        Me.seassionid.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.seassionid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.seassionid.Enabled = False
        Me.seassionid.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.seassionid.ForeColor = System.Drawing.Color.White
        Me.seassionid.Location = New System.Drawing.Point(12, 101)
        Me.seassionid.Name = "seassionid"
        Me.seassionid.ReadOnly = True
        Me.seassionid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.seassionid.Size = New System.Drawing.Size(234, 37)
        Me.seassionid.TabIndex = 208
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(10, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 15)
        Me.Label9.TabIndex = 206
        Me.Label9.Text = "Name SesionId"
        '
        'RdTipe1
        '
        Me.RdTipe1.AutoSize = True
        Me.RdTipe1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdTipe1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdTipe1.ForeColor = System.Drawing.Color.White
        Me.RdTipe1.Location = New System.Drawing.Point(13, 34)
        Me.RdTipe1.Name = "RdTipe1"
        Me.RdTipe1.Size = New System.Drawing.Size(159, 24)
        Me.RdTipe1.TabIndex = 209
        Me.RdTipe1.TabStop = True
        Me.RdTipe1.Text = "Buat Session Baru"
        Me.RdTipe1.UseVisualStyleBackColor = True
        '
        'RdTipe2
        '
        Me.RdTipe2.AutoSize = True
        Me.RdTipe2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RdTipe2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RdTipe2.ForeColor = System.Drawing.Color.White
        Me.RdTipe2.Location = New System.Drawing.Point(203, 34)
        Me.RdTipe2.Name = "RdTipe2"
        Me.RdTipe2.Size = New System.Drawing.Size(170, 24)
        Me.RdTipe2.TabIndex = 210
        Me.RdTipe2.TabStop = True
        Me.RdTipe2.Text = "Pakai Session Lama"
        Me.RdTipe2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.ForeColor = System.Drawing.Color.White
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(13, 103)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(233, 32)
        Me.ComboBox1.TabIndex = 211
        Me.ComboBox1.Visible = False
        '
        'WAScanQrForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(523, 181)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.RdTipe2)
        Me.Controls.Add(Me.RdTipe1)
        Me.Controls.Add(Me.CountWa)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.BtnADD)
        Me.Controls.Add(Me.seassionid)
        Me.Controls.Add(Me.Label9)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WAScanQrForm"
        Me.Text = "WAScanQrForm"
        CType(Me.CountWa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CountWa As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnADD As Button
    Friend WithEvents seassionid As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents RdTipe1 As RadioButton
    Friend WithEvents RdTipe2 As RadioButton
    Friend WithEvents ComboBox1 As ComboBox
End Class
