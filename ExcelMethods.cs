using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExcelLibrary.SpreadSheet;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace SelfAssessment
{
    class ExcelMethods
    {
        /*public static void CreateExcelFile(List<List<string>> answersHistory, string savePath)
        {
            WorkBook xlsxWorkbook = WorkBook.Create(ExcelFileFormat.XLSX);
            xlsxWorkbook.Metadata.Author = "IronXL";
            WorkSheet xlsSheet = xlsxWorkbook.CreateWorkSheet("Answers");

            for (int i = 0; i < answersHistory[0].Count; i++ )
            {
                xlsSheet[$"A{i+1}"].Value = Program.PIB;
                xlsSheet[$"B{i+1}"].Value = answersHistory[0][i];
                xlsSheet[$"C{i+1}"].Value = answersHistory[1][i];
            }
            xlsxWorkbook.SaveAs(savePath);
        }*/

        public static void ExcelFileCreate2(List<List<string>> answersHistory, string savePath)
        {
            //создание файла
            string file = @"C:\Users\Denis\Desktop\test.xls";
            Workbook workbook = new Workbook();
            Worksheet worksheet = new Worksheet("Первый Лист");
            
            for (int i = 0; i < answersHistory[0].Count; i++)
            {
                worksheet.Cells[i, 0] = new Cell(Program.PIB);
                worksheet.Cells[i, 1] = new Cell(answersHistory[0][i]);
                worksheet.Cells[i, 2] = new Cell(answersHistory[1][i]);
            }
            
            workbook.Worksheets.Add(worksheet);
            workbook.Save(savePath);
            MessageBox.Show($"Excel файл був створений, Ви можете знайти його в {savePath}");
        }

        public static void ExcelFileCreate3(List<List<string>> answersHistory, string savePath)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }

            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            for (int i = 1; i < answersHistory[0].Count + 1; i++)
            {
                xlWorkSheet.Cells[i, "A"] = Program.PIB;
                xlWorkSheet.Cells[i, "B"] = answersHistory[1][i - 1];
                xlWorkSheet.Cells[i, "C"] = answersHistory[2][i - 1];
            }

            xlWorkBook.SaveAs(@savePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show($"Excel файл був створений, Ви можете знайти його в {savePath}");
        }
    }
}
