<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class pgset1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pgset1))
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Pcbarcode = New System.Windows.Forms.PictureBox()
        Me.BtnNext = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.LbValid = New System.Windows.Forms.Label()
        CType(Me.Pcbarcode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label12
        '
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Microsoft PhagsPa", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(219, 34)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(269, 112)
        Me.Label12.TabIndex = 197
        Me.Label12.Text = "Bagaimana Caranya " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "1. Silahkan buka WhatsApp " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2. Lalu Klik Icon Foto Pada Whats" &
    "App" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3. Lakukan Scan Barcode Disamping" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "4. Kirim Pesan Tersebut ke nomer tertuju" &
    "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "5. Tunggu Sebentar validasi"
        '
        'Pcbarcode
        '
        Me.Pcbarcode.Location = New System.Drawing.Point(15, 34)
        Me.Pcbarcode.Name = "Pcbarcode"
        Me.Pcbarcode.Size = New System.Drawing.Size(198, 200)
        Me.Pcbarcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pcbarcode.TabIndex = 195
        Me.Pcbarcode.TabStop = False
        '
        'BtnNext
        '
        Me.BtnNext.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.BtnNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnNext.FlatAppearance.BorderSize = 0
        Me.BtnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnNext.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnNext.Image = CType(resources.GetObject("BtnNext.Image"), System.Drawing.Image)
        Me.BtnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnNext.Location = New System.Drawing.Point(107, 240)
        Me.BtnNext.Name = "BtnNext"
        Me.BtnNext.Size = New System.Drawing.Size(313, 51)
        Me.BtnNext.TabIndex = 196
        Me.BtnNext.Text = "Langkah Selanjutnya Isi Form Register"
        Me.BtnNext.UseVisualStyleBackColor = False
        Me.BtnNext.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 3000
        '
        'LbValid
        '
        Me.LbValid.Font = New System.Drawing.Font("Microsoft YaHei UI", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbValid.ForeColor = System.Drawing.Color.White
        Me.LbValid.Image = CType(resources.GetObject("LbValid.Image"), System.Drawing.Image)
        Me.LbValid.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LbValid.Location = New System.Drawing.Point(257, 161)
        Me.LbValid.Name = "LbValid"
        Me.LbValid.Size = New System.Drawing.Size(163, 48)
        Me.LbValid.TabIndex = 198
        Me.LbValid.Text = "Valid"
        Me.LbValid.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.LbValid.Visible = False
        '
        'pgset1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 300)
        Me.Controls.Add(Me.LbValid)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Pcbarcode)
        Me.Controls.Add(Me.BtnNext)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pgset1"
        Me.Text = "pgset1"
        CType(Me.Pcbarcode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label12 As Label
    Friend WithEvents Pcbarcode As PictureBox
    Friend WithEvents BtnNext As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LbValid As Label
End Class
