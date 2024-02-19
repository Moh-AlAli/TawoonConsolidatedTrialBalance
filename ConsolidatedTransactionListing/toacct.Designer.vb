<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class toacct
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(toacct))
        Me.Txtaccno = New System.Windows.Forms.TextBox()
        Me.Bfind = New System.Windows.Forms.Button()
        Me.CBCaptions = New System.Windows.Forms.ComboBox()
        Me.CBSearch = New System.Windows.Forms.ComboBox()
        Me.CBfindby = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Lblfl = New System.Windows.Forms.Label()
        Me.Butcan = New System.Windows.Forms.Button()
        Me.DGtacc = New System.Windows.Forms.DataGridView()
        Me.ButSel = New System.Windows.Forms.Button()
        CType(Me.DGtacc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Txtaccno
        '
        Me.Txtaccno.Location = New System.Drawing.Point(65, 62)
        Me.Txtaccno.Name = "Txtaccno"
        Me.Txtaccno.Size = New System.Drawing.Size(237, 20)
        Me.Txtaccno.TabIndex = 107
        '
        'Bfind
        '
        Me.Bfind.Location = New System.Drawing.Point(307, 3)
        Me.Bfind.Name = "Bfind"
        Me.Bfind.Size = New System.Drawing.Size(75, 23)
        Me.Bfind.TabIndex = 106
        Me.Bfind.Text = "Find"
        Me.Bfind.UseVisualStyleBackColor = True
        '
        'CBCaptions
        '
        Me.CBCaptions.FormattingEnabled = True
        Me.CBCaptions.Items.AddRange(New Object() {"Srarts With", "Contains"})
        Me.CBCaptions.Location = New System.Drawing.Point(65, 61)
        Me.CBCaptions.Name = "CBCaptions"
        Me.CBCaptions.Size = New System.Drawing.Size(237, 21)
        Me.CBCaptions.TabIndex = 105
        '
        'CBSearch
        '
        Me.CBSearch.FormattingEnabled = True
        Me.CBSearch.Items.AddRange(New Object() {"Srarts With", "Contains"})
        Me.CBSearch.Location = New System.Drawing.Point(64, 33)
        Me.CBSearch.Name = "CBSearch"
        Me.CBSearch.Size = New System.Drawing.Size(237, 21)
        Me.CBSearch.TabIndex = 104
        '
        'CBfindby
        '
        Me.CBfindby.FormattingEnabled = True
        Me.CBfindby.Items.AddRange(New Object() {"Show All Records", "Unformatted Account", "Account Number", "Description", "Status", "Type", "Structure Code", "Control Account", "Allocations Allowed", "MultiCurrency", "Quantities Allowed", "Unit of Measure"})
        Me.CBfindby.Location = New System.Drawing.Point(63, 5)
        Me.CBfindby.Name = "CBfindby"
        Me.CBfindby.Size = New System.Drawing.Size(238, 21)
        Me.CBfindby.TabIndex = 103
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Find By :"
        '
        'Lblfl
        '
        Me.Lblfl.AutoSize = True
        Me.Lblfl.Location = New System.Drawing.Point(6, 64)
        Me.Lblfl.Name = "Lblfl"
        Me.Lblfl.Size = New System.Drawing.Size(31, 13)
        Me.Lblfl.TabIndex = 101
        Me.Lblfl.Text = "Filter"
        '
        'Butcan
        '
        Me.Butcan.Location = New System.Drawing.Point(634, 338)
        Me.Butcan.Name = "Butcan"
        Me.Butcan.Size = New System.Drawing.Size(75, 23)
        Me.Butcan.TabIndex = 100
        Me.Butcan.Text = "Cancel"
        Me.Butcan.UseVisualStyleBackColor = True
        '
        'DGtacc
        '
        Me.DGtacc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGtacc.Location = New System.Drawing.Point(0, 86)
        Me.DGtacc.Name = "DGtacc"
        Me.DGtacc.Size = New System.Drawing.Size(781, 244)
        Me.DGtacc.TabIndex = 98
        '
        'ButSel
        '
        Me.ButSel.Location = New System.Drawing.Point(62, 337)
        Me.ButSel.Name = "ButSel"
        Me.ButSel.Size = New System.Drawing.Size(75, 23)
        Me.ButSel.TabIndex = 99
        Me.ButSel.Text = "Select"
        Me.ButSel.UseVisualStyleBackColor = True
        '
        'toacct
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 378)
        Me.Controls.Add(Me.Txtaccno)
        Me.Controls.Add(Me.Bfind)
        Me.Controls.Add(Me.CBCaptions)
        Me.Controls.Add(Me.CBSearch)
        Me.Controls.Add(Me.CBfindby)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Lblfl)
        Me.Controls.Add(Me.Butcan)
        Me.Controls.Add(Me.DGtacc)
        Me.Controls.Add(Me.ButSel)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "toacct"
        Me.Text = "To Account"
        CType(Me.DGtacc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Txtaccno As TextBox
    Friend WithEvents Bfind As Button
    Friend WithEvents CBCaptions As ComboBox
    Friend WithEvents CBSearch As ComboBox
    Friend WithEvents CBfindby As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Lblfl As Label
    Friend WithEvents Butcan As Button
    Friend WithEvents DGtacc As DataGridView
    Friend WithEvents ButSel As Button
End Class
