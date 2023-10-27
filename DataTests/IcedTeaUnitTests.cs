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
            Size drinkSize = icedTea.DrinkSize;
            Assert.Equal(Size.Medium, drinkSize);
        }

        /// <summary>
        /// verifies that the price property returns the correct price based on drinkSize
        /// </summary>
        /// <param name="drinkSize">the drink size</param>
        /// <param name="expectedPrice">the expected price</param>
        [Theory]
        [InlineData(Size.Small, 2.00)]
        [InlineData(Size.Medium, 2.50)]
        [InlineData(Size.Large, 3.00)]
        public void PricePropertyCalculatesCorrectlyTest(Size drinkSize, decimal expectedPrice)
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
        [InlineData(Size.Small, 175U)]
        [InlineData(Size.Medium, 220U)]
        [InlineData(Size.Large, 275U)]
        public void CaloriesPropertyCalculatesCorrectlyTest(Size drinkSize, uint expectedCalories)
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
        [InlineData(Size.Small, true, new string[] { "Drink size: Small" })]
        [InlineData(Size.Medium, false, new string[] { "Drink size: Medium", "Hold Ice" })]
        [InlineData(Size.Large, true, new string[] { "Drink size: Large" })]
        public void SpecialInstructionsPropertyReturnsCorrectValueTest(Size drinkSize, bool ice, string[] expectedInstructions)
        {
            var icedTea = new IcedTea { DrinkSize = drinkSize, Ice = ice };

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, icedTea.SpecialInstructions);
            }
        }

        /// <summary>
        /// notify property test
        /// </summary>
        /// <param name="size">the size</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(Size.Small, "Price")]
        [InlineData(Size.Medium, "Price")]
        [InlineData(Size.Large, "Price")]
        [InlineData(Size.Small, "CaloriesTotal")]
        [InlineData(Size.Medium, "CaloriesTotal")]
        [InlineData(Size.Large, "CaloriesTotal")]
        [InlineData(Size.Small, "CaloriesPerEach")]
        [InlineData(Size.Medium, "CaloriesPerEach")]
        [InlineData(Size.Large, "CaloriesPerEach")]
        [InlineData(Size.Small, "SpecialInstructions")]
        [InlineData(Size.Medium, "SpecialInstructions")]
        [InlineData(Size.Large, "SpecialInstructions")]
        public void ChangingSizeShouldNotifyOfPropertyChanges(Size size, string propertyName)
        {
            IcedTea tea = new();
            Assert.PropertyChanged(tea, propertyName, () => {
                tea.DrinkSize = size;
            });



        }
    }
}
