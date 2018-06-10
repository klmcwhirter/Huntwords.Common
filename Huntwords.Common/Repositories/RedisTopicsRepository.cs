#pragma warning disable CS1572, CS1573, CS1591
using ServiceStack.Redis;
using System.Collections.Generic;

namespace Huntwords.Common.Repositories
{
    /// <summary>
    /// Repository for topics
    /// </summary>
    public class RedisTopicsRepository : ITopicsRepository
    {
        public const string TopicsSet = "urn.topics";
        protected IRedisClient RedisClient { get; }

        public RedisTopicsRepository(IRedisClient redisClient)
        {
            this.RedisClient = redisClient;

        }

        public bool Add(string topic)
        {
            var rc = RedisClient.AddItemToSortedSet(TopicsSet, topic);
            return rc;
        }

        public bool Delete(string topic)
        {
            var rc = RedisClient.RemoveItemFromSortedSet(TopicsSet, topic);
            return rc;
        }

        public ICollection<string> GetAll()
        {
            var rc = RedisClient.GetAllItemsFromSortedSet(TopicsSet);
            return rc;
        }
    }
}
