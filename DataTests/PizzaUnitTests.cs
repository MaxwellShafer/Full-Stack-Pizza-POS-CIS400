using PizzaParlor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaParlor.Data.Crust;

namespace DataTests
{
    /// <summary>
    /// A class to test the pizza data class
    /// </summary>
    public class PizzaUnitTests
    {
        /// <summary>
        /// verifies that the name property is correct.
        /// </summary>
        [Fact]
        public void NamePropertyDefaultsCorrect()
        {
            var pizza = new Pizza();
            string name = pizza.Name;
            Assert.Equal("Build-Your-Own Pizza", name);
        }

        /// <summary>
        /// verifies that the description property is "The pizza with pineapple".
        /// </summary>
        [Fact]
        public void DescriptionPropertyDefaulteCorrect()
        {
            var pizza = new Pizza();
            string description = pizza.Description;
            Assert.Equal("A pizza you get to build", description);
        }


        /// <summary>
        /// verifies that the slices property defaults to 8.
        /// </summary>
        [Fact]
        public void SlicesPropertyDefaultsTo8()
        {
            var pizza = new Pizza();
            uint slices = pizza.Slices;
            Assert.Equal(8U, slices);
        }

        /// <summary>
        /// verifies that the price property calculates correctly based on pizzaSize and crust.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="crust">The crust type.</param>
        /// <param name="expectedPrice">The expected price.</param>
        /// <param name="topping1">topping1</param>
        /// <param name="topping2">topping2</param>
        /// <param name="topping3">topping3</param>
        [Theory]
        [InlineData(Size.Small, Crust.Original, Topping.Sausage, Topping.Ham, Topping.Bacon, 10.99)]
        [InlineData(Size.Medium, Crust.Original, Topping.Pineapple , Topping.Ham , Topping.Onions , 12.99)]
        [InlineData(Size.Large, Crust.Original, Topping.Mushrooms , Topping.Peppers , Topping.Pepperoni , 14.99)]
        [InlineData(Size.Small, Crust.DeepDish, Topping.Bacon , Topping.Pepperoni , Topping.Mushrooms , 11.99)]
        [InlineData(Size.Medium, Crust.DeepDish, Topping.Pepperoni , Topping.Olives , Topping.Peppers , 13.99)]
        [InlineData(Size.Large, Crust.DeepDish, Topping.Sausage , Topping.Pineapple , Topping.Pepperoni , 15.99)]
        public void PricePropertyCalculatesCorrectly(Size pizzaSize, Crust crust, Topping topping1, Topping topping2, Topping topping3, decimal expectedPrice)
        {
            var pizza = new Pizza
            {
                PizzaSize = pizzaSize,
                PizzaCrust = crust
            };

            pizza.FindTopping(topping1).OnPizza = true;
            pizza.FindTopping(topping2).OnPizza = true;
            pizza.FindTopping(topping3).OnPizza = true;


            decimal price = pizza.Price;
            Assert.Equal(expectedPrice, price);
        }

        /// <summary>
        /// verifies that the caloriesPerEach property calculates correctly based on pizzaSize, ham, pineapple, and onions.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="expectedCalories">The expected calories.</param>
        /// <param name="crust">The crust type.</param>
        /// <param name="topping1">topping1</param>
        /// <param name="topping2">topping2</param>
        /// <param name="topping3">topping3</param>
        [Theory]
        [InlineData(Size.Small, Crust.Original, Topping.Sausage, Topping.Ham, Topping.Bacon, 277U)]
        [InlineData(Size.Medium, Crust.Original, Topping.Pineapple, Topping.Ham, Topping.Onions, 370U)]
        [InlineData(Size.Large, Crust.Original, Topping.Mushrooms, Topping.Peppers, Topping.Pepperoni, 481U)]
        [InlineData(Size.Small, Crust.DeepDish, Topping.Bacon, Topping.Pepperoni, Topping.Mushrooms, 315U)]
        [InlineData(Size.Medium, Crust.DeepDish, Topping.Pepperoni, Topping.Olives, Topping.Peppers, 420U)]
        [InlineData(Size.Large, Crust.DeepDish, Topping.Sausage, Topping.Pineapple, Topping.Pepperoni, 546U)]
        public void CaloriesPerEachPropertyCalculatesCorrectly(Size pizzaSize, Crust crust, Topping topping1, Topping topping2, Topping topping3, uint expectedCalories)
        {
            var pizza = new Pizza
            {
                PizzaSize = pizzaSize,
                PizzaCrust = crust
            };

            pizza.FindTopping(topping1).OnPizza = true;
            pizza.FindTopping(topping2).OnPizza = true;
            pizza.FindTopping(topping3).OnPizza = true;

            uint caloriesPerEach = pizza.CaloriesPerEach;
            Assert.Equal(expectedCalories, caloriesPerEach);
        }

