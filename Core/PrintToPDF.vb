Imports iTextSharp.text
Imports System.IO
Imports iTextSharp.text.pdf
Imports iTextSharp.text.pdf.draw
Imports AcroPDFLib

Public Class PrintToPDF

    Private Doc As Document
    Private fileStream As FileStream
    Private Writer As PdfWriter

    'Declare a printerSettings
    Private PrinterToUseSetting As System.Drawing.Printing.PrinterSettings = Nothing


    Private Class TableColumnsDefinition

        Private _dictionary


        Public Sub New(ColumnsName() As String)
            _dictionary = New Dictionary(Of String, Integer)
            For i As Integer = 0 To ColumnsName.Length - 1
                _dictionary.add(ColumnsName(i), i)
            Next
        End Sub

        Public Function Column(ColumnName As String) As Integer
            ' Return value from private Dictionary.
            Return Me._dictionary.Item(ColumnName)
        End Function

    End Class
    Private tcdOreLavoro As TableColumnsDefinition
    Private tcdRefound As TableColumnsDefinition




    Public Sub New()

    End Sub




#Region "Methods"
    Public Sub PrintOreLavoro(FileName As String, Filter As DatabaseManagement.udtFilterOreLavoro)

        If My.Computer.FileSystem.FileExists(FileName) Then
            My.Computer.FileSystem.DeleteFile(FileName)
        End If


        Doc = New Document(PageSize.A4, 50, 20, 15, 15)
        Try
            fileStream = New FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            Writer = PdfWriter.GetInstance(Doc, fileStream)
            Doc.Open()

            LogoOreLavoro()

            IntestazioneOreLavoro(Filter.EmployeeName, Filter.BeginDate.ToString("MMMM"), Filter.BeginDate.ToString("yyyy"))

            TabellaOreLavoro(Filter)



        Catch ex As Exception

        End Try

        Doc.Close()


        ' cmdPrint_Click(FileName)



    End Sub

    Public Sub PrintOreLavoroAnalysis(FileName As String, Filter As DatabaseManagement.udtFilterOreLavoro, Employee As Boolean)

        Dim Name As String = ""

        If Employee Then
            Name = Filter.EmployeeName
        Else
            Name = Filter.OrderName.Replace("%", "")
        End If

        If My.Computer.FileSystem.FileExists(FileName) Then
            My.Computer.FileSystem.DeleteFile(FileName)
        End If


        Doc = New Document(PageSize.A4, 50, 20, 15, 15)
        Try
            fileStream = New FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            Writer = PdfWriter.GetInstance(Doc, fileStream)
            Doc.Open()

            LogoOreLavoroAnalysis()

            IntestazioneOreLavoroAnalysis(Name, Filter.BeginDate.ToString("dd/MM/yyy"), Filter.EndDate.ToString("dd/MM/yyy"))

            TabellaOreLavoroAnalysis(Filter, Employee)



        Catch ex As Exception

        End Try

        Doc.Close()


        ' cmdPrint_Click(FileName)



    End Sub


    Public Sub PrintRefound(FileName As String, Filter As DatabaseManagement.udtFilterRefound)

        If My.Computer.FileSystem.FileExists(FileName) Then
            My.Computer.FileSystem.DeleteFile(FileName)
        End If


        Doc = New Document(PageSize.A4.Rotate, 50, 20, 15, 15)
        Try
            fileStream = New FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            Writer = PdfWriter.GetInstance(Doc, fileStream)
            Doc.Open()

            LogoRefound()

            IntestazioneRefound(Filter.EmployeeName, Filter.BeginDate.ToString("MMMM"), Filter.BeginDate.ToString("yyyy"))

            TabellaRefound(Filter)


        Catch ex As Exception

        End Try

        Doc.Close()


        ' cmdPrint_Click(FileName)



    End Sub

    Public Sub PrintRefoundAnalysis(FileName As String, Filter As DatabaseManagement.udtFilterRefound, EmployeeType As Boolean)
        If My.Computer.FileSystem.FileExists(FileName) Then
            My.Computer.FileSystem.DeleteFile(FileName)
        End If

        Dim Name As String = ""
        Name = FileName.Replace("C:\OreLavoro\AnalisiSpese-", "")
        Name = Name.Replace(".pdf", "")

        Doc = New Document(PageSize.A4.Rotate, 50, 20, 15, 15)
        Try
            fileStream = New FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.None)
            Writer = PdfWriter.GetInstance(Doc, fileStream)
            Doc.Open()

            LogoRefoundAnalysis()

            IntestazioneRefoundAnalysis(Name, Filter.BeginDate.ToString("dd/MM/yyyy"), Filter.EndDate.ToString("dd/MM/yyyy"))

            TabellaRefoundAnalysis(Filter, EmployeeType)


        Catch ex As Exception

        End Try

        Doc.Close()

    End Sub

#End Region

