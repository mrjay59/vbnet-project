<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pgVerifyNumber
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(pgVerifyNumber))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BtnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.RoundedPanel1 = New AutoCall.RoundedPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblTotData = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New AutoCall.RoundedPanel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RoundedPanel3 = New AutoCall.RoundedPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.RoundedPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Gray
        Me.Panel2.Controls.Add(Me.BtnClose)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(467, 41)
        Me.Panel2.TabIndex = 6
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Gray
        Me.BtnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnClose.FlatAppearance.BorderSize = 0
        Me.BtnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(241, Byte), Integer), CType(CType(112, Byte), Integer), CType(CType(112, Byte), Integer))
        Me.BtnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(232, Byte), Integer), CType(CType(17, Byte), Integer), CType(CType(35, Byte), Integer))
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.ForeColor = System.Drawing.Color.White
        Me.BtnClose.Location = New System.Drawing.Point(425, 0)
        Me.BtnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(42, 41)
        Me.BtnClose.TabIndex = 250
        Me.BtnClose.Text = "X"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Lucida Sans Unicode", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(12, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(137, 20)
        Me.Label1.TabIndex = 182
        Me.Label1.Text = "Verify Number"
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(278, 187)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(177, 36)
        Me.btnSend.TabIndex = 249
        Me.btnSend.Text = "Masukin Data Verify"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.AutoSizeHeight = False
        Me.RoundedPanel1.BorderColor = System.Drawing.Color.Gray
        Me.RoundedPanel1.BorderWidth = 1
        Me.RoundedPanel1.Controls.Add(Me.Label2)
        Me.RoundedPanel1.Controls.Add(Me.lblTotData)
        Me.RoundedPanel1.CornerRadius = 10
        Me.RoundedPanel1.Location = New System.Drawing.Point(25, 239)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.RoundingStyle = AutoCall.RoundedPanel.RoundStyle.All
        Me.RoundedPanel1.Size = New System.Drawing.Size(108, 100)
        Me.RoundedPanel1.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Microsoft New Tai Lue", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(4, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 31)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "2000"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblTotData
        '
        Me.lblTotData.AutoSize = True
        Me.lblTotData.Font = New System.Drawing.Font("Microsoft New Tai Lue", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotData.ForeColor = System.Drawing.Color.White
        Me.lblTotData.Location = New System.Drawing.Point(22, 19)
        Me.lblTotData.Name = "lblTotData"
        Me.lblTotData.Size = New System.Drawing.Size(68, 17)
        Me.lblTotData.TabIndex = 0
        Me.lblTotData.Text = "Total Data"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.AutoSizeHeight = False
        Me.RoundedPanel2.BorderColor = System.Drawing.Color.Gray
        Me.RoundedPanel2.BorderWidth = 1
        Me.RoundedPanel2.Controls.Add(Me.Label3)
        Me.RoundedPanel2.Controls.Add(Me.Label4)
        Me.RoundedPanel2.CornerRadius = 10
        Me.RoundedPanel2.Location = New System.Drawing.Point(179, 239)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.RoundingStyle = AutoCall.RoundedPanel.RoundStyle.All
        Me.RoundedPanel2.Size = New System.Drawing.Size(108, 100)
        Me.RoundedPanel2.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Microsoft New Tai Lue", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(4, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 31)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "2000"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft New Tai Lue", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(35, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 17)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Verify"
        '
        'RoundedPanel3
        '
        Me.RoundedPanel3.AutoSizeHeight = False
        Me.RoundedPanel3.BorderColor = System.Drawing.Color.Gray
        Me.RoundedPanel3.BorderWidth = 1
        Me.RoundedPanel3.Controls.Add(Me.Label5)
        Me.RoundedPanel3.Controls.Add(Me.Label6)
        Me.RoundedPanel3.CornerRadius = 10
        Me.RoundedPanel3.Location = New System.Drawing.Point(333, 239)
        Me.RoundedPanel3.Name = "RoundedPanel3"
        Me.RoundedPanel3.RoundingStyle = AutoCall.RoundedPanel.RoundStyle.All
        Me.RoundedPanel3.Size = New System.Drawing.Size(108, 100)
        Me.RoundedPanel3.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Microsoft New Tai Lue", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 31)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "2000"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft New Tai Lue", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(21, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 17)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Not Verify"
        '
        'BtnPaste
        '
        Me.BtnPaste.BackColor = System.Drawing.Color.Transparent
        Me.BtnPaste.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnPaste.FlatAppearance.BorderSize = 0
        Me.BtnPaste.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnPaste.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPaste.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnPaste.Image = CType(resources.GetObject("BtnPaste.Image"), System.Drawing.Image)
        Me.BtnPaste.Location = New System.Drawing.Point(430, 51)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(25, 25)
        Me.BtnPaste.TabIndex = 252
        Me.BtnPaste.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(23, 57)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(153, 13)
        Me.Label7.TabIndex = 251
        Me.Label7.Text = "Enter Number : min 2 s.d 1000 "
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumber.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TxtNumber.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.ForeColor = System.Drawing.Color.White
        Me.TxtNumber.Location = New System.Drawing.Point(20, 80)
        Me.TxtNumber.Multiline = True
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.ReadOnly = True
        Me.TxtNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNumber.Size = New System.Drawing.Size(435, 101)
        Me.TxtNumber.TabIndex = 250
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(128, 187)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 36)
        Me.Button1.TabIndex = 253
        Me.Button1.Text = "Convert Vcard"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'pgVerifyNumber
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(467, 358)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.RoundedPanel3)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "pgVerifyNumber"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "pgVerifyNumber"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.RoundedPanel3.ResumeLayout(False)
        Me.RoundedPanel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents RoundedPanel3 As RoundedPanel
    Friend WithEvents btnSend As Button
    Friend WithEvents BtnClose As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblTotData As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents BtnPaste As Button
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents Button1 As Button
End Class
