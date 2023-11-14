Imports System.Data.SqlClient
Imports System.IO

Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common
Imports System.Globalization


Public Class DatabaseManagement

    Private sqlCon As Configuration.udtAppConfig.udtSqlConnectionConfig

    Private culture As CultureInfo


    Private Class DataStoreException : Inherits ApplicationException
        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub
    End Class

    Private Class DipendentiTableDefs
        Public Property TableName As String = "Dipendenti"

        Public Property Matricola As String = "Matricola"
        Public Property Nome As String = "Nome"
        Public Property CodiceFiscale As String = "CodiceFiscale"
        Public Property Qualifica As String = "Qualifica"
        Public Property Indirizzo As String = "Indirizzo"
        Public Property Città As String = "Città"
        Public Property Provincia As String = "Provincia"
        Public Property CAP As String = "CAP"
        Public Property Paese As String = "Paese"
        Public Property TelefonoAbitazione As String = "TelefonoAbitazione"
        Public Property Cellulare As String = "Cellulare"
        Public Property DataDiNascita As String = "DataDiNascita"
        Public Property LuogoDiNascita As String = "LuogoDiNascita"
        Public Property DataAssunzione As String = "DataAssunzione"
        Public Property StatoCivile As String = "StatoCivile"
        Public Property NomeConiuge As String = "NomeConiuge"
        Public Property Fotografia As String = "Fotografia"
        Public Property Autovettura As String = "Autovettura"
        Public Property AutoAziendale As String = "AutoAziendale"
        Public Property Targa As String = "Targa"
        Public Property Note As String = "Note"
        Public Property CostoOrario As String = "CostoOrario"
        Public Property DataFineContratto As String = "DataFineContratto"

    End Class

    Private Class UsersTableDefs
        Public Property TableName As String = "Users"

        Public Property Matricola As String = "Matricola"
        Public Property LoginName As String = "LoginName"
        Public Property Password As String = "Password"

    End Class
    Private Class ConfigTableDefs
        Public Property TableName As String = "Configurations"

        Public Property Name As String = "Name"
        Public Property Value As String = "Value"

    End Class
    Private Class RiportiTableDefs
        Public Property TableName As String = "Riporti"

        Public Property Matricola As String = "Matricola"
        Public Property Mese As String = "Mese"
        Public Property Anno As String = "Anno"
        Public Property Riporto As String = "Riporto"
        Public Property OreInBusta As String = "OreInBusta"
        Public Property Contanti As String = "Contanti"
        Public Property CostoOrario As String = "CostoOrario"
        ' Public Property Trasferta As String = "Trasferta"
        Public Property GiorniTrasfertaItalia As String = "GiorniTrasfertaItalia"
        Public Property GiorniTrasfertaEstero As String = "GiorniTrasfertaEstero"
        Public Property GiorniTrasfertaEsteroLungo As String = "GiorniTrasfertaEsteroLungo"
        Public Property CostoTrasfertaItalia As String = "CostoTrasfertaItalia"
        Public Property CostoTrasfertaEstero As String = "CostoTrasfertaEstero"
        Public Property CostoTrasfertaEsteroLungo As String = "CostoTrasfertaEsteroLungo"

    End Class

    Public Class udtConfigurations
        Public Property CostoKm As Single = 0.4
        Public Property DiariaItalia As Single = 46
        Public Property DiariaEstero As Single = 77
        Public Property FestaPatronale As Date = New Date(2018, 5, 11)
        Public Property TrasfertaItalia As Single = 0.4
        Public Property TrasfertaEstero As Single = 0.4
        Public Property TrasfertaEsteroWeekEnd As Single = 0.4

    End Class

    Public Class udtEmployeeData
        Public Property Matricola As Integer = 0
        Public Property Nome As String = ""
        Public Property CodiceFiscale As String = ""
        Public Property Qualifica As String = ""
        Public Property Indirizzo As String = ""
        Public Property Citta As String = ""
        Public Property Provincia As String = ""
        Public Property CAP As String = ""
        Public Property Paese As String = ""
        Public Property TelefonoAbitazione As String = ""
        Public Property Cellulare As String = ""
        Public Property DataDiNascita As String = ""
        Public Property LuogoDiNascita As String = ""
        Public Property DataAssunzione As String = ""
        Public Property StatoCivile As String = ""
        Public Property NomeConiuge As String = ""
        Public Property Autovettura As String = ""
        Public Property AutoAziendale As Boolean = False
        Public Property Targa As String = ""
        Public Property Note As String = ""
        Public Property CostoOrario As Single = 0
        Public Property DataFineContratto As String = ""
    End Class

    Public Class udtRecordOreLavoro
        Public Property UserName As String = ""
        Public Property OrderName As String = ""
        Public Property Activity As String = ""
        Public Property Sector As String = ""
        Public Property Timestamp As Date = Date.Now
        Public Property WorkHours As Single = 0
        Public Property TravelHours As Single = 0
    End Class
    Public Class udtRecordRefound
        Public Property UserName As String = ""
        Public Property OrderName As String = ""
        Public Property City As String = ""
        Public Property Km As String = ""
        Public Property Timestamp As Date = Date.Now
        Public Property Autostrada As Single = 0
        Public Property MezziPubblici As Single = 0
        Public Property Vitto As Single = 0
        Public Property Alloggio As Single = 0
        Public Property Varie As Single = 0
        Public Property Diaria As Single = 0
        Public Property CartaCredito As Single = 0
        Public Property Valuta As Single = 0
        Public Property TipoRimborso As String = ""
        Public Property Motivo As String = ""
        Public Property CostoKm As Single = 0
    End Class

    Public Class udtFilterOreLavoro
        Public Property EmployeeName As String = "%"
        Public Property OrderName As String = "%"
        Public Property Activity As String = "%"
        Public Property Sector As String = "%"
        Public Property BeginDate As Date = Date.Now
        Public Property EndDate As Date = Date.Now
        Public Overloads Function DeepCopy() As udtFilterOreLavoro
            Dim other As udtFilterOreLavoro = DirectCast(Me.MemberwiseClone(), udtFilterOreLavoro)
            Return other
        End Function
    End Class
    Public Class udtFilterRefound
        Public Property EmployeeName As String = "%"
        Public Property OrderName As String = "%"
        Public Property BeginDate As Date = Date.Now
        Public Property EndDate As Date = Date.Now
        Public Overloads Function DeepCopy() As udtFilterRefound
            Dim other As udtFilterRefound = DirectCast(Me.MemberwiseClone(), udtFilterRefound)
            Return other
        End Function
    End Class

    Public Class udtRecordOrder
        Public Property OrderName As String = ""
        Public Property Customer As String = ""
        Public Property Ended As Boolean = False
    End Class

    Public Class udtRiporti
        Public Property OreInBusta As String = "0"
        'Public Property TrasfertaInBusta As Single = 0
        Public Property Contanti As Single = 0
        Public Property Riporto As Single = 0
        Public Property CostoOrario As Single = 0
        Public Property GiorniTrasfertaItalia As Integer = 0
        Public Property CostoTrasfertaItalia As Single = 0
        Public Property GiorniTrasfertaEstero As Integer = 0
        Public Property CostoTrasfertaEstero As Single = 0
        Public Property GiorniTrasfertaEsteroLungo As Integer = 0
        Public Property CostoTrasfertaEsteroLungo As Single = 0

    End Class


    Public Sub New()

        sqlCon = xConfig.GetSqlConnection(cLocalSqlServer)

        Try
            CreateTablesInDatabase()
            CreateStoredProcedeures()
        Catch ex As Exception

        End Try

    End Sub

    Public Function CreateDatabaseStructure() As Boolean
        Dim cmdSql As New SqlCommand()

        'Delete all tables
        Try
            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()
                Dim TableList As New DataTable
                TableList = dbConnection.GetSchema(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Tables)

                Dim TableNames As New List(Of String)
                For Each row As DataRow In TableList.Rows
                    For Each col As DataColumn In TableList.Columns
                        If col.ColumnName = "TABLE_NAME" Then
                            TableNames.Add(row(col).ToString)
                        End If
                    Next
                Next

                For Each Str As String In TableNames
                    cmdSql.Connection = dbConnection
                    cmdSql.CommandText = "DROP TABLE " & Str
                    cmdSql.ExecuteNonQuery()
                Next

            End Using

        Catch ex As Exception
            Return False
        End Try

        CreateTablesInDatabase()
        CreateStoredProcedeures()
        Return True
    End Function



