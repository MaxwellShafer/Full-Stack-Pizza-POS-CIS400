using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTests
{
    /// <summary>
    /// Unit tests for the order class
    /// </summary>
    public class OrderUnitTests
    {
        /// <summary>
        /// A mock menu item for testing
        /// </summary>
        internal class MockMenuItem : IMenuItem
        {

            /// <summary>
            /// Name property
            /// </summary>
            public string Name { get; set; } = "";

            /// <summary>
            /// Description property
            /// </summary>
            public string Description { get; set; } = "";

            /// <summary>
            /// price
            /// </summary>
            public decimal Price { get; set; }
            /// <summary>
            /// Cal per each
            /// </summary>
            public uint CaloriesPerEach { get; set; }
            /// <summary>
            /// cal total
            /// </summary>
            public uint CaloriesTotal { get; set; }
            /// <summary>
            /// instrictions
            /// </summary>
            public IEnumerable<string> SpecialInstructions { get; set; }
        }

        /// <summary>
        /// Tests the sum of prices
        /// </summary>

        [Fact]
        public void SubtotalShouldEqualSumOftemPrices()
        {
            Order order = new Order();
            order.Add(new MockMenuItem() { Price = 2.00m });
            order.Add(new MockMenuItem() { Price = 1.50m });
            order.Add(new MockMenuItem() { Price = 4.00m });
            Assert.Equal(7.50m, order.Subtotal);
        }

        /// <summary>
        /// Asserts that readonly is false
        /// </summary>

        [Fact]
        public void ReadOnlySetToFalse()
        {
            Order order = new();

            Assert.False(order.IsReadOnly);
        }

        /// <summary>
        /// ensures that adding actually adds an item 
        /// </summary>
        [Fact]
        public void AddActuallyAddsItem()
        {
            Order order = new Order();
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());

            int expected = 3;
            Assert.Equal(expected,order.Count);
        }

        /// <summary>
        /// ensures that adding actually adds an item
        /// </summary>
        [Fact]
        public void CountPropertyWorks()
        {
            Order order = new Order();
            MockMenuItem menuitem = new MockMenuItem();
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(new MockMenuItem());
            order.Add(menuitem);
            order.Remove(menuitem);
            int expected = 3;
            Assert.Equal(expected, order.Count);
        }

        /// <summary>
        /// ensures that the remove method works when its the last item in the list
        /// </summary>
        [Fact]
        public void RemoveCorrectly()
        {
            Order order = new Order();
            MockMenuItem menuitem = new MockMenuItem();
            order.Add(menuitem);
            order.Remove(menuitem);
            int expected = 0;
            Assert.Equal(expected, order.Count);
        }

        /// <summary>
        /// Asserts that tax is right
        /// </summary>

        [Fact]
        public void TaxIsCorrect()
        {
            Order order = new();

            order.Add(new MockMenuItem() { Price = 2.00m });
            order.Add(new MockMenuItem() { Price = 1.50m });
            order.Add(new MockMenuItem() { Price = 4.00m });

            Assert.Equal(.686250M, order.Tax);
        }


        /// <summary>
        /// Asserts that total is right
        /// </summary>

        [Fact]
        public void TotalIsCorrect()
        {
            Order order = new();

            order.Add(new MockMenuItem() { Price = 2.00m });
            order.Add(new MockMenuItem() { Price = 1.50m });
            order.Add(new MockMenuItem() { Price = 4.00m });

            Assert.Equal(8.186250M, order.Total);
        }

        /// <summary>
        /// Test that changning the Tax Rate
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyOfPropertyChangeTest()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => {
                order.TaxRate = 0.15m;
            });
        }

        /// <summary>
        /// Test that changning the Tax triggers
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfPropertyChangeTaxTest()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "Tax", () => {
                order.Add(p);
            });
            
        }

        /// <summary>
        /// Test that changning the total property triggers
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfPropertyChangeTotalTest()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "Total", () => {
                order.Add(p);
            });
           
        }

        /// <summary>
        /// Test that changning the subtotal triggers
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyOfPropertyChangeSubtotalTest()
        {
            Order order = new Order();
            Pizza p = new Pizza();
            Assert.PropertyChanged(order, "Subtotal", () => {
                order.Add(p);
               
            });
           
        }

        

        /// <summary>
        /// Checks if it can be cast/ is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Checks if it can be cast/ is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// Test that new orders have new order numbers
        /// </summary>
        [Fact]
        public void NewOrdersShouldHaveNewOrderNumbersTest()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();
            Assert.Equal(order1.Number + 1, order2.Number);
            Assert.Equal(order2.Number +1, order3.Number);
            
        }

        /// <summary>
        /// ensures that the date and time is matching with the PlacedAt property
        /// </summary>
        [Fact]
        public void DateAndTimePropertyWorksTest()
        {
            Order order = new Order();
            Assert.Equal(DateTime.Now, order.PlacedAt, TimeSpan.FromSeconds(5));
        }


        /// <summary>
        /// ensures that the date and time is matching with the PlacedAt property
        /// </summary>
        [Fact]
        public void DateAndTimePropertyWorksWhenRequestedMultipleTest()
        {
            Order order = new Order();
            DateTime temp = order.PlacedAt;
            Assert.Equal(DateTime.Now, order.PlacedAt, TimeSpan.FromSeconds(5));
        }


        /// <summary>
        /// Test that new orders have new order numbers
        /// </summary>
        [Fact]
        public void NewOrdersShouldHaveNewOrderNumbersMultipleTest()
        {
            Order order1 = new Order();
            Order order2 = new Order();
            Order order3 = new Order();
           
            Assert.Equal(order1.Number + 1, order2.Number);
            Assert.Equal(order2.Number + 1, order3.Number);
            Assert.Equal(order1.Number + 1, order2.Number);
            Assert.Equal(order2.Number + 1, order3.Number);
            Assert.Equal(order1.Number + 1, order2.Number);
            Assert.Equal(order2.Number + 1, order3.Number);

        }
    }
}
