using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventBus
    {
        private IServiceProvider? ServiceProvider { get; set; }
        
        private bool IsSetUp { get; set; }

        private Dictionary<Type, List<IEventHandler>>? RegisteredHandlers { get; set; }

        public EventBusPreparation Setup()
        {
            return new EventBusPreparation(this);
        }

        public async Task<HandleResult> Handle(object eventData, CancellationToken token = default)
        {
            if (!IsSetUp)
                throw new InvalidOperationException("EventBus is not set up");
            
            var startTime = DateTime.Now;

            if (!RegisteredHandlers!.TryGetValue(eventData.GetType(), out var handlers))
                return new HandleResult(Array.Empty<IEventHandler>(), startTime, DateTime.Now);
            
            foreach (var handler in handlers)
            {
                try
                {
                    await handler.Execute(ServiceProvider!, eventData, token);
                }
                catch (Exception exception)
                {
                    return new HandleResult(handlers, startTime, DateTime.Now,
                        new EventHandlingException(exception, handler));
                }
            }
            
            return new HandleResult(handlers, startTime, DateTime.Now);
        }

        internal void FinishSetup(IServiceProvider serviceProvider, Dictionary<Type, List<IEventHandler>> handlers)
        {
            if (IsSetUp)
                throw new InvalidOperationException("EventBus is already set up");
            
            ServiceProvider = serviceProvider;
            RegisteredHandlers = handlers;
            IsSetUp = true;
        }
    }
}