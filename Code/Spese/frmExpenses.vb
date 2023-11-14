Imports Core

Public Class frmExpenses

    Private CheckInputData As Core.CheckInputData

    Private dtpDateChanging As Boolean = False
    Private LastDateShown As Date = Now

    Private IsLoading As Boolean = False

    Private CostoKm As Single = 0

    Private Sub frmExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Spese e rimborsi"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        IsLoading = True
        LoadEmpolyeeComboBox()
        LoadOrdersComboBox("%")
        LoadDateTimePicker()

        CostoKm = xDatabase.RimborsoKm(cboEmployeeName.Text)

        LoadData()

        IsLoading = False

    End Sub


#Region "Private"
    Private Sub LoadEmpolyeeComboBox()
        cboEmployeeName.Items.Clear()
        Dim EmpolyeeList As List(Of String) = xDatabase.GetEmpolyeeList()
        For Each str As String In EmpolyeeList
            cboEmployeeName.Items.Add(str)
        Next
        cboEmployeeName.Text = xUsers.UserLogged.Name
    End Sub
    Private Sub LoadOrdersComboBox(Filter As String)
        LoadOrdersComboBox(Filter, False)
    End Sub
    Private Sub LoadOrdersComboBox(Filter As String, ShowValue As Boolean)
        cboOrderName.Items.Clear()
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

    Private Sub LoadDateTimePicker()
        Dim d As Date = Date.Now
        Dim DaysInMonth As Integer = Date.DaysInMonth(d.Year, d.Month)
        Dim EndDate As Date = New Date(d.Year, d.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(d.Year, d.Month, 1)

        dtpDate.Value = BeginDate


    End Sub

    Private Sub LoadData()

        Dim dtData As New DataTable

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filter As New DatabaseManagement.udtFilterRefound
        Filter.EmployeeName = cboEmployeeName.Text    'xUsers.UserLogged.Name
        Filter.OrderName = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        dtData = xDatabase.GetUserRefound(Filter)

        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            txtKm.Text = "0"
            txtAutostrada.Text = "0"
            txtMezziPubblici.Text = "0"
            txtVitto.Text = "0"
            txtAlloggio.Text = "0"
            txtVarie.Text = "0"
            txtDiaria.Text = "0"
            txtCartaCredito.Text = "0"
            txtValuta.Text = "0"
            optNormale.Checked = True
            optForfait.Checked = True
            chkItaly.Checked = True
            chkEstero.Checked = False
        Else
            dgv.DataSource = dtData 'bsTrace
            dgv.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            'dgv.RowHeadersWidth = 10
            dgv.RowHeadersVisible = False
            If dgv.ColumnCount > 12 Then
                dgv.Columns(0).Width = 40       'Giorno
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(1).Width = 180      'Commessa
                dgv.Columns(2).Width = 120      'Localita
                dgv.Columns(3).Width = 40       'KM
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(4).Width = 60       'autostrada
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(5).Width = 50       'Mezzi
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(6).Width = 40       'Vitto
                dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(7).Width = 50       'Alloggio
                dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(8).Width = 50       'Varie
                dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(9).Width = 50       'Carta
                dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(10).Width = 40       'Valuta
                dgv.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(11).Width = 30       'Rimborso
                dgv.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(12).Width = 30       'Motivo
                dgv.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(13).Width = 40       'Diaria
                'dgv.Columns(13).Visible = False
                dgv.Columns(13).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            Else
                txtKm.Text = "0"
                txtAutostrada.Text = "0"
                txtMezziPubblici.Text = "0"
                txtVitto.Text = "0"
                txtAlloggio.Text = "0"
                txtVarie.Text = "0"
                txtDiaria.Text = "0"
                txtCartaCredito.Text = "0"
                txtValuta.Text = "0"
                chkItaly.Checked = True
                chkEstero.Checked = False
                optNormale.Checked = True
                optForfait.Checked = True
            End If
        End If

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
        If DateDiff(DateInterval.Month, LastDateShown, dtpDate.Value) <> 0 Then
            LastDateShown = dtpDate.Value
            LoadData()
        End If

        dtpDateChanging = True
        For Each r As DataGridViewRow In dgv.Rows
            If r.Cells("Giorno").Value = dtpDate.Value.Day Then
                r.Selected = True
            Else
                r.Selected = False
            End If
        Next
        dtpDateChanging = False
    End Sub

    Private Sub dgv_SelectionChanged(sender As Object, e As EventArgs) Handles dgv.SelectionChanged

        If dtpDateChanging Then Return

        If dgv.SelectedRows.Count > 0 Then
            dtpDate.Value = CDate(dtpDate.Value.Year.ToString + "-" + dtpDate.Value.Month.ToString + "-" + dgv.SelectedRows(0).Cells("Giorno").Value.ToString)
            cboOrderName.Text = dgv.SelectedRows(0).Cells("Commessa").Value
            txtCity.Text = dgv.SelectedRows(0).Cells("Località").Value
            txtKm.Text = dgv.SelectedRows(0).Cells("Km").Value
            txtAutostrada.Text = dgv.SelectedRows(0).Cells("Autostrada").Value
            txtMezziPubblici.Text = dgv.SelectedRows(0).Cells("Mezzi").Value
            txtVitto.Text = dgv.SelectedRows(0).Cells("Vitto").Value
            txtAlloggio.Text = dgv.SelectedRows(0).Cells("Alloggio").Value
            txtVarie.Text = dgv.SelectedRows(0).Cells("Varie").Value
            txtDiaria.Text = dgv.SelectedRows(0).Cells("Diaria").Value

            txtCartaCredito.Text = dgv.SelectedRows(0).Cells("Carta").Value
            txtValuta.Text = dgv.SelectedRows(0).Cells("Valuta").Value

            If dgv.SelectedRows(0).Cells("Diaria").Value = xConfig.OreLavoro.DiariaItalia Then
                chkItaly.Checked = True
                chkEstero.Checked = False
            ElseIf dgv.SelectedRows(0).Cells("Diaria").Value = xConfig.OreLavoro.DiariaEstero Then
                chkItaly.Checked = False
                chkEstero.Checked = True
            Else
                chkItaly.Checked = False
                chkEstero.Checked = False
            End If

            If dgv.SelectedRows(0).Cells("R").Value = "F" Then
                optForfait.Checked = True
            Else
                optPieDiLista.Checked = True
            End If
            If dgv.SelectedRows(0).Cells("M").Value = "R" Then
                optNormale.Checked = True
            Else
                optStraordinario.Checked = True
            End If

        End If

    End Sub

    Private Sub chkItaly_CheckedChanged(sender As Object, e As EventArgs) Handles chkItaly.CheckedChanged
        If IsLoading Then Return
        If chkItaly.Checked Then
            txtDiaria.Text = xConfig.OreLavoro.DiariaItalia.ToString
            chkEstero.Checked = False
        Else
            If Not chkEstero.Checked Then
                txtDiaria.Text = "0"
            End If
        End If
    End Sub

    Private Sub chkEstero_CheckedChanged(sender As Object, e As EventArgs) Handles chkEstero.CheckedChanged
        If IsLoading Then Return
        If chkEstero.Checked Then
            txtDiaria.Text = xConfig.OreLavoro.DiariaEstero.ToString
            chkItaly.Checked = False
        Else
            If Not chkItaly.Checked Then
                txtDiaria.Text = "0"
            End If
        End If
    End Sub


#End Region



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
                        Dim frm As New frmImportaSpese
                        frm.EmployeeName = cboEmployeeName.Text
                        frm.dtpDate = dtpDate
                        frm.ShowDialog(Me)
                        frm.Dispose()
                        frm = Nothing
                        LoadData()
                        mnu.ActivateMenuSuspended()

                    Case "Analisys"
                        mnu.SuspendMenu()
                        Dim frm As New frmAnalisiRefound
                        frm.ShowDialog(Me)
                        frm.Dispose()
                        frm = Nothing
                        mnu.ActivateMenuSuspended()


                End Select
        End Select



    End Sub

    Private Sub Write()
        If Not CheckData() Then
            MsgBox(CheckInputData.NokResult.ToString, MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            Exit Sub
        End If

        Dim rec As New DatabaseManagement.udtRecordRefound
        rec.UserName = cboEmployeeName.Text     'xUsers.UserLogged.Name
        rec.City = txtCity.Text
        rec.OrderName = cboOrderName.Text
        rec.Timestamp = Format(dtpDate.Value, "yyyy/MM/dd")
        rec.Alloggio = txtAlloggio.Text
        rec.Autostrada = txtAutostrada.Text
        rec.CartaCredito = txtCartaCredito.Text
        rec.Diaria = txtDiaria.Text
        rec.Km = txtKm.Text
        rec.MezziPubblici = txtMezziPubblici.Text
        rec.Valuta = txtValuta.Text
        rec.Varie = txtVarie.Text
        rec.Vitto = txtVitto.Text
        If optPieDiLista.Checked Then
            rec.TipoRimborso = "P"
        Else
            rec.TipoRimborso = "F"
        End If
        If optNormale.Checked Then
            rec.Motivo = "R"
        Else
            rec.Motivo = "S"
        End If
        If xDatabase.RecordRefoundExists(rec) Then
            If MsgBox("Dati esistenti. Vuoi sovrascriverli?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim RowSelected As Integer = dgv.SelectedRows(0).Index
                xDatabase.UpdateRefound(rec)
                LoadData()
                dgv.ClearSelection()
                dgv.Rows(RowSelected).Selected = True
            Else

            End If
        Else
            'Add new record
            Dim day As Integer = dtpDate.Value.Day
            xDatabase.AddRefound(rec)
            LoadData()
            dgv.ClearSelection()
            For Each r As DataGridViewRow In dgv.Rows
                If r.Cells("Giorno").Value = day Then
                    r.Selected = True
                Else
                    r.Selected = False
                End If
            Next
        End If

    End Sub

    Private Sub Delete()
        Dim rec As New DatabaseManagement.udtRecordRefound
        rec.UserName = cboEmployeeName.Text     'xUsers.UserLogged.Name
        rec.OrderName = cboOrderName.Text
        rec.City = txtCity.Text
        rec.Timestamp = dtpDate.Value

        If xDatabase.RecordRefoundExists(rec) Then
            If MsgBox("Cancello riga selezionata. Sei DAVVERO sicuro?", MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                Dim RowSelected As Integer = dgv.SelectedRows(0).Index
                xDatabase.DeleteRefound(rec)
                LoadData()
            End If
        End If
    End Sub

    Private Sub Print()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filename As String = ""

        Dim Filter As New DatabaseManagement.udtFilterRefound
        Filter.EmployeeName = cboEmployeeName.Text       ' xUsers.UserLogged.Name
        Filter.OrderName = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        'dtData = xDatabase.GetUserRefound(Filter)

        Dim Month As String = Filter.BeginDate.ToString("MMMM")
        Dim Year As String = Filter.BeginDate.ToString("yyyy")

        Filename = "C:\OreLavoro\NotaSpese-" & Filter.EmployeeName & "-" & Month & "-" & Year & ".pdf"

        Dim pdf As New PrintToPDF
        pdf.PrintRefound(Filename, Filter)
        Dim pdfShow As New frmShowPdf
        pdfShow.FileToShow = Filename
        pdfShow.Size = New Size(1024, 768)
        pdfShow.ShowDialog()
        pdfShow.Dispose()
        pdfShow = Nothing

    End Sub

    Private Sub Import()

    End Sub


    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub


#End Region


#Region "Check data input"

    Private Sub SelectOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
            txtCity.KeyPress

        sender.backcolor = Color.White
    End Sub
    Private Sub OnlyTimeOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtKm.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyInteger(sender, e.KeyChar, "+")
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtAutostrada.KeyPress, txtMezziPubblici.KeyPress, txtVitto.KeyPress, txtAlloggio.KeyPress, txtVarie.KeyPress, txtDiaria.KeyPress,
            txtCartaCredito.KeyPress, txtValuta.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        If Not CheckInputData.IsValueExisting(txtCity) Then Return False

        If Not CheckInputData.IsValueNumericOk(txtKm, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtAutostrada, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtMezziPubblici, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtVitto, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtAlloggio, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtVarie, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtDiaria, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtCartaCredito, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtValuta, 0, 999999) Then Return False

        If cboOrderName.Text = "" Then
            CheckInputData.NokResult = CheckInputData.enumNokResult.CommessaNonValida
            cboOrderName.Focus()
            'cboOrderName.BackColor = Color.Coral
            Return False
        End If

        Return True

    End Function

    Private Sub cboOrderName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboOrderName.SelectedIndexChanged
        cboOrderName.BackColor = Color.White
    End Sub


    Private Sub cboOrderName_DropDown(sender As Object, e As EventArgs) Handles cboOrderName.DropDown
        cboOrderName.BackColor = Color.White
    End Sub

#End Region

End Class