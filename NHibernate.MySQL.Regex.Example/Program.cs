using System.Linq;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.MySQL.Regex.Example.Mapping;
using NHibernate.MySQL.Regex.Example.Model;

namespace NHibernate.MySQL.Regex.Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var fluentConfig = Fluently.Configure()
                .Database(
                    MySQLConfiguration.Standard.Dialect<CustomMySqlDialect>()
                        .ConnectionString(c => c.FromConnectionStringWithKey("DbConnectionString")))
                .ExposeConfiguration(cfg => cfg.LinqToHqlGeneratorsRegistry<CustomLinqToHqlRegistry>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RecordMap>())
                .BuildConfiguration();

            var sessionFactory = fluentConfig.BuildSessionFactory();

            // Use sessionFactory
            var session = sessionFactory.OpenSession();

            // Query using Linq
            var results = session.Query<Record>()
                .Where(x => x.Data.RegExp("bob|billy"))
                .ToList();
        }
    }
}