#Region "OreLavoro"
    Private Sub LogoOreLavoro()

        Try

            Dim table = New PdfPTable(2)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 216.0F
            table.SetWidths(New Single() {1.0, 1.0})

            Dim Arial = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
            Dim FontCizeta = FontFactory.GetFont("Arial", 48, iTextSharp.text.Font.BOLD, New BaseColor(Drawing.Color.OrangeRed))

            'Dim p = New Paragraph(New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)))
            Dim LineSeparator = New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, 1)
            Doc.Add(LineSeparator)

            table.AddCell(GetCell("cizeta", 1, 4, FontCizeta, Element.ALIGN_CENTER))
            table.AddCell(GetCell("CIZETA AUTOMAZIONE S.R.L.", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("15057 TORTONA (AL)", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("Via S.FERRARI 20/5", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("p.i. 0096859 0067", Arial, Element.ALIGN_LEFT))
            Doc.Add(table)

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, -5))
            ' Doc.Add(Chunk.NEWLINE)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub IntestazioneOreLavoro(EmployeeName As String, Month As String, Year As String)

        Dim Arial = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.NORMAL)
        Dim ArialSmall = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)

        Try

            Dim table = New PdfPTable(7)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {50, 180, 50, 100, 50, 40, 70})

            InsertEmptyRow(table, 6)
            table.AddCell(GetCell("Nome ", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(EmployeeName, ArialSmall, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCell("Mese ", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Month, ArialSmall, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCell("Anno ", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Year, ArialSmall, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCell(" ", ArialSmall, Element.ALIGN_RIGHT))
            InsertEmptyRow(table, 6)
            Doc.Add(table)

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))
            'Doc.Add(Chunk.NEWLINE)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabellaOreLavoro(Filter As DatabaseManagement.udtFilterOreLavoro)
        Dim Arial = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)

        Try

            'Dim table = New PdfPTable(6)
            Dim table = New PdfPTable(7)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 50, 120, 100, 80, 60, 60})

            'Intestazione
            table.AddCell(GetCell("Nome ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Giorno ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Commessa ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Attività ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Settore ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("OreLavoro ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("OreViaggio ", ArialBold, Element.ALIGN_CENTER))
            Doc.Add(table)

            'Commesse
            Dim dtAll As DataTable = xDatabase.GetWorkedHoursMonthly(Filter)
            Dim Orders As New List(Of String)
            For iRow As Integer = 0 To dtAll.Rows.Count - 1
                If Not Orders.Contains(dtAll.Rows(iRow)(1).ToString()) Then
                    Orders.Add(dtAll.Rows(iRow)(1).ToString())
                End If
            Next

            For Each str As String In Orders
                Dim f As New DatabaseManagement.udtFilterOreLavoro
                f.EmployeeName = Filter.EmployeeName
                f.OrderName = str
                f.Activity = Filter.Activity
                f.Sector = Filter.Sector
                f.BeginDate = Filter.BeginDate
                f.EndDate = Filter.EndDate
                TabellaOreLavoroCommesse(f)
            Next

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

            'Totali
            Dim OreLavoroTot As String = ""
            Dim OreViaggioTot As String = ""
            Dim ore As udtOre = GetOre(dtAll, 4, 5) '4, 5
            OreLavoroTot = TimeSpanToText(ore.Lavoro)
            OreViaggioTot = TimeSpanToText(ore.Viaggio)

            table = New PdfPTable(7)
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 40, 130, 100, 80, 60, 60})

            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Totale ore mese", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCellWithBorder(OreLavoroTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder(OreViaggioTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            InsertEmptyRow(table, 6)
            Doc.Add(table)

            'Straordinario
            Dim wh As TimeSpan = GetWorkingHours(Filter.BeginDate, Filter.EndDate)
            ore.Straordinario = ore.Lavoro.Add(ore.Viaggio)
            Dim tot As String = TimeSpanToText(ore.Straordinario)
            ore.Straordinario = ore.Straordinario.Subtract(wh)
            Dim OreStraordinario As String = TimeSpanToText(ore.Straordinario)
            Dim work As String = TimeSpanToText(wh)

            table = New PdfPTable(3)
            InsertEmptyRow(table, 6)
            table.AddCell(GetCellWithBorder("Ore totali", ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder("Ore lavorative", ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder("Ore straordinario", ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder(tot, ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCellWithBorder(work, ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCellWithBorder(OreStraordinario, ArialBold, Element.ALIGN_CENTER))
            Doc.Add(table)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub TabellaOreLavoroCommesse(Filter As DatabaseManagement.udtFilterOreLavoro)

        Dim Arial = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)

        Try

            'Dim table = New PdfPTable(6)
            Dim table = New PdfPTable(7)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 50, 120, 100, 80, 60, 60})

            'Dati
            Dim font As Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL)
            Dim PdfPCell As PdfPCell = Nothing
            'Dim dt As DataTable = xDatabase.GetWorkedHoursMonthly(Filter)
            Dim dt As DataTable = xDatabase.GetWorkedHoursByUser(Filter)
            For iRow As Integer = 0 To dt.Rows.Count - 1
                For iCol As Integer = 0 To dt.Columns.Count - 1
                    Dim alignemnt As Integer = Element.ALIGN_CENTER
                    Select Case iCol
                        Case 1, 2, 3
                            alignemnt = Element.ALIGN_CENTER
                        Case Else
                            alignemnt = Element.ALIGN_CENTER
                    End Select
                    Dim str As String = ""
                    If iCol >= 5 Then   '>=4
                        Dim ts As New TimeSpan()
                        ts = ResPublic.TextToTimeSpan(dt.Rows(iRow)(iCol).ToString())
                        str = TimeSpanToText(ts)
                    Else
                        str = dt.Rows(iRow)(iCol).ToString()
                        str = str.Replace("00:00:00", "")
                    End If
                    If iRow Mod (2) = 0 Then
                        table.AddCell(GetCell(str, font, alignemnt, New BaseColor(Drawing.Color.Lavender)))
                    Else
                        table.AddCell(GetCell(str, font, alignemnt))
                    End If

                Next
            Next

            InsertEmptyRow(table, 6)
            Doc.Add(table)

            'Doc.Add(New Paragraph(".", FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL)))
            Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

            'Totali
            Dim OreLavoroTot As String = ""
            Dim OreViaggioTot As String = ""
            Dim ore As udtOre = GetOre(dt, 5, 6)   '4, 5
            OreLavoroTot = TimeSpanToText(ore.Lavoro)
            OreViaggioTot = TimeSpanToText(ore.Viaggio)

            table = New PdfPTable(7)
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 40, 130, 100, 80, 60, 60})

            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCellWithBorder(OreLavoroTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder(OreViaggioTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))

            InsertEmptyRow(table, 6)
            Doc.Add(table)

            'Doc.Add(Chunk.NEWLINE)

        Catch ex As Exception

        End Try


    End Sub
