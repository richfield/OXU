using Microsoft.AspNetCore.Http;
using OXU.Data.Model;
using System.Collections.Generic;

namespace OXU.Interfaces
{
    public interface IExcelProcessor
    {
        IEnumerable<ExcelObject> Process(IFormFile file);
    }
}
