using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    ///  A class contiaing data for a meat pizza
    /// </summary>
    public class MeatsPizza
    {
        /// <summary>
        /// gets or sets the name of the pizza
        /// </summary>
        public string Name { get; } = "Meats Pizza";

        /// <summary>
        /// gets or sets the description of the pizza
        /// </summary>
        public string Description { get; } = "All the meats";

        /// <summary>
        /// gets or sets a value indicating whether the pizza has sausage
        /// </summary>
        public bool Sausage { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has pepperoni
        /// </summary>
        public bool Pepperoni { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has ham
        /// </summary>
        public bool Ham { get; set; } = true;

        /// <summary>
        /// gets or sets a value indicating whether the pizza has bacon
        /// </summary>
        public bool Bacon { get; set; } = true;

        /// <summary>
        /// gets the number of slices in the pizza
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// gets the price of the pizza
        /// </summary>
        public decimal Price { get; } = 15.99M;

        /// <summary>
        /// gets the calories per each slice of the pizza
        /// </summary>
        public uint CaloriesPerEach { get; } = 250;

        /// <summary>
        /// gets the total number of calories in the pizza, considering toppings and slices
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach + (Sausage ? 60U : 0U) + (Pepperoni ? 30U : 0U) + (Ham ? 30U : 0U) + (Bacon ? 30U : 0U);

        /// <summary>
        /// gets special instructions for the pizza based on selected toppings
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                if (!Sausage)
                    yield return "Hold Sausage";
                if (!Pepperoni)
                    yield return "Hold Pepperoni";
                if (!Ham)
                    yield return "Hold Ham";
                if (!Bacon)
                    yield return "Hold Bacon";
            }
        }
    }
}
