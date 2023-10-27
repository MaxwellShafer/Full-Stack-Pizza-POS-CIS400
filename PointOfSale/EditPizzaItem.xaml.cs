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
    /// Interaction logic for EditPizzaItem.xaml
    /// </summary>
    public partial class EditPizzaItem : UserControl, IEditOrder
    {
        public EditPizzaItem()
        {
            InitializeComponent();
            
        }


        /// <summary>
        /// adds the item to the order
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">the e</param>
        public void HandleAddToOrder(object sender, RoutedEventArgs e)
        {
             this.Visibility = Visibility.Hidden;
             if(this.VisualParent is System.Windows.Controls.Grid parent)
            {
                foreach( MenuItemSelectionControl control in parent.Children.OfType<MenuItemSelectionControl>()){
                    control.Visibility = Visibility.Visible;
                    if (control.DataContext is Order list)
                    {
                       if(this.DataContext is IMenuItem item)
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
        /// a method to generate topping controls
        /// </summary>
        /// <returns>the stackpanel containing the topping controls</returns>
        /// <exception cref="ArgumentException">if the data class insnt pizza</exception>
        public void LoadToppings()
        {
            if (DataContext is Pizza pizza)
            {
                StackPanel stack = new();
                TextBlock toping = new();
                toping.Text = "Toppings: ";
                toping.FontSize = 20;
                toping.Margin = new Thickness(5, 0, 5, 5);

                stack.Children.Add(toping);
                foreach (PizzaTopping topping in pizza.PossibleToppings)
                {
                    CheckBox box = new();
                    box.DataContext = topping;
                    Binding binding = new();
                    binding.Path = new PropertyPath(nameof(topping.OnPizza));
                    binding.Mode = BindingMode.TwoWay;
                    BindingOperations.SetBinding(box, CheckBox.IsCheckedProperty, binding);


                    TextBlock block = new();
                    block.Margin =  new Thickness(5, 0, 5, 0);
                    block.Text = topping.Name;
                    box.Content = block;
                    

                    stack.Children.Add(box);
                }

                mainGrid.Children.Add(stack);
                Grid.SetColumn(stack, 0);
                Grid.SetRow(stack, 1);
                
            }
            else
            {
                throw new ArgumentException("not pizza data context");
            }
        }
    }
}
