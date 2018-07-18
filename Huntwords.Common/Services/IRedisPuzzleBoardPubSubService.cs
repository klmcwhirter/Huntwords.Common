using System;

namespace Huntwords.Common.Services
{
    /// <summary>
    /// Contract for a Redis PuzzleBoard PubSub service
    /// </summary>
    public interface IRedisPuzzleBoardPubSubService
    {
        /// <summary>
        /// Publish a message that a PuzzleBoard has been popped out of the list
        /// </summary>
        /// <param name="puzzleName">Name of the PuzzleBoard list that was popped</param>
        void PublishPopped(string puzzleName);
        /// <summary>
        /// Subscribe to PuzzleBoard popped messages
        /// </summary>
        /// <param name="puzzlePoppedHandler">Action&lt;string&gt; that will handle the message</param>
        void SubscribePopped(Action<string> puzzlePoppedHandler);
    }
}
