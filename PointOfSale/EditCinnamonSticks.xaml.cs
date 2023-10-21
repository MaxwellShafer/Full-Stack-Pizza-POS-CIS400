using PizzaParlor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for EditCinnamonSticks.xaml
    /// </summary>
    public partial class EditCinnamonSticks : UserControl, IEditOrder
    {
        public EditCinnamonSticks()
        {
            InitializeComponent();
            CinnamonSticks item = new();
            this.DataContext = item;
        }

        /// <summary>
        /// adds the item to the order
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">the e</param>
        public void HandleAddToOrder(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Visible;
                    if (control.DataContext is Order list)
                    {
                        if (this.DataContext is IMenuItem item)
                        {
                            if (!list.Contains(item))
                            {
                                list.Add(item);
                            }
                        }

                    }
                }

            }
        }

        /// <summary>
        /// hndles the bool element of a data item
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void HandleCheckbox(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is CinnamonSticks item && sender is CheckBox checkbox)
            {
                if (checkbox.IsChecked != null)
                {
                    if ((bool)checkbox.IsChecked)
                    {
                        item.Frosting = true;
                    }
                    else
                    {
                        item.Frosting = false;
                    }
                }

            }
        }
    }
}
