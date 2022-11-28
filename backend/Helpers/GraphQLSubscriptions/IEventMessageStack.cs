﻿using System.Collections.Concurrent;

namespace Motostore.Helpers.GraphQLSubscriptions
{
    public interface IEventMessageStack
    {
        IObservable<EventMessage> GetAll();
        EventMessage AddEventMessage(EventMessage eventMessage);
        ConcurrentStack<EventMessage> AllEventMessages { get; }
    }
}
