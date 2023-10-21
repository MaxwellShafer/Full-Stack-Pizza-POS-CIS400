using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// interface class for all edit controls
    /// </summary>
    interface IEditOrder
    {
        /// <summary>
        /// generic method stub for event handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public abstract void HandleAddToOrder(object sender, RoutedEventArgs e);
    }
}
