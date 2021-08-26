namespace MortenRoemer.Tools.Framework.IO
{
    public static class AppPreparationExtension
    {
        public static AppPreparation<TApp> WithLocalFileSystem<TApp>(this AppPreparation<TApp> preparation)
            where TApp : class, IApplication, new() 
            => preparation.WithCustomService<IFileRepository>(LocalFileRepository.Singleton);

        public static AppPreparation<TApp> WithConsoleTracing<TApp>(this AppPreparation<TApp> preparation)
            where TApp : class, IApplication, new()
            => preparation.WithCustomService<ITracingService>(ConsoleTracingService.Singleton);
    }
}