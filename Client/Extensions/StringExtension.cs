using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Client.Extensions
{
    public static class StringExtension
    {
        public static string ToStringEx(this object str)
        {
            if (str == null) return string.Empty;
            return str.ToString();
        }

        public static string TrimEx(this string str)
        {
            return str.ToStringEx().Trim();
        }

        public static string GetOnlyNumbers(this string str)
        {
            string pattern = "\\D";
            Regex regex = new Regex(pattern, RegexOptions.None, TimeSpan.FromMilliseconds(100));

            str = regex.Replace(str, "");
            return str;
        }

        public static bool IsFullNameValid(this string str)
        {
            return str.TrimEx().Contains(" ");
        }

        public static string GetLastName(this string str)
        {
            var rs = string.Empty;
            if (str.IsFullNameValid())
            {
                var arr = str.Split(' ');
                rs = arr[arr.Length - 1];
            }
            return rs;
        }

        public static string GetFirstName(this string str)
        {
            var rs = string.Empty;
            if (str.IsFullNameValid())
            {
                var lst = str.Split(' ').ToList();
                lst.RemoveAt(lst.Count - 1);
                rs = string.Join(" ", lst);
            }
            return rs;
        }

        public static bool IsPhoneNumberValid(this string phoneNumber, string regex = @"^(0[1-9]|84[1-9])(\d{8,9})$")
        {
            Regex phoneRegex = new Regex(regex, RegexOptions.None, TimeSpan.FromMilliseconds(100));
            return phoneRegex.IsMatch(phoneNumber);
        }
    }
}
