using System;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.IO
{
    public interface ITracingService
    {
        Task Trace(string content);

        Task TraceException(Exception exception);
    }
}