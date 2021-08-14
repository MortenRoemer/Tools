namespace MortenRoemer.Tools.Framework.IO
{
    public static class AppPreparationExtension
    {
        public static AppPreparation WithLocalFileSystem(this AppPreparation preparation) 
            => preparation.WithCustomService<IFileRepository>(LocalFileRepository.Singleton);
    }
}