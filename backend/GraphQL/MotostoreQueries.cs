using Microsoft.EntityFrameworkCore;

using GraphQL.Types;
using GraphQL.MicrosoftDI;

using Motostore.DataAccess;
using Motostore.Models;
using Motostore.Repositories;

namespace Motostore.GraphQL
{
    public class MotostoreQueries : ObjectGraphType
    {
        public MotostoreQueries(IRepository repository)
        {
            Field<ListGraphType<UserType>, IEnumerable<User>>(Name = "usersWithDbContext")
                .Resolve()
                .WithScope()
                .WithService<DataContext>()
                .ResolveAsync(async (context, dataContext) =>
                {
                    return await dataContext.Users.ToListAsync();
                });
            Field<ListGraphType<UserType>, IEnumerable<User>>(Name = "usersWithRepository")
                .Resolve()
                .WithScope()
                .WithService<DataContext>()
                .ResolveAsync(async (context, dataContext) =>
                {
                    return await repository.User.GetAll();
                });
        }
    }
}
