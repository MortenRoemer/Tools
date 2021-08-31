namespace MortenRoemer.Tools.Framework
{
    public interface IFluentServiceAggregation<out TAggregator>
    {
        TAggregator WithCustomService<TService>(object service);
    }
}