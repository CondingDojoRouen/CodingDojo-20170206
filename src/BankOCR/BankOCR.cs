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
            catch (ArgumentException)
            {
                throw;
            }
            catch (FileNotFoundException)
            {
                throw;
            }

        }

        public static bool IsValidFile(string[] lines)
        {
            if (lines.Length != 4)
                return false;

            if (lines.Any(l => l.Length != 27))
                return false;

            return true;
        }
    }
}
