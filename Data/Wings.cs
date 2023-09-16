﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// A class definition for Wings
    /// </summary>
    public class Wings
    {
        /// <summary>
        /// gets the name of the wings
        /// </summary>
        public string Name { get; } = "Wings";

        /// <summary>
        /// gets the description of the wings
        /// </summary>
        public string Description { get; } = "Chicken wings tossed in sauce";

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
                if (value <= 4)
                {
                    _count = 4;
                }
                if (value >= 12)
                {
                    _count = 12;
                }
            }
        }

        /// <summary>
        /// gets or sets a value indicating whether the wings are bone in. Defaults to true.
        /// </summary>
        public bool BoneIn { get; set; } = true;

        /// <summary>
        /// gets or sets a and enum depending on the sauce
        /// </summary>
        public WingSauce.WingSauces Sauce { get; set; } = WingSauce.WingSauces.Medium;

        /// <summary>
        /// gets the price of the wings
        /// </summary>
        public decimal Price => (BoneIn ? ( (decimal)Count * (decimal)1.5) :((decimal)Count * (decimal)1.75));

        /// <summary>
        /// gets the calories per each wing ,
        /// </summary>
        public uint CaloriesPerEach
        {
            get
            {

                if (Sauce.Equals(WingSauce.WingSauces.HoneyBBQ))
                {
                    return 175U + (BoneIn ? 50U : 0U);
                }
                else
                {
                    return 125U + (BoneIn ? 50U : 0U);
                }

            }
        }
        /// <summary>
        /// gets the total number of calories of the wings
        /// </summary>
        public uint CaloriesTotal => CaloriesPerEach * Count;

        /// <summary>
        /// gets special instructions for the wings
        /// </summary>
        public IEnumerable<string> SpecialInstructions
        {
            get
            {
                if (BoneIn)
                { yield return Count.ToString() + " Bone-In Wings"; }
                else
                {
                    yield return Count.ToString() + " Bone-In Wings";
                }

                yield return Sauce.ToString() + " Sauce";

            }
           
            
        }
    }

}