using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ClassAct.Website.PL
{
    public static class DataAccess
    {
        public static void SaveToXML(string filepath, object obj, Type type)
        {

            try
            {
                StreamWriter sw = new StreamWriter(filepath);
                XmlSerializer Serializer = new XmlSerializer(type);
                Serializer.Serialize(sw, obj);
                sw.Close();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public static object LoadFromXml(string filepath, Type type)
        {
            try
            {
                StreamReader Reader = new StreamReader(filepath);
                XmlSerializer Serializer = new XmlSerializer(type);

                object obj = Serializer.Deserialize(Reader);

                Reader.Close();
                return obj;
            }
            catch (Exception e)
            {

                throw e;
            }

        }
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

            public static string[,] Import(string filename)
            {
                Application xlApp;
                Workbook xlWB;
                Worksheet xlWS;

                xlApp = new Application();
                xlWB = xlApp.Workbooks.Open(filename);
                xlWS = (Worksheet)xlWB.Sheets[1];

                Range xlRange = xlWS.UsedRange;


                string[,] test = new string[xlRange.Rows.Count, xlRange.Columns.Count];


                for (int i = 0; i < test.GetLength(0); i++)
                {
                    for (int j = 0; j < test.GetLength(1); j++)
                    {
                        test[i, j] = xlRange.Cells[i + 1, j + 1].Value2.ToString();

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
}