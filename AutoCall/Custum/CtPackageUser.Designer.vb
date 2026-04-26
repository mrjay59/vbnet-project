<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class CtPackageUser
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.LblPrice = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnBeli = New System.Windows.Forms.Button()
        Me.lbPaket = New System.Windows.Forms.Label()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'LblPrice
        '
        Me.LblPrice.Font = New System.Drawing.Font("Microsoft YaHei UI", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrice.ForeColor = System.Drawing.Color.White
        Me.LblPrice.Location = New System.Drawing.Point(5, 32)
        Me.LblPrice.Name = "LblPrice"
        Me.LblPrice.Size = New System.Drawing.Size(255, 38)
        Me.LblPrice.TabIndex = 0
        Me.LblPrice.Text = "Rp 125.000"
        Me.LblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft New Tai Lue", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(9, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Harga :"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(13, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(235, 2)
        Me.Panel1.TabIndex = 2
        '
        'BtnBeli
        '
        Me.BtnBeli.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnBeli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnBeli.FlatAppearance.BorderSize = 0
        Me.BtnBeli.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnBeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnBeli.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnBeli.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnBeli.Location = New System.Drawing.Point(228, 3)
        Me.BtnBeli.Name = "BtnBeli"
        Me.BtnBeli.Size = New System.Drawing.Size(55, 23)
        Me.BtnBeli.TabIndex = 187
        Me.BtnBeli.Text = "Beli"
        Me.BtnBeli.UseVisualStyleBackColor = False
        '
        'lbPaket
        '
        Me.lbPaket.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lbPaket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lbPaket.Font = New System.Drawing.Font("Cambria", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPaket.ForeColor = System.Drawing.Color.White
        Me.lbPaket.Location = New System.Drawing.Point(143, 3)
        Me.lbPaket.Name = "lbPaket"
        Me.lbPaket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lbPaket.Size = New System.Drawing.Size(79, 23)
        Me.lbPaket.TabIndex = 188
        Me.lbPaket.Text = "FREE"
        Me.lbPaket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPusat.Location = New System.Drawing.Point(0, 82)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(286, 334)
        Me.PanelPusat.TabIndex = 189
        '
        'CtPackageUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(75, Byte), Integer), CType(CType(76, Byte), Integer))
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.lbPaket)
        Me.Controls.Add(Me.BtnBeli)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblPrice)
        Me.Name = "CtPackageUser"
        Me.Size = New System.Drawing.Size(286, 416)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblPrice As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents BtnBeli As Button
    Friend WithEvents lbPaket As Label
    Friend WithEvents PanelPusat As Panel
End Class
