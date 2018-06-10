#pragma warning disable CS1572, CS1573, CS1591
using System.Collections.Generic;

namespace Huntwords.Common.Repositories
{
    public interface ITagsRepository
    {
        /// <summary>
        /// Adds a tag
        /// </summary>
        /// <param name="tag">tag</param>
        /// <returns>success</returns>
        bool Add(string tag);
        /// <summary>
        /// Deletes a tag
        /// </summary>
        /// <param name="tag">tag</param>
        /// <returns>success</returns>
        bool Delete(string tag);        
        /// <summary>
        /// Gets all the tags
        /// </summary>
        ICollection<string> GetAll();
    }
}
