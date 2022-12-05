using GraphQL.Types;

namespace Motostore.GraphQL
{
    public class MotostoreQueries : ObjectGraphType
    {
        public MotostoreQueries()
        {
            Field<AccountQuieriesGroup>("account").Resolve(context => new { });
        }
    }
}
