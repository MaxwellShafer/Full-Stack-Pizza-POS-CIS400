﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A generic Pizza class, Serves as the base for the specialty pizzas
    /// </summary>
    public class Pizza : IMenuItem
    {

        /// <summary>
        /// event handler
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// helper method
        /// </summary>
        /// <param name="propertyName">the property name</param>
        public virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// A Name property
        /// </summary>
        virtual public string Name { get; } = "Build-Your-Own Pizza";

        /// <summary>
        /// A description of the Pizza
        /// </summary>
        virtual public string Description { get; } = "A pizza you get to build";

        /// <summary>
        /// Number of slices
        /// </summary>
        public uint Slices { get; } = 8;

        /// <summary>
        /// private backing feild
        /// </summary>
        private Size _pizzaSize = Size.Medium;

        /// <summary>
        /// The size of the pizza
        /// </summary>
        virtual public Size PizzaSize
        {
            get
            {
                return _pizzaSize;
            }
            set
            {
                _pizzaSize = value; 
                OnPropertyChanged(nameof(PizzaSize));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }

        /// <summary>
        /// private backing feild
        /// </summary>
        private Crust _pizzaCrust = Crust.Original;

        /// <summary>
        /// The size of the pizza
        /// </summary>
        virtual public Crust PizzaCrust
        {
            get
            {
                return _pizzaCrust;
            }
            set
            {
                _pizzaCrust = value;
                OnPropertyChanged(nameof(PizzaCrust));
                OnPropertyChanged(nameof(Price));
                OnPropertyChanged(nameof(CaloriesPerEach));
                OnPropertyChanged(nameof(CaloriesTotal));
                OnPropertyChanged(nameof(SpecialInstructions));
            }
        }


        /// <summary>
        /// private backing field
        /// </summary>
        private List<PizzaTopping> _toppings = new List<PizzaTopping>();

        /// <summary>
        /// A list of the possible toppings
        /// </summary>
        virtual public List<PizzaTopping> PossibleToppings
        {
            get
            {
                return _toppings;
            }
            set
            {
                _toppings = value;
            }
        }

        /// <summary>
        /// helper method to track changes to list
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void OnToppingChanged(object? sender, PropertyChangedEventArgs e)
        {
            
            OnPropertyChanged(nameof(Price));
            OnPropertyChanged(nameof(CaloriesPerEach));
            OnPropertyChanged(nameof(CaloriesTotal));
            OnPropertyChanged(nameof(SpecialInstructions));
        }

        /// <summary>
        /// Calculates the price
        /// </summary>
        virtual public decimal Price
        {
            get
            {
                decimal price = 0M;

                if(PizzaSize == Size.Small)
                {
                    price = 7.99M;
                }
                if (PizzaSize == Size.Medium)
                {
                    price = 9.99M;
                }
                if (PizzaSize == Size.Large)
                {
                    price = 11.99M;
                }
                if(PizzaCrust == Crust.DeepDish)
                {
                    price += 1.00M;
                }

                foreach (PizzaTopping top in PossibleToppings)
                {
                    if (top.OnPizza)
                    {
                        price += 1.00M;
                    }
                }

                return price;
            }
        }
        /// <summary>
        /// Number of calories per each slice
        /// </summary>
        virtual public uint CaloriesPerEach
        {
            get
            {
                uint cal = 0;
                if(PizzaCrust == Crust.Thin)
                {
                    cal = 150;
                }
                if (PizzaCrust == Crust.Original)
                {
                    cal = 250;
                }
                if (PizzaCrust == Crust.DeepDish)
                {
                    cal = 300;
                }

                foreach(PizzaTopping t in PossibleToppings)
                {
                    if(t.OnPizza == true)
                    {
                        cal += t.BaseCalories;
                    }
                    
                }

                if (PizzaSize == Size.Small)
                {
                    cal = (uint)(cal * .75);
                }
                if (PizzaSize == Size.Large)
                {
                    cal = (uint)(cal * 1.3);
                }

                return cal;
            }
        }

        /// <summary>
        /// Total calories
        /// </summary>
        virtual public uint CaloriesTotal => CaloriesPerEach * Slices;

        /// <summary>
        /// Sets up the instruction list for the pizza
        /// </summary>
        virtual public IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new();

                if (PizzaSize == Size.Small)
                {
                    instructions.Add("Small");
                }
                if (PizzaSize == Size.Medium)
                {
                    instructions.Add("Medium");
                }
                if (PizzaSize == Size.Large)
                {
                    instructions.Add("Large");
                }

                if (PizzaCrust == Crust.Thin)
                {
                    instructions.Add("Thin Crust");
                }
                if (PizzaCrust == Crust.Original)
                {
                    instructions.Add("Original Crust");
                }
                if (PizzaCrust == Crust.DeepDish)
                {
                    instructions.Add("Deep Dish");
                }

                foreach (PizzaTopping t in PossibleToppings)
                {
                    if(t.OnPizza == true)
                    {
                        instructions.Add("Add " + t.Name);
                    }
                    
                }

                return instructions;
            }
        }

        public Pizza()
        {
            PossibleToppings.Add(new PizzaTopping(Topping.Sausage, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Bacon, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Ham, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Pepperoni, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Pineapple, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Onions, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Olives, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Peppers, false));
            PossibleToppings.Add(new PizzaTopping(Topping.Mushrooms, false));

            foreach( PizzaTopping t in PossibleToppings)
            {
                t.PropertyChanged += OnToppingChanged;
            }
        }

        /// <summary>
        /// A method that returns a toping if it is in the list or null if it is not;
        /// </summary>
        /// <param name="t">the topping to look for</param>
        /// <returns>the topping if found null if it is not in the list</returns>
        public PizzaTopping FindTopping(Topping t)
        {
            foreach(PizzaTopping top in PossibleToppings)
            {
                if(top.ToppingType == t)
                {
                    return top;
                } 
            }

            throw new ArgumentException("Pizza Topping not in list");
        }

        /// <summary>
        /// Override to string method
        /// </summary>
        /// <returns> the name</returns>
        public override string ToString()
        {
            return Name;
        }

    }
}
