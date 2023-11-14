Imports Core

Public Class frmWorkingDiary

    Private Const cOrderSeparator = "----------"

    Private dtOreLavoro As New DataTable

    Private LastDateShown As Date = Now

    Private CheckInputData As Core.CheckInputData

    Private dtpDateChanging As Boolean = False

    Private dgvSelecting As Boolean = False

    Private Sub frmWorkingDiary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Ore lavoro"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        LoadEmpolyeeComboBox()
        LoadOrdersComboBox("%")
        LoadActivityComboBox()
        LoadSectorComboBox()
        LoadDateTimePicker()

        cboEmployeeName.Text = xUsers.UserLogged.Name

        LoadData()

    End Sub


    Private Sub LoadEmpolyeeComboBox()
        cboEmployeeName.Items.Clear()
        Dim EmpolyeeList As List(Of String) = xDatabase.GetEmpolyeeList()
        For Each str As String In EmpolyeeList
            cboEmployeeName.Items.Add(str)
        Next
        cboEmployeeName.Text = xUsers.UserLogged.Name
        ''Load orders
        'cboEmployeeName.Items.Clear()
        'Dim strs As New List(Of String)
        'For Each usr As Users.udtUser In xUsers.Users
        '    strs.Add(usr.Name)
        'Next
        'strs.Sort()
        'For Each str As String In strs
        '    cboEmployeeName.Items.Add(str)
        'Next
        'cboEmployeeName.Text = xUsers.UserLogged.Name
    End Sub
    Private Sub LoadOrdersComboBox(Filter As String)
        LoadOrdersComboBox(Filter, False)

    End Sub
    Private Sub LoadOrdersComboBox(Filter As String, ShowValue As Boolean)
        cboOrderName.Items.Clear()
        cboOrderName.Items.Add("Ferie")
        cboOrderName.Items.Add("Mutua")
        cboOrderName.Items.Add(cOrderSeparator)
        Dim orders As New List(Of String)
        orders = xDatabase.GetOrderList(Filter)
        For Each str As String In orders
            cboOrderName.Items.Add(str)
        Next
        If ShowValue Then
            If orders.Count > 0 Then
                cboOrderName.Text = orders(0)
            End If
        End If
    End Sub
    Private Sub LoadActivityComboBox()
        'Load orders
        cboActivity.Items.Clear()
        Dim Activity As New List(Of String)
        Activity = xDatabase.GetActivityList()
        For Each str As String In Activity
            cboActivity.Items.Add(str.ToUpper)
        Next
    End Sub
    Private Sub LoadSectorComboBox()
        'Load orders
        cboSector.Items.Clear()
        Dim Sectors As New List(Of String)
        Sectors = xDatabase.GetSectorList()
        For Each str As String In Sectors
            cboSector.Items.Add(str.ToUpper)
        Next
    End Sub

    Private Sub LoadDateTimePicker()
        Dim d As Date = Date.Now
        Dim DaysInMonth As Integer = Date.DaysInMonth(d.Year, d.Month)
        Dim EndDate As Date = New Date(d.Year, d.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(d.Year, d.Month, 1)

        dtpDate.Value = BeginDate


    End Sub

    Private Sub LoadData()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filter As New DatabaseManagement.udtFilterOreLavoro
        Filter.EmployeeName = cboEmployeeName.Text   'xUsers.UserLogged.Name
        Filter.OrderName = "%"
        Filter.Activity = "%"
        Filter.Sector = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        dtOreLavoro = xDatabase.GetWorkedHoursMonthly(Filter)
        'dtOreLavoro = xDatabase.GetOreLavoro(xUsers.UserLogged.Name, BeginDate, EndDate)

        If IsNothing(dtOreLavoro) Then
            dgvOreLavoro.DataSource = Nothing
            dgvOreLavoro.Rows.Clear()
        Else
            dgvOreLavoro.DataSource = dtOreLavoro 'bsTrace
            dgvOreLavoro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            'dgvOreLavoro.RowHeadersWidth = 10
            dgvOreLavoro.RowHeadersVisible = False
            If dgvOreLavoro.ColumnCount > 1 Then
                dgvOreLavoro.Columns(0).Width = 50
                dgvOreLavoro.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOreLavoro.Columns(1).Width = 230
                dgvOreLavoro.Columns(2).Width = 120
                dgvOreLavoro.Columns(3).Width = 100
                dgvOreLavoro.Columns(4).Width = 60
                dgvOreLavoro.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOreLavoro.Columns(5).Width = 60
                dgvOreLavoro.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If


            Dim ore As udtOre = GetOre(dtOreLavoro, 4, 5)
            lblTotaleOreLavoro.Text = TimeSpanToText(ore.Lavoro)
            lblTotaleOreViaggio.Text = TimeSpanToText(ore.Viaggio)

            Dim wh As TimeSpan = GetWorkingHours(BeginDate, EndDate)
            ore.Straordinario = ore.Lavoro.Add(ore.Viaggio)
            ore.Straordinario = ore.Straordinario.Subtract(wh)
            lblTotaleOreStraordinario.Text = TimeSpanToText(ore.Straordinario)
            If lblTotaleOreStraordinario.Text.Contains("-") Then
                lblTotaleOreStraordinario.Text = "0:0"
            End If
        End If

    End Sub



#Region "Menu"

    Private Sub ShowMenu()
        Try

            mnu.CreateMenu(Me, xConfig.GetFormMenus(MyBase.Name))
            mnu.ShowMenu("Main")

        Catch ex As Exception

        End Try

    End Sub

    Private Sub mnu_ButtonClick(MenuName As String, ButtonName As String, Checked As CheckState) Handles mnu.ButtonClick
        Select Case MenuName
            Case "Main"
                Select Case ButtonName
                    Case "Close"
                        Call Shut()


                    Case "Write"
                        Write()

                    Case "Delete"
                        Call Delete()

                    Case "Print"
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        Print()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default


                    Case "AdjustExpenses"
                        mnu.SuspendMenu()
                        Using frm As New frmAdjustExpenses
                            frm.ShowDialog(Me)
                        End Using
                        mnu.ActivateMenuSuspended()

                    Case "Import"
                        mnu.SuspendMenu()
                        Dim frm As New frmImportaOreLavoro
                        frm.EmployeeName = cboEmployeeName.Text
                        frm.dtpDate = dtpDate
                        frm.ShowDialog(Me)
                        frm.Dispose()
                        frm = Nothing
                        LoadData()
                        mnu.ActivateMenuSuspended()

                    Case "Analysis"
                        mnu.SuspendMenu()
                        Dim frm As New frmAnalisiOreLavoro
                        frm.ShowDialog(Me)
                        frm.Dispose()
                        frm = Nothing
                        mnu.ActivateMenuSuspended()


                End Select
        End Select



    End Sub


    Private Sub cboEmployeeName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmployeeName.SelectedIndexChanged
        LoadData()
    End Sub

    Private Sub plsNext_Click(sender As Object, e As EventArgs) Handles plsNext.Click
        dtpDateChanging = True
        dtpDate.Value = DateAdd("d", 1, dtpDate.Value)
        dtpDateChanging = False
    End Sub

    Private Sub plsFilter_Click(sender As Object, e As EventArgs) Handles plsFilter.Click
        mnu.SuspendMenu()
        Using dlg As New frmFilter
            If dlg.ShowDialog() = DialogResult.OK Then
                LoadOrdersComboBox(dlg.Filter & "%", True)
            End If
        End Using

        mnu.ActivateMenuSuspended()
    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged

        If dgvSelecting Then Return

        If DateDiff(DateInterval.Month, LastDateShown, dtpDate.Value) <> 0 Then
            LastDateShown = dtpDate.Value
            LoadData()
        End If

        dtpDateChanging = True
        For Each r As DataGridViewRow In dgvOreLavoro.Rows
            If r.Cells("Giorno").Value = dtpDate.Value.Day Then
                r.Selected = True
            Else
                r.Selected = False
            End If
        Next
        dtpDateChanging = False
    End Sub

    Private Sub dgvOreLavoro_SelectionChanged(sender As Object, e As EventArgs) Handles dgvOreLavoro.SelectionChanged



        If dtpDateChanging Then Return
        dgvSelecting = True

        If dgvOreLavoro.SelectedRows.Count > 0 Then
            txtOreLavoro.Text = dgvOreLavoro.SelectedRows(0).Cells("OreLavoro").Value
            txtOreViaggio.Text = dgvOreLavoro.SelectedRows(0).Cells("OreViaggio").Value
            cboOrderName.Text = dgvOreLavoro.SelectedRows(0).Cells("Commessa").Value
            cboActivity.Text = dgvOreLavoro.SelectedRows(0).Cells("Attività").Value
            cboSector.Text = dgvOreLavoro.SelectedRows(0).Cells("Settore").Value
            dtpDate.Value = CDate(dtpDate.Value.Year.ToString + "-" + dtpDate.Value.Month.ToString + "-" + dgvOreLavoro.SelectedRows(0).Cells("Giorno").Value.ToString)
        Else
            'txtOreLavoro.Text = "0"
            'txtOreViaggio.Text = "0"
            'cboCommessa.Text = ""
            'cboAttivita.Text = ""
            'cboSettore.Text = ""
        End If
        dgvSelecting = False
    End Sub

    Private Sub Write()
        If Not CheckData() Then
            MsgBox(CheckInputData.NokResult.ToString, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim rec As New DatabaseManagement.udtRecordOreLavoro
        rec.UserName = cboEmployeeName.Text   'xUsers.UserLogged.Name
        rec.OrderName = cboOrderName.Text
        rec.Activity = cboActivity.Text
        rec.Sector = cboSector.Text
        rec.Timestamp = Format(dtpDate.Value, "yyyy/MM/dd")
        rec.WorkHours = TextToSingle(txtOreLavoro.Text)
        rec.TravelHours = TextToSingle(txtOreViaggio.Text)
        If xDatabase.RecordOreLavoroExists(rec) Then
            If MsgBox("Dati esistenti. Vuoi sovrascriverli?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim RowSelected As Integer = dgvOreLavoro.SelectedRows(0).Index
                xDatabase.UpdateOreLavoro(rec)
                LoadData()
                dgvOreLavoro.ClearSelection()
                dgvOreLavoro.Rows(RowSelected).Selected = True
            Else

            End If
        Else
            'Add new record
            Dim day As Integer = dtpDate.Value.Day
            xDatabase.AddOreLavoro(rec)
            LoadData()
            dgvOreLavoro.ClearSelection()
            'dgvOreLavoro.Rows(dgvOreLavoro.RowCount - 1).Selected = True
            For Each r As DataGridViewRow In dgvOreLavoro.Rows
                If r.Cells("Giorno").Value = day Then
                    r.Selected = True
                Else
                    r.Selected = False
                End If
            Next
        End If

        'Write expense if necessary (journey hours > 0)
        If rec.TravelHours > 0 Then
            Dim ExpRec As New DatabaseManagement.udtRecordRefound
            ExpRec.UserName = cboEmployeeName.Text     'xUsers.UserLogged.Name
            ExpRec.City = ""
            ExpRec.OrderName = cboOrderName.Text
            ExpRec.Timestamp = Format(dtpDate.Value, "yyyy/MM/dd")
            ExpRec.Alloggio = 0
            ExpRec.Autostrada = 0
            ExpRec.CartaCredito = 0
            ExpRec.Diaria = 0
            ExpRec.Km = ""
            ExpRec.MezziPubblici = 0
            ExpRec.Valuta = 0
            ExpRec.Varie = 0
            ExpRec.Vitto = 0
            ExpRec.TipoRimborso = "F"
            ExpRec.Motivo = "R"

            If xDatabase.RecordRefoundExists(ExpRec) Then
                'Update record
                xDatabase.UpdateRefound(ExpRec)
                LoadData()
            Else
                'Add record
                xDatabase.AddRefound(ExpRec)
                LoadData()
            End If
        Else

            End If


    End Sub

    Private Sub Delete()
        Dim rec As New DatabaseManagement.udtRecordOreLavoro
        rec.UserName = cboEmployeeName.Text   'xUsers.UserLogged.Name
        rec.OrderName = cboOrderName.Text
        rec.Activity = cboActivity.Text
        rec.Sector = cboSector.Text
        rec.Timestamp = dtpDate.Value
        rec.WorkHours = TextToSingle(txtOreLavoro.Text)
        rec.TravelHours = TextToSingle(txtOreViaggio.Text)

        If xDatabase.RecordOreLavoroExists(rec) Then
            If MsgBox("Cancello riga selezionata. Sei DAVVERO sicuro?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim RowSelected As Integer = dgvOreLavoro.SelectedRows(0).Index
                xDatabase.DeleteOreLavoro(rec)
                LoadData()
            End If
        End If
    End Sub

    Private Sub Print()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filename As String = ""

        Dim Filter As New DatabaseManagement.udtFilterOreLavoro
        Filter.EmployeeName = cboEmployeeName.Text   'xUsers.UserLogged.Name
        Filter.OrderName = "%"
        Filter.Activity = "%"
        Filter.Sector = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate

        Dim Month As String = Filter.BeginDate.ToString("MMMM")
        Dim Year As String = Filter.BeginDate.ToString("yyyy")

        Filename = "C:\OreLavoro\Ore-" & Filter.EmployeeName & "-" & Month & "-" & Year & ".pdf"

        Dim pdf As New PrintToPDF
        pdf.PrintOreLavoro(Filename, Filter)


        Dim pdfShow As New frmShowPdf
        pdfShow.FileToShow = Filename
        pdfShow.Size = New Size(1024, 768)
        pdfShow.ShowDialog()
        pdfShow.Dispose()
        pdfShow = Nothing


    End Sub


    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub


#End Region



#Region "Check data input"

    Private Sub SelectOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        'sender.SelectAll()
    End Sub
    Private Sub OnlyTimeOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtOreLavoro.KeyPress, txtOreViaggio.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyTime(sender, e.KeyChar)
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        If Not CheckInputData.IsTime(txtOreLavoro) Then Return False
        If Not CheckInputData.IsTime(txtOreViaggio) Then Return False

        If cboOrderName.Text = "" Then
            CheckInputData.NokResult = CheckInputData.enumNokResult.ValoreDeveEsistere
            cboOrderName.Focus()
            lblOrderName.BackColor = Color.Coral
            Return False
        End If
        If cboOrderName.Text = cOrderSeparator Then
            CheckInputData.NokResult = CheckInputData.enumNokResult.ValoreErrato
            cboOrderName.Focus()
            lblOrderName.BackColor = Color.Coral
            Return False
        End If

        If cboActivity.Text = "" Then
            CheckInputData.NokResult = CheckInputData.enumNokResult.ValoreDeveEsistere
            cboActivity.Focus()
            lblActivity.BackColor = Color.Coral
            Return False
        End If
        If cboSector.Text = "" Then
            CheckInputData.NokResult = CheckInputData.enumNokResult.ValoreDeveEsistere
            cboSector.Focus()
            lblSector.BackColor = Color.Coral
            Return False
        End If


        Return True

    End Function

    Private Sub cboOrderName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrderName.SelectedIndexChanged
        lblOrderName.BackColor = Color.White
    End Sub
    Private Sub cboOrderName_DropDown(sender As Object, e As EventArgs) Handles cboOrderName.DropDown
        lblOrderName.BackColor = Color.White
    End Sub

    Private Sub cboActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActivity.SelectedIndexChanged
        lblActivity.BackColor = Color.White
    End Sub
    Private Sub cboActivity_DropDown(sender As Object, e As EventArgs) Handles cboActivity.DropDown
        lblActivity.BackColor = Color.White
    End Sub

    Private Sub cboSector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSector.SelectedIndexChanged
        lblSector.BackColor = Color.White
    End Sub
    Private Sub cboSector_DropDown(sender As Object, e As EventArgs) Handles cboSector.DropDown
        lblSector.BackColor = Color.White
    End Sub


#End Region





End Class