namespace Motostore.Helpers.GraphQLSubscriptions
{
    public class EventMessage
    {
        public string Id { get; set; }
        public IEntity Entity { get; set; }
        public string SubscriptionName { get; set; }
        public int UserId { get; set; }

        public EventMessage(IEntity entity, string subscriptionName, int userId)
        {
            Id = Guid.NewGuid().ToString();
            Entity = entity;
            SubscriptionName = subscriptionName;
            UserId = userId;
        }
    }
}
