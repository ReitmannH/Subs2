using System;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace Subs.Data
{
    public class ExcelIO
    {
        private Excel.Application gApp = new Excel.Application();
        private readonly Excel.Workbook gWorkBook;
        private Excel._Worksheet gWorkSheet;


        public ExcelIO(string pExcelFile)
        {
            try
            {
                gWorkBook = gApp.Workbooks.Open(pExcelFile,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value,
                Missing.Value);
                gApp.Visible = false;
                gApp.Interactive = false;

                gWorkSheet = (Excel._Worksheet)gWorkBook.Worksheets["Sheet1"];
                gWorkSheet.Activate();
            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "ExcelIO", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return;
            }

        }

        public bool IsVisible
        {
            set
            {
                if ((bool)value)
                {
                    gApp.Visible = true;
                    gApp.Interactive = true;
                }
                else
                {
                    gApp.Visible = false;
                    gApp.Interactive = false;
                }
            }
        }


        public string SelectSheet(string pSheet)
        {
            try
            {
                gWorkSheet = (Excel._Worksheet)gWorkBook.Worksheets[pSheet];
                gWorkSheet.Activate();
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string AddRow(string pDefinedName)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target = gWorkSheet.Range[pDefinedName];
                int lRowCount = Target.Rows.Count;
                Excel.Range lEntryPoint = (Excel.Range)gWorkSheet.Rows[Target.Row + lRowCount - 1, Missing.Value];
                //lEntryPoint.Interior.Color = Excel.XlRgbColor.rgbGold;
                lEntryPoint.Insert(Excel.XlDirection.xlDown);

                Excel.Range lNewRow = (Excel.Range)gWorkSheet.Rows[Target.Row + lRowCount - 2, Missing.Value];
                lEntryPoint.Copy(lNewRow);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public string PutCellString(string pDefinedName, int pRow, int pColumn, string pContent)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target = gWorkSheet.Range[pDefinedName];
                Target.Cells[pRow, pColumn].Value = pContent;
                return "OK";
            }

            catch (Exception ex)
            {
                Exception CurrentException = ex;
                return ex.Message;
            }

        }

        public string PutCellInteger(string pDefinedName, int pRow, int pColumn, int pContent)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target = gWorkSheet.Range[pDefinedName];
                Target.Cells[pRow, pColumn].Value = pContent;
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }


        public string PutCellDecimal(string pDefinedName, int pRow, int pColumn, decimal pContent)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target = gWorkSheet.Range[pDefinedName];
                Target.Cells[pRow, pColumn].Value = pContent;
                return "OK";
            }

            catch (Exception ex)
            {

                return ex.Message;
            }

        }


        public string PutCellDate(string pDefinedName, int pRow, int pColumn, DateTime pContent)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target = gWorkSheet.Range[pDefinedName];
                Target.Cells[pRow, pColumn].Value = pContent;
                return "OK";
            }

            catch (Exception ex)
            {
                Exception CurrentException = ex;
                return ex.Message;
            }
        }


        public string GetCell(int Row, int Column, ref decimal Result)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target;
                Target = (Microsoft.Office.Interop.Excel.Range)gWorkSheet.Cells[Row, Column];
                Target.Activate();
                if (Target.Value2 == null)
                { Result = 0; }
                else
                {
                    Result = System.Convert.ToDecimal(Target.Value2);
                }
                return "OK";
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }

        public string Save(string pOutputFile)
        {
            string lStage = "";

            try
            {
                SelectSheet("Sheet1");
                lStage = "xlsx";
                gWorkSheet.SaveAs(pOutputFile);
                lStage = "pdf";
                string lPDFFile = pOutputFile.Replace(".xlsx", "");
                gWorkSheet.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, lPDFFile + ".pdf");

                return "OK";

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "Save()", "Stage =  " + lStage);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return ex.Message;
            }
        }


        public string SaveAsPdf()
        {
            string lStage = "";

            try
            {
                SelectSheet("Sheet1");
                lStage = "xlsx";
                gWorkBook.Save();
                lStage = "pdf";
                gWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypePDF, gWorkBook.FullName.Replace(".xlsx", ".pdf"));

                return "OK";

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SaveAsPdf", "Stage =  " + lStage);
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return ex.Message;
            }
        }


        public string SaveAsXPS()
        {

            try
            {
                gWorkBook.ExportAsFixedFormat(Excel.XlFixedFormatType.xlTypeXPS, gWorkBook.FullName.Replace(".xlsx", ".xps"));

                return "OK";

            }

            catch (Exception ex)
            {
                //Display all the exceptions

                Exception CurrentException = ex;
                int ExceptionLevel = 0;
                do
                {
                    ExceptionLevel++;
                    ExceptionData.WriteException(1, ExceptionLevel.ToString() + " " + CurrentException.Message, this.ToString(), "SaveAsXPS", "");
                    CurrentException = CurrentException.InnerException;
                } while (CurrentException != null);

                return ex.Message;
            }
        }




        public string Close()
        {
            gWorkBook.Saved = true;
            gWorkBook.Close();
            gApp.Quit();
            gApp = null;
            return "OK";
        }

    }
}
