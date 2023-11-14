<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCambioNomeCommessa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCambioNomeCommessa))
        Me.plsFilter = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboOrderName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCommessa = New System.Windows.Forms.Label()
        Me.plsCancel = New System.Windows.Forms.Button()
        Me.plsConfirm = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'plsFilter
        '
        Me.plsFilter.Image = CType(resources.GetObject("plsFilter.Image"), System.Drawing.Image)
        Me.plsFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsFilter.Location = New System.Drawing.Point(342, 83)
        Me.plsFilter.Name = "plsFilter"
        Me.plsFilter.Size = New System.Drawing.Size(25, 26)
        Me.plsFilter.TabIndex = 222
        Me.plsFilter.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(49, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 221
        Me.Label5.Text = "Commessa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOrderName
        '
        Me.cboOrderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderName.Location = New System.Drawing.Point(116, 86)
        Me.cboOrderName.Name = "cboOrderName"
        Me.cboOrderName.Size = New System.Drawing.Size(220, 21)
        Me.cboOrderName.TabIndex = 220
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 223
        Me.Label1.Text = "Commessa"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCommessa
        '
        Me.lblCommessa.BackColor = System.Drawing.Color.White
        Me.lblCommessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCommessa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommessa.Location = New System.Drawing.Point(116, 25)
        Me.lblCommessa.Name = "lblCommessa"
        Me.lblCommessa.Size = New System.Drawing.Size(220, 20)
        Me.lblCommessa.TabIndex = 224
        Me.lblCommessa.Text = "Commessa"
        Me.lblCommessa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'plsCancel
        '
        Me.plsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.plsCancel.Image = CType(resources.GetObject("plsCancel.Image"), System.Drawing.Image)
        Me.plsCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsCancel.Location = New System.Drawing.Point(49, 154)
        Me.plsCancel.Name = "plsCancel"
        Me.plsCancel.Size = New System.Drawing.Size(87, 28)
        Me.plsCancel.TabIndex = 275
        Me.plsCancel.Text = "Annulla"
        Me.plsCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.plsCancel.UseVisualStyleBackColor = True
        '
        'plsConfirm
        '
        Me.plsConfirm.Image = CType(resources.GetObject("plsConfirm.Image"), System.Drawing.Image)
        Me.plsConfirm.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsConfirm.Location = New System.Drawing.Point(234, 154)
        Me.plsConfirm.Name = "plsConfirm"
        Me.plsConfirm.Size = New System.Drawing.Size(87, 28)
        Me.plsConfirm.TabIndex = 276
        Me.plsConfirm.Text = "Conferma"
        Me.plsConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.plsConfirm.UseVisualStyleBackColor = True
        '
        'frmCambioNomeCommessa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(393, 222)
        Me.Controls.Add(Me.plsCancel)
        Me.Controls.Add(Me.plsConfirm)
        Me.Controls.Add(Me.lblCommessa)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.plsFilter)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cboOrderName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambioNomeCommessa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmCambioNomeCommessa"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents plsFilter As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cboOrderName As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents lblCommessa As Label
    Friend WithEvents plsCancel As Button
    Friend WithEvents plsConfirm As Button
End Class
