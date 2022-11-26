using GraphQL.Types;
using GraphQL.Instrumentation;

namespace Motostore.GraphQL
{
    public class MotostoreSchema : Schema
    {
        public MotostoreSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MotostoreQueries>();
            Mutation = provider.GetRequiredService<MotostoreMutations>();
            Subscription = provider.GetRequiredService<MotostoreSubscriptions>();

            FieldMiddleware.Use(new MotostoreMiddleware());
        }
    }
}
