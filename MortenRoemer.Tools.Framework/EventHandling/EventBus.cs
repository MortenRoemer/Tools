using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public static class EventBus
    {
        private static IServiceProvider? ServiceProvider { get; set; }
        
        private static bool IsSetUp { get; set; }

        private static Dictionary<Type, List<IEventHandler>> RegisteredHandlers { get; } = new();

        public static EventBusPreparation Setup()
        {
            return new EventBusPreparation();
        }

        public static void Register(IEventHandler eventHandler)
        {
            if (RegisteredHandlers.TryGetValue(eventHandler.MessageType, out var handlers))
                handlers.Add(eventHandler);
            else
                RegisteredHandlers.Add(eventHandler.MessageType, new List<IEventHandler> { eventHandler });
        }

        public static async Task<HandleResult> Handle(object eventData, CancellationToken token = default)
        {
            if (!IsSetUp)
                throw new InvalidOperationException("EventBus is not set up");
            
            var startTime = DateTime.Now;

            if (!RegisteredHandlers.TryGetValue(eventData.GetType(), out var handlers))
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

        internal static void FinishSetup(IServiceProvider serviceProvider)
        {
            if (IsSetUp)
                throw new InvalidOperationException("EventBus is already set up");
            
            ServiceProvider = serviceProvider;
            IsSetUp = true;
        }
    }
}