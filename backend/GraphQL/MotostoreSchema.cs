using GraphQL.Types;

namespace Motostore.GraphQL
{
    public class MotostoreSchema : Schema
    {
        public MotostoreSchema(IServiceProvider provider) : base(provider)
        {
            Query = provider.GetRequiredService<MotostoreQueries>();
        }
    }
}
