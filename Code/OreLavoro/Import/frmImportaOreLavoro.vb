Imports Core
Imports OreLavoro.ImportData

Public Class frmImportaOreLavoro
    Private CheckInputData As Core.CheckInputData

    Private dtOreLavoro As New DataTable

    Private ListaCommesseModificate As New Dictionary(Of String, String)
    Private ListaAttivitaModificate As New Dictionary(Of String, String)
    Private ListaSettoriModificati As New Dictionary(Of String, String)

    Private dtpDateChanging As Boolean = False
    Private LastDateShown As Date = Now

    Private EmployeeCfg As New DatabaseManagement.udtEmployeeData

    Public Property EmployeeName As String = ""
    Public Property dtpDate As DateTimePicker


    Private Sub frmImportaOreLavoro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Importa ore lavoro"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        dtOreLavoro = InitDataTable()

        'LoadData()
        ShowData()

    End Sub


#Region "Private"
    Private Function InitDataTable() As DataTable
        Dim dtData As New DataTable

        dtData.Rows.Clear()
        dtData.Columns.Clear()
        dtData.Columns.Add("Giorno")
        dtData.Columns.Add("Commessa")
        dtData.Columns.Add("Attività")
        dtData.Columns.Add("Settore")
        dtData.Columns.Add("OreLavoro")
        dtData.Columns.Add("OreViaggio")

        Return dtData
    End Function

    Private Sub LoadData()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filter As New DatabaseManagement.udtFilterOreLavoro
        Filter.EmployeeName = EmployeeName
        Filter.OrderName = "%"
        Filter.Activity = "%"
        Filter.Sector = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        dtOreLavoro = xDatabase.GetWorkedHoursMonthly(Filter)

    End Sub
    Private Sub ShowData()

        'Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        'Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        'Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        If dtOreLavoro.Columns.Count = 0 Then
            dtOreLavoro = InitDataTable()
        End If

        If IsNothing(dtOreLavoro) Then
            dgvOreLavoro.DataSource = Nothing
            dgvOreLavoro.Rows.Clear()
        Else
            dgvOreLavoro.DataSource = dtOreLavoro 'bsTrace
            dgvOreLavoro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            dgvOreLavoro.RowHeadersWidth = 30
            dgvOreLavoro.RowHeadersVisible = True
            If dgvOreLavoro.ColumnCount > 1 Then
                dgvOreLavoro.Columns(0).Width = 50      'Giorno
                dgvOreLavoro.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOreLavoro.Columns(1).Width = 200     'Commessa
                dgvOreLavoro.Columns(2).Width = 120     'Attivita
                dgvOreLavoro.Columns(3).Width = 100     'Settore
                dgvOreLavoro.Columns(4).Width = 60      'OreLavoro
                dgvOreLavoro.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOreLavoro.Columns(5).Width = 60      'OreViaggio
                dgvOreLavoro.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If


            'Dim ore As udtOre = GetOre(dtOreLavoro, 4, 5)
            'lblTotaleOreLavoro.Text = TimeSpanToText(ore.Lavoro)
            'lblTotaleOreViaggio.Text = TimeSpanToText(ore.Viaggio)

            'Dim wh As TimeSpan = GetWorkingHours(BeginDate, EndDate)
            'ore.Straordinario = ore.Lavoro.Add(ore.Viaggio)
            'ore.Straordinario = ore.Straordinario.Subtract(wh)
            'lblTotaleOreStraordinario.Text = TimeSpanToText(ore.Straordinario)
        End If


    End Sub

    Private Function ChecKData(OreMensili As List(Of udtOreLavoro)) As DataTable
        Dim dtData As New DataTable
        dtData = InitDataTable()
        'dtData.Rows.Clear()
        'dtData.Columns.Clear()
        'dtData.Columns.Add("Giorno")
        'dtData.Columns.Add("Commessa")
        'dtData.Columns.Add("Attività")
        'dtData.Columns.Add("Settore")
        'dtData.Columns.Add("OreLavoro")
        'dtData.Columns.Add("OreViaggio")

        'Check data
        Dim OrderList As New List(Of String)
        OrderList = xDatabase.GetOrderList("%")
        Dim ActivityList As New List(Of String)
        ActivityList = xDatabase.GetActivityList()
        ActivityList = ActivityList.ConvertAll(Function(d) d.ToUpper())
        Dim SectorsList As New List(Of String)
        SectorsList = xDatabase.GetSectorList()
        SectorsList = SectorsList.ConvertAll(Function(d) d.ToUpper())
        For Each item As udtOreLavoro In OreMensili
            Dim OrderName As String = item.OrderName
            If Not OrderList.Contains(item.OrderName) Then
                'Commessa non trovata - cambio nome
                If Not ListaCommesseModificate.ContainsKey(item.OrderName) Then
                    Dim frm As New frmCambioNomeCommessa
                    frm.OrderName = item.OrderName
                    If frm.ShowDialog() = DialogResult.OK Then
                        OrderName = frm.OrderName
                        ListaCommesseModificate.Add(item.OrderName, OrderName)
                    End If
                    frm.Dispose()
                    frm = Nothing
                Else
                    OrderName = ListaCommesseModificate.Item(item.OrderName)
                End If
            End If
            Dim Activity As String = item.Activity
            If Not ActivityList.Contains(item.Activity) Then
                If Not ListaAttivitaModificate.ContainsKey(item.Activity) Then
                    Dim frm As New frmCambioAttivita
                    frm.Activity = item.Activity
                    If frm.ShowDialog() = DialogResult.OK Then
                        Activity = frm.Activity
                        ListaAttivitaModificate.Add(item.Activity, Activity)
                    End If
                    frm.Dispose()
                    frm = Nothing
                Else
                    Activity = ListaAttivitaModificate.Item(item.Activity)
                End If
            End If
            Dim Sector As String = item.Sector
            If Not SectorsList.Contains(item.Sector) Then
                If Not ListaSettoriModificati.ContainsKey(item.Sector) Then
                    Dim frm As New frmCambioSettore
                    frm.Sector = item.Sector
                    If frm.ShowDialog() = DialogResult.OK Then
                        Sector = frm.Sector
                        ListaSettoriModificati.Add(item.Sector, Sector)
                    End If
                    frm.Dispose()
                    frm = Nothing
                Else
                    Sector = ListaSettoriModificati.Item(item.Sector)
                End If
            End If

            Dim sWorkingHour As String = item.WorkingHours.Replace(":", ",")
            Dim sJourneyHour As String = item.JourneyHours.Replace(":", ",")

            dtData.Rows.Add(item.Data.Day, OrderName, Activity, Sector, sWorkingHour, sJourneyHour)
        Next

        Return dtData
    End Function


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


                    Case "ReadFile"
                        ReadFile()

                    Case "ReadAccess"
                        ReadAccess()

                    Case "Save"
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        Save()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default
                        Shut()



                End Select
        End Select



    End Sub

    Private Sub ReadFile()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim FileName As String = xGlobals.DataPath & "Imports\Diario" & EmployeeName.Replace(" ", "") & ".xml"

        Dim data As New ImportData(FileName)
        data.ReadDataFromFile()

        'Retreive data current month
        Dim OreMensili As New List(Of udtOreLavoro)
        OreMensili = data.OreLavoroMese(dtpDate.Value)
        dtOreLavoro = ChecKData(OreMensili)

        ShowData()

        'Update diary 
        Dim bUpdate As Boolean = False
        For Each item As udtOreLavoro In data.Diario.OreLavoro
            If ListaCommesseModificate.ContainsKey(item.OrderName) Then
                item.OrderName = ListaCommesseModificate.Item(item.OrderName)
                bUpdate = True
            End If
            If ListaAttivitaModificate.ContainsKey(item.Activity) Then
                item.Activity = ListaAttivitaModificate.Item(item.Activity)
                bUpdate = True
            End If
            If ListaSettoriModificati.ContainsKey(item.Sector) Then
                item.Sector = ListaSettoriModificati.Item(item.Sector)
                bUpdate = True
            End If
        Next

        For Each item As udtExpense In data.Diario.Spese
            If ListaCommesseModificate.ContainsKey(item.OrderName) Then
                item.OrderName = ListaCommesseModificate.Item(item.OrderName)
                bUpdate = True
            End If
        Next
        If bUpdate Then data.WriteDataToFile()

    End Sub

    Private Sub Save()
        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        For iRow As Integer = 0 To dgvOreLavoro.Rows.Count - 1
            If Not IsNothing(dgvOreLavoro.Rows(iRow).Cells("Commessa").Value) And Not IsDBNull(dgvOreLavoro.Rows(iRow).Cells("Commessa").Value) Then
                Dim rec As New DatabaseManagement.udtRecordOreLavoro
                rec.UserName = EmployeeName
                rec.OrderName = dgvOreLavoro.Rows(iRow).Cells("Commessa").Value
                rec.Activity = dgvOreLavoro.Rows(iRow).Cells("Attività").Value
                rec.Sector = dgvOreLavoro.Rows(iRow).Cells("Settore").Value
                rec.Timestamp = CDate(dtpDate.Value.Year.ToString & "/" & dtpDate.Value.Month.ToString & "/" & dgvOreLavoro.Rows(iRow).Cells("Giorno").Value)
                rec.WorkHours = TextToSingle(dgvOreLavoro.Rows(iRow).Cells("OreLavoro").Value.ToString.Replace(":", "."))
                rec.TravelHours = TextToSingle(dgvOreLavoro.Rows(iRow).Cells("OreViaggio").Value.ToString.Replace(":", "."))

                If xDatabase.RecordOreLavoroExists(rec) Then
                    xDatabase.UpdateOreLavoro(rec)
                Else
                    'Add new record
                    xDatabase.AddOreLavoro(rec)
                End If
            End If

        Next


    End Sub


    Private Sub ReadAccess()

        Dim openFile As New OpenFileDialog()
        openFile.FileName = ""
        openFile.InitialDirectory =xGlobals.DataPath & "Imports"
        openFile.Filter = "Microsoft Access Application (*.mdb)|*.mdb"

        Dim res As System.Windows.Forms.DialogResult = openFile.ShowDialog()
        If res = System.Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim data As New ImportData()
        Dim OreMensili As New List(Of udtOreLavoro)
        OreMensili = Data.OreLavoroDaAccess(dtpDate.Value, openFile.FileName)
        Dim dtData As DataTable = ChecKData(OreMensili)

        mnu.SuspendMenu()
        Using frm As New frmVisualizzaOreLavoroImportate
            frm.dtImport = dtData
            frm.dtOreLavoro = dtOreLavoro
            frm.dgvPadre = Me.dgvOreLavoro
            frm.ShowDialog()
        End Using
        mnu.ActivateMenuSuspended()


    End Sub


    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub


#End Region


#Region "Check data input"

    Private Sub SelectOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        sender.backcolor = Color.White
    End Sub
    Private Sub OnlyTimeOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyInteger(sender, e.KeyChar, "+")
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        Return True

    End Function


#End Region

End Class