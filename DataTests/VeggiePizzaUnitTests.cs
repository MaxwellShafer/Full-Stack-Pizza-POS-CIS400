using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Tests for the VeggiePizza class
    /// </summary>
    public class VeggiePizzaUnitTests
    {
        /// <summary>
        /// Test for the Name property.
        /// </summary>
        [Fact]
        public void NamePropertyShouldReturnCorrectValueTest()
        {
            var veggiePizza = new VeggiePizza();

            string name = veggiePizza.Name;

            Assert.Equal("Veggie Pizza", name);
        }

        /// <summary>
        /// Test for the Description property.
        /// </summary>
        [Fact]
        public void DescriptionPropertyShouldReturnCorrectValueTest()
        {
            var veggiePizza = new VeggiePizza();

            string description = veggiePizza.Description;

            Assert.Equal("All the veggies", description);
        }

    }
}
