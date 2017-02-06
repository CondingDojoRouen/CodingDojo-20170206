using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCR
{
    public static class BankOCR
    {
        public static void DecodeFile(string filePath)
        {
            try
            {
                File.ReadAllLines(filePath);
            }
            catch(ArgumentException)
            {
                throw;
            }
            catch(FileNotFoundException)
            {
                throw;
            }
            
        }
    }
}
