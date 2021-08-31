using System;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventHandlingException : Exception
    {
        public EventHandlingException(Exception inner, IEventHandler eventHandler) : base(inner.Message, inner)
        {
            EventHandler = eventHandler;
        }
        
        public IEventHandler EventHandler { get; }
    }
}