#End Region

#Region "Analysis OreLavoro"
    Private Sub LogoOreLavoroAnalysis()

        Try

            Dim table = New PdfPTable(2)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 216.0F
            table.SetWidths(New Single() {1.0, 1.0})

            Dim Arial = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
            Dim FontCizeta = FontFactory.GetFont("Arial", 48, iTextSharp.text.Font.BOLD, New BaseColor(Drawing.Color.OrangeRed))

            'Dim p = New Paragraph(New Chunk(New iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)))
            Dim LineSeparator = New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, 1)
            Doc.Add(LineSeparator)

            table.AddCell(GetCell("cizeta", 1, 4, FontCizeta, Element.ALIGN_CENTER))
            table.AddCell(GetCell("CIZETA AUTOMAZIONE S.R.L.", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("15057 TORTONA (AL)", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("Via S.FERRARI 20/5", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("p.i. 0096859 0067", Arial, Element.ALIGN_LEFT))
            Doc.Add(table)

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, -5))
            ' Doc.Add(Chunk.NEWLINE)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub IntestazioneOreLavoroAnalysis(Name As String, BeginDate As String, EndDate As String)
        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)
        Dim ArialSmall = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD)

        Try


            Dim table1 = New PdfPTable(7)
            table1.TotalWidth = 530
            table1.LockedWidth = True
            table1.SetWidths(New Single() {50, 230, 50, 80, 50, 80, 30})
            InsertEmptyRow(table1, 6)

            table1.AddCell(GetCell("Nome", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(Name, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table1.AddCell(GetCell("Dal", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(BeginDate, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table1.AddCell(GetCell("Al", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(EndDate, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table1.AddCell(GetCell(" ", ArialSmall, Element.ALIGN_RIGHT))
            InsertEmptyRow(table1, 6)
            Doc.Add(table1)



            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

        Catch ex As Exception

        End Try
    End Sub

    Private Sub TabellaOreLavoroAnalysis(Filter As DatabaseManagement.udtFilterOreLavoro, EmployeeType As Boolean)
        Dim Arial = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)

        Try
            Dim dtAll As DataTable = xDatabase.GetWorkedHoursMonthly(Filter)
            If EmployeeType Then
                Dim Orders As List(Of String) = xDatabase.GetOrdersDoneByUser(Filter)
                For Each ord As String In Orders
                    Filter.OrderName = ord
                    ItemOreLavoroAnalysis(Filter, EmployeeType)
                Next
            Else
                Dim Names As List(Of String) = xDatabase.GetUsersListWhoMakeOrder(Filter)
                For Each name As String In Names
                    Filter.EmployeeName = name
                    ItemOreLavoroAnalysis(Filter, EmployeeType)
                Next
            End If

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

            'Totali
            Dim OreLavoroTot As String = ""
            Dim OreViaggioTot As String = ""
            Dim ore As udtOre = GetOre(dtAll, 4, 5) '4, 5
            OreLavoroTot = TimeSpanToText(ore.Lavoro)
            OreViaggioTot = TimeSpanToText(ore.Viaggio)

            Dim table = New PdfPTable(7)
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 40, 130, 100, 80, 60, 60})

            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Totale ore", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCellWithBorder(OreLavoroTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder(OreViaggioTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            InsertEmptyRow(table, 6)
            Doc.Add(table)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ItemOreLavoroAnalysis(Filter As DatabaseManagement.udtFilterOreLavoro, EmployeeType As Boolean)
        Dim Arial = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)

        Try
            Dim table = New PdfPTable(7)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 50, 120, 100, 80, 60, 60})

            'Intestazione
            table.AddCell(GetCell("Nome ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Giorno ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Commessa ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Attività ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Settore ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("OreLavoro ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("OreViaggio ", ArialBold, Element.ALIGN_CENTER))
            Doc.Add(table)


            table = New PdfPTable(7)
            table.DefaultCell.Border = Rectangle.NO_BORDER
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 50, 120, 100, 80, 60, 60})

            Dim font As Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL)
            Dim PdfPCell As PdfPCell = Nothing
            'Dim dt As DataTable = xDatabase.GetWorkedHoursMonthly(Filter)
            Dim dt As DataTable = xDatabase.GetWorkedHoursByUser(Filter)
            For iRow As Integer = 0 To dt.Rows.Count - 1
                For iCol As Integer = 0 To dt.Columns.Count - 1
                    Dim alignemnt As Integer = Element.ALIGN_CENTER
                    Select Case iCol
                        Case 1, 2, 3
                            alignemnt = Element.ALIGN_CENTER
                        Case Else
                            alignemnt = Element.ALIGN_CENTER
                    End Select
                    Dim str As String = ""
                    If iCol >= 5 Then   '>=4
                        Dim ts As New TimeSpan()
                        ts = ResPublic.TextToTimeSpan(dt.Rows(iRow)(iCol).ToString())
                        str = TimeSpanToText(ts)
                    Else
                        str = dt.Rows(iRow)(iCol).ToString()
                        str = str.Replace("00:00:00", "")
                    End If
                    If iRow Mod (2) = 0 Then
                        table.AddCell(GetCell(str, font, alignemnt, New BaseColor(Drawing.Color.Lavender)))
                    Else
                        table.AddCell(GetCell(str, font, alignemnt))
                    End If

                Next
            Next

            InsertEmptyRow(table, 6)
            Doc.Add(table)

            'Doc.Add(New Paragraph(".", FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL)))
            Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

            'Totali
            Dim OreLavoroTot As String = ""
            Dim OreViaggioTot As String = ""
            Dim ore As udtOre = GetOre(dt, 5, 6)   '4, 5
            OreLavoroTot = TimeSpanToText(ore.Lavoro)
            OreViaggioTot = TimeSpanToText(ore.Viaggio)

            table = New PdfPTable(7)
            table.TotalWidth = 530
            table.LockedWidth = True
            table.SetWidths(New Single() {100, 40, 130, 100, 80, 60, 60})

            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCellWithBorder(OreLavoroTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCellWithBorder(OreViaggioTot, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))

            InsertEmptyRow(table, 6)
            Doc.Add(table)


        Catch ex As Exception

        End Try


    End Sub
#End Region

#Region "Refound"
    Private Sub LogoRefound()

        Try

            Dim table = New PdfPTable(3)
            table.TotalWidth = 780
            table.LockedWidth = True
            table.SetWidths(New Single() {280, 200, 400})

            Dim Arial = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
            Dim FontCizeta = FontFactory.GetFont("Arial", 40, iTextSharp.text.Font.BOLD, New BaseColor(Drawing.Color.OrangeRed))
            Dim FontNotaSpese = FontFactory.GetFont("Arial", 40, iTextSharp.text.Font.BOLD, New BaseColor(Drawing.Color.Blue))

            Dim LineSeparator = New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, 1)
            Doc.Add(LineSeparator)

            table.AddCell(GetCell("cizeta", 1, 4, FontCizeta, Element.ALIGN_CENTER))
            table.AddCell(GetCell("CIZETA AUTOMAZIONE S.R.L.", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("NOTA SPESE", 1, 4, FontNotaSpese, Element.ALIGN_CENTER))

            table.AddCell(GetCell("15057 TORTONA (AL)", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("Via S.FERRARI 20/5", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("p.i. 0096859 0067", Arial, Element.ALIGN_LEFT))

            Doc.Add(table)

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, -5))
            ' Doc.Add(Chunk.NEWLINE)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub IntestazioneRefound(EmployeeName As String, Month As String, Year As String)

        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)
        Dim ArialSmall = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)

        Try

            Dim cfg As New DatabaseManagement.udtEmployeeData
            cfg = xDatabase.EmployeeData(EmployeeName)

            Dim table1 = New PdfPTable(5)
            table1.TotalWidth = 780
            table1.LockedWidth = True
            table1.SetWidths(New Single() {530, 50, 100, 50, 50})
            InsertEmptyRow(table1, 6)
            table1.AddCell(GetCell(" ", ArialSmall, Element.ALIGN_LEFT))
            table1.AddCell(GetCell("Mese", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(Month, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table1.AddCell(GetCell("Anno", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(Year, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            InsertEmptyRow(table1, 4)
            Doc.Add(table1)


            Dim table = New PdfPTable(11)
            table.TotalWidth = 780
            table.LockedWidth = True
            table.SetWidths(New Single() {30, 250, 20, 100, 40, 20, 40, 50, 60, 20, 50})

            table.AddCell(GetCell("Nome", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(EmployeeName, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table.AddCell(GetCell("C.F.", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(cfg.CodiceFiscale, Arial, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Matricola", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(cfg.Matricola.ToString, Arial, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Qualifica", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(cfg.Qualifica, Arial, Element.ALIGN_CENTER))
            'table.AddCell(GetCell("Autovettura", ArialSmall, Element.ALIGN_RIGHT))
            'table.AddCell(GetCell(cfg.Autovettura, Arial, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Auto Aziendale", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(IIf(cfg.AutoAziendale, "SI", "NO"), Arial, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialSmall, Element.ALIGN_CENTER))

            InsertEmptyRow(table, 6)
            Doc.Add(table)

            'Doc.Add(New Paragraph(".", FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.NORMAL)))

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabellaRefound(Filter As DatabaseManagement.udtFilterRefound)

        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)
        Dim ArialSmall = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)

        Dim ColunmnsName() As String = {"Data", "Commessa", "Località", "Km", "Autostrada", "MezziPub", "Vitto", "Alloggio", "Varie", "Diaria", "CCA", "Valuta"}
        tcdRefound = New TableColumnsDefinition(ColunmnsName)

        Try

            Dim table = New PdfPTable(13)
            table.TotalWidth = 780
            table.LockedWidth = True
            table.SetWidths(New Single() {50, 120, 110, 50, 70, 60, 50, 70, 50, 50, 50, 50, 20})

            'Intestazione
            table.AddCell(GetCell("Data", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Commessa", ArialBold, Element.ALIGN_LEFT))
            table.AddCell(GetCell("Località", ArialBold, Element.ALIGN_LEFT))
            table.AddCell(GetCell("Km", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Autostrada", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("MezziPub", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Vitto", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Alloggio", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Varie", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Diaria", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("CCA", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell("Valuta", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
            InsertEmptyRow(table, 6)
            Doc.Add(table)
            Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))


            'Dati
            table = New PdfPTable(13)
            table.TotalWidth = 770
            table.LockedWidth = True
            table.SetWidths(New Single() {50, 120, 100, 50, 70, 60, 50, 70, 50, 50, 50, 50, 20})

            Dim Totali(12) As Single

            Dim font As Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL)
            Dim PdfPCell As PdfPCell = Nothing
            Dim dt As DataTable = xDatabase.ReportEmployeeRefound(Filter)
            'dt.Columns.Remove("TipoRimborso")
            For iRow As Integer = 0 To dt.Rows.Count - 1
                For iCol As Integer = 0 To dt.Columns.Count - 2
                    Dim Value As String = dt.Rows(iRow)(iCol).ToString
                    If iCol = 6 Or iCol = 7 Then
                        If dt.Rows(iRow)(12).ToString = "F" Then        'Se tipo rimborso Forfait
                            Value = "0"
                        End If
                    End If
                    Dim alignment As Integer = Element.ALIGN_LEFT
                    If iCol >= 3 Then
                        alignment = Element.ALIGN_RIGHT
                        Totali(iCol) = Totali(iCol) + TextToSingle(Value)
                    Else
                        Totali(iCol) = 0
                    End If
                    If iRow Mod (2) = 0 Then
                        table.AddCell(GetCell(Value, font, alignment, New BaseColor(Drawing.Color.Lavender)))
                    Else
                        table.AddCell(GetCell(Value, font, alignment))
                    End If
                Next
                table.AddCell(GetCell(" ", font, Element.ALIGN_LEFT))
            Next
            InsertEmptyRow(table, 6)
            Doc.Add(table)
            Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))


            'Sommatoria
            table = New PdfPTable(13)
            table.TotalWidth = 770
            table.LockedWidth = True
            table.SetWidths(New Single() {50, 120, 100, 50, 70, 60, 50, 70, 50, 50, 50, 50, 20})

            table.AddCell(GetCell("TOTALI", ArialBold, Element.ALIGN_CENTER))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_LEFT))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_LEFT))
            table.AddCell(GetCell(Format(Totali(3), "#0.00"), ArialBold, Element.ALIGN_RIGHT))     'KM
            table.AddCell(GetCell(Format(Totali(4), "#0.00"), ArialBold, Element.ALIGN_RIGHT))     'AUTOSTRADA
            table.AddCell(GetCell(Format(Totali(5), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Format(Totali(6), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Format(Totali(7), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Format(Totali(8), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Format(Totali(9), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Format(Totali(10), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Format(Totali(11), "#0.00"), ArialBold, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_LEFT))

            InsertEmptyRow(table, 6)
            Doc.Add(table)
            Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))


            'Rimborso kilometrico
            InsertEmptyRow(table, 10)
            table = New PdfPTable(1)
            table.TotalWidth = 250
            table.LockedWidth = True
            table.HorizontalAlignment = Element.ALIGN_LEFT

            Dim CostoKm As Single = xDatabase.RimborsoKm(Filter.EmployeeName)
            Dim rk As Single = Totali(3) * CostoKm
            Dim Text As String = "Rimborso kilometrico: € " & Format(CostoKm, "#0.00") & " * " & Format(Totali(3), "#0") & " = € " & Format(rk, "#0.00")
            Dim cell As PdfPCell = New PdfPCell(New Phrase(Text, Arial))
            cell.HorizontalAlignment = Element.ALIGN_LEFT
            table.AddCell(cell)
            Doc.Add(table)

            PlaceFooterRefound(Totali, rk)

        Catch ex As Exception

        End Try



    End Sub


    Private Sub PlaceFooterRefound(Totali() As Single, RimbKm As Single)
        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)

        Dim footerTot As PdfPTable = New PdfPTable(10)
        footerTot.TotalWidth = 770
        footerTot.SetWidths(New Single() {80, 80, 80, 80, 80, 80, 100, 80, 100, 10})
        footerTot.LockedWidth = True

        footerTot.AddCell(GetCellWithBorder("Viaggio", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("+Vitto", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("+Alloggio", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("+Varie", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("+Diaria", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("-CCA", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("=Totale spese", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("-Anticipo", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCellWithBorder("=Rimborso", Arial, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
        footerTot.AddCell(GetCell(" ", Arial, Element.ALIGN_CENTER))

        Dim SpeseViaggio As Single = RimbKm + Totali(4) + Totali(5)
        Dim TotSpese As Single = SpeseViaggio + Totali(6) + Totali(7) + Totali(8) + Totali(9) - Totali(10)
        Dim Rimborso As Single = TotSpese - Totali(11)
        footerTot.AddCell(GetCellWithBorder("€ " & Format(SpeseViaggio, "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Totali(6), "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Totali(7), "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Totali(8), "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Totali(9), "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Totali(10), "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(TotSpese, "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Totali(11), "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCellWithBorder("€ " & Format(Rimborso, "#0.00"), Arial, Element.ALIGN_CENTER))
        footerTot.AddCell(GetCell(" ", Arial, Element.ALIGN_CENTER))

        footerTot.WriteSelectedRows(0, -1, 45, 80, Writer.DirectContent)


        Dim str As String = "Tortona il " & Format(Date.Now, "dd/MM/yyyy") & "            Firma ............................................"
        Dim footer As Paragraph = New Paragraph(str, FontFactory.GetFont(FontFactory.TIMES, 10, iTextSharp.text.Font.NORMAL))
        footer.Alignment = Element.ALIGN_RIGHT
        Dim footerTbl As PdfPTable = New PdfPTable(1)
        footerTbl.TotalWidth = 1000
        footerTbl.HorizontalAlignment = Element.ALIGN_CENTER
        Dim cell2 As PdfPCell = New PdfPCell(footer)
        cell2.Border = 0
        cell2.PaddingLeft = 10
        footerTbl.AddCell(cell2)
        footerTbl.WriteSelectedRows(0, -1, 500, 30, Writer.DirectContent)

    End Sub

#End Region

#Region "Analysis Refound"

    Private Sub LogoRefoundAnalysis()

        Try
            Dim table = New PdfPTable(3)
            table.TotalWidth = 780
            table.LockedWidth = True
            table.SetWidths(New Single() {280, 200, 400})

            Dim Arial = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
            Dim FontCizeta = FontFactory.GetFont("Arial", 40, iTextSharp.text.Font.BOLD, New BaseColor(Drawing.Color.OrangeRed))
            Dim FontNotaSpese = FontFactory.GetFont("Arial", 35, iTextSharp.text.Font.BOLD, New BaseColor(Drawing.Color.Blue))

            Dim LineSeparator = New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, 1)
            Doc.Add(LineSeparator)

            table.AddCell(GetCell("cizeta", 1, 4, FontCizeta, Element.ALIGN_CENTER))
            table.AddCell(GetCell("CIZETA AUTOMAZIONE S.R.L.", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("ANALISI SPESE", 1, 4, FontNotaSpese, Element.ALIGN_CENTER))

            table.AddCell(GetCell("15057 TORTONA (AL)", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("Via S.FERRARI 20/5", Arial, Element.ALIGN_LEFT))
            table.AddCell(GetCell("p.i. 0096859 0067", Arial, Element.ALIGN_LEFT))

            Doc.Add(table)

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, -5))

        Catch ex As Exception

        End Try

    End Sub
    Private Sub IntestazioneRefoundAnalysis(Name As String, BeginDate As String, EndDate As String)
        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)
        Dim ArialSmall = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD)

        Try

            Dim table1 = New PdfPTable(5)
            table1.TotalWidth = 780
            table1.LockedWidth = True
            table1.SetWidths(New Single() {480, 50, 100, 50, 100})
            InsertEmptyRow(table1, 6)

            table1.AddCell(GetCell(" ", ArialSmall, Element.ALIGN_LEFT))
            table1.AddCell(GetCell("Dal", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(BeginDate, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            table1.AddCell(GetCell("Al", ArialSmall, Element.ALIGN_RIGHT))
            table1.AddCell(GetCell(EndDate, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            InsertEmptyRow(table1, 4)
            Doc.Add(table1)

            Dim table = New PdfPTable(2)
            table.TotalWidth = 780
            table.LockedWidth = True
            table.SetWidths(New Single() {30, 250})
            table.AddCell(GetCell("Nome", ArialSmall, Element.ALIGN_RIGHT))
            table.AddCell(GetCell(Name, ArialBold, Element.ALIGN_CENTER, New BaseColor(Drawing.Color.PaleTurquoise)))
            InsertEmptyRow(table, 6)
            Doc.Add(table)

            Doc.Add(New LineSeparator(2.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

        Catch ex As Exception

        End Try

    End Sub

    Private Sub TabellaRefoundAnalysis(Filter As DatabaseManagement.udtFilterRefound, EmployeeType As Boolean)
        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)
        Dim ArialSmall = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)



        Try

            'Dati analisi
            If EmployeeType Then
                Dim Orders As List(Of String) = xDatabase.GetOrdersDoneByUserWithRefound(Filter)
                For Each ord As String In Orders
                    Filter.OrderName = ord
                    ItemRefoundAnalysis(Filter, EmployeeType)
                Next
            Else
                Dim Names As List(Of String) = xDatabase.GetUsersListWhoMakeOrderWithRefound(Filter)
                For Each name As String In Names
                    Filter.EmployeeName = name
                    ItemRefoundAnalysis(Filter, EmployeeType)
                Next
            End If


        Catch ex As Exception

        End Try

    End Sub

    Private Sub ItemRefoundAnalysis(Filter As DatabaseManagement.udtFilterRefound, EmployeeType As Boolean)
        Dim Arial = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.NORMAL)
        Dim ArialBold = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD)
        Dim ArialBoldTot = FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)
        Dim ArialSmall = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL)

        Dim ColunmnsName() As String = {"Nome", "Data", "Commessa", "Località", "Km", "Autostrada", "Mezzi", "Vitto", "Alloggio", "Varie"}
        tcdRefound = New TableColumnsDefinition(ColunmnsName)

        Dim table = New PdfPTable(11)
        table.TotalWidth = 780
        table.LockedWidth = True
        table.SetWidths(New Single() {120, 50, 120, 110, 50, 70, 60, 50, 70, 50, 20})

        'Intestazione
        table.AddCell(GetCell("Nome", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Data", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Commessa", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Località", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Km", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Autostrada", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Mezzi", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Vitto", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Alloggio", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell("Varie", ArialBold, Element.ALIGN_CENTER))
        table.AddCell(GetCell(" ", ArialBold, Element.ALIGN_CENTER))
        InsertEmptyRow(table, 6)
        Doc.Add(table)
        Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

        table = New PdfPTable(11)
        table.TotalWidth = 770
        table.LockedWidth = True
        table.SetWidths(New Single() {120, 50, 120, 110, 50, 70, 60, 50, 70, 50, 20})

        Dim Totali(10) As Single
        Dim font As Font = FontFactory.GetFont("Arial", 7, iTextSharp.text.Font.NORMAL)
        Dim PdfPCell As PdfPCell = Nothing

        Dim dt As New DataTable
        dt = xDatabase.GetUserAnalysisRefound(Filter)
        For iRow As Integer = 0 To dt.Rows.Count - 1
            For iCol As Integer = 0 To dt.Columns.Count - 1
                Dim Value As String = dt.Rows(iRow)(iCol).ToString
                Value = Value.Replace("00:00:00", "")
                Dim alignment As Integer = Element.ALIGN_CENTER
                If iCol >= 4 Then 'se una colonna spese
                    alignment = Element.ALIGN_RIGHT
                    Totali(iCol) = Totali(iCol) + TextToSingle(Value)
                Else
                    Totali(iCol) = 0
                End If
                If iRow Mod (2) = 0 Then 'se riga pari cambio colore
                    table.AddCell(GetCell(Value, font, alignment, New BaseColor(Drawing.Color.Lavender)))
                Else
                    table.AddCell(GetCell(Value, font, alignment))
                End If
            Next
            table.AddCell(GetCell(" ", font, Element.ALIGN_LEFT))
        Next
        InsertEmptyRow(table, 6)
        Doc.Add(table)
        Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

        'Sommatoria
        table = New PdfPTable(11)
        table.TotalWidth = 770
        table.LockedWidth = True
        table.SetWidths(New Single() {120, 50, 120, 110, 50, 70, 60, 50, 70, 50, 20})

        If EmployeeType Then
            table.AddCell(GetCell("TOTALI " & Filter.OrderName, ArialBoldTot, Element.ALIGN_CENTER))
        Else
            table.AddCell(GetCell("TOTALI " & Filter.EmployeeName, ArialBoldTot, Element.ALIGN_CENTER))
        End If
        'table.AddCell(GetCell("TOTALI", ArialBoldTot, Element.ALIGN_CENTER))
        table.AddCell(GetCell(" ", ArialBoldTot, Element.ALIGN_LEFT))
        table.AddCell(GetCell(" ", ArialBoldTot, Element.ALIGN_LEFT))
        table.AddCell(GetCell(" ", ArialBoldTot, Element.ALIGN_LEFT))
        table.AddCell(GetCell(Format(Totali(4), "#0.00"), ArialBoldTot, Element.ALIGN_RIGHT))     'KM
        table.AddCell(GetCell(Format(Totali(5), "#0.00"), ArialBoldTot, Element.ALIGN_RIGHT))     'AUTOSTRADA
        table.AddCell(GetCell(Format(Totali(6), "#0.00"), ArialBoldTot, Element.ALIGN_RIGHT))
        table.AddCell(GetCell(Format(Totali(7), "#0.00"), ArialBoldTot, Element.ALIGN_RIGHT))
        table.AddCell(GetCell(Format(Totali(8), "#0.00"), ArialBoldTot, Element.ALIGN_RIGHT))
        table.AddCell(GetCell(Format(Totali(9), "#0.00"), ArialBoldTot, Element.ALIGN_RIGHT))
        table.AddCell(GetCell(" ", ArialBoldTot, Element.ALIGN_LEFT))

        InsertEmptyRow(table, 6)
        Doc.Add(table)
        Doc.Add(New LineSeparator(1.0F, 100.0F, New BaseColor(Drawing.Color.Black), Element.ALIGN_LEFT, +5))

    End Sub
#End Region


    Private Sub InsertEmptyRow(ByRef table As PdfPTable, fontSize As Integer)
        Dim font = FontFactory.GetFont("Arial", fontSize, iTextSharp.text.Font.NORMAL)
        For iRow As Integer = 0 To table.NumberOfColumns - 1
            table.AddCell(GetCell(" ", font, Element.ALIGN_LEFT))
        Next
    End Sub
    Private Function GetCell(ByVal text As String, f As Font, alignment As Integer, BackColor As BaseColor) As PdfPCell
        Return GetCell(text, 1, 1, f, alignment, BackColor)
    End Function
    Private Function GetCell(ByVal text As String, f As Font, alignment As Integer) As PdfPCell
        Return GetCell(text, 1, 1, f, alignment, Nothing)
    End Function
    Private Function GetCell(ByVal text As String, ByVal colSpan As Integer, ByVal rowSpan As Integer, f As Font, alignment As Integer) As PdfPCell
        Return GetCell(text, colSpan, rowSpan, f, alignment, New BaseColor(Drawing.Color.Transparent))
    End Function
    Private Function GetCell(ByVal text As String, ByVal colSpan As Integer, ByVal rowSpan As Integer, f As Font, alignment As Integer, BackColor As BaseColor) As PdfPCell
        Dim cell As PdfPCell = New PdfPCell(New Phrase(text, f))
        cell.HorizontalAlignment = alignment
        ' cell.VerticalAlignment = Element.ALIGN_TOP
        cell.Rowspan = rowSpan
        cell.Colspan = colSpan
        cell.Border = Rectangle.NO_BORDER
        cell.BackgroundColor = BackColor
        Return cell
    End Function

    Private Function GetCellWithBorder(ByVal text As String, f As Font, alignment As Integer, BackColor As BaseColor) As PdfPCell
        Return GetCellWithBorder(text, 1, 1, f, alignment, BackColor)
    End Function
    Private Function GetCellWithBorder(ByVal text As String, f As Font, alignment As Integer) As PdfPCell
        Return GetCellWithBorder(text, 1, 1, f, alignment, Nothing)
    End Function
    Private Function GetCellWithBorder(ByVal text As String, ByVal colSpan As Integer, ByVal rowSpan As Integer, f As Font, alignment As Integer) As PdfPCell
        Return GetCellWithBorder(text, colSpan, rowSpan, f, alignment, New BaseColor(Drawing.Color.Transparent))
    End Function
    Private Function GetCellWithBorder(ByVal text As String, ByVal colSpan As Integer, ByVal rowSpan As Integer, f As Font, alignment As Integer, BackColor As BaseColor) As PdfPCell
        Dim cell As PdfPCell = New PdfPCell(New Phrase(text, f))
        cell.HorizontalAlignment = alignment
        ' cell.VerticalAlignment = Element.ALIGN_TOP
        cell.Rowspan = rowSpan
        cell.Colspan = colSpan
        'cell.Border = Rectangle.NO_BORDER
        cell.BackgroundColor = BackColor
        Return cell
    End Function


    Private Sub PlaceText(ByVal pdfContentByte As PdfContentByte, ByVal text As String, ByVal font As iTextSharp.text.Font, ByVal lowerLeftx As Single, ByVal lowerLefty As Single, ByVal upperRightx As Single, ByVal upperRighty As Single, ByVal leading As Single, ByVal alignment As Integer)
        Dim ct As ColumnText = New ColumnText(pdfContentByte)
        ct.SetSimpleColumn(New Phrase(text, font), lowerLeftx, lowerLefty, upperRightx, upperRighty, leading, alignment)
        ct.Go()
    End Sub





    'Private Sub ExportDataToPDFTable()
    '    Dim doc As New Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35)
    '    Try

    '        Dim pdfFilePath As String = "/pdf/myPdf.pdf"

    '        'Create Document class object and set its size to letter and give space left, right, Top, Bottom Margin
    '        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(pdfFilePath, FileMode.Create))

    '        doc.Open()
    '        'Open Document to write
    '        Dim font8 As Font = FontFactory.GetFont("ARIAL", 7)

    '        'Write some content
    '        Dim paragraph As New Paragraph("Using ITextsharp I am going to show how to create simple table in PDF document ")

    '        Dim dt As DataTable = GetDataTable()

    '        If dt IsNot Nothing Then
    '            'Craete instance of the pdf table and set the number of column in that table
    '            Dim PdfTable As New PdfPTable(dt.Columns.Count)
    '            Dim PdfPCell As PdfPCell = Nothing


    '            'Add Header of the pdf table
    '            PdfPCell = New PdfPCell(New Phrase(New Chunk("ID", font8)))
    '            PdfTable.AddCell(PdfPCell)

    '            PdfPCell = New PdfPCell(New Phrase(New Chunk("Name", font8)))
    '            PdfTable.AddCell(PdfPCell)


    '            'How add the data from datatable to pdf table
    '            For rows As Integer = 0 To dt.Rows.Count - 1
    '                For column As Integer = 0 To dt.Columns.Count - 1
    '                    PdfPCell = New PdfPCell(New Phrase(New Chunk(dt.Rows(rows)(column).ToString(), font8)))
    '                    PdfTable.AddCell(PdfPCell)
    '                Next
    '            Next

    '            PdfTable.SpacingBefore = 15.0F
    '            ' Give some space after the text or it may overlap the table
    '            doc.Add(paragraph)
    '            ' add paragraph to the document
    '            ' add pdf table to the document
    '            doc.Add(PdfTable)

    '        End If
    '    Catch docEx As DocumentException
    '        'handle pdf document exception if any
    '    Catch ioEx As IOException
    '        ' handle IO exception
    '    Catch ex As Exception
    '        ' ahndle other exception if occurs
    '    Finally
    '        'Close document and writer

    '        doc.Close()
    '    End Try
    'End Sub
    'Private Function GetDataTable() As DataTable
    '    Dim dtOreLavoro As New DataTable

    '    Dim Filter As New DatabaseManagement.udtFilterOreLavoro
    '    Filter.EmployeeName = "Boveri Enzo"
    '    Filter.OrderName = "%"
    '    Filter.Activity = "%"
    '    Filter.Sector = "%"
    '    Filter.BeginDate = CDate("2018-11-01")
    '    Filter.EndDate = CDate("2018-11-30")
    '    dtOreLavoro = xDatabase.GetWorkedHoursMonthly(Filter)

    '    Return dtOreLavoro

    'End Function








    Private Sub cmdPrint_Click(FileName As String)

        Try

            'Get de the default printer in the system
            PrinterToUseSetting = DocumentPrinter.GetDefaultPrinterSetting

            'uncomment if you want to change the default printer before print
            DocumentPrinter.ChangePrinterSettings(PrinterToUseSetting)


            'print your file 
            If DocumentPrinter.PrintFile(FileName, PrinterToUseSetting) Then
                'MsgBox("your print file success message")
            Else
                'MsgBox("your print file failed message")
            End If

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub




    Public NotInheritable Class DocumentPrinter

        Shared Sub New()

        End Sub

        Public Shared Function PrintFile(ByVal fileName As String, printerSetting As System.Drawing.Printing.PrinterSettings) As Boolean

            Dim printProcess As System.Diagnostics.Process = Nothing
            Dim printed As Boolean = False


            Try

                If printerSetting IsNot Nothing Then

                    Dim startInfo As New ProcessStartInfo()
                    startInfo.Verb = "Print"
                    startInfo.Arguments = printerSetting.PrinterName.ToString     ' <----printer to use---- 
                    startInfo.FileName = fileName
                    startInfo.UseShellExecute = True
                    startInfo.CreateNoWindow = True
                    startInfo.WindowStyle = ProcessWindowStyle.Hidden

                    Using print As System.Diagnostics.Process = Process.Start(startInfo)

                        'Close the application after X milliseconds with WaitForExit(X)   

                        print.WaitForExit(10000)

                        If print.HasExited = False Then

                            If print.CloseMainWindow() Then
                                printed = True
                            Else
                                printed = True
                            End If

                        Else
                            printed = True

                        End If

                        print.Close()

                    End Using


                Else
                    Throw New Exception("Stampante non trovata...")
                End If


            Catch ex As Exception
                Throw
            End Try

            Return printed

        End Function

        Public Shared Sub ChangePrinterSettings(ByRef defaultPrinterSetting As System.Drawing.Printing.PrinterSettings)

            Dim printDialogBox As New System.Windows.Forms.PrintDialog

            If printDialogBox.ShowDialog = System.Windows.Forms.DialogResult.OK Then

                If printDialogBox.PrinterSettings.IsValid Then
                    defaultPrinterSetting = printDialogBox.PrinterSettings
                End If

            End If

        End Sub

        Public Shared Function GetDefaultPrinterSetting() As System.Drawing.Printing.PrinterSettings

            Dim defaultPrinterSetting As System.Drawing.Printing.PrinterSettings = Nothing

            For Each printer As String In System.Drawing.Printing.PrinterSettings.InstalledPrinters


                defaultPrinterSetting = New System.Drawing.Printing.PrinterSettings
                defaultPrinterSetting.PrinterName = printer

                If defaultPrinterSetting.IsDefaultPrinter Then
                    Return defaultPrinterSetting
                End If

            Next

            Return defaultPrinterSetting

        End Function

    End Class

End Class
