using MortenRoemer.Tools.Framework.IO;

namespace MortenRoemer.Tools.Framework.Testing.IO
{
    public static class FluentServiceAggregationExtension
    {
        public static TAggregator WithFakeFileRepository<TAggregator>(this TAggregator aggregator, params FakeFile[] files)
            where TAggregator : IFluentServiceAggregation<TAggregator>
            => aggregator.WithCustomService<IFileRepository>(new FakeFileRepository(files));

        public static TAggregator WithFakeTracingService<TAggregator>(this TAggregator preparation)
            where TAggregator : IFluentServiceAggregation<TAggregator>
            => preparation.WithCustomService<ITracingService>(new FakeTracingService());
    }
}