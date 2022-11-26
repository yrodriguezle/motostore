using GraphQL.Types;

namespace Motostore.GraphQL
{
    public class MotostoreMutations : ObjectGraphType
    {
        public MotostoreMutations()
        {
            Field<StringGraphType>(Name = "login")
                .Argument<NonNullGraphType<StringGraphType>>("email")
                .Argument<NonNullGraphType<StringGraphType>>("password")
                .Resolve(context =>
                {
                    return string.Empty;
                });
        }
    }
}
