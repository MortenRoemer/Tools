namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventHandlerPreparation<THandler, TEvent>
        where THandler : class, IEventHandler<TEvent>, new()
    {
        public static EventHandlerPreparation<THandler, TEvent> Start() => new();

        private ServiceProvider Services { get; } = new();

        public EventHandlerPreparation<THandler, TEvent> WithCustomService<T>(object service)
        {
            Services.Add<T>(service);
            return this;
        }

        public ActiveEventHandler<THandler, TEvent> Activate()
        {
            return new ActiveEventHandler<THandler, TEvent>(Services);
        }
    }
}