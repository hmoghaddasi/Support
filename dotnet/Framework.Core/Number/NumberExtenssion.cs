using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Core.Number
{
    public static class NumberExtenssion
    {
        public static bool IsNull(int? number)
        {
            //Check number is null
            return IsNull(number);
        }

        public static int SolidValue(int? number)
        {
            //Return Zero for null number
            return number.Value;
            
        }

        public static int[] ConvertStringToArray(string value)
        {
            string[] array = value.Split(',');
            int[] result=new int[array.Length-1];
            for (int i = 0; i < array.Length - 1; i++)
            {
                result[i] = Convert.ToInt32(array[i]);
            }
            return result;
        }

        public static string PersianToEnglish(this string persianStr)
        {
            try
            {
                Dictionary<string, string> lettersDictionary = new Dictionary<string, string>
                {
                    ["۰"] = "0",
                    ["۱"] = "1",
                    ["۲"] = "2",
                    ["۳"] = "3",
                    ["۴"] = "4",
                    ["۵"] = "5",
                    ["۶"] = "6",
                    ["۷"] = "7",
                    ["۸"] = "8",
                    ["۹"] = "9"
                };
                return lettersDictionary.Aggregate(persianStr, (current, item) =>
                    current.Replace(item.Key, item.Value));
            }
            catch
            {
                return null;
            }
          
        }
    }
}
