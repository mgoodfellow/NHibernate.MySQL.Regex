using System.Text.RegularExpressions;

namespace NHibernate.MySQL.Regex
{
    public static class RegExpLinqExtension
    {
        public static bool RegExp(this string source, string terms)
        {
            var regex = new System.Text.RegularExpressions.Regex(terms, RegexOptions.IgnoreCase);
            return regex.IsMatch(source);
        }
    }
}
