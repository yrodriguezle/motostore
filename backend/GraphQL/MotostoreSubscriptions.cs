using GraphQL;
using GraphQL.Types;

using Motostore.Helpers.GraphQLSubscriptions;


namespace Motostore.GraphQL
{
    public class MotostoreSubscriptions : ObjectGraphType
    {
        private IEntitySubscription _entity;
        private T? EntityFromMessage<T>(IResolveFieldContext context, string subscriptionName)
        {
            if (((SubscriptionMessage)context.Source).Entity is T entity && ((SubscriptionMessage)context.Source).SubscriptionName == subscriptionName)
            {
                return entity;
            }
            return default;
        }

        public MotostoreSubscriptions(IEntitySubscription entityDetails)
        {
            _entity = entityDetails;
        }
    }
}
