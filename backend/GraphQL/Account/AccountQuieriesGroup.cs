using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Motostore.Models;
using Motostore.Repositories;
using Motostore.Services;
using System.Net;
using System.Security.Claims;

namespace Motostore.GraphQL
{
    public class AccountQuieriesGroup : ObjectGraphType
    {
        public AccountQuieriesGroup(Defer<IRepository> repository, Defer<IAuthenticationService> authService)
        {
            Field<UserType, User>(Name = "currentUser")
                .ResolveAsync(async (context) =>
                {
                    string username = authService.Value.GetUserName();
                    return await repository.Value.User.GetByUsername(username);
                });

            Field<StringGraphType>(Name = "refreshAccessToken")
                .Argument<NonNullGraphType<StringGraphType>>("token")
                .Argument<NonNullGraphType<StringGraphType>>("refreshToken")
                .ResolveAsync(async (context) =>
                {
                    try
                    {
                        string token = context.GetArgument<string>("token");
                        string refreshToken = context.GetArgument<string>("refreshToken");
                        ClaimsPrincipal principal = authService.Value.GetPrincipalFromExpiredToken(token);
                        string username = principal.Identity.Name;

                        User user = await repository.Value.User.GetByUsername(username);

                        if (user is null || user.RememberToken == null || !user.RememberToken.Equals(refreshToken))
                        {
                            throw new ExecutionError("Unauthorized");
                        }
                        return authService.Value.GenerateAccessToken(principal.Claims);
                    }
                    catch (Exception)
                    {
                        throw new ExecutionError("Unauthorized");
                    }
                });
        }
    }
}
