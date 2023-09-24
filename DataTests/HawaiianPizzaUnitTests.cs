using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Test class for Hawaiian Pizza
    /// </summary>
    public class HawaiianPizzaUnitTests
    {
        /// <summary>
        /// verifies that the name property is "Hawaiian Pizza".
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToHawaiianPizza()
        {
            var hawaiianPizza = new HawaiianPizza();
            string name = hawaiianPizza.Name;
            Assert.Equal("Hawaiian Pizza", name);
        }

        /// <summary>
        /// verifies that the description property is "The pizza with pineapple".
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToThePizzaWithPineapple()
        {
            var hawaiianPizza = new HawaiianPizza();
            string description = hawaiianPizza.Description;
            Assert.Equal("The pizza with pineapple", description);
        }

    }
}
