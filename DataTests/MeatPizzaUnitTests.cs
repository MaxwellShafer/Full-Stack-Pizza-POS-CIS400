﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Test cases for Meat pizza
    /// </summary>
    public class MeatsPizzaUnitTests
    {
        /// <summary>
        /// test for name property defaults to meats pizza.
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToMeatsPizzaTest()
        {
            var meatsPizza = new MeatsPizza();
            string name = meatsPizza.Name;
            Assert.Equal("Meats Pizza", name);
        }

        /// <summary>
        /// test for description property defaults to all the meats.
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToAllTheMeatsTest()
        {
            var meatsPizza = new MeatsPizza();
            string description = meatsPizza.Description;
            Assert.Equal("All the meats", description);
        }

    }
}
