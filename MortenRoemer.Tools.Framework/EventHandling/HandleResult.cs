using System;
using System.Collections.Generic;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public readonly struct HandleResult
    {
        public HandleResult(IReadOnlyList<IEventHandler> handlers, DateTime startTime, DateTime endTime)
        {
            ThrownException = null;
            Handlers = handlers;
            StartTime = startTime;
            EndTime = endTime;
        }
        
        public HandleResult(IReadOnlyList<IEventHandler> handlers, DateTime startTime, DateTime endTime, EventHandlingException exception)
        {
            ThrownException = exception;
            Handlers = handlers;
            StartTime = startTime;
            EndTime = endTime;
        }
        
        public EventHandlingException? ThrownException { get; }
        
        public IReadOnlyList<IEventHandler> Handlers { get; }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public TimeSpan Duration => EndTime - StartTime;
    }
}