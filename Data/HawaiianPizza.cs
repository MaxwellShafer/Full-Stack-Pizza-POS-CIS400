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
        /// a constructor for Hawaiian pizza
        /// </summary>
        public HawaiianPizza() : base()
        {
            FindTopping(Topping.Ham).OnPizza = true;
            FindTopping(Topping.Pineapple).OnPizza = true;
            FindTopping(Topping.Onions).OnPizza = true;

        }
    }

}
