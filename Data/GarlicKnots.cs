﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class containing data for Garlic Knots
    /// </summary>
    public class GarlicKnots
    {
        /// <summary>
        /// gets the name of the garlic knots
        /// </summary>
        public string Name { get; } = "Garlic Knots";

        /// <summary>
        /// gets the description of the garlic knots
        /// </summary>
        public string Description { get; } = "Twisted rolls with garlic and butter";

        /// <summary>
        /// a private field to store the count 
        /// </summary>
        private uint _count = 8;

        /// <summary>
        /// gets or sets the count of wings. Defaults to 8, maximum of 12.
        /// </summary>
        public uint Count
        {

            get
            {
                return _count;
            }

            set
            {
                if (value >= 4 && value <= 12)
                {
                    _count = value;
                }
            }
        }

        /// <summary>
        /// gets the price of each garlic knot. $0.75 each
        /// </summary>
        public decimal Price { get; } = 0.75M;

        /// <summary>
        /// gets the calories per each garlic knot. 175
        /// </summary>
        public uint CaloriesPerEach { get; } = 175;

        /// <summary>
        /// gets the total number of calories in all garlic knots, considering the count.
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach * Count;

        /// <summary>
        /// gets special instructions for the garlic knots based on the count.
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                yield return $"{Count} Garlic Knots";
            }
        }
    }
}
