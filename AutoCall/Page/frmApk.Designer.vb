<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmApk
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
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BtnPaket = New System.Windows.Forms.Button()
        Me.BtnProduk = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.Panelgb = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Malgun Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 32)
        Me.Label4.TabIndex = 196
        Me.Label4.Text = "Market"
        '
        'BtnPaket
        '
        Me.BtnPaket.BackColor = System.Drawing.Color.FromArgb(CType(CType(110, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnPaket.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPaket.FlatAppearance.BorderSize = 0
        Me.BtnPaket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaket.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaket.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPaket.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnPaket.Location = New System.Drawing.Point(33, 51)
        Me.BtnPaket.Name = "BtnPaket"
        Me.BtnPaket.Size = New System.Drawing.Size(67, 34)
        Me.BtnPaket.TabIndex = 197
        Me.BtnPaket.Text = "Paket"
        Me.BtnPaket.UseVisualStyleBackColor = False
        '
        'BtnProduk
        '
        Me.BtnProduk.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(165, Byte), Integer), CType(CType(190, Byte), Integer))
        Me.BtnProduk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnProduk.FlatAppearance.BorderSize = 0
        Me.BtnProduk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProduk.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProduk.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnProduk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProduk.Location = New System.Drawing.Point(122, 51)
        Me.BtnProduk.Name = "BtnProduk"
        Me.BtnProduk.Size = New System.Drawing.Size(80, 34)
        Me.BtnProduk.TabIndex = 198
        Me.BtnProduk.Text = "Produk"
        Me.BtnProduk.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(70, Byte), Integer), CType(CType(91, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(12, 44)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(900, 1)
        Me.Panel2.TabIndex = 199
        '
        'PanelPusat
        '
        Me.PanelPusat.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PanelPusat.Location = New System.Drawing.Point(0, 91)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(940, 499)
        Me.PanelPusat.TabIndex = 200
        '
        'Panelgb
        '
        Me.Panelgb.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Panelgb.Location = New System.Drawing.Point(221, 80)
        Me.Panelgb.Name = "Panelgb"
        Me.Panelgb.Size = New System.Drawing.Size(100, 5)
        Me.Panelgb.TabIndex = 137
        Me.Panelgb.Visible = False
        '
        'frmApk
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(940, 590)
        Me.Controls.Add(Me.Panelgb)
        Me.Controls.Add(Me.PanelPusat)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnProduk)
        Me.Controls.Add(Me.BtnPaket)
        Me.Controls.Add(Me.Label4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmApk"
        Me.Text = "frmApk"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label4 As Label
    Friend WithEvents BtnPaket As Button
    Friend WithEvents BtnProduk As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents Panelgb As Panel
End Class
