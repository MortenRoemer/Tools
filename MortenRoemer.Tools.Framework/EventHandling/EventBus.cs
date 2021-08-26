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

        public void AddHandler<THandler, TEvent>(ActiveEventHandler<THandler, TEvent> aHandler)
            where THandler : class, IEventHandler<TEvent>, new()
        {
            
        }
        
        private IDictionary<Type, List<object>> Handlers { get; set; }
    }
}