using System;
using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public interface IEventHandler
    {
        Type MessageType { get; }
        
        Task Execute(IServiceProvider services, object message, CancellationToken token = default);
    }
}