using System;
using System.Collections.Generic;

namespace MortenRoemer.Tools.Framework
{
    public class ServiceProvider : IServiceProvider
    {
        private IDictionary<Type, object> Services { get; } = new Dictionary<Type, object>();

        public void Add<T>(object service)
        {
            if (!typeof(T).IsAssignableTo(service.GetType()))
                throw new ArgumentException($"type {typeof(T)} is not assignable to service");
            
            Services.Add(typeof(T), service);
        }
        
        public T Get<T>()
        {
            return (T)Services[typeof(T)];
        }

        public bool Has<T>()
        {
            return Services.ContainsKey(typeof(T));
        }

        public bool TryGet<T>(out T? service)
        {
            if (Services.TryGetValue(typeof(T), out var entry))
            {
                service = (T)entry;
                return true;
            }

            service = default;
            return false;
        }
    }
}