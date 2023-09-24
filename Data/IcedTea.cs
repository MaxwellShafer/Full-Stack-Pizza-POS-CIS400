using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Represents an iced tea drink.
    /// </summary>
    public class IcedTea : Drinks, IMenuItem
    {
        /// <summary>
        /// string representing the name of the iced tea.
        /// </summary>
        override public string Name { get; } = "Iced Tea";

        /// <summary>
        /// string representing the description of the iced tea
        /// </summary>
        override public string Description { get; } = "Freshly brewed sweet tea";

        /// <summary>
        /// boolean representing whether the iced tea has ice 
        /// </summary>
        override public bool Ice { get; set; } = true;

        /// <summary>
        /// Size representing the size of the iced tea 
        /// </summary>
        override public Size.Sizes DrinkSize { get; set; } = Size.Sizes.Medium;

        /// <summary>
        /// decimal representing the price of the iced tea.
        /// </summary>
        override public decimal Price
        {
            get
            {
                if (DrinkSize == Size.Sizes.Small) return 2.00m;
                if (DrinkSize == Size.Sizes.Medium) return 2.50m;
                if (DrinkSize == Size.Sizes.Large) return 3.00m;
                return 0m;
            }
        }

        /// <summary>
        /// uint representing the calories of the iced tea.
        /// </summary>
        public uint Calories
        {
            get
            {
                if (DrinkSize == Size.Sizes.Small) return 175;
                if (DrinkSize == Size.Sizes.Medium) return 220;
                if (DrinkSize == Size.Sizes.Large) return 275;
                return 0;
            }
        }

        /// <summary>
        ///  special instructions for the iced tea.
        /// </summary>
        override public IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>();

                instructions.Add($"Drink size: {DrinkSize}");


                if (!Ice)
                {
                    instructions.Add("Hold Ice");
                }

                return instructions;
            }
        }

        /// <summary>
        /// Calculate the calories per each
        /// </summary>
        override public uint CaloriesPerEach
        {
            get
            {
                if (DrinkSize == Size.Sizes.Small) return 175;
                if (DrinkSize == Size.Sizes.Medium) return 220;
                if (DrinkSize == Size.Sizes.Large) return 275;
                return 0;
            }
        }

        /// <summary>
        /// calculate the calorie totals
        /// </summary>
         override public uint CaloriesTotal
        {
            get
            {
                if (DrinkSize == Size.Sizes.Small) return 175;
                if (DrinkSize == Size.Sizes.Medium) return 220;
                if (DrinkSize == Size.Sizes.Large) return 275;
                return 0;
            }
        }
    }
}
