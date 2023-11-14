Imports Core

Public Class frmAnalisiRefound
    Private Const cComboSeparator = "----------"

    Private OrderFilter As String = "%"

    Private WithEvents TabsData As New TabControl

    Private FilterRefound As New DatabaseManagement.udtFilterRefound

    Private IsLoading As Boolean = False
    Private EmployeeRefoundActive As Boolean = False
    Private OrdersActive As Boolean = False

    Private Class udtFilter
        Public Property EmployeeName As String = "%"
        Public Property OrderName As String = "%"
    End Class
    Private Filter As New udtFilter

    Private dtRefound As New DataTable

    Private Sub frmAnalisiSpese_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        IsLoading = False
    End Sub

    Private Sub frmAnalisiSpese_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Analisi spese"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        IsLoading = True

        Call ShowMenu()
        mnu.EnableButton("ExportToExcel", False)
        mnu.EnableButton("Print", False)

        Filter = New udtFilter
        Filter.EmployeeName = xUsers.UserLogged.Name

        LoadEmpolyeeComboBox()
        LoadOrdersComboBox("%")
        LoadDateTimePicker()

        TabsData = New TabControl
        TabsData.Location = New Point(3, 3)
        TabsData.Size = New Size(panData.Width - 5, panData.Height - 10)
        TabsData.Multiline = False
        panData.Controls.Add(TabsData)

        lblSpeseTotale.Text = "0.0"

    End Sub

    Private Sub LoadEmpolyeeComboBox()
        cboEmployee.Items.Clear()
        Dim EmpolyeeList As List(Of String) = xDatabase.GetEmpolyeeList()
        For Each str As String In EmpolyeeList
            cboEmployee.Items.Add(str)
        Next
        cboEmployee.Text = xUsers.UserLogged.Name

    End Sub

    Private Sub LoadOrdersComboBox(Filter As String)
        cboOrderName.Items.Clear()
        cboOrderName.Items.Add("%")
        cboOrderName.Items.Add(cComboSeparator)
        Dim orders As New List(Of String)
        orders = xDatabase.GetOrderList(Filter)
        For Each str As String In orders
            cboOrderName.Items.Add(str)
        Next
        If Filter <> "%" Then
            If orders.Count > 0 Then
                cboOrderName.Text = orders(0)
            End If
        Else
            cboOrderName.Text = "%"
        End If
    End Sub

    Private Sub LoadDateTimePicker()
        Dim d As Date = Date.Now
        Dim DaysInMonth As Integer = Date.DaysInMonth(d.Year, d.Month)
        Dim EndDate As Date = New Date(d.Year, d.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(d.Year, d.Month, 1)

        dtpFrom.Value = BeginDate
        dtpTo.Value = EndDate

    End Sub

#Region "Tabs"
    Private Sub RemoveTabs()
        Dim ucViewRefoundDataList As New List(Of ucViewRefoundData)
        For Each tab As TabPage In TabsData.TabPages
            For Each ctrl As Control In tab.Controls
                If TypeOf (ctrl) Is ucViewRefoundData Then
                    ucViewRefoundDataList.Add(ctrl)
                End If
            Next
        Next
        For Each item As ucViewRefoundData In ucViewRefoundDataList
            item.Dispose()
            item = Nothing
        Next
        TabsData.TabPages.Clear()
    End Sub

    Private Sub AddOrderTab(Filter As DatabaseManagement.udtFilterRefound)

        Dim tab As New TabPage
        tab.Text = Filter.OrderName
        tab.BorderStyle = BorderStyle.Fixed3D
        tab.Name = Filter.OrderName
        tab.Tag = Filter.OrderName
        Dim ucViewRefoundData As New ucViewRefoundData
        ucViewRefoundData.Name = "ucViewRefoundData" & Filter.OrderName
        tab.Controls.Add(ucViewRefoundData)
        TabsData.TabPages.Add(tab)

        Dim dt As New DataTable
        dt = xDatabase.GetUserAnalysisRefound(Filter)
        ucViewRefoundData.LoadData(dt)
    End Sub

    Private Sub AddEmpolyeeTab(Filter As DatabaseManagement.udtFilterRefound)

        Dim tab As New TabPage
        tab.Text = Filter.EmployeeName
        tab.BorderStyle = BorderStyle.Fixed3D
        tab.Name = Filter.EmployeeName
        tab.Tag = Filter.EmployeeName
        Dim ucViewRefoundData As New ucViewRefoundData
        ucViewRefoundData.Name = "ucViewRefoundData" & Filter.EmployeeName
        tab.Controls.Add(ucViewRefoundData)
        TabsData.TabPages.Add(tab)

        Dim dt As New DataTable
        dt = xDatabase.GetUserAnalysisRefound(Filter)
        ucViewRefoundData.LoadData(dt)
    End Sub

    Private Sub AddAllOrdersTab(Filter As DatabaseManagement.udtFilterRefound)

        Dim tab As New TabPage
        tab.Text = Filter.EmployeeName
        tab.BorderStyle = BorderStyle.Fixed3D
        tab.Name = Filter.EmployeeName
        tab.Tag = Filter.EmployeeName
        Dim ucViewAllOrdersRefound As New ucViewAllOrdersRefound
        ucViewAllOrdersRefound.Name = "ucViewAllOrdersRefound" & Filter.EmployeeName
        AddHandler ucViewAllOrdersRefound.ItemSelected, AddressOf ucViewAllOrdersRefound_ItemSelected
        AddHandler ucViewAllOrdersRefound.DoubleClickOnItem, AddressOf ucViewAllOrdersRefound_DoubleClickOnItem
        tab.Controls.Add(ucViewAllOrdersRefound)
        TabsData.TabPages.Add(tab)

        ucViewAllOrdersRefound.LoadData(Filter)


    End Sub
#End Region

    Private Sub LoadDataRefoundByEmployee()

        lblSpeseTotale.Text = "0.0"

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        Dim FilterOre As New DatabaseManagement.udtFilterOreLavoro
        FilterOre.EmployeeName = cboEmployee.Text
        FilterOre.OrderName = cboOrderName.Text & "%"
        FilterOre.Activity = "%"
        FilterOre.Sector = "%"
        FilterOre.BeginDate = BeginDate
        FilterOre.EndDate = EndDate

        Dim Filter As New DatabaseManagement.udtFilterRefound
        Filter.EmployeeName = cboEmployee.Text
        Filter.OrderName = cboOrderName.Text & "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate

        RemoveTabs()

        If cboEmployee.Text <> "%" Then
            Dim Orders As List(Of String) = xDatabase.GetOrdersDoneByUserWithRefound(Filter)
            For Each ord As String In Orders
                Filter.OrderName = ord
                AddOrderTab(Filter)
            Next
        Else
            Dim Names As List(Of String) = xDatabase.GetUsersListWhoMakeOrder(FilterOre)
            For Each str As String In Names
                Filter.EmployeeName = str
                AddEmpolyeeTab(Filter)
            Next
        End If

        If TabsData.TabPages.Count > 0 Then
            lblCommessa.Text = TabsData.TabPages(0).Text
            ShowTotalsOrder(lblCommessa.Text)
            OrdersActive = False
            EmployeeRefoundActive = True
            mnu.EnableButton("ExportToExcel", True)
        Else
            OrdersActive = False
            EmployeeRefoundActive = False
            mnu.EnableButton("ExportToExcel", False)
        End If

    End Sub

    Private Sub LoadDataCommesse()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        Dim FilterOreLavoro As New DatabaseManagement.udtFilterOreLavoro
        FilterOreLavoro.EmployeeName = "%"
        FilterOreLavoro.OrderName = cboOrderName.Text & "%"
        FilterOreLavoro.Activity = "%"
        FilterOreLavoro.Sector = "%"
        FilterOreLavoro.BeginDate = BeginDate
        FilterOreLavoro.EndDate = EndDate

        cboEmployee.Text = "%"

        FilterRefound.EmployeeName = "%"
        FilterRefound.OrderName = cboOrderName.Text & "%"
        FilterRefound.BeginDate = BeginDate
        FilterRefound.EndDate = EndDate

        RemoveTabs()

        Dim Names As List(Of String) = xDatabase.GetUsersListWhoMakeOrderWithRefound(FilterRefound)
        For Each name As String In Names
            FilterRefound.EmployeeName = name
            AddAllOrdersTab(FilterRefound)
        Next

        If TabsData.TabPages.Count > 0 Then
            lblCommessa.Text = TabsData.TabPages(0).Text
            ShowTotalsOrder(lblCommessa.Text)
            OrdersActive = True
            EmployeeRefoundActive = False
            mnu.EnableButton("ExportToExcel", True)
        Else
            OrdersActive = False
            EmployeeRefoundActive = False
            mnu.EnableButton("ExportToExcel", False)
        End If

        'AddAllOrdersTab(Filter)

    End Sub

    Private Sub plsFilter_Click(sender As Object, e As EventArgs) Handles plsFilter.Click
        mnu.SuspendMenu()
        Using dlg As New frmFilter
            If dlg.ShowDialog() = DialogResult.OK Then
                Filter.OrderName = dlg.Filter & "%"
                LoadOrdersComboBox(Filter.OrderName)
            End If
        End Using

        mnu.ActivateMenuSuspended()
    End Sub

    Private Sub TabsData_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabsData.SelectedIndexChanged
        If Not IsNothing(TabsData.SelectedTab) Then
            lblCommessa.Text = TabsData.SelectedTab.Text
            ShowTotalsOrder(lblCommessa.Text)
        End If
    End Sub

    Private Sub ShowTotalsOrder(OrderName As String)

        For Each tab As TabPage In TabsData.TabPages
            For Each ctrl As Control In tab.Controls
                If TypeOf (ctrl) Is ucViewRefoundData Then
                    Dim _uc As ucViewRefoundData
                    _uc = DirectCast(ctrl, ucViewRefoundData)
                    If tab.Name = OrderName Then
                        lblCommessa.Text = tab.Name
                        lblSpeseTotale.Text = _uc.SpesaTotale.ToString
                    End If
                End If

                If TypeOf (ctrl) Is ucViewAllOrdersRefound Then
                    Dim _uc As ucViewAllOrdersRefound
                    _uc = DirectCast(ctrl, ucViewAllOrdersRefound)
                    If tab.Name = OrderName Then
                        lblCommessa.Text = tab.Name
                        lblSpeseTotale.Text = _uc.SpesaTotale.ToString
                    End If
                End If

            Next
        Next
    End Sub

#Region "Events"
    Private Sub ucViewAllOrdersRefound_ItemSelected(sender As ucViewAllOrdersRefound, EmployeeName As String, OrderName As String)

        'Dim ucView As New ucViewOreLavoroData
        'ucView.Name = "ucView"

        'Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        'Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        'Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        'Dim Filter As New DatabaseManagement.udtFilterOreLavoro
        'Filter.EmployeeName = EmployeeName
        'Filter.OrderName = OrderName
        'Filter.Activity = Activity
        'Filter.Sector = Sector
        'Filter.BeginDate = BeginDate
        'Filter.EndDate = EndDate

        'Dim dt As New DataTable
        'dt = xDatabase.GetWorkedHours(Filter)
        'ucView.LoadData(dt)

        'lblOreLavoroCommessa.Text = TimeSpanToText(ucView.OreLavoro)
        'lblOreViaggioCommessa.Text = TimeSpanToText(ucView.OreViaggio)
        'lblOreLavoroTotale.Text = TimeSpanToText(ucView.OreLavoro)
        'lblOreViaggioTotale.Text = TimeSpanToText(ucView.OreViaggio)

        ''cboEmployee.Text = EmployeeName
        ''cboOrderName.Text = OrderName
        ''cboActivity.Text = Activity
        ''cboSector.Text = Sector

    End Sub

    Private Sub ucViewAllOrdersRefound_DoubleClickOnItem(sender As ucViewAllOrdersRefound, EmployeeName As String, OrderName As String)


        Using frm As New frmAnalisiOreLavoroDettaglioCommessa
            frm.Filter = New DatabaseManagement.udtFilterOreLavoro
            frm.Filter.EmployeeName = EmployeeName
            frm.Filter.OrderName = OrderName
            frm.Filter.Activity = "%"
            frm.Filter.Sector = "%"
            frm.Filter.BeginDate = FilterRefound.BeginDate
            frm.Filter.EndDate = FilterRefound.EndDate
            frm.ShowDialog()
        End Using



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

                    Case "AnalisiOreLavoro"
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        LoadDataRefoundByEmployee()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default
                        mnu.EnableButton("Print", EmployeeRefoundActive)
                        mnu.EnableButton("ExportToExcel", EmployeeRefoundActive)

                    Case "OrdersAnalysis"
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        LoadDataCommesse()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default
                        mnu.EnableButton("Print", OrdersActive)
                        mnu.EnableButton("ExportToExcel", OrdersActive)

                    Case "Print"
                        If OrdersActive Or EmployeeRefoundActive Then
                            mnu.SuspendMenu()
                            Me.Cursor = Cursors.WaitCursor
                            PrintRefoundAnalysisToPdf()
                            mnu.ActivateMenuSuspended()
                            Me.Cursor = Cursors.Default
                        End If

                    Case "ExportToExcel"
                        If OrdersActive Or EmployeeRefoundActive Then
                            mnu.SuspendMenu()
                            Me.Cursor = Cursors.WaitCursor
                            ExportCommesseToExcel()
                            mnu.ActivateMenuSuspended()
                            Me.Cursor = Cursors.Default
                        End If

                End Select
        End Select



    End Sub

    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub

#End Region

#Region "Export to Excel"

    Private Sub ExportCommesseToExcel()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)


        Using frm As New frmAnalisiRefoundExport
            frm.IsEmployeeExport = EmployeeRefoundActive
            frm.Filter = New DatabaseManagement.udtFilterRefound
            frm.Filter.EmployeeName = cboEmployee.Text
            frm.Filter.OrderName = cboOrderName.Text & "%"
            frm.Filter.BeginDate = BeginDate
            frm.Filter.EndDate = EndDate

            frm.ShowDialog()
        End Using




    End Sub



#End Region

#Region "Print To PDF"

    Private Sub PrintRefoundAnalysisToPdf()
        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        Dim Filename As String = ""

        Dim Filter As New DatabaseManagement.udtFilterRefound



        Filter.OrderName = cboOrderName.Text & "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate

        If EmployeeRefoundActive Then
            Filter.EmployeeName = cboEmployee.Text
            Filename = "C:\OreLavoro\AnalisiSpese-" & Filter.EmployeeName & ".pdf"
        End If

        If OrdersActive Then
            Filter.EmployeeName = "%"
            Filename = "C:\OreLavoro\AnalisiSpese-" & Filter.OrderName.Replace("%", "") & ".pdf"
        End If

        Dim pdf As New PrintToPDF
        pdf.PrintRefoundAnalysis(Filename, Filter, EmployeeRefoundActive)
        Dim pdfShow As New frmShowPdf
        pdfShow.FileToShow = Filename
        pdfShow.Size = New Size(1024, 768)
        pdfShow.ShowDialog()
        pdfShow.Dispose()
        pdfShow = Nothing

    End Sub
#End Region

End Class