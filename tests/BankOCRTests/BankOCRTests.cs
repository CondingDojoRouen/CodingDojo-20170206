using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BankOCR
{
    [TestClass]
    public class BankOCRTests
    {
        [TestMethod]
        public void ThrowsFileNotFoundExceptionIfFileDoesntExists()
        {
            // Arrange
            string filePath = string.Empty;
            
            // Act
            
            //Assert
            Assert.ThrowsException<FileNotFoundException>(() => BankOCR.DecodeFile(filePath));
        }
    }
}
