Imports Core

Public Class frmAdjustExpenses

    Private CheckInputData As Core.CheckInputData

    Private dtpDateChanging As Boolean = False
    Private LastDateShown As Date = Now

    Private IsLoading As Boolean = False

    Private CostoKm As Single = 0

    Private EmployeeCfg As New DatabaseManagement.udtEmployeeData
    Private Riporti As New DatabaseManagement.udtRiporti


    Private Sub frmAdjustExpenses_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Ravana spese"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        Call ShowMenu()

        CheckInputData = New Core.CheckInputData()

        IsLoading = True
        LoadEmpolyeeComboBox()



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

    Private Sub LoadData()

        Dim dtData As New DataTable

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        Dim Filter As New DatabaseManagement.udtFilterRefound
        Filter.EmployeeName = cboEmployeeName.Text
        Filter.OrderName = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        dtData = xDatabase.GetUserRefound(Filter)

        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
            txtOreFatte.Text = "0"
            txtOreInBusta.Text = "0"
            txtCostoOrario.Text = "0"
            txtGiorniTrasfertaItalia.Text = "0"
            txtGiorniTrasfertaEstero.Text = "0"
            txtGiorniTrasfertaEsteroLungo.Text = "0"
            txtCompetenzeStraordinario.Text = "0.00"
            txtCompetenze.Text = "0.00"
            txtDiaria.Text = "0"
            txtSpese.Text = "0"
            txtRiporti.Text = "0"
            txtContanti.Text = "0"
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
                dgv.DataSource = Nothing
                dgv.Rows.Clear()
                txtOreFatte.Text = "0"
                txtOreInBusta.Text = "0"
                txtCostoOrario.Text = "0"
                txtGiorniTrasfertaItalia.Text = "0"
                txtGiorniTrasfertaEstero.Text = "0"
                txtGiorniTrasfertaEsteroLungo.Text = "0"
                txtCompetenzeStraordinario.Text = "0.00"
                txtDiaria.Text = "0"
                txtSpese.Text = "0"
                txtRiporti.Text = "0"
                txtContanti.Text = "0"
            End If
        End If

        CostoKm = xDatabase.RimborsoKm(cboEmployeeName.Text)

        EmployeeCfg = xDatabase.EmployeeData(cboEmployeeName.Text)
        Riporti = xDatabase.GetRiporti(cboEmployeeName.Text, BeginDate)
        If Riporti.CostoOrario = 0 Then
            txtCostoOrario.Text = Format(EmployeeCfg.CostoOrario, "#0.00")
        Else
            txtCostoOrario.Text = Format(Riporti.CostoOrario, "#0.00")
        End If
        txtOreInBusta.Text = Riporti.OreInBusta

        txtContanti.Text = Format(Riporti.Contanti, "#0.00")
        txtRiporti.Text = Format(Riporti.Riporto, "#0.00")

        If Riporti.CostoTrasfertaItalia = 0 Then
            txtGiorniTrasfertaItalia.Text = Riporti.GiorniTrasfertaItalia
            lblCostoTrasfertaItalia.Text = Format(xConfig.OreLavoro.TrasfertaItalia, "#0.00")
            txtGiorniTrasfertaEstero.Text = Riporti.GiorniTrasfertaEstero
            lblCostoTrasfertaEstero.Text = Format(xConfig.OreLavoro.TrasfertaEstero, "#0.00")
            txtGiorniTrasfertaEsteroLungo.Text = Riporti.GiorniTrasfertaEsteroLungo
            lblCostoTrasfertaLungo.Text = Format(xConfig.OreLavoro.TrasfertaEsteroWeekEnd, "#0.00")
        Else
            txtGiorniTrasfertaItalia.Text = Riporti.GiorniTrasfertaItalia
            lblCostoTrasfertaItalia.Text = Format(Riporti.CostoTrasfertaItalia, "#0.00")
            txtGiorniTrasfertaEstero.Text = Riporti.GiorniTrasfertaEstero
            lblCostoTrasfertaEstero.Text = Format(Riporti.CostoTrasfertaEstero, "#0.00")
            txtGiorniTrasfertaEsteroLungo.Text = Riporti.GiorniTrasfertaEsteroLungo
            lblCostoTrasfertaLungo.Text = Format(Riporti.CostoTrasfertaEsteroLungo, "#0.00")
        End If


        txtTrasferta.Text = Format(Trasferta, "#0.00")
        txtTrasfertaCedolino.Text = Format(0.0, "#0.00")

    End Sub

    Private Function Trasferta() As Single
        Dim res As Single = 0
        Dim TrasfCedolino As Single = TextToSingle(txtTrasfertaCedolino.Text)
        res = TextToSingle(txtGiorniTrasfertaItalia.Text) * TextToSingle(lblCostoTrasfertaItalia.Text)
        res += TextToSingle(txtGiorniTrasfertaEstero.Text) * TextToSingle(lblCostoTrasfertaEstero.Text)
        res += TextToSingle(txtGiorniTrasfertaEsteroLungo.Text) * TextToSingle(lblCostoTrasfertaLungo.Text)
        Return res - TrasfCedolino
    End Function

    Private Sub cboEmployeeName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEmployeeName.SelectedIndexChanged


        LoadData()

    End Sub

    Private Sub dtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        If DateDiff(DateInterval.Month, LastDateShown, dtpDate.Value) <> 0 Then
            LastDateShown = dtpDate.Value
            LoadData()
            Calculate()
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


                    Case "Calculate"
                        Calculate()

                    Case "Save"
                        Save()



                End Select
        End Select



    End Sub

    Private Sub Calculate()

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)

        'Competenze
        Dim Spese As Single = 0
        For Each row As DataGridViewRow In dgv.Rows
            If (row.Cells(11).Value = "F") And (row.Cells(12).Value <> "S") Then
                Spese += TextToSingle(row.Cells(6).Value) + TextToSingle(row.Cells(7).Value)
            End If
        Next
        txtSpese.Text = Format(Spese, "#0.00")

        Dim Diaria As Single = 0
        For Each row As DataGridViewRow In dgv.Rows
            Diaria += TextToSingle(row.Cells(13).Value)
        Next

        Dim Km As Integer = 0
        For Each row As DataGridViewRow In dgv.Rows
            If (row.Cells(11).Value = "F") And (row.Cells(12).Value = "S") Then
                Km += TextToSingle(row.Cells(3).Value)
            End If
        Next
        Diaria += Km * CostoKm
        txtDiaria.Text = Format(Diaria, "#0.00")

        Dim rip As New DatabaseManagement.udtRiporti
        rip = xDatabase.GetRiporti(cboEmployeeName.Text, dtpDate.Value)

        Dim Riporti As Single = rip.Riporto
        txtRiporti.Text = Format(Riporti, "#0.00")

        'Dim Riporti As Single = TextToSingle(txtRiporti.Text)
        Dim Contanti As Single = TextToSingle(txtContanti.Text)

        Dim Competenze As Single = Diaria - Spese + Riporti + Contanti
        txtCompetenze.Text = Format(Competenze, "#0.00")


        'Competenze ore straordinarie
        Dim dtOreLavoro As New DataTable
        Dim Filter As New DatabaseManagement.udtFilterOreLavoro
        Filter.EmployeeName = cboEmployeeName.Text
        Filter.OrderName = "%"
        Filter.Activity = "%"
        Filter.Sector = "%"
        Filter.BeginDate = BeginDate
        Filter.EndDate = EndDate
        dtOreLavoro = xDatabase.GetWorkedHoursMonthly(Filter)

        Dim ore As udtOre = GetOre(dtOreLavoro, 4, 5)
        Dim wh As TimeSpan = GetWorkingHours(BeginDate, EndDate)
        ore.Straordinario = ore.Lavoro.Add(ore.Viaggio)
        ore.Straordinario = ore.Straordinario.Subtract(wh)
        txtOreFatte.Text = TimeSpanToText(ore.Straordinario)

        Dim OreInBusta As TimeSpan = TextToTimeSpan(txtOreInBusta.Text)
        ore.Straordinario = ore.Straordinario.Subtract(OreInBusta)

        Dim CostoOrario As Single = TextToSingle(txtCostoOrario.Text)

        'Trasferta
        txtTrasferta.Text = Trasferta()
        Dim Trasfetra As Single = TextToSingle(txtTrasferta.Text)

        'Dim CompetenzeStraordinario As Single = (ore.Straordinario.Days * 24 * CostoOrario) + (ore.Straordinario.Hours * CostoOrario) + (ore.Straordinario.Minutes * (CostoOrario / 60))
        Dim CompetenzeStraordinario As Single = (((ore.Straordinario.Days * 24) + ore.Straordinario.Hours) * CostoOrario) + (ore.Straordinario.Minutes * (CostoOrario / 60))
        CompetenzeStraordinario = CompetenzeStraordinario + Trasfetra

        txtCompetenzeStraordinario.Text = Format(CompetenzeStraordinario, "#0.00")


        mnu.EnableButton("Save", True)
    End Sub

    Private Sub Save()
        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Value.Year, dtpDate.Value.Month)
        Dim EndDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Value.Year, dtpDate.Value.Month, 1)


        Dim rip As New DatabaseManagement.udtRiporti
        rip.Riporto = TextToSingle(txtCompetenze.Text) - TextToSingle(txtCompetenzeStraordinario.Text)
        rip.OreInBusta = TimeSpanToText(TextToTimeSpan(txtOreInBusta.Text))
        rip.Contanti = TextToSingle(txtContanti.Text)
        rip.CostoOrario = TextToSingle(txtCostoOrario.Text)
        rip.GiorniTrasfertaItalia = TextToInt(txtGiorniTrasfertaItalia.Text)
        rip.CostoTrasfertaItalia = TextToInt(lblCostoTrasfertaItalia.Text)
        'rip.GiorniTrasfertaEstero = TextToInt(txtGiorniTrasfertaItalia.Text)
        rip.GiorniTrasfertaEstero = TextToInt(txtGiorniTrasfertaEstero.Text)
        rip.CostoTrasfertaEstero = TextToInt(lblCostoTrasfertaEstero.Text)
        rip.GiorniTrasfertaEsteroLungo = TextToInt(txtGiorniTrasfertaEsteroLungo.Text)
        rip.CostoTrasfertaEsteroLungo = TextToInt(lblCostoTrasfertaLungo.Text)

        If Not xDatabase.UpdateRiporti(cboEmployeeName.Text, BeginDate, rip) Then
            MsgBox("Dati non salvati", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly)




        Else
            MsgBox("Dati salvati correttamente", MsgBoxStyle.Information + MsgBoxStyle.OkOnly)
            'Genera file per dati da importare nella versione dipendenti
            Dim FileName As String = xGlobals.DataPath & "Imports\Data" & cboEmployeeName.Text.Replace(" ", "") & ".xml"
            Dim Riporti As Single = TextToSingle(txtRiporti.Text)
            Dim data As New EmployeeData(FileName)
            Dim item As New EmployeeData.udtMoneyData
            item.Riporti = Riporti
            data.Data.MoneyAttuali.Add(item)
            data.WriteDataToFile()

            'data.ReadDataFromFile()
        End If

    End Sub

    Private Sub Shut()
        Me.Close()
        Me.Dispose()
    End Sub


    Private Sub DisableSave() Handles _
            txtSpese.KeyPress, txtCostoOrario.KeyPress, txtDiaria.KeyPress, txtSpese.KeyPress, txtRiporti.KeyPress, txtContanti.KeyPress,
            txtGiorniTrasfertaItalia.KeyPress, txtGiorniTrasfertaEstero.KeyPress, txtGiorniTrasfertaEsteroLungo.KeyPress
        mnu.EnableButton("Save", False)
    End Sub

