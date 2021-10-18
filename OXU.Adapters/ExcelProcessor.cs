using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using OXU.Data.Model;
using OXU.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace OXU.Adapters
{
    public class ExcelProcessor : IExcelProcessor
    {
        public IEnumerable<ExcelObject> Process(IFormFile file)
        {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(file.OpenReadStream()))
            {

            }

            var list = new List<ExcelObject>();

            return list;
        }
    }
}
