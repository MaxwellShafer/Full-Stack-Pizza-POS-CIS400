using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Test cases for Meat pizza
    /// </summary>
    public class MeatsPizzaUnitTests
    {
        /// <summary>
        /// test for name property defaults to meats pizza.
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToMeatsPizzaTest()
        {
            var meatsPizza = new MeatsPizza();
            string name = meatsPizza.Name;
            Assert.Equal("Meats Pizza", name);
        }

        /// <summary>
        /// test for description property defaults to all the meats.
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToAllTheMeatsTest()
        {
            var meatsPizza = new MeatsPizza();
            string description = meatsPizza.Description;
            Assert.Equal("All the meats", description);
        }

        /// <summary>
        /// test for sausage property defaults to true.
        /// </summary>
        [Fact]
        public void SausagePropertyDefaultsToTrueTest()
        {
            var meatsPizza = new MeatsPizza();
            bool sausage = meatsPizza.Sausage;
            Assert.True(sausage);
        }

        /// <summary>
        /// test for pepperoni property defaults to true.
        /// </summary>
        [Fact]
        public void PepperoniPropertyDefaultsToTrueTest()
        {
            var meatsPizza = new MeatsPizza();
            bool pepperoni = meatsPizza.Pepperoni;
            Assert.True(pepperoni);
        }

        /// <summary>
        /// test for ham property defaults to true.
        /// </summary>
        [Fact]
        public void HamPropertyDefaultsToTrueTest()
        {
            var meatsPizza = new MeatsPizza();
            bool ham = meatsPizza.Ham;
            Assert.True(ham);
        }

        /// <summary>
        /// test for bacon property defaults to true.
        /// </summary>
        [Fact]
        public void BaconPropertyDefaultsToTrueTest()
        {
            var meatsPizza = new MeatsPizza();
            bool bacon = meatsPizza.Bacon;
            Assert.True(bacon);
        }

        /// <summary>
        /// test for slices property defaults to 8.
        /// </summary>
        [Fact]
        public void SlicesPropertyDefaultsTo8Test()
        {
            var meatsPizza = new MeatsPizza();
            uint slices = meatsPizza.Slices;
            Assert.Equal(8U, slices);
        }

        /// <summary>
        /// test for price property calculates correctly.
        /// </summary>
        /// <param name="pizzaSize">size</param>
        /// <param name="crust">crust</param>
        /// <param name="expectedPrice">expected price</param>
        [Theory]
        [InlineData(Size.Sizes.Small, Crust.Crusts.Original, 13.99)]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.Original, 15.99)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, 17.99)]
        [InlineData(Size.Sizes.Small, Crust.Crusts.DeepDish, 14.99)]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.DeepDish, 16.99)]
        [InlineData(Size.Sizes.Large, Crust.Crusts.DeepDish, 18.99)]
        public void PricePropertyCalculatesCorrectlyTest(Size.Sizes pizzaSize, Crust.Crusts crust, decimal expectedPrice)
        {
            var meatsPizza = new MeatsPizza
            {
                PizzaSize = pizzaSize,
                Crusts = crust
            };
            decimal price = meatsPizza.Price;
            Assert.Equal(expectedPrice, price);
        }

        /// <summary>
        /// test for calories pereach property calculates correctly.
        /// </summary>
        /// <param name="pizzaSize">the size of the pizza</param>
        /// <param name="expectedCalories">the expected claories</param>
        /// <param name="sausage">sausage</param>
        /// <param name="pepperoni">pepperoni</param>
        /// <param name="bacon">bacon</param>
        /// <param name="ham">ham</param>
        [Theory]
        [InlineData(Size.Sizes.Small, 217U, false, true, false, true)]
        [InlineData(Size.Sizes.Medium, 320U, true, false, true, true)]
        [InlineData(Size.Sizes.Large, 416U, true, true, false, true)]
        public void CaloriesPerEachPropertyCalculatesCorrectlyTest(Size.Sizes pizzaSize, uint expectedCalories, bool sausage, bool pepperoni, bool bacon, bool ham)
        {
            var meatsPizza = new MeatsPizza
            {
                PizzaSize = pizzaSize,
                Sausage = sausage,
                Pepperoni = pepperoni,
                Bacon = bacon,
                Ham = ham
            };
            uint caloriesPerEach = meatsPizza.CaloriesPerEach;
            Assert.Equal(expectedCalories, caloriesPerEach);
        }


        /// <summary>
        /// test for calories total property calculates correctly.
        /// </summary>
        /// <param name="pizzaSize">the size of the pizza</param>
        /// <param name="expectedCalories">the expected calories</param>
        /// <param name="sausage">Sausage</param>
        /// <param name="pepperoni">Pepperoni</param>
        /// <param name="bacon">Bacon</param>
        /// <param name="ham">Ham</param>
        [Theory]
        [InlineData(Size.Sizes.Small, 1736U, false, true, false, true)]
        [InlineData(Size.Sizes.Medium, 2560U, true, false, true, true)]
        [InlineData(Size.Sizes.Large, 3328U, true, true, false, true)]
        public void CaloriesTotalPropertyCalculatesCorrectlyTest(Size.Sizes pizzaSize, uint expectedCalories, bool sausage, bool pepperoni, bool bacon, bool ham)
        {
            var meatsPizza = new MeatsPizza
            {
                PizzaSize = pizzaSize,
                Sausage = sausage,
                Pepperoni = pepperoni,
                Bacon = bacon,
                Ham = ham
            };

            uint caloriesTotal = meatsPizza.CaloriesTotal;
            Assert.Equal(expectedCalories, caloriesTotal);
        }


        /// <summary>
        /// test for special instructions property returns correctvalue.
        /// </summary>
        /// <param name="pizzaSize">the pizza size</param>
        /// <param name="crust"> the crust</param>
        /// <param name="ham">the ham</param>
        /// <param name="sausage">the sausage</param>
        /// <param name="bacon">the bacon</param>
        /// <param name="pepperoni">peperonis</param>
        /// <param name="expectedInstructions">the expected instructions</param>
        [Theory]
        [InlineData(Size.Sizes.Small, Crust.Crusts.Original, false, true, true, true, new string[] { "Small Pizza", "Original Crust", "Hold Ham" })]
        [InlineData(Size.Sizes.Medium, Crust.Crusts.DeepDish, true, false, false, false, new string[] { "Medium Pizza", "DeepDish Crust", "Hold Sausage", "Hold Bacon", "Hold Pepperoni" })]
        [InlineData(Size.Sizes.Large, Crust.Crusts.Original, true, false, false, false, new string[] { "Large Pizza", "Original Crust", "Hold Bacon" })]
        public void SpecialInstructionsPropertyReturnsCorrectValueTest(Size.Sizes pizzaSize, Crust.Crusts crust, bool ham, bool sausage, bool bacon, bool pepperoni, string[] expectedInstructions)
        {
            var meatsPizza = new MeatsPizza
            {
                PizzaSize = pizzaSize,
                Crusts = crust,
                Ham = ham,
                Sausage = sausage,
                Bacon = bacon,
                Pepperoni = pepperoni
            };

            var instructions = meatsPizza.SpecialInstructions;

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, instructions);
            }
        }
    }
}
