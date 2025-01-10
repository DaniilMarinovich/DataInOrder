using DataInOrder.Application.Interfaces;
using DataInOrder.Domain.Entities;
using System.Data;
using System.IO;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataInOrder.Application.Services;

public class ConvertToExcel : IConvert
{
    public void Convert(List<Person> persons, string fullPath)
    {
        var dataTable = new DataTable(typeof(Person).Name);

        PropertyInfo[] Props = typeof(Person).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo prop in Props)
        {
            dataTable.Columns.Add(prop.Name);
        }

        foreach (Person person in persons)
        {
            var values = new object[Props.Length];
            for (int i = 0; i < Props.Length; i++)
            {
                values[i] = Props[i].GetValue(person, null);
            }
            dataTable.Rows.Add(values);
        }

        DataSet dataSet = new();
        dataSet.Tables.Add(dataTable);

        Excel.Application excelApp = new Excel.Application();
        Excel.Workbook excelWorkBook = excelApp.Workbooks.Add();
        Excel._Worksheet xlWorksheet = (Excel._Worksheet)excelWorkBook.Sheets[1];
        Excel.Range xlRange = xlWorksheet.UsedRange;

        foreach (DataTable table in dataSet.Tables)
        {
            Excel.Worksheet excelWorkSheet = (Excel.Worksheet)excelWorkBook.Sheets.Add();
            excelWorkSheet.Name = table.TableName;
            for (int i = 1; i < table.Columns.Count + 1; i++)
            {
                excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
            }
            for (int j = 0; j < table.Rows.Count; j++)
            {
                for (int k = 0; k < table.Columns.Count; k++)
                {
                    excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                }
            }
        }

        excelWorkBook.SaveAs(fullPath);
        excelWorkBook.Close();
        excelApp.Quit();
    }
}
