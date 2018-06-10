#pragma warning disable CS1572, CS1573, CS1591
using System;
using System.Collections.Generic;
using Huntwords.Common.Models;

namespace Huntwords.Common.Repositories
{
    /// <summary>
    /// Contract for a puzzle board repository
    /// </summary>
    public interface IPuzzleBoardRepository
    {
        /// <summary>
        /// Deletes a puzzle board list
        /// </summary>
        /// <param name="name">PuzzleBoard name</param>
        void Delete(string name);
        /// <summary>
        /// Get the Length of the PuzzleBoard List for name
        /// </summary>
        /// <param name="name">name of the PuzzleBoard list</param>
        /// <returns>int</returns>
        int Length(string name);
        /// <summary>
        /// Pops a puzzle board
        /// </summary>
        /// <param name="name">PuzzleBoard name</param>
        /// <returns>PuzzleBoard</returns>
        PuzzleBoard Pop(string name);
        /// <summary>
        /// Pushes a puzzle board
        /// </summary>
        /// <param name="puzzleBoard">PuzzleBoard</param>
        void Push(PuzzleBoard puzzleBoard);
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