#Region "Configurazione"
    Public Function GetConfigurations() As udtConfigurations

        Dim cfg As New udtConfigurations

        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetConfigurations"
                cmd.CommandType = CommandType.StoredProcedure

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                Dim year As Integer = Date.Now.Year
                Dim Month As Integer = Date.Now.Month
                Dim Day As Integer = Date.Now.Day
                For Each row As DataRow In dsTab.Rows
                    If row("Name") = "CostoKm" Then
                        cfg.CostoKm = TextToSingle(row("Value"))
                    End If
                    If row("Name") = "DiariaItalia" Then
                        cfg.DiariaItalia = TextToSingle(row("Value"))
                    End If
                    If row("Name") = "DiariaEstero" Then
                        cfg.DiariaEstero = TextToSingle(row("Value"))
                    End If
                    If row("Name") = "TrasfertaItalia" Then
                        cfg.TrasfertaItalia = TextToSingle(row("Value"))
                    End If
                    If row("Name") = "TrasfertaEstero" Then
                        cfg.TrasfertaEstero = TextToSingle(row("Value"))
                    End If
                    If row("Name") = "TrasfertaEsteroWeekEnd" Then
                        cfg.TrasfertaEsteroWeekEnd = TextToSingle(row("Value"))
                    End If
                    If row("Name") = "FestaPatronaleMese" Then
                        Month = TextToInt(row("Value"))
                    End If
                    If row("Name") = "FestaPatronaleGiorno" Then
                        Day = TextToInt(row("Value"))
                    End If
                Next

                cfg.FestaPatronale = New Date(year, Month, Day)


                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

        Return cfg

    End Function
    Public Sub WriteConfigurations(cfg As udtConfigurations)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                AddConfigurationRow(dbConnection, "CostoKm", cfg.CostoKm)
                AddConfigurationRow(dbConnection, "DiariaItalia", cfg.DiariaItalia)
                AddConfigurationRow(dbConnection, "DiariaEstero", cfg.DiariaEstero)
                AddConfigurationRow(dbConnection, "TrasfertaItalia", cfg.TrasfertaItalia)
                AddConfigurationRow(dbConnection, "TrasfertaEstero", cfg.TrasfertaEstero)
                AddConfigurationRow(dbConnection, "TrasfertaEsteroWeekEnd", cfg.TrasfertaEsteroWeekEnd)
                AddConfigurationRow(dbConnection, "FestaPatronaleMese", cfg.FestaPatronale.Month)
                AddConfigurationRow(dbConnection, "FestaPatronaleGiorno", cfg.FestaPatronale.Day)

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub AddConfigurationRow(dbConnection As SqlConnection, ParamName As String, Value As Single)


        Try
            Dim cmd As New SqlCommand
            cmd.Connection = dbConnection
            cmd.CommandText = "AddConfigurationParam"
            cmd.CommandType = CommandType.StoredProcedure

            cmd.Parameters.AddWithValue("@Name", ParamName)
            cmd.Parameters.AddWithValue("@Value", Value)

            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try


    End Sub

    Public Function RimborsoKm(EmployeeName As String) As Single

        Dim CostKm As Single = 0
        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                Dim sqlq As String = "SELECT [cizeta].[dbo].[fnCostoKm] "
                sqlq += "('" & EmployeeName & "'"
                sqlq += ") AS Result"
                cmd.CommandText = sqlq
                cmd.CommandType = CommandType.Text

                Dim r As SqlDataReader = cmd.ExecuteReader()
                If r.HasRows Then
                    While r.Read()
                        CostKm = r("Result")
                    End While
                End If

            End Using

        Catch ex As Exception

        End Try

        Return CostKm


    End Function

    Public Function EmployeeData(EmployeeName As String) As udtEmployeeData
        Dim cfg As New udtEmployeeData


        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sqlq As String = "SELECT * FROM [cizeta].[dbo].[Dipendenti] WHERE [Nome] ='" & EmployeeName & "'"
                daTab = New SqlDataAdapter(sqlq, dbConnection)
                Dim commandBuilder As New SqlCommandBuilder(daTab)
                dsTab.Locale = System.Globalization.CultureInfo.InvariantCulture
                daTab.Fill(dsTab)

                For Each row As DataRow In dsTab.Rows
                    cfg = EmployeeData(row)
                Next

            End Using

        Catch ex As Exception

        End Try

        Return cfg

    End Function


    Public Function ReadEmployeesConfig() As DataTable
        Dim tabDef As New DipendentiTableDefs

        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sqlq As String = "SELECT " & tabDef.Nome
                sqlq = sqlq & " , " & tabDef.Matricola
                sqlq = sqlq & " , " & tabDef.CodiceFiscale
                sqlq = sqlq & " , " & tabDef.Qualifica
                sqlq = sqlq & " , " & tabDef.DataAssunzione
                sqlq = sqlq & " , " & tabDef.DataFineContratto
                sqlq = sqlq & " , " & tabDef.CostoOrario
                sqlq = sqlq & " , " & tabDef.Cellulare
                sqlq = sqlq & " , " & tabDef.Indirizzo
                sqlq = sqlq & " , " & tabDef.Città
                sqlq = sqlq & " , " & tabDef.Provincia
                sqlq = sqlq & " , " & tabDef.CAP
                sqlq = sqlq & " , " & tabDef.Paese
                sqlq = sqlq & " , " & tabDef.TelefonoAbitazione
                sqlq = sqlq & " , " & tabDef.DataDiNascita
                sqlq = sqlq & " , " & tabDef.LuogoDiNascita
                sqlq = sqlq & " , " & tabDef.StatoCivile
                sqlq = sqlq & " , " & tabDef.NomeConiuge
                sqlq = sqlq & " , " & tabDef.Autovettura
                sqlq = sqlq & " , " & tabDef.AutoAziendale
                sqlq = sqlq & " , " & tabDef.Targa
                sqlq = sqlq & " FROM [cizeta].[dbo].[" & tabDef.TableName & "] ORDER BY Matricola"
                daTab = New SqlDataAdapter(sqlq, dbConnection)
                Dim commandBuilder As New SqlCommandBuilder(daTab)
                dsTab.Locale = System.Globalization.CultureInfo.InvariantCulture
                daTab.Fill(dsTab)

            End Using

        Catch ex As Exception

        End Try

        Return dsTab

    End Function

    Public Sub WriteEmployeesConfig(dsTab As DataTable)

        Dim tabDef As New DipendentiTableDefs

        Dim daTab As New SqlDataAdapter, ds As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                For Each row As DataRow In dsTab.Rows
                    Dim cfg As New udtEmployeeData
                    cfg = EmployeeData(row)

                    Dim sqlq As String = "SELECT * FROM [cizeta].[dbo].[" & tabDef.TableName & "] WHERE [" & tabDef.Nome & "] = '" & cfg.Nome & "'"
                    daTab = New SqlDataAdapter(sqlq, dbConnection)
                    Dim commandBuilder As New SqlCommandBuilder(daTab)
                    ds.Locale = System.Globalization.CultureInfo.InvariantCulture
                    daTab.Fill(ds)
                    If ds.Rows.Count > 0 Then
                        'Update
                        sqlq = "UPDATE [cizeta].[dbo].[" & tabDef.TableName & "]"
                        sqlq = sqlq & " SET " & tabDef.Matricola & " = '" & cfg.Matricola & "'"
                        sqlq = sqlq & " , " & tabDef.CodiceFiscale & " = '" & cfg.CodiceFiscale & "'"
                        sqlq = sqlq & " , " & tabDef.Qualifica & " = '" & cfg.Qualifica & "'"
                        sqlq = sqlq & " , " & tabDef.Indirizzo & " = '" & cfg.Indirizzo & "'"
                        sqlq = sqlq & " , " & tabDef.Città & " = '" & cfg.Citta & "'"
                        sqlq = sqlq & " , " & tabDef.Provincia & " = '" & cfg.Provincia & "'"
                        sqlq = sqlq & " , " & tabDef.CAP & " = '" & cfg.CAP & "'"
                        sqlq = sqlq & " , " & tabDef.Paese & " = '" & cfg.Paese & "'"
                        sqlq = sqlq & " , " & tabDef.TelefonoAbitazione & " = '" & cfg.TelefonoAbitazione & "'"
                        sqlq = sqlq & " , " & tabDef.Cellulare & " = '" & cfg.Cellulare & "'"
                        sqlq = sqlq & " , " & tabDef.DataDiNascita & " = '" & cfg.DataDiNascita & "'"
                        sqlq = sqlq & " , " & tabDef.LuogoDiNascita & " = '" & cfg.LuogoDiNascita & "'"
                        sqlq = sqlq & " , " & tabDef.DataAssunzione & " = '" & cfg.DataAssunzione & "'"
                        sqlq = sqlq & " , " & tabDef.StatoCivile & " = '" & cfg.StatoCivile & "'"
                        sqlq = sqlq & " , " & tabDef.NomeConiuge & " = '" & cfg.NomeConiuge & "'"
                        sqlq = sqlq & " , " & tabDef.Autovettura & " = '" & cfg.Autovettura & "'"
                        '      sqlq = sqlq & " , " & tabDef.AutoAziendale & " = '" & IIf(cfg.AutoAziendale, "SI", "NO") & "'"
                        sqlq = sqlq & " , " & tabDef.AutoAziendale & " = '" & cfg.AutoAziendale & "'"
                        sqlq = sqlq & " , " & tabDef.Targa & " = '" & cfg.Targa & "'"
                        sqlq = sqlq & " , " & tabDef.CostoOrario & " = '" & cfg.CostoOrario & "'"
                        sqlq = sqlq & " , " & tabDef.DataFineContratto & " = '" & cfg.DataFineContratto & "'"
                        sqlq = sqlq & " WHERE " & tabDef.Nome & " = '" & cfg.Nome & "'"
                        Dim cmd As New SqlCommand(sqlq, dbConnection)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Else
                        'Insert
                        sqlq = "INSERT INTO [cizeta].[dbo].[" & tabDef.TableName & "]"
                        sqlq = sqlq & "(" & tabDef.Matricola & "," & tabDef.Nome & "," & tabDef.CodiceFiscale & "," & tabDef.Qualifica
                        sqlq = sqlq & "," & tabDef.Indirizzo & "," & tabDef.Città & "," & tabDef.Provincia & "," & tabDef.CAP & "," & tabDef.Paese
                        sqlq = sqlq & "," & tabDef.TelefonoAbitazione & "," & tabDef.Cellulare
                        sqlq = sqlq & "," & tabDef.DataDiNascita & "," & tabDef.LuogoDiNascita & "," & tabDef.DataAssunzione
                        sqlq = sqlq & "," & tabDef.StatoCivile & "," & tabDef.NomeConiuge
                        sqlq = sqlq & "," & tabDef.Autovettura & "," & tabDef.AutoAziendale & "," & tabDef.Targa
                        sqlq = sqlq & "," & tabDef.CostoOrario & "," & tabDef.DataFineContratto
                        sqlq = sqlq & " VALUES "
                        sqlq = sqlq & "(" & cfg.Matricola & "," & cfg.Nome & "," & cfg.CodiceFiscale & "," & cfg.Qualifica
                        sqlq = sqlq & "," & cfg.Indirizzo & "," & cfg.Citta & "," & cfg.Provincia & "," & cfg.CAP & "," & cfg.Paese
                        sqlq = sqlq & "," & cfg.DataDiNascita & "," & cfg.LuogoDiNascita & "," & cfg.DataAssunzione
                        sqlq = sqlq & "," & cfg.StatoCivile & "," & cfg.NomeConiuge
                        sqlq = sqlq & "," & cfg.Autovettura & "," & cfg.AutoAziendale & "," & cfg.Targa
                        sqlq = sqlq & "," & cfg.CostoOrario & "," & cfg.DataFineContratto
                        sqlq = sqlq & ")"
                    End If
                Next

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Function EmployeeData(row As DataRow) As udtEmployeeData
        Dim cfg As New udtEmployeeData

        cfg.Matricola = TextToInt(row("Matricola").ToString)
        cfg.Nome = DatabaseToString(row("Nome"))
        cfg.CodiceFiscale = row("CodiceFiscale").ToString
        cfg.Qualifica = row("Qualifica").ToString
        cfg.Indirizzo = row("Indirizzo").ToString
        cfg.Citta = row("Città").ToString
        cfg.Provincia = row("Provincia").ToString
        cfg.CAP = row("CAP").ToString
        cfg.Paese = row("Paese").ToString
        cfg.TelefonoAbitazione = row("TelefonoAbitazione").ToString
        cfg.Cellulare = row("Cellulare").ToString
        cfg.DataDiNascita = row("DataDiNascita").ToString
        cfg.LuogoDiNascita = row("LuogoDiNascita").ToString
        cfg.DataAssunzione = row("DataAssunzione").ToString
        cfg.StatoCivile = row("StatoCivile").ToString
        cfg.NomeConiuge = row("NomeConiuge").ToString
        cfg.Autovettura = row("Autovettura").ToString
        '    cfg.AutoAziendale = IIf((row("AutoAziendale") = "SI") Or (row("AutoAziendale").trim = "1"), True, False)
        cfg.AutoAziendale = row("AutoAziendale")
        cfg.Targa = row("Targa").ToString
        'cfg.Note = row("Note").ToString
        cfg.CostoOrario = TextToSingle(row("CostoOrario"))
        If IsDBNull(row("DataFineContratto")) Then
            cfg.DataFineContratto = "1/1/2100"
        Else
            cfg.DataFineContratto = row("DataFineContratto").ToString
        End If


        Return cfg

    End Function

    Public Function GetEmpolyeeList() As List(Of String)
        Dim EmpolyeeList As New List(Of String)

        Dim tabDef As New DipendentiTableDefs

        Dim dtData As DataTable = ReadEmployeesConfig()
        EmpolyeeList.Clear()

        Dim ToAdd As Boolean = False
        Dim strs As New List(Of String)
        For iRow As Integer = 0 To dtData.Rows.Count - 1
            ToAdd = False
            Try
                Dim DataAssunzione As Date '= dtData.Rows(iRow).Item(tabDef.DataAssunzione)
                If IsDBNull(dtData.Rows(iRow).Item(tabDef.DataAssunzione)) Then
                    DataAssunzione = CDate("1980-01-01")
                Else
                    DataAssunzione = dtData.Rows(iRow).Item(tabDef.DataAssunzione)
                End If

                Dim DataFineContratto As Date
                If IsDBNull(dtData.Rows(iRow).Item(tabDef.DataFineContratto)) Then
                    DataFineContratto = CDate("2100-01-01")
                    ToAdd = True
                Else
                    DataFineContratto = dtData.Rows(iRow).Item(tabDef.DataFineContratto)
                End If

                If DateDiff(DateInterval.Day, Date.Now, DataFineContratto) > 3 Then
                    ToAdd = True
                Else

                End If
                If ToAdd Then
                    strs.Add(dtData.Rows(iRow).Item(tabDef.Nome).ToString)
                End If
            Catch ex As Exception

            End Try

        Next
        strs.Sort()
        For Each str As String In strs
            EmpolyeeList.Add(str)
        Next

        Return EmpolyeeList

    End Function


