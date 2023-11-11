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
    public class HawaiianPizza : Pizza, IMenuItem
    {

        /// <summary>
        /// gets the name of the pizza
        /// </summary>
        override public string Name { get; } = "Hawaiian Pizza";

        /// <summary>
        /// gets the description of the pizza
        /// </summary>
        override public string Description { get; } = "The pizza with pineapple";

        /// <summary>
        /// Calculates the price
        /// </summary>
        override public decimal Price
        {
            get
            {

                decimal price = base.Price;

                if (PizzaSize == Size.Small)
                {
                    price += 1.00M;
                }
                if (PizzaSize == Size.Medium)
                {
                    price += 1.00M;
                }
                if (PizzaSize == Size.Large)
                {
                    price += 1.00M;
                }


                return price;
            }
        }
        /// <summary>
        /// a constructor for Hawaiian pizza
        /// </summary>
        public HawaiianPizza() : base()
        {
            FindTopping(Topping.Ham).OnPizza = true;
            FindTopping(Topping.Pineapple).OnPizza = true;
            FindTopping(Topping.Onions).OnPizza = true;

        }

        /// <summary>
        /// special instructions
        /// </summary>
        override public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (PizzaSize == Size.Small)
                {
                    instructions.Add("Small");
                }
                if (PizzaSize == Size.Medium)
                {
                    instructions.Add("Medium");
                }
                if (PizzaSize == Size.Large)
                {
                    instructions.Add("Large");
                }

                if (PizzaCrust == Crust.Thin)
                {
                    instructions.Add("Thin Crust");
                }
                if (PizzaCrust == Crust.Original)
                {
                    instructions.Add("Original Crust");
                }
                if (PizzaCrust == Crust.DeepDish)
                {
                    instructions.Add("Deep Dish");
                }

                foreach (PizzaTopping t in PossibleToppings)
                {
                    if(t.ToppingType == Topping.Pineapple || t.ToppingType == Topping.Ham  || t.ToppingType == Topping.Onions)
                    {
                        if(t.OnPizza == false)
                        {
                            instructions.Add("Hold " + t.Name);
                        }
                    }
                    else
                    {
                        if (t.OnPizza == true)
                        {
                            instructions.Add("Add " + t.Name);
                        }
                    }
                    

                }

                return instructions;
            }
        }

    }

}
