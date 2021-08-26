using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public interface IEventHandler<in T>
    {
        Task Execute(IServiceProvider services,T message, CancellationToken token = default);
    }
}