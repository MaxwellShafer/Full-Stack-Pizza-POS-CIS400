using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Tests for the Wings class
    /// </summary>
    public class WingsUnitTests
    {
        /// <summary>
        /// Test for the Name property.
        /// </summary>
        [Fact]
        public void NamePropertyShouldReturnCorrectValueTest()
        {
            var wings = new Wings();

            string name = wings.Name;

            Assert.Equal("Wings", name);
        }

        /// <summary>
        /// Test for the Description property.
        /// </summary>
        [Fact]
        public void DescriptionPropertyShouldReturnCorrectValueTest()
        {
            var wings = new Wings();

            string description = wings.Description;

            Assert.Equal("Chicken wings tossed in sauce", description);
        }

        /// <summary>
        /// Test for the BoneIn property.
        /// </summary>
        [Fact]
        public void BoneInPropertyShouldReturnDefaultValueTest()
        {
            var wings = new Wings();

            bool boneIn = wings.BoneIn;

            Assert.True(boneIn); // Default value should be true
        }

        /// <summary>
        /// Test for the Count property with valid input.
        /// </summary>
        [Theory]
        [InlineData(5, 5)]
        [InlineData(8, 8)]
        [InlineData(15, 5)] // Should enforce the maximum constraint
        public void CountPropertyShouldReturnValidValueTest(uint inputCount, uint expectedCount)
        {
            var wings = new Wings();

            wings.Count = inputCount;

            Assert.Equal(expectedCount, wings.Count);
        }

        /// <summary>
        /// Test for the Price property with different combinations of parameters.
        /// </summary>
        /// <param name="boneIn">Indicates if the wings are bone-in</param>
        /// <param name="count">The count of wings</param>
        /// <param name="sauce">The type of sauce</param>
        /// <param name="expectedPrice">The expected price</param>
        [Theory]
        [InlineData(true, 5, WingSauce.WingSauces.Medium, 7.5)]
        [InlineData(false, 10, WingSauce.WingSauces.HoneyBBQ, 17.5)]
        public void PricePropertyShouldReturnCorrectValueTest(bool boneIn, uint count, WingSauce.WingSauces sauce, decimal expectedPrice)
        {
            var wings = new Wings();
            wings.BoneIn = boneIn;
            wings.Count = count;
            wings.Sauce = sauce;

            decimal price = wings.Price;

            Assert.Equal(expectedPrice, price);
        }

        /// <summary>
        /// Test for the CaloriesPerEach property with different combinations of parameters.
        /// </summary>
        /// <param name="boneIn">Indicates if the wings are bone-in</param>
        /// <param name="sauce">The type of sauce</param>
        /// <param name="expectedCaloriesPerEach">The expected calories per each wing</param>
        [Theory]
        [InlineData(true, WingSauce.WingSauces.Medium, 225)]
        [InlineData(false, WingSauce.WingSauces.HoneyBBQ, 125)]
        public void CaloriesPerEachPropertyShouldReturnCorrectValueTest(bool boneIn, WingSauce.WingSauces sauce, uint expectedCaloriesPerEach)
        {
            var wings = new Wings();
            wings.BoneIn = boneIn;
            wings.Sauce = sauce;

            uint caloriesPerEach = wings.CaloriesPerEach;

            Assert.Equal(expectedCaloriesPerEach, caloriesPerEach);
        }

        /// <summary>
        /// Test for the CaloriesTotal property with different combinations of parameters.
        /// </summary>
        /// <param name="boneIn">Indicates if the wings are bone-in</param>
        /// <param name="count">The count of wings</param>
        /// <param name="sauce">The type of sauce</param>
        /// <param name="expectedCaloriesTotal">The expected total calories</param>
        [Theory]
        [InlineData(true, 5, WingSauce.WingSauces.Medium, 1125)]
        [InlineData(false, 10, WingSauce.WingSauces.HoneyBBQ, 1250)]
        public void CaloriesTotalPropertyShouldReturnCorrectValueTest(bool boneIn, uint count, WingSauce.WingSauces sauce, uint expectedCaloriesTotal)
        {
            var wings = new Wings();
            wings.BoneIn = boneIn;
            wings.Count = count;
            wings.Sauce = sauce;

            uint caloriesTotal = wings.CaloriesTotal;

            Assert.Equal(expectedCaloriesTotal, caloriesTotal);
        }

        /// <summary>
        /// Test for the SpecialInstructions property with different combinations of parameters.
        /// </summary>
        /// <param name="boneIn">Indicates if the wings are bone-in</param>
        /// <param name="count">The count of wings</param>
        /// <param name="sauce">The type of sauce</param>
        /// <param name="expectedInstruction1">The first expected instruction</param>
        /// <param name="expectedInstruction2">The second expected instruction</param>
        [Theory]
        [InlineData(true, 5, WingSauce.WingSauces.Medium, "5 Bone-In Wings", "Medium Sauce")]
        [InlineData(false, 10, WingSauce.WingSauces.HoneyBBQ, "10 Boneless Wings", "HoneyBBQ Sauce")]
        public void SpecialInstructionsPropertyShouldReturnCorrectValueTest(bool boneIn, uint count, WingSauce.WingSauces sauce, string expectedInstruction1, string expectedInstruction2)
        {
            var wings = new Wings();
            wings.BoneIn = boneIn;
            wings.Count = count;
            wings.Sauce = sauce;

            IEnumerable<string> specialInstructions = wings.SpecialInstructions;

            Assert.Contains(expectedInstruction1, specialInstructions);
            Assert.Contains(expectedInstruction2, specialInstructions);
        }
    }
}
