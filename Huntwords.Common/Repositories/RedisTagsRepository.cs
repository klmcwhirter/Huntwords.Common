#pragma warning disable CS1572, CS1573, CS1591
using ServiceStack.Redis;
using System.Collections.Generic;

namespace Huntwords.Common.Repositories
{
    /// <summary>
    /// Repository for tags
    /// </summary>
    public class RedisTagsRepository : ITagsRepository
    {
        public const string TagsSet = "urn.tags";

        public IRedisClient RedisClient { get; }

        public RedisTagsRepository(IRedisClient redisClient)
        {
            RedisClient = redisClient;
        }

        public bool Add(string tag)
        {
            var rc = RedisClient.AddItemToSortedSet(TagsSet, tag);
            return rc;
        }

        public bool Delete(string tag)
        {
            var rc = RedisClient.RemoveItemFromSortedSet(TagsSet, tag);
            return rc;
        }

        public ICollection<string> GetAll()
        {
            var rc = RedisClient.GetAllItemsFromSortedSet(TagsSet);
            return rc;
        }
    }
}
