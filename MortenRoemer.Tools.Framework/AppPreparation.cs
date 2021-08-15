using System;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework
{
    public class AppPreparation<TApp>
        where TApp : class, IApplication, new()
    {
        public static AppPreparation<TApp> Start() => new();
        
        private ServiceProvider Services { get; } = new();

        public AppPreparation<TApp> WithCustomService<T>(object service)
        {
            Services.Add<T>(service);
            return this;
        }
        
        public async Task<AppResult> ThenExecute()
        {
            var startTime = DateTime.Now;
            try
            {
                await new TApp().Execute(Services);
            }
            catch (Exception exception)
            {
                return new AppResult(startTime, DateTime.Now, exception);
            }

            return new AppResult(startTime, DateTime.Now, null);
        }
    }
}