#End Region

#Region "Orders"
    Public Function GetOrderList(Filter As String) As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetOrdersList"
                cmd.CommandType = CommandType.StoredProcedure

                Dim sqlParamPiecesName As New SqlParameter
                sqlParamPiecesName = cmd.Parameters.Add("@Filter", SqlDbType.NVarChar)
                sqlParamPiecesName.Value = Filter

                strs.Clear()
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Commessa"))
                Next

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function
    Public Function GetOrders(Filter As String) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetOrders"
                cmd.CommandType = CommandType.StoredProcedure

                Dim sqlParamPiecesName As New SqlParameter
                sqlParamPiecesName = cmd.Parameters.Add("@Filter", SqlDbType.NVarChar)
                sqlParamPiecesName.Value = Filter

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()
            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function
    Public Function OrderExists(OrderName As String) As Boolean
        Dim bRes As Boolean = False
        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                Dim sqlq As String = "Select [dbo].[fnOrderExists] "
                sqlq += "('" & OrderName & "'"
                sqlq += ") AS Result"
                cmd.CommandText = sqlq
                cmd.CommandType = CommandType.Text

                Dim r As SqlDataReader = cmd.ExecuteReader()
                If r.HasRows Then
                    While r.Read()
                        bRes = CBool(r("Result"))
                    End While
                End If

            End Using

        Catch ex As Exception

        End Try

        Return bRes
    End Function
    Public Sub AddOrder(rec As udtRecordOrder)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "AddOrder"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@Customer", rec.Customer)
                'cmd.Parameters.AddWithValue("@Ended", rec.Ended)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Public Sub UpdateOrder(rec As udtRecordOrder)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "UpdateOrder"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@Customer", rec.Customer)
                cmd.Parameters.AddWithValue("@Ended", rec.Ended)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub

    Public Sub ModifyOrderName(rec As udtRecordOrder, NewName As String)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "ModifyOrderName"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@NewOrderName", NewName)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub
    Public Sub DeleteOrder(OrderName As String)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "DeleteOrder"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@OrderName", OrderName)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub
#End Region


#Region "Activities"

    Public Function GetActivityTable() As DataTable
        Dim sDs As New DataSet
        Dim sTable As New DataTable


        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sql As String = "SELECT * FROM [cizeta].[dbo].[Attività] ORDER BY Attività"
                Dim sCommand = New SqlCommand(sql, dbConnection)
                Dim sAdapter = New SqlDataAdapter(sCommand)
                sAdapter.Fill(sDs, "Attività")
                sTable = sDs.Tables("Attività")

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

        Return sTable

    End Function

    Public Sub UpdateActivityTable(Activities As List(Of String))
        Dim sDs As New DataSet


        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sqlq = "DELETE FROM [cizeta].[dbo].[Attività] "
                Dim cmd As New SqlCommand(sqlq, dbConnection)
                Dim rowsAffected = cmd.ExecuteNonQuery()

                For Each item As String In Activities
                    sqlq = "INSERT INTO [cizeta].[dbo].[Attività] "
                    sqlq += " (Attività)"
                    sqlq += " VALUES ('" & item & "')"
                    cmd = New SqlCommand(sqlq, dbConnection)
                    rowsAffected = cmd.ExecuteNonQuery()
                Next

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try


    End Sub

    Public Function GetActivityList() As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetActivityList"
                cmd.CommandType = CommandType.StoredProcedure

                strs.Clear()
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Attività"))
                Next

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function
#End Region


#Region "Sectors"

    Public Function GetSectiorsTable() As DataTable
        Dim sDs As New DataSet
        Dim sTable As New DataTable

        Try
            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sql As String = "SELECT * FROM [cizeta].[dbo].[Settori] ORDER BY Settore"
                Dim sCommand = New SqlCommand(sql, dbConnection)
                Dim sAdapter = New SqlDataAdapter(sCommand)
                sAdapter.Fill(sDs, "Settori")
                sTable = sDs.Tables("Settori")

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

        Return sTable

    End Function

    Public Sub UpdateSectorsTable(Sectors As List(Of String))
        Dim sDs As New DataSet

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sqlq = "DELETE FROM [cizeta].[dbo].[Settori] "
                Dim cmd As New SqlCommand(sqlq, dbConnection)
                Dim rowsAffected = cmd.ExecuteNonQuery()

                For Each item As String In Sectors
                    sqlq = "INSERT INTO [cizeta].[dbo].[Settori] "
                    sqlq += " (Settore)"
                    sqlq += " VALUES ('" & item & "')"
                    cmd = New SqlCommand(sqlq, dbConnection)
                    rowsAffected = cmd.ExecuteNonQuery()
                Next

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try


    End Sub

    Public Function GetSectorList() As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetSectorList"
                cmd.CommandType = CommandType.StoredProcedure

                strs.Clear()
                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Settore"))
                Next

                dbConnection.Close()
            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function
#End Region




