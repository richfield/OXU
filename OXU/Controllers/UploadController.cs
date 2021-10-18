using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OXU.Data.Model;
using OXU.Interfaces;

namespace OXU.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {   
        private readonly ILogger<UploadController> _logger;
        private readonly IExcelProcessor excelProcessor;

        public UploadController(ILogger<UploadController> logger, IExcelProcessor excelProcessor)
        {
            _logger = logger;
            this.excelProcessor = excelProcessor;
        }

        [HttpPost]
        public IEnumerable<ExcelObject> Upload(IFormFile file)
        {
            return this.excelProcessor.Process(file);
        }
    }
}
