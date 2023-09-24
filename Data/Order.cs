using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// a class containing the neccicary methods to create and order
    /// </summary>
    public class Order : ICollection<IMenuItem>

    {
        /// <summary>
        /// count property
        /// </summary>
        public int Count => _order.Count();

        /// <summary>
        /// if the file is read only or not
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// private list to hold the order
        /// </summary>
        private List<IMenuItem> _order = new List<IMenuItem>(); 

        /// <summary>
        /// Adds an item to the order
        /// </summary>
        /// <param name="item">the item to add</param>
        public void Add(IMenuItem item)
        {
            _order.Add(item);
        }

        /// <summary>
        /// clears the order
        /// </summary>
        public void Clear()
        {
            _order.Clear();
        }

        /// <summary>
        /// checks to see if an item is in the order
        /// </summary>
        /// <param name="item">the item to look for</param>
        /// <returns>a bool if the item was found</returns>
        public bool Contains(IMenuItem item)
        {
            return _order.Contains(item);
        }

        /// <summary>
        /// Copys contents of order to an array
        /// </summary>
        /// <param name="array">the arrau to copy to</param>
        /// <param name="arrayIndex">where to start </param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _order.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// an enumerator for the order
        /// </summary>
        /// <returns>the contents of the order</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            foreach(IMenuItem menuItem in _order)
            {
                yield return menuItem;
            }
        }

        /// <summary>
        /// remove an item from the list
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>a bool if it was sucsessfull</returns>
        public bool Remove(IMenuItem item)
        {
            return _order.Remove(item);
        }

        /// <summary>
        /// returns the enumerator
        /// </summary>
        /// <returns>returns the enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// calculates the subtotal of the order
        /// </summary>
        /// <returns>the subtotal</returns>
        public decimal Subtotal()
        {
            decimal total = 0;
            foreach(IMenuItem item in _order)
            {
                total += item.Price;
            }

            return total;
        }

        /// <summary>
        ///  the tax rate
        /// </summary>
        public decimal TaxRate { get; set; } = .0915M;

        /// <summary>
        /// The total tax on the order
        /// </summary>
        public decimal Tax => TaxRate * Subtotal();

        /// <summary>
        /// Total cost of the order
        /// </summary>
        public decimal Total => Tax + Subtotal();
    }
}
