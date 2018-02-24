using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DAO;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class PriceDepartmentDAO : BaseDAO
    {

        public PriceDepartment GetPriceDepartmentFromReader(IDataReader dr)
        {
            PriceDepartment temp = new PriceDepartment();

            if (dr["PriceID"] != DBNull.Value) temp.PriceID = Convert.ToInt32(dr["PriceID"]);
            if (dr["DepartmentID"] != DBNull.Value) temp.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);

            return temp;
        }

        public PriceDepartmentDAO()
        {
        }

        public PriceDepartment GetPriceDepartment(int priceID, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectPriceDepartment", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = priceID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetPriceDepartmentFromReader(dr);
                else
                    return null;
            }
        }

        //Insert
        public bool Insert(PriceDepartment priceDepartment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertPriceDepartment", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = ConvertNullToDBNull(priceDepartment.PriceID);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(priceDepartment.DepartmentID);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool Delete(int priceID, int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePriceDepartment", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = priceID;
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool DeleteByDepartment(int departmentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePriceDepartmentByDepartment", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        public bool DeleteByPrice(int priceID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeletePriceDepartmentByPrice", cn);

                cmd.Parameters.Add("@PriceID", SqlDbType.Int).Value = priceID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
