using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OXU.Data.Model;
using OXU.Interfaces;

namespace OXU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {   
        private readonly IExcelProcessor excelProcessor;

        public UploadController(IExcelProcessor excelProcessor)
        {
            this.excelProcessor = excelProcessor;
        }

        [HttpPost]
        public IEnumerable<ExcelObject> Upload(IFormFile file)
        {
            return this.excelProcessor.Process(file);
        }
    }
}
