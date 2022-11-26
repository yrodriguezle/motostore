using System.Collections.Concurrent;

namespace Motostore.Helpers.GraphQLSubscriptions
{
    public interface IEntitySubscription
    {
        IObservable<SubscriptionMessage> GetLatestEntities();
        SubscriptionMessage AddEntity(SubscriptionMessage entityDetails);
        ConcurrentStack<SubscriptionMessage> AllEntities { get; }
    }
}
