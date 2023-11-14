<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExpenses
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExpenses))
        Me.panMenu = New System.Windows.Forms.Panel()
        Me.mnu = New OreLavoro.ucMenu()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.panOreLavoro = New System.Windows.Forms.Panel()
        Me.cboEmployeeName = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.dgv = New System.Windows.Forms.DataGridView()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.optStraordinario = New System.Windows.Forms.RadioButton()
        Me.optNormale = New System.Windows.Forms.RadioButton()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.optPieDiLista = New System.Windows.Forms.RadioButton()
        Me.optForfait = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.chkEstero = New System.Windows.Forms.CheckBox()
        Me.chkItaly = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCity = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtKm = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtValuta = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCartaCredito = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtDiaria = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtVarie = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtAlloggio = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtVitto = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMezziPubblici = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAutostrada = New System.Windows.Forms.TextBox()
        Me.plsFilter = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboOrderName = New System.Windows.Forms.ComboBox()
        Me.plsNext = New System.Windows.Forms.Button()
        Me.lblData = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.panMenu.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.panOreLavoro.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'panMenu
        '
        Me.panMenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panMenu.Controls.Add(Me.mnu)
        Me.panMenu.Location = New System.Drawing.Point(4, 3)
        Me.panMenu.Name = "panMenu"
        Me.panMenu.Size = New System.Drawing.Size(136, 620)
        Me.panMenu.TabIndex = 146
        '
        'mnu
        '
        Me.mnu.Location = New System.Drawing.Point(-1, -2)
        Me.mnu.Name = "mnu"
        Me.mnu.Size = New System.Drawing.Size(135, 619)
        Me.mnu.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.BackColor = System.Drawing.SystemColors.Control
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.OrangeRed
        Me.Label24.Location = New System.Drawing.Point(28, 21)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 17)
        Me.Label24.TabIndex = 15
        Me.Label24.Text = "cizeta"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label25
        '
        Me.Label25.BackColor = System.Drawing.SystemColors.Control
        Me.Label25.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label25.Location = New System.Drawing.Point(28, 5)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(65, 17)
        Me.Label25.TabIndex = 14
        Me.Label25.Text = "Powered by"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.Label24)
        Me.Panel4.Controls.Add(Me.Label25)
        Me.Panel4.Cursor = System.Windows.Forms.Cursors.Default
        Me.Panel4.Location = New System.Drawing.Point(52, 768)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(124, 51)
        Me.Panel4.TabIndex = 149
        '
        'panOreLavoro
        '
        Me.panOreLavoro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.panOreLavoro.Controls.Add(Me.cboEmployeeName)
        Me.panOreLavoro.Controls.Add(Me.Label15)
        Me.panOreLavoro.Controls.Add(Me.dgv)
        Me.panOreLavoro.Controls.Add(Me.GroupBox5)
        Me.panOreLavoro.Controls.Add(Me.GroupBox4)
        Me.panOreLavoro.Controls.Add(Me.GroupBox3)
        Me.panOreLavoro.Controls.Add(Me.GroupBox2)
        Me.panOreLavoro.Controls.Add(Me.GroupBox1)
        Me.panOreLavoro.Controls.Add(Me.plsFilter)
        Me.panOreLavoro.Controls.Add(Me.Label1)
        Me.panOreLavoro.Controls.Add(Me.cboOrderName)
        Me.panOreLavoro.Controls.Add(Me.plsNext)
        Me.panOreLavoro.Controls.Add(Me.lblData)
        Me.panOreLavoro.Controls.Add(Me.dtpDate)
        Me.panOreLavoro.Location = New System.Drawing.Point(146, 3)
        Me.panOreLavoro.Name = "panOreLavoro"
        Me.panOreLavoro.Size = New System.Drawing.Size(877, 620)
        Me.panOreLavoro.TabIndex = 150
        '
        'cboEmployeeName
        '
        Me.cboEmployeeName.BackColor = System.Drawing.SystemColors.Window
        Me.cboEmployeeName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeName.Location = New System.Drawing.Point(45, 7)
        Me.cboEmployeeName.Name = "cboEmployeeName"
        Me.cboEmployeeName.Size = New System.Drawing.Size(222, 21)
        Me.cboEmployeeName.TabIndex = 240
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(7, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(38, 20)
        Me.Label15.TabIndex = 239
        Me.Label15.Text = "Nome"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.dgv.Location = New System.Drawing.Point(5, 143)
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
        Me.dgv.Size = New System.Drawing.Size(859, 470)
        Me.dgv.TabIndex = 234
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.optStraordinario)
        Me.GroupBox5.Controls.Add(Me.optNormale)
        Me.GroupBox5.Location = New System.Drawing.Point(472, 39)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(183, 47)
        Me.GroupBox5.TabIndex = 233
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Motivo"
        '
        'optStraordinario
        '
        Me.optStraordinario.Location = New System.Drawing.Point(89, 15)
        Me.optStraordinario.Name = "optStraordinario"
        Me.optStraordinario.Size = New System.Drawing.Size(85, 24)
        Me.optStraordinario.TabIndex = 230
        Me.optStraordinario.TabStop = True
        Me.optStraordinario.Text = "Straordinario"
        Me.optStraordinario.UseVisualStyleBackColor = True
        '
        'optNormale
        '
        Me.optNormale.Location = New System.Drawing.Point(12, 15)
        Me.optNormale.Name = "optNormale"
        Me.optNormale.Size = New System.Drawing.Size(65, 24)
        Me.optNormale.TabIndex = 229
        Me.optNormale.TabStop = True
        Me.optNormale.Text = "Normale"
        Me.optNormale.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.optPieDiLista)
        Me.GroupBox4.Controls.Add(Me.optForfait)
        Me.GroupBox4.Location = New System.Drawing.Point(661, 39)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(203, 47)
        Me.GroupBox4.TabIndex = 232
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Tipo"
        '
        'optPieDiLista
        '
        Me.optPieDiLista.Location = New System.Drawing.Point(105, 15)
        Me.optPieDiLista.Name = "optPieDiLista"
        Me.optPieDiLista.Size = New System.Drawing.Size(73, 24)
        Me.optPieDiLista.TabIndex = 230
        Me.optPieDiLista.TabStop = True
        Me.optPieDiLista.Text = "Piè di lista"
        Me.optPieDiLista.UseVisualStyleBackColor = True
        '
        'optForfait
        '
        Me.optForfait.Location = New System.Drawing.Point(12, 15)
        Me.optForfait.Name = "optForfait"
        Me.optForfait.Size = New System.Drawing.Size(60, 24)
        Me.optForfait.TabIndex = 229
        Me.optForfait.TabStop = True
        Me.optForfait.Text = "Forfait"
        Me.optForfait.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.chkEstero)
        Me.GroupBox3.Controls.Add(Me.chkItaly)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.txtCity)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtKm)
        Me.GroupBox3.Location = New System.Drawing.Point(5, 39)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(451, 47)
        Me.GroupBox3.TabIndex = 231
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Località"
        '
        'chkEstero
        '
        Me.chkEstero.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkEstero.BackgroundImage = CType(resources.GetObject("chkEstero.BackgroundImage"), System.Drawing.Image)
        Me.chkEstero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.chkEstero.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkEstero.Location = New System.Drawing.Point(401, 12)
        Me.chkEstero.Name = "chkEstero"
        Me.chkEstero.Size = New System.Drawing.Size(34, 30)
        Me.chkEstero.TabIndex = 231
        Me.chkEstero.UseVisualStyleBackColor = True
        '
        'chkItaly
        '
        Me.chkItaly.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkItaly.BackgroundImage = CType(resources.GetObject("chkItaly.BackgroundImage"), System.Drawing.Image)
        Me.chkItaly.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.chkItaly.Location = New System.Drawing.Point(356, 12)
        Me.chkItaly.Name = "chkItaly"
        Me.chkItaly.Size = New System.Drawing.Size(34, 30)
        Me.chkItaly.TabIndex = 230
        Me.chkItaly.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 20)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Città"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCity
        '
        Me.txtCity.Location = New System.Drawing.Point(51, 19)
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(224, 20)
        Me.txtCity.TabIndex = 224
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(285, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 20)
        Me.Label3.TabIndex = 225
        Me.Label3.Text = "Km"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtKm
        '
        Me.txtKm.Location = New System.Drawing.Point(310, 19)
        Me.txtKm.Name = "txtKm"
        Me.txtKm.Size = New System.Drawing.Size(41, 20)
        Me.txtKm.TabIndex = 226
        Me.txtKm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.txtValuta)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCartaCredito)
        Me.GroupBox2.Location = New System.Drawing.Point(661, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(203, 47)
        Me.GroupBox2.TabIndex = 230
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Anticipi"
        '
        'Label10
        '
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(105, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(39, 20)
        Me.Label10.TabIndex = 239
        Me.Label10.Text = "Valuta"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtValuta
        '
        Me.txtValuta.Location = New System.Drawing.Point(144, 18)
        Me.txtValuta.Name = "txtValuta"
        Me.txtValuta.Size = New System.Drawing.Size(49, 20)
        Me.txtValuta.TabIndex = 240
        Me.txtValuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(6, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 20)
        Me.Label9.TabIndex = 237
        Me.Label9.Text = "Carta"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCartaCredito
        '
        Me.txtCartaCredito.Location = New System.Drawing.Point(45, 18)
        Me.txtCartaCredito.Name = "txtCartaCredito"
        Me.txtCartaCredito.Size = New System.Drawing.Size(49, 20)
        Me.txtCartaCredito.TabIndex = 238
        Me.txtCartaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtDiaria)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtVarie)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txtAlloggio)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtVitto)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtMezziPubblici)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtAutostrada)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 90)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(650, 47)
        Me.GroupBox1.TabIndex = 229
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Spese"
        '
        'Label11
        '
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(561, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(39, 20)
        Me.Label11.TabIndex = 237
        Me.Label11.Text = "Diaria"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtDiaria
        '
        Me.txtDiaria.Location = New System.Drawing.Point(600, 18)
        Me.txtDiaria.Name = "txtDiaria"
        Me.txtDiaria.Size = New System.Drawing.Size(41, 20)
        Me.txtDiaria.TabIndex = 238
        Me.txtDiaria.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(467, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 20)
        Me.Label8.TabIndex = 235
        Me.Label8.Text = "Varie"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVarie
        '
        Me.txtVarie.Location = New System.Drawing.Point(506, 18)
        Me.txtVarie.Name = "txtVarie"
        Me.txtVarie.Size = New System.Drawing.Size(49, 20)
        Me.txtVarie.TabIndex = 236
        Me.txtVarie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(352, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 20)
        Me.Label7.TabIndex = 233
        Me.Label7.Text = "Alloggio"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAlloggio
        '
        Me.txtAlloggio.Location = New System.Drawing.Point(412, 18)
        Me.txtAlloggio.Name = "txtAlloggio"
        Me.txtAlloggio.Size = New System.Drawing.Size(49, 20)
        Me.txtAlloggio.TabIndex = 234
        Me.txtAlloggio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(258, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(38, 20)
        Me.Label6.TabIndex = 231
        Me.Label6.Text = "Vitto"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtVitto
        '
        Me.txtVitto.Location = New System.Drawing.Point(296, 19)
        Me.txtVitto.Name = "txtVitto"
        Me.txtVitto.Size = New System.Drawing.Size(49, 20)
        Me.txtVitto.TabIndex = 232
        Me.txtVitto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(128, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 229
        Me.Label5.Text = "Mezzi pubblici"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtMezziPubblici
        '
        Me.txtMezziPubblici.Location = New System.Drawing.Point(204, 19)
        Me.txtMezziPubblici.Name = "txtMezziPubblici"
        Me.txtMezziPubblici.Size = New System.Drawing.Size(49, 20)
        Me.txtMezziPubblici.TabIndex = 230
        Me.txtMezziPubblici.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 20)
        Me.Label4.TabIndex = 227
        Me.Label4.Text = "Autostrada"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAutostrada
        '
        Me.txtAutostrada.Location = New System.Drawing.Point(72, 19)
        Me.txtAutostrada.Name = "txtAutostrada"
        Me.txtAutostrada.Size = New System.Drawing.Size(49, 20)
        Me.txtAutostrada.TabIndex = 228
        Me.txtAutostrada.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'plsFilter
        '
        Me.plsFilter.Image = CType(resources.GetObject("plsFilter.Image"), System.Drawing.Image)
        Me.plsFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsFilter.Location = New System.Drawing.Point(838, 4)
        Me.plsFilter.Name = "plsFilter"
        Me.plsFilter.Size = New System.Drawing.Size(25, 26)
        Me.plsFilter.TabIndex = 222
        Me.plsFilter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(554, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 20)
        Me.Label1.TabIndex = 221
        Me.Label1.Text = "Commessa"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboOrderName
        '
        Me.cboOrderName.BackColor = System.Drawing.SystemColors.Window
        Me.cboOrderName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrderName.Location = New System.Drawing.Point(614, 7)
        Me.cboOrderName.Name = "cboOrderName"
        Me.cboOrderName.Size = New System.Drawing.Size(220, 21)
        Me.cboOrderName.TabIndex = 220
        '
        'plsNext
        '
        Me.plsNext.Image = CType(resources.GetObject("plsNext.Image"), System.Drawing.Image)
        Me.plsNext.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.plsNext.Location = New System.Drawing.Point(516, 4)
        Me.plsNext.Name = "plsNext"
        Me.plsNext.Size = New System.Drawing.Size(25, 26)
        Me.plsNext.TabIndex = 218
        Me.plsNext.UseVisualStyleBackColor = True
        '
        'lblData
        '
        Me.lblData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblData.Location = New System.Drawing.Point(277, 7)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(33, 20)
        Me.lblData.TabIndex = 205
        Me.lblData.Text = "Data"
        Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(311, 7)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(203, 20)
        Me.dtpDate.TabIndex = 143
        Me.dtpDate.Value = New Date(2023, 7, 13, 0, 0, 0, 0)
        '
        'frmExpenses
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 633)
        Me.Controls.Add(Me.panOreLavoro)
        Me.Controls.Add(Me.panMenu)
        Me.Controls.Add(Me.Panel4)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmExpenses"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmExpenses"
        Me.panMenu.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.panOreLavoro.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panMenu As Panel
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents panOreLavoro As Panel
    Friend WithEvents plsNext As Button
    Friend WithEvents lblData As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents mnu As ucMenu
    Friend WithEvents plsFilter As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents cboOrderName As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtVarie As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtAlloggio As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtVitto As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMezziPubblici As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtAutostrada As TextBox
    Friend WithEvents txtKm As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtCity As TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtCartaCredito As TextBox
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents optStraordinario As RadioButton
    Friend WithEvents optNormale As RadioButton
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents optPieDiLista As RadioButton
    Friend WithEvents optForfait As RadioButton
    Friend WithEvents Label10 As Label
    Friend WithEvents txtValuta As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents txtDiaria As TextBox
    Private WithEvents dgv As DataGridView
    Friend WithEvents chkEstero As CheckBox
    Friend WithEvents chkItaly As CheckBox
    Friend WithEvents cboEmployeeName As ComboBox
    Friend WithEvents Label15 As Label
End Class
