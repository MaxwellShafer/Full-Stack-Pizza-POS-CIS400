using System;
using System.Collections.Generic;
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
            Assert.Equal(7.50m, order.Subtotal());
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



    }
}
