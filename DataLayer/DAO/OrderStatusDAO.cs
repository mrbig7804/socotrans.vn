using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class OrderStatusDAO : OrderStatusBaseDAO
    {
    }

    public class OrderStatusBaseDAO : BaseDAO
    {

        public OrderStatus GetOrderStatuFromReader(IDataReader dr)
        {
            OrderStatus temp = new OrderStatus();

            if (dr["OrderStatusID"] != DBNull.Value) temp.OrderStatusID = Convert.ToInt32(dr["OrderStatusID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);

            return temp;
        }

        public OrderStatusBaseDAO()
        {
        }

        public OrderStatus GetOrderStatu(int orderStatusID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrderStatu", cn);

                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = orderStatusID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetOrderStatuFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetOrderStatusAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectOrderStatusAll");
        //}


        //Get by ForeignKey
        public List<OrderStatus> GetOrderStatusByOrderStatusID(int orderStatusID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectOrderStatusByOrderStatusID", cn);

                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = orderStatusID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<OrderStatus> list = new List<OrderStatus>();
                while (dr.Read())
                {
                    list.Add(GetOrderStatuFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<OrderStatus> GetOrderStatusAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectOrderStatusAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<OrderStatus> list = new List<OrderStatus>();
                while (dr.Read())
                {
                    list.Add(GetOrderStatuFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(OrderStatus orderStatus)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertOrderStatu", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderStatus.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderStatus.Description);

                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@OrderStatusID"].Value;
            }
        }
        //Update
        public bool Update(OrderStatus orderStatus)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateOrderStatu", cn);

                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = ConvertNullToDBNull(orderStatus.OrderStatusID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderStatus.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(orderStatus.Description);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int orderStatusID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteOrderStatu", cn);

                cmd.Parameters.Add("@OrderStatusID", SqlDbType.Int).Value = orderStatusID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
