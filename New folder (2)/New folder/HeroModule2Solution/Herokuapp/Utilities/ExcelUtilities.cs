using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.Utilities
{
    internal class ExcelUtilities
    {
        public static List<SignIn> ReadExcelData(string excelFilePath, string sheetname)
        {
            List<SignIn> SearchDatalist = new List<SignIn>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))

                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });
                    var datatable = result.Tables[sheetname];
                    if (datatable != null)
                    {
                        foreach (DataRow row in datatable.Rows)
                        {
                            SignIn signin = new SignIn
                            {
                
                                Email= GetValueOrDefault(row,"Email"),
                                Password= GetValueOrDefault(row, "Password")

                            };
                            SearchDatalist.Add(signin);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return SearchDatalist;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            //Console.WriteLine(row + "" + columnName);
            return row.Table.Columns.Contains(columnName) ?
                row[columnName]?.ToString() : null;
        }
    }
}
