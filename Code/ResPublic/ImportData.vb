Imports Core
Imports System.Data.OleDb

Public Class ImportData

    Private ser As Serialization


#Region "DataTypes"

    Public Class udtOreLavoro
        Public Property Data As Date
        Public Property OrderName As String
        Public Property Activity As String
        Public Property Sector As String
        Public Property WorkingHours As String
        Public Property JourneyHours As String
    End Class

    Public Class udtExpense
        Public Property Data As Date
        Public Property OrderName As String
        Public Property City As String = ""
        Public Property Km As Integer = 0
        Public Property Autostrada As Single = 0
        Public Property MezziPubblici As Single = 0
        Public Property Vitto As Single = 0
        Public Property Alloggio As Single = 0
        Public Property Varie As Single = 0
        Public Property CCA As Single = 0
        Public Property Valuta As Single = 0
        Public Property TipoRimborso As String = ""
        Public Property Motivo As String = ""
        Public Property Diaria As Single = 0
    End Class

#End Region

    Public Class udtDiario

        ' Public Property Data As String
        Public Property OreLavoro As New List(Of udtOreLavoro)
        Public Property Spese As New List(Of udtExpense)

        Public Sub New()
        End Sub

    End Class

#Region "Properties"

    Public Property Diario As udtDiario
    Public Property NomeFileDiario As String

#End Region

#Region "Costructors"
    Public Sub New()

    End Sub
    Public Sub New(ByVal FileName As String)
        Diario = New udtDiario
        ser = New Serialization(FileName, Diario)
    End Sub

#End Region

