using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class containing the data of Bread Sticks
    /// </summary>
    public class Breadsticks
    {
        /// <summary>
        /// gets the name of the breadsticks
        /// </summary>
        public string Name { get; } = "Breadsticks";

        /// <summary>
        /// gets the description of the breadsticks
        /// </summary>
        public string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// a private field to store the count 
        /// </summary>
        private uint _count;

        /// <summary>
        /// gets or sets the count of breadsticks. Defaults to 8, maximum of 12.
        /// </summary>
        public uint Count { 
            
            get {
                return _count;
            }

            set
            {
                 if( value <= 4)
                {
                    _count = 4;
                }
                 if(value >= 12)
                {
                    _count = 12;
                }

            }
        
        }

        /// <summary>
        /// gets or sets a value indicating whether the breadsticks have cheese. Defaults to false.
        /// </summary>
        public bool Cheese { get; set; } = false;

        /// <summary>
        /// gets the price of each breadstick. $0.75 each for plain breadsticks, $1.00 for cheesesticks.
        /// </summary>
        public decimal Price { get; } = 0.75M;

        /// <summary>
        /// gets the calories per each breadstick. 150 for plain breadsticks, plus 50 calories for cheesesticks.
        /// </summary>
        public uint CaloriesPerEach { get; } = 150;

        /// <summary>
        /// gets the total number of calories in all breadsticks, considering the count and type (cheesesticks or plain breadsticks).
        /// </summary>
        public uint CaloriesTotal => (Cheese ? CaloriesPerEach + 50U : CaloriesPerEach) * Count;

        /// <summary>
        /// gets special instructions for the breadsticks based on the count and type (cheesesticks or plain breadsticks).
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                if (Cheese)
                    yield return $"{Count} Cheesesticks";
                else
                    yield return $"{Count} Breadsticks";
            }
        }
    }
}
