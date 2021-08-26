using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MortenRoemer.Tools.Framework.IO;

#pragma warning disable 1998

namespace MortenRoemer.Tools.Framework.Testing.IO
{
    public class FakeTracingService : ITracingService
    {
        public List<string> Traces { get; } = new();

        public List<string> Exceptions { get; } = new();


        public async Task Trace(string content)
        {
            Traces.Add($"[{DateTime.Now:s}] {content}");
        }

        public async Task TraceException(Exception exception)
        {
            Exceptions.Add($"[{DateTime.Now:s}] {exception}");
        }
    }
}

#pragma warning restore 1998