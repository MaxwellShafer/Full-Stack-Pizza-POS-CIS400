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
    /// Interaction logic for OrderSummaryControl.xaml
    /// </summary>
    public partial class OrderSummaryControl : UserControl
    {
        /// <summary>
        /// Initilizes Component
        /// </summary>
        public OrderSummaryControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// edits an item in the order
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">the e</param>
        public void HandleEditConrtrol(object sender, RoutedEventArgs e)
        {
            
            if (this.VisualParent is DockPanel parent)
            {
                //if(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(VisualTreeHelper.GetParent(parent))) is DockPanel mainDock )
                //{
                    foreach (Grid grid in parent.Children.OfType<Grid>())
                    {
                        foreach (MenuItemSelectionControl menuControl in grid.Children.OfType<MenuItemSelectionControl>())
                        {
                            menuControl.Visibility = Visibility.Hidden;

                        }

                        foreach (UserControl orderControl in grid.Children.OfType<IEditOrder>())
                        {
                            if (orderControl.DataContext == ((Button)sender).DataContext)
                            {
                                orderControl.Visibility = Visibility.Visible;
                            }
                        }
                           


                    }
            }


                        
               // }
               

        }
    }
}

