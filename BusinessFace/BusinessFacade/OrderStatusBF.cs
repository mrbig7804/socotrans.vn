using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class OrderStatusBF
    {

        protected int _orderStatusID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        #region Public Properties

        public int OrderStatusID
        {
            get { return _orderStatusID; }
            set { _orderStatusID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        private static List<OrderStatusBF> GetOrderStatusBFListFromOrderStatusList(List<OrderStatus> recordset)
        {
            List<OrderStatusBF> ret = new List<OrderStatusBF>();
            foreach (OrderStatus record in recordset)
                ret.Add(GetOrderStatusBFFromOrderStatu(record));
            return ret;
        }

        private static OrderStatusBF GetOrderStatusBFFromOrderStatu(OrderStatus record)
        {
            if (record == null)
                return null;
            else
            {
                return new OrderStatusBF(record.OrderStatusID, record.Title, record.Description);
            }
        }

        public OrderStatusBF()
        {
        }


        public OrderStatusBF(int orderStatusID, string title, string description)
        {
            _orderStatusID = orderStatusID;
            _title = title;
            _description = description;
        }

        public static OrderStatusBF GetOrderStatusBF(int orderStatusID)
        {
            return GetOrderStatusBFFromOrderStatu(SiteProvider.OrderStatusProvider.GetOrderStatu(orderStatusID));
        }

        //Get by ForeignKey
        public static List<OrderStatusBF> GetOrderStatusByOrderStatusID(int orderStatusID)
        {
            return GetOrderStatusBFListFromOrderStatusList(SiteProvider.OrderStatusProvider.GetOrderStatusByOrderStatusID(orderStatusID));
        }

        //Get All
        public static List<OrderStatusBF> GetOrderStatusAll()
        {
            return GetOrderStatusBFListFromOrderStatusList(SiteProvider.OrderStatusProvider.GetOrderStatusAll());
        }

        //Insert
        public int Insert()
        {
            return OrderStatusBF.Insert(this.OrderStatusID, this.Title, this.Description);
        }

        //Update
        public bool Update()
        {
            return OrderStatusBF.Update(this.OrderStatusID, this.Title, this.Description);
        }

        //Delete
        public bool Delete()
        {
            return OrderStatusBF.Delete(this.OrderStatusID);
        }

        //Insert
        public static int Insert(int orderStatusID, string title, string description)
        {
            return SiteProvider.OrderStatusProvider.Insert(new OrderStatus(orderStatusID, title, description));
        }

        //Update
        public static bool Update(int orderStatusID, string title, string description)
        {
            return SiteProvider.OrderStatusProvider.Update(new OrderStatus(orderStatusID, title, description));
        }

        //Delete
        public static bool Delete(int orderStatusID)
        {
            return SiteProvider.OrderStatusProvider.Delete(orderStatusID);
        }

    }

}
