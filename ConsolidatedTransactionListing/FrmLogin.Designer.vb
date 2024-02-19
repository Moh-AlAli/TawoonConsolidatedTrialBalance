<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLogin))
        Me.dtSesDate = New System.Windows.Forms.DateTimePicker()
        Me.label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdOK = New System.Windows.Forms.Button()
        Me.cmbComp = New System.Windows.Forms.ComboBox()
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblComp = New System.Windows.Forms.Label()
        Me.lblPwd = New System.Windows.Forms.Label()
        Me.lblUserid = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'dtSesDate
        '
        Me.dtSesDate.CustomFormat = "yyyy-MM-dd"
        Me.dtSesDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtSesDate.Location = New System.Drawing.Point(114, 108)
        Me.dtSesDate.Name = "dtSesDate"
        Me.dtSesDate.Size = New System.Drawing.Size(96, 20)
        Me.dtSesDate.TabIndex = 35
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(37, 111)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(73, 13)
        Me.label1.TabIndex = 38
        Me.label1.Text = "Session Date:"
        '
        'cmdCancel
        '
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(349, 51)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 37
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdOK
        '
        Me.cmdOK.Location = New System.Drawing.Point(349, 19)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(75, 23)
        Me.cmdOK.TabIndex = 36
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        '
        'cmbComp
        '
        Me.cmbComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComp.FormattingEnabled = True
        Me.cmbComp.Location = New System.Drawing.Point(114, 82)
        Me.cmbComp.Name = "cmbComp"
        Me.cmbComp.Size = New System.Drawing.Size(310, 21)
        Me.cmbComp.TabIndex = 33
        '
        'txtPwd
        '
        Me.txtPwd.Location = New System.Drawing.Point(114, 54)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(151, 20)
        Me.txtPwd.TabIndex = 31
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(114, 27)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(151, 20)
        Me.txtUser.TabIndex = 29
        '
        'lblComp
        '
        Me.lblComp.AutoSize = True
        Me.lblComp.Location = New System.Drawing.Point(36, 86)
        Me.lblComp.Name = "lblComp"
        Me.lblComp.Size = New System.Drawing.Size(56, 13)
        Me.lblComp.TabIndex = 34
        Me.lblComp.Text = "Company:"
        '
        'lblPwd
        '
        Me.lblPwd.AutoSize = True
        Me.lblPwd.Location = New System.Drawing.Point(36, 55)
        Me.lblPwd.Name = "lblPwd"
        Me.lblPwd.Size = New System.Drawing.Size(57, 13)
        Me.lblPwd.TabIndex = 32
        Me.lblPwd.Text = "Password:"
        '
        'lblUserid
        '
        Me.lblUserid.AutoSize = True
        Me.lblUserid.Location = New System.Drawing.Point(36, 30)
        Me.lblUserid.Name = "lblUserid"
        Me.lblUserid.Size = New System.Drawing.Size(47, 13)
        Me.lblUserid.TabIndex = 30
        Me.lblUserid.Text = "User ID:"
        '
        'FrmLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(461, 146)
        Me.Controls.Add(Me.dtSesDate)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.cmdOK)
        Me.Controls.Add(Me.cmbComp)
        Me.Controls.Add(Me.txtPwd)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.lblComp)
        Me.Controls.Add(Me.lblPwd)
        Me.Controls.Add(Me.lblUserid)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FrmLogin"
        Me.Text = "Sage 300 ERP Signon"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents dtSesDate As DateTimePicker
    Private WithEvents label1 As Label
    Private WithEvents cmdCancel As Button
    Private WithEvents cmdOK As Button
    Private WithEvents cmbComp As ComboBox
    Private WithEvents txtPwd As TextBox
    Private WithEvents txtUser As TextBox
    Private WithEvents lblComp As Label
    Private WithEvents lblPwd As Label
    Private WithEvents lblUserid As Label
End Class
