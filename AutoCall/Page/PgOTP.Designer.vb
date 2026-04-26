<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PgOTP
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblheader = New System.Windows.Forms.Label()
        Me.kode1 = New System.Windows.Forms.TextBox()
        Me.kode2 = New System.Windows.Forms.TextBox()
        Me.kode3 = New System.Windows.Forms.TextBox()
        Me.kode4 = New System.Windows.Forms.TextBox()
        Me.kode5 = New System.Windows.Forms.TextBox()
        Me.kode6 = New System.Windows.Forms.TextBox()
        Me.Lblname = New System.Windows.Forms.Label()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(4, 41)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(430, 1)
        Me.Panel2.TabIndex = 181
        '
        'lblheader
        '
        Me.lblheader.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblheader.ForeColor = System.Drawing.Color.White
        Me.lblheader.Location = New System.Drawing.Point(5, 8)
        Me.lblheader.Name = "lblheader"
        Me.lblheader.Size = New System.Drawing.Size(208, 28)
        Me.lblheader.TabIndex = 180
        Me.lblheader.Text = "Konfirmasi OTP"
        '
        'kode1
        '
        Me.kode1.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode1.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode1.ForeColor = System.Drawing.Color.White
        Me.kode1.Location = New System.Drawing.Point(43, 112)
        Me.kode1.MaxLength = 1
        Me.kode1.Name = "kode1"
        Me.kode1.Size = New System.Drawing.Size(52, 42)
        Me.kode1.TabIndex = 1
        Me.kode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode1.WordWrap = False
        '
        'kode2
        '
        Me.kode2.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode2.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode2.ForeColor = System.Drawing.Color.White
        Me.kode2.Location = New System.Drawing.Point(103, 112)
        Me.kode2.MaxLength = 1
        Me.kode2.Name = "kode2"
        Me.kode2.Size = New System.Drawing.Size(52, 42)
        Me.kode2.TabIndex = 2
        Me.kode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode2.WordWrap = False
        '
        'kode3
        '
        Me.kode3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode3.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode3.ForeColor = System.Drawing.Color.White
        Me.kode3.Location = New System.Drawing.Point(161, 112)
        Me.kode3.MaxLength = 1
        Me.kode3.Name = "kode3"
        Me.kode3.Size = New System.Drawing.Size(52, 42)
        Me.kode3.TabIndex = 3
        Me.kode3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode3.WordWrap = False
        '
        'kode4
        '
        Me.kode4.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode4.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode4.ForeColor = System.Drawing.Color.White
        Me.kode4.Location = New System.Drawing.Point(219, 112)
        Me.kode4.MaxLength = 1
        Me.kode4.Name = "kode4"
        Me.kode4.Size = New System.Drawing.Size(52, 42)
        Me.kode4.TabIndex = 4
        Me.kode4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode4.WordWrap = False
        '
        'kode5
        '
        Me.kode5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode5.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode5.ForeColor = System.Drawing.Color.White
        Me.kode5.Location = New System.Drawing.Point(277, 112)
        Me.kode5.MaxLength = 1
        Me.kode5.Name = "kode5"
        Me.kode5.Size = New System.Drawing.Size(52, 42)
        Me.kode5.TabIndex = 5
        Me.kode5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode5.WordWrap = False
        '
        'kode6
        '
        Me.kode6.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.kode6.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.kode6.ForeColor = System.Drawing.Color.White
        Me.kode6.Location = New System.Drawing.Point(335, 112)
        Me.kode6.MaxLength = 1
        Me.kode6.Name = "kode6"
        Me.kode6.Size = New System.Drawing.Size(52, 42)
        Me.kode6.TabIndex = 6
        Me.kode6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.kode6.WordWrap = False
        '
        'Lblname
        '
        Me.Lblname.AutoSize = True
        Me.Lblname.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lblname.ForeColor = System.Drawing.Color.White
        Me.Lblname.Location = New System.Drawing.Point(112, 93)
        Me.Lblname.Name = "Lblname"
        Me.Lblname.Size = New System.Drawing.Size(203, 16)
        Me.Lblname.TabIndex = 187
        Me.Lblname.Text = "Kode Sudah dikirimkan Melalui WhatsApp"
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
        Me.btnclose.Location = New System.Drawing.Point(392, 7)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(42, 29)
        Me.btnclose.TabIndex = 188
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'PgOTP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(441, 242)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.Lblname)
        Me.Controls.Add(Me.kode6)
        Me.Controls.Add(Me.kode5)
        Me.Controls.Add(Me.kode4)
        Me.Controls.Add(Me.kode3)
        Me.Controls.Add(Me.kode2)
        Me.Controls.Add(Me.kode1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblheader)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "PgOTP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "PgOTP"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblheader As Label
    Friend WithEvents kode1 As TextBox
    Friend WithEvents kode2 As TextBox
    Friend WithEvents kode3 As TextBox
    Friend WithEvents kode4 As TextBox
    Friend WithEvents kode5 As TextBox
    Friend WithEvents kode6 As TextBox
    Friend WithEvents Lblname As Label
    Friend WithEvents btnclose As Button
End Class
