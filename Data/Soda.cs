using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Represents a soda drink.
    /// </summary>
    public class Soda
    {
        /// <summary>
        /// string representing the name of the soda.
        /// </summary>
        public string Name { get; } = "Soda";

        /// <summary>
        /// string representing the description of the soda.
        /// </summary>
        public string Description { get; } = "Standard Fountain Drink";

        /// <summary>
        /// boolean representing whether the soda has ice
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Size representing the size of the soda
        /// </summary>
        public Size.Sizes DrinkSize { get; set; } = Size.Sizes.Medium;

        /// <summary>
        /// SodaFlavor representing the flavor of the soda
        /// </summary>
        public SodaFlavor.SodaFlavors DrinkType { get; set; } = SodaFlavor.SodaFlavors.Coke;

        /// <summary>
        /// decimal representing the price of the soda
        /// </summary>
        public decimal Price
        {
            get
            {
                if (DrinkSize == Size.Sizes.Small) return 1.50m;
                if (DrinkSize == Size.Sizes.Medium) return 2.00m;
                if (DrinkSize == Size.Sizes.Large) return 2.50m;
                return 0m;
            }
        }

        /// <summary>
        /// uint representing the calories of the soda.
        /// </summary>
        public uint Calories
        {
            get
            {
                if (DrinkType == SodaFlavor.SodaFlavors.DietCoke) return 0;
                if (DrinkSize == Size.Sizes.Small) return 150;
                if (DrinkSize == Size.Sizes.Medium) return 200;
                if (DrinkSize == Size.Sizes.Large) return 250;
                return 0;
            }
        }

        /// <summary>
        /// an enumerable representing special instructions for the soda.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                var instructions = new List<string>
            {
                $"Drink size: {DrinkSize}",
                $"Drink flavor: {DrinkType}"
            };

                if (!Ice)
                {
                    instructions.Add("Hold Ice");
                }

                return instructions;
            }
        }
    }
}
