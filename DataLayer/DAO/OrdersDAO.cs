using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    /// <summary>
    /// 12/12/07: sondt: thêm hàm GetOrdersByCustomerName để lấy đơn hàng theo tên người đặt hàng
    /// </summary>
    public class OrdersDAO : OrdersBaseDAO
    {

        public List<Order> GetOrdersByCustomerName(string customerName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Orders_GetByCustomerName", cn);

                cmd.Parameters.Add("@CustomerName", SqlDbType.NVarChar).Value = customerName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Order> list = new List<Order>();
                while (dr.Read())
                {
                    list.Add(GetOrderFromReader(dr));
                }
                return list;
            }
        }

        public List<Order> GetOrdersByStatusID(int statusID, DateTime fromDate, DateTime toDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Orders_GetByStatusID", cn);

                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = statusID;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;


                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Order> list = new List<Order>();
                while (dr.Read())
                {
                    list.Add(GetOrderFromReader(dr));
                }
                return list;
            }
        }
    }

    /// <summary>
    /// 08/12/07:sondt: sửa hàm update để có thể cập nhật ngày tháng băng null
    /// </summary>
    public class OrdersBaseDAO : BaseDAO
    {

        public Order GetOrderFromReader(IDataReader dr)
        {
            Order temp = new Order();

            if (dr["OrderID"] != DBNull.Value) temp.OrderID = Convert.ToInt32(dr["OrderID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["StatusID"] != DBNull.Value) temp.StatusID = Convert.ToInt32(dr["StatusID"]);
            if (dr["PaymentMethod"] != DBNull.Value) temp.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
            if (dr["AccountCode"] != DBNull.Value) temp.AccountCode = Convert.ToString(dr["AccountCode"]);
            if (dr["Total"] != DBNull.Value) temp.Total = Convert.ToInt32(dr["Total"]);
            if (dr["ShippingFullName"] != DBNull.Value) temp.ShippingFullName = Convert.ToString(dr["ShippingFullName"]);
            if (dr["ShippingAddress"] != DBNull.Value) temp.ShippingAddress = Convert.ToString(dr["ShippingAddress"]);
            if (dr["ShippingCity"] != DBNull.Value) temp.ShippingCity = Convert.ToString(dr["ShippingCity"]);
            if (dr["CustomerEmail"] != DBNull.Value) temp.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
            if (dr["CustomerPhone"] != DBNull.Value) temp.CustomerPhone = Convert.ToString(dr["CustomerPhone"]);
            if (dr["CustomerMoblie"] != DBNull.Value) temp.CustomerMoblie = Convert.ToString(dr["CustomerMoblie"]);
            if (dr["ShippedDate"] != DBNull.Value) temp.ShippedDate = Convert.ToDateTime(dr["ShippedDate"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Note"] != DBNull.Value) temp.Note = Convert.ToString(dr["Note"]);

            return temp;
        }

        public OrdersBaseDAO()
        {
        }

        public Order GetOrder(int orderID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrder", cn);

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetOrderFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetOrdersAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectOrdersAll");
        //}


        //Get by ForeignKey
        public List<Order> GetOrdersByStatusID(int statusID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrdersByStatusID", cn);

                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = statusID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Order> list = new List<Order>();
                while (dr.Read())
                {
                    list.Add(GetOrderFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<Order> GetOrdersAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectOrdersAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Order> list = new List<Order>();
                while (dr.Read())
                {
                    list.Add(GetOrderFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Order order)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertOrder", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.AddedBy);
                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = ConvertNullToDBNull(order.StatusID);
                cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.PaymentMethod);
                cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.AccountCode);
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = ConvertNullToDBNull(order.Total);
                cmd.Parameters.Add("@ShippingFullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingFullName);
                cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingAddress);
                cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingCity);
                cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.CustomerEmail);
                cmd.Parameters.Add("@CustomerPhone", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerPhone);
                cmd.Parameters.Add("@CustomerMoblie", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerMoblie);
                //cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.ShippedDate);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Description);
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Note);

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@OrderID"].Value;
            }
        }
        //Update
        public bool Update(Order order)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateOrder", cn);


                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ConvertNullToDBNull(order.OrderID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.AddedBy);
                cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = ConvertNullToDBNull(order.StatusID);
                cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.PaymentMethod);
                cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.AccountCode);
                cmd.Parameters.Add("@Total", SqlDbType.Int).Value = ConvertNullToDBNull(order.Total);
                cmd.Parameters.Add("@ShippingFullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingFullName);
                cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingAddress);
                cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingCity);
                cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.CustomerEmail);
                cmd.Parameters.Add("@CustomerPhone", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerPhone);
                cmd.Parameters.Add("@CustomerMoblie", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerMoblie);

                if (order.ShippedDate == DateTime.MinValue)
                    cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = DBNull.Value;
                else
                    cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = order.ShippedDate;

                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Description);
                cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Note);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int orderID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteOrder", cn);

                cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

    //public class OrdersDAO : OrdersBaseDAO
    //{
    //}

    //public class OrdersBaseDAO : BaseDAO
    //{

    //    public Order GetOrderFromReader(IDataReader dr)
    //    {
    //        Order temp = new Order();

    //        if (dr["OrderID"] != DBNull.Value) temp.OrderID = Convert.ToInt32(dr["OrderID"]);
    //        if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
    //        if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
    //        if (dr["StatusID"] != DBNull.Value) temp.StatusID = Convert.ToInt32(dr["StatusID"]);
    //        if (dr["PaymentMethod"] != DBNull.Value) temp.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
    //        if (dr["AccountCode"] != DBNull.Value) temp.AccountCode = Convert.ToString(dr["AccountCode"]);
    //        if (dr["ShippingFullName"] != DBNull.Value) temp.ShippingFullName = Convert.ToString(dr["ShippingFullName"]);
    //        if (dr["ShippingAddress"] != DBNull.Value) temp.ShippingAddress = Convert.ToString(dr["ShippingAddress"]);
    //        if (dr["ShippingCity"] != DBNull.Value) temp.ShippingCity = Convert.ToString(dr["ShippingCity"]);
    //        if (dr["CustomerEmail"] != DBNull.Value) temp.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
    //        if (dr["CustomerPhone"] != DBNull.Value) temp.CustomerPhone = Convert.ToString(dr["CustomerPhone"]);
    //        if (dr["CustomerMoblie"] != DBNull.Value) temp.CustomerMoblie = Convert.ToString(dr["CustomerMoblie"]);
    //        if (dr["ShippedDate"] != DBNull.Value) temp.ShippedDate = Convert.ToDateTime(dr["ShippedDate"]);
    //        if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
    //        if (dr["Note"] != DBNull.Value) temp.Note = Convert.ToString(dr["Note"]);

    //        return temp;
    //    }

    //    public OrdersBaseDAO()
    //    {
    //    }

    //    public Order GetOrder(int orderID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_SelectOrder", cn);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);
    //            if (dr.Read())
    //                return GetOrderFromReader(dr);
    //            else
    //                return null;
    //        }
    //    }

    //    //public DataSet GetOrdersAll()
    //    //{
    //    //	SqlService service = new SqlService();
    //    //	return service.ExecuteSPDataSet("usp_SelectOrdersAll");
    //    //}


    //    //Get by ForeignKey
    //    public List<Order> GetOrdersByStatusID(int statusID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_SelectOrdersByStatusID", cn);

    //            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = statusID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);

    //            List<Order> list = new List<Order>();
    //            while (dr.Read())
    //            {
    //                list.Add(GetOrderFromReader(dr));
    //            }
    //            return list;
    //        }
    //    }

    //    //Get All
    //    public List<Order> GetOrdersAll()
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {

    //            SqlCommand cmd = new SqlCommand("usp_SelectOrdersAll", cn);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);

    //            List<Order> list = new List<Order>();
    //            while (dr.Read())
    //            {
    //                list.Add(GetOrderFromReader(dr));
    //            }

    //            return list;
    //        }
    //    }

    //    //Insert
    //    public int Insert(Order order)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_InsertOrder", cn);

    //            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.AddedDate);
    //            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.AddedBy);
    //            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = ConvertNullToDBNull(order.StatusID);
    //            cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.PaymentMethod);
    //            cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.AccountCode);
    //            cmd.Parameters.Add("@ShippingFullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingFullName);
    //            cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingAddress);
    //            cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingCity);
    //            cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.CustomerEmail);
    //            cmd.Parameters.Add("@CustomerPhone", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerPhone);
    //            cmd.Parameters.Add("@CustomerMoblie", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerMoblie);
    //            //cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.ShippedDate);
    //            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Description);
    //            cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Note);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (int)cmd.Parameters["@OrderID"].Value;
    //        }
    //    }
    //    //Update
    //    public bool Update(Order order)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_UpdateOrder", cn);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ConvertNullToDBNull(order.OrderID);
    //            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.AddedDate);
    //            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.AddedBy);
    //            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = ConvertNullToDBNull(order.StatusID);
    //            cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.PaymentMethod);
    //            cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.AccountCode);
    //            cmd.Parameters.Add("@ShippingFullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingFullName);
    //            cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingAddress);
    //            cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingCity);
    //            cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.CustomerEmail);
    //            cmd.Parameters.Add("@CustomerPhone", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerPhone);
    //            cmd.Parameters.Add("@CustomerMoblie", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerMoblie);
    //            cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.ShippedDate);
    //            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Description);
    //            cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Note);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (ret == 1);
    //        }
    //    }
    //    //Delete
    //    public bool Delete(int orderID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_DeleteOrder", cn);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (ret == 1);
    //        }
    //    }
    //}

    //public class OrdersDAO : OrdersBaseDAO
    //{
    //}

    //public class OrdersBaseDAO : BaseDAO
    //{

    //    public Order GetOrderFromReader(IDataReader dr)
    //    {
    //        Order temp = new Order();

    //        if (dr["OrderID"] != DBNull.Value) temp.OrderID = Convert.ToInt32(dr["OrderID"]);
    //        if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
    //        if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
    //        if (dr["StatusID"] != DBNull.Value) temp.StatusID = Convert.ToInt32(dr["StatusID"]);
    //        if (dr["PaymentMethod"] != DBNull.Value) temp.PaymentMethod = Convert.ToString(dr["PaymentMethod"]);
    //        if (dr["AccountCode"] != DBNull.Value) temp.AccountCode = Convert.ToString(dr["AccountCode"]);
    //        if (dr["ShippingAddress"] != DBNull.Value) temp.ShippingAddress = Convert.ToString(dr["ShippingAddress"]);
    //        if (dr["ShippingCity"] != DBNull.Value) temp.ShippingCity = Convert.ToString(dr["ShippingCity"]);
    //        if (dr["CustomerEmail"] != DBNull.Value) temp.CustomerEmail = Convert.ToString(dr["CustomerEmail"]);
    //        if (dr["CustomerPhone"] != DBNull.Value) temp.CustomerPhone = Convert.ToString(dr["CustomerPhone"]);
    //        if (dr["CustomerMoblie"] != DBNull.Value) temp.CustomerMoblie = Convert.ToString(dr["CustomerMoblie"]);
    //        if (dr["ShippedDate"] != DBNull.Value) temp.ShippedDate = Convert.ToDateTime(dr["ShippedDate"]);
    //        if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
    //        if (dr["Note"] != DBNull.Value) temp.Note = Convert.ToString(dr["Note"]);

    //        return temp;
    //    }

    //    public OrdersBaseDAO()
    //    {
    //    }

    //    public Order GetOrder(int orderID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_SelectOrder", cn);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);
    //            if (dr.Read())
    //                return GetOrderFromReader(dr);
    //            else
    //                return null;
    //        }
    //    }

    //    //public DataSet GetOrdersAll()
    //    //{
    //    //	SqlService service = new SqlService();
    //    //	return service.ExecuteSPDataSet("usp_SelectOrdersAll");
    //    //}


    //    //Get by ForeignKey
    //    public List<Order> GetOrdersByStatusID(int statusID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_SelectOrdersByStatusID", cn);

    //            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = statusID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);

    //            List<Order> list = new List<Order>();
    //            while (dr.Read())
    //            {
    //                list.Add(GetOrderFromReader(dr));
    //            }
    //            return list;
    //        }
    //    }

    //    //Get All
    //    public List<Order> GetOrdersAll()
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {

    //            SqlCommand cmd = new SqlCommand("usp_SelectOrdersAll", cn);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            IDataReader dr = ExecuteReader(cmd);

    //            List<Order> list = new List<Order>();
    //            while (dr.Read())
    //            {
    //                list.Add(GetOrderFromReader(dr));
    //            }

    //            return list;
    //        }
    //    }

    //    //Insert
    //    public int Insert(Order order)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_InsertOrder", cn);

    //            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.AddedDate);
    //            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.AddedBy);
    //            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = ConvertNullToDBNull(order.StatusID);
    //            cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.PaymentMethod);
    //            cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.AccountCode);
    //            cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingAddress);
    //            cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingCity);
    //            cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.CustomerEmail);
    //            cmd.Parameters.Add("@CustomerPhone", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerPhone);
    //            cmd.Parameters.Add("@CustomerMoblie", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerMoblie);
    //            cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.ShippedDate);
    //            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Description);
    //            cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Note);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Direction = ParameterDirection.Output;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (int)cmd.Parameters["@OrderID"].Value;
    //        }
    //    }
    //    //Update
    //    public bool Update(Order order)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_UpdateOrder", cn);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = ConvertNullToDBNull(order.OrderID);
    //            cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.AddedDate);
    //            cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.AddedBy);
    //            cmd.Parameters.Add("@StatusID", SqlDbType.Int).Value = ConvertNullToDBNull(order.StatusID);
    //            cmd.Parameters.Add("@PaymentMethod", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.PaymentMethod);
    //            cmd.Parameters.Add("@AccountCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.AccountCode);
    //            cmd.Parameters.Add("@ShippingAddress", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingAddress);
    //            cmd.Parameters.Add("@ShippingCity", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.ShippingCity);
    //            cmd.Parameters.Add("@CustomerEmail", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.CustomerEmail);
    //            cmd.Parameters.Add("@CustomerPhone", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerPhone);
    //            cmd.Parameters.Add("@CustomerMoblie", SqlDbType.VarChar).Value = ConvertNullToDBNull(order.CustomerMoblie);
    //            cmd.Parameters.Add("@ShippedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(order.ShippedDate);
    //            cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Description);
    //            cmd.Parameters.Add("@Note", SqlDbType.NVarChar).Value = ConvertNullToDBNull(order.Note);

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (ret == 1);
    //        }
    //    }
    //    //Delete
    //    public bool Delete(int orderID)
    //    {
    //        using (SqlConnection cn = new SqlConnection(this.ConnectionString))
    //        {
    //            SqlCommand cmd = new SqlCommand("usp_DeleteOrder", cn);

    //            cmd.Parameters.Add("@OrderID", SqlDbType.Int).Value = orderID;

    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cn.Open();

    //            int ret = ExecuteNonQuery(cmd);

    //            return (ret == 1);
    //        }
    //    }
    //}
}
