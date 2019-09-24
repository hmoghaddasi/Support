using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Number;
using Support.Application.Contract.Constant;

namespace Support.Application.Contract.Tools
{
    public static class PersonTools
    {
        public static string GetRandomPassKey()
        {
            Random random = new Random();
            return $"{random.Next(10000, 99999).ToString().PersianToEnglish()}";
        }

        public static List<string> GetRandomUsername(List<string> currentData, int count)
        {
            var random = new Random();
            var list = new List<string>();
            for (int i = 0; i < count; i++)
            {
                var userName = new string(Enumerable.Repeat(CharType.AlphaNum, 5)
                    .Select(s => s[random.Next(s.Length)]).ToArray());

                var unique= SetUniqueLoginName(currentData, userName);
                list.Add(unique);
            }

            return list;
        }

        public static string GetRandomIdentifier(List<string> currentData)
        {
            var character = "";
            var random = new Random();

            for (int i = 0; i < 4; i++)
            {

                character += new string(Enumerable.Repeat(CharType.AlphaNum, 5)
                                 .Select(s => s[random.Next(s.Length)]).ToArray());
            }

            return SetUniqueLoginName(currentData, character);
        }

        private static string SetUniqueLoginName(List<string> currentUsers, string userName)
        {
            if (currentUsers.Contains(userName))
            {
                var random = new Random();
                userName = userName + random.Next(0, 100);
                SetUniqueLoginName(currentUsers, userName);
            }
            return userName;
        }
    }
}
