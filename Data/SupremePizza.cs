using System.Drawing;

namespace PizzaParlor.Data
{
    
    public class SupremePizza
    {
        /// <summary>
        /// The name of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is an example of an get-only autoproperty with a default value
        /// </remarks>
        public string Name { get; } = "Supreme Pizza";

        /// <summary>
        /// The description of the SupremePizza instance
        /// </summary>
        /// <remarks>
        /// This is also a get-only autoproperty, but it was declared using lambda syntax
        /// </remarks>
        public string Description => "Your standard supreme with meats and veggies";

        /// <summary>
        /// Whether this SupremePizza instance contains sausage
        /// </summary>
        public bool Sausage { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains pepperoni
        /// </summary>
        public bool Pepperoni { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains olives
        /// </summary>
        public bool Olives { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains peppers
        /// </summary>
        public bool Peppers { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains onions
        /// </summary>
        public bool Onions { get; set; } = true;

        /// <summary>
        /// Whether this SupremePizza instance contains mushrooms
        /// </summary>
        public bool Mushrooms { get; set; } = true;

        /// <summary>
        /// The number of slices in this SupremePizza instance
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// The price of this SupremePizza instance
        /// </summary>
        public decimal Price
        {
            get
            {
                return 13.99m;
            }
        }

        /// <summary>
        /// The number of calories in each slice of this SupremePizza instance
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {
                uint cals = 250;

                if (Sausage) cals += 30;
                if (Pepperoni) cals += 20;
                if (Olives) cals += 5;
                if (Peppers) cals += 5;
                if (Onions) cals += 5;
                if (Mushrooms) cals += 5;

                return cals;
            }
        }

        /// <summary>
        /// The total number of calories in this SupremePizza instance
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
        /// Special instructions for the preparation of this FlyingSaucer
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (!Sausage) instructions.Add("Hold Sausage");
                if (!Pepperoni) instructions.Add("Hold Pepperoni");
                if (!Olives) instructions.Add("Hold Olives");
                if (!Onions) instructions.Add("Hold Onions");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                return instructions;
            }
        }
    }
}