using System.Drawing;

namespace PizzaParlor.Data
{
    /// <summary>
    /// This is the definition for the supreme pizza class
    /// </summary>
    public class SupremePizza : Pizza, IMenuItem
    {
        /// <summary>
        /// The name of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        override public string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        override public string Description => "Your standard supreme with meats and veggies";


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
                    price -= 2.00M;
                }
                if (PizzaSize == Size.Medium)
                {
                    price -= 2.00M;
                }
                if (PizzaSize == Size.Large)
                {
                    price -= 2.00M;
                }


                return price;
            }
        }

        /// <summary>
        /// A constructor for a supreme pizza
        /// </summary>
        public SupremePizza() : base()
        {
            FindTopping(Topping.Mushrooms).OnPizza = true;
            FindTopping(Topping.Onions).OnPizza = true;
            FindTopping(Topping.Peppers).OnPizza = true;
            FindTopping(Topping.Olives).OnPizza = true;
            FindTopping(Topping.Pepperoni).OnPizza = true;
            FindTopping(Topping.Sausage).OnPizza = true;

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
                    if (t.ToppingType == Topping.Mushrooms || t.ToppingType == Topping.Onions || t.ToppingType == Topping.Sausage || t.ToppingType == Topping.Pepperoni | t.ToppingType == Topping.Olives | t.ToppingType == Topping.Peppers)
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