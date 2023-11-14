Imports Core

Public Class frmAnalisiOreLavoroDettaglioCommessa

    Public Property Filter As DatabaseManagement.udtFilterOreLavoro

    Private Sub frmAnalisiOreLavoroDettaglioCommessa_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.AssemblyName & " - " & xGlobals.Release & " - Analisi ore lavoro, dettaglio commessa"
        Me.Icon = New System.Drawing.Icon(xGlobals.PicturePath & "OreLavoro.ico")

        LoadData()

    End Sub


    Private Sub LoadData()

        lblEmployeeName.Text = Filter.EmployeeName

        Dim dtOreLavoro As New DataTable

        dtOreLavoro = xDatabase.GetWorkedHours(Filter)

        If IsNothing(dtOreLavoro) Then
            dgvOreLavoro.DataSource = Nothing
            dgvOreLavoro.Rows.Clear()
        Else
            dgvOreLavoro.DataSource = dtOreLavoro 'bsTrace
            dgvOreLavoro.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells)
            'dgvOreLavoro.RowHeadersWidth = 10
            dgvOreLavoro.RowHeadersVisible = False
            If dgvOreLavoro.ColumnCount > 1 Then
                dgvOreLavoro.Columns(0).Width = 80
                dgvOreLavoro.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOreLavoro.Columns(1).Width = 200
                dgvOreLavoro.Columns(2).Width = 120
                dgvOreLavoro.Columns(3).Width = 100
                dgvOreLavoro.Columns(4).Width = 60
                dgvOreLavoro.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvOreLavoro.Columns(5).Width = 60
                dgvOreLavoro.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            End If

        End If

    End Sub

End Class