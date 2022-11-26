namespace Motostore.Helpers.GraphQLSubscriptions
{
    public class SubscriptionMessage
    {
        public string Id { get; set; }
        public IEntity Entity { get; set; }
        public string SubscriptionName { get; set; }
        public int UserId { get; set; }

        public SubscriptionMessage(IEntity entity, string subscriptionName, int userId)
        {
            Id = Guid.NewGuid().ToString();
            Entity = entity;
            SubscriptionName = subscriptionName;
            UserId = userId;
        }
    }
}
