using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    internal class GarlicKnots
    {
        /// <summary>
        /// gets the name of the garlic knots
        /// </summary>
        public string Name { get; } = "Garlic Knots";

        /// <summary>
        /// gets the description of the garlic knots
        /// </summary>
        public string Description { get; } = "Twisted rolls with garlic and butter";

        /// <summary>
        /// gets or sets the count of garlic knots. Defaults to 8, maximum of 12
        /// </summary>
        public uint Count { get; set; } = 8;

        /// <summary>
        /// gets the price of each garlic knot. $0.75 each
        /// </summary>
        public decimal Price { get; } = 0.75M;

        /// <summary>
        /// gets the calories per each garlic knot. 175
        /// </summary>
        public uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// gets the total number of calories in all garlic knots, considering the count.
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach * Count;

        /// <summary>
        /// gets special instructions for the garlic knots based on the count.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                yield return $"{Count} Garlic Knots";
            }
        }
    }
}
