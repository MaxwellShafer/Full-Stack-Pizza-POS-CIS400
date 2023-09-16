namespace DataTests
{
    /// <summary>
    /// Tests for the Breadstick class
    /// </summary>
    public class BreadsticksUnitTests
    {
        /// <summary>
        /// Test for the Name property.
        /// </summary>
        [Fact]
        public void NamePropertyShouldReturnCorrectValue()
        {
            
            var breadsticks = new Breadsticks();

            string name = breadsticks.Name;

            Assert.Equal("Breadsticks", name);
        }

        /// <summary>
        /// Test for the Description property.
        /// </summary>
        [Fact]
        public void DescriptionPropertyShouldReturnCorrectValue()
        {
            var breadsticks = new Breadsticks();

            string description = breadsticks.Description;

            Assert.Equal("Soft buttery breadsticks", description);
        }


        /// <summary>
        /// Verifies that the Count property setter enforces the minimum value constraint.
        /// </summary>
        /// <param name="inputCount">The input</param>
        /// <param name="expectedCount">The expected count</param>
        [Theory]
        [InlineData(3, 8)]
        [InlineData(8, 8)]
        [InlineData(15, 8)]
        public void CountPropertyEnforcesMinimumConstraintTest(uint inputCount, uint expectedCount)
        {
            var breadsticks = new Breadsticks();

            breadsticks.Count = inputCount;

            Assert.Equal(expectedCount, breadsticks.Count);
        }

        /// <summary>
        /// Verifies that the Count property setter enforces the maximum value constraint.
        /// </summary>
        /// <param name="inputCount">the input</param>
        /// <param name="expectedCount">the expected value</param>
        [Theory]
        [InlineData(3, 8)]
        [InlineData(10, 10)]
        [InlineData(15, 8)]
        public void CountPropertyEnforcesMaximumConstraintTest(uint inputCount, uint expectedCount)
        {
            var breadsticks = new Breadsticks();

            breadsticks.Count = inputCount;

            Assert.Equal(expectedCount, breadsticks.Count);
        }

        /// <summary>
        /// Test for the Cheese property.
        /// </summary>
        [Fact]
        public void CheesePropertyShouldReturnDefaultValue()
        {
            var breadsticks = new Breadsticks();

            bool cheese = breadsticks.Cheese;

            Assert.False(cheese);
        }

        /// <summary>
        /// Test for the Price property.
        /// </summary>
        [Fact]
        public void PricePropertyShouldReturnCorrectValue()
        {
            var breadsticks = new Breadsticks();

            decimal price = breadsticks.Price;

            Assert.Equal(0.75M * breadsticks.Count, price);
        }

        /// <summary>
        /// Test for the Price property.
        /// </summary>
        [Fact]
        public void PricePropertyWithCheeseShouldReturnCorrectValue()
        {
            var breadsticks = new Breadsticks();

            breadsticks.Cheese = true;
            decimal price = breadsticks.Price;
            

            Assert.Equal(1M * breadsticks.Count, price);
        }

        /// <summary>
        /// Test for the CaloriesPerEach property.
        /// </summary>
        [Fact]
        public void CaloriesPerEachPropertyShouldReturnCorrectValue()
        {
            var breadsticks = new Breadsticks();

            uint caloriesPerEach = breadsticks.CaloriesPerEach;

            Assert.Equal(150U, caloriesPerEach);
        }

        /// <summary>
        /// Test for the CaloriesTotal property with different combinations of cheese and count.
        /// </summary>
        /// <param name="cheese">if it has cheese</param>
        /// <param name="count">the count</param>
        /// <param name="expectedCalories">the expected amount of calories</param>
        [Theory]
        [InlineData(true, 8, 1600U)]
        [InlineData(false, 5, 750U)]
        [InlineData(true, 12, 2400U)]
        [InlineData(false, 3, 1200U)]
        [InlineData(true, 4, 800U)]
        [InlineData(false, 10, 1500U)]
        [InlineData(true, 6, 1200U)]
        [InlineData(false, 7, 1050U)]
        public void CaloriesTotalPropertyShouldReturnCorrectValueTest(bool cheese, uint count, uint expectedCalories)
        {
            var breadsticks = new Breadsticks();
            breadsticks.Count = count;
            breadsticks.Cheese = cheese;

            uint caloriesTotal = breadsticks.CaloriesTotal;

            Assert.Equal(expectedCalories, caloriesTotal);
        }

        /// <summary>
        /// Test for the SpecialInstructions property with different combinations of cheese and count.
        /// </summary>
        /// <param name="cheese">the cheese</param>
        /// <param name="count">the count</param>
        /// <param name="expectedInstructions">what the insructions should be</param>
        [Theory]
        [InlineData(true, 8, "8 Cheesesticks")]
        [InlineData(false, 5, "5 Breadsticks")]
        [InlineData(true, 12, "12 Cheesesticks")]
        [InlineData(false, 3, "8 Breadsticks")]
        [InlineData(true, 4, "4 Cheesesticks")]
        [InlineData(false, 10, "10 Breadsticks")]
        [InlineData(true, 6, "6 Cheesesticks")]
        [InlineData(false, 7, "7 Breadsticks")]
        public void SpecialInstructionsPropertyShouldReturnCorrectValueTest(bool cheese, uint count, string expectedInstructions)
        {
            var breadsticks = new Breadsticks();
            breadsticks.Count = count;
            breadsticks.Cheese = cheese;


            Assert.Equal(expectedInstructions, breadsticks.SpecialInstructions.First());
        }
    }
}