#Region "OreLavoro"
    Public Function GetWorkedHoursMonthly(filter As udtFilterOreLavoro) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetWorkedHoursMonthly"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@Activity", filter.Activity)
                cmd.Parameters.AddWithValue("@Sector", filter.Sector)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function
    Public Function GetWorkedHours(filter As udtFilterOreLavoro) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetWorkedHours"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@Activity", filter.Activity)
                cmd.Parameters.AddWithValue("@Sector", filter.Sector)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function

    Public Function GetWorkedHoursByUser(filter As udtFilterOreLavoro) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetWorkedHoursByUser"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@Activity", filter.Activity)
                cmd.Parameters.AddWithValue("@Sector", filter.Sector)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function
    Public Function RecordOreLavoroExists(rec As udtRecordOreLavoro) As Boolean
        Dim bRes As Boolean = False
        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                Dim sqlq As String = "SELECT [dbo].[fnOreLavoroExists] "
                sqlq += "('" & rec.UserName & "'"
                sqlq += ",'" & rec.OrderName & "'"
                sqlq += ",'" & rec.Activity & "'"
                sqlq += ",'" & rec.Sector & "'"
                sqlq += ",'" & DateIso(rec.Timestamp) & "'"
                sqlq += ") AS Result"
                cmd.CommandText = sqlq
                cmd.CommandType = CommandType.Text

                Dim r As SqlDataReader = cmd.ExecuteReader()
                If r.HasRows Then
                    While r.Read()
                        bRes = CBool(r("Result"))
                    End While
                End If

            End Using

        Catch ex As Exception

        End Try

        Return bRes
    End Function
    Public Sub AddOreLavoro(rec As udtRecordOreLavoro)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "AddOreLavoro"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", rec.UserName)
                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@Activity", rec.Activity)
                cmd.Parameters.AddWithValue("@Sector", rec.Sector)
                cmd.Parameters.AddWithValue("@DateIso", DateIso(rec.Timestamp))
                cmd.Parameters.AddWithValue("@OreLavoro", OreIso(rec.WorkHours))
                cmd.Parameters.AddWithValue("@OreViaggio", OreIso(rec.TravelHours))

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub
    Public Sub UpdateOreLavoro(rec As udtRecordOreLavoro)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "UpdateOreLavoro"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", rec.UserName)
                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@Activity", rec.Activity)
                cmd.Parameters.AddWithValue("@Sector", rec.Sector)
                cmd.Parameters.AddWithValue("@DateIso", DateIso(rec.Timestamp))
                cmd.Parameters.AddWithValue("@OreLavoro", OreIso(rec.WorkHours))
                cmd.Parameters.AddWithValue("@OreViaggio", OreIso(rec.TravelHours))

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub
    Public Sub DeleteOreLavoro(rec As udtRecordOreLavoro)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "DeleteOreLavoro"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", rec.UserName)
                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@Activity", rec.Activity)
                cmd.Parameters.AddWithValue("@Sector", rec.Sector)
                cmd.Parameters.AddWithValue("@DateIso", DateIso(rec.Timestamp))

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub

    Public Function GetOrdersDoneByUser(filter As udtFilterOreLavoro) As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetOrdersDoneByUser"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@EmployeeName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@Activity", filter.Activity)
                cmd.Parameters.AddWithValue("@Sector", filter.Sector)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Commessa"))
                Next

            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function

    Public Function GetUsersListWhoMakeOrder(filter As udtFilterOreLavoro) As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetUsersWhoMakeOrder"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@Activity", filter.Activity)
                cmd.Parameters.AddWithValue("@Sector", filter.Sector)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Nome"))
                Next

            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function

    Public Function GetWorkInProgressOrders(filter As udtFilterOreLavoro) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetWorkInProgressOrders"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@EmployeeName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@Activity", filter.Activity)
                cmd.Parameters.AddWithValue("@Sector", filter.Sector)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try

        Return dsTab

    End Function

#End Region

#Region "Refound"
    Public Function GetUserRefound(filter As udtFilterRefound) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetUserRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function

    Public Function GetOrdersDoneByUserWithRefound(filter As udtFilterRefound) As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetOrdersDoneByUserWithRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Commessa"))
                Next

            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function

    Public Function GetUsersListWhoMakeOrderWithRefound(filter As udtFilterRefound) As List(Of String)
        Dim strs As New List(Of String)
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetUsersWhoMakeOrderWithRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

                strs.Clear()
                For Each row As DataRow In dsTab.Rows
                    strs.Add(row("Nome"))
                Next

            End Using

        Catch ex As Exception

        End Try

        Return strs

    End Function

    Public Function GetUserAnalysisRefound(filter As udtFilterRefound) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetUserAnalysisRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function

    Public Function GetUserAnalysisRefoundByName(filter As udtFilterRefound) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetUserAnalysisRefoundByName"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function

    Public Function GetUserAnalysisRefoundByOrders(filter As udtFilterRefound) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "GetUserAnalysisRefoundByOrders"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function
    Public Function RecordRefoundExists(rec As udtRecordRefound) As Boolean
        Dim bRes As Boolean = False
        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                Dim sqlq As String = "SELECT [dbo].[fnRefoundExists] "
                sqlq += "('" & rec.UserName & "'"
                sqlq += ",'" & rec.OrderName & "'"
                'sqlq += ",'" & rec.City & "'"
                sqlq += ",'" & DateIso(rec.Timestamp) & "'"
                sqlq += ") AS Result"
                cmd.CommandText = sqlq
                cmd.CommandType = CommandType.Text

                Dim r As SqlDataReader = cmd.ExecuteReader()
                If r.HasRows Then
                    While r.Read()
                        bRes = CBool(r("Result"))
                    End While
                End If

            End Using

        Catch ex As Exception

        End Try

        Return bRes
    End Function
    Public Sub AddRefound(rec As udtRecordRefound)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "AddRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", rec.UserName)
                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@City", rec.City)
                cmd.Parameters.AddWithValue("@DateIso", DateIso(rec.Timestamp))
                cmd.Parameters.AddWithValue("@Km", rec.Km)
                cmd.Parameters.AddWithValue("@Autostrada", rec.Autostrada)
                cmd.Parameters.AddWithValue("@MezziPub", rec.MezziPubblici)
                cmd.Parameters.AddWithValue("@Vitto", rec.Vitto)
                cmd.Parameters.AddWithValue("@Alloggio", rec.Alloggio)
                cmd.Parameters.AddWithValue("@Varie", rec.Varie)
                cmd.Parameters.AddWithValue("@Diaria", rec.Diaria)
                cmd.Parameters.AddWithValue("@CCA", rec.CartaCredito)
                cmd.Parameters.AddWithValue("@Valuta", rec.Valuta)
                cmd.Parameters.AddWithValue("@TipoRimborso", rec.TipoRimborso)
                cmd.Parameters.AddWithValue("@Motivo", rec.Motivo)
                cmd.Parameters.AddWithValue("@CostoKm", rec.CostoKm)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub
    Public Sub UpdateRefound(rec As udtRecordRefound)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "UpdateRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", rec.UserName)
                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@City", rec.City)
                cmd.Parameters.AddWithValue("@DateIso", DateIso(rec.Timestamp))
                cmd.Parameters.AddWithValue("@Km", rec.Km)
                cmd.Parameters.AddWithValue("@Autostrada", rec.Autostrada)
                cmd.Parameters.AddWithValue("@MezziPub", rec.MezziPubblici)
                cmd.Parameters.AddWithValue("@Vitto", rec.Vitto)
                cmd.Parameters.AddWithValue("@Alloggio", rec.Alloggio)
                cmd.Parameters.AddWithValue("@Varie", rec.Varie)
                cmd.Parameters.AddWithValue("@Diaria", rec.Diaria)
                cmd.Parameters.AddWithValue("@CCA", rec.CartaCredito)
                cmd.Parameters.AddWithValue("@Valuta", rec.Valuta)
                cmd.Parameters.AddWithValue("@TipoRimborso", rec.TipoRimborso)
                cmd.Parameters.AddWithValue("@Motivo", rec.Motivo)
                cmd.Parameters.AddWithValue("@CostoKm", rec.CostoKm)

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub
    Public Sub DeleteRefound(rec As udtRecordRefound)

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "DeleteRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", rec.UserName)
                cmd.Parameters.AddWithValue("@OrderName", rec.OrderName)
                cmd.Parameters.AddWithValue("@City", rec.City)
                cmd.Parameters.AddWithValue("@DateIso", DateIso(rec.Timestamp))

                cmd.ExecuteNonQuery()

            End Using

        Catch ex As Exception

        End Try


    End Sub


    Public Function GetRiporti(EmployeeName As String, Data As Date) As udtRiporti
        Dim rip As New udtRiporti

        Dim defRip As New RiportiTableDefs

        Dim cfg As New DatabaseManagement.udtEmployeeData
        cfg = xDatabase.EmployeeData(EmployeeName)

        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                'Riporto dal mese precedente
                Dim d As Date = DateAdd("M", -1, Data)
                Dim sqlq As String = "SELECT * FROM [cizeta].[dbo].[Riporti] WHERE [Matricola] ='" & cfg.Matricola & "'"
                sqlq = sqlq & " AND Mese = " & d.Month & " AND Anno = " & d.Year
                daTab = New SqlDataAdapter(sqlq, dbConnection)
                Dim commandBuilder As New SqlCommandBuilder(daTab)
                dsTab.Locale = System.Globalization.CultureInfo.InvariantCulture
                daTab.Fill(dsTab)

                For Each row As DataRow In dsTab.Rows
                    rip.Riporto = TextToSingle(row("Riporto").ToString)
                    'rip.TrasfertaInBusta = row("Trasferta").ToString
                    'rip.OreInBusta = row("OreInBusta").ToString
                    'rip.Contanti = TextToSingle(row("Contanti").ToString)
                Next

                'Altri dati dal mese attuale
                sqlq = "SELECT * FROM [cizeta].[dbo].[Riporti] WHERE [Matricola] ='" & cfg.Matricola & "'"
                sqlq = sqlq & " AND Mese = " & Data.Month & " AND Anno = " & Data.Year
                daTab = New SqlDataAdapter(sqlq, dbConnection)
                commandBuilder = New SqlCommandBuilder(daTab)
                dsTab.Locale = System.Globalization.CultureInfo.InvariantCulture
                daTab.Fill(dsTab)

                For Each row As DataRow In dsTab.Rows
                    'rip.Riporto = TextToSingle(row("Riporto").ToString)
                    rip.OreInBusta = row(defRip.OreInBusta).ToString
                    rip.Contanti = TextToSingle(row(defRip.Contanti).ToString)
                    rip.CostoOrario = TextToSingle(row(defRip.CostoOrario).ToString)
                    rip.GiorniTrasfertaItalia = TextToInt(row(defRip.GiorniTrasfertaItalia).ToString)
                    rip.CostoTrasfertaItalia = TextToSingle(row(defRip.CostoTrasfertaItalia).ToString)
                    rip.GiorniTrasfertaEstero = TextToInt(row(defRip.GiorniTrasfertaEstero).ToString)
                    rip.CostoTrasfertaEstero = TextToSingle(row(defRip.CostoTrasfertaEstero).ToString)
                    rip.GiorniTrasfertaEsteroLungo = TextToInt(row(defRip.GiorniTrasfertaEsteroLungo).ToString)
                    rip.CostoTrasfertaEsteroLungo = TextToSingle(row(defRip.CostoTrasfertaEsteroLungo).ToString)
                Next


            End Using

        Catch ex As Exception

        End Try

        Return rip

    End Function

    Public Function UpdateRiporti(EmployeeName As String, Data As Date, rip As udtRiporti) As Boolean

        Dim rowsAffected As Integer = 0

        Dim cfg As New DatabaseManagement.udtEmployeeData
        cfg = xDatabase.EmployeeData(EmployeeName)

        Dim defRip As New RiportiTableDefs

        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim sqlq As String = "SELECT * FROM [cizeta].[dbo].[Riporti] WHERE [Matricola] ='" & cfg.Matricola & "'"
                sqlq = sqlq & " AND Mese = " & Data.Month & " AND Anno = " & Data.Year
                daTab = New SqlDataAdapter(sqlq, dbConnection)
                Dim commandBuilder As New SqlCommandBuilder(daTab)
                dsTab.Locale = System.Globalization.CultureInfo.InvariantCulture
                daTab.Fill(dsTab)

                Dim sRiporto As String = rip.Riporto.ToString.Replace(",", ".")
                Dim sContanti As String = rip.Contanti.ToString.Replace(",", ".")
                'Dim sTrasferta As String = rip.TrasfertaInBusta.ToString.Replace(",", ".")
                Dim sCostoOrario As String = rip.CostoOrario.ToString.Replace(",", ".")
                Dim sCostoTrasfertaItalia As String = rip.CostoTrasfertaItalia.ToString.Replace(",", ".")
                Dim sCostoTrasfertaEstero As String = rip.CostoTrasfertaEstero.ToString.Replace(",", ".")
                Dim sCostoTrasfertaEsteroLungo As String = rip.CostoTrasfertaEsteroLungo.ToString.Replace(",", ".")


                If dsTab.Rows.Count > 0 Then
                    sqlq = "UPDATE [cizeta].[dbo].[Riporti]"
                    sqlq = sqlq & " SET " & defRip.Riporto & " =  '" & sRiporto & "'"
                    sqlq = sqlq & " , " & defRip.OreInBusta & " = '" & rip.OreInBusta & "'"
                    sqlq = sqlq & " , " & defRip.Contanti & " = '" & sContanti & "'"
                    sqlq = sqlq & " , " & defRip.CostoOrario & " = '" & sCostoOrario & "'"
                    sqlq = sqlq & " , " & defRip.GiorniTrasfertaItalia & " = '" & rip.GiorniTrasfertaItalia & "'"
                    sqlq = sqlq & " , " & defRip.CostoTrasfertaItalia & " = '" & sCostoTrasfertaItalia & "'"
                    sqlq = sqlq & " , " & defRip.GiorniTrasfertaEstero & " = '" & rip.GiorniTrasfertaEstero & "'"
                    sqlq = sqlq & " , " & defRip.CostoTrasfertaEstero & " = '" & sCostoTrasfertaEstero & "'"
                    sqlq = sqlq & " , " & defRip.GiorniTrasfertaEsteroLungo & " = '" & rip.GiorniTrasfertaEsteroLungo & "'"
                    sqlq = sqlq & " , " & defRip.CostoTrasfertaEsteroLungo & " = '" & sCostoTrasfertaEsteroLungo & "'"
                    sqlq = sqlq & " WHERE Matricola = " & cfg.Matricola
                    sqlq = sqlq & " AND Mese = " & Data.Month & " AND Anno = " & Data.Year
                    Dim cmd As New SqlCommand(sqlq, dbConnection)
                    rowsAffected = cmd.ExecuteNonQuery()
                Else
                    sqlq = "INSERT INTO [cizeta].[dbo].[Riporti]"
                    'sqlq = sqlq & " (Matricola, Anno, Mese, Riporto, OreInBusta, Contanti, CostoOrario) "

                    sqlq = sqlq & "(" & defRip.Matricola & "," & defRip.Anno & "," & defRip.Mese & "," & defRip.Riporto
                    sqlq = sqlq & "," & defRip.OreInBusta & "," & defRip.Contanti & "," & defRip.CostoOrario
                    sqlq = sqlq & "," & defRip.GiorniTrasfertaItalia & "," & defRip.CostoTrasfertaItalia
                    sqlq = sqlq & "," & defRip.GiorniTrasfertaEstero & "," & defRip.CostoTrasfertaEstero
                    sqlq = sqlq & "," & defRip.GiorniTrasfertaEsteroLungo & "," & defRip.CostoTrasfertaEsteroLungo

                    'sqlq = sqlq & " VALUES (" & cfg.Matricola & "," & Data.Year & "," & Data.Month & "," & sRiporto & ",'" & rip.OreInBusta & "'," & sContanti & "," & sCostoOrario & ")"

                    sqlq = sqlq & ") VALUES "
                    sqlq = sqlq & "(" & cfg.Matricola & "," & Data.Year & "," & Data.Month & "," & sRiporto
                    sqlq = sqlq & ",'" & rip.OreInBusta & "'," & sContanti & "," & sCostoOrario
                    sqlq = sqlq & "," & rip.GiorniTrasfertaItalia & "," & sCostoTrasfertaItalia
                    sqlq = sqlq & "," & rip.GiorniTrasfertaEstero & "," & sCostoTrasfertaEstero
                    sqlq = sqlq & "," & rip.GiorniTrasfertaEsteroLungo & "," & sCostoTrasfertaEsteroLungo
                    sqlq = sqlq & ")"

                    Dim cmd As New SqlCommand(sqlq, dbConnection)
                    rowsAffected = cmd.ExecuteNonQuery()
                End If



            End Using

        Catch ex As Exception

        End Try

        Return (rowsAffected >= 1)

    End Function


