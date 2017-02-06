using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace BankOCR
{
    [TestClass]
    public class BankOCRTests
    {
        [TestClass]
        public class BankOCRTests_DecodeFile
        {

            [TestMethod]
            public void ThrowsFileNotFoundExceptionIfFileDoesntExists()
            {
                // Arrange
                string filePath = "bla";

                // Act

                //Assert
                Assert.ThrowsException<FileNotFoundException>(() => BankOCR.DecodeFile(filePath));
            }

            [TestMethod]
            public void ThrowsArgumentExceptionIfFilePathIsEmpty()
            {
                // Arrange
                string filePath = string.Empty;

                // Act

                //Assert
                Assert.ThrowsException<ArgumentException>(() => BankOCR.DecodeFile(filePath));
            }
        }

        [TestClass]
        public class BankOCRTests_IsFileValid
        {
            [TestMethod]
            public void ReturnsFileValidity()
            {
                // Arrange
                string[] filePathValid = File.ReadAllLines(@"E:\CodingDojo\CodingDojo-20170206\assets\userstory1.txt");
                string[] filePathNotValid = File.ReadAllLines(@"E:\CodingDojo\CodingDojo-20170206\assets\userstory1Invalid.txt");
                string[] filePathNotValid2 = File.ReadAllLines(@"E:\CodingDojo\CodingDojo-20170206\assets\userstory1Invalid2.txt");
                // Act

                //Assert
                Assert.IsTrue(BankOCR.IsValidFile(filePathValid));
                Assert.IsFalse(BankOCR.IsValidFile(filePathNotValid));
                Assert.IsFalse(BankOCR.IsValidFile(filePathNotValid2));
            }

            [TestMethod]
            public void ReturnsFalseIfFileContainsOtherCharactereThanPipeAndUnderscore()
            {
                // Arrange
                string[] filePathValid = File.ReadAllLines(@"E:\CodingDojo\CodingDojo-20170206\assets\userstory1UnspectedChar.txt");

                // Act

                //Assert
                Assert.IsFalse(BankOCR.IsValidFile(filePathValid));
            }
        }

        [TestClass]
        public class BankOCRTests_ParseNumbers
        {
            [TestMethod]
            public void ReturnsArrayWith9ElementsWhen4LinesAreSent()
            {
                //Arrange

                //Act
                var result = BankOCR.ParseNumbers(new string[4]);
                //Assert
                Assert.AreEqual(9, result.Length);
            }
        }
    }
}
