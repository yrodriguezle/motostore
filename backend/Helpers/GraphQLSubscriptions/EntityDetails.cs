
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Collections.Concurrent;

namespace Motostore.Helpers.GraphQLSubscriptions
{
    public class EntityDetails : IEntitySubscription
    {
        private readonly ISubject<SubscriptionMessage> _messageStream = new ReplaySubject<SubscriptionMessage>(1);
        public ConcurrentStack<SubscriptionMessage> AllEntities { get; }
        public EntityDetails()
        {
            AllEntities = new ConcurrentStack<SubscriptionMessage>();
        }

        public IObservable<SubscriptionMessage> GetLatestEntities()
        {
            return _messageStream.Select(entity =>
            {
                return entity;
            })
                .AsObservable();
        }

        public SubscriptionMessage AddEntity(SubscriptionMessage entityDetails)
        {
            AllEntities.Push(entityDetails);
            _messageStream.OnNext(entityDetails);
            return entityDetails;
        }

        public void AddError(Exception exception)
        {
            _messageStream.OnError(exception);
        }
    }
}
