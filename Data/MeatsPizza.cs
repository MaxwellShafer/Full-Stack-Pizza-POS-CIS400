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
        public decimal Price
        {

            get
            {
                decimal price = 15.99M;

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

                if (Sausage) cals += 30;
                if (Pepperoni) cals += 20;
                if (Bacon) cals += 20;
                if (Ham) cals += 20;
                

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
        public uint CaloriesTotal
        {
            get
            {
                //all pizzas have 8 slices

                return CaloriesPerEach * Slices;
            }
        }

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

                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Bacon) instructions.Add("Hold Bacon");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");



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
