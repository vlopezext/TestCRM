using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Windows.Markup;
using System.Collections;
using System.IO;

using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Ap = DocumentFormat.OpenXml.ExtendedProperties;
using Vt = DocumentFormat.OpenXml.VariantTypes;
using X14 = DocumentFormat.OpenXml.Office2010.Excel;
using A = DocumentFormat.OpenXml.Drawing;

namespace GESTCRM.Clases
{
    public class ExportToExcel
    {
        private ArrayList _Filas = new ArrayList();
        private string[] _cols = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "AA" };
        private static string _sheetName = "Informe";
        private string _sTitulo = "";
        private string _sSubTitulo = "";
        private string _sSubTitulo2 = "";
        private List<string> _lsCabeceras = new List<string>();
        private List<string[]> _lsLineas = new List<string[]>();

        public ExportToExcel()
        {
        }


        public ExportToExcel(string fileName, string sheetName, string titulo, string subtitulo, string subtitulo2, List<string> cabecera, List<string[]> lineas)
        {
            _sheetName = sheetName;
            _sTitulo = titulo;
            _sSubTitulo = subtitulo;
            _sSubTitulo2 = subtitulo2;
            _lsCabeceras = cabecera;
            _lsLineas = lineas;

            CreaExcel(fileName);
        }


