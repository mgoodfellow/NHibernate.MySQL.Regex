using NHibernate.Linq.Functions;

namespace NHibernate.MySQL.Regex
{
    public class CustomLinqToHqlRegistry : DefaultLinqToHqlGeneratorsRegistry
    {
        public CustomLinqToHqlRegistry()
        {
            var generator = new RegExpGenerator();
            RegisterGenerator(typeof(RegExpLinqExtension).GetMethod("RegExp"), generator);
        }
    }
}
