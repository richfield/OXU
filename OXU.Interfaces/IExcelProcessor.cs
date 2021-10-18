using Microsoft.AspNetCore.Http;
using OXU.Data.Model;
using System;
using System.Collections.Generic;
using System.IO;

namespace OXU.Interfaces
{
    public interface IExcelProcessor
    {
        IEnumerable<ExcelObject> Process(IFormFile file);
    }
}
