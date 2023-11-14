<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdjustExpenses
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAdjustExpenses))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.panOreLavoro = New System.Windows.Forms.Panel()
        Me.picArrowUp = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtTrasfertaCedolino = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.lblCostoTrasfertaLungo = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtGiorniTrasfertaEsteroLungo = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblCostoTrasfertaEstero = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.txtGiorniTrasfertaEstero = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.lblCostoTrasfertaItalia = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtGiorniTrasfertaItalia = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtContanti = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCompetenze = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtRiporti = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSpese = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtDiaria = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCompetenzeStraordinario = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtTrasferta = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCostoOrario = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOreInBusta = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOreFatte = New System.Windows.Forms.TextBox()
        Me.cboEmployeeName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.lblData = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.ucCable3 = New OreLavoro.ucCable()
        Me.ucCable2 = New OreLavoro.ucCable()
        Me.ucCable1 = New OreLavoro.ucCable()
        Me.mnu = New OreLavoro.ucMenu()
        Me.panMenu.SuspendLayout()
        Me.panOreLavoro.SuspendLayout()
        CType(Me.picArrowUp, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(3, 3)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 620)
        Me.panMenu.TabIndex = 147
        '
        'panOreLavoro
        '
        Me.panOreLavoro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panOreLavoro.Controls.Add(Me.picArrowUp)
        Me.panOreLavoro.Controls.Add(Me.ucCable3)
        Me.panOreLavoro.Controls.Add(Me.ucCable2)
        Me.panOreLavoro.Controls.Add(Me.ucCable1)
        Me.panOreLavoro.Controls.Add(Me.GroupBox2)
        Me.panOreLavoro.Controls.Add(Me.GroupBox1)
        Me.panOreLavoro.Controls.Add(Me.GroupBox3)
        Me.panOreLavoro.Controls.Add(Me.cboEmployeeName)
        Me.panOreLavoro.Controls.Add(Me.Label1)
        Me.panOreLavoro.Controls.Add(Me.dgv)
        Me.panOreLavoro.Controls.Add(Me.lblData)
        Me.panOreLavoro.Controls.Add(Me.dtpDate)
        Me.panOreLavoro.Location = New System.Drawing.Point(142, 3)
        Me.panOreLavoro.Name = "panOreLavoro"
        Me.panOreLavoro.Size = New System.Drawing.Size(877, 620)
        Me.panOreLavoro.TabIndex = 151
        '
        'picArrowUp
        '
        Me.picArrowUp.Image = CType(resources.GetObject("picArrowUp.Image"), System.Drawing.Image)
        Me.picArrowUp.Location = New System.Drawing.Point(539, 97)
        Me.picArrowUp.Name = "picArrowUp"
        Me.picArrowUp.Size = New System.Drawing.Size(11, 15)
        Me.picArrowUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picArrowUp.TabIndex = 304
        Me.picArrowUp.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtTrasfertaCedolino)
        Me.GroupBox2.Controls.Add(Me.Label30)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.lblCostoTrasfertaLungo)
        Me.GroupBox2.Controls.Add(Me.Label36)
        Me.GroupBox2.Controls.Add(Me.Label37)
        Me.GroupBox2.Controls.Add(Me.txtGiorniTrasfertaEsteroLungo)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.lblCostoTrasfertaEstero)
        Me.GroupBox2.Controls.Add(Me.Label34)
        Me.GroupBox2.Controls.Add(Me.Label35)
        Me.GroupBox2.Controls.Add(Me.txtGiorniTrasfertaEstero)
        Me.GroupBox2.Controls.Add(Me.Label33)
        Me.GroupBox2.Controls.Add(Me.Label32)
        Me.GroupBox2.Controls.Add(Me.Label31)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.lblCostoTrasfertaItalia)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.txtGiorniTrasfertaItalia)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Location = New System.Drawing.Point(43, 43)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(754, 47)
        Me.GroupBox2.TabIndex = 239
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Trasferte"
        '
        'txtTrasfertaCedolino
        '
        Me.txtTrasfertaCedolino.Location = New System.Drawing.Point(662, 18)
        Me.txtTrasfertaCedolino.Name = "txtTrasfertaCedolino"
        Me.txtTrasfertaCedolino.Size = New System.Drawing.Size(60, 20)
        Me.txtTrasfertaCedolino.TabIndex = 245
        Me.txtTrasfertaCedolino.Text = "0.00"
        Me.txtTrasfertaCedolino.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label30
        '
        Me.Label30.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(555, 18)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(106, 20)
        Me.Label30.TabIndex = 270
        Me.Label30.Text = "Trasferta in cedolino"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(535, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(19, 28)
        Me.Label27.TabIndex = 246
        Me.Label27.Text = "-"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(520, 25)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(12, 20)
        Me.Label28.TabIndex = 269
        Me.Label28.Text = "€"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(451, 22)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(19, 20)
        Me.Label29.TabIndex = 265
        Me.Label29.Text = "gg"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoTrasfertaLungo
        '
        Me.lblCostoTrasfertaLungo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCostoTrasfertaLungo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTrasfertaLungo.Location = New System.Drawing.Point(484, 18)
        Me.lblCostoTrasfertaLungo.Name = "lblCostoTrasfertaLungo"
        Me.lblCostoTrasfertaLungo.Size = New System.Drawing.Size(36, 20)
        Me.lblCostoTrasfertaLungo.TabIndex = 268
        Me.lblCostoTrasfertaLungo.Text = "40"
        Me.lblCostoTrasfertaLungo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(467, 18)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(19, 23)
        Me.Label36.TabIndex = 267
        Me.Label36.Text = "*"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label37
        '
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(359, 18)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(68, 20)
        Me.Label37.TabIndex = 264
        Me.Label37.Text = "Estero lungo"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGiorniTrasfertaEsteroLungo
        '
        Me.txtGiorniTrasfertaEsteroLungo.Location = New System.Drawing.Point(428, 18)
        Me.txtGiorniTrasfertaEsteroLungo.Name = "txtGiorniTrasfertaEsteroLungo"
        Me.txtGiorniTrasfertaEsteroLungo.Size = New System.Drawing.Size(23, 20)
        Me.txtGiorniTrasfertaEsteroLungo.TabIndex = 266
        Me.txtGiorniTrasfertaEsteroLungo.Text = "30"
        Me.txtGiorniTrasfertaEsteroLungo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(312, 26)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(12, 20)
        Me.Label21.TabIndex = 263
        Me.Label21.Text = "€"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(243, 23)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(19, 20)
        Me.Label26.TabIndex = 259
        Me.Label26.Text = "gg"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCostoTrasfertaEstero
        '
        Me.lblCostoTrasfertaEstero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCostoTrasfertaEstero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTrasfertaEstero.Location = New System.Drawing.Point(276, 19)
        Me.lblCostoTrasfertaEstero.Name = "lblCostoTrasfertaEstero"
        Me.lblCostoTrasfertaEstero.Size = New System.Drawing.Size(36, 20)
        Me.lblCostoTrasfertaEstero.TabIndex = 262
        Me.lblCostoTrasfertaEstero.Text = "40"
        Me.lblCostoTrasfertaEstero.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label34
        '
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(259, 19)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(19, 23)
        Me.Label34.TabIndex = 261
        Me.Label34.Text = "*"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label35
        '
        Me.Label35.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(181, 19)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(39, 20)
        Me.Label35.TabIndex = 258
        Me.Label35.Text = "Estero"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGiorniTrasfertaEstero
        '
        Me.txtGiorniTrasfertaEstero.Location = New System.Drawing.Point(220, 19)
        Me.txtGiorniTrasfertaEstero.Name = "txtGiorniTrasfertaEstero"
        Me.txtGiorniTrasfertaEstero.Size = New System.Drawing.Size(23, 20)
        Me.txtGiorniTrasfertaEstero.TabIndex = 260
        Me.txtGiorniTrasfertaEstero.Text = "30"
        Me.txtGiorniTrasfertaEstero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(137, 27)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(12, 20)
        Me.Label33.TabIndex = 257
        Me.Label33.Text = "€"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(68, 24)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(19, 20)
        Me.Label32.TabIndex = 244
        Me.Label32.Text = "gg"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label31
        '
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(333, 15)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(19, 23)
        Me.Label31.TabIndex = 252
        Me.Label31.Text = "+"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(156, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(19, 23)
        Me.Label20.TabIndex = 247
        Me.Label20.Text = "+"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblCostoTrasfertaItalia
        '
        Me.lblCostoTrasfertaItalia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCostoTrasfertaItalia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCostoTrasfertaItalia.Location = New System.Drawing.Point(101, 20)
        Me.lblCostoTrasfertaItalia.Name = "lblCostoTrasfertaItalia"
        Me.lblCostoTrasfertaItalia.Size = New System.Drawing.Size(36, 20)
        Me.lblCostoTrasfertaItalia.TabIndex = 246
        Me.lblCostoTrasfertaItalia.Text = "40"
        Me.lblCostoTrasfertaItalia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(84, 20)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(19, 23)
        Me.Label22.TabIndex = 245
        Me.Label22.Text = "*"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label23
        '
        Me.Label23.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(6, 20)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(39, 20)
        Me.Label23.TabIndex = 243
        Me.Label23.Text = "Italia"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtGiorniTrasfertaItalia
        '
        Me.txtGiorniTrasfertaItalia.Location = New System.Drawing.Point(45, 20)
        Me.txtGiorniTrasfertaItalia.Name = "txtGiorniTrasfertaItalia"
        Me.txtGiorniTrasfertaItalia.Size = New System.Drawing.Size(23, 20)
        Me.txtGiorniTrasfertaItalia.TabIndex = 244
        Me.txtGiorniTrasfertaItalia.Text = "30"
        Me.txtGiorniTrasfertaItalia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(726, 13)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(19, 23)
        Me.Label24.TabIndex = 242
        Me.Label24.Text = "="
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.txtContanti)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCompetenze)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtRiporti)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.txtSpese)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txtDiaria)
        Me.GroupBox1.Location = New System.Drawing.Point(43, 149)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(705, 47)
        Me.GroupBox1.TabIndex = 238
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Totali"
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(385, 11)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(19, 23)
        Me.Label17.TabIndex = 245
        Me.Label17.Text = "+"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label19
        '
        Me.Label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(405, 19)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(63, 20)
        Me.Label19.TabIndex = 243
        Me.Label19.Text = "Contanti"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtContanti
        '
        Me.txtContanti.Location = New System.Drawing.Point(469, 19)
        Me.txtContanti.Name = "txtContanti"
        Me.txtContanti.Size = New System.Drawing.Size(60, 20)
        Me.txtContanti.TabIndex = 244
        Me.txtContanti.Text = "0.0"
        Me.txtContanti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(535, 12)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(19, 23)
        Me.Label11.TabIndex = 242
        Me.Label11.Text = "="
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(555, 19)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(71, 20)
        Me.Label12.TabIndex = 240
        Me.Label12.Text = "Competenze"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompetenze
        '
        Me.txtCompetenze.Location = New System.Drawing.Point(626, 19)
        Me.txtCompetenze.Name = "txtCompetenze"
        Me.txtCompetenze.Size = New System.Drawing.Size(60, 20)
        Me.txtCompetenze.TabIndex = 241
        Me.txtCompetenze.Text = "0.00"
        Me.txtCompetenze.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(243, 11)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(19, 23)
        Me.Label13.TabIndex = 239
        Me.Label13.Text = "+"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(263, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(59, 20)
        Me.Label14.TabIndex = 237
        Me.Label14.Text = "Riporti"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRiporti
        '
        Me.txtRiporti.Location = New System.Drawing.Point(322, 19)
        Me.txtRiporti.Name = "txtRiporti"
        Me.txtRiporti.Size = New System.Drawing.Size(60, 20)
        Me.txtRiporti.TabIndex = 238
        Me.txtRiporti.Text = "0.00"
        Me.txtRiporti.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(120, 9)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(19, 23)
        Me.Label15.TabIndex = 236
        Me.Label15.Text = "-"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label16
        '
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(140, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 20)
        Me.Label16.TabIndex = 234
        Me.Label16.Text = "Spese"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtSpese
        '
        Me.txtSpese.Location = New System.Drawing.Point(180, 19)
        Me.txtSpese.Name = "txtSpese"
        Me.txtSpese.Size = New System.Drawing.Size(60, 20)
        Me.txtSpese.TabIndex = 235
        Me.txtSpese.Text = "0.00"
        Me.txtSpese.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label18
        '
        Me.Label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(16, 19)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(40, 20)
        Me.Label18.TabIndex = 231
        Me.Label18.Text = "Diaria"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiaria
        '
        Me.txtDiaria.Location = New System.Drawing.Point(57, 19)
        Me.txtDiaria.Name = "txtDiaria"
        Me.txtDiaria.Size = New System.Drawing.Size(61, 20)
        Me.txtDiaria.TabIndex = 232
        Me.txtDiaria.Text = "0.00"
        Me.txtDiaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label38)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txtCompetenzeStraordinario)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtTrasferta)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtCostoOrario)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtOreInBusta)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtOreFatte)
        Me.GroupBox3.Location = New System.Drawing.Point(43, 96)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(705, 47)
        Me.GroupBox3.TabIndex = 237
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Straordinari"
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.Transparent
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(4, 11)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(14, 29)
        Me.Label38.TabIndex = 244
        Me.Label38.Text = "("
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(250, 11)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(14, 29)
        Me.Label25.TabIndex = 243
        Me.Label25.Text = ")"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(535, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(19, 23)
        Me.Label9.TabIndex = 242
        Me.Label9.Text = "="
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(555, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 20)
        Me.Label10.TabIndex = 240
        Me.Label10.Text = "Competenze"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCompetenzeStraordinario
        '
        Me.txtCompetenzeStraordinario.Location = New System.Drawing.Point(626, 20)
        Me.txtCompetenzeStraordinario.Name = "txtCompetenzeStraordinario"
        Me.txtCompetenzeStraordinario.Size = New System.Drawing.Size(60, 20)
        Me.txtCompetenzeStraordinario.TabIndex = 241
        Me.txtCompetenzeStraordinario.Text = "0.00"
        Me.txtCompetenzeStraordinario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(391, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(19, 23)
        Me.Label7.TabIndex = 239
        Me.Label7.Text = "+"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(411, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 20)
        Me.Label8.TabIndex = 237
        Me.Label8.Text = "Trasferta"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTrasferta
        '
        Me.txtTrasferta.Location = New System.Drawing.Point(469, 20)
        Me.txtTrasferta.Name = "txtTrasferta"
        Me.txtTrasferta.Size = New System.Drawing.Size(60, 20)
        Me.txtTrasferta.TabIndex = 238
        Me.txtTrasferta.Text = "0.00"
        Me.txtTrasferta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(260, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 23)
        Me.Label6.TabIndex = 236
        Me.Label6.Text = "*"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(279, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 20)
        Me.Label5.TabIndex = 234
        Me.Label5.Text = "Costo orario"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCostoOrario
        '
        Me.txtCostoOrario.Location = New System.Drawing.Point(350, 20)
        Me.txtCostoOrario.Name = "txtCostoOrario"
        Me.txtCostoOrario.Size = New System.Drawing.Size(39, 20)
        Me.txtCostoOrario.TabIndex = 235
        Me.txtCostoOrario.Text = "35,00"
        Me.txtCostoOrario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(119, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(19, 23)
        Me.Label3.TabIndex = 233
        Me.Label3.Text = "-"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(139, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 20)
        Me.Label2.TabIndex = 231
        Me.Label2.Text = "Ore in busta"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOreInBusta
        '
        Me.txtOreInBusta.Location = New System.Drawing.Point(210, 20)
        Me.txtOreInBusta.Name = "txtOreInBusta"
        Me.txtOreInBusta.Size = New System.Drawing.Size(39, 20)
        Me.txtOreInBusta.TabIndex = 232
        Me.txtOreInBusta.Text = "00:00"
        Me.txtOreInBusta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(19, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.TabIndex = 229
        Me.Label4.Text = "Ore Fatte"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOreFatte
        '
        Me.txtOreFatte.Location = New System.Drawing.Point(79, 20)
        Me.txtOreFatte.Name = "txtOreFatte"
        Me.txtOreFatte.Size = New System.Drawing.Size(39, 20)
        Me.txtOreFatte.TabIndex = 230
        Me.txtOreFatte.Text = "00:00"
        Me.txtOreFatte.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboEmployeeName
        '
        Me.cboEmployeeName.BackColor = System.Drawing.SystemColors.Window
        Me.cboEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeName.Location = New System.Drawing.Point(123, 14)
        Me.cboEmployeeName.Name = "cboEmployeeName"
        Me.cboEmployeeName.Size = New System.Drawing.Size(220, 21)
        Me.cboEmployeeName.TabIndex = 236
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(77, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 20)
        Me.Label1.TabIndex = 235
        Me.Label1.Text = "Nome"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.dgv.Location = New System.Drawing.Point(11, 210)
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
        Me.dgv.Size = New System.Drawing.Size(859, 403)
        Me.dgv.TabIndex = 234
        '
        'lblData
        '
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.Location = New System.Drawing.Point(375, 13)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(41, 20)
        Me.lblData.TabIndex = 205
        Me.lblData.Text = "Data"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(416, 13)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(203, 20)
        Me.dtpDate.TabIndex = 143
        '
        'ucCable3
        '
        Me.ucCable3.BackColor = System.Drawing.Color.Black
        Me.ucCable3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ucCable3.Location = New System.Drawing.Point(543, 93)
        Me.ucCable3.Name = "ucCable3"
        Me.ucCable3.Size = New System.Drawing.Size(276, 4)
        Me.ucCable3.TabIndex = 242
        '
        'ucCable2
        '
        Me.ucCable2.BackColor = System.Drawing.Color.Black
        Me.ucCable2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ucCable2.Location = New System.Drawing.Point(818, 70)
        Me.ucCable2.Name = "ucCable2"
        Me.ucCable2.Size = New System.Drawing.Size(4, 27)
        Me.ucCable2.TabIndex = 241
        '
        'ucCable1
        '
        Me.ucCable1.BackColor = System.Drawing.Color.Black
        Me.ucCable1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ucCable1.Location = New System.Drawing.Point(802, 70)
        Me.ucCable1.Name = "ucCable1"
        Me.ucCable1.Size = New System.Drawing.Size(20, 4)
        Me.ucCable1.TabIndex = 240
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -2)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 619)
        Me.mnu.TabIndex = 1
        '
        'frmAdjustExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 632)
        Me.Controls.Add(Me.panOreLavoro)
        Me.Controls.Add(Me.panMenu)
        Me.Name = "frmAdjustExpenses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmAdjustExpenses"
        Me.panMenu.ResumeLayout(False)
        Me.panOreLavoro.ResumeLayout(False)
        CType(Me.picArrowUp, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents mnu As ucMenu
    Friend WithEvents panOreLavoro As Panel
    Friend WithEvents Label1 As Label
    Private WithEvents dgv As DataGridView
    Friend WithEvents lblData As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents cboEmployeeName As ComboBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCompetenze As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents txtRiporti As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtSpese As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents txtDiaria As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCompetenzeStraordinario As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTrasferta As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtCostoOrario As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtOreInBusta As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtOreFatte As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents txtContanti As TextBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label28 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents lblCostoTrasfertaLungo As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents txtGiorniTrasfertaEsteroLungo As TextBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents lblCostoTrasfertaEstero As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents txtGiorniTrasfertaEstero As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents lblCostoTrasfertaItalia As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtGiorniTrasfertaItalia As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents picArrowUp As PictureBox
    Friend WithEvents ucCable3 As ucCable
    Friend WithEvents ucCable2 As ucCable
    Friend WithEvents ucCable1 As ucCable
    Friend WithEvents Label38 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents txtTrasfertaCedolino As TextBox
    Friend WithEvents Label30 As Label
    Friend WithEvents Label27 As Label
End Class
