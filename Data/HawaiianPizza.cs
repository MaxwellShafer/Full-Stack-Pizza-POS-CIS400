using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class defining a Hawaiian pizza
    /// </summary>
    internal class HawaiianPizza
    {
    
    /// <summary>
    /// gets the name of the pizza
    /// </summary>
    public string Name { get; } = "Hawaiian Pizza";

        /// <summary>
        /// gets the description of the pizza
        /// </summary>
        public string Description { get; } = "The pizza with pineapple";

        /// <summary>
        /// gets or sets a value indicating whether the pizza has ham
        /// </summary>
        public bool Ham { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has pineapple
        /// </summary>
        public bool Pineapple { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// gets the number of slices in the pizza
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// gets the price of the pizza
        /// </summary>
        public decimal Price { get; } = 13.99M;

        /// <summary>
        /// gets the calories per each slice of the pizza
        /// </summary>
        public uint CaloriesPerEach { get; } = 250;

        /// <summary>
        /// gets the total number of calories in the pizza, considering toppings and slices
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach + (Ham ? 30U : 0U) + (Pineapple ? 15U : 0U) + (Onions ? 5U : 0U);

        /// <summary>
        /// gets special instructions for the pizza based on selected toppings
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                if (!Ham)
                    yield return "Hold Ham";
                if (!Pineapple)
                    yield return "Hold Pineapple";
                if (!Onions)
                    yield return "Hold Onions";
            }
        }
    }
}
