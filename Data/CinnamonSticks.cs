using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// a class containg the data for Cinnimon sticks
    /// </summary>
    public class CinnamonSticks
    {
        /// <summary>
        /// gets the name of the cinnamon sticks
        /// </summary>
        public string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// gets the description of the cinnamon sticks
        /// </summary>
        public string Description { get; } = "Like breadsticks but for dessert";

        /// <summary>
        /// gets or sets the count of cinnamon sticks. Defaults to 8, maximum of 12
        /// </summary>
        public uint Count { get; set; } = 8;

        /// <summary>
        /// gets or sets a value indicating whether the cinnamon sticks have frosting. Defaults to true.
        /// </summary>
        public bool Frosting { get; set; } = true;

        /// <summary>
        /// gets the price of each cinnamon stick. $0.75 each for plain cinnamon sticks, $0.90 each with frosting.
        /// </summary>
        public decimal Price { get; } = 0.75M;

        /// <summary>
        /// gets the calories per each cinnamon stick. 160 for plain cinnamon sticks, plus 30 calories for frosting.
        /// </summary>
        public uint CaloriesPerEach { get; } = 160;

        /// <summary>
        /// gets the total number of calories in all cinnamon sticks, considering the count and frosting.
        /// </summary>
        public uint CaloriesTotal => (Frosting ? CaloriesPerEach + 30U : CaloriesPerEach) * Count;

        /// <summary>
        /// gets special instructions for the cinnamon sticks based on the count and frosting.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                yield return $"{Count} Cinnamon Sticks";
                if (!Frosting)
                    yield return "Hold Frosting";
            }
        }
    }
}
