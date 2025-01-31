using System.Globalization;

namespace BookShop.Utility
{
    public static class Extension
    {
        public static string ToPersianCalender(this DateTime dateTime)
        {
            PersianCalendar persianCalendar = new();
            return $"{persianCalendar.GetHour(dateTime):00}:{persianCalendar.GetMinute(dateTime):00}   {persianCalendar.GetYear(dateTime):0000}/{persianCalendar.GetMonth(dateTime):00}/{persianCalendar.GetDayOfMonth(dateTime):00}";
        }

        public static string ToPriceFormat(this decimal value)
        {
            return value.ToString("#,#");
        }

        public static string ToPriceFormat(this double value)
        {
            return value.ToString("#,#");
        }

        public static decimal ToPriceDecimal(this string value)
        {
            var strWithoutComma = value.Replace(",", "");

            if (strWithoutComma.All(char.IsDigit))
                return decimal.Parse(strWithoutComma, CultureInfo.InvariantCulture);
            else
                return 0;
        }
    }
}
