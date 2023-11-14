Imports Core
Imports OreLavoro.ImportData

Public Class frmImportaSpese

    Private CheckInputData As Core.CheckInputData

    Private dtSpese As New DataTable

    Private ListaCommesseModificate As New Dictionary(Of String, String)

    Private EmployeeCfg As New DatabaseManagement.udtEmployeeData


    Public Property EmployeeName As String = ""
    Public Property dtpDate As DateTimePicker


    Private Sub frmImportaSpese_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Importa spese e rimborsi"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        dtSpese = InitDataTable()

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
        dtData.Columns.Add("Località")
        dtData.Columns.Add("Km")
        dtData.Columns.Add("Autostrada")
        dtData.Columns.Add("Mezzi")
        dtData.Columns.Add("Vitto")
        dtData.Columns.Add("Alloggio")
        dtData.Columns.Add("Varie")
        dtData.Columns.Add("Carta")
        dtData.Columns.Add("Valuta")
        dtData.Columns.Add("R")
        dtData.Columns.Add("M")
        dtData.Columns.Add("Diaria")

        Return dtData
    End Function

    Private Sub LoadData()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filter As New DatabaseManagement.udtFilterRefound
        Filter.EmployeeName = EmployeeName
        Filter.OrderName = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        dtSpese = xDatabase.GetUserRefound(Filter)
        

    End Sub

    Private Sub ShowData()

        If dtSpese.Columns.Count = 0 Then
            dtSpese = InitDataTable()
        End If

        If IsNothing(dtSpese) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        Else
            dgv.DataSource = dtSpese
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
            End If
        End If

    End Sub

    Private Function ChecKData(SpeseMensili As List(Of udtExpense)) As DataTable
        Dim dtData As New DataTable

        dtData = InitDataTable()

        'dtData.Rows.Clear()
        'dtData.Columns.Clear()
        'dtData.Columns.Add("Giorno")
        'dtData.Columns.Add("Commessa")
        'dtData.Columns.Add("Località")
        'dtData.Columns.Add("Km")
        'dtData.Columns.Add("Autostrada")
        'dtData.Columns.Add("Mezzi")
        'dtData.Columns.Add("Vitto")
        'dtData.Columns.Add("Alloggio")
        'dtData.Columns.Add("Varie")
        'dtData.Columns.Add("Carta")
        'dtData.Columns.Add("Valuta")
        'dtData.Columns.Add("R")
        'dtData.Columns.Add("M")
        'dtData.Columns.Add("Diaria")


        'Check data
        Dim OrderList As New List(Of String)
        OrderList = xDatabase.GetOrderList("%")
        For Each item As udtExpense In SpeseMensili
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

            dtData.Rows.Add(item.Data.Day, OrderName, item.City, item.Km, item.Autostrada, item.MezziPubblici, item.Vitto, item.Alloggio,
                            item.Varie, item.CCA, item.Valuta, item.TipoRimborso, item.Motivo, item.Diaria)
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
        Dim SpeseMensili As New List(Of udtExpense)
        SpeseMensili = data.SpeseMese(dtpDate.Value)
        dtSpese = ChecKData(SpeseMensili)

        ShowData()

        'Update diary 
        Dim bUpdate As Boolean = False
        For Each item As udtOreLavoro In data.Diario.OreLavoro
            If ListaCommesseModificate.ContainsKey(item.OrderName) Then
                item.OrderName = ListaCommesseModificate.Item(item.OrderName)
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

        For iRow As Integer = 0 To dgv.Rows.Count - 1
            If Not IsNothing(dgv.Rows(iRow).Cells("Commessa").Value) And Not IsDBNull(dgv.Rows(iRow).Cells("Commessa").Value) Then

                Dim rec As New DatabaseManagement.udtRecordRefound
                rec.UserName = EmployeeName
                rec.City = dgv.Rows(iRow).Cells("Località").Value
                rec.OrderName = dgv.Rows(iRow).Cells("Commessa").Value
                rec.Timestamp = CDate(dtpDate.Value.Year.ToString & "/" & dtpDate.Value.Month.ToString & "/" & dgv.Rows(iRow).Cells("Giorno").Value)
                rec.Alloggio = TextToSingle(dgv.Rows(iRow).Cells("Alloggio").Value)
                rec.Autostrada = TextToSingle(dgv.Rows(iRow).Cells("Autostrada").Value)
                rec.CartaCredito = TextToSingle(dgv.Rows(iRow).Cells("Carta").Value)
                rec.Diaria = TextToSingle(dgv.Rows(iRow).Cells("Diaria").Value)
                rec.Km = dgv.Rows(iRow).Cells("Km").Value
                rec.MezziPubblici = TextToSingle(dgv.Rows(iRow).Cells("Mezzi").Value)
                rec.Valuta = TextToSingle(dgv.Rows(iRow).Cells("Valuta").Value)
                rec.Varie = TextToSingle(dgv.Rows(iRow).Cells("Varie").Value)
                rec.Vitto = TextToSingle(dgv.Rows(iRow).Cells("Vitto").Value)
                rec.TipoRimborso = dgv.Rows(iRow).Cells("R").Value
                rec.Motivo = dgv.Rows(iRow).Cells("M").Value

                If xDatabase.RecordRefoundExists(rec) Then
                    xDatabase.UpdateRefound(rec)
                Else
                    'Add new record
                    xDatabase.AddRefound(rec)
                End If
            End If

        Next

    End Sub


    Private Sub ReadAccess()

        Dim openFile As New OpenFileDialog()
        openFile.FileName = ""
        openFile.InitialDirectory = xGlobals.DataPath & "Imports"
        openFile.Filter = "Microsoft Access Application (*.mdb)|*.mdb"

        Dim res As System.Windows.Forms.DialogResult = openFile.ShowDialog()
        If res = System.Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        Dim data As New ImportData()
        Dim SpeseMensili As New List(Of udtExpense)
        SpeseMensili = data.SpeseDaAccess(dtpDate.Value, openFile.FileName)
        Dim dtToImport As DataTable = ChecKData(SpeseMensili)

        mnu.SuspendMenu()
        Using frm As New frmVisualizzaSpeseImportate
            frm.dtImport = dtToImport
            frm.dtSpese = dtSpese
            frm.dgvPadre = Me.dgv
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