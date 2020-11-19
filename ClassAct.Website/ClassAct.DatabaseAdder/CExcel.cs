using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ClassAct.DatabaseAdder
{
    public static class CExcel
    {
        public static void Export(string filename, string[,] data)
        {
            Application xlApp;
            Workbook xlWB;
            Worksheet xlWS;

            xlApp = new Application();
            xlWB = xlApp.Workbooks.Add(System.Reflection.Missing.Value);
            xlWS = (Worksheet)xlWB.Sheets["Sheet1"];

            for (int iRow = 0; iRow < data.GetLength(0); iRow++)
            {
                for (int iCol = 0; iCol < data.GetLength(1); iCol++)
                {
                    xlWS.Cells[iRow + 1, iCol + 1] = data[iRow, iCol];
                }
            }

            xlWS.Columns.AutoFit();
            xlWS.UsedRange.Borders.LineStyle = XlLineStyle.xlContinuous;
            xlApp.DisplayAlerts = false;

            //Save the XLSX
            xlWS.SaveAs(filename);

            //save the PDF
            xlWB.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF,
                    filename.Substring(0, filename.Length - 5));

            xlWB.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWS);

            Marshal.ReleaseComObject(xlWB);

            Marshal.ReleaseComObject(xlApp);
        }
        public static object[,] ImportObjectArray(string filename, int Sheet)
        {
            Application xlApp;
            Workbook xlWB;
            Worksheet xlWS;

            xlApp = new Application();
            xlApp.Visible = false;
            xlWB = xlApp.Workbooks.Open(filename);
            xlWS = (Worksheet)xlWB.Sheets[Sheet];

            Range xlRange = xlWS.UsedRange;

            object[,] items = xlRange.Value;
           
            xlWB.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWS);

            Marshal.ReleaseComObject(xlWB);

            Marshal.ReleaseComObject(xlApp);

            return items;
            
        }
        public static string[,] Import(string filename,int Sheet)
        {
            Application xlApp;
            Workbook xlWB;
            Worksheet xlWS;
           
            xlApp = new Application();
            xlApp.Visible = false;
            xlWB = xlApp.Workbooks.Open(filename);
            xlWS = (Worksheet)xlWB.Sheets[Sheet];

            Range xlRange = xlWS.UsedRange;

            object[,] items = xlRange.Value;
            ArrayList ItemsArr = new ArrayList();
            string[,] test = new string[items.GetLength(0), items.GetLength(1)];

            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {

                    ItemsArr.Add(items[i, j]);

                }

            }


            for (int i = 0; i < items.GetLength(0); i++)
            {
                for (int j = 0; j < items.GetLength(1); j++)
                {
                    if (items[i,j] != null)
                    { test[i, j] = items[i,j].ToString(); }
                    else
                    {
                        test[i, j] = "";
                    }

                }
                
            }

            xlWB.Close();
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWS);

            Marshal.ReleaseComObject(xlWB);

            Marshal.ReleaseComObject(xlApp);
           
            return test;
        }
    }
}
