using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// unit tests for the GarlicKnots class
    /// </summary>
    public class GarlicKnotsUnitTests
    {
        /// <summary>
        /// verifies that the Name property is "Garlic Knots"
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToGarlicKnotsTest()
        {
            var garlicKnots = new GarlicKnots();
            string name = garlicKnots.Name;
            Assert.Equal("Garlic Knots", name);
        }

        /// <summary>
        /// verifies that the Description property is "Twisted rolls with garlic and butter"
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToTwistedRollsWithGarlicAndButterTest()
        {
            var garlicKnots = new GarlicKnots();
            string description = garlicKnots.Description;
            Assert.Equal("Twisted rolls with garlic and butter", description);
        }

        /// <summary>
        /// verifies that the Count property defaults to 8
        /// </summary>
        [Fact]
        public void CountPropertyDefaultsTo8Test()
        {
            var garlicKnots = new GarlicKnots();
            uint count = garlicKnots.Count;
            Assert.Equal(8U, count);
        }

        /// <summary>
        /// verifies that the Count property enforces the minimum and maximum constraints
        /// </summary>
        /// <param name="inputCount">the input count</param>
        /// <param name="expectedCount">the expected count</param>
        [Theory]
        [InlineData(3U, 8U)]
        [InlineData(8U, 8U)]
        [InlineData(15U, 8U)]
        public void CountPropertyEnforcesMinimumAndMaximumConstraintsTest(uint inputCount, uint expectedCount)
        {
            var garlicKnots = new GarlicKnots();
            garlicKnots.Count = inputCount;
            Assert.Equal(expectedCount, garlicKnots.Count);
        }

        /// <summary>
        /// verifies that the Price property returns the correct price
        /// </summary>
        [Fact]
        public void PricePropertyDefaultsTo075Test()
        {
            var garlicKnots = new GarlicKnots();
            decimal price = garlicKnots.Price;
            Assert.Equal(0.75M, price);
        }

        /// <summary>
        /// verifies that the CaloriesPerEach property defaults to 175
        /// </summary>
        [Fact]
        public void CaloriesPerEachPropertyDefaultsTo175Test()
        {
            var garlicKnots = new GarlicKnots();
            uint caloriesPerEach = garlicKnots.CaloriesPerEach;
            Assert.Equal(175U, caloriesPerEach);
        }

        /// <summary>
        /// verifies that the CaloriesTotal property calculates correctly based on Count
        /// </summary>
        /// <param name="count">the count of garlic knots</param>
        /// <param name="expectedCalories">the expected total calories</param>
        [Theory]
        [InlineData(8U, 1400U)]
        [InlineData(5U, 875U)]
        [InlineData(12U, 2100U)]
        public void CaloriesTotalPropertyCalculatesCorrectlyTest(uint count, uint expectedCalories)
        {
            var garlicKnots = new GarlicKnots();
            garlicKnots.Count = count;
            Assert.Equal(expectedCalories, garlicKnots.CaloriesTotal);
        }

        /// <summary>
        /// verifies that the SpecialInstructions property returns the correct instructions based on Count
        /// </summary>
        /// <param name="count">the count of garlic knots</param>
        /// <param name="expectedInstructions">the expected special instructions</param>
        [Theory]
        [InlineData(8U, new string[] { "8 Garlic Knots" })]
        [InlineData(5U, new string[] { "5 Garlic Knots" })]
        [InlineData(12U, new string[] { "12 Garlic Knots" })]
        public void SpecialInstructionsPropertyReturnsCorrectValueTest(uint count, string[] expectedInstructions)
        {
            var garlicKnots = new GarlicKnots();
            garlicKnots.Count = count;

            var instructions = garlicKnots.SpecialInstructions;

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, instructions);
            }
        }
    }
}
