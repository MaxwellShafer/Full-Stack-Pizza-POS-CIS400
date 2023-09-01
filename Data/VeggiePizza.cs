using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public decimal Price { get; } = 12.99M;

        /// <summary>
        /// gets the calories per each slice of the pizza, including toppings
        /// </summary>
        public uint CaloriesPerEach { get; } = 250;

        /// <summary>
        /// gets the total number of calories in the pizza, considering toppings and slices
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach + (Olives ? 5U : 0U) + (Peppers ? 5U : 0U) + (Onions ? 5U : 0U) + (Mushrooms ? 5U : 0U);

        /// <summary>
        /// gets special instructions for the pizza based on selected toppings
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                if (!Olives)
                    yield return "Hold Olives";
                if (!Peppers)
                    yield return "Hold Peppers";
                if (!Onions)
                    yield return "Hold Onions";
                if (!Mushrooms)
                    yield return "Hold Mushrooms";
            }
        }
    }
}
