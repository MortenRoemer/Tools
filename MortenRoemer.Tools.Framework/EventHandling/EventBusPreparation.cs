using System;
using System.Collections.Generic;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventBusPreparation : IFluentServiceAggregation<EventBusPreparation>
    {
        public EventBusPreparation(EventBus eventBus)
        {
            EventBus = eventBus;
        }
        
        private EventBus EventBus { get; }
        
        private ServiceProvider Services { get; } = new();

        private Dictionary<Type, List<IEventHandler>> Handlers { get; } = new();
        
        public EventBusPreparation WithCustomService<TService>(object service)
        {
            Services.Add<TService>(service);
            return this;
        }

        public EventBusPreparation WithHandlers(params IEventHandler[] handlers)
        {
            foreach (var handler in handlers)
            {
                if (Handlers.TryGetValue(handler.MessageType, out var subhandlers))
                    subhandlers.Add(handler);
                else
                    Handlers.Add(handler.MessageType, new List<IEventHandler> { handler });
            }

            return this;
        }

        public void Finish()
        {
            EventBus.FinishSetup(Services, Handlers);
        }
    }
}