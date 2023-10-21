using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// Interface for a generic menu item
    /// </summary>
    public interface IMenuItem : INotifyPropertyChanged
    {
        
        


        

        /// <summary>
        /// A generic Name property
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// A generic descritption property
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// A generic price property
        /// </summary>
        public decimal Price { get; }

        /// <summary>
        /// A generic Calories Per each property
        /// </summary>
        public uint CaloriesPerEach { get; }

        /// <summary>
        /// a generic Calorie total Property
        /// </summary>
        public uint CaloriesTotal { get; }

        /// <summary>
        /// A generic Special instruction property
        /// </summary>
        public IEnumerable<string> SpecialInstructions { get; }



    }
}
