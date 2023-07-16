using OfficeOpenXml;
using System.Data;
using System.IO;

namespace EDI_Reader_v0._1
{
    internal class WriteExcelSheet
    {
        private string sheet;
        private DataTable dataTable;
        private string folderPath;

        public WriteExcelSheet(string sheet, DataTable dataTable, string folderPath)
        {
            this.sheet = sheet;
            this.dataTable = dataTable;

            // Set the LicenseContext
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet
                var worksheet = package.Workbook.Worksheets.Add(sheet);

                // Write the column headers to the Excel sheet
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dataTable.Columns[i].ColumnName;
                }

                // Write the data rows to the Excel sheet
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    for (int col = 0; col < dataTable.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = dataTable.Rows[row][col];
                    }
                }

                // Save the Excel file to the specified folder path
                string filePath = Path.Combine(folderPath, "new_excel_file.xlsx");
                package.SaveAs(new FileInfo(filePath));
            }
        }
    }
}