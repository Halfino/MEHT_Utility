using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MEHT_Counter
{
    class DigitValidator
    {
        string pattern { get; }
        string pattern2 { get; }
        public DigitValidator() {
            this.pattern = @"^\d+[\.\,]?\d*$";
            this.pattern2 = @"^\d+[\.]?\d*$";
        }

        public bool validateDigits(string inputString)
        {
            Match result = Regex.Match(inputString, this.pattern);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool checkIfDotSeparated(string inputString)
        {
            Match result = Regex.Match(inputString, this.pattern2);
            if (result.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isNumeric(string inputString)
        {
            bool isNumeric = int.TryParse(inputString, out int numberNeco);
            return isNumeric;
        }
    }
}
