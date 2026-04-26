<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddataServer
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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.BtnValidasi = New System.Windows.Forms.Button()
        Me.Lblname = New System.Windows.Forms.Label()
        Me.kode6 = New System.Windows.Forms.TextBox()
        Me.kode5 = New System.Windows.Forms.TextBox()
        Me.kode4 = New System.Windows.Forms.TextBox()
        Me.kode3 = New System.Windows.Forms.TextBox()
        Me.kode2 = New System.Windows.Forms.TextBox()
        Me.kode1 = New System.Windows.Forms.TextBox()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Gray
        Me.Panel3.Controls.Add(Me.btnclose)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(471, 41)
        Me.Panel3.TabIndex = 4
        '
        'btnclose
        '
        Me.btnclose.BackColor = System.Drawing.Color.Gray
        Me.btnclose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnclose.FlatAppearance.BorderSize = 0
        Me.btnclose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.btnclose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.btnclose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnclose.ForeColor = System.Drawing.Color.White
        Me.btnclose.Location = New System.Drawing.Point(429, 0)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(42, 41)
        Me.btnclose.TabIndex = 181
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = False
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
        Me.Label11.Size = New System.Drawing.Size(159, 23)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Masukan Voucher"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnValidasi
        '
        Me.BtnValidasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(91, Byte), Integer))
        Me.BtnValidasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnValidasi.FlatAppearance.BorderSize = 0
        Me.BtnValidasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnValidasi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnValidasi.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnValidasi.Location = New System.Drawing.Point(317, 194)
        Me.BtnValidasi.Name = "BtnValidasi"
        Me.BtnValidasi.Size = New System.Drawing.Size(137, 36)
        Me.BtnValidasi.TabIndex = 202
        Me.BtnValidasi.Text = "Validasi Voucher"
        Me.BtnValidasi.UseVisualStyleBackColor = False
        '
        'Lblname
        '
        Me.Lblname.AutoSize = True
        Me.Lblname.Font = New System.Drawing.Font("Book Antiqua", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblname.ForeColor = System.Drawing.Color.White
        Me.Lblname.Location = New System.Drawing.Point(178, 67)
        Me.Lblname.Name = "Lblname"
        Me.Lblname.Size = New System.Drawing.Size(114, 18)
        Me.Lblname.TabIndex = 209
        Me.Lblname.Text = "Input Kode Voucher"
        '
        'kode6
        '
        Me.kode6.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode6.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode6.ForeColor = System.Drawing.Color.White
        Me.kode6.Location = New System.Drawing.Point(379, 102)
        Me.kode6.MaxLength = 1
        Me.kode6.Name = "kode6"
        Me.kode6.Size = New System.Drawing.Size(64, 42)
        Me.kode6.TabIndex = 208
        Me.kode6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode6.WordWrap = False
        '
        'kode5
        '
        Me.kode5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode5.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode5.ForeColor = System.Drawing.Color.White
        Me.kode5.Location = New System.Drawing.Point(309, 102)
        Me.kode5.MaxLength = 1
        Me.kode5.Name = "kode5"
        Me.kode5.Size = New System.Drawing.Size(64, 42)
        Me.kode5.TabIndex = 207
        Me.kode5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode5.WordWrap = False
        '
        'kode4
        '
        Me.kode4.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode4.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode4.ForeColor = System.Drawing.Color.White
        Me.kode4.Location = New System.Drawing.Point(239, 102)
        Me.kode4.MaxLength = 1
        Me.kode4.Name = "kode4"
        Me.kode4.Size = New System.Drawing.Size(64, 42)
        Me.kode4.TabIndex = 206
        Me.kode4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode4.WordWrap = False
        '
        'kode3
        '
        Me.kode3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode3.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode3.ForeColor = System.Drawing.Color.White
        Me.kode3.Location = New System.Drawing.Point(169, 102)
        Me.kode3.MaxLength = 1
        Me.kode3.Name = "kode3"
        Me.kode3.Size = New System.Drawing.Size(64, 42)
        Me.kode3.TabIndex = 205
        Me.kode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode3.WordWrap = False
        '
        'kode2
        '
        Me.kode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode2.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode2.ForeColor = System.Drawing.Color.White
        Me.kode2.Location = New System.Drawing.Point(99, 102)
        Me.kode2.MaxLength = 1
        Me.kode2.Name = "kode2"
        Me.kode2.Size = New System.Drawing.Size(64, 42)
        Me.kode2.TabIndex = 204
        Me.kode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode2.WordWrap = False
        '
        'kode1
        '
        Me.kode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode1.ForeColor = System.Drawing.Color.White
        Me.kode1.Location = New System.Drawing.Point(29, 102)
        Me.kode1.MaxLength = 1
        Me.kode1.Name = "kode1"
        Me.kode1.Size = New System.Drawing.Size(64, 42)
        Me.kode1.TabIndex = 203
        Me.kode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode1.WordWrap = False
        '
        'AddataServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(471, 246)
        Me.Controls.Add(Me.Lblname)
        Me.Controls.Add(Me.kode6)
        Me.Controls.Add(Me.kode5)
        Me.Controls.Add(Me.kode4)
        Me.Controls.Add(Me.kode3)
        Me.Controls.Add(Me.kode2)
        Me.Controls.Add(Me.kode1)
        Me.Controls.Add(Me.BtnValidasi)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "AddataServer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "AddataServer"
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnclose As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents BtnValidasi As Button
    Friend WithEvents Lblname As Label
    Friend WithEvents kode6 As TextBox
    Friend WithEvents kode5 As TextBox
    Friend WithEvents kode4 As TextBox
    Friend WithEvents kode3 As TextBox
    Friend WithEvents kode2 As TextBox
    Friend WithEvents kode1 As TextBox
End Class