#End Region


#Region "Report"

    Public Function ReportEmployeeRefound(filter As udtFilterRefound) As DataTable
        Dim daTab As New SqlDataAdapter, dsTab As New DataTable

        Try

            Using dbConnection As New SqlConnection(sqlCon.ConnectionString)
                dbConnection.Open()

                Dim cmd As New SqlCommand
                cmd.Connection = dbConnection
                cmd.CommandText = "ReportEmployeeRefound"
                cmd.CommandType = CommandType.StoredProcedure

                cmd.Parameters.AddWithValue("@UserName", filter.EmployeeName)
                cmd.Parameters.AddWithValue("@OrderName", filter.OrderName)
                cmd.Parameters.AddWithValue("@BeginDateIso", DateIso(filter.BeginDate))
                cmd.Parameters.AddWithValue("@EndDateIso", DateIso(filter.EndDate))

                Dim dr As SqlDataReader
                dr = cmd.ExecuteReader()
                If dr.HasRows Then
                    dsTab.Load(dr)
                End If
                dr.Close()

            End Using

        Catch ex As Exception

        End Try


        Return dsTab

    End Function

#End Region

    Public Sub ExportDataTable(dsTab As DataTable, FileName As String)
        Dim IncludeHeaders As Boolean = True

        Using writer As StreamWriter = New StreamWriter(FileName)
            'Rfc4180Writer.WriteDataTable(sourceTable, writer, True)

            If (IncludeHeaders) Then
                Dim headerValues As List(Of String) = New List(Of String)()
                For Each column As DataColumn In dsTab.Columns
                    headerValues.Add(QuoteValue(column.ColumnName))
                Next
                writer.WriteLine(String.Join(";", headerValues))
            End If

            Dim items() As String = Nothing
            For Each row As DataRow In dsTab.Rows
                items = row.ItemArray.Select(Function(obj) QuoteValue(obj.ToString())).ToArray()
                writer.WriteLine(String.Join(";", items))
            Next

            writer.Flush()

        End Using

    End Sub

    Private Function QuoteValue(ByVal value As String) As String
        Return String.Concat("""", value.Replace("""", """"""), """")
    End Function






#Region "Create database structure"
    Private Sub CreateTablesInDatabase()

        'Ricorda: Tabella dipendenti: modifica colonna AutoAziendale come NVCHAR(2) e scrivere "SI" al posto di "1" 

        Dim myDatabase = New czDatabase

        Dim dbConnection As New SqlClient.SqlConnection()
        dbConnection.ConnectionString = sqlCon.ConnectionString
        dbConnection.Open()


        'Users table
        Dim utd As New UsersTableDefs
        If Not myDatabase.TableExist(dbConnection, utd.TableName) Then
            If myDatabase.CreateTable(dbConnection, utd.TableName, utd.Matricola, "int") Then
                myDatabase.CreateField(dbConnection, utd.TableName, utd.LoginName, "NVarChar(20)  NULL")
                myDatabase.CreateField(dbConnection, utd.TableName, utd.Password, "NVarChar(20)  NULL")
                myDatabase.CreateIndex(dbConnection, "IdxID", utd.TableName, utd.Matricola)

                'update table
                Dim daTab As New SqlDataAdapter, dsTab As New DataTable
                Try
                    Dim sqlq As String = "SELECT [Matricola], [Nome] FROM [cizeta].[dbo].[Dipendenti] ORDER BY [Matricola] ASC"
                    daTab = New SqlDataAdapter(sqlq, dbConnection)
                    Dim commandBuilder As New SqlCommandBuilder(daTab)
                    dsTab.Locale = System.Globalization.CultureInfo.InvariantCulture
                    daTab.Fill(dsTab)
                    For Each row As DataRow In dsTab.Rows
                        sqlq = "INSERT INTO [" & utd.TableName & "] " '& "{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}) VALUES ('{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}')"
                        sqlq += "([" & utd.Matricola & "],[" & utd.LoginName & "],[" & utd.Password & "])"
                        Dim aryStr As String() = row("Nome").ToString.Split(" ")
                        Dim LoginName As String = aryStr(0).Substring(0, 1)
                        If aryStr.Length > 1 Then LoginName += aryStr(1).Substring(0, 1)
                        sqlq += " VALUES (" & row(utd.Matricola) & ",'" & LoginName & "', '')"
                        Dim cmd As New SqlCommand(sqlq, dbConnection)
                        Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                    Next
                Catch ex As Exception
                End Try
            End If
        End If

        Dim ctd As New ConfigTableDefs
        If myDatabase.CreateTable(dbConnection, ctd.TableName, ctd.Name, "NVarChar(40)  NULL") Then
            myDatabase.CreateField(dbConnection, ctd.TableName, ctd.Value, "real")
        End If

        Dim rtd As New RiportiTableDefs
        If myDatabase.CreateTable(dbConnection, rtd.TableName, rtd.Matricola, "int") Then
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.Anno, "int")
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.Mese, "int")
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.Riporto, "real")
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.Contanti, "real", 0.0)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.CostoOrario, "real", 0.0)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.GiorniTrasfertaItalia, "int", 0)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.CostoTrasfertaItalia, "real", 30)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.GiorniTrasfertaEstero, "int", 0)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.CostoTrasfertaEstero, "real", 40)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.GiorniTrasfertaEsteroLungo, "int", 0)
            myDatabase.CreateField(dbConnection, rtd.TableName, rtd.CostoTrasfertaEsteroLungo, "real", 50)
            If Not myDatabase.DoFieldExist(dbConnection, rtd.OreInBusta, rtd.TableName) Then
                myDatabase.CreateField(dbConnection, rtd.TableName, rtd.OreInBusta, "NVarChar(10)  NULL", "0")
                'update field
                Try
                    Dim sqlq As String = ""
                    sqlq = "UPDATE " & rtd.TableName
                    sqlq = sqlq & " SET OreInBusta =  src.OreInBusta"
                    sqlq = sqlq & " FROM  " & rtd.TableName & " tgt "
                    sqlq = sqlq & " INNER JOIN ResocontoOre src "
                    sqlq = sqlq & " ON tgt.Matricola=src.Matricola AND tgt.Mese=src.Mese AND tgt.Anno=src.Anno"
                    Dim cmd As New SqlCommand(sqlq, dbConnection)
                    Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                Catch ex As Exception
                End Try
            End If
        End If

        Dim dtd As New DipendentiTableDefs
        If myDatabase.CreateTable(dbConnection, dtd.TableName, dtd.Matricola, "int") Then
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Nome, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.CodiceFiscale, "NVarChar(30)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Qualifica, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Indirizzo, "NVarChar(255)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Città, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Provincia, "NVarChar(20)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.CAP, "NVarChar(20)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Paese, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.TelefonoAbitazione, "NVarChar(30)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Cellulare, "NVarChar(30)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.DataDiNascita, "datetime2")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.LuogoDiNascita, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.DataAssunzione, "datetime2")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.StatoCivile, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.NomeConiuge, "NVarChar(50)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Fotografia, "image")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Autovettura, "NVarChar(32)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.AutoAziendale, "NVarChar(22)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Targa, "NVarChar(10)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.Note, "NVarChar(MAX)  NULL")
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.CostoOrario, "real", 0.0)
            myDatabase.CreateField(dbConnection, dtd.TableName, dtd.DataFineContratto, "datetime2")

        End If

        dbConnection.Close()

    End Sub

    Private Sub CreateStoredProcedeures()

        Dim ServerName As String = ""
        Dim Login As String = ""
        Dim Password As String = ""
        Dim Catalog As String = ""
        Dim arystr As String() = sqlCon.ConnectionString.Split(";")
        For i = 0 To arystr.Count - 1
            If arystr(i).Contains("Server=") Then
                ServerName = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
            End If
            If arystr(i).Contains("User ID=") Then
                Login = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
            End If
            If arystr(i).Contains("Password=") Then
                Password = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
            End If
            If arystr(i).Contains("Initial Catalog =") Then
                Catalog = arystr(i).Substring(arystr(i).LastIndexOf("=") + 1)
            End If
        Next

        Try

            'Connect to the local, default instance of SQL Server.
            ' For remote connection, remote server name / ServerInstance needs to be specified
            Dim srvConn As New ServerConnection(ServerName)
            srvConn.LoginSecure = False
            srvConn.Login = Login
            srvConn.Password = Password
            Dim srv As New Server(srvConn)

            'Reference the database.
            Dim db As Database
            db = srv.Databases(Catalog)

            CreateSP_GetConfigurations(db)

            CreateSP_GetUsersList(db)
            CreateSP_GetOrdersList(db)
            CreateSP_GetActivityList(db)
            CreateSP_GetSectorList(db)

            CreateFN_Matricola(db)
            CreateFN_CostoKm(db)

            CreateSP_GetOrders(db)
            CreateSP_AddOrder(db)
            CreateSP_UpdateOrder(db)
            CreateSP_ModifyOrderName(db)
            CreateSP_DeleteOrder(db)
            CreateFN_OrderExists(db)

            CreateSP_GetWorkedHoursMonthly(db)
            CreateSP_AddOreLavoro(db)
            CreateSP_UpdateOreLavoro(db)
            CreateSP_DeleteOreLavoro(db)
            CreateFN_OreLavoroExists(db)

            CreateSP_GetOrdersDoneByUser(db)
            CreateSP_GetUsersWhoMakeOrder(db)
            CreateSP_GetWorkInProgressOrders(db)

            CreateSP_GetWorkedHours(db)
            CreateSP_GetWorkedHoursByUser(db)

            CreateSP_GetUserRefound(db)
            CreateSP_GetUserAnalysisRefound(db)
            CreateSP_GetUserAnalysisRefoundByName(db)
            CreateSP_GetUserAnalysisRefoundByOrders(db)
            CreateSP_GetOrdersDoneByUserWithRefound(db)
            CreateSP_GetUsersWhoMakeOrderWithRefound(db)
            CreateSP_AddRefound(db)
            CreateSP_UpdateRefound(db)
            CreateSP_DeleteRefound(db)
            CreateFN_RefoundExists(db)

            CreateSP_ReportEmployeeRefound(db)

            CreateSP_AddConfiguration(db)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub CreateSP_GetConfigurations(db As Database)

        Try

            Dim StoredProcedureName As String = "GetConfigurations"

            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "Set NOCOUNT On;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT Name, Value" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Configurations]" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetUsersList(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUsersList"

            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "Set NOCOUNT On;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT d.[Matricola],d.[Nome],u.[LoginName],u.[Password], d.[Fotografia]" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Dipendenti] d" & vbCrLf
            stmt += vbTab & "INNER JOIN cizeta.dbo.Users u ON d.Matricola = u.Matricola" & vbCrLf
            stmt += vbTab & "ORDER BY d.Matricola ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_GetOrdersList(db As Database)

        Try

            Dim StoredProcedureName As String = "GetOrdersList"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Filter", DataType.NVarChar(40)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT [Commessa]" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Commesse]" & vbCrLf
            stmt += vbTab & "WHERE [Commessa] LIKE @Filter" & vbCrLf
            stmt += vbTab & "ORDER BY [Commessa] ASC;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_GetActivityList(db As Database)

        Try

            Dim StoredProcedureName As String = "GetActivityList"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT [Attività]" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Attività]" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_GetSectorList(db As Database)

        Try

            Dim StoredProcedureName As String = "GetSectorList"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT [Settore]" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Settori]" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateFN_Matricola(db As Database)

        Try

            Dim UserDefinedFunctionName As String = "fnMatricola"
            For Each item As UserDefinedFunction In db.UserDefinedFunctions
                If item.Name = UserDefinedFunctionName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim udf As UserDefinedFunction
            udf = New UserDefinedFunction(db, UserDefinedFunctionName)
            udf.TextMode = False
            udf.DataType = DataType.Int
            udf.ExecutionContext = ExecutionContext.Caller
            udf.FunctionType = UserDefinedFunctionType.Scalar
            udf.ImplementationType = ImplementationType.TransactSql
            'Add parameters.
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@UserName", DataType.NVarChar(40)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @ReturnValue int = 0" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT  @ReturnValue = Matricola" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Dipendenti] " & vbCrLf
            stmt += vbTab & "WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "RETURN @ReturnValue" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            udf.TextBody = stmt

            udf.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateFN_CostoKm(db As Database)

        Try

            Dim UserDefinedFunctionName As String = "fnCostoKm"
            For Each item As UserDefinedFunction In db.UserDefinedFunctions
                If item.Name = UserDefinedFunctionName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim udf As UserDefinedFunction
            udf = New UserDefinedFunction(db, UserDefinedFunctionName)
            udf.TextMode = False
            udf.DataType = DataType.Real
            udf.ExecutionContext = ExecutionContext.Caller
            udf.FunctionType = UserDefinedFunctionType.Scalar
            udf.ImplementationType = ImplementationType.TransactSql
            'Add parameters.
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@UserName", DataType.NVarChar(40)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @ReturnValue real = 0.4" & vbCrLf
            stmt += vbTab & "DECLARE @AutoAziendale int = 0" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT  @AutoAziendale = AutoAziendale" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Dipendenti]" & vbCrLf
            stmt += vbTab & "WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT @ReturnValue = [Value]" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Configurations]" & vbCrLf
            stmt += vbTab & "WHERE Name = 'CostoKm'" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "IF @AutoAziendale = 1 " & vbCrLf
            stmt += vbTab & vbTab & "SET @ReturnValue = 0" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "RETURN @ReturnValue" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            udf.TextBody = stmt

            udf.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub


    Private Sub CreateSP_AddConfiguration(db As Database)

        Try

            Dim StoredProcedureName As String = "AddConfigurationParam"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Name", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Value", DataType.Real))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE  @ParamsQty INT;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT @ParamsQty = COUNT(*) FROM [cizeta].[dbo].[Configurations] WHERE Name = @Name" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "IF @ParamsQty = 0" & vbCrLf
            stmt += vbTab & vbTab & "INSERT INTO [cizeta].[dbo].[Configurations]  (Name, Value) VALUES (@Name, @Value);" & vbCrLf
            stmt += vbTab & "ELSE UPDATE [cizeta].[dbo].[Configurations] SET Value = @Value WHERE Name = @Name" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt


            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub


    Private Sub CreateSP_GetOrders(db As Database)

        Try

            Dim StoredProcedureName As String = "GetOrders"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Filter", DataType.NVarChar(40)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT [Commessa], [Cliente], CONVERT(nvarchar,[Finita]) AS Terminata" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[Commesse]" & vbCrLf
            stmt += vbTab & "WHERE [Commessa] LIKE @Filter" & vbCrLf
            stmt += vbTab & "ORDER BY [Commessa] ASC;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_AddOrder(db As Database)

        Try

            Dim StoredProcedureName As String = "AddOrder"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Customer", DataType.NVarChar(80)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "INSERT INTO Commesse (Commessa, [Finita], [Cliente])" & vbCrLf
            stmt += vbTab & "VALUES (@OrderName, 0, @Customer);" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_UpdateOrder(db As Database)

        Try

            Dim StoredProcedureName As String = "UpdateOrder"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Customer", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Ended", DataType.Int))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "UPDATE Commesse" & vbCrLf
            stmt += vbTab & "SET Commessa = @OrderName, Cliente = @Customer, Finita = @Ended" & vbCrLf
            stmt += vbTab & "WHERE Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_ModifyOrderName(db As Database)

        Try

            Dim StoredProcedureName As String = "ModifyOrderName"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@NewOrderName", DataType.NVarChar(80)))

            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN TRANSACTION;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "UPDATE OreLavoro" & vbCrLf
            stmt += vbTab & "SET Commessa = @NewOrderName" & vbCrLf
            stmt += vbTab & "WHERE Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "UPDATE SpeseViaggio" & vbCrLf
            stmt += vbTab & "SET Commessa = @NewOrderName" & vbCrLf
            stmt += vbTab & "WHERE Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "UPDATE Commesse" & vbCrLf
            stmt += vbTab & "SET Commessa = @NewOrderName" & vbCrLf
            stmt += vbTab & "WHERE Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "COMMIT;" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_DeleteOrder(db As Database)

        Try

            Dim StoredProcedureName As String = "DeleteOrder"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DELETE FROM Commesse" & vbCrLf
            stmt += vbTab & "WHERE Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateFN_OrderExists(db As Database)

        Try

            Dim UserDefinedFunctionName As String = "fnOrderExists"
            For Each item As UserDefinedFunction In db.UserDefinedFunctions
                If item.Name = UserDefinedFunctionName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim udf As UserDefinedFunction
            udf = New UserDefinedFunction(db, UserDefinedFunctionName)
            udf.TextMode = False
            udf.DataType = DataType.Int
            udf.ExecutionContext = ExecutionContext.Caller
            udf.FunctionType = UserDefinedFunctionType.Scalar
            udf.ImplementationType = ImplementationType.TransactSql
            'Add parameters.
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@OrderName", DataType.NVarChar(80)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @ReturnValue int = 0" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT  @ReturnValue = COUNT(Commessa)" & vbCrLf
            stmt += vbTab & "FROM Commesse" & vbCrLf
            stmt += vbTab & "WHERE Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "RETURN @ReturnValue" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            udf.TextBody = stmt

            udf.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetWorkedHoursMonthly(db As Database)

        Try

            Dim StoredProcedureName As String = "GetWorkedHoursMonthly"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DAY(Data) As Giorno, [Commessa], [Attività], [Settore] ,[OreLavoro],[OreViaggio]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[OreLavoro]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Nome LIKE @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Attività LIKE @Activity" & vbCrLf
            stmt += vbTab & vbTab & "AND [Settore] LIKE @Sector" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Data ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_AddOreLavoro(db As Database)

        Try

            Dim StoredProcedureName As String = "AddOreLavoro"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@DateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OreLavoro", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OreViaggio", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "INSERT INTO OreLavoro (Nome, Commessa, Attività, Settore, Data, OreLavoro, OreViaggio)" & vbCrLf
            stmt += vbTab & "VALUES (@UserName, @OrderName, @Activity, @Sector, @DateIso, @OreLavoro, @OreViaggio);" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_UpdateOreLavoro(db As Database)

        Try

            Dim StoredProcedureName As String = "UpdateOreLavoro"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@DateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OreLavoro", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OreViaggio", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "UPDATE OreLavoro" & vbCrLf
            stmt += vbTab & "SET OreLavoro = @OreLavoro, OreViaggio = @OreViaggio" & vbCrLf
            stmt += vbTab & "WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "AND Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "AND Attività = @Activity" & vbCrLf
            stmt += vbTab & "AND Settore = @Sector" & vbCrLf
            stmt += vbTab & "AND Data = CONVERT (datetime2, @DateIso)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_DeleteOreLavoro(db As Database)

        Try

            Dim StoredProcedureName As String = "DeleteOreLavoro"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@DateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DELETE FROM OreLavoro" & vbCrLf
            stmt += vbTab & "WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "AND Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "AND Attività = @Activity" & vbCrLf
            stmt += vbTab & "AND Settore = @Sector" & vbCrLf
            stmt += vbTab & "AND Data = CONVERT (datetime2, @DateIso)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateFN_OreLavoroExists(db As Database)

        Try

            Dim UserDefinedFunctionName As String = "fnOreLavoroExists"
            For Each item As UserDefinedFunction In db.UserDefinedFunctions
                If item.Name = UserDefinedFunctionName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim udf As UserDefinedFunction
            udf = New UserDefinedFunction(db, UserDefinedFunctionName)
            udf.TextMode = False
            udf.DataType = DataType.Int
            udf.ExecutionContext = ExecutionContext.Caller
            udf.FunctionType = UserDefinedFunctionType.Scalar
            udf.ImplementationType = ImplementationType.TransactSql
            'Add parameters.
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@UserName", DataType.NVarChar(40)))
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@OrderName", DataType.NVarChar(80)))
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@Activity", DataType.NVarChar(80)))
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@Sector", DataType.NVarChar(80)))
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@DateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @ReturnValue int = 0" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT  @ReturnValue =COUNT(Nome)" & vbCrLf
            stmt += vbTab & "FROM OreLavoro" & vbCrLf
            stmt += vbTab & "WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "AND Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "AND Attività = @Activity" & vbCrLf
            stmt += vbTab & "AND Settore = @Sector" & vbCrLf
            stmt += vbTab & "AND Data = CONVERT (datetime2, @DateIso)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "RETURN @ReturnValue" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            udf.TextBody = stmt

            udf.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetOrdersDoneByUser(db As Database)

        Try

            Dim StoredProcedureName As String = "GetOrdersDoneByUser"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EmployeeName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DISTINCT [Commessa]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[OreLavoro]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Nome LIKE @EmployeeName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Attività LIKE @Activity" & vbCrLf
            stmt += vbTab & vbTab & "AND Settore LIKE @Sector" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Commessa ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_GetUsersWhoMakeOrder(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUsersWhoMakeOrder"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DISTINCT [Nome]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[OreLavoro]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Attività LIKE @Activity" & vbCrLf
            stmt += vbTab & vbTab & "AND [Settore] LIKE @Sector" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Nome ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetWorkInProgressOrders(db As Database)

        Try

            Dim StoredProcedureName As String = "GetWorkInProgressOrders"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EmployeeName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DISTINCT Commessa, Attività, Settore, Nome " & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[OreLavoro]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Nome LIKE @EmployeeName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Attività LIKE @Activity" & vbCrLf
            stmt += vbTab & vbTab & "AND [Settore] LIKE @Sector" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Commessa ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetWorkedHours(db As Database)

        Try

            Dim StoredProcedureName As String = "GetWorkedHours"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT Data, [Commessa], [Attività], [Settore] ,[OreLavoro],[OreViaggio]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[OreLavoro]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Nome LIKE @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Attività LIKE @Activity" & vbCrLf
            stmt += vbTab & vbTab & "AND [Settore] LIKE @Sector" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Data ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetWorkedHoursByUser(db As Database)

        Try

            Dim StoredProcedureName As String = "GetWorkedHoursByUser"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Activity", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Sector", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT Nome, Data, [Commessa], [Attività], [Settore] ,[OreLavoro],[OreViaggio]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[OreLavoro]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Nome LIKE @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Attività LIKE @Activity" & vbCrLf
            stmt += vbTab & vbTab & "AND [Settore] LIKE @Sector" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Data ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub



    Private Sub CreateSP_GetUserRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUserRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DAY(Data) AS Giorno, [Commessa], [Località], [Km], [Autostrada], [MezziPub] AS Mezzi" & vbCrLf
            stmt += vbTab & vbTab & ",[Vitto],[Alloggio],[Varie],[CCA] AS Carta,[Valuta],[TipoRimborso] AS R,[Motivo] AS M, [Diaria]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE dp.nome = @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Data ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetOrdersDoneByUserWithRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "GetOrdersDoneByUserWithRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DISTINCT [Commessa]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE dp.nome = @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Motivo = 'R'" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Commessa ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetUsersWhoMakeOrderWithRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUsersWhoMakeOrderWithRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DISTINCT [Nome]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND Motivo = 'R'" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Nome ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetUserAnalysisRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUserAnalysisRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT Nome, Data, [Commessa], [Località], [Km], [Autostrada], [MezziPub] AS Mezzi" & vbCrLf
            stmt += vbTab & vbTab & ",[Vitto],[Alloggio],[Varie]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE dp.nome = @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Data ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetUserAnalysisRefoundByName(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUserAnalysisRefoundByName"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT Nome, Data, [Commessa], [Località], [Km], [Autostrada], [MezziPub] AS Mezzi" & vbCrLf
            stmt += vbTab & vbTab & ",[Vitto],[Alloggio],[Varie]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE dp.nome = @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Nome ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_GetUserAnalysisRefoundByOrders(db As Database)

        Try

            Dim StoredProcedureName As String = "GetUserAnalysisRefoundByOrders"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT Nome, Data, [Commessa], [Località], [Km], [Autostrada], [MezziPub] AS Mezzi" & vbCrLf
            stmt += vbTab & vbTab & ",[Vitto],[Alloggio],[Varie]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE dp.nome = @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Commessa ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub

    Private Sub CreateSP_AddRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "AddRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@City", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@DateIso", DataType.NVarChar(20)))

            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Km", DataType.Int))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Autostrada", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@MezziPub", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Vitto", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Alloggio", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Varie", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Diaria", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@CCA", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Valuta", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@TipoRimborso", DataType.NVarChar(1)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Motivo", DataType.NVarChar(1)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@CostoKm", DataType.Real))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @mat    int" & vbCrLf
            stmt += vbTab & "SELECT @mat = dbo.fnMatricola(@UserName)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "INSERT INTO SpeseViaggio (Matricola, Commessa, Data, Località, Km, Autostrada, MezziPub, Vitto, Alloggio, Varie, Diaria, CCA, Valuta, TipoRimborso, Motivo, CostoKm)" & vbCrLf
            stmt += vbTab & "VALUES (@mat, @OrderName, @DateIso, @City, @Km, @Autostrada, @MezziPub, @Vitto, @Alloggio, @Varie, @Diaria, @CCA, @Valuta, @TipoRimborso, @Motivo, @CostoKm);" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_UpdateRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "UpdateRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@City", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@DateIso", DataType.NVarChar(20)))

            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Km", DataType.Int))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Autostrada", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@MezziPub", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Vitto", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Alloggio", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Varie", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Diaria", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@CCA", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Valuta", DataType.Real))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@TipoRimborso", DataType.NVarChar(1)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@Motivo", DataType.NVarChar(1)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@CostoKm", DataType.Real))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @mat    int" & vbCrLf
            stmt += vbTab & "SELECT @mat = dbo.fnMatricola(@UserName)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "UPDATE SpeseViaggio" & vbCrLf
            stmt += vbTab & "SET Località = @City, Km = @km, Autostrada = @Autostrada" & vbCrLf
            stmt += vbTab & ", MezziPub = @MezziPub, Vitto = @Vitto" & vbCrLf
            stmt += vbTab & ", Alloggio = @Alloggio, Varie = @Varie" & vbCrLf
            stmt += vbTab & ", Diaria = @Diaria, CCA = @CCA" & vbCrLf
            stmt += vbTab & ", Valuta = @Valuta, TipoRimborso = @TipoRimborso" & vbCrLf
            stmt += vbTab & ", Motivo = @Motivo, CostoKm = @CostoKm" & vbCrLf
            stmt += vbTab & "WHERE Matricola = @mat" & vbCrLf
            stmt += vbTab & "AND Commessa = @OrderName" & vbCrLf
            'stmt += vbTab & "AND località = @City" & vbCrLf
            stmt += vbTab & "AND Data = CONVERT (datetime2, @DateIso)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateSP_DeleteRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "DeleteRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@City", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@DateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            'stmt += vbTab & "SELECT @mat = Matricola FROM Dipendenti WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "DECLARE @mat    int" & vbCrLf
            stmt += vbTab & "SELECT @mat = dbo.fnMatricola(@UserName)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DELETE FROM SpeseViaggio" & vbCrLf
            stmt += vbTab & "WHERE Matricola = @mat" & vbCrLf
            stmt += vbTab & "AND Commessa = @OrderName" & vbCrLf
            stmt += vbTab & "AND località = @City" & vbCrLf
            stmt += vbTab & "AND Data = CONVERT (datetime2, @DateIso)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub
    Private Sub CreateFN_RefoundExists(db As Database)

        Try

            Dim UserDefinedFunctionName As String = "fnRefoundExists"
            For Each item As UserDefinedFunction In db.UserDefinedFunctions
                If item.Name = UserDefinedFunctionName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim udf As UserDefinedFunction
            udf = New UserDefinedFunction(db, UserDefinedFunctionName)
            udf.TextMode = False
            udf.DataType = DataType.Int
            udf.ExecutionContext = ExecutionContext.Caller
            udf.FunctionType = UserDefinedFunctionType.Scalar
            udf.ImplementationType = ImplementationType.TransactSql
            'Add parameters.
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@UserName", DataType.NVarChar(40)))
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@OrderName", DataType.NVarChar(80)))
            'udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@City", DataType.NVarChar(80)))
            udf.Parameters.Add(New UserDefinedFunctionParameter(udf, "@DateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "DECLARE @ReturnValue int = 0" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SELECT  @ReturnValue =COUNT(sv.Matricola)" & vbCrLf
            stmt += vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sv" & vbCrLf
            stmt += vbTab & "inner join [Dipendenti] dip on sv.Matricola = dip.Matricola" & vbCrLf
            stmt += vbTab & "WHERE Nome = @UserName" & vbCrLf
            stmt += vbTab & "AND Commessa = @OrderName" & vbCrLf
            'stmt += vbTab & "AND [Località] = @City" & vbCrLf
            stmt += vbTab & "AND Data = CONVERT (datetime2, @DateIso)" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "RETURN @ReturnValue" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            udf.TextBody = stmt

            udf.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub



    Private Sub CreateSP_ReportEmployeeRefound(db As Database)

        Try

            Dim StoredProcedureName As String = "ReportEmployeeRefound"
            For Each item As StoredProcedure In db.StoredProcedures
                If item.Name = StoredProcedureName Then
                    item.Drop()
                    Exit For
                End If
            Next

            Dim sp As StoredProcedure
            sp = New StoredProcedure(db, StoredProcedureName)
            sp.TextMode = False
            sp.AnsiNullsStatus = False
            sp.QuotedIdentifierStatus = False
            'Add parameters.
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@UserName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@OrderName", DataType.NVarChar(80)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@BeginDateIso", DataType.NVarChar(20)))
            sp.Parameters.Add(New StoredProcedureParameter(sp, "@EndDateIso", DataType.NVarChar(20)))
            'Set the TextBody property to define the stored procedure.
            Dim stmt As String
            stmt = "BEGIN" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & "SET NOCOUNT ON;" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += vbTab & vbTab & "SELECT DAY(Data) AS Giorno, [Commessa], [Località], [Km], [Autostrada], [MezziPub] AS Mezzi" & vbCrLf
            stmt += vbTab & vbTab & ",[Vitto], [Alloggio], [Varie], [Diaria], [CCA] AS Carta, [Valuta], [TipoRimborso]" & vbCrLf
            stmt += vbTab & vbTab & "FROM [cizeta].[dbo].[SpeseViaggio] sp" & vbCrLf
            stmt += vbTab & vbTab & "inner join [cizeta].[dbo].[Dipendenti] dp ON sp.[Matricola]=dp.[Matricola]" & vbCrLf
            stmt += vbTab & vbTab & "WHERE dp.nome = @UserName" & vbCrLf
            stmt += vbTab & vbTab & "AND Commessa LIKE @OrderName" & vbCrLf
            stmt += vbTab & vbTab & "AND (Data BETWEEN CONVERT (datetime2, @BeginDateIso) AND CONVERT (datetime2, @EndDateIso))" & vbCrLf
            stmt += vbTab & vbTab & "ORDER BY Data ASC" & vbCrLf
            stmt += vbTab & "" & vbCrLf
            stmt += "END" & vbCrLf
            sp.TextBody = stmt

            sp.Create()

        Catch ex As Exception
            If System.Diagnostics.Debugger.IsAttached Then
                MsgBox(System.Reflection.MethodBase.GetCurrentMethod().Name & " Failed!")
            End If
        End Try

    End Sub


