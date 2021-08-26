using System;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public struct HandleResult<THandler, TEvent>
        where THandler : class, IEventHandler<TEvent>, new()
    {
        public Exception ThrownException { get; set; }

        public ActiveEventHandler<THandler, TEvent> ThrowingHandler { get; set; }

        public DateTime StartingTime { get; set; }
        public DateTime EndingTime { get; set; }

        public TimeSpan Duration => EndingTime - StartingTime;
    }
}