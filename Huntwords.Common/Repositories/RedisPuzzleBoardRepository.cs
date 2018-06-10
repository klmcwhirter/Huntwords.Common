#pragma warning disable CS1572, CS1573, CS1591
using System;
using System.Collections.Generic;
using Huntwords.Common.Models;
using Huntwords.Common.Services;
using ServiceStack.Model;
using ServiceStack.Redis;

namespace Huntwords.Common.Repositories
{
    public class RedisPuzzleBoardRepository : IPuzzleBoardRepository
    {
        protected string PuzzleBoardListName = "urn:puzzleboards";
        protected string PuzzleBoardPoppedChannel = "urn:puzzleboard:popped";

        protected IRedisClient RedisClient { get; }
        protected ITransformer<string, PuzzleBoard> Json2PuzzleBoardTransformer { get; }
        protected ITransformer<PuzzleBoard, string> PuzzleBoard2JsonTransformer { get; }

        protected IRedisSubscription Subscription { get; set; } = null;

        public RedisPuzzleBoardRepository(
            IRedisClient redisClient,
            ITransformer<string, PuzzleBoard> json2PuzzleBoardTransformer,
            ITransformer<PuzzleBoard, string> puzzleBoard2JsonTransformer
            )
        {
            RedisClient = redisClient;
            Json2PuzzleBoardTransformer = json2PuzzleBoardTransformer;
            PuzzleBoard2JsonTransformer = puzzleBoard2JsonTransformer;
        }

        protected string ListName(string name) => $"{PuzzleBoardListName}:{name}";

        protected IRedisList List(string name) => RedisClient.Lists[ListName(name)];

        public void Delete(string name)
        {
            List(name).RemoveAll();
        }

        public int Length(string name)
        {
            var rc = List(name).Count;
            return rc;
        }

        public PuzzleBoard Pop(string name)
        {
            var json = List(name).Pop();
            var rc = Json2PuzzleBoardTransformer.Transform(json);
            PublishPopped(rc.Puzzle.Name);
            return rc;
        }

        public void Push(PuzzleBoard puzzleBoard)
        {
            var json = PuzzleBoard2JsonTransformer.Transform(puzzleBoard);
            List(puzzleBoard.Puzzle.Name).Push(json);
        }

        public void PublishPopped(string puzzleName)
        {
            RedisClient.PublishMessage(PuzzleBoardPoppedChannel, puzzleName);
        }

        public void SubscribePopped(Action<string> puzzlePoppedHandler)
        {
            using (Subscription = RedisClient.CreateSubscription())
            {
                Subscription.OnMessage += (channel, puzzleName) =>
                {
                    Subscription.UnSubscribeFromAllChannels();
                    Subscription = null;
                    puzzlePoppedHandler(puzzleName);
                };
            }

            Subscription.SubscribeToChannels(new string[] { PuzzleBoardPoppedChannel });
        }
    }
}