        /// <summary>
        /// verifies that the caloriesTotal property calculates correctly based on pizzaSize, ham, pineapple, and onions.
        /// </summary>
        /// <param name="pizzaSize">The pizza size.</param>
        /// <param name="expectedCalories">The expected total calories.</param>
        /// <param name="crust">The crust type.</param>
        /// <param name="topping1">topping1</param>
        /// <param name="topping2">topping2</param>
        /// <param name="topping3">topping3</param>
        [Theory]
        [InlineData(Size.Small, Crust.Original, Topping.Sausage, Topping.Ham, Topping.Bacon, 2216U)]
        [InlineData(Size.Medium, Crust.Original, Topping.Pineapple, Topping.Ham, Topping.Onions, 2960U)]
        [InlineData(Size.Large, Crust.Original, Topping.Mushrooms, Topping.Peppers, Topping.Pepperoni, 3848U)]
        [InlineData(Size.Small, Crust.DeepDish, Topping.Bacon, Topping.Pepperoni, Topping.Mushrooms, 2520U)]
        [InlineData(Size.Medium, Crust.DeepDish, Topping.Pepperoni, Topping.Olives, Topping.Peppers, 3360U)]
        [InlineData(Size.Large, Crust.DeepDish, Topping.Sausage, Topping.Pineapple, Topping.Pepperoni, 4368U)]
        public void CaloriesTotalPropertyCalculatesCorrectly(Size pizzaSize, Crust crust, Topping topping1, Topping topping2, Topping topping3, uint expectedCalories)
        {
            var pizza = new Pizza
            {
                PizzaSize = pizzaSize,
                PizzaCrust = crust
            };

            pizza.FindTopping(topping1).OnPizza = true;
            pizza.FindTopping(topping2).OnPizza = true;
            pizza.FindTopping(topping3).OnPizza = true;

            uint caloriesTotal = pizza.CaloriesTotal;
            Assert.Equal(expectedCalories, caloriesTotal);
        }


        /// <summary>
        /// A unit Test for the special instructions property for the pizza class.
        /// </summary>
        /// <param name="pizzaSize">th size of the pizza</param>
        /// <param name="crust">the type of crust</param>
        /// <param name="topping1">topping 1</param>
        /// <param name="topping2">topping 2</param>
        /// <param name="topping3"> topping 3</param>
        /// <param name="expectedInstructions">what we expect the instuctions to look like.</param>

        [Theory]
        [InlineData(Size.Small, Crust.Original, Topping.Sausage, Topping.Ham, Topping.Bacon, new string[] { "Small", "Original Crust", "Add Sausage", "Add Bacon", "Add Ham" })]
        [InlineData(Size.Medium, Crust.Thin, Topping.Pineapple, Topping.Ham, Topping.Onions, new string[] { "Medium", "Thin Crust", "Add Pineapple", "Add Ham", "Add Onions" })]
        [InlineData(Size.Large, Crust.DeepDish, Topping.Mushrooms, Topping.Peppers, Topping.Pepperoni, new string[] { "Large", "Deep Dish", "Add Mushrooms", "Add Peppers", "Add Pepperoni" })]
        [InlineData(Size.Small, Crust.Original, Topping.Bacon, Topping.Pepperoni, Topping.Mushrooms, new string[] { "Small", "Original Crust", "Add Pepperoni", "Add Bacon", "Add Mushrooms" })]
        [InlineData(Size.Medium, Crust.Thin, Topping.Pepperoni, Topping.Olives, Topping.Peppers, new string[] { "Medium", "Thin Crust", "Add Pepperoni", "Add Peppers", "Add Olives" })]
        [InlineData(Size.Large, Crust.DeepDish, Topping.Sausage, Topping.Pineapple, Topping.Pepperoni, new string[] { "Large", "Deep Dish", "Add Sausage", "Add Pineapple", "Add Pepperoni" })]
        public void SpecialInstructionsContainsCorrectValues(Size pizzaSize, Crust crust, Topping topping1, Topping topping2, Topping topping3, string[] expectedInstructions)
        {
            var pizza = new Pizza
            {
                PizzaSize = pizzaSize,
                PizzaCrust = crust
            };

            pizza.FindTopping(topping1).OnPizza = true;
            pizza.FindTopping(topping2).OnPizza = true;
            pizza.FindTopping(topping3).OnPizza = true;

            var instructions = pizza.SpecialInstructions;

            foreach (var expectedInstruction in expectedInstructions)
            {
                Assert.Contains(expectedInstruction, instructions);
            }
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
            Pizza pizza = new();
            Assert.PropertyChanged(pizza, propertyName, () => {
                pizza.PizzaSize = size;
            });
        }

        /// <summary>
        /// test if it implements properly
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            Pizza pizza = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(pizza);
        }

    }
}
