<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class add_cloud
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(add_cloud))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnscan = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.btnclose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PanelPusat = New AutoCall.RoundedPanel()
        Me.lbIdle = New AutoCall.UCformtext()
        Me.lbTipeAkun = New AutoCall.UCformtext()
        Me.LblConcurrent = New AutoCall.UCformtext()
        Me.BtnAdding = New System.Windows.Forms.Button()
        Me.LblTglExpire = New AutoCall.UCformtext()
        Me.LblTglCreate = New AutoCall.UCformtext()
        Me.LblAkunId = New AutoCall.UCformtext()
        Me.PanelPusat.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Bodoni MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(6, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(319, 28)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Step 1 : Input Token"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnscan
        '
        Me.btnscan.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnscan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnscan.FlatAppearance.BorderSize = 0
        Me.btnscan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnscan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnscan.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnscan.Image = CType(resources.GetObject("btnscan.Image"), System.Drawing.Image)
        Me.btnscan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnscan.Location = New System.Drawing.Point(249, 233)
        Me.btnscan.Name = "btnscan"
        Me.btnscan.Size = New System.Drawing.Size(80, 39)
        Me.btnscan.TabIndex = 228
        Me.btnscan.Text = "Scan"
        Me.btnscan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnscan.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(23, 110)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 231
        Me.Label7.Text = "Masukin Token :"
        '
        'txtToken
        '
        Me.txtToken.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToken.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtToken.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToken.ForeColor = System.Drawing.Color.White
        Me.txtToken.Location = New System.Drawing.Point(13, 126)
        Me.txtToken.Multiline = True
        Me.txtToken.Name = "txtToken"
        Me.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtToken.Size = New System.Drawing.Size(316, 101)
        Me.txtToken.TabIndex = 230
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
        Me.btnclose.Location = New System.Drawing.Point(296, 13)
        Me.btnclose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnclose.Name = "btnclose"
        Me.btnclose.Size = New System.Drawing.Size(33, 25)
        Me.btnclose.TabIndex = 232
        Me.btnclose.Text = "X"
        Me.btnclose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(5, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(226, 24)
        Me.Label1.TabIndex = 233
        Me.Label1.Text = "Tambahkan device Cloud"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Bodoni MT", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(10, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(319, 28)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "Step  2 : Data Akun"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoSizeHeight = False
        Me.PanelPusat.BorderColor = System.Drawing.Color.Gray
        Me.PanelPusat.BorderWidth = 1
        Me.PanelPusat.Controls.Add(Me.lbIdle)
        Me.PanelPusat.Controls.Add(Me.lbTipeAkun)
        Me.PanelPusat.Controls.Add(Me.LblConcurrent)
        Me.PanelPusat.Controls.Add(Me.BtnAdding)
        Me.PanelPusat.Controls.Add(Me.LblTglExpire)
        Me.PanelPusat.Controls.Add(Me.LblTglCreate)
        Me.PanelPusat.Controls.Add(Me.LblAkunId)
        Me.PanelPusat.CornerRadius = 10
        Me.PanelPusat.Location = New System.Drawing.Point(9, 324)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.RoundingStyle = AutoCall.RoundedPanel.RoundStyle.All
        Me.PanelPusat.Size = New System.Drawing.Size(320, 290)
        Me.PanelPusat.TabIndex = 229
        '
        'lbIdle
        '
        Me.lbIdle.BackColor = System.Drawing.Color.Transparent
        Me.lbIdle.Location = New System.Drawing.Point(153, 175)
        Me.lbIdle.Name = "lbIdle"
        Me.lbIdle.Size = New System.Drawing.Size(167, 62)
        Me.lbIdle.TabIndex = 238
        '
        'lbTipeAkun
        '
        Me.lbTipeAkun.BackColor = System.Drawing.Color.Transparent
        Me.lbTipeAkun.Location = New System.Drawing.Point(4, 175)
        Me.lbTipeAkun.Name = "lbTipeAkun"
        Me.lbTipeAkun.Size = New System.Drawing.Size(166, 62)
        Me.lbTipeAkun.TabIndex = 237
        '
        'LblConcurrent
        '
        Me.LblConcurrent.BackColor = System.Drawing.Color.Transparent
        Me.LblConcurrent.Location = New System.Drawing.Point(176, 7)
        Me.LblConcurrent.Name = "LblConcurrent"
        Me.LblConcurrent.Size = New System.Drawing.Size(144, 63)
        Me.LblConcurrent.TabIndex = 236
        '
        'BtnAdding
        '
        Me.BtnAdding.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnAdding.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdding.FlatAppearance.BorderSize = 0
        Me.BtnAdding.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdding.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdding.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAdding.Image = CType(resources.GetObject("BtnAdding.Image"), System.Drawing.Image)
        Me.BtnAdding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdding.Location = New System.Drawing.Point(176, 240)
        Me.BtnAdding.Name = "BtnAdding"
        Me.BtnAdding.Size = New System.Drawing.Size(139, 44)
        Me.BtnAdding.TabIndex = 235
        Me.BtnAdding.Text = "Aktifkan Akun"
        Me.BtnAdding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnAdding.UseVisualStyleBackColor = False
        '
        'LblTglExpire
        '
        Me.LblTglExpire.BackColor = System.Drawing.Color.Transparent
        Me.LblTglExpire.Location = New System.Drawing.Point(4, 121)
        Me.LblTglExpire.Name = "LblTglExpire"
        Me.LblTglExpire.Size = New System.Drawing.Size(316, 62)
        Me.LblTglExpire.TabIndex = 115
        '
        'LblTglCreate
        '
        Me.LblTglCreate.BackColor = System.Drawing.Color.Transparent
        Me.LblTglCreate.Location = New System.Drawing.Point(4, 63)
        Me.LblTglCreate.Name = "LblTglCreate"
        Me.LblTglCreate.Size = New System.Drawing.Size(316, 62)
        Me.LblTglCreate.TabIndex = 114
        '
        'LblAkunId
        '
        Me.LblAkunId.BackColor = System.Drawing.Color.Transparent
        Me.LblAkunId.Location = New System.Drawing.Point(4, 8)
        Me.LblAkunId.Name = "LblAkunId"
        Me.LblAkunId.Size = New System.Drawing.Size(191, 62)
        Me.LblAkunId.TabIndex = 112
        '
        'add_cloud
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(81, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(341, 626)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnclose)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtToken)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.btnscan)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "add_cloud"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "add_cloud"
        Me.PanelPusat.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PanelPusat As RoundedPanel
    Friend WithEvents btnscan As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtToken As TextBox
    Friend WithEvents btnclose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents LblTglCreate As UCformtext
    Friend WithEvents LblAkunId As UCformtext
    Friend WithEvents LblTglExpire As UCformtext
    Friend WithEvents BtnAdding As Button
    Friend WithEvents LblConcurrent As UCformtext
    Friend WithEvents lbIdle As UCformtext
    Friend WithEvents lbTipeAkun As UCformtext
End Class
