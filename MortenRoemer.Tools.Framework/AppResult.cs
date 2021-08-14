using System;

namespace MortenRoemer.Tools.Framework
{
    public class AppResult
    {
        public AppResult(DateTime startTime, DateTime endTime, Exception? exception)
        {
            StartTime = startTime;
            EndTime = endTime;
            ThrownException = exception;
        }
        
        public DateTime StartTime { get; }
        
        public DateTime EndTime { get; }

        public TimeSpan ExecutionTime => EndTime - StartTime;
        
        public Exception? ThrownException { get; }
    }
}