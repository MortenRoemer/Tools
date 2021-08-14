namespace MortenRoemer.Tools.Framework
{
    public interface IServiceProvider
    {
        T Get<T>();

        bool Has<T>();

        bool TryGet<T>(out T? service);
    }
}