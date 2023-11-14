<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAnalisiRefound
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnalisiRefound))
        Me.panFilter = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboOrderName = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboEmployee = New System.Windows.Forms.ComboBox()
        Me.plsFilter = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grpOreLavoro = New System.Windows.Forms.GroupBox()
        Me.lblCommessa = New System.Windows.Forms.Label()
        Me.lblSpeseTotale = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpTo = New System.Windows.Forms.DateTimePicker()
        Me.lblData = New System.Windows.Forms.Label()
        Me.mnu = New OreLavoro.ucMenu()
        Me.panData = New System.Windows.Forms.Panel()
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker()
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.panFilter.SuspendLayout()
        Me.grpOreLavoro.SuspendLayout()
        Me.panMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'panFilter
        '
        Me.panFilter.Controls.Add(Me.Label1)
        Me.panFilter.Controls.Add(Me.cboOrderName)
        Me.panFilter.Controls.Add(Me.Label5)
        Me.panFilter.Controls.Add(Me.cboEmployee)
        Me.panFilter.Controls.Add(Me.plsFilter)
        Me.panFilter.Location = New System.Drawing.Point(146, 4)
        Me.panFilter.Name = "panFilter"
        Me.panFilter.Size = New System.Drawing.Size(328, 76)
        Me.panFilter.TabIndex = 244
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 230
        Me.Label1.Text = "Nome"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOrderName
        '
        Me.cboOrderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderName.Location = New System.Drawing.Point(70, 40)
        Me.cboOrderName.Name = "cboOrderName"
        Me.cboOrderName.Size = New System.Drawing.Size(220, 21)
        Me.cboOrderName.TabIndex = 222
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 20)
        Me.Label5.TabIndex = 223
        Me.Label5.Text = "Commessa"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboEmployee
        '
        Me.cboEmployee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployee.FormattingEnabled = True
        Me.cboEmployee.Location = New System.Drawing.Point(70, 9)
        Me.cboEmployee.Name = "cboEmployee"
        Me.cboEmployee.Size = New System.Drawing.Size(220, 21)
        Me.cboEmployee.TabIndex = 229
        '
        'plsFilter
        '
        Me.plsFilter.Image = CType(resources.GetObject("plsFilter.Image"), System.Drawing.Image)
        Me.plsFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsFilter.Location = New System.Drawing.Point(296, 21)
        Me.plsFilter.Name = "plsFilter"
        Me.plsFilter.Size = New System.Drawing.Size(25, 26)
        Me.plsFilter.TabIndex = 228
        Me.plsFilter.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(129, 20)
        Me.Label9.TabIndex = 236
        Me.Label9.Text = "Totale"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grpOreLavoro
        '
        Me.grpOreLavoro.Controls.Add(Me.lblCommessa)
        Me.grpOreLavoro.Controls.Add(Me.lblSpeseTotale)
        Me.grpOreLavoro.Controls.Add(Me.Label9)
        Me.grpOreLavoro.Location = New System.Drawing.Point(750, 4)
        Me.grpOreLavoro.Name = "grpOreLavoro"
        Me.grpOreLavoro.Size = New System.Drawing.Size(251, 76)
        Me.grpOreLavoro.TabIndex = 243
        Me.grpOreLavoro.TabStop = False
        Me.grpOreLavoro.Text = "Totali spese"
        '
        'lblCommessa
        '
        Me.lblCommessa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCommessa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommessa.Location = New System.Drawing.Point(6, 21)
        Me.lblCommessa.Name = "lblCommessa"
        Me.lblCommessa.Size = New System.Drawing.Size(129, 20)
        Me.lblCommessa.TabIndex = 240
        Me.lblCommessa.Text = "Commessa"
        Me.lblCommessa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSpeseTotale
        '
        Me.lblSpeseTotale.BackColor = System.Drawing.Color.White
        Me.lblSpeseTotale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblSpeseTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSpeseTotale.Location = New System.Drawing.Point(136, 47)
        Me.lblSpeseTotale.Name = "lblSpeseTotale"
        Me.lblSpeseTotale.Size = New System.Drawing.Size(82, 20)
        Me.lblSpeseTotale.TabIndex = 239
        Me.lblSpeseTotale.Text = "999.59"
        Me.lblSpeseTotale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(490, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 20)
        Me.Label2.TabIndex = 241
        Me.Label2.Text = "A"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(531, 48)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(203, 20)
        Me.dtpTo.TabIndex = 240
        '
        'lblData
        '
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.Location = New System.Drawing.Point(490, 9)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(41, 20)
        Me.lblData.TabIndex = 239
        Me.lblData.Text = "Da"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -2)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 619)
        Me.mnu.TabIndex = 1
        '
        'panData
        '
        Me.panData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panData.Location = New System.Drawing.Point(147, 86)
        Me.panData.Name = "panData"
        Me.panData.Size = New System.Drawing.Size(854, 537)
        Me.panData.TabIndex = 242
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(531, 9)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(203, 20)
        Me.dtpFrom.TabIndex = 238
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(4, 4)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 620)
        Me.panMenu.TabIndex = 237
        '
        'frmAnalisiRefound
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 628)
        Me.Controls.Add(Me.panFilter)
        Me.Controls.Add(Me.grpOreLavoro)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtpTo)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.panData)
        Me.Controls.Add(Me.dtpFrom)
        Me.Controls.Add(Me.panMenu)
        Me.Name = "frmAnalisiRefound"
        Me.Text = "frmAnalisiRefound"
        Me.panFilter.ResumeLayout(False)
        Me.grpOreLavoro.ResumeLayout(False)
        Me.panMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panFilter As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cboOrderName As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cboEmployee As ComboBox
    Friend WithEvents plsFilter As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents grpOreLavoro As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents dtpTo As DateTimePicker
    Friend WithEvents lblData As Label
    Friend WithEvents mnu As ucMenu
    Friend WithEvents panData As Panel
    Friend WithEvents dtpFrom As DateTimePicker
    Friend WithEvents panMenu As Panel
    Friend WithEvents lblSpeseTotale As Label
    Friend WithEvents lblCommessa As Label
End Class
