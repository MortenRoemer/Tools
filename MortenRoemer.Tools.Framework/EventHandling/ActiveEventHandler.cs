using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class ActiveEventHandler<THandler, TEvent>
        where THandler : class, IEventHandler<TEvent>, new()
    {
        public ActiveEventHandler(ServiceProvider services)
        {
            Services = services;
        }

        private ServiceProvider Services { get; }

        private THandler Handler { get; } = new();

        public async Task Execute(TEvent message, CancellationToken token = default)
        {
            await Handler.Execute(Services, message);
        }
    }
}