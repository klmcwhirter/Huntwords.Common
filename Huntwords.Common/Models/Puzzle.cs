#pragma warning disable CS1572, CS1573, CS1591
using System.Collections.Generic;

namespace Huntwords.Common.Models
{
    public class Puzzle
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<string> Topics { get; set; }

        public ICollection<string> Tags { get; set; }

        public ICollection<string> PuzzleWords { get; set; }
    }
}
