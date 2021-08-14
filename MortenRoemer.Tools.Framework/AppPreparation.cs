using System;
using System.Threading.Tasks;

namespace MortenRoemer.Tools.Framework
{
    public class AppPreparation
    {
        public static AppPreparation Start() => new();
        
        private ServiceProvider Services { get; } = new();

        public AppPreparation WithCustomService<T>(object service)
        {
            Services.Add<T>(service);
            return this;
        }
        
        public async Task<AppResult> ThenExecute(IApplication application)
        {
            var startTime = DateTime.Now;
            try
            {
                await application.Execute(Services);
            }
            catch (Exception exception)
            {
                return new AppResult(startTime, DateTime.Now, exception);
            }

            return new AppResult(startTime, DateTime.Now, null);
        }
    }
}