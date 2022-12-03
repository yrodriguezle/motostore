using GraphQL.Types;

namespace Motostore.GraphQL
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public TokenResponse()
        {
            Token = string.Empty;
            RefreshToken = string.Empty;
        }
    }

    public class TokenResponseType : ObjectGraphType<TokenResponse>
    {
        public TokenResponseType()
        {
            Description = "TokenResponse";
            Field(x => x.Token, type: typeof(StringGraphType), nullable: false).Description("Token");
            Field(x => x.RefreshToken, type: typeof(StringGraphType), nullable: true).Description("RefreshToken");
        }
    }
}
