<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class WACreateAForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WACreateAForm))
        Me.qwaserver = New System.Windows.Forms.RadioButton()
        Me.qwascanqr = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtToken = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAkunID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSubscribe = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtTglExpired = New System.Windows.Forms.TextBox()
        Me.BtnAdding = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtMaxWA = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'qwaserver
        '
        Me.qwaserver.AutoSize = True
        Me.qwaserver.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.qwaserver.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.qwaserver.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qwaserver.ForeColor = System.Drawing.Color.White
        Me.qwaserver.Location = New System.Drawing.Point(220, 12)
        Me.qwaserver.Name = "qwaserver"
        Me.qwaserver.Size = New System.Drawing.Size(199, 24)
        Me.qwaserver.TabIndex = 212
        Me.qwaserver.TabStop = True
        Me.qwaserver.Text = "Buat Akun WASERVER"
        Me.qwaserver.UseVisualStyleBackColor = False
        '
        'qwascanqr
        '
        Me.qwascanqr.AutoSize = True
        Me.qwascanqr.BackColor = System.Drawing.Color.FromArgb(CType(CType(160, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.qwascanqr.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.qwascanqr.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.qwascanqr.ForeColor = System.Drawing.Color.White
        Me.qwascanqr.Location = New System.Drawing.Point(12, 12)
        Me.qwascanqr.Name = "qwascanqr"
        Me.qwascanqr.Size = New System.Drawing.Size(199, 24)
        Me.qwascanqr.TabIndex = 211
        Me.qwascanqr.TabStop = True
        Me.qwascanqr.Text = "Buat Akun WASCANQR"
        Me.qwascanqr.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(12, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 13)
        Me.Label7.TabIndex = 250
        Me.Label7.Text = "Masukin Token :"
        '
        'txtToken
        '
        Me.txtToken.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtToken.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtToken.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtToken.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToken.ForeColor = System.Drawing.Color.White
        Me.txtToken.Location = New System.Drawing.Point(12, 64)
        Me.txtToken.Multiline = True
        Me.txtToken.Name = "txtToken"
        Me.txtToken.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtToken.Size = New System.Drawing.Size(261, 151)
        Me.txtToken.TabIndex = 249
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(282, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 252
        Me.Label1.Text = "AKUNID :"
        '
        'txtAkunID
        '
        Me.txtAkunID.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.txtAkunID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAkunID.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtAkunID.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAkunID.ForeColor = System.Drawing.Color.White
        Me.txtAkunID.Location = New System.Drawing.Point(285, 64)
        Me.txtAkunID.Name = "txtAkunID"
        Me.txtAkunID.ReadOnly = True
        Me.txtAkunID.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtAkunID.Size = New System.Drawing.Size(168, 31)
        Me.txtAkunID.TabIndex = 251
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(282, 103)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 254
        Me.Label2.Text = "Subscribe :"
        '
        'TxtSubscribe
        '
        Me.TxtSubscribe.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtSubscribe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubscribe.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtSubscribe.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubscribe.ForeColor = System.Drawing.Color.White
        Me.TxtSubscribe.Location = New System.Drawing.Point(285, 121)
        Me.TxtSubscribe.Name = "TxtSubscribe"
        Me.TxtSubscribe.ReadOnly = True
        Me.TxtSubscribe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtSubscribe.Size = New System.Drawing.Size(119, 31)
        Me.TxtSubscribe.TabIndex = 253
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(407, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Tanggal Expired :"
        '
        'TxtTglExpired
        '
        Me.TxtTglExpired.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtTglExpired.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtTglExpired.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtTglExpired.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTglExpired.ForeColor = System.Drawing.Color.White
        Me.TxtTglExpired.Location = New System.Drawing.Point(410, 121)
        Me.TxtTglExpired.Name = "TxtTglExpired"
        Me.TxtTglExpired.ReadOnly = True
        Me.TxtTglExpired.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTglExpired.Size = New System.Drawing.Size(134, 31)
        Me.TxtTglExpired.TabIndex = 255
        '
        'BtnAdding
        '
        Me.BtnAdding.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnAdding.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnAdding.Enabled = False
        Me.BtnAdding.FlatAppearance.BorderSize = 0
        Me.BtnAdding.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnAdding.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAdding.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnAdding.Image = CType(resources.GetObject("BtnAdding.Image"), System.Drawing.Image)
        Me.BtnAdding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnAdding.Location = New System.Drawing.Point(310, 162)
        Me.BtnAdding.Name = "BtnAdding"
        Me.BtnAdding.Size = New System.Drawing.Size(207, 42)
        Me.BtnAdding.TabIndex = 257
        Me.BtnAdding.Text = "Aktifkan Akun "
        Me.BtnAdding.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(457, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 13)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "Max Whatsapp :"
        '
        'TxtMaxWA
        '
        Me.TxtMaxWA.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtMaxWA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMaxWA.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtMaxWA.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxWA.ForeColor = System.Drawing.Color.White
        Me.TxtMaxWA.Location = New System.Drawing.Point(459, 64)
        Me.TxtMaxWA.Name = "TxtMaxWA"
        Me.TxtMaxWA.ReadOnly = True
        Me.TxtMaxWA.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtMaxWA.Size = New System.Drawing.Size(85, 31)
        Me.TxtMaxWA.TabIndex = 258
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(215, 48)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(58, 13)
        Me.Label21.TabIndex = 260
        Me.Label21.Text = "edit Token"
        '
        'WACreateAForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(549, 227)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMaxWA)
        Me.Controls.Add(Me.BtnAdding)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtTglExpired)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSubscribe)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAkunID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtToken)
        Me.Controls.Add(Me.qwaserver)
        Me.Controls.Add(Me.qwascanqr)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "WACreateAForm"
        Me.Text = "WAForwardForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents qwaserver As RadioButton
    Friend WithEvents qwascanqr As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents txtToken As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtAkunID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TxtSubscribe As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtTglExpired As TextBox
    Friend WithEvents BtnAdding As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtMaxWA As TextBox
    Friend WithEvents Label21 As Label
End Class
