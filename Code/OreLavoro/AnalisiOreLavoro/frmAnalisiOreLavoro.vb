Imports Core

Public Class frmAnalisiOreLavoro

    Private Const cComboSeparator = "----------"

    Private OrderFilter As String = "%"

    Private WithEvents TabsData As New TabControl

    Private FilterOreLavoro As New DatabaseManagement.udtFilterOreLavoro

    Private IsLoading As Boolean = False
    Private OreLavoroActive As Boolean = False
    Private OrdersActive As Boolean = False

    Private Class udtFilter
        Public Property EmployeeName As String = "%"
        Public Property OrderName As String = "%"
        Public Property Activity As String = "%"
        Public Property Sector As String = "%"
        Public Property FromDate As Date = Date.Now
        Public Property ToDate As Date = Date.Now
    End Class
    Private Filter As New udtFilter

    Private dtOreLavoro As New DataTable


    Private Sub frmAnalisiOreLavoro_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        IsLoading = False
    End Sub

    Private Sub frmAnalisiOreLavoro_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Analisi ore lavoro"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        IsLoading = True

        Call ShowMenu()
        mnu.EnableButton("ExportToExcel", False)
        mnu.EnableButton("Print", False)

        Filter = New udtFilter
        Filter.EmployeeName = xUsers.UserLogged.Name

        LoadEmpolyeeComboBox()
        LoadOrdersComboBox("%")
        LoadActivityComboBox()
        LoadSectorComboBox()
        LoadDateTimePicker()

        TabsData = New TabControl
        TabsData.Location = New Point(3, 3)
        TabsData.Size = New Size(panData.Width - 5, panData.Height - 10)
        TabsData.Multiline = False
        panData.Controls.Add(TabsData)

        lblOreLavoroTotale.Text = "0.0"
        lblOreViaggioTotale.Text = "0.0"
        lblOreLavoroCommessa.Text = "0.0"
        lblOreViaggioCommessa.Text = "0.0"

    End Sub


    Private Sub LoadEmpolyeeComboBox()
        cboEmployee.Items.Clear()
        Dim EmpolyeeList As List(Of String) = xDatabase.GetEmpolyeeList()
        For Each str As String In EmpolyeeList
            cboEmployee.Items.Add(str)
        Next
        cboEmployee.Text = xUsers.UserLogged.Name
        ''Load orders
        'cboEmployee.Items.Clear()
        'cboEmployee.Items.Add("%")
        'cboEmployee.Items.Add(cComboSeparator)
        'Dim strs As New List(Of String)
        'For Each usr As Users.udtUser In xUsers.Users
        '    strs.Add(usr.Name)
        'Next
        'strs.Sort()
        'For Each str As String In strs
        '    cboEmployee.Items.Add(str)
        'Next
        'cboEmployee.Text = xUsers.UserLogged.Name
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
    Private Sub LoadActivityComboBox()
        'Load orders
        cboActivity.Items.Clear()
        cboActivity.Items.Add("%")
        cboActivity.Items.Add(cComboSeparator)
        Dim activity As New List(Of String)
        activity = xDatabase.GetActivityList()
        For Each str As String In activity
            cboActivity.Items.Add(str.ToUpper)
        Next
        cboActivity.Text = "%"
    End Sub
    Private Sub LoadSectorComboBox()
        'Load orders
        cboSector.Items.Clear()
        cboSector.Items.Add("%")
        cboSector.Items.Add(cComboSeparator)
        Dim sector As New List(Of String)
        sector = xDatabase.GetSectorList()
        For Each str As String In sector
            cboSector.Items.Add(str.ToUpper)
        Next
        cboSector.Text = "%"
    End Sub
    Private Sub LoadDateTimePicker()
        Dim d As Date = Date.Now
        Dim DaysInMonth As Integer = Date.DaysInMonth(d.Year, d.Month)
        Dim EndDate As Date = New Date(d.Year, d.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(d.Year, d.Month, 1)

        dtpFrom.Value = BeginDate
        dtpTo.Value = EndDate

    End Sub

    Private Sub RemoveTabs()
        Dim ucViewOreLavoroDataList As New List(Of ucViewOreLavoroData)
        For Each tab As TabPage In TabsData.TabPages
            For Each ctrl As Control In tab.Controls
                If TypeOf (ctrl) Is ucViewOreLavoroData Then
                    ucViewOreLavoroDataList.Add(ctrl)
                End If
            Next
        Next
        For Each item As ucViewOreLavoroData In ucViewOreLavoroDataList
            item.Dispose()
            item = Nothing
        Next
        TabsData.TabPages.Clear()
    End Sub

    Private Sub AddOrderTab(Filter As DatabaseManagement.udtFilterOreLavoro)

        Dim tab As New TabPage
        tab.Text = Filter.OrderName
        tab.BorderStyle = BorderStyle.Fixed3D
        tab.Name = Filter.OrderName
        tab.Tag = Filter.OrderName
        Dim ucViewOreLavoroData As New ucViewOreLavoroData
        ucViewOreLavoroData.Name = "ucViewOreLavoroData" & Filter.OrderName
        tab.Controls.Add(ucViewOreLavoroData)
        TabsData.TabPages.Add(tab)

        Dim dt As New DataTable
        dt = xDatabase.GetWorkedHours(Filter)
        ucViewOreLavoroData.LoadData(dt)
    End Sub
    Private Sub AddEmpolyeeTab(Filter As DatabaseManagement.udtFilterOreLavoro)

        Dim tab As New TabPage
        tab.Text = Filter.EmployeeName
        tab.BorderStyle = BorderStyle.Fixed3D
        tab.Name = Filter.EmployeeName
        tab.Tag = Filter.EmployeeName
        Dim ucViewOreLavoroData As New ucViewOreLavoroData
        ucViewOreLavoroData.Name = "ucViewOreLavoroData" & Filter.EmployeeName
        tab.Controls.Add(ucViewOreLavoroData)
        TabsData.TabPages.Add(tab)

        Dim dt As New DataTable
        dt = xDatabase.GetWorkedHours(Filter)
        ucViewOreLavoroData.LoadData(dt)
    End Sub

    Private Sub AddAllOrdersTab(Filter As DatabaseManagement.udtFilterOreLavoro)

        Dim tab As New TabPage
        tab.Text = Filter.OrderName
        tab.BorderStyle = BorderStyle.Fixed3D
        tab.Name = Filter.OrderName
        tab.Tag = Filter.OrderName
        Dim ucViewAllOrdersData As New ucViewAllOrdersData
        ucViewAllOrdersData.Name = "ucViewAllOrdersData" & Filter.OrderName
        AddHandler ucViewAllOrdersData.ItemSelected, AddressOf ucViewAllOrdersData_ItemSelected
        AddHandler ucViewAllOrdersData.DoubleClickOnItem, AddressOf ucViewAllOrdersData_DoubleClickOnItem
        tab.Controls.Add(ucViewAllOrdersData)
        TabsData.TabPages.Add(tab)

        ucViewAllOrdersData.LoadData(Filter)

        'Dim dt As New DataTable
        'dt = xDatabase.GetWorkInProgressOrders(Filter)
        'ucViewAllOrdersData.LoadData(dt)
    End Sub

    Private Sub LoadDataOreLavoro()

        lblOreLavoroCommessa.Text = TimeSpanToText(New TimeSpan)
        lblOreViaggioCommessa.Text = TimeSpanToText(New TimeSpan)
        lblOreLavoroTotale.Text = TimeSpanToText(New TimeSpan)
        lblOreViaggioTotale.Text = TimeSpanToText(New TimeSpan)

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        Dim Filter As New DatabaseManagement.udtFilterOreLavoro
        Filter.EmployeeName = cboEmployee.Text  '  xUsers.UserLogged.Name
        Filter.OrderName = cboOrderName.Text & "%"
        Filter.Activity = cboActivity.Text '  "%"
        Filter.Sector = cboSector.Text '"%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate

        RemoveTabs()

        If cboEmployee.Text <> "%" Then
            Dim Orders As List(Of String) = xDatabase.GetOrdersDoneByUser(Filter)
            For Each ord As String In Orders
                Filter.OrderName = ord
                AddOrderTab(Filter)
            Next
        Else
            Dim Names As List(Of String) = xDatabase.GetUsersListWhoMakeOrder(Filter)
            For Each str As String In Names
                Filter.EmployeeName = str
                AddEmpolyeeTab(Filter)
            Next
        End If

        If TabsData.TabPages.Count > 0 Then
            lblCommessa.Text = TabsData.TabPages(0).Text
            ShowTotalsOrder(lblCommessa.Text)
            ShowTotals()
            OrdersActive = False
            OreLavoroActive = True
            mnu.EnableButton("ExportToExcel", True)
        Else
            OrdersActive = False
            OreLavoroActive = False
            mnu.EnableButton("ExportToExcel", False)
        End If

    End Sub

    Private Sub LoadDataCommesse()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        cboEmployee.Text = "%"

        FilterOreLavoro.EmployeeName = "%"
        FilterOreLavoro.OrderName = cboOrderName.Text & "%"
        FilterOreLavoro.Activity = cboActivity.Text & "%"
        FilterOreLavoro.Sector = cboSector.Text & "%"
        FilterOreLavoro.BeginDate = BeginDate
        FilterOreLavoro.EndDate = EndDate

        RemoveTabs()

        Dim Orders As List(Of String) = xDatabase.GetOrdersDoneByUser(FilterOreLavoro)
        For Each ord As String In Orders
            FilterOreLavoro.OrderName = ord
            AddAllOrdersTab(FilterOreLavoro)
        Next

        If TabsData.TabPages.Count > 0 Then
            lblCommessa.Text = TabsData.TabPages(0).Text
            ShowTotalsOrder(lblCommessa.Text)
            ShowTotals()
            OrdersActive = True
            OreLavoroActive = False
            mnu.EnableButton("ExportToExcel", True)
        Else
            OrdersActive = False
            OreLavoroActive = False
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
                If TypeOf (ctrl) Is ucViewOreLavoroData Then
                    Dim _uc As ucViewOreLavoroData
                    _uc = DirectCast(ctrl, ucViewOreLavoroData)
                    If tab.Name = OrderName Then
                        lblOreLavoroCommessa.Text = TimeSpanToText(_uc.OreLavoro)
                        lblOreViaggioCommessa.Text = TimeSpanToText(_uc.OreViaggio)
                    End If
                End If

                If TypeOf (ctrl) Is ucViewAllOrdersData Then
                    Dim _uc As ucViewAllOrdersData
                    _uc = DirectCast(ctrl, ucViewAllOrdersData)
                    If tab.Name = OrderName Then
                        lblOreLavoroCommessa.Text = TimeSpanToText(_uc.OreLavoro)
                        lblOreViaggioCommessa.Text = TimeSpanToText(_uc.OreViaggio)
                        'lblOreLavoroTotale.Text = ""
                        'lblOreViaggioTotale.Text = ""
                    End If
                End If

            Next
        Next
    End Sub

    Private Sub ShowTotals()
        Dim OreLavoro As New TimeSpan
        Dim OreViaggio As New TimeSpan

        For Each tab As TabPage In TabsData.TabPages
            For Each ctrl As Control In tab.Controls
                If TypeOf (ctrl) Is ucViewOreLavoroData Then
                    Dim _uc As ucViewOreLavoroData
                    _uc = DirectCast(ctrl, ucViewOreLavoroData)
                    OreLavoro = OreLavoro.Add(_uc.OreLavoro)
                    OreViaggio = OreViaggio.Add(_uc.OreViaggio)
                End If
                If TypeOf (ctrl) Is ucViewAllOrdersData Then
                    Dim _uc As ucViewAllOrdersData
                    _uc = DirectCast(ctrl, ucViewAllOrdersData)
                    OreLavoro = OreLavoro.Add(_uc.OreLavoro)
                    OreViaggio = OreViaggio.Add(_uc.OreViaggio)
                End If
            Next
        Next
        lblOreLavoroTotale.Text = TimeSpanToText(OreLavoro)
        lblOreViaggioTotale.Text = TimeSpanToText(OreViaggio)
    End Sub


    'Private Sub cboActivity_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboActivity.SelectedIndexChanged
    '    If IsLoading Then Return
    '    LoadDataOreLavoro()
    'End Sub
    'Private Sub cboSector_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSector.SelectedIndexChanged
    '    If IsLoading Then Return
    '    LoadDataOreLavoro()
    'End Sub


    Private Sub ucViewAllOrdersData_ItemSelected(sender As ucViewAllOrdersData, EmployeeName As String, OrderName As String, Activity As String, Sector As String)

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

    Private Sub ucViewAllOrdersData_DoubleClickOnItem(sender As ucViewAllOrdersData, EmployeeName As String, OrderName As String, Activity As String, Sector As String)


        Using frm As New frmAnalisiOreLavoroDettaglioCommessa
            frm.Filter = New DatabaseManagement.udtFilterOreLavoro
            frm.Filter.EmployeeName = EmployeeName
            frm.Filter.OrderName = OrderName
            frm.Filter.Activity = Activity
            frm.Filter.Sector = Sector
            frm.Filter.BeginDate = FilterOreLavoro.BeginDate
            frm.Filter.EndDate = FilterOreLavoro.EndDate
            frm.ShowDialog()
        End Using

        'ucViewAllOrdersData_ItemSelected(sender, EmployeeName, OrderName, Activity, Sector)

        'cboEmployee.Text = EmployeeName
        'cboOrderName.Text = OrderName
        'cboActivity.Text = Activity
        'cboSector.Text = Sector

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

                    Case "AnalisiOreLavoro"
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        LoadDataOreLavoro()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default
                        mnu.EnableButton("ExportToExcel", OreLavoroActive)
                        mnu.EnableButton("Print", OreLavoroActive)

                    Case "OrdersAnalysis"
                        mnu.SuspendMenu()
                        Me.Cursor = Cursors.WaitCursor
                        LoadDataCommesse()
                        mnu.ActivateMenuSuspended()
                        Me.Cursor = Cursors.Default
                        mnu.EnableButton("ExportToExcel", OrdersActive)
                        mnu.EnableButton("Print", OrdersActive)

                    Case "Print"
                        If OrdersActive Or OreLavoroActive Then
                            mnu.SuspendMenu()
                            Me.Cursor = Cursors.WaitCursor
                            PrintCommesseToPdf()
                            mnu.ActivateMenuSuspended()
                            Me.Cursor = Cursors.Default
                        End If

                    Case "ExportToExcel"
                        If OrdersActive Or OreLavoroActive Then
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

        'cboEmployee.Text = "%"

        'Dim Filter As New DatabaseManagement.udtFilterOreLavoro

        'Filter.EmployeeName = cboEmployee.Text
        'Filter.OrderName = cboOrderName.Text & "%"
        'Filter.Activity = cboActivity.Text & "%"
        'Filter.Sector = cboSector.Text & "%"
        'Filter.BeginDate = BeginDate
        'Filter.EndDate = EndDate

        Using frm As New frmAnalisiOreLavoroExport
            frm.IsEmployeeExport = OreLavoroActive
            frm.Filter = New DatabaseManagement.udtFilterOreLavoro
            frm.Filter.EmployeeName = cboEmployee.Text
            frm.Filter.OrderName = cboOrderName.Text & "%"
            frm.Filter.Activity = cboActivity.Text & "%"
            frm.Filter.Sector = cboSector.Text & "%"
            frm.Filter.BeginDate = BeginDate
            frm.Filter.EndDate = EndDate
            'frm.Filter = Filter.DeepCopy
            ' frm.Filter.OrderName = "%"
            frm.ShowDialog()
        End Using

        'Dim frm = New frmAnalisiOreLavoroExport
        'frm.Filter = New DatabaseManagement.udtFilterOreLavoro
        'frm.Filter = FilterOreLavoro.DeepCopy
        'frm.Filter.OrderName = "%"
        'frm.Show()



    End Sub



#End Region

#Region "Print To PDF"

    Private Sub PrintCommesseToPdf()
        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpTo.Value.Year, dtpTo.Value.Month)
        Dim EndDate As Date = New Date(dtpTo.Value.Year, dtpTo.Value.Month, DaysInMonth, 0, 0, 0)
        Dim BeginDate As Date = New Date(dtpFrom.Value.Year, dtpFrom.Value.Month, 1, 0, 0, 0)

        Dim Filename As String = ""

        Dim Filter As New DatabaseManagement.udtFilterOreLavoro



        Filter.OrderName = cboOrderName.Text & "%"
        Filter.Activity = cboActivity.Text & "%"
        Filter.Sector = cboSector.Text & "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate

        If OreLavoroActive Then
            Filter.EmployeeName = cboEmployee.Text
            Filename = "C:\OreLavoro\AnalisiOre-" & Filter.EmployeeName & ".pdf"
        End If

        If OrdersActive Then
            Filter.EmployeeName = "%"
            Filename = "C:\OreLavoro\AnalisiOre-" & Filter.OrderName.Replace("%", "") & ".pdf"
        End If

        Dim pdf As New PrintToPDF
        pdf.PrintOreLavoroAnalysis(Filename, Filter, OreLavoroActive)
        Dim pdfShow As New frmShowPdf
        pdfShow.FileToShow = Filename
        pdfShow.Size = New Size(1024, 768)
        pdfShow.ShowDialog()
        pdfShow.Dispose()
        pdfShow = Nothing

    End Sub
#End Region
End Class