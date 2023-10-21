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
    public class CinnamonSticks : Sides, IMenuItem
    {
        /// <summary>
        /// gets the name of the cinnamon sticks
        /// </summary>
        override public string Name { get; } = "Cinnamon Sticks";

        /// <summary>
        /// gets the description of the cinnamon sticks
        /// </summary>
        override public string Description { get; } = "Like breadsticks but for dessert";
        /// <summary>
        /// a private field to store the count 
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// gets or sets the count of wings. Defaults to 8, maximum of 12.
        /// </summary>
        override public uint SideCount
        {

            get
            {
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
        /// private backing field
        /// </summary>
        private bool _frosting = true;
        /// <summary>
        /// gets or sets a value indicating whether the cinnamon sticks have frosting. Defaults to true.
        /// </summary>
        public bool Frosting
        {
            get
            {
                return _frosting;
            }

            set
            {
                _frosting = value;
               
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// gets the price of each cinnamon stick. $0.75 each for plain cinnamon sticks, $0.90 each with frosting.
        /// </summary>
        override public decimal Price {
            get
            {
                if (Frosting)
                {
                    return .9M * SideCount;
                }
                else
                {
                    return .75M * SideCount ;
                }
            }
        }

        /// <summary>
        /// gets the calories per each cinnamon stick. 160 for plain cinnamon sticks, plus 30 calories for frosting.
        /// </summary>
        override public uint CaloriesPerEach
        {
            get
            {
                if (Frosting)
                {
                    return 190U;
                }
                else
                {
                    return 160U;
                }
            }
        }
        /// <summary>
        /// gets the total number of calories in all cinnamon sticks, considering the count and frosting.
        /// </summary>
        override public uint CaloriesTotal => CaloriesPerEach * SideCount;

        /// <summary>
        /// gets special instructions for the cinnamon sticks based on the count and frosting.
        /// </summary>
        override public IEnumerable<string> SpecialInstructions
        {
            get
            {
                yield return $"{SideCount} Cinnamon Sticks";
                if (!Frosting)
                    yield return "Hold Frosting";
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
