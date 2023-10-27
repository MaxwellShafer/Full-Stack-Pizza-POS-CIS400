using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace PizzaParlor.Data
{
    /// <summary>
    /// a class containing the neccicary methods to create and order
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyPropertyChanged, INotifyCollectionChanged

    {
        /// <summary>
        /// Property Changed Event handler
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;


        /// <summary>
        /// Collection changed event handler
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;


        /// <summary>
        /// holds the cumulative order
        /// </summary>
        private static int _cumOrder = 0;

        /// <summary>
        /// Static order number
        /// </summary>
        private int _number = 0;

        /// <summary>
        /// public property to get the order number
        /// </summary>
        public int Number
        {
            get
            {
                return _number;
            }

            init
            {
                _number = value;
            }
        }

        /// <summary>
        /// private backing field for datetime property
        /// </summary>
        private DateTime _dateTime = new();

        /// <summary>
        /// Keeps track of when the order was placed
        /// </summary>
        public DateTime PlacedAt
        {
            get
            {
                return _dateTime;
            }
            init
            {
                _dateTime = value;
            }
        }

        /// <summary>
        /// count property
        /// </summary>
        public int Count => _order.Count();

        /// <summary>
        /// if the file is read only or not
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// private list to hold the order
        /// </summary>
        private List<IMenuItem> _order = new List<IMenuItem>(); 

        /// <summary>
        /// Adds an item to the order
        /// </summary>
        /// <param name="item">the item to add</param>
        public void Add(IMenuItem item)
        {
            _order.Add(item);
            if(item is INotifyPropertyChanged menuItem)
            {
                item.PropertyChanged += HandlePropertyChanged;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
        }

       
        /// <summary>
        /// clears the order
        /// </summary>
        public void Clear()
        {
            _order.Clear();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));


        }

        /// <summary>
        /// checks to see if an item is in the order
        /// </summary>
        /// <param name="item">the item to look for</param>
        /// <returns>a bool if the item was found</returns>
        public bool Contains(IMenuItem item)
        {
            return _order.Contains(item);
        }

        /// <summary>
        /// Copys contents of order to an array
        /// </summary>
        /// <param name="array">the arrau to copy to</param>
        /// <param name="arrayIndex">where to start </param>
        public void CopyTo(IMenuItem[] array, int arrayIndex)
        {
            _order.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// an enumerator for the order
        /// </summary>
        /// <returns>the contents of the order</returns>
        public IEnumerator<IMenuItem> GetEnumerator()
        {
            foreach(IMenuItem menuItem in _order)
            {
                yield return menuItem;
            }
        }

        /// <summary>
        /// remove an item from the list
        /// </summary>
        /// <param name="item">the item to remove</param>
        /// <returns>a bool if it was sucsessfull</returns>
        public bool Remove(IMenuItem item)
        {
            int index = _order.IndexOf(item);
            if (index != -1)
            {
                _order.Remove(item);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item, index));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                return true;
            }
            return false;

        }

        /// <summary>
        /// returns the enumerator
        /// </summary>
        /// <returns>returns the enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// calculates the subtotal of the order
        /// </summary>
        /// <returns>the subtotal</returns>
        public decimal Subtotal
        {
            get
            {
                decimal total = 0;
                foreach (IMenuItem item in _order)
                {
                    total += item.Price;
                }

                return total;
            }
            
        }

        /// <summary>
        /// private backing feild for taxrate
        /// </summary>
        private decimal _taxRate = .0915M;

        /// <summary>
        ///  the tax rate
        /// </summary>
        public decimal TaxRate { get { return _taxRate; } 
            
            set 
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Count)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TaxRate)));
            } 
        
        }

        /// <summary>
        /// The total tax on the order
        /// </summary>
        public decimal Tax => TaxRate * Subtotal;

        /// <summary>
        /// Total cost of the order
        /// </summary>
        public decimal Total
        {
            get
            {   
                return Tax + Subtotal;

            }
        }

        public Order()
        {
            _cumOrder++;
            Number = _cumOrder;
            PlacedAt = DateTime.Now;
        }

        /// <summary>
        /// helps handle propertys changing
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        public void HandlePropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName != null)
            {
                //if (sender is Pizza pizza)
                //{
                   
                //    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, pizza));
                    
                    
                //}
                //if (sender is Sides side)
                //{
                    
                //    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, side));

                //}
                //if (sender is Drinks drink)
                //{
                    
                //    CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace, drink));

                //}
            }
           
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));

            
        }
    }
}
