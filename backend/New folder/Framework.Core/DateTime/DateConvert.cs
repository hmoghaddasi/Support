using System;
using System.Globalization;


namespace Framework.Core.DateTime
{
    public static class DateConvert
    {
        public static int GetMonth(System.DateTime date)
        {
            //return month like 9601
            var persian = new PersianCalendar();
            var persianMonth = persian.GetYear(date)*100+ persian.GetMonth(date);
            return persianMonth;
        }

        public static System.DateTime ConvertToMiladi(this System.DateTime date)
        {
            //return Miladi date like 2001/01/01
            var miladidate = new System.DateTime(date.Year, date.Month, date.Day, new PersianCalendar());
            return miladidate;
        }
        public static System.DateTime ConvertToPersian(this System.DateTime date)
        {
            //return shamsi date like 1396/01/01
            var persian = new PersianCalendar();
            var persiandate = new System.DateTime(persian.GetYear(date), persian.GetMonth(date), persian.GetDayOfMonth(date));
            return persiandate;
        }
        public static System.DateTime ConvertToMiladi(string date)
        {
            //return Miladi date like 2001/01/01
            if(date!=null && date != "") { 
            string[] dt_arr = date.Split('/');
            var pc = new PersianCalendar();
            string str = pc.ToDateTime(Convert.ToInt32(dt_arr[0]), Convert.ToInt32(dt_arr[1]), Convert.ToInt32(dt_arr[2]), 1, 1, 1, 1, GregorianCalendar.ADEra).ToShortDateString();
            return Convert.ToDateTime(str);
            }
            return System.DateTime.Now;
        }

        public static System.DateTime ConvertShortToMiladi(string date)
        {
            //return Miladi date like 2001/01/01
            if (date != null && date != "")
            {
                string[] dt_arr = date.Split('/');
                var pc = new PersianCalendar();
                string str = pc.ToDateTime(1300+Convert.ToInt32(dt_arr[0]), Convert.ToInt32(dt_arr[1]), Convert.ToInt32(dt_arr[2]), 1, 1, 1, 1, GregorianCalendar.ADEra).ToShortDateString();
                return Convert.ToDateTime(str);
            }
            return System.DateTime.Now;
        }

        public static string GetShamsiDate(System.DateTime date, int count=0)
        {
            count++;
            var pc = new PersianCalendar();
            string strDate = pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date);
            return strDate;
            
        }
        public static string GetShamsiDateTime(System.DateTime date)
        {
            var pc = new PersianCalendar();
            string strDate = pc.GetYear(date) + "/" + pc.GetMonth(date) + "/" + pc.GetDayOfMonth(date) +" " +date.Hour+":"+date.Minute;
            return strDate;

        }
    }
}
