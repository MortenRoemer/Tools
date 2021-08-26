using System;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventHandlerResult
    {
        public EventHandlerResult(DateTime startTime, DateTime endTime, Exception? exception)
        {
            StartTime = startTime;
            EndTime = endTime;
            ThrownException = exception;
        }

        public DateTime StartTime { get; }

        public DateTime EndTime { get; }

        public TimeSpan ExecutionTime => EndTime - StartTime;

        public Exception? ThrownException { get; }

        public bool IsSuccess => ThrownException is null;

        public bool IsFailure => ThrownException is not null;
    }
}