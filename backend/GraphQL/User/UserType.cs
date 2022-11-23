using System;

using GraphQL.Types;

using Motostore.Models;

namespace Motostore.GraphQL
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Description = "User";
            Field(x => x.Id, type: typeof(LongGraphType), nullable: false).Description("Id");
            Field(x => x.Name, type: typeof(StringGraphType), nullable: true).Description("Name");
            Field(x => x.Email, type: typeof(StringGraphType), nullable: true).Description("Email");
            Field(x => x.Avatar, type: typeof(StringGraphType), nullable: true).Description("Avatar");
            Field(x => x.EmailVerifiedAt, type: typeof(DateTimeGraphType), nullable: true).Description("Avatar");
            Field(x => x.Password, type: typeof(StringGraphType), nullable: true).Description("Password");
            Field(x => x.RememberToken, type: typeof(StringGraphType), nullable: true).Description("Password");
            Field(x => x.CreatedAt, type: typeof(DateTimeGraphType), nullable: true).Description("Phone");
            Field(x => x.UpdatedAt, type: typeof(DateTimeGraphType), nullable: true).Description("DeletedAt");
            Field(x => x.RoleId, type: typeof(IntGraphType), nullable: true).Description("RoleId");
        }
    }
}
