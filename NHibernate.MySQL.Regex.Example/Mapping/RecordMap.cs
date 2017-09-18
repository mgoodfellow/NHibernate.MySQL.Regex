using FluentNHibernate.Mapping;
using NHibernate.MySQL.Regex.Example.Model;

namespace NHibernate.MySQL.Regex.Example.Mapping
{
    public class RecordMap : ClassMap<Record>
    {
        public RecordMap()
        {
            Table("record");

            Id(x => x.Id).Column("Id").Not.Nullable().GeneratedBy.Identity();

            Map(x => x.Data).Column("Data").Length(1024).Nullable();
        }
    }
}
