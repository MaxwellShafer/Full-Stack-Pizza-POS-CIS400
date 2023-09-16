using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataTests
{
    /// <summary>
    /// unit tests for the IcedTea class
    /// </summary>
    public class IcedTeaUnitTests
    {
        /// <summary>
        /// verifies that the name property is "Iced Tea"
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToIcedTeaTest()
        {
            var icedTea = new IcedTea();
            string name = icedTea.Name;
            Assert.Equal("Iced Tea", name);
        }

        /// <summary>
        /// verifies that the description property is "Freshly brewed sweet tea"
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToFreshlyBrewedSweetTeaTest()
        {
            var icedTea = new IcedTea();
            string description = icedTea.Description;
            Assert.Equal("Freshly brewed sweet tea", description);
        }

        /// <summary>
        /// verifies that the ice property defaults to true
        /// </summary>
        [Fact]
        public void IcePropertyDefaultsToTrueTest()
        {
            var icedTea = new IcedTea();
            bool ice = icedTea.Ice;
            Assert.True(ice);
        }

        /// <summary>
        /// verifies that the drinkSize property defaults to Medium
        /// </summary>
        [Fact]
        public void DrinkSizePropertyDefaultsToMediumTest()
        {
            var icedTea = new IcedTea();
            Size.Sizes drinkSize = icedTea.DrinkSize;
            Assert.Equal(Size.Sizes.Medium, drinkSize);
        }

        /// <summary>
        /// verifies that the price property returns the correct price based on drinkSize
        /// </summary>
        /// <param name="drinkSize">the drink size</param>
        /// <param name="expectedPrice">the expected price</param>
        [Theory]
        [InlineData(Size.Sizes.Small, 2.00)]
        [InlineData(Size.Sizes.Medium, 2.50)]
        [InlineData(Size.Sizes.Large, 3.00)]
        public void PricePropertyCalculatesCorrectlyTest(Size.Sizes drinkSize, decimal expectedPrice)
        {
            var icedTea = new IcedTea { DrinkSize = drinkSize };
            decimal price = icedTea.Price;
            Assert.Equal(expectedPrice, price);
        }

        /// <summary>
        /// verifies that the calories property returns the correct calories based on drinkSize
        /// </summary>
        /// <param name="drinkSize">the drink size</param>
        /// <param name="expectedCalories">the expected calories</param>
        [Theory]
        [InlineData(Size.Sizes.Small, 175U)]
        [InlineData(Size.Sizes.Medium, 220U)]
        [InlineData(Size.Sizes.Large, 275U)]
        public void CaloriesPropertyCalculatesCorrectlyTest(Size.Sizes drinkSize, uint expectedCalories)
        {
            var icedTea = new IcedTea { DrinkSize = drinkSize };
            uint calories = icedTea.Calories;
            Assert.Equal(expectedCalories, calories);
        }

        /// <summary>
        /// verifies that the specialInstructions property returns the correct instructions based on ice and drinkSize
        /// </summary>
        /// <param name="drinkSize">the drink size</param>
        /// <param name="ice">a flag indicating whether ice is included</param>
        /// <param name="expectedInstructions">the expected special instructions</param>
        [Theory]
        [InlineData(Size.Sizes.Small, true, new string[] { "Drink size: Small" })]
        [InlineData(Size.Sizes.Medium, false, new string[] { "Drink size: Medium", "Hold Ice" })]
        [InlineData(Size.Sizes.Large, true, new string[] { "Drink size: Large" })]
        public void SpecialInstructionsPropertyReturnsCorrectValueTest(Size.Sizes drinkSize, bool ice, string[] expectedInstructions)
        {
            var icedTea = new IcedTea { DrinkSize = drinkSize, Ice = ice };

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, icedTea.SpecialInstructions);
            }
        }
    }
}
