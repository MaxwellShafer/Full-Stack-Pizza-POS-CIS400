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
    /// Interaction logic for MenuItemSelectionControl.xaml
    /// </summary>
    public partial class MenuItemSelectionControl : UserControl
    {
        /// <summary>
        /// Initilizes Component
        /// </summary>
        public MenuItemSelectionControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddPizzaClick(object sender, RoutedEventArgs e)
        {
            if(DataContext is ObservableCollection<IMenuItem> list)
            {
                Pizza p = new Pizza();
                list.Add(p);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddMeatPizzaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                MeatsPizza p = new MeatsPizza();
                list.Add(p);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddVeggiePizzaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                VeggiePizza p = new VeggiePizza();
                list.Add(p);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddHawaiianPizzaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                HawaiianPizza p = new HawaiianPizza();
                list.Add(p);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddSupremePizzaClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Supreme");
            if (this.DataContext is ObservableCollection<IMenuItem> list)
            {
                SupremePizza p = new SupremePizza();
                list.Add(p);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddWingsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                Wings item = new Wings();
                list.Add(item);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddBreadSticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                Breadsticks item = new Breadsticks();
                list.Add(item);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddGarlicKnotsClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                GarlicKnots item = new GarlicKnots();
                list.Add(item);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddCinnamonSticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                CinnamonSticks item = new CinnamonSticks();
                list.Add(item);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddSodaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is ObservableCollection<IMenuItem> list)
            {
                Soda item = new Soda();
                list.Add(item);
            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddTeaClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is  ObservableCollection<IMenuItem> list)
            {
                IcedTea item = new IcedTea();
                list.Add(item);
            }
        }
    }
}