#End Region


#Region "Check data input"

    Private Sub SelectOnGotFocus(ByVal sender As Object, ByVal e As System.EventArgs)

        sender.backcolor = Color.White
    End Sub
    Private Sub OnlyTimeOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtOreFatte.KeyPress, txtOreInBusta.KeyPress, txtGiorniTrasfertaItalia.KeyPress, txtGiorniTrasfertaEstero.KeyPress, txtGiorniTrasfertaEsteroLungo.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyInteger(sender, e.KeyChar, "+")
    End Sub
    Private Sub OnlyRealOnKeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _
            txtSpese.KeyPress, txtCostoOrario.KeyPress, txtDiaria.KeyPress, txtSpese.KeyPress, txtRiporti.KeyPress, txtContanti.KeyPress

        sender.backcolor = Color.White
        e.KeyChar = CheckInputData.OnlyNumber(sender, e.KeyChar, "+")
    End Sub


    Private Function CheckData() As Boolean

        If Not CheckInputData.IsValueExisting(txtOreFatte) Then Return False
        If Not CheckInputData.IsValueExisting(txtOreInBusta) Then Return False

        If Not CheckInputData.IsValueNumericOk(txtSpese, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtCostoOrario, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtDiaria, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtSpese, 0, 999999) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtRiporti, 0, 999999) Then Return False

        If Not CheckInputData.IsValueNumericOk(txtGiorniTrasfertaItalia, 0, 99) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtGiorniTrasfertaEstero, 0, 99) Then Return False
        If Not CheckInputData.IsValueNumericOk(txtGiorniTrasfertaEsteroLungo, 0, 99) Then Return False



        Return True

    End Function

    'Private Sub DisableSave(sender As Object, e As KeyPressEventArgs) Handles txtTrasferta.KeyPress, txtSpese.KeyPress, txtRiporti.KeyPress, txtDiaria.KeyPress, txtCostoOrario.KeyPress, txtContanti.KeyPress

    'End Sub




#End Region


End Class