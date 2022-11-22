using GraphQL.Types;

using MOTOSTORE.Models;
using System;

namespace MOTOSTORE.DataAccess
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType()
        {
            Description = "User";
            Field(x => x.Id, type: typeof(LongGraphType), nullable: false).Description("Id");
            Field(x => x.Name, type: typeof(StringGraphType), nullable: true).Description("Name");
            Field(x => x.Email, type: typeof(StringGraphType), nullable: true).Description("Email");
            Field(x => x.Password, type: typeof(StringGraphType), nullable: true).Description("Password");
            Field(x => x.Phone, type: typeof(StringGraphType), nullable: true).Description("Phone");
            Field(x => x.DeletedAt, type: typeof(DateTimeGraphType), nullable: true).Description("DeletedAt");
            Field(x => x.RoleId, type: typeof(IntGraphType), nullable: true).Description("RoleId");
        }
    }
}
