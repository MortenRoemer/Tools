using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace MortenRoemer.Tools.Framework.EventHandling
{
    public class EventBus
    {
        public EventBus()
        {
        }

        public HandleResult<THandler, TEvent> HandleEvent<THandler, TEvent>(TEvent tEvent)
            where THandler : class, IEventHandler<TEvent>, new()
        {
            //TODO: Get MethodInfo-object from handlerinterface(IEventHandler)
            //TODO: analyze if current handler is corresponding to current event, if no -> ignore

            var handlerInterface = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(assembly =>
                    assembly.GetTypes()).First(type =>
                    type.IsInterface && type.IsGenericType && type.GenericTypeArguments.Contains(typeof(TEvent)));

            var handlers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsClass && !type.IsAbstract && handlerInterface.IsAssignableTo(type));

            foreach (var handler in handlers)
            {
                var method = handler.GetMethod(nameof(IEventHandler<TEvent>.Execute),
                    new[] { typeof(IServiceProvider), typeof(TEvent), typeof(CancellationToken) });
                
                method.Invoke()
            }
        }
    }
}