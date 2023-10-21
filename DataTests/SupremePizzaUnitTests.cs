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
    public class SupremePizzaUnitTests
    {
        /// <summary>
        /// test for name property defaults to meats pizza.
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToMeatsPizzaTest()
        {
            var supremePizza = new SupremePizza();
            string name = supremePizza.Name;
            Assert.Equal("Supreme Pizza", name);
        }

        /// <summary>
        /// test for description property defaults to all the meats.
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToAllTheMeatsTest()
        {
            var supremePizza = new SupremePizza();
            string description = supremePizza.Description;
            Assert.Equal("Your standard supreme with meats and veggies", description);
        }

        /// <summary>
        /// notify property test
        /// </summary>
        /// <param name="size">the size</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
        [InlineData(Size.Small, "PizzaSize")]
        [InlineData(Size.Medium, "PizzaSize")]
        [InlineData(Size.Large, "PizzaSize")]
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
            SupremePizza pizza = new();
            Assert.PropertyChanged(pizza, propertyName, () => {
                pizza.PizzaSize = size;
            });
        }

    }
}
