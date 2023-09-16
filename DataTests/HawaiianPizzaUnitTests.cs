using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    public class HawaiianPizzaUnitTests
    {
        /// <summary>
        /// verifies that the name property is "Hawaiian Pizza".
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToHawaiianPizza()
        {
            var hawaiianPizza = new HawaiianPizza();
            string name = hawaiianPizza.Name;
            Assert.Equal("Hawaiian Pizza", name);
        }

        /// <summary>
        /// verifies that the description property is "The pizza with pineapple".
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToThePizzaWithPineapple()
        {
            var hawaiianPizza = new HawaiianPizza();
            string description = hawaiianPizza.Description;
            Assert.Equal("The pizza with pineapple", description);
        }

        /// <summary>
        /// verifies that the ham property defaults to true.
        /// </summary>
        [Fact]
        public void HamPropertyDefaultsToTrue()
        {
            var hawaiianPizza = new HawaiianPizza();
            bool ham = hawaiianPizza.Ham;
            Assert.True(ham);
        }

        /// <summary>
        /// verifies that the pineapple property defaults to true.
        /// </summary>
        [Fact]
        public void PineapplePropertyDefaultsToTrue()
        {
            var hawaiianPizza = new HawaiianPizza();
            bool pineapple = hawaiianPizza.Pineapple;
            Assert.True(pineapple);
        }

        /// <summary>
        /// verifies that the onions property defaults to true.
        /// </summary>
        [Fact]
        public void OnionsPropertyDefaultsToTrue()
        {
            var hawaiianPizza = new HawaiianPizza();
            bool onions = hawaiianPizza.Onions;
            Assert.True(onions);
        }

        /// <summary>
        /// verifies that the slices property defaults to 8.
        /// </summary>
        [Fact]
        public void SlicesPropertyDefaultsTo8()
        {
            var hawaiianPizza = new HawaiianPizza();
            uint slices = hawaiianPizza.Slices;
            Assert.Equal(8U, slices);
        }

        /// <summary>
        /// verifies that the price property calculates correctly based on pizzaSize and crust.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="crust">The crust type.</param>
        /// <param name="expectedPrice">The expected price.</param>
        [Theory]
        [InlineData(Size.Sizes.Small, Crust.Crusts.Original, 11.99)]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.Original, 13.99)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, 15.99)]
        [InlineData(Size.Sizes.Small, Crust.Crusts.DeepDish, 12.99)]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.DeepDish, 14.99)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.DeepDish, 16.99)]
        public void PricePropertyCalculatesCorrectly(Size.Sizes pizzaSize, Crust.Crusts crust, decimal expectedPrice)
        {
            var hawaiianPizza = new HawaiianPizza
            {
                PizzaSize = pizzaSize,
                Crusts = crust
            };
            decimal price = hawaiianPizza.Price;
            Assert.Equal(expectedPrice, price);
        }

        /// <summary>
        /// verifies that the caloriesPerEach property calculates correctly based on pizzaSize, ham, pineapple, and onions.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="expectedCalories">The expected calories.</param>
        /// <param name="ham">A flag indicating whether ham is included.</param>
        /// <param name="pineapple">A flag indicating whether pineapple is included.</param>
        /// <param name="onions">A flag indicating whether onions are included.</param>
        [Theory]
        [InlineData(Size.Sizes.Small, 195U, false, true, false)]
        [InlineData(Size.Sizes.Medium, 275U, true, false, true)]
        [InlineData(Size.Sizes.Large, 344U, false, true, true)]
        public void CaloriesPerEachPropertyCalculatesCorrectly(Size.Sizes pizzaSize, uint expectedCalories, bool ham, bool pineapple, bool onions)
        {
            var hawaiianPizza = new HawaiianPizza
            {
                PizzaSize = pizzaSize,
                Ham = ham,
                Pineapple = pineapple,
                Onions = onions
            };
            uint caloriesPerEach = hawaiianPizza.CaloriesPerEach;
            Assert.Equal(expectedCalories, caloriesPerEach);
        }

        /// <summary>
        /// verifies that the caloriesTotal property calculates correctly based on pizzaSize, ham, pineapple, and onions.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="expectedCalories">The expected total calories.</param>
        /// <param name="ham">A flag indicating whether ham is included.</param>
        /// <param name="pineapple">A flag indicating whether pineapple is included.</param>
        /// <param name="onions">A flag indicating whether onions are included.</param>
        [Theory]
        [InlineData(Size.Sizes.Small, 1560U, false, true, false)]
        [InlineData(Size.Sizes.Medium, 2200U, true, false, true)]
        [InlineData(Size.Sizes.Large, 2752U, false, true, true)]
        public void CaloriesTotalPropertyCalculatesCorrectly(Size.Sizes pizzaSize, uint expectedCalories, bool ham, bool pineapple, bool onions)
        {
            var hawaiianPizza = new HawaiianPizza
            {
                PizzaSize = pizzaSize,
                Ham = ham,
                Pineapple = pineapple,
                Onions = onions
            };

            uint caloriesTotal = hawaiianPizza.CaloriesTotal;
            Assert.Equal(expectedCalories, caloriesTotal);
        }

        /// <summary>
        /// verifies that the SpecialInstructions property returns the correct instructions based on pizzaSize, crust, ham, pineapple, and onions.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="crust">The crust type.</param>
        /// <param name="ham">A flag indicating whether ham is included.</param>
        /// <param name="pineapple">A flag indicating whether pineapple is included.</param>
        /// <param name="onions">A flag indicating whether onions are included.</param>
        /// <param name="expectedInstructions">The expected instructions.</param>
        [Theory]
        [InlineData(Size.Sizes.Small, Crust.Crusts.Original, true, true, true, new string[] { "Small Pizza", "Original Crust" })]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.DeepDish, false, false, false, new string[] { "Medium Pizza", "DeepDish Crust", "Hold Ham", "Hold Pinapple", "Hold Onions" })]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, true, false, true, new string[] { "Large Pizza", "Original Crust", "Hold Pinapple" })]
        public void SpecialInstructionsPropertyReturnsCorrectValue(Size.Sizes pizzaSize, Crust.Crusts crust, bool ham, bool pineapple, bool onions, string[] expectedInstructions)
        {
            var hawaiianPizza = new HawaiianPizza
            {
                PizzaSize = pizzaSize,
                Crusts = crust,
                Ham = ham,
                Pineapple = pineapple,
                Onions = onions
            };

            var instructions = hawaiianPizza.SpecialInstructions;

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, instructions);
            }
        }
    }
}
