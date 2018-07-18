#pragma warning disable CS1572, CS1573, CS1591
using System;
using ServiceStack.Redis;

namespace Huntwords.Common.Services
{
    public class RedisPuzzleBoardPubSubService : IRedisPuzzleBoardPubSubService
    {
        protected string PuzzleBoardPoppedChannel = "urn:puzzleboard:popped";

        protected IRedisClient RedisClient { get; }

        public RedisPuzzleBoardPubSubService(
            IRedisClient redisClient
            )
        {
            RedisClient = redisClient;
        }

        public void PublishPopped(string puzzleName)
        {
            RedisClient.PublishMessage(PuzzleBoardPoppedChannel, puzzleName);
        }

        public void SubscribePopped(Action<string> puzzlePoppedHandler)
        {
            using (var subscription = RedisClient.CreateSubscription())
            {
                subscription.OnMessage += (channel, puzzleName) =>
                {
                    puzzlePoppedHandler(puzzleName);
                };
            }
        }
    }
}
