using System.Collections.Concurrent;

namespace Motostore.Helpers.GraphQLSubscriptions
{
    public interface IEventMessageStack
    {
        IObservable<EventMessage> GetAll();
        EventMessage AddEventMessage(EventMessage entityDetails);
        ConcurrentStack<EventMessage> AllEventMessages { get; }
    }
}
