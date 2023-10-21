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
    public class Breadsticks : Sides, IMenuItem
    {
        /// <summary>
        /// gets the name of the breadsticks
        /// </summary>
        override public string Name { get; } = "Breadsticks";

        /// <summary>
        /// gets the description of the breadsticks
        /// </summary>
        override public string Description { get; } = "Soft buttery breadsticks";

        /// <summary>
        /// a private field to store the count 
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// gets or sets the count of breadsticks. Defaults to 8, maximum of 12.
        /// </summary>
        override public uint SideCount { 
            
            get {
                return _count;
            }

            set
            {
                if (value >= 4 && value <= 12)
                {
                    _count = value;

                    OnPropertyChanged(nameof(SideCount));
                    OnPropertyChanged(nameof(Price));
                    OnPropertyChanged(nameof(CaloriesPerEach));
                    OnPropertyChanged(nameof(CaloriesTotal));
                    OnPropertyChanged(nameof(SpecialInstructions));
                }

            }
        
        }

        /// <summary>
        /// private backing feild
        /// </summary>
        private bool _cheese = false;

        /// <summary>
        /// gets or sets a value indicating whether the breadsticks have cheese. Defaults to false.
        /// </summary>
        public bool Cheese
        {
            get
            {
                return _cheese;
            }

            set
            {
                _cheese = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// gets the price of each breadstick. $0.75 each for plain breadsticks, $1.00 for cheesesticks.
        /// </summary>
        override public decimal Price {
            get
            {
                if (Cheese)
                {
                    return 1M* SideCount;
                }
                else
                {
                    return .75M * SideCount;
                }
            }
        }

        /// <summary>
        /// gets the calories per each breadstick. 150 for plain breadsticks, plus 50 calories for cheesesticks.
        /// </summary>
        override public uint CaloriesPerEach => (Cheese ?  200U : 150U);

        /// <summary>
        /// gets the total number of calories in all breadsticks, considering the count and type (cheesesticks or plain breadsticks).
        /// </summary>
        override public uint CaloriesTotal => CaloriesPerEach * SideCount;

        /// <summary>
        /// gets special instructions for the breadsticks based on the count and type (cheesesticks or plain breadsticks).
        /// </summary>
        override public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (Cheese)
                {
                    instructions.Add($"{SideCount} Cheesesticks");
                }

                else
                {
                    instructions.Add($"{SideCount} Breadsticks");
                    
                }

                return instructions;
            }
        }

        /// <summary>
        /// Override to string method
        /// </summary>
        /// <returns> the name</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
