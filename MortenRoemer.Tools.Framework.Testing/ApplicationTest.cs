namespace MortenRoemer.Tools.Framework.Testing
{
    public class ApplicationTest<TApp>
        where TApp : class, IApplication, new()
    {
        protected AppPreparation<TApp> WhenApplicationIsExecuted()
        {
            return new AppPreparation<TApp>();
        }
    }
}