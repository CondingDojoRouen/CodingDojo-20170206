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
                decodeNumber = ParseNumbers(fileContent);

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

        public static int ParseNumbers(string[] lines)
        {
            string[] strParsed = new string[9];
            int k = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j += 3)
                {
                    strParsed[k++] += lines[i].Substring(j, 3);
                }
                k = 0;
            }
            return strParsed.Select(s => litteralDigit[s]).Aggregate((a, b) => a * 10 + b);
        }

        public static bool AccountNumberValid(int account)
        {
            var checksum = account.ToString("000000000").Select((n, i) => Convert.ToInt32(n - '0') * (9 - i)).Aggregate((a, b) => a + b);
             
            return checksum % 11 == 0;
        }

        public static Dictionary<string, int> litteralDigit = new Dictionary<string, int>
        {
            {"   " +
             "  |" +
             "  |" +
             "   ", 1},
            {" _ " +
             " _|" +
             "|_ " +
             "   " , 2 },
            {" _ " +
             " _|" +
             " _|" +
             "   ", 3 },
            {"   " +
            "|_|" +
            "  |" +
            "   ", 4 },
            {" _ " +
             "|_ " +
             " _|" +
            "   ", 5},
            {" _ " +
             "|_ " +
             "|_|" +
             "   ", 6 },
            {" _ " +
             "  |" +
             "  |" +
             "   ", 7},
            {" _ " +
             "|_|" +
             "|_|" +
             "   ", 8 },
            {" _ " +
             "|_|" +
             " _|" +
             "   ", 9},
            {" _ " +
             "| |" +
             "|_|" +
             "   ", 0 },
        };
    }
}