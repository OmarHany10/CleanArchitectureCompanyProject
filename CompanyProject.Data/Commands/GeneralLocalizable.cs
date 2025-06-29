using System.Globalization;

namespace CompanyProject.Data.Commands
{
    public static class GeneralLocalizable
    {
        public static string Localize(string textAr, string textEn)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            if (cultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEn;
        }
    }
}
