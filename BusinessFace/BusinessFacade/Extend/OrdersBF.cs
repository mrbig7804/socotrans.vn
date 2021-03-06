using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    /// <summary>
    /// 06/12/07: sondt: thêm hàm Insert với với tham số chuyền vào là ShoppingCart
    /// 07/12/07: sondt: thêm thuộc tính OrderItems để lấy tất cả item trong order
    /// 08/12/07: sondt: thêm hàm Update 
    /// 12/12/07: sondt: thêm hàm GetOrdersByCustomerName để lấy đơn hàng theo tên người đặt hàng
    /// </summary> 

    public partial class OrdersBF : BaseBF
    {

        #region Custom Methods

        public static List<OrdersBF> GetOrdersByStatusID(int statusID, DateTime fromDate, DateTime toDate)
        {
            return GetOrdersBFListFromOrdersList(SiteProvider.OrdersProvider.GetOrdersByStatusID(statusID, fromDate, toDate));

        }


        public static List<OrdersBF> GetOrdersByCustomerName(string customerName)
        {
            return GetOrdersBFListFromOrdersList(SiteProvider.OrdersProvider.GetOrdersByCustomerName(CurrentUserName));
        }

        public static bool Update(int orderID, int statusID, DateTime shippedDate, string description, string note)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{

            //lấy đơn hàng trước khi update
            OrdersBF order = OrdersBF.GetOrdersBF(orderID);

            // update đơn hàng
            OrdersBF record = new OrdersBF(orderID, order.AddedDate, order.AddedBy, statusID, order.PaymentMethod, order.AccountCode, order.Total,
                order.ShippingFullName, order.ShippingAddress, order.ShippingCity, order.CustomerEmail, order.CustomerPhone, order.CustomerMoblie,
                shippedDate, description, note);

            bool ret = record.Update();

            // nếu đơn hàng lần đầu tiên được xác nhận thì trừ số sản phẩn trong kho
            //if (statusID == (int)StatusCode.Confirmed && order.StatusID == (int)StatusCode.WaitingForPayment)
            //{
            //    foreach (OrderItem item in order.Items)
            //        Product.DecrementProductUnitsInStock(item.ProductID, item.Quantity);
            //}

            //scope.Complete();
            return ret;
            //}
        }

        public static int Insert(ShoppingCart shoppingCart, string paymentMethod, string accountCode, string fullName, string shippingAddress, string shippingCity, string customerEmail, string customerPhone, string customerMoblie, string description)
        {
            // khởi tạo transaction
            //using (TransactionScope scope = new TransactionScope())
            //{
            // insert the master order
            //OrderDetails order = new OrderDetails(0, DateTime.Now,
            //   userName, 1, "", shippingMethod, shoppingCart.Total, shipping,
            //   shippingFirstName, shippingLastName, shippingStreet, shippingPostalCode,
            //   shippingCity, shippingState, shippingCountry, customerEmail, customerPhone,
            //   customerFax, DateTime.MinValue, transactionID, "");

            OrdersBF order = new OrdersBF(0, DateTime.Now, CurrentUserName, (int)OrderStatusCode.WaitingForPayment,
                paymentMethod, accountCode, shoppingCart.Total, fullName, shippingAddress, shippingCity, customerEmail, customerPhone,
                customerMoblie, DateTime.MinValue, description, "");

            int orderID = order.Insert();

            // insert the child order items
            foreach (ShoppingCartItem item in shoppingCart.Items)
            {
                OrderItemsBF orderItem = new OrderItemsBF(0, DateTime.Now, CurrentUserName,
                    orderID, item.ID, item.Title, item.UnitPrice, item.Quantity, item.Size, item.Color);

                orderItem.Insert();
            }

            //scope.Complete();

            return orderID;
            //}
        }

        #endregion

    }
}
