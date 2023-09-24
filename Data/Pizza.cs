using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A generic Pizza class, Serves as the base for the specialty pizzas
    /// </summary>
    public class Pizza : IMenuItem
    {
        /// <summary>
        /// A Name property
        /// </summary>
        virtual public string Name { get; } = "Build-Your-Own Pizza";

        /// <summary>
        /// A description of the Pizza
        /// </summary>
        virtual public string Description { get; } = "A pizza you get to build";

        /// <summary>
        /// Number of slices
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The size of the pizza
        /// </summary>
        virtual public Size.Sizes PizzaSize { get; set; } = Size.Sizes.Medium;

        /// <summary>
        /// The pizza Crust type
        /// </summary>
        virtual public Crust.Crusts PizzaCrust { get; set; } = Crust.Crusts.Original;

        /// <summary>
        /// A list of the possible toppings
        /// </summary>
        virtual public List<PizzaTopping> PossibleToppings { get; set; } = new List<PizzaTopping>();

        /// <summary>
        /// Calculates the price
        /// </summary>
        virtual public decimal Price
        {
            get
            {
                decimal price = 0M;

                if(PizzaSize == Size.Sizes.Small)
                {
                    price = 7.99M;
                }
                if (PizzaSize == Size.Sizes.Medium)
                {
                    price = 9.99M;
                }
                if (PizzaSize == Size.Sizes.Large)
                {
                    price = 11.99M;
                }
                if(PizzaCrust == Crust.Crusts.DeepDish)
                {
                    price += 1.00M;
                }

                foreach (PizzaTopping top in PossibleToppings)
                {
                    if (top.OnPizza)
                    {
                        price += 1.00M;
                    }
                }

                return price;
            }
        }
        /// <summary>
        /// Number of calories per each slice
        /// </summary>
        virtual public uint CaloriesPerEach
        {
            get
            {
                uint cal = 0;
                if(PizzaCrust == Crust.Crusts.Thin)
                {
                    cal = 150;
                }
                if (PizzaCrust == Crust.Crusts.Original)
                {
                    cal = 250;
                }
                if (PizzaCrust == Crust.Crusts.DeepDish)
                {
                    cal = 300;
                }

                foreach(PizzaTopping t in PossibleToppings)
                {
                    cal += t.BaseCalories;
                }

                if (PizzaSize == Size.Sizes.Small)
                {
                    cal = (uint)(cal * .75);
                }
                if (PizzaSize == Size.Sizes.Large)
                {
                    cal = (uint)(cal * 1.3);
                }

                return cal;
            }
        }

        /// <summary>
        /// Total calories
        /// </summary>
        virtual public uint CaloriesTotal => CaloriesPerEach * Slices;

        /// <summary>
        /// Sets up the instruction list for the pizza
        /// </summary>
        virtual public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (PizzaSize == Size.Sizes.Small)
                {
                    instructions.Add("Small");
                }
                if (PizzaSize == Size.Sizes.Medium)
                {
                    instructions.Add("Medium");
                }
                if (PizzaSize == Size.Sizes.Large)
                {
                    instructions.Add("Large");
                }

                if (PizzaCrust == Crust.Crusts.Thin)
                {
                    instructions.Add("Thin Crust");
                }
                if (PizzaCrust == Crust.Crusts.Original)
                {
                    instructions.Add("Original Crust");
                }
                if (PizzaCrust == Crust.Crusts.DeepDish)
                {
                    instructions.Add("Deep Dish");
                }

                foreach (PizzaTopping t in PossibleToppings)
                {
                    instructions.Add("Add " + t.Name);
                }

                return instructions;
            }
        }

        public Pizza()
        {
            PossibleToppings.Add(new PizzaTopping(Topping.Sausage, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Bacon, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Ham, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Pineapple, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Onions, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Olives, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Peppers, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, false));
        }

        /// <summary>
        /// A method that returns a toping if it is in the list or null if it is not;
        /// </summary>
        /// <param name="t">the topping to look for</param>
        /// <returns>the topping if found null if it is not in the list</returns>
        public PizzaTopping FindTopping(Topping t)
        {
            foreach(PizzaTopping top in PossibleToppings)
            {
                if(top.ToppingType == t)
                {
                    return top;
                } 
            }

            throw new ArgumentException("Pizza Topping not in list");
        }
        
    }
}
