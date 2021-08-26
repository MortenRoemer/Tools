using System;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.IO
{
    public class ConsoleTracingService : ITracingService
    {
        public static readonly ConsoleTracingService Singleton = new();
        
        private ConsoleTracingService() { }
        
        public async Task Trace(string content)
        {
            await Console.Out.WriteLineAsync($"[{DateTime.Now:s}] {content}");
        }

        public async Task TraceException(Exception exception)
        {
            await Console.Error.WriteLineAsync($"[{DateTime.Now:s}] {exception}");
        }
    }
}