<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmOrders
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOrders))
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.mnu = New OreLavoro.ucMenu()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtOrderName = New System.Windows.Forms.TextBox()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkOrdedEnded = New System.Windows.Forms.CheckBox()
        Me.txtOrderRename = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.panMenu.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(5, 4)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 499)
        Me.panMenu.TabIndex = 147
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -2)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 500)
        Me.mnu.TabIndex = 1
        '
        'dgv
        '
        Me.dgv.AllowUserToAddRows = False
        Me.dgv.AllowUserToDeleteRows = False
        Me.dgv.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Lavender
        Me.dgv.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgv.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgv.Location = New System.Drawing.Point(147, 104)
        Me.dgv.Name = "dgv"
        Me.dgv.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgv.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgv.RowTemplate.Height = 16
        Me.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgv.Size = New System.Drawing.Size(565, 399)
        Me.dgv.TabIndex = 148
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 20)
        Me.Label5.TabIndex = 214
        Me.Label5.Text = "Nome"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOrderName
        '
        Me.txtOrderName.Name = "txtOrderName"
        Me.txtOrderName.Size = New System.Drawing.Size(252, 20)
        Me.txtOrderName.TabIndex = 215
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(252, 20)
        Me.txtCustomerName.TabIndex = 217
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 20)
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Cliente"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkOrdedEnded
        '
        Me.chkOrdedEnded.AutoSize = True
        Me.chkOrdedEnded.Name = "chkOrdedEnded"
        Me.chkOrdedEnded.Size = New System.Drawing.Size(51, 17)
        Me.chkOrdedEnded.TabIndex = 218
        Me.chkOrdedEnded.Text = "Finita"
        Me.chkOrdedEnded.UseVisualStyleBackColor = True
        '
        'txtOrderRename
        '
        Me.txtOrderRename.Location = New System.Drawing.Point(232, 74)
        Me.txtOrderRename.Name = "txtOrderRename"
        Me.txtOrderRename.Size = New System.Drawing.Size(252, 20)
        Me.txtOrderRename.TabIndex = 220
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(150, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 20)
        Me.Label2.TabIndex = 219
        Me.Label2.Text = "Rinominare in"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(724, 509)
        Me.Controls.Add(Me.txtOrderRename)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.chkOrdedEnded)
        Me.Controls.Add(Me.txtCustomerName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtOrderName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.panMenu)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmOrders"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmOrders"
        Me.panMenu.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents mnu As ucMenu
    Private WithEvents dgv As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents txtOrderName As TextBox
    Friend WithEvents txtCustomerName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkOrdedEnded As CheckBox
    Friend WithEvents txtOrderRename As TextBox
    Friend WithEvents Label2 As Label
End Class
