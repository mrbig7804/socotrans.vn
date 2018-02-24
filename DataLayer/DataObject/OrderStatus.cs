using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class OrderStatus
    {
        protected int _orderStatusID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        public OrderStatus()
        {
        }

        public OrderStatus(int orderStatusID, string title, string description)
        {
            _orderStatusID = orderStatusID;
            _title = title;
            _description = description;
        }

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
    }


}