#Region "Methods"



    Public Sub ReadDataFromFile()
        Diario = ser.Deserialize()
        'If Diario.OreLavoro.Count = 0 Then
        '    Diario.OreLavoro = New List(Of udtOreLavoro)
        '    Dim ol As New udtOreLavoro
        '    ol.Data = Format(Date.Now, "yyyy-MM-dd")
        '    ol.OrderName = "OrderName"
        '    ol.Activity = "Activity"
        '    ol.Sector = "Sector"
        '    ol.WorkingHours = "8:00"
        '    ol.JourneyHours = "2:00"
        '    Diario.OreLavoro.Add(ol)
        'End If
        'If Diario.Spese.Count = 0 Then
        '    Diario.Spese = New List(Of udtExpense)
        '    Dim sp As New udtExpense
        '    sp.Data = Format(Date.Now, "yyyy-MM-dd")
        '    sp.OrderName = "OrderName"
        '    sp.City = "Tortona"
        '    sp.Km = 10
        '    sp.Autostrada = 0
        '    sp.Vitto = 10.5
        '    sp.Alloggio = 0
        '    sp.Varie = 0
        '    sp.CCA = 0
        '    sp.Valuta = 0
        '    Diario.Spese.Add(sp)
        'End If

    End Sub

    Public Sub WriteDataToFile()
        ser.Serialize()
    End Sub

    Public Function OreLavoroMese(dtpDate As Date) As List(Of udtOreLavoro)
        Dim params As New List(Of udtOreLavoro)

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Year, dtpDate.Month)
        Dim EndDate As Date = New Date(dtpDate.Year, dtpDate.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Year, dtpDate.Month, 1)

        For Each ore As udtOreLavoro In Diario.OreLavoro
            If (ore.Data >= BeginDate) And (ore.Data <= EndDate) Then
                Dim OreLav As New ImportData.udtOreLavoro
                OreLav.Data = ore.Data
                OreLav.OrderName = ore.OrderName
                OreLav.Activity = ore.Activity
                OreLav.Sector = ore.Sector
                OreLav.WorkingHours = ore.WorkingHours
                OreLav.JourneyHours = ore.JourneyHours
                params.Add(OreLav)
            End If

        Next

        Return params
    End Function

    Public Function SpeseMese(dtpDate As Date) As List(Of udtExpense)
        Dim params As New List(Of udtExpense)

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Year, dtpDate.Month)
        Dim EndDate As Date = New Date(dtpDate.Year, dtpDate.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Year, dtpDate.Month, 1)

        For Each spese As udtExpense In Diario.Spese
            If (spese.Data >= BeginDate) And (spese.Data <= EndDate) Then
                Dim sp As New ImportData.udtExpense
                sp.Data = spese.Data
                sp.OrderName = spese.OrderName
                sp.City = spese.City
                sp.Km = spese.Km
                sp.Autostrada = spese.Autostrada
                sp.Vitto = spese.Vitto
                sp.Alloggio = spese.Alloggio
                sp.Varie = spese.Varie
                sp.CCA = spese.CCA
                sp.Valuta = spese.Valuta
                sp.TipoRimborso = spese.TipoRimborso
                sp.Motivo = spese.Motivo
                sp.Diaria = spese.Diaria
                params.Add(sp)
            End If
        Next

        Return params
    End Function


    Public Function OreLavoroDaAccess(dtpDate As Date, FileName As String) As List(Of udtOreLavoro)
        Dim params As New List(Of udtOreLavoro)

        ' Dim FileName As String = "C:\OreLavoro\Data\Imports\Boveri.mdb"

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Year, dtpDate.Month)
        Dim EndDate As Date = New Date(dtpDate.Year, dtpDate.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Year, dtpDate.Month, 1)


        Dim accessConnection As New OleDbConnection()
        Dim accessDataSet As DataSet
        Dim accessDataAdapter As OleDbDataAdapter
        Dim accessDataTable As DataTable

        Try

            accessConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + FileName     'se x86
            'accessConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + FileName    'se x64

            accessDataSet = New DataSet()
            accessDataSet.EnforceConstraints = False

            accessConnection.Open()


            'create new instances for select, insert and update
            'and delete commands to be used with the adapter
            Dim accessSelectCommand As New OleDbCommand()

            accessDataAdapter = Nothing
            accessDataAdapter = New OleDbDataAdapter()

            accessSelectCommand.CommandText = "SELECT * FROM OreLavoro"
            accessSelectCommand.Connection = accessConnection
            accessDataAdapter.SelectCommand = accessSelectCommand

            accessDataAdapter.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "OreLavoro")})
            accessDataAdapter.FillSchema(accessDataSet, SchemaType.Source, "OreLavoro")

            accessDataAdapter.Fill(accessDataSet)

            accessDataTable = accessDataSet.Tables("OreLavoro")

            For iRow As Integer = 0 To accessDataTable.Rows.Count - 1
                Dim d As Date = CDate(accessDataTable.Rows(iRow)(4))
                If (d >= BeginDate) And (d <= EndDate) Then
                    Dim OreLav As New ImportData.udtOreLavoro
                    OreLav.Data = CDate(accessDataTable.Rows(iRow)(4))
                    OreLav.OrderName = CStr(accessDataTable.Rows(iRow)(0))
                    OreLav.Activity = CStr(accessDataTable.Rows(iRow)(3))
                    OreLav.Sector = CStr(accessDataTable.Rows(iRow)(2))
                    OreLav.WorkingHours = CStr(accessDataTable.Rows(iRow)(5))
                    OreLav.JourneyHours = CStr(accessDataTable.Rows(iRow)(6))
                    params.Add(OreLav)
                End If

            Next

        Catch ex As Exception

        Finally
            accessConnection.Close()

        End Try

        Return params

    End Function
    Public Function SpeseDaAccess(dtpDate As Date, FileName As String) As List(Of udtExpense)
        Dim params As New List(Of udtExpense)

        ' Dim FileName As String = "C:\OreLavoro\Data\Imports\Boveri.mdb"

        Dim DaysInMonth As Integer = Date.DaysInMonth(dtpDate.Year, dtpDate.Month)
        Dim EndDate As Date = New Date(dtpDate.Year, dtpDate.Month, DaysInMonth)
        Dim BeginDate As Date = New Date(dtpDate.Year, dtpDate.Month, 1)


        Dim accessConnection As New OleDbConnection()
        Dim accessDataSet As DataSet
        Dim accessDataAdapter As OleDbDataAdapter
        Dim accessDataTable As DataTable

        Try

            accessConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " + FileName     'se x86
            'accessConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + FileName    'se x64

            accessDataSet = New DataSet()
            accessDataSet.EnforceConstraints = False

            accessConnection.Open()


            'create new instances for select, insert and update
            'and delete commands to be used with the adapter
            Dim accessSelectCommand As New OleDbCommand()

            accessDataAdapter = Nothing
            accessDataAdapter = New OleDbDataAdapter()

            accessSelectCommand.CommandText = "SELECT * FROM SpeseViaggio"
            accessSelectCommand.Connection = accessConnection
            accessDataAdapter.SelectCommand = accessSelectCommand

            accessDataAdapter.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "SpeseViaggio")})
            accessDataAdapter.FillSchema(accessDataSet, SchemaType.Source, "SpeseViaggio")

            accessDataAdapter.Fill(accessDataSet)

            accessDataTable = accessDataSet.Tables("SpeseViaggio")

            For iRow As Integer = 0 To accessDataTable.Rows.Count - 1
                Dim d As Date = CDate(accessDataTable.Rows(iRow)(1))
                If (d >= BeginDate) And (d <= EndDate) Then
                    Dim Spese As New ImportData.udtExpense
                    Spese.Data = CDate(accessDataTable.Rows(iRow)(1))
                    Spese.OrderName = CStr(accessDataTable.Rows(iRow)(2))
                    Spese.City = CStr(accessDataTable.Rows(iRow)(3))
                    Spese.Km = CStr(accessDataTable.Rows(iRow)(4))
                    Spese.Autostrada = CStr(accessDataTable.Rows(iRow)(5))
                    Spese.MezziPubblici = CStr(accessDataTable.Rows(iRow)(6))
                    Spese.Vitto = CStr(accessDataTable.Rows(iRow)(7))
                    Spese.Alloggio = CStr(accessDataTable.Rows(iRow)(8))
                    Spese.Varie = CStr(accessDataTable.Rows(iRow)(9))
                    Spese.Diaria = CStr(accessDataTable.Rows(iRow)(10))
                    Spese.CCA = CStr(accessDataTable.Rows(iRow)(11))
                    Spese.TipoRimborso = CStr(accessDataTable.Rows(iRow)(13))
                    Spese.Motivo = CStr(accessDataTable.Rows(iRow)(14))
                    Spese.Valuta = CStr(accessDataTable.Rows(iRow)(15))
                    params.Add(Spese)
                End If

            Next

        Catch ex As Exception

        Finally
            accessConnection.Close()

        End Try

        Return params

    End Function

#End Region



End Class
