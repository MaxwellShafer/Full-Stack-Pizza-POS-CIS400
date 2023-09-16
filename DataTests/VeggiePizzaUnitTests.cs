using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Tests for the VeggiePizza class
    /// </summary>
    public class VeggiePizzaUnitTests
    {
        /// <summary>
        /// Test for the Name property.
        /// </summary>
        [Fact]
        public void NamePropertyShouldReturnCorrectValueTest()
        {
            var veggiePizza = new VeggiePizza();

            string name = veggiePizza.Name;

            Assert.Equal("Veggie Pizza", name);
        }

        /// <summary>
        /// Test for the Description property.
        /// </summary>
        [Fact]
        public void DescriptionPropertyShouldReturnCorrectValueTest()
        {
            var veggiePizza = new VeggiePizza();

            string description = veggiePizza.Description;

            Assert.Equal("All the veggies", description);
        }

        /// <summary>
        /// Test for the Olives property.
        /// </summary>
        [Fact]
        public void OlivesPropertyShouldReturnDefaultValueTest()
        {
            var veggiePizza = new VeggiePizza();

            bool olives = veggiePizza.Olives;

            Assert.True(olives); 
        }

        /// <summary>
        /// Test for the Peppers property.
        /// </summary>
        [Fact]
        public void PeppersPropertyShouldReturnDefaultValueTest()
        {
            var veggiePizza = new VeggiePizza();

            bool peppers = veggiePizza.Peppers;

            Assert.True(peppers);
        }

        /// <summary>
        /// Test for the Onions property.
        /// </summary>
        [Fact]
        public void OnionsPropertyShouldReturnDefaultValueTest()
        {
            var veggiePizza = new VeggiePizza();

            bool onions = veggiePizza.Onions;

            Assert.True(onions); 
        }

        /// <summary>
        /// Test for the Mushrooms property.
        /// </summary>
        [Fact]
        public void MushroomsPropertyShouldReturnDefaultValueTest()
        {
            var veggiePizza = new VeggiePizza();

            bool mushrooms = veggiePizza.Mushrooms;

            Assert.True(mushrooms); 
        }

        /// <summary>
        /// Test for the Slices property.
        /// </summary>
        [Fact]
        public void SlicesPropertyShouldReturnCorrectValueTest()
        {
            var veggiePizza = new VeggiePizza();

            uint slices = veggiePizza.Slices;

            Assert.Equal(8U, slices);
        }
        /// <summary>
        /// Test for price property using [InlineData]
        /// </summary>
        /// <param name="pizzaSize">The size of the pizza</param>
        /// <param name="crust">The type of crust</param>
        /// <param name="olives">A value indicating whether the pizza has olives</param>
        /// <param name="peppers">A value indicating whether the pizza has peppers</param>
        /// <param name="onions">A value indicating whether the pizza has onions</param>
        /// <param name="mushrooms">A value indicating whether the pizza has mushrooms</param>
        /// <param name="expectedPrice">The expected price of the pizza</param>
        [Theory]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, true, true, true, true, 14.99)]
        [InlineData(Size.Sizes.Small, Crust.Crusts.DeepDish, false, false, false, false, 11.99)]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.Original, true, true, false, true, 12.99)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Thin, false, false, true, false, 14.99)]
        public void PricePropertyShouldReturnCorrectValueTest(Size.Sizes pizzaSize, Crust.Crusts crust, bool olives, bool peppers, bool onions, bool mushrooms, decimal expectedPrice)
        {
            var veggiePizza = new VeggiePizza();
            veggiePizza.PizzaSize = pizzaSize;
            veggiePizza.Crusts = crust;
            veggiePizza.Olives = olives;
            veggiePizza.Peppers = peppers;
            veggiePizza.Onions = onions;
            veggiePizza.Mushrooms = mushrooms;

            decimal price = veggiePizza.Price;

            Assert.Equal(expectedPrice, price);
        }

        /// <summary>
        /// Test for CaloriesTotal property 
        /// </summary>
        /// <param name="pizzaSize">The size of the pizza</param>
        /// <param name="crust">The type of crust</param>
        /// <param name="olives">A value indicating whether the pizza has olives</param>
        /// <param name="peppers">A value indicating whether the pizza has peppers</param>
        /// <param name="onions">A value indicating whether the pizza has onions</param>
        /// <param name="mushrooms">A value indicating whether the pizza has mushrooms</param>
        /// <param name="expectedCaloriesPerEach">The expected calories per each slice</param>
        [Theory]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.Original, true, true, true, true, 270U)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Thin, false, false, false, false, 195U)]
        [InlineData(Size.Sizes.Small, Crust.Crusts.DeepDish, true, false, true, false, 232U)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, false, true, false, true, 338U)]
        public void CaloriesPerEachPropertyShouldReturnCorrectValueTest(Size.Sizes pizzaSize, Crust.Crusts crust, bool olives, bool peppers, bool onions, bool mushrooms, uint expectedCaloriesPerEach)
        {
            var veggiePizza = new VeggiePizza();
            veggiePizza.PizzaSize = pizzaSize;
            veggiePizza.Crusts = crust;
            veggiePizza.Olives = olives;
            veggiePizza.Peppers = peppers;
            veggiePizza.Onions = onions;
            veggiePizza.Mushrooms = mushrooms;

            uint caloriesPerEach = veggiePizza.CaloriesPerEach;

            Assert.Equal(expectedCaloriesPerEach, caloriesPerEach);
        }
        /// <summary>
        /// Test for CaloriesTotal property
        /// </summary>
        /// <param name="pizzaSize">The size of the pizza</param>
        /// <param name="crust">The type of crust</param>
        /// <param name="olives">A value indicating whether the pizza has olives</param>
        /// <param name="peppers">A value indicating whether the pizza has peppers</param>
        /// <param name="onions">A value indicating whether the pizza has onions</param>
        /// <param name="mushrooms">A value indicating whether the pizza has mushrooms</param>
        /// <param name="expectedCaloriesTotal">The expected total calories in the pizza</param>
        [Theory]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.Original, true, true, true, true, 2160U)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Thin, false, false, false, false, 1560U)]
        [InlineData(Size.Sizes.Small, Crust.Crusts.DeepDish, true, false, true, false, 1856U)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, false, true, false, true, 2704U)]
        public void CaloriesTotalPropertyShouldReturnCorrectValueTest(Size.Sizes pizzaSize, Crust.Crusts crust, bool olives, bool peppers, bool onions, bool mushrooms, uint expectedCaloriesTotal)
        {
            var veggiePizza = new VeggiePizza();
            veggiePizza.PizzaSize = pizzaSize;
            veggiePizza.Crusts = crust;
            veggiePizza.Olives = olives;
            veggiePizza.Peppers = peppers;
            veggiePizza.Onions = onions;
            veggiePizza.Mushrooms = mushrooms;

            uint caloriesTotal = veggiePizza.CaloriesTotal;

            Assert.Equal(expectedCaloriesTotal, caloriesTotal);
        }

        /// <summary>
        /// Test for the SpecialInstructions property.
        /// </summary>
        /// <param name="pizzaSize">The size of the pizza</param>
        /// <param name="crust">The type of crust</param>
        /// <param name="olives">A value indicating whether the pizza has olives</param>
        /// <param name="peppers">A value indicating whether the pizza has peppers</param>
        /// <param name="onions">A value indicating whether the pizza has onions</param>
        /// <param name="mushrooms">A value indicating whether the pizza has mushrooms</param>
        /// <param name="expectedInstructions">The expected special instructions for the pizza</param>
        [Theory]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.Original, true, true, false, true, new[] { "Medium Pizza", "Original Crust", "Hold Onions" })]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Thin, true, true, true, true, new[] { "Large Pizza", "Thin Crust" })]
        [InlineData(Size.Sizes.Small, Crust.Crusts.DeepDish, true, false, true, true, new[] { "Small Pizza", "DeepDish Crust", "Hold Peppers" })]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, false, true, true, false, new[] { "Large Pizza", "Original Crust", "Hold Olives", "Hold Mushrooms" })]
        public void SpecialInstructionsPropertyShouldReturnCorrectValueTest(Size.Sizes pizzaSize, Crust.Crusts crust, bool olives, bool peppers, bool onions, bool mushrooms, string[] expectedInstructions)
        {
            var veggiePizza = new VeggiePizza();
            veggiePizza.PizzaSize = pizzaSize;
            veggiePizza.Crusts = crust;
            veggiePizza.Olives = olives;
            veggiePizza.Peppers = peppers;
            veggiePizza.Onions = onions;
            veggiePizza.Mushrooms = mushrooms;

            IEnumerable<string> specialInstructions = veggiePizza.SpecialInstructions;

            Assert.Equal(expectedInstructions, specialInstructions);
        }

    }
}
