using System;
using System.Reflection;
using Microsoft.Office.Interop.Excel;

namespace Subs.Data
{
	/// <summary>
	/// Summary description for ExInput.
	/// </summary>
	/// 

	public class ExcelIO
	{
        private Microsoft.Office.Interop.Excel.Application Ex = new Microsoft.Office.Interop.Excel.Application();
        private Microsoft.Office.Interop.Excel.Workbook myWorkbook;
        private Microsoft.Office.Interop.Excel._Worksheet myWorksheet;

		public ExcelIO(string ExcelFile)
		{
			myWorkbook = Ex.Workbooks.Open(ExcelFile,
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

			Ex.Visible = true;
			Ex.Interactive = true;
		}

        ~ExcelIO()
        {
            Close();
        }


		public void SelectSheet(string Sheet)
		{
            try
            {
                myWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)myWorkbook.Worksheets[Sheet];
                myWorksheet.Activate();
             }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "SelectSheet", "");
                    throw new Exception(this.ToString() + " : " + "SelectSheet" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
		}


        public void SelectFirstSheet()
        {
            try
            {
                myWorksheet = (Microsoft.Office.Interop.Excel._Worksheet)myWorkbook.Worksheets[1];
                myWorksheet.Activate();
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "SelectFirstSheet", "");
                    throw new Exception(this.ToString() + " : " + "SelectFirstSheet" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
        }




		public void PutCell(int Row, int Column, decimal Content)
		{
            try
            {
                Microsoft.Office.Interop.Excel.Range Target;
                Target = (Microsoft.Office.Interop.Excel.Range)Ex.Cells[Row, Column];
                Target.set_Item(1, 1, Content);
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "PutCell", "");
                    throw new Exception(this.ToString() + " : " + "PutCell" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
		}

        public int GetInt(int Row, int Column)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target;
                Target = (Microsoft.Office.Interop.Excel.Range)Ex.Cells[Row, Column];
                Target.Activate();
                if (Target.Value2 == null)
                { 
                    return 0;
                }
                else
                {
                    return System.Convert.ToInt32(Target.Value2);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "GetInt", "");
                    throw new Exception(this.ToString() + " : " + "GetInt" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
        }


		public Decimal GetDecimal(int Row, int Column)
		{
            try
            {
                Microsoft.Office.Interop.Excel.Range Target;
                Target = (Microsoft.Office.Interop.Excel.Range)Ex.Cells[Row, Column];
                Target.Activate();
                if (Target.Value2 == null)
                { return 0; }
                else
                {
                    return System.Convert.ToDecimal(Target.Value2);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "GetDecimal", "");
                    throw new Exception(this.ToString() + " : " + "GetDecimal" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
		}


        public double GetDouble(int Row, int Column)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target;
                Target = (Microsoft.Office.Interop.Excel.Range)Ex.Cells[Row, Column];
                Target.Activate();
                if (Target.Value2 == null)
                {
                    return 0.0;
                }
                else
                {
                    return System.Convert.ToDouble(Target.Value2);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "GetDouble", "");
                    throw new Exception(this.ToString() + " : " + "GetDouble" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
        }




        public string GetString(int Row, int Column)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Range Target;
                Target = (Microsoft.Office.Interop.Excel.Range)Ex.Cells[Row, Column];
                Target.Activate();
                if (Target.Value2 == null)
                { return ""; }
                else
                {
                    return System.Convert.ToString(Target.Value2);
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                {
                    ExceptionData.WriteException(1, ex.Message, this.ToString(), "GetString", "");
                    throw new Exception(this.ToString() + " : " + "GetString" + " : ", ex);
                }
                else
                {
                    throw ex; // Just bubble it up
                }
            }
        }

    	public void Close()
		{
            if (Ex != null)
            {
                Ex.Quit();
                Ex = null; 
            }
		}
	}
}
