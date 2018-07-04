#pragma warning disable CS1572, CS1573, CS1591
using System.Collections.Generic;
using System.Linq;
using Huntwords.Common.Models;
using ServiceStack.Redis;

namespace Huntwords.Common.Repositories
{
    public class RedisPuzzlesRepository : IPuzzlesRepository
    {
        protected string PuzzlePrefix = "urn:puzzle:";

        public RedisPuzzlesRepository(IRedisClient redisClient)
        {
            RedisClient = redisClient;
        }

        public IRedisClient RedisClient { get; }

        protected string GetKey(string name) => PuzzlePrefix + name;
        public Puzzle Add(Puzzle puzzle)
        {
            var key = GetKey(puzzle.Name);
            RedisClient.Set(key, puzzle);
            var rc = Get(puzzle.Name);
            return rc;
        }

        public Puzzle AddWord(string name, string word)
        {
            var puzzle = Get(name);
            puzzle.PuzzleWords.Add(word);
            puzzle.PuzzleWords.Sort();
            var rc = Update(puzzle.Name, puzzle);
            return rc;
        }

        public void Delete(string name)
        {
            var key = GetKey(name);
            RedisClient.Remove(key);
        }

        public Puzzle DeleteWord(string name, string word)
        {
            var puzzle = Get(name);
            puzzle.PuzzleWords.Remove(word);
            var rc = Update(name, puzzle);
            return rc;
        }

        public Puzzle Get(string name)
        {
            var key = GetKey(name);
            var rc = RedisClient.Get<Puzzle>(key);
            return rc;
        }

        public ICollection<Puzzle> GetAll()
        {
            var keys = RedisClient.SearchKeys(PuzzlePrefix + "*");
            var rc = RedisClient.GetAll<Puzzle>(keys);
            return rc.Values;
        }

        public Puzzle Update(string name, Puzzle puzzle)
        {
            var rc = Add(puzzle);
            return rc;
        }
    }
}