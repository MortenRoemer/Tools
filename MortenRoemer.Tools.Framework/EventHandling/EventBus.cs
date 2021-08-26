using System;
using System.Collections;
using System.Collections.Generic;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventBus
    {
        public EventBus()
        {
        }

        public void AddHandler<THandler, TEvent>(ActiveEventHandler<THandler, TEvent> activeHandler)
            where THandler : class, IEventHandler<TEvent>, new()
        {
            if (Handlers.TryGetValue(typeof(TEvent), out var handlers))
            {
                handlers.Add(activeHandler);
            }
            else
                Handlers.Add(typeof(TEvent), new List<object> {activeHandler});
        }

        public HandleResult<THandler, TEvent> HandleEvent<THandler, TEvent>(TEvent tEvent)
            where THandler : class, IEventHandler<TEvent>, new()
        {
            if(Handlers.TryGetValue(tEvent.GetType(), out var handlers))
            {
                
            }
            
        }

        private Dictionary<Type, List<object>> Handlers { get; } = new();
    }
}