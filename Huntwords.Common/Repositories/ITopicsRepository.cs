#pragma warning disable CS1572, CS1573, CS1591
using System.Collections.Generic;

namespace Huntwords.Common.Repositories
{
    public interface ITopicsRepository
    {
        /// <summary>
        /// Adds a topic
        /// </summary>
        /// <param name="topic">topic</param>
        /// <returns>success</returns>
        bool Add(string topic);
        /// <summary>
        /// Deletes a topic
        /// </summary>
        /// <param name="topic">topic</param>
        /// <returns>success</returns>
        bool Delete(string topic);        
        /// <summary>
        /// Gets all the topics
        /// </summary>
        ICollection<string> GetAll();
    }
}
