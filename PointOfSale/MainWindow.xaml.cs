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



    }
}
