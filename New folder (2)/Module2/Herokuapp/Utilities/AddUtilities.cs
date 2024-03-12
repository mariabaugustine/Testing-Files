using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herokuapp.Utilities
{
    internal class AddUtilities
    {
        public static List<AddData> ReadExcelData(string excelFilePath, string sheetname)
        {
            List<AddData>Addlist = new List<AddData>();
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
                            AddData data = new AddData
                            {

                                FirstName = GetValueOrDefault(row, "fname"),
                                LastName = GetValueOrDefault(row, "lname"),
                                //Dob = GetValueOrDefault(row, "dob"),
                                Email = GetValueOrDefault(row, "email"),
                                Phone = GetValueOrDefault(row, "phone"),
                                Street1= GetValueOrDefault(row, "sadress1"),
                                Street2= GetValueOrDefault(row, "saddress2"),
                                City= GetValueOrDefault(row,"city"),
                                State=GetValueOrDefault(row, "state"),
                                PostalCode= GetValueOrDefault(row,"post"),
                                Country= GetValueOrDefault(row,"country")
                             };
                            Addlist.Add(data);

                        }
                    }
                    else
                    {
                        Console.WriteLine($"sheet'{sheetname}' not found in the excel file");
                    }
                }
            }

            return Addlist;
        }
        static string GetValueOrDefault(DataRow row, string columnName)
        {
            //Console.WriteLine(row + "" + columnName);
            return row.Table.Columns.Contains(columnName) ?
                row[columnName]?.ToString() : null;
        }
    }
}
