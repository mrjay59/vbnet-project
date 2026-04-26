<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTraningWA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTraningWA))
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnlogActivty = New System.Windows.Forms.Panel()
        Me.lstLog = New System.Windows.Forms.ListBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnStopCall = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.BtnProses = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BtnCreate = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TotWA = New System.Windows.Forms.NumericUpDown()
        Me.PanelPusat = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4.SuspendLayout()
        Me.PnlogActivty.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TotWA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PnlogActivty)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(531, 13)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 435)
        Me.Panel4.TabIndex = 224
        '
        'PnlogActivty
        '
        Me.PnlogActivty.AutoScroll = True
        Me.PnlogActivty.Controls.Add(Me.lstLog)
        Me.PnlogActivty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlogActivty.Location = New System.Drawing.Point(0, 41)
        Me.PnlogActivty.Name = "PnlogActivty"
        Me.PnlogActivty.Size = New System.Drawing.Size(400, 394)
        Me.PnlogActivty.TabIndex = 144
        '
        'lstLog
        '
        Me.lstLog.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstLog.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstLog.Font = New System.Drawing.Font("Microsoft New Tai Lue", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstLog.ForeColor = System.Drawing.Color.White
        Me.lstLog.FormattingEnabled = True
        Me.lstLog.ItemHeight = 15
        Me.lstLog.Location = New System.Drawing.Point(0, 0)
        Me.lstLog.Margin = New System.Windows.Forms.Padding(10)
        Me.lstLog.Name = "lstLog"
        Me.lstLog.Size = New System.Drawing.Size(400, 394)
        Me.lstLog.TabIndex = 176
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Panel5.Controls.Add(Me.BtnStopCall)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(400, 41)
        Me.Panel5.TabIndex = 4
        '
        'BtnStopCall
        '
        Me.BtnStopCall.BackColor = System.Drawing.Color.DimGray
        Me.BtnStopCall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStopCall.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnStopCall.FlatAppearance.BorderSize = 0
        Me.BtnStopCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStopCall.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStopCall.ForeColor = System.Drawing.Color.Black
        Me.BtnStopCall.Image = CType(resources.GetObject("BtnStopCall.Image"), System.Drawing.Image)
        Me.BtnStopCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStopCall.Location = New System.Drawing.Point(282, 0)
        Me.BtnStopCall.Name = "BtnStopCall"
        Me.BtnStopCall.Size = New System.Drawing.Size(118, 41)
        Me.BtnStopCall.TabIndex = 183
        Me.BtnStopCall.Text = "Stop All"
        Me.BtnStopCall.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(104, 23)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Log Activity"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.BackColor = System.Drawing.Color.Transparent
        Me.lblStatus.Cursor = System.Windows.Forms.Cursors.Default
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.White
        Me.lblStatus.Location = New System.Drawing.Point(488, 53)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(0, 16)
        Me.lblStatus.TabIndex = 4
        Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblStatus.Visible = False
        '
        'BtnProses
        '
        Me.BtnProses.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.BtnProses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnProses.FlatAppearance.BorderSize = 0
        Me.BtnProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnProses.Font = New System.Drawing.Font("Lucida Sans Typewriter", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnProses.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnProses.Image = CType(resources.GetObject("BtnProses.Image"), System.Drawing.Image)
        Me.BtnProses.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnProses.Location = New System.Drawing.Point(368, 2)
        Me.BtnProses.Name = "BtnProses"
        Me.BtnProses.Size = New System.Drawing.Size(142, 36)
        Me.BtnProses.TabIndex = 231
        Me.BtnProses.Text = "Mulai Proses"
        Me.BtnProses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnProses.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblStatus)
        Me.Panel1.Controls.Add(Me.BtnCreate)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.TotWA)
        Me.Panel1.Controls.Add(Me.PanelPusat)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Location = New System.Drawing.Point(12, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(513, 435)
        Me.Panel1.TabIndex = 225
        '
        'BtnCreate
        '
        Me.BtnCreate.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnCreate.FlatAppearance.BorderSize = 0
        Me.BtnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCreate.ForeColor = System.Drawing.Color.White
        Me.BtnCreate.Location = New System.Drawing.Point(211, 50)
        Me.BtnCreate.Name = "BtnCreate"
        Me.BtnCreate.Size = New System.Drawing.Size(64, 23)
        Me.BtnCreate.TabIndex = 268
        Me.BtnCreate.Text = "Create"
        Me.BtnCreate.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Book Antiqua", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(6, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(95, 16)
        Me.Label12.TabIndex = 266
        Me.Label12.Text = "Jumlah Percakapan"
        '
        'TotWA
        '
        Me.TotWA.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotWA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotWA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotWA.ForeColor = System.Drawing.Color.White
        Me.TotWA.Increment = New Decimal(New Integer() {2, 0, 0, 0})
        Me.TotWA.Location = New System.Drawing.Point(117, 53)
        Me.TotWA.Name = "TotWA"
        Me.TotWA.Size = New System.Drawing.Size(88, 20)
        Me.TotWA.TabIndex = 267
        Me.TotWA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TotWA.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'PanelPusat
        '
        Me.PanelPusat.AutoScroll = True
        Me.PanelPusat.Location = New System.Drawing.Point(0, 79)
        Me.PanelPusat.Name = "PanelPusat"
        Me.PanelPusat.Size = New System.Drawing.Size(513, 356)
        Me.PanelPusat.TabIndex = 144
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(85, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Panel3.Controls.Add(Me.BtnProses)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(513, 41)
        Me.Panel3.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(5, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(151, 23)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Buat Percakapan"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmTraningWA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(943, 460)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel4)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmTraningWA"
        Me.Text = "FrmTraningWA"
        Me.Panel4.ResumeLayout(False)
        Me.PnlogActivty.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TotWA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnlogActivty As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents BtnProses As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PanelPusat As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label3 As Label
    Public WithEvents lstLog As ListBox
    Friend WithEvents Label12 As Label
    Friend WithEvents TotWA As NumericUpDown
    Friend WithEvents BtnCreate As Button
    Friend WithEvents lblStatus As Label
    Friend WithEvents BtnStopCall As Button
End Class
