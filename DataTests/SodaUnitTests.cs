﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// test class for the Soda class
    /// </summary>
    public class SodaUnitTests
    {
        /// <summary>
        /// verifies that the Name property returns "Soda"
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsToSoda()
        {
            var soda = new Soda();
            string name = soda.Name;
            Assert.Equal("Soda", name);
        }

        /// <summary>
        /// verifies that the Description property returns "Standard Fountain Drink"
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaultsToStandardFountainDrink()
        {
            var soda = new Soda();
            string description = soda.Description;
            Assert.Equal("Standard Fountain Drink", description);
        }

        /// <summary>
        /// verifies that the Ice property defaults to true
        /// </summary>
        [Fact]
        public void IcePropertyDefaultsToTrue()
        {
            var soda = new Soda();
            bool ice = soda.Ice;
            Assert.True(ice);
        }

        /// <summary>
        /// verifies that the DrinkSize property defaults to Size.Medium
        /// </summary>
        [Fact]
        public void DrinkSizePropertyDefaultsToMedium()
        {
            var soda = new Soda();
            Size drinkSize = soda.DrinkSize;
            Assert.Equal(Size.Medium, drinkSize);
        }

        /// <summary>
        /// verifies that the DrinkType property defaults to SodaFlavor
        /// .Coke
        /// </summary>
        [Fact]
        public void DrinkTypePropertyDefaultsToCoke()
        {
            var soda = new Soda();
            SodaFlavor drinkType = soda.DrinkType;
            Assert.Equal(SodaFlavor.Coke, drinkType);
        }

        /// <summary>
        /// verifies that the Price property calculates correctly for a medium soda
        /// </summary>
        [Fact]
        public void PricePropertyCalculatesCorrectlyForMediumSoda()
        {
            var soda = new Soda();
            decimal price = soda.Price;
            Assert.Equal(2.00m, price);
        }

        /// <summary>
        /// verifies that the Calories property calculates correctly for a medium soda
        /// </summary>
        [Fact]
        public void CaloriesPropertyCalculatesCorrectlyForMediumSoda()
        {
            var soda = new Soda();
            uint calories = soda.CaloriesTotal;
            Assert.Equal(200U, calories);
        }

        /// <summary>
        /// verifies that the SpecialInstructions property contains the drink size and drink flavor
        /// </summary>
        [Fact]
        public void SpecialInstructionsPropertyContainsDrinkSizeAndDrinkFlavor()
        {
            var soda = new Soda();
            var instructions = soda.SpecialInstructions;
            Assert.Contains("Drink size: Medium", instructions);
            Assert.Contains("Drink flavor: Coke", instructions);
        }

        /// <summary>
        /// verifies that the SpecialInstructions property includes "Hold Ice" when Ice is set to false
        /// </summary>
        [Fact]
        public void SpecialInstructionsPropertyIncludesHoldIceWhenIceIsFalse()
        {
            var soda = new Soda();
            soda.Ice = false;
            var instructions = soda.SpecialInstructions;
            Assert.Contains("Hold Ice", instructions);
        }

        /// <summary>
        /// notify property test
        /// </summary>
        /// <param name="size">the size</param>
        /// <param name="propertyName">the property name</param>
        [Theory]
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
            Soda soda = new();
            Assert.PropertyChanged(soda, propertyName, () => {
                soda.DrinkSize = size;
            });
        }

        /// <summary>
        /// test if it implements properly
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Soda soda = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(soda);
        }
    }
}
