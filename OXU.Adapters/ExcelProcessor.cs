using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OXU.Data.Model;
using OXU.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace OXU.Adapters
{
    public class ExcelProcessor : IExcelProcessor
    {
        // Set the colums
        private readonly Dictionary<int,string> columns = new Dictionary<int, string>                
        {
            { 1, "FirstName" },
            { 2, "LastName" },
            { 11, "EmailAddress" }
        };

        private readonly int skipRows = 1;

        public IEnumerable<ExcelObject> Process(IFormFile file)
        {
            if(file == null)
            {
                throw new FileNotFoundException();
            }
            
            var list = new List<ExcelObject>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(file.OpenReadStream()))
            {
                var firstSheet = package.Workbook.Worksheets[0];
                               
                var start = firstSheet.Dimension.Start;
                var end = firstSheet.Dimension.End;                

                // Get the values
                for (int row = start.Row + skipRows; row <= end.Row; row++)
                {
                    var currentObject = new ExcelObject();
                    foreach(var col in this.columns)
                    {                        
                        currentObject.Add(col.Value, firstSheet.Cells[row, col.Key].Text); 
                    }

                    if(!currentObject.IsEmpty)
                    {
                        list.Add(currentObject);
                    }
                }
            }

            return list;
        }
    }
}
