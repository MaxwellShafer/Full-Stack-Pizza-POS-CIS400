using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// a class representing the toppings on a pizza.
    /// </summary>
    public class PizzaTopping : INotifyPropertyChanged
    {
        /// <summary>
        /// constructor for a pizza topping
        /// </summary>
        /// <param name="topping">the type of topping</param>
        /// <param name="onPizza">a bool if it is on the pizza</param>
        public PizzaTopping(Topping topping, bool onPizza)
        {
            ToppingType = topping;
            OnPizza = onPizza;
        }
        /// <summary>
        /// The topping type
        /// </summary>
        public Topping ToppingType { get; init; }


        private bool _onPizza;
        /// <summary>
        /// if it is on the pizza
        /// </summary>
        public bool OnPizza
        {
            get
            {
                return _onPizza;
            }
            set
            {
                _onPizza = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(OnPizza)));
            }
        }
        
        /// <summary>
        /// the name of the property
        /// </summary>
        public string Name
        {
            get
            {
                if (ToppingType == Topping.Sausage)
                {
                    return "Sausage";
                }
                if (ToppingType == Topping.Bacon)
                {
                    return "Bacon";
                }
                if (ToppingType == Topping.Ham)
                {
                    return "Ham";
                }
                if (ToppingType == Topping.Pepperoni)
                {
                    return "Pepperoni";
                }
                if (ToppingType == Topping.Pineapple)
                {
                    return "Pineapple";
                }
                if (ToppingType == Topping.Peppers)
                {
                    return "Peppers";
                }
                if (ToppingType == Topping.Mushrooms)
                {
                    return "Mushrooms";
                }
                if (ToppingType == Topping.Onions)
                {
                    return "Onions";
                }
                if (ToppingType == Topping.Olives)
                {
                    return "Olives";
                }

                throw new ArgumentException("Topping class: Missing Name?");
            }
        }

        /// <summary>
        /// The base calories of the topping
        /// </summary>
        public uint BaseCalories
        {
            get
            {
                if(ToppingType == Topping.Sausage)
                {
                    return 30;
                }
                if(ToppingType == Topping.Bacon)
                {
                    return 20;
                }
                if (ToppingType == Topping.Ham)
                {
                    return 20;
                }
                if (ToppingType == Topping.Pepperoni)
                {
                    return 20;
                }
                if (ToppingType == Topping.Pineapple)
                {
                    return 10;
                }
                if (ToppingType == Topping.Peppers)
                {
                    return 5;
                }
                if (ToppingType == Topping.Mushrooms)
                {
                    return 5;
                }
                if (ToppingType == Topping.Onions)
                {
                    return 5;
                }
                if (ToppingType == Topping.Olives)
                {
                    return 5;
                }

                throw new ArgumentException("Topping class: Missing Topping?");
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
