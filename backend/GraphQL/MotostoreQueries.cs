using Microsoft.EntityFrameworkCore;

using GraphQL.Types;
using GraphQL.MicrosoftDI;

using Motostore.DataAccess;
using Motostore.Models;

namespace Motostore.GraphQL
{
    public class MotostoreQueries : ObjectGraphType
    {
        public MotostoreQueries()
        {
            Field<ListGraphType<UserType>, IEnumerable<User>>(Name = "users")
                .Resolve()
                .WithScope() // creates a service scope as described above; not necessary for serial execution
                .WithService<DataContext>()
                .ResolveAsync(async (context, dataContext) =>
                {
                    return await dataContext.Users.ToListAsync();
                });
        }
    }
}
