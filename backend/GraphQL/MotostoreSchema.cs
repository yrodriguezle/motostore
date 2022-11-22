using GraphQL.Types;

namespace MOTOSTORE.GraphQL
{
    public class MotostoreSchema : Schema
    {
        public MotostoreSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<Queries>();
            //Mutation = provider.GetRequiredService<AMICO4Mutations>();
            //Subscription = provider.GetRequiredService<AMICO4Subscriptions>();

            //RegisterTypes(new[] { typeof(DateTimeNullGraphType) });
            //RegisterValueConverter(new DateTimeNullValueConverter());
        }
    }
}
