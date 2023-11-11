using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// unit test for the Menu class
    /// </summary>
    public class MenuUnitTests
    {
        /// <summary>
        /// a test that checks if there is the proper number of pizzas
        /// </summary>
        [Fact]
        public void NumberOfPizzasMatchesCount()
        {
            Assert.Equal(45, Menu.Pizzas.Count());
        }


        /// <summary>
        /// a test that checks if there is the proper number of drinks
        /// </summary>
        [Fact]
        public void NumberOfDrinksMatchesCount()
        {
            Assert.Equal(18, Menu.Drinks.Count());
        }

        /// <summary>
        /// a test that checks if there is the proper number of sides
        /// </summary>
        [Fact]
        public void NumberOfSidesMatchesCount()
        {
            Assert.Equal(45, Menu.Drinks.Count());
        }

        
    }
}
