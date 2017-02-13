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
        public static int DecodeFile(string[] fileContent)
        {
            int decodeNumber = -1;

            if (CheckFileCompliant(fileContent))
                decodeNumber = 0;

            return decodeNumber;
        }

        public static bool CheckFileCompliant(string[] lines)
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