#End Region


    Private Sub DeleteAllFiles(Path As String)
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(Path)
            My.Computer.FileSystem.DeleteFile(foundFile, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.DeletePermanently) ', Microsoft.VisualBasic.FileIO.UIOption.AllDialogs, Microsoft.VisualBasic.FileIO.RecycleOption.DeletePermanently)
        Next

    End Sub

    Private Function UpdateField(ByVal dbC As SqlConnection, ByVal TableName As String, ByVal FieldName As String, ByVal Value As String, WhereClause As String) As Boolean
        Dim sqlq As String = "UPDATE " & TableName & " SET " & FieldName & " = '" & Value & "'" & " WHERE " & WhereClause
        Dim cmd As New SqlCommand(sqlq, dbC)
        cmd.ExecuteNonQuery()
        Return True
    End Function
    Private Function UpdateFields(ByVal dbC As SqlConnection, ByVal TableName As String, ByVal FieldNameWithValue As List(Of String), WhereClause As String) As Boolean
        Dim retry As Byte = 0

        If FieldNameWithValue.Count = 0 Then Return False

        Do
            Try
                Dim sqlq As String = "UPDATE " & TableName & " SET "
                For i As Integer = 0 To FieldNameWithValue.Count - 1
                    sqlq += FieldNameWithValue(i)
                    If i = FieldNameWithValue.Count - 1 Then
                    Else
                        sqlq += ","
                    End If
                Next
                sqlq += " WHERE  " & WhereClause
                Dim cmd As New SqlCommand(sqlq, dbC)
                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then Return True
                retry += 1
            Catch ex As Exception
                retry += 1
            End Try
            If retry > 5 Then Return False
            Threading.Thread.Sleep(10)
        Loop


    End Function

    Private Function DateIso(d As Date) As String
        Return d.ToString("yyyy-MM-dd HH:mm")
    End Function
    Private Function OreIso(d As Single) As String

        Dim Sep As String = (System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)

        Dim s As String = d.ToString("#0.00")
        s = s.Replace(",", ".")
        Return s
        'Return d.ToString("#0.00")
    End Function

    Private Function DatabaseToString(ByVal sValore As Object) As String

        If IsDBNull(sValore) Then Return ""
        Return sValore.ToString
        

    End Function


End Class
