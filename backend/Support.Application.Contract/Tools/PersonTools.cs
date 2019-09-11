using System;
using System.Collections.Generic;

namespace Support.Application.Contract.Tools
{
    public static class PersonTools
    {
      
        public static string GetRandomPassKey()
        {
            Random randomCodeGenerator = new Random();
            return randomCodeGenerator.Next(10000, 99999).ToString();
        }


        public static string GetLoginName(string user, List<string> loginNames)
        {
            if (loginNames.Contains(user))
            {
                Random random = new Random();
                user = user + random.Next(0, 1000);
                GetLoginName(user, loginNames);
            }
            return user;
        }
    }
}
