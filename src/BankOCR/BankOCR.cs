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
                var content = File.ReadAllLines(filePath);
                IsValidFile(content);
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
            if (lines.Length != 4 
                || lines.Any(l => l.Except(new char[] { '|', '_', ' ' }).Any())
                || lines.Any(l => l.Length != 27))
                return false;

            return true;
        }

        public static string[] ParseNumbers(string[] lines)
        {
            return null;
        }
    }
}
