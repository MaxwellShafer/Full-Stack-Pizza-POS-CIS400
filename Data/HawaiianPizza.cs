using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class defining a Hawaiian pizza
    /// </summary>
    public class HawaiianPizza
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
        public decimal Price
        {

            get
            {
                decimal price = 13.99M;

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


        }

        /// <summary>
        /// gets the calories per each slice of the pizza
        /// </summary>
        public uint CaloriesPerEach {

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

                if (Ham) cals += 20;
                if (Onions) cals += 5;
                if (Pineapple) cals += 10;

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

                if (!Ham) instructions.Add("Hold Ham");
                if (!Pineapple) instructions.Add("Hold Pinapple");
                if (!Onions) instructions.Add("Hold Onions");


                

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
