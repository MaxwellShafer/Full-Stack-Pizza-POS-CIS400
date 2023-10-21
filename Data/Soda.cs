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
    public class Soda : Drinks, IMenuItem
    {
        /// <summary>
        /// string representing the name of the soda.
        /// </summary>
        override public string Name { get; } = "Soda";

        /// <summary>
        /// string representing the description of the soda.
        /// </summary>
        override public string Description { get; } = "Standard Fountain Drink";

        /// <summary>
        /// boolean representing whether the soda has ice
        /// </summary>
        override public bool Ice { get; set; } = true;

        /// <summary>
        /// private backing field
        /// </summary>
        private Size _size = Size.Medium;

        /// <summary>
        /// Size representing the size of the soda
        /// </summary>
        override public Size DrinkSize
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// private backing field
        /// </summary>
        private SodaFlavor _flavor = SodaFlavor.Coke;

        /// <summary>
        /// SodaFlavor representing the flavor of the soda
        /// </summary>
        public SodaFlavor DrinkType
        {
            get
            {
                return _flavor;
            }
            set
            {
                _flavor = value;
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// decimal representing the price of the soda
        /// </summary>
        override public decimal Price
        {
            get
            {
                if (DrinkSize == Size.Small) return 1.50m;
                if (DrinkSize == Size.Medium) return 2.00m;
                if (DrinkSize == Size.Large) return 2.50m;
                return 0m;
            }
        }

        /// <summary>
        /// an enumerable representing special instructions for the soda.
        /// </summary>
        override public IEnumerable<string> SpecialInstructions
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
        /// <summary>
        /// Calculates the calories per each drink
        /// </summary>
        override public uint CaloriesPerEach
        {
            get
            {
                if (DrinkType == SodaFlavor.DietCoke) return 0;
                if (DrinkSize == Size.Small) return 150;
                if (DrinkSize == Size.Medium) return 200;
                if (DrinkSize == Size.Large) return 250;
                return 0;
            }
        }

        /// <summary>
        /// Calculates the calorie total
        /// </summary>
        override public uint CaloriesTotal
        {
            get
            {
                if (DrinkType == SodaFlavor.DietCoke) return 0;
                if (DrinkSize == Size.Small) return 150;
                if (DrinkSize == Size.Medium) return 200;
                if (DrinkSize == Size.Large) return 250;
                return 0;
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
