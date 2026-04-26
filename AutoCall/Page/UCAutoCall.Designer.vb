<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UCAutoCall
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UCAutoCall))
        Me.BtnLink = New System.Windows.Forms.Button()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblfiname = New System.Windows.Forms.Label()
        Me.TotData = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComApk = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtLink = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Dtsleep = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.calldurasi = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Ulangi = New System.Windows.Forms.NumericUpDown()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.lburut = New System.Windows.Forms.Label()
        Me.lbstatus = New System.Windows.Forms.Label()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.BtnStart = New System.Windows.Forms.Button()
        CType(Me.TotData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dtsleep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.calldurasi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Ulangi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BtnLink
        '
        Me.BtnLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnLink.ForeColor = System.Drawing.Color.White
        Me.BtnLink.Image = CType(resources.GetObject("BtnLink.Image"), System.Drawing.Image)
        Me.BtnLink.Location = New System.Drawing.Point(163, 94)
        Me.BtnLink.Name = "BtnLink"
        Me.BtnLink.Size = New System.Drawing.Size(23, 23)
        Me.BtnLink.TabIndex = 83
        Me.BtnLink.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(72, 253)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(52, 17)
        Me.rd1.TabIndex = 181
        Me.rd1.TabStop = True
        Me.rd1.Text = "Tidak"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(19, 253)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(38, 17)
        Me.rd0.TabIndex = 180
        Me.rd0.TabStop = True
        Me.rd0.Text = "Ya"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(141, 16)
        Me.Label7.TabIndex = 179
        Me.Label7.Text = "Bisa melakukan komunikasi ?"
        '
        'lblfiname
        '
        Me.lblfiname.AutoSize = True
        Me.lblfiname.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.lblfiname.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblfiname.Font = New System.Drawing.Font("Book Antiqua", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfiname.ForeColor = System.Drawing.Color.White
        Me.lblfiname.Location = New System.Drawing.Point(87, 74)
        Me.lblfiname.Name = "lblfiname"
        Me.lblfiname.Size = New System.Drawing.Size(70, 18)
        Me.lblfiname.TabIndex = 84
        Me.lblfiname.Text = "Contoh File"
        '
        'TotData
        '
        Me.TotData.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotData.ForeColor = System.Drawing.Color.White
        Me.TotData.Increment = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TotData.Location = New System.Drawing.Point(127, 142)
        Me.TotData.Maximum = New Decimal(New Integer() {350, 0, 0, 0})
        Me.TotData.Name = "TotData"
        Me.TotData.ReadOnly = True
        Me.TotData.Size = New System.Drawing.Size(53, 20)
        Me.TotData.TabIndex = 23
        Me.TotData.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(14, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Apk Dial"
        '
        'ComApk
        '
        Me.ComApk.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ComApk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ComApk.ForeColor = System.Drawing.Color.White
        Me.ComApk.FormattingEnabled = True
        Me.ComApk.Location = New System.Drawing.Point(14, 141)
        Me.ComApk.Name = "ComApk"
        Me.ComApk.Size = New System.Drawing.Size(110, 21)
        Me.ComApk.TabIndex = 72
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(17, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 16)
        Me.Label1.TabIndex = 80
        Me.Label1.Text = "Pilih File Txt"
        '
        'TxtLink
        '
        Me.TxtLink.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtLink.Font = New System.Drawing.Font("Microsoft YaHei UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLink.ForeColor = System.Drawing.Color.White
        Me.TxtLink.Location = New System.Drawing.Point(12, 94)
        Me.TxtLink.Name = "TxtLink"
        Me.TxtLink.ReadOnly = True
        Me.TxtLink.Size = New System.Drawing.Size(148, 24)
        Me.TxtLink.TabIndex = 79
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(124, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 16)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Data"
        '
        'Dtsleep
        '
        Me.Dtsleep.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Dtsleep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Dtsleep.ForeColor = System.Drawing.Color.White
        Me.Dtsleep.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Dtsleep.Location = New System.Drawing.Point(126, 194)
        Me.Dtsleep.Maximum = New Decimal(New Integer() {45, 0, 0, 0})
        Me.Dtsleep.Minimum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.Dtsleep.Name = "Dtsleep"
        Me.Dtsleep.ReadOnly = True
        Me.Dtsleep.Size = New System.Drawing.Size(54, 20)
        Me.Dtsleep.TabIndex = 21
        Me.Dtsleep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Dtsleep.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(124, 177)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Delay"
        '
        'calldurasi
        '
        Me.calldurasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.calldurasi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.calldurasi.ForeColor = System.Drawing.Color.White
        Me.calldurasi.Increment = New Decimal(New Integer() {30, 0, 0, 0})
        Me.calldurasi.Location = New System.Drawing.Point(13, 193)
        Me.calldurasi.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.calldurasi.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.calldurasi.Name = "calldurasi"
        Me.calldurasi.ReadOnly = True
        Me.calldurasi.Size = New System.Drawing.Size(56, 20)
        Me.calldurasi.TabIndex = 19
        Me.calldurasi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.calldurasi.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 16)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "Durasi"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(72, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "ReCall"
        '
        'Ulangi
        '
        Me.Ulangi.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Ulangi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Ulangi.ForeColor = System.Drawing.Color.White
        Me.Ulangi.Location = New System.Drawing.Point(74, 193)
        Me.Ulangi.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.Ulangi.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.Ulangi.Name = "Ulangi"
        Me.Ulangi.ReadOnly = True
        Me.Ulangi.Size = New System.Drawing.Size(50, 20)
        Me.Ulangi.TabIndex = 11
        Me.Ulangi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Ulangi.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'lburut
        '
        Me.lburut.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(71, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.lburut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lburut.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lburut.ForeColor = System.Drawing.Color.White
        Me.lburut.Location = New System.Drawing.Point(0, 0)
        Me.lburut.Name = "lburut"
        Me.lburut.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lburut.Size = New System.Drawing.Size(30, 30)
        Me.lburut.TabIndex = 183
        Me.lburut.Text = "1"
        Me.lburut.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbstatus
        '
        Me.lbstatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbstatus.Font = New System.Drawing.Font("Yu Gothic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbstatus.ForeColor = System.Drawing.Color.White
        Me.lbstatus.Location = New System.Drawing.Point(4, 36)
        Me.lbstatus.Name = "lbstatus"
        Me.lbstatus.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbstatus.Size = New System.Drawing.Size(198, 30)
        Me.lbstatus.TabIndex = 185
        Me.lbstatus.Text = "Keterangan"
        Me.lbstatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Red
        Me.BtnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClose.FlatAppearance.BorderSize = 0
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.Black
        Me.BtnClose.Location = New System.Drawing.Point(38, 0)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(44, 30)
        Me.BtnClose.TabIndex = 184
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        Me.BtnClose.Visible = False
        '
        'BtnStart
        '
        Me.BtnStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStart.FlatAppearance.BorderSize = 0
        Me.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStart.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnStart.Image = CType(resources.GetObject("BtnStart.Image"), System.Drawing.Image)
        Me.BtnStart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStart.Location = New System.Drawing.Point(90, 0)
        Me.BtnStart.Name = "BtnStart"
        Me.BtnStart.Size = New System.Drawing.Size(112, 30)
        Me.BtnStart.TabIndex = 186
        Me.BtnStart.Text = "Start Call"
        Me.BtnStart.UseVisualStyleBackColor = False
        '
        'UCAutoCall
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Controls.Add(Me.BtnStart)
        Me.Controls.Add(Me.lbstatus)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.lburut)
        Me.Controls.Add(Me.BtnLink)
        Me.Controls.Add(Me.TxtLink)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.calldurasi)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Dtsleep)
        Me.Controls.Add(Me.lblfiname)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rd0)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Ulangi)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ComApk)
        Me.Controls.Add(Me.TotData)
        Me.Name = "UCAutoCall"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Size = New System.Drawing.Size(205, 282)
        CType(Me.TotData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dtsleep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.calldurasi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Ulangi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnLink As Button
    Friend WithEvents TotData As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents ComApk As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtLink As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Dtsleep As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents calldurasi As NumericUpDown
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Ulangi As NumericUpDown
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents lblfiname As Label
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents lburut As Label
    Friend WithEvents lbstatus As Label
    Friend WithEvents BtnClose As Button
    Friend WithEvents BtnStart As Button
End Class
