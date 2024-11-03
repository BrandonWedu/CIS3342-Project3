using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Utilities
{
    public static class Validation
    {
        // Only alphanumeric characters, no spaces
        public static bool IsAlphaNumeric(string stringValue)
        {
            string pattern = @"^[a-zA-Z0-9]+$";
            return Regex.IsMatch(stringValue, pattern);
        }
        // Only alphanumeric characters, no spaces
        public static bool IsAlphaNumericWithDash(string stringValue)
        {
            string pattern = @"^[a-zA-Z0-9-]+$";
            return Regex.IsMatch(stringValue, pattern);
        } 
        // Only alphanumeric characters, with spaces
        public static bool IsAlphaNumericWithSpace(string stringValue)
        {
            string pattern = @"^[a-zA-Z0-9 ]+$"; 
            return Regex.IsMatch(stringValue, pattern);
        }
        // Password Characters, no spaces
        public static bool IsPassword(string stringValue)
        {
            string pattern = @"^[a-zA-Z0-9@$!%*?&]{8,}$";
            return Regex.IsMatch(stringValue, pattern); 
        }
        public static bool IsUnder51Characters(string stringValue)
        {
            return stringValue.Length > 51;
        }
        // Try Parses string to int
        public static bool IsInteger(string stringValue)
        {
            return int.TryParse(stringValue, out int temp) && stringValue.Length > 0;
        }
        // Try Parses string to double
        public static bool IsDouble(string stringValue)
        {
            return double.TryParse(stringValue, out double temp) && stringValue.Length > 0;
        }
    }
}
