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
    public class MeatsPizza : Pizza, IMenuItem
    {
        /// <summary>
        /// gets or sets the name of the pizza
        /// </summary>
        override public string Name { get; } = "Meats Pizza";

        /// <summary>
        /// gets or sets the description of the pizza
        /// </summary>
        override public string Description { get; } = "All the meats";

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
                    price += 2.00M;
                }
                if (PizzaSize == Size.Medium)
                {
                    price += 2.00M;
                }
                if (PizzaSize == Size.Large)
                {
                    price += 2.00M;
                }


                return price;
            }
        }
        public MeatsPizza() : base()
        {
            FindTopping(Topping.Sausage).OnPizza = true;
            FindTopping(Topping.Bacon).OnPizza = true;
            FindTopping(Topping.Ham).OnPizza = true;
            FindTopping(Topping.Pepperoni).OnPizza = true;
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
                    if (t.ToppingType == Topping.Bacon || t.ToppingType == Topping.Ham || t.ToppingType == Topping.Sausage || t.ToppingType == Topping.Pepperoni)
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
