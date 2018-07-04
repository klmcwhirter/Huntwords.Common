#pragma warning disable CS1572, CS1573, CS1591
using System.Collections.Generic;

namespace Huntwords.Common.Models
{
    public class Puzzle
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public List<string> Topics { get; set; }

        public List<string> Tags { get; set; }

        public List<string> PuzzleWords { get; set; }
    }
}
