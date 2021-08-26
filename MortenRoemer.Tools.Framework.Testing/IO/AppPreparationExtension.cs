using MortenRoemer.Tools.Framework.IO;

namespace MortenRoemer.Tools.Framework.Testing.IO
{
    public static class AppPreparationExtension
    {
        public static AppPreparation<TApp> WithFakeFileRepository<TApp>(this AppPreparation<TApp> preparation, params FakeFile[] files)
            where TApp : class, IApplication, new() 
            => preparation.WithCustomService<IFileRepository>(new FakeFileRepository(files));

        public static AppPreparation<TApp> WithFakeTracingService<TApp>(this AppPreparation<TApp> preparation)
            where TApp : class, IApplication, new()
            => preparation.WithCustomService<ITracingService>(new FakeTracingService());
    }
}