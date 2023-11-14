Imports Core
Public Class frmAnalisiRefoundExport

    Private Class udtRecord
        Public Property Nome As String = ""
        Public Property Data As String = ""
        Public Property Commessa As String = ""
        Public Property Località As String = ""
        Public Property Km As String = ""
        Public Property Autostrada As String = ""
        Public Property Mezzi As String = ""
        Public Property Vitto As String = ""
        Public Property Alloggio As String = ""
        Public Property Varie As String = ""
    End Class

    Public Property Filter As DatabaseManagement.udtFilterRefound
    Public Property IsEmployeeExport As Boolean
    Public Property Employee As String = ""

    Private Sub frmAnalisiRefoundExport_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Analisi spese, esporta dati"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        LoadData()
    End Sub

    Private Sub LoadData()
        Dim rec As New udtRecord
        Dim dtData As New DataTable

        If Not IsEmployeeExport Then
            Filter.EmployeeName = "%"
        End If

        If IsEmployeeExport Then
            dtData = xDatabase.GetUserAnalysisRefoundByOrders(Filter)
            If IsNothing(dtData) Then
                dgv.DataSource = Nothing
                dgv.Rows.Clear()
            Else
                dgv.Rows.Clear()
                dgv.Columns.Clear()
                Dim NomeCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Nome", .HeaderText = "Nome"}
                Dim DataCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Data", .HeaderText = "Data"}
                Dim CommessaCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Commessa", .HeaderText = "Commessa"}
                Dim LocalitàCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Località", .HeaderText = "Località"}
                Dim KmCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Km", .HeaderText = "Km"}
                Dim AutostradaCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Autostrada", .HeaderText = "Autostrada"}
                Dim MezziCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Mezzi", .HeaderText = "Mezzi"}
                Dim VittoCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Vitto", .HeaderText = "Vitto"}
                Dim AlloggioCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Alloggio", .HeaderText = "Alloggio"}
                Dim VarieCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Varie", .HeaderText = "Varie"}
                dgv.Columns.AddRange(NomeCol, DataCol, CommessaCol, LocalitàCol, KmCol, AutostradaCol, MezziCol, VittoCol, AlloggioCol, VarieCol)

                Dim Commessa As String = ""
                Dim Nome As String = ""

                For iRow As Integer = 0 To dtData.Rows.Count - 1

                    rec.Nome = dtData.Rows(iRow).Item(0).ToString
                    rec.Data = dtData.Rows(iRow).Item(1).ToString.Replace("00:00:00", "")
                    rec.Commessa = dtData.Rows(iRow).Item(2).ToString
                    rec.Località = dtData.Rows(iRow).Item(3).ToString
                    rec.Km = dtData.Rows(iRow).Item(4).ToString
                    rec.Autostrada = dtData.Rows(iRow).Item(5).ToString
                    rec.Mezzi = dtData.Rows(iRow).Item(6).ToString
                    rec.Vitto = dtData.Rows(iRow).Item(7).ToString
                    rec.Alloggio = dtData.Rows(iRow).Item(8).ToString
                    rec.Varie = dtData.Rows(iRow).Item(9).ToString
                    dgv.Rows.Add(rec.Nome, rec.Data, rec.Commessa, rec.Località, rec.Km, rec.Autostrada, rec.Mezzi, rec.Vitto, rec.Alloggio, rec.Varie)

                    Employee = rec.Nome
                Next
                dgv.ColumnHeadersVisible = False
                dgv.RowHeadersVisible = False

                If dgv.ColumnCount > 1 Then
                    dgv.Columns(0).Width = 118
                    dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(1).Width = 95
                    dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(2).Width = 125
                    dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(3).Width = 110
                    dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(4).Width = 53
                    dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(5).Width = 65
                    dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(6).Width = 53
                    dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(7).Width = 53
                    dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(8).Width = 53
                    dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgv.Columns(9).Width = 53
                    dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                End If

            End If
        Else
            Dim Names As List(Of String) = xDatabase.GetUsersListWhoMakeOrderWithRefound(Filter)
            If IsNothing(Names) Then
                dgv.DataSource = Nothing
                dgv.Rows.Clear()
            Else
                dgv.Rows.Clear()
                dgv.Columns.Clear()
                Dim NomeCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Nome", .HeaderText = "Nome"}
                Dim DataCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Data", .HeaderText = "Data"}
                Dim CommessaCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Commessa", .HeaderText = "Commessa"}
                Dim LocalitàCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Località", .HeaderText = "Località"}
                Dim KmCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Km", .HeaderText = "Km"}
                Dim AutostradaCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Autostrada", .HeaderText = "Autostrada"}
                Dim MezziCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Mezzi", .HeaderText = "Mezzi"}
                Dim VittoCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Vitto", .HeaderText = "Vitto"}
                Dim AlloggioCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Alloggio", .HeaderText = "Alloggio"}
                Dim VarieCol As New DataGridViewTextBoxColumn With {.DataPropertyName = "Varie", .HeaderText = "Varie"}
                dgv.Columns.AddRange(NomeCol, DataCol, CommessaCol, LocalitàCol, KmCol, AutostradaCol, MezziCol, VittoCol, AlloggioCol, VarieCol)

                For Each name As String In Names
                    Filter.EmployeeName = name
                    dtData = xDatabase.GetUserAnalysisRefoundByOrders(Filter)
                    For iRow As Integer = 0 To dtData.Rows.Count - 1

                        rec.Nome = dtData.Rows(iRow).Item(0).ToString
                        rec.Data = dtData.Rows(iRow).Item(1).ToString.Replace("00:00:00", "")
                        rec.Commessa = dtData.Rows(iRow).Item(2).ToString
                        rec.Località = dtData.Rows(iRow).Item(3).ToString
                        rec.Km = dtData.Rows(iRow).Item(4).ToString
                        rec.Autostrada = dtData.Rows(iRow).Item(5).ToString
                        rec.Mezzi = dtData.Rows(iRow).Item(6).ToString
                        rec.Vitto = dtData.Rows(iRow).Item(7).ToString
                        rec.Alloggio = dtData.Rows(iRow).Item(8).ToString
                        rec.Varie = dtData.Rows(iRow).Item(9).ToString
                        dgv.Rows.Add(rec.Nome, rec.Data, rec.Commessa, rec.Località, rec.Km, rec.Autostrada, rec.Mezzi, rec.Vitto, rec.Alloggio, rec.Varie)

                        Employee = rec.Nome
                    Next
                    dgv.ColumnHeadersVisible = False
                    dgv.RowHeadersVisible = False

                    If dgv.ColumnCount > 1 Then
                        dgv.Columns(0).Width = 118
                        dgv.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(1).Width = 95
                        dgv.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(2).Width = 125
                        dgv.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(3).Width = 110
                        dgv.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(4).Width = 53
                        dgv.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(5).Width = 65
                        dgv.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(6).Width = 53
                        dgv.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(7).Width = 53
                        dgv.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(8).Width = 53
                        dgv.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                        dgv.Columns(9).Width = 53
                        dgv.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    End If
                Next
            End If
        End If




    End Sub

    Private Sub plsExport_Click(sender As Object, e As EventArgs) Handles plsExport.Click
        Dim FileName As String = ""

        If IsEmployeeExport Then
            FileName = "AnalisiSpese" & Employee
        Else
            FileName = "AnalisiSpese"
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