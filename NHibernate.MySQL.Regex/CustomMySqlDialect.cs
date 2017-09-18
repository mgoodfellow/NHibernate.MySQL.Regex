using NHibernate.Dialect;
using NHibernate.Dialect.Function;

namespace NHibernate.MySQL.Regex
{
    public class CustomMySqlDialect : MySQL55InnoDBDialect
    {
        public CustomMySqlDialect()
        {
            RegisterFunction(
                "regexp",
                new SQLFunctionTemplate(
                    NHibernateUtil.Boolean,
                    "?1 REGEXP ?2"));
        }
    }
}
