using System;
using System.Text.RegularExpressions;

namespace Framework.Core.Text
{
    public static class TextExtenssion
    {
        private const string _mobilePattern = @"^[0][1-9]\d{9}$|^[1-9]\d{9}$";
        public static bool IsValidMobile(this string text)
        {
            return Regex.Match(text, _mobilePattern).Success;
        }
    }
}
