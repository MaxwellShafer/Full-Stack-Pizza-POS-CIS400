using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Drink Base Class
    /// </summary>
    public abstract class Drinks : IMenuItem
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
        /// Abstract name property
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Abstract Description property
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Abstract price property
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Abstract Calories for each property
        /// </summary>
        public abstract uint CaloriesPerEach { get; }

        /// <summary>
        /// Abstract calorie total property
        /// </summary>
        public abstract uint CaloriesTotal { get; }

        /// <summary>
        /// Abstract Special Instruction property
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Abstract Drink size property
        /// </summary>
        abstract public Size DrinkSize { get; set; }

        /// <summary>
        /// If the drink has ice
        /// </summary>
        abstract public bool Ice { get; set; }
    }
}
