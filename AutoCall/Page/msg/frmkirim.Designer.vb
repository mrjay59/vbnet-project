<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmkirim
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmkirim))
        Me.BtnTmpl = New System.Windows.Forms.Button()
        Me.Rrm = New System.Windows.Forms.RadioButton()
        Me.Rsm = New System.Windows.Forms.RadioButton()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TotSender = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Breaktime = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.breakmsg = New System.Windows.Forms.NumericUpDown()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Delay = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.PnlogActivty = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.BtnStopCall = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblCountState = New System.Windows.Forms.Label()
        Me.TxtMessage = New System.Windows.Forms.RichTextBox()
        Me.TxtSender = New System.Windows.Forms.TextBox()
        Me.BtnSelect = New System.Windows.Forms.Button()
        Me.rd4 = New System.Windows.Forms.RadioButton()
        Me.TxtNumber = New System.Windows.Forms.TextBox()
        Me.rd3 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSend = New System.Windows.Forms.Button()
        Me.rd1 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.rd0 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BtnContact = New System.Windows.Forms.Button()
        Me.BtnPaste = New System.Windows.Forms.Button()
        Me.LblTotData = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.RdWAD = New System.Windows.Forms.RadioButton()
        CType(Me.TotSender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Breaktime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.breakmsg, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Delay, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnTmpl
        '
        Me.BtnTmpl.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.BtnTmpl.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnTmpl.FlatAppearance.BorderSize = 0
        Me.BtnTmpl.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnTmpl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnTmpl.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnTmpl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnTmpl.Location = New System.Drawing.Point(283, 4)
        Me.BtnTmpl.Name = "BtnTmpl"
        Me.BtnTmpl.Size = New System.Drawing.Size(88, 27)
        Me.BtnTmpl.TabIndex = 268
        Me.BtnTmpl.Text = "Pilih Template"
        Me.BtnTmpl.UseVisualStyleBackColor = False
        '
        'Rrm
        '
        Me.Rrm.AutoSize = True
        Me.Rrm.ForeColor = System.Drawing.Color.White
        Me.Rrm.Location = New System.Drawing.Point(120, 8)
        Me.Rrm.Name = "Rrm"
        Me.Rrm.Size = New System.Drawing.Size(94, 17)
        Me.Rrm.TabIndex = 267
        Me.Rrm.TabStop = True
        Me.Rrm.Text = "Multi Template"
        Me.Rrm.UseVisualStyleBackColor = True
        '
        'Rsm
        '
        Me.Rsm.AutoSize = True
        Me.Rsm.ForeColor = System.Drawing.Color.White
        Me.Rsm.Location = New System.Drawing.Point(7, 7)
        Me.Rsm.Name = "Rsm"
        Me.Rsm.Size = New System.Drawing.Size(107, 17)
        Me.Rsm.TabIndex = 266
        Me.Rsm.TabStop = True
        Me.Rsm.Text = "Manual Template"
        Me.Rsm.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(36, 402)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(63, 13)
        Me.Label12.TabIndex = 264
        Me.Label12.Text = "Use Sender"
        '
        'TotSender
        '
        Me.TotSender.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TotSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotSender.Enabled = False
        Me.TotSender.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotSender.ForeColor = System.Drawing.Color.White
        Me.TotSender.Location = New System.Drawing.Point(27, 418)
        Me.TotSender.Name = "TotSender"
        Me.TotSender.ReadOnly = True
        Me.TotSender.Size = New System.Drawing.Size(84, 20)
        Me.TotSender.TabIndex = 265
        Me.TotSender.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(290, 438)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 263
        Me.Label9.Text = "Menit"
        '
        'Breaktime
        '
        Me.Breaktime.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Breaktime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Breaktime.ForeColor = System.Drawing.Color.White
        Me.Breaktime.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Breaktime.Location = New System.Drawing.Point(222, 436)
        Me.Breaktime.Maximum = New Decimal(New Integer() {30, 0, 0, 0})
        Me.Breaktime.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.Breaktime.Name = "Breaktime"
        Me.Breaktime.ReadOnly = True
        Me.Breaktime.Size = New System.Drawing.Size(64, 20)
        Me.Breaktime.TabIndex = 262
        Me.Breaktime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Breaktime.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(288, 409)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 261
        Me.Label6.Text = "Second/ Message"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(456, 440)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 13)
        Me.Label5.TabIndex = 260
        Me.Label5.Text = "Message"
        '
        'breakmsg
        '
        Me.breakmsg.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.breakmsg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.breakmsg.ForeColor = System.Drawing.Color.White
        Me.breakmsg.Increment = New Decimal(New Integer() {5, 0, 0, 0})
        Me.breakmsg.Location = New System.Drawing.Point(386, 436)
        Me.breakmsg.Maximum = New Decimal(New Integer() {50, 0, 0, 0})
        Me.breakmsg.Minimum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.breakmsg.Name = "breakmsg"
        Me.breakmsg.ReadOnly = True
        Me.breakmsg.Size = New System.Drawing.Size(64, 20)
        Me.breakmsg.TabIndex = 259
        Me.breakmsg.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.breakmsg.Value = New Decimal(New Integer() {5, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(347, 438)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 13)
        Me.Label1.TabIndex = 258
        Me.Label1.Text = "Every"
        '
        'Delay
        '
        Me.Delay.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.Delay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Delay.ForeColor = System.Drawing.Color.White
        Me.Delay.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        Me.Delay.Location = New System.Drawing.Point(221, 406)
        Me.Delay.Maximum = New Decimal(New Integer() {240, 0, 0, 0})
        Me.Delay.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.Delay.Name = "Delay"
        Me.Delay.ReadOnly = True
        Me.Delay.Size = New System.Drawing.Size(64, 20)
        Me.Delay.TabIndex = 257
        Me.Delay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.Delay.Value = New Decimal(New Integer() {30, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(133, 385)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 256
        Me.Label3.Text = "Delay Setting"
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.PnlogActivty)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Location = New System.Drawing.Point(509, 32)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(427, 419)
        Me.Panel4.TabIndex = 255
        '
        'PnlogActivty
        '
        Me.PnlogActivty.AutoScroll = True
        Me.PnlogActivty.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PnlogActivty.Location = New System.Drawing.Point(0, 41)
        Me.PnlogActivty.Name = "PnlogActivty"
        Me.PnlogActivty.Size = New System.Drawing.Size(427, 378)
        Me.PnlogActivty.TabIndex = 144
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Gray
        Me.Panel5.Controls.Add(Me.BtnStopCall)
        Me.Panel5.Controls.Add(Me.Button1)
        Me.Panel5.Controls.Add(Me.Label10)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(427, 41)
        Me.Panel5.TabIndex = 4
        '
        'BtnStopCall
        '
        Me.BtnStopCall.BackColor = System.Drawing.Color.DimGray
        Me.BtnStopCall.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnStopCall.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnStopCall.FlatAppearance.BorderSize = 0
        Me.BtnStopCall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStopCall.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnStopCall.ForeColor = System.Drawing.Color.Black
        Me.BtnStopCall.Image = CType(resources.GetObject("BtnStopCall.Image"), System.Drawing.Image)
        Me.BtnStopCall.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnStopCall.Location = New System.Drawing.Point(309, 0)
        Me.BtnStopCall.Name = "BtnStopCall"
        Me.BtnStopCall.Size = New System.Drawing.Size(118, 41)
        Me.BtnStopCall.TabIndex = 182
        Me.BtnStopCall.Text = "Stop All"
        Me.BtnStopCall.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.Transparent
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(432, 5)
        Me.Button1.Name = "Button1"
        Me.Button1.Padding = New System.Windows.Forms.Padding(5)
        Me.Button1.Size = New System.Drawing.Size(40, 30)
        Me.Button1.TabIndex = 78
        Me.Button1.UseVisualStyleBackColor = False
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
        'lblCountState
        '
        Me.lblCountState.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCountState.AutoSize = True
        Me.lblCountState.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblCountState.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCountState.ForeColor = System.Drawing.Color.White
        Me.lblCountState.Location = New System.Drawing.Point(760, 12)
        Me.lblCountState.Name = "lblCountState"
        Me.lblCountState.Size = New System.Drawing.Size(0, 13)
        Me.lblCountState.TabIndex = 259
        '
        'TxtMessage
        '
        Me.TxtMessage.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMessage.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMessage.ForeColor = System.Drawing.Color.White
        Me.TxtMessage.Location = New System.Drawing.Point(128, 259)
        Me.TxtMessage.Name = "TxtMessage"
        Me.TxtMessage.ReadOnly = True
        Me.TxtMessage.Size = New System.Drawing.Size(375, 119)
        Me.TxtMessage.TabIndex = 238
        Me.TxtMessage.Text = ""
        '
        'TxtSender
        '
        Me.TxtSender.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtSender.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSender.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSender.ForeColor = System.Drawing.Color.White
        Me.TxtSender.Location = New System.Drawing.Point(7, 37)
        Me.TxtSender.Multiline = True
        Me.TxtSender.Name = "TxtSender"
        Me.TxtSender.ReadOnly = True
        Me.TxtSender.Size = New System.Drawing.Size(116, 345)
        Me.TxtSender.TabIndex = 239
        '
        'BtnSelect
        '
        Me.BtnSelect.BackColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(95, Byte), Integer))
        Me.BtnSelect.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSelect.FlatAppearance.BorderSize = 0
        Me.BtnSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSelect.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSelect.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnSelect.Location = New System.Drawing.Point(16, 9)
        Me.BtnSelect.Name = "BtnSelect"
        Me.BtnSelect.Size = New System.Drawing.Size(95, 24)
        Me.BtnSelect.TabIndex = 240
        Me.BtnSelect.Text = "Pilih "
        Me.BtnSelect.UseVisualStyleBackColor = False
        '
        'rd4
        '
        Me.rd4.AutoSize = True
        Me.rd4.ForeColor = System.Drawing.Color.White
        Me.rd4.Location = New System.Drawing.Point(248, 69)
        Me.rd4.Name = "rd4"
        Me.rd4.Size = New System.Drawing.Size(93, 17)
        Me.rd4.TabIndex = 253
        Me.rd4.TabStop = True
        Me.rd4.Text = "Clould Android"
        Me.rd4.UseVisualStyleBackColor = True
        '
        'TxtNumber
        '
        Me.TxtNumber.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.TxtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNumber.Font = New System.Drawing.Font("Calibri", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNumber.ForeColor = System.Drawing.Color.White
        Me.TxtNumber.Location = New System.Drawing.Point(128, 155)
        Me.TxtNumber.Multiline = True
        Me.TxtNumber.Name = "TxtNumber"
        Me.TxtNumber.ReadOnly = True
        Me.TxtNumber.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtNumber.Size = New System.Drawing.Size(375, 48)
        Me.TxtNumber.TabIndex = 241
        '
        'rd3
        '
        Me.rd3.AutoSize = True
        Me.rd3.ForeColor = System.Drawing.Color.White
        Me.rd3.Location = New System.Drawing.Point(136, 69)
        Me.rd3.Name = "rd3"
        Me.rd3.Size = New System.Drawing.Size(90, 17)
        Me.rd3.TabIndex = 252
        Me.rd3.TabStop = True
        Me.rd3.Text = "Local Android"
        Me.rd3.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(124, 137)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 13)
        Me.Label7.TabIndex = 242
        Me.Label7.Text = "Enter Number :"
        '
        'btnSend
        '
        Me.btnSend.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(90, Byte), Integer))
        Me.btnSend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSend.FlatAppearance.BorderSize = 0
        Me.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSend.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.btnSend.Image = CType(resources.GetObject("btnSend.Image"), System.Drawing.Image)
        Me.btnSend.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSend.Location = New System.Drawing.Point(413, 3)
        Me.btnSend.Name = "btnSend"
        Me.btnSend.Size = New System.Drawing.Size(93, 36)
        Me.btnSend.TabIndex = 243
        Me.btnSend.Text = "  Kirim"
        Me.btnSend.UseVisualStyleBackColor = False
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.ForeColor = System.Drawing.Color.White
        Me.rd1.Location = New System.Drawing.Point(249, 45)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(108, 17)
        Me.rd1.TabIndex = 250
        Me.rd1.TabStop = True
        Me.rd1.Text = "Local WAScanQr"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(128, 208)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 13)
        Me.Label4.TabIndex = 244
        Me.Label4.Text = "Pesan teks:"
        '
        'rd0
        '
        Me.rd0.AutoSize = True
        Me.rd0.ForeColor = System.Drawing.Color.White
        Me.rd0.Location = New System.Drawing.Point(136, 44)
        Me.rd0.Name = "rd0"
        Me.rd0.Size = New System.Drawing.Size(106, 17)
        Me.rd0.TabIndex = 249
        Me.rd0.TabStop = True
        Me.rd0.Text = "Clould WAServer"
        Me.rd0.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Cambria", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(125, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(213, 19)
        Me.Label8.TabIndex = 248
        Me.Label8.Text = "Metode Kirim Pesan Melalui ?"
        '
        'BtnContact
        '
        Me.BtnContact.BackColor = System.Drawing.Color.Transparent
        Me.BtnContact.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnContact.FlatAppearance.BorderSize = 0
        Me.BtnContact.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnContact.ForeColor = System.Drawing.SystemColors.ButtonFace
        Me.BtnContact.Image = CType(resources.GetObject("BtnContact.Image"), System.Drawing.Image)
        Me.BtnContact.Location = New System.Drawing.Point(478, 124)
        Me.BtnContact.Name = "BtnContact"
        Me.BtnContact.Size = New System.Drawing.Size(25, 25)
        Me.BtnContact.TabIndex = 247
        Me.BtnContact.UseVisualStyleBackColor = False
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
        Me.BtnPaste.Location = New System.Drawing.Point(445, 124)
        Me.BtnPaste.Name = "BtnPaste"
        Me.BtnPaste.Size = New System.Drawing.Size(25, 25)
        Me.BtnPaste.TabIndex = 245
        Me.BtnPaste.UseVisualStyleBackColor = False
        '
        'LblTotData
        '
        Me.LblTotData.AutoSize = True
        Me.LblTotData.BackColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(90, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.LblTotData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotData.ForeColor = System.Drawing.Color.White
        Me.LblTotData.Location = New System.Drawing.Point(209, 137)
        Me.LblTotData.Name = "LblTotData"
        Me.LblTotData.Size = New System.Drawing.Size(57, 13)
        Me.LblTotData.TabIndex = 246
        Me.LblTotData.Text = "Total Data"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Rsm)
        Me.Panel1.Controls.Add(Me.BtnTmpl)
        Me.Panel1.Controls.Add(Me.Rrm)
        Me.Panel1.Location = New System.Drawing.Point(128, 221)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(375, 34)
        Me.Panel1.TabIndex = 269
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(138, 409)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 270
        Me.Label2.Text = "1. Wait For"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(138, 437)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 15)
        Me.Label11.TabIndex = 271
        Me.Label11.Text = "2. Wait For"
        '
        'RdWAD
        '
        Me.RdWAD.AutoSize = True
        Me.RdWAD.ForeColor = System.Drawing.Color.White
        Me.RdWAD.Location = New System.Drawing.Point(362, 44)
        Me.RdWAD.Name = "RdWAD"
        Me.RdWAD.Size = New System.Drawing.Size(118, 17)
        Me.RdWAD.TabIndex = 272
        Me.RdWAD.TabStop = True
        Me.RdWAD.Text = "WhatsApp Desktop"
        Me.RdWAD.UseVisualStyleBackColor = True
        '
        'frmkirim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(60, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(943, 460)
        Me.Controls.Add(Me.RdWAD)
        Me.Controls.Add(Me.lblCountState)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.breakmsg)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Breaktime)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Delay)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TotSender)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtMessage)
        Me.Controls.Add(Me.TxtSender)
        Me.Controls.Add(Me.BtnSelect)
        Me.Controls.Add(Me.rd4)
        Me.Controls.Add(Me.TxtNumber)
        Me.Controls.Add(Me.rd3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnSend)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.rd0)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BtnContact)
        Me.Controls.Add(Me.BtnPaste)
        Me.Controls.Add(Me.LblTotData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmkirim"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmkirim"
        CType(Me.TotSender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Breaktime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.breakmsg, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Delay, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BtnTmpl As Button
    Friend WithEvents Rrm As RadioButton
    Friend WithEvents Rsm As RadioButton
    Friend WithEvents Label12 As Label
    Friend WithEvents TotSender As NumericUpDown
    Friend WithEvents Label9 As Label
    Friend WithEvents Breaktime As NumericUpDown
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents breakmsg As NumericUpDown
    Friend WithEvents Label1 As Label
    Friend WithEvents Delay As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PnlogActivty As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents BtnStopCall As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents TxtMessage As RichTextBox
    Friend WithEvents TxtSender As TextBox
    Friend WithEvents BtnSelect As Button
    Friend WithEvents rd4 As RadioButton
    Friend WithEvents TxtNumber As TextBox
    Friend WithEvents rd3 As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents btnSend As Button
    Friend WithEvents rd1 As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents rd0 As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents BtnContact As Button
    Friend WithEvents BtnPaste As Button
    Friend WithEvents LblTotData As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents lblCountState As Label
    Friend WithEvents RdWAD As RadioButton
End Class
