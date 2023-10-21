
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
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditPizzaItem editPizzaControl = new();
                parent.Children.Add(editPizzaControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddMeatPizzaClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditPizzaItem editPizzaControl = new();
                parent.Children.Add(editPizzaControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddVeggiePizzaClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditPizzaItem editPizzaControl = new();
                parent.Children.Add(editPizzaControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddHawaiianPizzaClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditPizzaItem editPizzaControl = new();
                parent.Children.Add(editPizzaControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddSupremePizzaClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditPizzaItem editPizzaControl = new();
                parent.Children.Add(editPizzaControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddWingsClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditWingControl wingControl = new();
                parent.Children.Add(wingControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddBreadSticksClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditBreadstickControl stickControl = new();
                parent.Children.Add(stickControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddGarlicKnotsClick(object sender, RoutedEventArgs e)
        {

            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditGarlicKnotsControl stickControl = new();
                parent.Children.Add(stickControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddCinnamonSticksClick(object sender, RoutedEventArgs e)
        {
            if (DataContext is Order list)
                if (this.VisualParent is System.Windows.Controls.Grid parent)
                {
                    EditCinnamonSticks stickControl = new();
                    parent.Children.Add(stickControl);
                    foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                    {
                        control.Visibility = Visibility.Hidden;
                    }

                }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddSodaClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditSodaControl stickControl = new();
                parent.Children.Add(stickControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }

        /// <summary>
        /// EventHandler for an MenuItem
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void AddTeaClick(object sender, RoutedEventArgs e)
        {
            if (this.VisualParent is System.Windows.Controls.Grid parent)
            {
                EditIcedTeaControl stickControl = new();
                parent.Children.Add(stickControl);
                foreach (MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>())
                {
                    control.Visibility = Visibility.Hidden;
                }

            }
        }
    }
}
