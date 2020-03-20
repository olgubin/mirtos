using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace UC.BLL.Store
{
    [Serializable]
    public class ShoppingCartItem
    {
        private int _id = 0;
        public int ID
        {
            get { return _id; }
            private set { _id = value; }
        }

        private string _title = "";
        public string Title
        {
            get { return _title; }
            private set { _title = value; }
        }

        private string _sku = "";
        public string SKU
        {
            get { return _sku; }
            private set { _sku = value; }
        }

        private int _currencyID = 0;
        public int CurrencyID
        {
            get { return _currencyID; }
            private set { _currencyID = value; }
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get 
            {
                Currency currency = CurrencyManager.GetByCurrencyID(CurrencyID);

                decimal unitPrice = 0.0m;

                if (currency != null)
                {
                    Currency workingCurrency = CurrencyManager.WorkingCurrency;

                    if (workingCurrency != null)
                    {
                        unitPrice = CurrencyManager.ConvertCurrency(_unitPrice, currency, workingCurrency);
                    }
                }

                return unitPrice; 
            }
            private set { _unitPrice = value; }
        }

        private int _quantity = 1;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public ShoppingCartItem(int id, string title, string sku, decimal unitPrice, int currencyID)
        {
            this.ID = id;
            this.Title = title;
            this.SKU = sku;
            this.UnitPrice = unitPrice;
            this.CurrencyID = currencyID;
        }

        public ShoppingCartItem(int id, string title, string sku, decimal unitPrice, int currencyID, int quantity)
        {
            this.ID = id;
            this.Title = title;
            this.SKU = sku;
            this.UnitPrice = unitPrice;
            this.CurrencyID = currencyID;
            this.Quantity = quantity;
        }
    }

    [Serializable]
    public class ShoppingCart
    {
        private Dictionary<int, ShoppingCartItem> _items = new Dictionary<int, ShoppingCartItem>();
        public ICollection Items
        {
            get { return _items.Values; }
        }

        /// <summary>
        /// Gets the sum total of the items' prices
        /// </summary>
        public decimal Total
        {
            get
            {
                decimal sum = 0.0m;
                foreach (ShoppingCartItem item in _items.Values)
                {
                    sum += item.UnitPrice * item.Quantity;
                }

                return sum;
            }
        }

        /// <summary>
        /// Количество товаров
        /// </summary>
        public decimal Count
        {
            get
            {
                int count = 0;
                foreach (ShoppingCartItem item in _items.Values)
                    count += item.Quantity;
                return count;
            }
        }

        /// <summary>
        /// Adds a new item to the shopping cart
        /// </summary>
        public void InsertItem(int id, string title, string sku, decimal unitPrice, string currencyID)
        {
            if (_items.ContainsKey(id))
                _items[id].Quantity += 1;
            else
                _items.Add(id, new ShoppingCartItem(id, title, sku, unitPrice, Int32.Parse(currencyID)));
        }

        public void InsertItem(int id, string title, string sku, decimal unitPrice, int currencyID, int quantity)
        {
            if (_items.ContainsKey(id))
            {
                _items[id].Quantity += quantity;
            }
            else
            {
                _items.Add(id, new ShoppingCartItem(id, title, sku, unitPrice, currencyID, quantity));
            }
        }

        /// <summary>
        /// Removes an item from the shopping cart
        /// </summary>
        public void DeleteItem(int id)
        {
            if (_items.ContainsKey(id))
            {
                ShoppingCartItem item = _items[id];
                item.Quantity -= 1;
                if (item.Quantity == 0)
                    _items.Remove(id);
            }
        }

        /// <summary>
        /// Removes all items of a specified product from the shopping cart
        /// </summary>
        public void DeleteProduct(int id)
        {
            if (_items.ContainsKey(id))
            {
                _items.Remove(id);
            }
        }

        /// <summary>
        /// Updates the quantity for an item
        /// </summary>
        public void UpdateItemQuantity(int id, int quantity)
        {
            if (_items.ContainsKey(id))
            {
                ShoppingCartItem item = _items[id];
                item.Quantity = quantity;
                if (item.Quantity <= 0)
                    _items.Remove(id);
            }
        }

        /// <summary>
        /// Clears the cart
        /// </summary>
        public void Clear()
        {
            _items.Clear();
        }
    }

    public class CurrentUserShoppingCart
    {
        public static ICollection GetItems()
        {
            return (HttpContext.Current.Profile as ProfileCommon).ShoppingCart.Items;
        }

        public static void DeleteItem(int id)
        {
            (HttpContext.Current.Profile as ProfileCommon).ShoppingCart.DeleteItem(id);
        }

        public static void DeleteProduct(int id)
        {
            (HttpContext.Current.Profile as ProfileCommon).ShoppingCart.DeleteProduct(id);
        }
    }
}