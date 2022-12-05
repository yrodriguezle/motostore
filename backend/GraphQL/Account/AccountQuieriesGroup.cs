using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Motostore.Models;
using Motostore.Repositories;

namespace Motostore.GraphQL
{
    public class AccountQuieriesGroup : ObjectGraphType
    {
        public AccountQuieriesGroup(Defer<IRepository> repository)
        {
            Field<UserType, User>(Name = "currentUser")
                .ResolveAsync(async (context) =>
                {
                    
                });
        }
    }
}
