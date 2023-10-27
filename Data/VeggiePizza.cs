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

    }
}
