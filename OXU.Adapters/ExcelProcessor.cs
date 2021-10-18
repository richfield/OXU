using Microsoft.AspNetCore.Http;
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
            var list = new List<ExcelObject>();

            return list;
        }
    }
}
