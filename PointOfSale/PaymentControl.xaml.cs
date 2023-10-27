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
    /// Interaction logic for PaymentControl.xaml
    /// </summary>
    public partial class PaymentControl : UserControl
    {
        public PaymentControl()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// handles the back to menu button for the buttons
        /// </summary>
        /// <param name="sender">sender </param>
        /// <param name="e">e</param>
        public void HandleSubmitAndPay(object sender, RoutedEventArgs e)
        {
            
            if (this.VisualParent is DockPanel mainDock)
            {

                foreach (FrameworkElement element in mainDock.Children)
                {

                    element.Visibility = Visibility.Visible;
                }

                foreach (Grid grid in mainDock.Children.OfType<Grid>())
                {
                    int i = 0;
                    while (grid.Children.OfType<IEditOrder>().Count() > 0)
                    {
                        if (grid.Children[i] is IEditOrder editControl)
                        {
                            grid.Children.Remove((UIElement)editControl);
                            i--;
                        }
                        i++;
                    }
                }

                foreach (OrderSummaryControl orderSummaryControl in mainDock.Children.OfType<OrderSummaryControl>())
                {                

                    Order order = new();
                    orderSummaryControl.DataContext = order;
                    mainDock.DataContext = order;
                    orderSummaryControl.Visibility = Visibility.Visible;
                }

                mainDock.Visibility = Visibility.Visible;

             
                    if (this.DataContext is PaymentViewModel p)
                    { 
                        Console.WriteLine(p.Recipt);
                    }
                
                mainDock.Children.Remove(this);
            }


           

            

        }



        /// <summary>
        /// handles the back to menu button for the buttons
        /// </summary>
        /// <param name="sender">sender </param>
        /// <param name="e">e</param>
        public void HandleBackToMenu(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is DockPanel mainDock)
            {
               

                foreach ( FrameworkElement element in mainDock.Children)
                {
                    
                    element.Visibility = Visibility.Visible;
                }


                foreach (Grid grid in mainDock.Children.OfType<Grid>())
                {
                    foreach (UserControl orderControl in grid.Children.OfType<IEditOrder>())
                    {

                        orderControl.Visibility = Visibility.Hidden;

                    }

                    foreach (MenuItemSelectionControl menuControl in grid.Children.OfType<MenuItemSelectionControl>())
                    {
                        menuControl.Visibility = Visibility.Visible;

                    }
                }

                mainDock.Children.Remove(this);
            }

            


        }

    }
}
