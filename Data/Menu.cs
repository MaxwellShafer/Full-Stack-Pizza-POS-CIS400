using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParlor.Data
{
    /// <summary>
    /// static menu class
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// an enumerable for all types of pizza
        /// </summary>
        public static IEnumerable<IMenuItem> Pizzas
        {
            get
            {
                List<IMenuItem> pizzas = new();
                pizzas.AddRange(GenerateSizeAndCrust(Size.Small, Crust.Original));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Small, Crust.Thin));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Small, Crust.DeepDish));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Medium, Crust.Original));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Medium, Crust.Thin));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Medium, Crust.DeepDish));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Large, Crust.Original));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Large, Crust.Thin));
                pizzas.AddRange(GenerateSizeAndCrust(Size.Large, Crust.DeepDish));
                return pizzas;


            }
            
        }

        /// <summary>
        /// an enumerable for all types of sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides
        {
            get
            {
                List<IMenuItem> sides = new();
                sides.AddRange(GenerateWings(true));
                sides.AddRange(GenerateWings(false));
                sides.Add(new Breadsticks());
                Breadsticks b = new();
                b.Cheese = true;
                sides.Add(b);
                sides.Add(new CinnamonSticks());
                CinnamonSticks c = new();
                c.Frosting = false;
                sides.Add(c);
                return sides;
            }
            
        }

        /// <summary>
        /// an enumerable for all types of drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks
        {
            get
            {
                List < IMenuItem > drinks = new();
                drinks.AddRange(GenerateDrinks());
                drinks.Add(new IcedTea());
                return drinks;
            }
            
        }

        /// <summary>
        /// an enumerable for all menu items
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu
        {
            get
            {
                List<IMenuItem> list = new();
                list.AddRange(Pizzas);
                list.AddRange(Sides);
                list.AddRange(Drinks);
                return list;
            }
            
        }

        /// <summary>
        /// a method to simplify the adding of pizzas to the menu
        /// </summary>
        /// <param name="size">size</param>
        /// <param name="crust">crust</param>
        /// <returns>a list containg the pizzas</returns>
        static private List<IMenuItem> GenerateSizeAndCrust(Size size, Crust crust)
        {
            
            Pizza p = new();
            MeatsPizza m = new();
            VeggiePizza v = new();
            SupremePizza s = new();
            HawaiianPizza h = new();
            List<IMenuItem> list = new()
                {
                    p,
                    m,
                    v,
                    s,
                    h
                };

            foreach (IMenuItem item in list)
            {
                if (item is Pizza za)
                {
                    
                    za.PizzaSize = size;
                    za.PizzaCrust = crust;

                }
            }

            return list;
        }

        /// <summary>
        /// generate wings based off bone in
        /// </summary>
        /// <param name="b">bone in</param>
        /// <returns>a list</returns>
        static private List<IMenuItem>GenerateWings(bool b)
        {
            
            Wings m = new Wings();
            m.Sauce = WingSauce.Mild;
            m.BoneIn = b;
            Wings h = new Wings();
            h.Sauce = WingSauce.Hot;
            h.BoneIn = b;
            Wings bb = new Wings();
            bb.Sauce = WingSauce.HoneyBBQ;
            bb.BoneIn = b;
            Wings me = new Wings();
            me.Sauce = WingSauce.Medium;
            me.BoneIn = b;

            List<IMenuItem> list = new()
            {
                m,h,bb,me
            };
            return list;

        }

        /// <summary>
        /// private method to generate drinks -- side note at this point is when i remeberd you can index enums
        /// </summary>
        /// <returns>a list</returns>
        static private List<IMenuItem> GenerateDrinks()
        {
            List < IMenuItem > list  = new();
            for(int i = 0; i < 5; i++)
            {
                Soda s = new();
                for (int j = 0; j < 3; j++)
                {
                    s.DrinkSize = (Size)j;
                    s.DrinkType = (SodaFlavor)i;
                    list.Add(s);
                }
                
            }
            return list;
        }


        /// <summary>
        /// a method to filter by price
        /// </summary>
        /// <param name="items">the current item list</param>
        /// <param name="min">the min price</param>
        /// <param name="max">the max price</param>
        /// <returns>the new list</returns>
        public static IEnumerable<IMenuItem> FilterByPrice(IEnumerable<IMenuItem> items, decimal? min, decimal? max)
        {
            if (min == null) min = 0;
            if (max == null || max == 0) max = decimal.MaxValue;
            return from item in items where item.Price >= min && item.Price <= max select item;

        }

        /// <summary>
        /// a method to filter by cal
        /// </summary>
        /// <param name="items">the current item list</param>
        /// <param name="min">the min calories</param>
        /// <param name="max">the max calories</param>
        /// <returns>the new list</returns>
        public static IEnumerable<IMenuItem> FilterByCalories(IEnumerable<IMenuItem> items, int? min, int? max)
        {
            if (min == null) min = 0;
            if (max == null || max == 0) max = int.MaxValue;
            return from item in items where item.CaloriesPerEach >= min && item.CaloriesPerEach <= max select item;

        }


        /// <summary>
        /// filter by search term
        /// </summary>
        /// <param name="items">item list</param>
        /// <param name="term">the search term</param>
        /// <returns>the filterd list</returns>
        public static IEnumerable<IMenuItem> FilterBySearchTerms(IEnumerable<IMenuItem> items, string? term)
        {
            
            if (term != null)
            {
                string[] terms = term.Split(' ');
                List<IMenuItem> list = new List<IMenuItem>();
                foreach (IMenuItem item in items)
                {
                    foreach(string s in terms)
                    {
                        if (item.Name.Contains(s, StringComparison.CurrentCultureIgnoreCase))
                        {
                            list.Add(item);
                        }
                        else
                        {
                            foreach (string ins in item.SpecialInstructions)
                            {
                                if (ins.Contains(s, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    list.Add(item);
                                    break;
                                }
                            }
                        }
                        

                    }
                    
                }
                return list;
            }
            else
            {
                return items;
            }

        }



    }
}
