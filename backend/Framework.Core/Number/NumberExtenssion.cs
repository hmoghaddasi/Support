using System;

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
    }
}
