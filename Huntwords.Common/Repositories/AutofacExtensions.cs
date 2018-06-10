#pragma warning disable CS1572, CS1573, CS1591
using Autofac;

namespace Huntwords.Common.Repositories
{
    /// <summary>
    /// Extension methods to register types in this library
    /// </summary>
    public static class AutofacExtensions
    {
        /// <summary>
        /// Register common Repository types
        /// </summary>
        /// <param name="builder">ContainerBuilder</param>
        /// <returns>ContainerBuilder</returns>
        public static ContainerBuilder RegisterCommonRepositories(this ContainerBuilder builder)
        {
            builder.RegisterType<RedisPuzzlesRepository>().As<IPuzzlesRepository>();
            builder.RegisterType<RedisPuzzleBoardRepository>().As<IPuzzleBoardRepository>();
            builder.RegisterType<RedisTagsRepository>().As<ITagsRepository>();
            builder.RegisterType<RedisTopicsRepository>().As<ITopicsRepository>();

            builder.RegisterType<RedisWordsRepository>().As<IWordsRepository>();

            return builder;
        }
    }
}
