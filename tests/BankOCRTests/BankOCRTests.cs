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
            public void ReturnsNegativeValueIfContentIsNotCompliant()
            {
                // Arrange
                string[] contentValid = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  @ _||_|  ||_| _|",
                    "                           "
                };

                // Act
                var result = BankOCR.DecodeFile(contentValid) < 0;

                //Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ReturnsPositiveValueIfContentIsCompliant()
            {
                // Arrange
                string[] contentValid = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    "                           "
                };

                // Act
                var result = BankOCR.DecodeFile(contentValid) >= 0;

                //Assert
                Assert.IsTrue(result);
            }
        }

        [TestClass]
        public class BankOCRTests_CheckFileCompliant
        {
            [TestMethod]
            public void ReturnsTrueIfContentIsCompliant()
            {
                // Arrange
                string[] validContent = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    "                           "
                };

                // Act
                var result = BankOCR.CheckFileCompliant(validContent);

                //Assert
                Assert.IsTrue(result);
            }

            [TestMethod]
            public void ReturnsFalseIfContentContainsMoreThan4Lines()
            {
                // Arrange
                string[] notValidContent = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    "                           ",
                    ""
                };

                // Act
                var result = BankOCR.CheckFileCompliant(notValidContent);

                //Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ReturnsFalseIfContentContainsOneLineWithMoreThan27Chars()
            {
                // Arrange
                string[] notValidContent = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _| ",
                    "                           "
                };

                // Act
                var result = BankOCR.CheckFileCompliant(notValidContent);

                //Assert
                Assert.IsFalse(result);
            }

            [TestMethod]
            public void ReturnsFalseIfContentContainsOtherCharactereThanPipeSpaceAndUnderscore()
            {
                // Arrange
                string[] content = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_@ _|",
                    "                           "
                };

                // Act
                var result = BankOCR.CheckFileCompliant(content);

                //Assert
                Assert.IsFalse(result);
            }
        }

        [TestClass]
        public class BankOCRTests_ParseNumbers
        {
            [TestMethod]
            public void ReturnsIntegerWith9NumbersWhen4LinesAreSent()
            {
                //Arrange
                string[] content = new string[] {
                    "    _  _     _  _  _  _  _ ",
                    "  | _| _||_||_ |_   ||_||_|",
                    "  ||_  _|  | _||_|  ||_| _|",
                    "                           "
                };

                //Act
                var result = BankOCR.ParseNumbers(new string[4]);
                //Assert
                Assert.AreEqual(9, result.ToString().Length);
            }
        }
    }
}
