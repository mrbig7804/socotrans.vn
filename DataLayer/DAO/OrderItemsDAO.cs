using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;


namespace Zensoft.Website.DataLayer.DAO
{
    public class OrderItemsDAO : OrderItemsBaseDAO
    {
    }

    public class OrderItemsBaseDAO : BaseDAO
    {

        public OrderItem GetOrderItemFromReader(IDataReader dr)
        {
            OrderItem temp = new OrderItem();

            if (dr["OrderItemID"] != DBNull.Value) temp.OrderItemID = Convert.ToInt32(dr["OrderItemID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["OrderID"] != DBNull.Value) temp.OrderID = Convert.ToInt32(dr["OrderID"]);
            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["UnitPrice"] != DBNull.Value) temp.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
            if (dr["Quantity"] != DBNull.Value) temp.Quantity = Convert.ToInt32(dr["Quantity"]);
            if (dr["Size"] != DBNull.Value) temp.Size = Convert.ToString(dr["Size"]);
            if (dr["Color"] != DBNull.Value) temp.Color = Convert.ToString(dr["Color"]);

            return temp;
        }

        public OrderItemsBaseDAO()
        {
        }

        public OrderItem GetOrderItem(int orderItemID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrderItem", cn);

                cmd.Parameters.Add("@OrderItemID", SqlDbType.Int).Value = orderItemID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetOrderItemFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetOrderItemsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectOrderItemsAll");
        //}


        //Get by ForeignKey
        public List<OrderItem> GetOrderItemsByOrderID(int orderID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrderItemsByOrderID", cn);

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<OrderItem> list = new List<OrderItem>();
                while (dr.Read())
                {
                    list.Add(GetOrderItemFromReader(dr));
                }
                return list;
            }
        }
        public List<OrderItem> GetOrderItemsByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrderItemsByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<OrderItem> list = new List<OrderItem>();
                while (dr.Read())
                {
                    list.Add(GetOrderItemFromReader(dr));
                }
                return list;
            }
        }

        public int GetCountOrderItemsByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectCountOrderItemsByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@Count", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                return (int)cmd.Parameters["@Count"].Value;
            }
        }

        //Get All
        public List<OrderItem> GetOrderItemsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectOrderItemsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<OrderItem> list = new List<OrderItem>();
                while (dr.Read())
                {
                    list.Add(GetOrderItemFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(OrderItem orderItem)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertOrderItem", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(orderItem.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.AddedBy);
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.OrderID);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.ProductID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.Title);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.UnitPrice);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.Quantity);
                cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.Size);
                cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.Color);

                cmd.Parameters.Add("@OrderItemID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@OrderItemID"].Value;
            }
        }
        //Update
        public bool Update(OrderItem orderItem)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateOrderItem", cn);

                cmd.Parameters.Add("@OrderItemID", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.OrderItemID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(orderItem.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.AddedBy);
                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.OrderID);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.ProductID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.Title);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.UnitPrice);
                cmd.Parameters.Add("@Quantity", SqlDbType.Int).Value = ConvertNullToDBNull(orderItem.Quantity);
                cmd.Parameters.Add("@Size", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.Size);
                cmd.Parameters.Add("@Color", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderItem.Color);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int orderItemID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteOrderItem", cn);

                cmd.Parameters.Add("@OrderItemID", SqlDbType.Int).Value = orderItemID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
