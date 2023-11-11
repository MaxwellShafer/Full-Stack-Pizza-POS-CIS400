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
    public class VeggiePizza : Pizza, IMenuItem
    {
        /// <summary>
        /// gets the name of the pizza
        /// </summary>
         override public string Name { get; } = "Veggie Pizza";

        /// <summary>
        /// gets the description of the pizza
        /// </summary>
        override public string Description { get; } = "All the veggies";

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
                    price -= 1.00M;
                }
                if (PizzaSize == Size.Medium)
                {
                    price -= 1.00M;
                }
                if (PizzaSize == Size.Large)
                {
                    price -= 1.00M;
                }


                return price;
            }
        }
        /// <summary>
        /// A constructor for veggie pizza
        /// </summary>
        public VeggiePizza() : base()
        {
            FindTopping(Topping.Mushrooms).OnPizza = true;
            FindTopping(Topping.Onions).OnPizza = true;
            FindTopping(Topping.Peppers).OnPizza = true;
            FindTopping(Topping.Olives).OnPizza = true;

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
                    if (t.ToppingType == Topping.Mushrooms || t.ToppingType == Topping.Onions || t.ToppingType == Topping.Olives | t.ToppingType == Topping.Peppers)
                    {
                        if (t.OnPizza == false)
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
