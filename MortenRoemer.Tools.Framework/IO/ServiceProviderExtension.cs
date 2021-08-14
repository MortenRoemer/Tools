namespace MortenRoemer.Tools.Framework.IO
{
    public static class ServiceProviderExtension
    {
        public static IFileRepository GetFileRepository(this IServiceProvider serviceProvider)
            => serviceProvider.Get<IFileRepository>();
    }
}