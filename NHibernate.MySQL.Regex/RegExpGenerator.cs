using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using NHibernate.Hql.Ast;
using NHibernate.Linq;
using NHibernate.Linq.Functions;
using NHibernate.Linq.Visitors;

namespace NHibernate.MySQL.Regex
{
    public class RegExpGenerator : BaseHqlGeneratorForMethod
    {
        public RegExpGenerator()
        {
            SupportedMethods = new[]
                {
                    ReflectionHelper.GetMethod(() => RegExpLinqExtension.RegExp(null, null))
                };
        }

        public override HqlTreeNode BuildHql(
            MethodInfo method,
            Expression targetObject,
            ReadOnlyCollection<Expression> arguments,
            HqlTreeBuilder treeBuilder,
            IHqlExpressionVisitor visitor)
        {
            return treeBuilder.BooleanMethodCall(
                "regexp",
                arguments.Select(visitor.Visit).Cast<HqlExpression>());
        }
    }
}
