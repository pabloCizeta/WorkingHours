Imports Core

Public Class frmAnalisiOreLavoroExport

    Private Class udtRecord
        Public Class udtOre
            Public Property Lavoro As New TimeSpan
            Public Property Viaggio As New TimeSpan
            Public Property Progettazione As New Core.ResPublic.udtOre
            Public Property MifCliente As New Core.ResPublic.udtOre
            Public Property MifFinale As New Core.ResPublic.udtOre
            Public Property Altro As New Core.ResPublic.udtOre
        End Class

        Public Property Nome As String = ""
        Public Property Commessa As String = ""
        Public Property Activity As String = ""
        Public Property Sector As String = ""
        Public Property Ore As New udtOre
    End Class

    Public Property Filter As DatabaseManagement.udtFilterOreLavoro

    Public Property IsEmployeeExport As Boolean
    Public Property Employee As String = ""

    Private Sub frmAnalisiOreLavoroExport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Analisi ore lavoro, esporta dati"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        LoadData()

    End Sub

    Private Sub LoadData()

        Dim rec As New udtRecord
        Dim dtData As New DataTable

        If Not IsEmployeeExport Then
            Filter.EmployeeName = "%"
        End If

        dtData = xDatabase.GetWorkInProgressOrders(Filter)
        If IsNothing(dtData) Then
            dgv.DataSource = Nothing
            dgv.Rows.Clear()
        Else
            dgv.Rows.Clear()
            dgv.Columns.Clear()
            Dim NomeCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Nome", .HeaderText = "Nome"}
            Dim CommessaCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Commessa", .HeaderText = "Commessa"}
            Dim OreLavoroCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavoro", .HeaderText = "Lavoro"}
            Dim OreViaggioCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaggio", .HeaderText = "Viaggio"}
            Dim OreLavProgCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavProgetto", .HeaderText = "Progetto.Lavoro"}
            Dim OreViaProgCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaProgetto", .HeaderText = "Progetto.Viaggio"}
            Dim OreLavMifCliCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavMifCli", .HeaderText = "MifCliente.Lavoro"}
            Dim OreViaMifCliCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaMifCli", .HeaderText = "MifCliente.Viaggio"}
            Dim OreLavMifFinCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavMifFin", .HeaderText = "MifFinale.Lavoro"}
            Dim OreViaMifFinCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaMifFin", .HeaderText = "MifFinale.Viaggio"}
            Dim OreLavAltroCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreLavAltro", .HeaderText = "Altro.Lavoro"}
            Dim OreViaAltroCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "OreViaAltro", .HeaderText = "Altro.Viaggio"}
            dgv.Columns.AddRange(NomeCol, CommessaCol, OreLavoroCol, OreViaggioCol, OreLavProgCol, OreViaProgCol, OreLavMifCliCol, OreViaMifCliCol, OreLavMifFinCol, OreViaMifFinCol, OreLavAltroCol, OreViaAltroCol)

            dgv.Columns(2).DividerWidth = 5

            Dim Commessa As String = ""
            Dim Nome As String = ""
            For iRow As Integer = 0 To dtData.Rows.Count - 1

                If IsEmployeeExport Then
                    If Commessa = "" Then
                        Commessa = dtData.Rows(iRow).Item(0).ToString
                        Nome = dtData.Rows(iRow).Item(3).ToString
                        'Nuova Commessa
                        rec = New udtRecord
                    End If
                    If (Commessa <> dtData.Rows(iRow).Item(0).ToString) Then
                        'Nuova Commessa
                        'Add row
                        Dim ProgLav As String = TimeSpanToText(rec.Ore.Progettazione.Lavoro)
                        Dim ProgVia As String = TimeSpanToText(rec.Ore.Progettazione.Viaggio)
                        Dim MifCLav As String = TimeSpanToText(rec.Ore.MifCliente.Lavoro)
                        Dim MifCVia As String = TimeSpanToText(rec.Ore.MifCliente.Viaggio)
                        Dim MifFLav As String = TimeSpanToText(rec.Ore.MifFinale.Lavoro)
                        Dim MifFVia As String = TimeSpanToText(rec.Ore.MifFinale.Viaggio)
                        Dim AltroLav As String = TimeSpanToText(rec.Ore.Altro.Lavoro)
                        Dim AltroVia As String = TimeSpanToText(rec.Ore.Altro.Viaggio)
                        dgv.Rows.Add(rec.Nome, rec.Commessa, TimeSpanToText(rec.Ore.Lavoro), TimeSpanToText(rec.Ore.Viaggio), ProgLav, ProgVia, MifCLav, MifCVia, MifFLav, MifFVia, AltroLav, AltroVia)

                        rec = New udtRecord
                        Commessa = dtData.Rows(iRow).Item(0).ToString
                        Nome = dtData.Rows(iRow).Item(3).ToString
                    End If
                    rec.Commessa = dtData.Rows(iRow).Item(0).ToString
                    rec.Nome = dtData.Rows(iRow).Item(3).ToString

                    Dim f As New DatabaseManagement.udtFilterOreLavoro
                    f.EmployeeName = dtData.Rows(iRow).Item(3).ToString
                    f.OrderName = dtData.Rows(iRow).Item(0).ToString
                    f.Activity = dtData.Rows(iRow).Item(1).ToString
                    f.Sector = dtData.Rows(iRow).Item(2).ToString
                    f.BeginDate = Filter.BeginDate
                    f.EndDate = Filter.EndDate
                    Dim dt As New DataTable
                    dt = xDatabase.GetWorkedHours(f)
                    Dim ore As Core.ResPublic.udtOre = GetOre(dt, 4, 5) '4,5
                    rec.Ore.Lavoro = rec.Ore.Lavoro.Add(ore.Lavoro)
                    rec.Ore.Viaggio = rec.Ore.Viaggio.Add(ore.Viaggio)
                    If dtData.Rows(iRow).Item(1).ToString = "PROGETTAZIONE" Then
                        rec.Ore.Progettazione.Lavoro = rec.Ore.Progettazione.Lavoro.Add(ore.Lavoro)
                        rec.Ore.Progettazione.Viaggio = rec.Ore.Progettazione.Viaggio.Add(ore.Viaggio)
                    ElseIf dtData.Rows(iRow).Item(1).ToString = "MIF-CLIENTE" Then
                        rec.Ore.MifCliente.Lavoro = rec.Ore.MifCliente.Lavoro.Add(ore.Lavoro)
                        rec.Ore.MifCliente.Viaggio = rec.Ore.MifCliente.Viaggio.Add(ore.Viaggio)
                    ElseIf dtData.Rows(iRow).Item(1).ToString = "MIF-FINALE" Then
                        rec.Ore.MifFinale.Lavoro = rec.Ore.MifFinale.Lavoro.Add(ore.Lavoro)
                        rec.Ore.MifFinale.Viaggio = rec.Ore.MifFinale.Viaggio.Add(ore.Viaggio)
                    Else
                        rec.Ore.Altro.Lavoro = rec.Ore.Altro.Lavoro.Add(ore.Lavoro)
                        rec.Ore.Altro.Viaggio = rec.Ore.Altro.Viaggio.Add(ore.Viaggio)
                    End If
                    Employee = f.EmployeeName

                Else
                    If Nome = "" Then
                        Commessa = dtData.Rows(iRow).Item(0).ToString
                        Nome = dtData.Rows(iRow).Item(3).ToString
                        'Nuova Nome
                        rec = New udtRecord
                    End If
                    If (Nome <> dtData.Rows(iRow).Item(3).ToString) Then
                        'Nuovo Nome
                        'Add row
                        Dim ProgLav As String = TimeSpanToText(rec.Ore.Progettazione.Lavoro)
                        Dim ProgVia As String = TimeSpanToText(rec.Ore.Progettazione.Viaggio)
                        Dim MifCLav As String = TimeSpanToText(rec.Ore.MifCliente.Lavoro)
                        Dim MifCVia As String = TimeSpanToText(rec.Ore.MifCliente.Viaggio)
                        Dim MifFLav As String = TimeSpanToText(rec.Ore.MifFinale.Lavoro)
                        Dim MifFVia As String = TimeSpanToText(rec.Ore.MifFinale.Viaggio)
                        Dim AltroLav As String = TimeSpanToText(rec.Ore.Altro.Lavoro)
                        Dim AltroVia As String = TimeSpanToText(rec.Ore.Altro.Viaggio)
                        dgv.Rows.Add(rec.Nome, rec.Commessa, TimeSpanToText(rec.Ore.Lavoro), TimeSpanToText(rec.Ore.Viaggio), ProgLav, ProgVia, MifCLav, MifCVia, MifFLav, MifFVia, AltroLav, AltroVia)

                        rec = New udtRecord
                        Commessa = dtData.Rows(iRow).Item(0).ToString
                        Nome = dtData.Rows(iRow).Item(3).ToString
                    End If
                    rec.Commessa = dtData.Rows(iRow).Item(0).ToString
                    rec.Nome = dtData.Rows(iRow).Item(3).ToString

                    Dim f As New DatabaseManagement.udtFilterOreLavoro
                    f.EmployeeName = dtData.Rows(iRow).Item(3).ToString
                    f.OrderName = dtData.Rows(iRow).Item(0).ToString
                    f.Activity = dtData.Rows(iRow).Item(1).ToString
                    f.Sector = dtData.Rows(iRow).Item(2).ToString
                    f.BeginDate = Filter.BeginDate
                    f.EndDate = Filter.EndDate
                    Dim dt As New DataTable
                    dt = xDatabase.GetWorkedHours(f)
                    Dim ore As Core.ResPublic.udtOre = GetOre(dt, 4, 5) '4,5
                    rec.Ore.Lavoro = rec.Ore.Lavoro.Add(ore.Lavoro)
                    rec.Ore.Viaggio = rec.Ore.Viaggio.Add(ore.Viaggio)
                    If dtData.Rows(iRow).Item(1).ToString = "PROGETTAZIONE" Then
                        rec.Ore.Progettazione.Lavoro = rec.Ore.Progettazione.Lavoro.Add(ore.Lavoro)
                        rec.Ore.Progettazione.Viaggio = rec.Ore.Progettazione.Viaggio.Add(ore.Viaggio)
                    ElseIf dtData.Rows(iRow).Item(1).ToString = "MIF-CLIENTE" Then
                        rec.Ore.MifCliente.Lavoro = rec.Ore.MifCliente.Lavoro.Add(ore.Lavoro)
                        rec.Ore.MifCliente.Viaggio = rec.Ore.MifCliente.Viaggio.Add(ore.Viaggio)
                    ElseIf dtData.Rows(iRow).Item(1).ToString = "MIF-FINALE" Then
                        rec.Ore.MifFinale.Lavoro = rec.Ore.MifFinale.Lavoro.Add(ore.Lavoro)
                        rec.Ore.MifFinale.Viaggio = rec.Ore.MifFinale.Viaggio.Add(ore.Viaggio)
                    Else
                        rec.Ore.Altro.Lavoro = rec.Ore.Altro.Lavoro.Add(ore.Lavoro)
                        rec.Ore.Altro.Viaggio = rec.Ore.Altro.Viaggio.Add(ore.Viaggio)
                    End If
                    Employee = f.EmployeeName

                    If iRow = dtData.Rows.Count - 1 Then
                        Dim ProgLav As String = TimeSpanToText(rec.Ore.Progettazione.Lavoro)
                        Dim ProgVia As String = TimeSpanToText(rec.Ore.Progettazione.Viaggio)
                        Dim MifCLav As String = TimeSpanToText(rec.Ore.MifCliente.Lavoro)
                        Dim MifCVia As String = TimeSpanToText(rec.Ore.MifCliente.Viaggio)
                        Dim MifFLav As String = TimeSpanToText(rec.Ore.MifFinale.Lavoro)
                        Dim MifFVia As String = TimeSpanToText(rec.Ore.MifFinale.Viaggio)
                        Dim AltroLav As String = TimeSpanToText(rec.Ore.Altro.Lavoro)
                        Dim AltroVia As String = TimeSpanToText(rec.Ore.Altro.Viaggio)
                        dgv.Rows.Add(rec.Nome, rec.Commessa, TimeSpanToText(rec.Ore.Lavoro), TimeSpanToText(rec.Ore.Viaggio), ProgLav, ProgVia, MifCLav, MifCVia, MifFLav, MifFVia, AltroLav, AltroVia)

                        rec = New udtRecord
                        Commessa = dtData.Rows(iRow).Item(0).ToString
                        Nome = dtData.Rows(iRow).Item(3).ToString
                    End If

                End If

            Next

            dgv.ColumnHeadersVisible = False
            dgv.RowHeadersVisible = False
            'If dgv.ColumnCount > 1 Then
            '    dgv.Columns(0).Width = 235
            '    dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(1).Width = 53
            '    dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(2).Width = 53
            '    dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(3).Width = 53
            '    dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(4).Width = 53
            '    dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(5).Width = 53
            '    dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(6).Width = 53
            '    dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(7).Width = 53
            '    dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(8).Width = 53
            '    dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(9).Width = 53
            '    dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            '    dgv.Columns(10).Width = 53
            '    dgv.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'End If
            If dgv.ColumnCount > 1 Then
                dgv.Columns(0).Width = 118
                dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(1).Width = 117
                dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(2).Width = 53
                dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(3).Width = 53
                dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(4).Width = 53
                dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(5).Width = 53
                dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(6).Width = 53
                dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(7).Width = 53
                dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(8).Width = 53
                dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(9).Width = 53
                dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(10).Width = 53
                dgv.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv.Columns(11).Width = 53
                dgv.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        End If

    End Sub

    Private Sub plsExport_Click(sender As Object, e As EventArgs) Handles plsExport.Click
        Dim FileName As String = ""

        If IsEmployeeExport Then
            FileName = "Analisi" & Employee
        Else
            FileName = "Analisi"
        End If


        Call BrowseFile(FileName)
        If FileName <> "" Then ExportDataTable(dgv, FileName)

    End Sub

    Private Sub BrowseFile(ByRef FileName As String)

        'Sfoglia file
        Dim fileDlg As FileDialog
        fileDlg = New SaveFileDialog
        fileDlg.FileName = FileName
        fileDlg.CheckFileExists = False
        fileDlg.Filter = "Semicolon separated values (*.csv)|*.csv"
        If fileDlg.ShowDialog() = DialogResult.OK Then
            FileName = fileDlg.FileName
        Else
            FileName = ""
        End If
        fileDlg.Dispose()
    End Sub
End Class