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

    }
}
