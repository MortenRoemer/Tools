namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventBusPreparation : IFluentServiceAggregation<EventBusPreparation>
    {
        private ServiceProvider Services { get; } = new();
        
        public EventBusPreparation WithCustomService<TService>(object service)
        {
            Services.Add<TService>(service);
            return this;
        }

        public void Finish()
        {
            EventBus.FinishSetup(Services);
        }
    }
}