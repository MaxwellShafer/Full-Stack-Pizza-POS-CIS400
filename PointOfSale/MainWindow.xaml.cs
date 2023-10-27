using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using PizzaParlor.Data;

namespace PizzaParlor.PointOfSale
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Inintilizes Components
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Order();


        }

        

        /// <summary>
        /// handles back to menu button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void HandleBackToMenu(object sender, RoutedEventArgs e)
        {
            
            
             foreach (Grid grid in mainDock.Children.OfType<Grid>())
             {
                 foreach (MenuItemSelectionControl menuControl in grid.Children.OfType<MenuItemSelectionControl>())
                 {
                     menuControl.Visibility = Visibility.Visible;

                 }

                 foreach (UserControl orderControl in grid.Children.OfType<IEditOrder>())
                 {
                     
                         orderControl.Visibility = Visibility.Hidden;
                     
                 }



             }
            
        }

        /// <summary>
        /// handles the order cancel button
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void HandleCancelButton(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            OrderSummary.DataContext = order;
            mainDock.DataContext = order;

            foreach (Grid grid in mainDock.Children.OfType<Grid>())
            {
                foreach (MenuItemSelectionControl menuControl in grid.Children.OfType<MenuItemSelectionControl>())
                {
                    menuControl.Visibility = Visibility.Visible;

                }

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
        }

        /// <summary>
        /// handeles complete order button;
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        private void HandleCompleteOrder(object sender, RoutedEventArgs e)
        {          

            foreach( FrameworkElement orderSummaryControl in mainDock.Children)
            {
                
                orderSummaryControl.Visibility = Visibility.Collapsed;

            }

            


                PaymentControl completedOrder = new();
            completedOrder.DataContext = OrderSummary.DataContext;

            foreach (OrderSummaryControl orderSummaryControl in mainDock.Children.OfType<OrderSummaryControl>())
            {



                if (orderSummaryControl.DataContext is Order o)
                {
                    PaymentViewModel pay = new PaymentViewModel(o);
                    completedOrder.DataContext = pay;
                    
                }
            }
            mainDock.Children.Add(completedOrder);
            
        }
    }
}
