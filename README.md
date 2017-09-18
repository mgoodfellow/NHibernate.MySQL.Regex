# NHibernate.MySQL.Regex

This is an example of how to provide your own custom Linq functions which can be used in with NHibernate.Linq

As long as the Linq expression is implemented in both code and with a translator for HQL, then it can be used for both normal Linq within C#, or it can be used and converted into SQL.

This particular example focuses on providing the MySQL REGEXP function and making it available in Linq.

## Explanation

The NHibernate.MySQL.Regex project contains 4 files:

* `RegExpLinqExtension` - Extension method to provide normal Linq functionality
* `RegExpGenerator` - NHibernate HQL generator
* `CustomMySqlDialect` - NHibernate custom dialect which contains the actual SQL (Note: This comes off the `MySQL55InnoDBDialect`, but it could inherit from any dialect)
* `CustomLinqToHqlRegistry` - The HQL registry implementation

## Dependencies

* NHibernate
* Fluent.NHibernate

## Example

The example project shows how to wire up the new `Dialect` and the new `HqlRegistry` which means the new `.RegExp()` function can be called within a Linq query which will be converted into SQL.
