#pragma warning disable CS1572, CS1573, CS1591
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using ServiceStack.Redis;

namespace Huntwords.Common.Repositories
{
    public class RedisWordsRepository : IWordsRepository
    {
        const string WordsList = "urn:words";

        protected IRedisClient RedisClient { get; }
        protected ILogger<RedisWordsRepository> Logger { get; }

        public RedisWordsRepository(
            IRedisClient redisClient,
            ILogger<RedisWordsRepository> logger
        )
        {
            RedisClient = redisClient;
            Logger = logger;

            Initialize();
        }

        public int WordCount { get; set; }

        internal void Initialize()
        {
            try
            {
                WordCount = RedisClient.Lists[WordsList].Count;
                Logger.LogDebug($"Found {WordCount} words.");
            }
            catch (Exception e)
            {
                Logger.LogError(e, "Error: ");
            }
        }

        public string Get(int id) => RedisClient.Lists[WordsList].GetRange(id, id).FirstOrDefault();
    }
}
