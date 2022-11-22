using GraphQL;
using GraphQL.Types;

using MOTOSTORE.DataAccess;
using MOTOSTORE.Models;

namespace MOTOSTORE.GraphQL
{
    public class Queries : ObjectGraphType
    {
        // private readonly IConfiguration Configuration;
        public Queries(IRepositoryWrapper repository)
        {
            Field<UserType, User>("user")
                .Argument<StringGraphType>("username", "user username or email")
                .ResolveAsync(async context =>
                {
                    string email = context.GetArgument<string>("username");
                    return await repository.Users.GetByUsername(email);
                });
        }
    }
}
