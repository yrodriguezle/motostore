using GraphQL.Types;
using GraphQL.Instrumentation;
using System;
using Motostore.Services;

namespace Motostore.GraphQL
{
    public class MotostoreSchema : Schema
    {
        public MotostoreSchema(IServiceProvider provider, Defer<IAuthenticationService> authService) : base(provider)
        {
            Query = provider.GetRequiredService<MotostoreQueries>();
            Mutation = provider.GetRequiredService<MotostoreMutations>();
            Subscription = provider.GetRequiredService<MotostoreSubscriptions>();

            FieldMiddleware.Use(new MotostoreMiddleware(authService));
        }
    }
}
