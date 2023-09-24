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

        public MeatsPizza() : base()
        {
            FindTopping(Topping.Sausage).OnPizza = true;
            FindTopping(Topping.Bacon).OnPizza = true;
            FindTopping(Topping.Ham).OnPizza = true;
            FindTopping(Topping.Pepperoni).OnPizza = true;
        }
    }
}
