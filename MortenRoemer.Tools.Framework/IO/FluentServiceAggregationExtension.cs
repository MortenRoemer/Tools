namespace MortenRoemer.Tools.Framework.IO
{
    public static class FluentServiceAggregationExtension
    {
        public static TAggregator WithLocalFileSystem<TAggregator>(this TAggregator aggregator)
            where TAggregator : IFluentServiceAggregation<TAggregator>
            => aggregator.WithCustomService<IFileRepository>(LocalFileRepository.Singleton);

        public static TAggregator WithConsoleTracing<TAggregator>(this TAggregator aggregator)
            where TAggregator : IFluentServiceAggregation<TAggregator>
            => aggregator.WithCustomService<ITracingService>(ConsoleTracingService.Singleton);
    }
}