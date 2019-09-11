using System;

namespace Framework.Core.Data
{
    public static class ArrayExtenssion
    {
        public static int[] GetArrayId(string arrayString)
        {
            string[] textArray = arrayString.Split(',');
            int[] arrayId = new int[textArray.Length - 1];
            for (int i = 0; i < textArray.Length - 1; i++)
            {
                arrayId[i] = Convert.ToInt32(textArray[i]);
            }
            return arrayId;
        }
    }
}
