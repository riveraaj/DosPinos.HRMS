using System.Globalization;

namespace DosPinos.HRMS.WebApp.Helpers
{
    public static class GetDateHelper
    {
        public static string GetToday() => DateTime.Now.ToString("yyyy-MM-dd");

        public static string GetTodayCapitalize() => char.ToUpper(DateTime.Now.ToString("MMMM dd 'del' yyyy", new CultureInfo("es-CR"))[0]) +
                                            DateTime.Now.ToString("MMMM dd 'del' yyyy", new CultureInfo("es-CR"))[1..];

        public static string GetMonthTodayCapitalize() => char.ToUpper(DateTime.Now.ToString("MMMM yyyy", new CultureInfo("es-CR"))[0]) +
                                            DateTime.Now.ToString("MMMM yyyy", new CultureInfo("es-CR"))[1..];
    }
}