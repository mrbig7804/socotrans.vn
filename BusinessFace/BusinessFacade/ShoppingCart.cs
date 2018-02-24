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

namespace Zensoft.Website.BusinessLayer.BusinessFacade
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

        public string SmallPictureUrl { get; set; }

        //private string _sku = "";
        //public string SKU
        //{
        //    get { return _sku; }
        //    private set { _sku = value; }
        //}

        private string _size = "";
        public string Size
        {
            get { return _size; }
            private set { _size = value; }
        }

        private string _color = "";
        public string Color
        {
            get { return _color; }
            private set { _color = value; }
        }

        private int _unitPrice;
        public int UnitPrice
        {
            get { return _unitPrice; }
            private set { _unitPrice = value; }
        }

        private int _quantity;
        //private int id;
        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public int TotalItem { get { return this.Quantity * this.UnitPrice; } }

        public ShoppingCartItem(int id, string title, int unitPrice, string size, string color, int qty)
        {
            this.ID = id;
            this.Title = title;
            this.UnitPrice = unitPrice;
            this.Color = color;
            this.Size = size;
            this.Quantity = qty;

        }

        public ShoppingCartItem(int id, string title, int unitPrice, string image, int qty)
        {
            // TODO: Complete member initialization
            this.ID = id;
            this.Title = title;
            this.UnitPrice = unitPrice;
            this.SmallPictureUrl = image;
            this.Quantity = qty;
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
        public int Total
        {
            get
            {
                int sum = 0;
                foreach (ShoppingCartItem item in _items.Values)
                    sum += item.UnitPrice * item.Quantity;
                return sum;
            }
        }

        /// <summary>
        /// Adds a new item to the shopping cart
        /// </summary>
        public void InsertItem(int id, string title, int unitPrice, string size, string color, int qty)
        {
            if (_items.ContainsKey(id))
                _items[id].Quantity += qty;
            else
                _items.Add(id, new ShoppingCartItem(id, title, unitPrice, size, color, qty));
        }

        public void InsertItem(int id, string title, int unitPrice, string image, int qty)
        {
            if (_items.ContainsKey(id))
                _items[id].Quantity += qty;
            else
                _items.Add(id, new ShoppingCartItem(id, title, unitPrice, image, qty));
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

    //public class CurrentUserShoppingCart
    //{
    //    public static ICollection GetItems()
    //    {
    //        return (HttpContext.Current.Profile as ProfileCommon).ShoppingCart.Items;
    //    }

    //    public static void DeleteItem(int id)
    //    {
    //        (HttpContext.Current.Profile as ProfileCommon).ShoppingCart.DeleteItem(id);
    //    }

    //    public static void DeleteProduct(int id)
    //    {
    //        (HttpContext.Current.Profile as ProfileCommon).ShoppingCart.DeleteProduct(id);
    //    }
    //}
}
