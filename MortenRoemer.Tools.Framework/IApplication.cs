using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework
{
    public interface IApplication
    {
        Task Execute(IServiceProvider services, CancellationToken token = default);
    }
}