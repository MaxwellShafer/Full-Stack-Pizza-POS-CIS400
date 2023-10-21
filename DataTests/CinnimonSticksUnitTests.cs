using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataTests
{
    /// <summary>
    /// unit tests for Cinnamon Sticks
    /// </summary>
    public class CinnamonSticksUnitTests
    {
        /// <summary>
        /// verifies that the Name property defaults to "Cinnamon Sticks"
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToCinnamonSticksTest()
        {
            var cinnamonSticks = new CinnamonSticks();
            string name = cinnamonSticks.Name;
            Assert.Equal("Cinnamon Sticks", name);
        }

        /// <summary>
        /// verifies that the Description property defaults to "Like breadsticks but for dessert"
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToLikeBreadsticksButForDessertTest()
        {
            var cinnamonSticks = new CinnamonSticks();
            string description = cinnamonSticks.Description;
            Assert.Equal("Like breadsticks but for dessert", description);
        }

        /// <summary>
        /// verifies that the Count property defaults to 8
        /// </summary>
        [Fact]
        public void CountPropertyDefaultsTo8Test()
        {
            var cinnamonSticks = new CinnamonSticks();
            uint count = cinnamonSticks.SideCount;
            Assert.Equal(8U, count);
        }

        /// <summary>
        /// verifies that the Count property enforces minimum and maximum constraints
        /// </summary>
        /// <param name="inputCount">the input count value</param>
        /// <param name="expectedCount">the expected count after enforcing constraints</param>
        [Theory]
        [InlineData(3, 8)]
        [InlineData(8, 8)]
        [InlineData(15, 8)]
        public void CountPropertyEnforcesMinimumAndMaximumConstraintsTest(uint inputCount, uint expectedCount)
        {
            var cinnamonSticks = new CinnamonSticks();
            cinnamonSticks.SideCount = inputCount;
            Assert.Equal(expectedCount, cinnamonSticks.SideCount);
        }

        /// <summary>
        /// verifies that the Frosting property defaults to true
        /// </summary>
        [Fact]
        public void FrostingPropertyDefaultsToTrueTest()
        {
            var cinnamonSticks = new CinnamonSticks();
            bool frosting = cinnamonSticks.Frosting;
            Assert.True(frosting);
        }

        /// <summary>
        /// verifies that the Price property defaults to 0.90
        /// </summary>
        [Fact]
        public void PricePropertyDefaultsTo90Test()
        {
            var cinnamonSticks = new CinnamonSticks();
            decimal price = cinnamonSticks.Price;
            Assert.Equal(0.9M * 8, price);
        }

        /// <summary>
        /// verifies that the CaloriesPerEach property defaults to 190
        /// </summary>
        [Fact]
        public void CaloriesPerEachPropertyDefaultsTo190Test()
        {
            var cinnamonSticks = new CinnamonSticks();
            uint caloriesPerEach = cinnamonSticks.CaloriesPerEach;
            Assert.Equal(190U, caloriesPerEach);
        }

        /// <summary>
        /// verifies that the CaloriesTotal property calculates correctly based on frosting and count
        /// </summary>
        /// <param name="frosting">a flag indicating whether frosting is present</param>
        /// <param name="count">the count of cinnamon sticks</param>
        /// <param name="expectedCalories">the expected total calories</param>
        [Theory]
        [InlineData(true, 8, 1520U)]
        [InlineData(false, 5, 800U)]
        [InlineData(true, 12, 2280U)]
        [InlineData(false, 3, 1280U)]
        [InlineData(true, 4, 760U)]
        [InlineData(false, 10, 1600U)]
        [InlineData(true, 6, 1140U)]
        [InlineData(false, 7, 1120U)]
        public void CaloriesTotalPropertyCalculatesCorrectlyTest(bool frosting, uint count, uint expectedCalories)
        {
            var cinnamonSticks = new CinnamonSticks();
            cinnamonSticks.Frosting = frosting;
            cinnamonSticks.SideCount = count;
            Assert.Equal(expectedCalories, cinnamonSticks.CaloriesTotal);
        }

        /// <summary>
        /// verifies that the SpecialInstructions property returns the correct value based on count and frosting
        /// </summary>
        /// <param name="count">the count of cinnamon sticks</param>
        /// <param name="frosting">a flag indicating whether frosting is present</param>
        /// <param name="expectedInstructions">the expected special instructions</param>
        [Theory]
        [InlineData(8, true, "8 Cinnamon Sticks")]
        [InlineData(5, false, "5 Cinnamon Sticks", "Hold Frosting")]
        [InlineData(12, true, "12 Cinnamon Sticks")]
        [InlineData(3, false, "8 Cinnamon Sticks", "Hold Frosting")]
        [InlineData(4, true, "4 Cinnamon Sticks")]
        [InlineData(10, false, "10 Cinnamon Sticks", "Hold Frosting")]
        [InlineData(6, true, "6 Cinnamon Sticks")]
        [InlineData(7, false, "7 Cinnamon Sticks", "Hold Frosting")]
        public void SpecialInstructionsPropertyReturnsCorrectValueTest(uint count, bool frosting, params string[] expectedInstructions)
        {
            var cinnamonSticks = new CinnamonSticks();
            cinnamonSticks.SideCount = count;
            cinnamonSticks.Frosting = frosting;

            Assert.Equal(expectedInstructions.Length, cinnamonSticks.SpecialInstructions.Count());

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, cinnamonSticks.SpecialInstructions);
            }
        }


        /// <summary>
        /// test if it implements properly
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CinnamonSticks item = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(item);
        }

    }
}