        public void CreaExcel(string fileName)
        {
            using (var document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook, true))
            {
                CreateParts(document);
            }
        }

        public void CreateParts(SpreadsheetDocument document)
        {
            WorkbookPart workbookPart = document.AddWorkbookPart();
            CreateWorkbookPartContent(workbookPart);

            WorkbookStylesPart workbookStylesPart1 = workbookPart.AddNewPart<WorkbookStylesPart>("Id1");
            GenerateWorkbookStylesPart1Content(workbookStylesPart1);

            WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>("IdSheet");
            GenerateWorksheetContent(worksheetPart);
        }


        private static void CreateWorkbookPartContent(WorkbookPart workbookPart)
        {
            var workbook = new Workbook();

            var sheets = new Sheets();
            var sheet = new Sheet { Name = _sheetName, SheetId = 1, Id = "IdSheet" };
            sheets.Append(sheet);

            workbook.Append(sheets);

            workbookPart.Workbook = workbook;
        }


        private void GenerateWorksheetContent(WorksheetPart worksheetPart1)
        {
            var worksheet1 = new Worksheet();

            SheetData sheetData1 = new SheetData();

            UInt32Value rowIndex = 1;

            //Títol
            if (_sTitulo != null && _sTitulo.Trim() != "")
            {
                Row rowTitulo = new Row() { RowIndex = (UInt32Value)rowIndex };
                Cell cell = new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(_sTitulo), DataType = CellValues.String, StyleIndex = (UInt32Value)2U };
                rowTitulo.Append(cell);
                sheetData1.Append(rowTitulo);

                rowIndex++;

                ////Fila en blanc
                //Row rowBlanc = new Row() { RowIndex = (UInt32Value)rowIndex };
                //Cell cellBlanc = new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(""), DataType = CellValues.String };

                //rowBlanc.Append(cellBlanc);
                //sheetData1.Append(rowBlanc);
                
                //rowIndex++;
            }

            //Subtítol
            if (_sSubTitulo != null && _sSubTitulo.Trim() != "")
            {
                Row rowSubTitulo = new Row() { RowIndex = (UInt32Value)rowIndex };
                Cell cell = new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(_sSubTitulo), DataType = CellValues.String, StyleIndex = 4U };
                rowSubTitulo.Append(cell);
                sheetData1.Append(rowSubTitulo);

                rowIndex++;

                ////Fila en blanc
                //Row rowBlanc = new Row() { RowIndex = (UInt32Value)rowIndex };
                //Cell cellBlanc = new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(""), DataType = CellValues.String };

                //rowBlanc.Append(cellBlanc);
                //sheetData1.Append(rowBlanc);

                //rowIndex++;
            }

            //Subtítol
            if (_sSubTitulo2 != null && _sSubTitulo2.Trim() != "")
            {
                Row rowSubTitulo = new Row() { RowIndex = (UInt32Value)rowIndex };
                Cell cell = new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(_sSubTitulo2), DataType = CellValues.String, StyleIndex = 4U };
                rowSubTitulo.Append(cell);
                sheetData1.Append(rowSubTitulo);

                rowIndex++;

                //Fila en blanc
                Row rowBlanc = new Row() { RowIndex = (UInt32Value)rowIndex };
                Cell cellBlanc = new Cell() { CellReference = "A" + rowIndex.ToString(), CellValue = new CellValue(""), DataType = CellValues.String };

                rowBlanc.Append(cellBlanc);
                sheetData1.Append(rowBlanc);

                rowIndex++;
            }


            //Cabecera
            int colIndex = 1;
            Row row = new Row() { RowIndex = (UInt32Value)rowIndex };
            foreach (string valorCelda in _lsCabeceras)
            {
                Cell cell = new Cell() { CellReference = _cols[colIndex - 1] + rowIndex.ToString(), CellValue = new CellValue(valorCelda), DataType = CellValues.String, StyleIndex = (UInt32Value)3U };
                row.Append(cell);
                colIndex++;
            }

            sheetData1.Append(row);
            rowIndex++;


            //Filas
            foreach (string[] lin in _lsLineas)
            {
                colIndex = 1;
                Row rowlin = new Row() { RowIndex = (UInt32Value)rowIndex };

                foreach (string valorCelda in lin) 
                {
                    if (Utiles.IsDecimal(valorCelda))
                    {
                        Cell cell = new Cell() { CellReference = _cols[colIndex - 1] + rowIndex.ToString(), CellValue = new CellValue(valorCelda), DataType = CellValues.Number, StyleIndex = 1U };
                        rowlin.Append(cell);
                    }
                    else
                    {
                        Cell cell = new Cell() { CellReference = _cols[colIndex - 1] + rowIndex.ToString(), CellValue = new CellValue(valorCelda), DataType = CellValues.String, StyleIndex = 5U };
                        rowlin.Append(cell);
                    }

                    colIndex++;
                }

                sheetData1.Append(rowlin);
                rowIndex++;
            }

            worksheet1.Append(sheetData1);
            worksheetPart1.Worksheet = worksheet1;

        }


        private void GenerateWorkbookStylesPart1Content(WorkbookStylesPart workbookStylesPart1)
        {
            Stylesheet stylesheet1 = new Stylesheet() { MCAttributes = new MarkupCompatibilityAttributes() { Ignorable = "x14ac" } };
            stylesheet1.AddNamespaceDeclaration("mc", "http://schemas.openxmlformats.org/markup-compatibility/2006");
            stylesheet1.AddNamespaceDeclaration("x14ac", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/ac");

            Fonts fonts1 = new Fonts() { Count = (UInt32Value)6U, KnownFonts = true };

            Font font1 = new Font();
            FontSize fontSize1 = new FontSize() { Val = 11D };
            Color color1 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName1 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering1 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme1 = new FontScheme() { Val = FontSchemeValues.Minor };

            font1.Append(fontSize1);
            font1.Append(color1);
            font1.Append(fontName1);
            font1.Append(fontFamilyNumbering1);
            font1.Append(fontScheme1);

            Font font2 = new Font();
            Bold bold1 = new Bold();
            FontSize fontSize2 = new FontSize() { Val = 18D };
            Color color2 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName2 = new FontName() { Val = "Verdana" };
            FontFamilyNumbering fontFamilyNumbering2 = new FontFamilyNumbering() { Val = 2 };

            font2.Append(bold1);
            font2.Append(fontSize2);
            font2.Append(color2);
            font2.Append(fontName2);
            font2.Append(fontFamilyNumbering2);

            Font font3 = new Font();
            Bold bold2 = new Bold();
            FontSize fontSize3 = new FontSize() { Val = 14D };
            Color color3 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName3 = new FontName() { Val = "Verdana" };
            FontFamilyNumbering fontFamilyNumbering3 = new FontFamilyNumbering() { Val = 2 };

            font3.Append(bold2);
            font3.Append(fontSize3);
            font3.Append(color3);
            font3.Append(fontName3);
            font3.Append(fontFamilyNumbering3);

            Font font4 = new Font();
            Bold bold3 = new Bold();
            FontSize fontSize4 = new FontSize() { Val = 11D };
            Color color4 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName4 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering4 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme2 = new FontScheme() { Val = FontSchemeValues.Minor };

            font4.Append(bold3);
            font4.Append(fontSize4);
            font4.Append(color4);
            font4.Append(fontName4);
            font4.Append(fontFamilyNumbering4);
            font4.Append(fontScheme2);

            Font font5 = new Font();
            Bold bold4 = new Bold();
            FontSize fontSize5 = new FontSize() { Val = 12D };
            Color color5 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName5 = new FontName() { Val = "Verdana" };
            FontFamilyNumbering fontFamilyNumbering5 = new FontFamilyNumbering() { Val = 2 };

            font5.Append(bold4);
            font5.Append(fontSize5);
            font5.Append(color5);
            font5.Append(fontName5);
            font5.Append(fontFamilyNumbering5);

            Font font6 = new Font();
            FontSize fontSize6 = new FontSize() { Val = 11D };
            Color color6 = new Color() { Theme = (UInt32Value)1U };
            FontName fontName6 = new FontName() { Val = "Calibri" };
            FontFamilyNumbering fontFamilyNumbering6 = new FontFamilyNumbering() { Val = 2 };
            FontScheme fontScheme3 = new FontScheme() { Val = FontSchemeValues.Minor };

            font6.Append(fontSize6);
            font6.Append(color6);
            font6.Append(fontName6);
            font6.Append(fontFamilyNumbering6);
            font6.Append(fontScheme3);

            fonts1.Append(font1);
            fonts1.Append(font2);
            fonts1.Append(font3);
            fonts1.Append(font4);
            fonts1.Append(font5);
            fonts1.Append(font6);

            Fills fills1 = new Fills() { Count = (UInt32Value)2U };

            Fill fill1 = new Fill();
            PatternFill patternFill1 = new PatternFill() { PatternType = PatternValues.None };

            fill1.Append(patternFill1);

            Fill fill2 = new Fill();
            PatternFill patternFill2 = new PatternFill() { PatternType = PatternValues.Gray125 };

            fill2.Append(patternFill2);

            fills1.Append(fill1);
            fills1.Append(fill2);

            Borders borders1 = new Borders() { Count = (UInt32Value)2U };

            Border border1 = new Border();
            LeftBorder leftBorder1 = new LeftBorder();
            RightBorder rightBorder1 = new RightBorder();
            TopBorder topBorder1 = new TopBorder();
            BottomBorder bottomBorder1 = new BottomBorder();
            DiagonalBorder diagonalBorder1 = new DiagonalBorder();

            border1.Append(leftBorder1);
            border1.Append(rightBorder1);
            border1.Append(topBorder1);
            border1.Append(bottomBorder1);
            border1.Append(diagonalBorder1);

            Border border2 = new Border();
            LeftBorder leftBorder2 = new LeftBorder();
            RightBorder rightBorder2 = new RightBorder();
            TopBorder topBorder2 = new TopBorder();

            BottomBorder bottomBorder2 = new BottomBorder() { Style = BorderStyleValues.Thin };
            Color color7 = new Color() { Indexed = (UInt32Value)64U };

            bottomBorder2.Append(color7);
            DiagonalBorder diagonalBorder2 = new DiagonalBorder();

            border2.Append(leftBorder2);
            border2.Append(rightBorder2);
            border2.Append(topBorder2);
            border2.Append(bottomBorder2);
            border2.Append(diagonalBorder2);

            borders1.Append(border1);
            borders1.Append(border2);

            CellStyleFormats cellStyleFormats1 = new CellStyleFormats() { Count = (UInt32Value)1U };
            CellFormat cellFormat1 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U };

            cellStyleFormats1.Append(cellFormat1);

            Alignment alignment1 = new Alignment() { Horizontal = HorizontalAlignmentValues.Left };
            Alignment alignment2 = new Alignment() { Horizontal = HorizontalAlignmentValues.Center };
            Alignment alignment3 = new Alignment() { Horizontal = HorizontalAlignmentValues.Right };

            CellFormats cellFormats1 = new CellFormats() { Count = (UInt32Value)6U };
            CellFormat cellFormat2 = new CellFormat() { NumberFormatId = (UInt32Value)4U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U };
            CellFormat cellFormat3 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)0U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true };
            CellFormat cellFormat4 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)2U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true };
            CellFormat cellFormat5 = new CellFormat() { NumberFormatId = (UInt32Value)4U, FontId = (UInt32Value)3U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)1U, FormatId = (UInt32Value)0U, ApplyFont = true, ApplyBorder = true };
            CellFormat cellFormat6 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)4U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true };
            CellFormat cellFormat7 = new CellFormat() { NumberFormatId = (UInt32Value)0U, FontId = (UInt32Value)5U, FillId = (UInt32Value)0U, BorderId = (UInt32Value)0U, FormatId = (UInt32Value)0U, ApplyFont = true };

            cellFormat2.Alignment = alignment3;

            cellFormats1.Append(cellFormat2);
            cellFormats1.Append(cellFormat3);
            cellFormats1.Append(cellFormat4);
            cellFormats1.Append(cellFormat5);
            cellFormats1.Append(cellFormat6);
            cellFormats1.Append(cellFormat7);

            CellStyles cellStyles1 = new CellStyles() { Count = (UInt32Value)1U };
            CellStyle cellStyle1 = new CellStyle() { Name = "Normal", FormatId = (UInt32Value)0U, BuiltinId = (UInt32Value)0U };

            cellStyles1.Append(cellStyle1);
            DifferentialFormats differentialFormats1 = new DifferentialFormats() { Count = (UInt32Value)0U };
            TableStyles tableStyles1 = new TableStyles() { Count = (UInt32Value)0U, DefaultTableStyle = "TableStyleMedium2", DefaultPivotStyle = "PivotStyleMedium9" };

            StylesheetExtensionList stylesheetExtensionList1 = new StylesheetExtensionList();

            StylesheetExtension stylesheetExtension1 = new StylesheetExtension() { Uri = "{EB79DEF2-80B8-43e5-95BD-54CBDDF9020C}" };
            stylesheetExtension1.AddNamespaceDeclaration("x14", "http://schemas.microsoft.com/office/spreadsheetml/2009/9/main");
            X14.SlicerStyles slicerStyles1 = new X14.SlicerStyles() { DefaultSlicerStyle = "SlicerStyleLight1" };

            stylesheetExtension1.Append(slicerStyles1);

            stylesheetExtensionList1.Append(stylesheetExtension1);

            stylesheet1.Append(fonts1);
            stylesheet1.Append(fills1);
            stylesheet1.Append(borders1);
            stylesheet1.Append(cellStyleFormats1);
            stylesheet1.Append(cellFormats1);
            stylesheet1.Append(cellStyles1);
            stylesheet1.Append(differentialFormats1);
            stylesheet1.Append(tableStyles1);
            stylesheet1.Append(stylesheetExtensionList1);


            workbookStylesPart1.Stylesheet = stylesheet1;

        }


        public void OpenExcel(string fileName)
        {
            SpreadsheetDocument.Open(fileName, true);
        }
    }
}
