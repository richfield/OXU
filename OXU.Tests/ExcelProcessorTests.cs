using Microsoft.AspNetCore.Http.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OXU.Adapters;
using System;
using System.IO;
using System.Linq;

namespace OXU.Tests
{
    [TestClass]
    public class ExcelProcessorTests
    {
        private const string Path = "SampleData.xlsx";

        private const string TextPath = "TextFile1.txt";

        [TestMethod]
        public void ProcessReturnsList()
        {
            var processor = new ExcelProcessor();
            var fileStream = File.OpenRead(Path);
            var file = new FormFile(fileStream, 0, fileStream.Length, "SampleData", Path);

            var result = processor.Process(file);

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void FirstResultFirstNameIsJames()
        {
            var processor = new ExcelProcessor();
            var fileStream = File.OpenRead(Path);
            var file = new FormFile(fileStream, 0, fileStream.Length, "SampleData", Path);

            var result = processor.Process(file);

            var excelObject = result.First();
            excelObject.TryGetValue("FirstName", out string firstName);

            Assert.IsTrue(firstName == "James");
        }

        [TestMethod]
        public void NoFileThrowsFileNotFound()
        {
            try
            {
                var processor = new ExcelProcessor();
            
                var result = processor.Process(null);
            } 
            catch (Exception exception)
            {
                Assert.IsTrue(exception is FileNotFoundException);
            }
        }

        [TestMethod]
        public void InvalidFileThrowsInvalidData()
        {
            try
            {
                var processor = new ExcelProcessor();
                var fileStream = File.OpenRead(TextPath);
                var file = new FormFile(fileStream, 0, fileStream.Length, "SampleData", TextPath);
                var result = processor.Process(file);
            }
            catch (Exception exception)
            {
                Assert.IsTrue(exception is InvalidDataException);
            }
        }
    }
}
