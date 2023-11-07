using System.Security.Claims;

using GraphQL;
using GraphQL.DataLoader;
using GraphQL.Types;

using Motostore.Helpers;
using Motostore.Models;
using Motostore.Repositories;
using Motostore.Services;

namespace Motostore.GraphQL
{
    public class AccountMutationsGroup : ObjectGraphType
    {
        public AccountMutationsGroup(Defer<IRepository> repository, IPasswordHasher passwordHasher, Defer<IAuthenticationService> authenticationService)
        {
            Field<TokenResponseType>(Name = "Login")
                .Argument<NonNullGraphType<StringGraphType>>("username")
                .Argument<NonNullGraphType<StringGraphType>>("password")
                .ResolveAsync(async context =>
                {
                    string username = context.GetArgument<string>("username");
                    string password = context.GetArgument<string>("password");
                    
                    User? user = await repository.Value.User.GetByUsername(username);

                    passwordHasher.CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    await repository.Value.User.AddOrUpdate(user);

                    if (user == null || !passwordHasher.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                    {
                        throw new ExecutionError("Utente o password non validi!");
                    }
                    Claim[] usersClaims = new[]
                    {
                        new Claim(ClaimTypes.Name, user.Email),
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim("userId", user.Id.ToString()),
                    };
                    string jwtToken = authenticationService.Value.GenerateAccessToken(usersClaims);
                    string jwtRefreshToken = authenticationService.Value.GenerateRefreshToken();
                    user.RememberToken = jwtRefreshToken;
                    await repository.Value.User.AddOrUpdate(user);
                    return new TokenResponse()
                    {
                        Token = jwtToken,
                        RefreshToken = jwtRefreshToken,
                    };
                });
        }
    }
}
