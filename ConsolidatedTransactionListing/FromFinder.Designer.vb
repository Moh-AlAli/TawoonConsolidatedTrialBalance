<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FromFinder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FromFinder))
        Me.crtPan = New System.Windows.Forms.Panel()
        Me.chkAutoSearch = New System.Windows.Forms.CheckBox()
        Me.cmdFind = New System.Windows.Forms.Button()
        Me.cmbOperation = New System.Windows.Forms.ComboBox()
        Me.lblFindBy = New System.Windows.Forms.Label()
        Me.cmbFindBy = New System.Windows.Forms.ComboBox()
        Me.dataPan = New System.Windows.Forms.Panel()
        Me.cmdPan = New System.Windows.Forms.Panel()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.cmdSelect = New System.Windows.Forms.Button()
        Me.lstData = New System.Windows.Forms.ListView()
        Me.filPan = New System.Windows.Forms.Panel()
        Me.dataPan.SuspendLayout()
        Me.cmdPan.SuspendLayout()
        Me.filPan.SuspendLayout()
        Me.SuspendLayout()
        '
        'crtPan
        '
        Me.crtPan.Location = New System.Drawing.Point(56, 54)
        Me.crtPan.Name = "crtPan"
        Me.crtPan.Size = New System.Drawing.Size(168, 22)
        Me.crtPan.TabIndex = 9
        '
        'chkAutoSearch
        '
        Me.chkAutoSearch.AutoSize = True
        Me.chkAutoSearch.Location = New System.Drawing.Point(281, 31)
        Me.chkAutoSearch.Name = "chkAutoSearch"
        Me.chkAutoSearch.Size = New System.Drawing.Size(85, 17)
        Me.chkAutoSearch.TabIndex = 8
        Me.chkAutoSearch.Text = "Auto Search"
        Me.chkAutoSearch.UseVisualStyleBackColor = True
        '
        'cmdFind
        '
        Me.cmdFind.Location = New System.Drawing.Point(281, 2)
        Me.cmdFind.Name = "cmdFind"
        Me.cmdFind.Size = New System.Drawing.Size(75, 21)
        Me.cmdFind.TabIndex = 7
        Me.cmdFind.Text = "Find Now"
        Me.cmdFind.UseVisualStyleBackColor = True
        '
        'cmbOperation
        '
        Me.cmbOperation.BackColor = System.Drawing.SystemColors.Window
        Me.cmbOperation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOperation.FormattingEnabled = True
        Me.cmbOperation.Location = New System.Drawing.Point(56, 28)
        Me.cmbOperation.Name = "cmbOperation"
        Me.cmbOperation.Size = New System.Drawing.Size(168, 21)
        Me.cmbOperation.TabIndex = 6
        '
        'lblFindBy
        '
        Me.lblFindBy.AutoSize = True
        Me.lblFindBy.Location = New System.Drawing.Point(9, 5)
        Me.lblFindBy.Name = "lblFindBy"
        Me.lblFindBy.Size = New System.Drawing.Size(46, 13)
        Me.lblFindBy.TabIndex = 5
        Me.lblFindBy.Text = "Find By:"
        '
        'cmbFindBy
        '
        Me.cmbFindBy.BackColor = System.Drawing.SystemColors.Window
        Me.cmbFindBy.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbFindBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFindBy.FormattingEnabled = True
        Me.cmbFindBy.Location = New System.Drawing.Point(56, 2)
        Me.cmbFindBy.Name = "cmbFindBy"
        Me.cmbFindBy.Size = New System.Drawing.Size(218, 21)
        Me.cmbFindBy.TabIndex = 4
        '
        'dataPan
        '
        Me.dataPan.Controls.Add(Me.cmdPan)
        Me.dataPan.Controls.Add(Me.lstData)
        Me.dataPan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dataPan.Location = New System.Drawing.Point(0, 78)
        Me.dataPan.Margin = New System.Windows.Forms.Padding(3, 3, 3, 20)
        Me.dataPan.Name = "dataPan"
        Me.dataPan.Padding = New System.Windows.Forms.Padding(2)
        Me.dataPan.Size = New System.Drawing.Size(550, 295)
        Me.dataPan.TabIndex = 12
        '
        'cmdPan
        '
        Me.cmdPan.Controls.Add(Me.cmdCancel)
        Me.cmdPan.Controls.Add(Me.cmdSelect)
        Me.cmdPan.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.cmdPan.Location = New System.Drawing.Point(2, 260)
        Me.cmdPan.Name = "cmdPan"
        Me.cmdPan.Size = New System.Drawing.Size(546, 33)
        Me.cmdPan.TabIndex = 10
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.Location = New System.Drawing.Point(444, 5)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 8
        Me.cmdCancel.Text = "Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'cmdSelect
        '
        Me.cmdSelect.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdSelect.Location = New System.Drawing.Point(339, 5)
        Me.cmdSelect.Name = "cmdSelect"
        Me.cmdSelect.Size = New System.Drawing.Size(75, 23)
        Me.cmdSelect.TabIndex = 7
        Me.cmdSelect.Text = "Select"
        Me.cmdSelect.UseVisualStyleBackColor = True
        '
        'lstData
        '
        Me.lstData.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstData.AllowColumnReorder = True
        Me.lstData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lstData.Dock = System.Windows.Forms.DockStyle.Top
        Me.lstData.FullRowSelect = True
        Me.lstData.GridLines = True
        Me.lstData.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.lstData.HideSelection = False
        Me.lstData.LabelWrap = False
        Me.lstData.Location = New System.Drawing.Point(2, 2)
        Me.lstData.MultiSelect = False
        Me.lstData.Name = "lstData"
        Me.lstData.OwnerDraw = True
        Me.lstData.ShowGroups = False
        Me.lstData.Size = New System.Drawing.Size(546, 210)
        Me.lstData.TabIndex = 5
        Me.lstData.UseCompatibleStateImageBehavior = False
        Me.lstData.View = System.Windows.Forms.View.Details
        '
        'filPan
        '
        Me.filPan.Controls.Add(Me.crtPan)
        Me.filPan.Controls.Add(Me.chkAutoSearch)
        Me.filPan.Controls.Add(Me.cmdFind)
        Me.filPan.Controls.Add(Me.cmbOperation)
        Me.filPan.Controls.Add(Me.lblFindBy)
        Me.filPan.Controls.Add(Me.cmbFindBy)
        Me.filPan.Dock = System.Windows.Forms.DockStyle.Top
        Me.filPan.Location = New System.Drawing.Point(0, 0)
        Me.filPan.Name = "filPan"
        Me.filPan.Size = New System.Drawing.Size(550, 78)
        Me.filPan.TabIndex = 11
        '
        'FromFinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 373)
        Me.Controls.Add(Me.dataPan)
        Me.Controls.Add(Me.filPan)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FromFinder"
        Me.Text = "From Finder"
        Me.dataPan.ResumeLayout(False)
        Me.cmdPan.ResumeLayout(False)
        Me.filPan.ResumeLayout(False)
        Me.filPan.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents crtPan As Panel
    Private WithEvents chkAutoSearch As CheckBox
    Private WithEvents cmdFind As Button
    Private WithEvents cmbOperation As ComboBox
    Private WithEvents lblFindBy As Label
    Private WithEvents cmbFindBy As ComboBox
    Private WithEvents dataPan As Panel
    Private WithEvents cmdPan As Panel
    Private WithEvents cmdCancel As Button
    Private WithEvents cmdSelect As Button
    Private WithEvents lstData As ListView
    Private WithEvents filPan As Panel
End Class
