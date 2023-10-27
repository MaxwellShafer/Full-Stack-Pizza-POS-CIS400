using PizzaParlor.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PizzaParlor.PointOfSale
{

    /// <summary>
    /// a mvvm model for payment order control
    /// </summary>
    public class PaymentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Order data backing
        /// </summary>
        private Order _order; 

        /// <summary>
        /// pass through data
        /// </summary>
        public decimal Subtotal => _order.Subtotal;
        /// <summary>
        /// pass through data
        /// </summary>
        public decimal Tax => _order.Tax;
        /// <summary>
        /// pass through data
        /// </summary>
        public decimal Total => _order.Total;

        /// <summary>
        /// private backing field
        /// </summary>
        private decimal _paid = 0;

        /// <summary>
        /// property showing how much they paid
        /// </summary>
        public decimal Paid
        {
            get
            {
                return _paid;
            }
            set
            {
                if( value > Total)
                {
                    _paid = value;
                }
            }
        }

        /// <summary>
        /// calculates the change
        /// </summary>
         public decimal Change => Paid - Total;
        
        /// <summary>
        /// returns the recipt
        /// </summary>
        public string? Recipt
        {
            get
            {
                string path = @"C:\Users\kcmax\source\repos\status\pizza-parlor-MaxwellShafer\PointOfSale\recipt.txt";

                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("------------");
                        sw.WriteLine(_order.PlacedAt);
                        sw.WriteLine(_order.Number);

                        foreach (IMenuItem item in _order)
                        {
                            foreach (string s in item.SpecialInstructions)
                            {
                                sw.WriteLine(s);
                            }
                        }

                        sw.WriteLine("Subtotal: $" + Subtotal.ToString());
                        sw.WriteLine("Tax: $" + Tax.ToString());
                        sw.WriteLine("Total: $" + Total.ToString());
                        sw.WriteLine("Paid: $" + Paid.ToString());
                        sw.WriteLine("Change: $" + Change.ToString());
                        return sw.ToString();
                    }

                }
                else
                {
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine("------------");
                        sw.WriteLine(_order.PlacedAt);
                        sw.WriteLine(_order.Number);

                        foreach (IMenuItem item in _order)
                        {
                            foreach (string s in item.SpecialInstructions)
                            {
                                sw.WriteLine(s);
                            }
                        }

                        sw.WriteLine("Subtotal: $" + Subtotal.ToString());
                        sw.WriteLine("Tax: $" + Tax.ToString());
                        sw.WriteLine("Total: $" + Total.ToString());
                        sw.WriteLine("Paid: $" + Paid.ToString());
                        sw.WriteLine("Change: $" + Change.ToString());
                        return sw.ToString();
                    }
                }
                
                
            }
        }
        
        public PaymentViewModel(Order order)
        {
            _order = order;
            _paid = order.Total;
        }
    }
}
