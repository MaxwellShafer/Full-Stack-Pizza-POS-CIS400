using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaParlor.Data.Crust;

namespace PizzaParlor.Data
{
    /// <summary>
    /// a class containign the data for a veggie pizza
    /// </summary>
    public class VeggiePizza
    {
        /// <summary>
        /// gets the name of the pizza
        /// </summary>
        public string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// gets the description of the pizza
        /// </summary>
        public string Description { get; } = "All the veggies";

        /// <summary>
        /// gets or sets a value indicating whether the pizza has olives. Defaults to true.
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has peppers. Defaults to true.
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has onions. Defaults to true.
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has mushrooms. Defaults to true.
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// gets the number of slices in the pizza
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// gets the price of the pizza
        /// </summary>
        public decimal Price
        {

            get
            {
                decimal price = 12.99M;

                if (PizzaSize.Equals(Size.Sizes.Large))
                {
                    price += 2.00M;
                }
                else if ((PizzaSize.Equals(Size.Sizes.Small)))
                {
                    price -= 2.00M;
                }

                if (Crusts.Equals(Crust.Crusts.DeepDish))
                {
                    price += 1.00M;
                }

                return price;

            }


        };

        /// <summary>
        /// gets the calories per each slice of the pizza, including toppings
        /// </summary>
        public uint CaloriesPerEach
        {

            get
            {

                uint cals = 250;

                if (Crusts.Equals(Crust.Crusts.Thin))
                {
                    cals = 150;
                }
                if (Crusts.Equals(Crust.Crusts.DeepDish))
                {
                    cals = 300;
                }

                
                if (Olives) cals += 5;
                if (Peppers) cals += 5;
                if (Onions) cals += 5;
                if (Mushrooms) cals += 5;

                if (PizzaSize.Equals(Size.Sizes.Large))
                {
                    cals = (uint)(cals * 1.3);
                }
                if (PizzaSize.Equals(Size.Sizes.Small))
                {
                    cals = (uint)(cals * .75);
                }

                return cals;
            }

        }

        /// <summary>
        /// gets the total number of calories in the pizza, considering toppings and slices
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach * Slices;

        /// <summary>
        /// gets special instructions for the pizza based on selected toppings
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                instructions.Add($"{PizzaSize} Pizza");
                instructions.Add($"{Crusts} Crust");

                if (!Olives) instructions.Add("Hold Olives");
                if (!Onions) instructions.Add("Hold Onions");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");

                return instructions;
            }
        }

        /// <summary>
        /// A property that holds the size of the pizza
        /// </summary>
        public Size.Sizes PizzaSize { get; set; } = Size.Sizes.Medium;

        /// <summary>
        /// A property that holds the type of crust
        /// </summary>
        public Crust.Crusts Crusts { get; set; } = Crust.Crusts.Original;

    }
}
