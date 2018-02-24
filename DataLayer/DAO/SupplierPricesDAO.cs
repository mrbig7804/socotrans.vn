using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
using System.Data.Common;
using System.Web.Configuration;
using System.Configuration;

namespace Zensoft.Website.DataLayer.DAO
{
    public class SupplierPricesDAO : SupplierPricesBaseDAO
    {
    }

    public class SupplierPricesBaseDAO : BaseDAO
    {

        public SupplierPrice GetSupplierPriceFromReader(IDataReader dr)
        {
            SupplierPrice temp = new SupplierPrice();

            if (dr["SupplierID"] != DBNull.Value) temp.SupplierID = Convert.ToInt32(dr["SupplierID"]);
            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["InputPrice"] != DBNull.Value) temp.InputPrice = Convert.ToInt32(dr["InputPrice"]);

            return temp;
        }

        public SupplierPricesBaseDAO()
        {
        }

        public SupplierPrice GetSupplierPrice(int supplierID, int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSupplierPrice", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;


                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetSupplierPriceFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetSupplierPricesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectSupplierPricesAll");
        //}

        //Get by ForeignKey
        public List<SupplierPrice> GetSupplierPricesBySupplierID(int supplierID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSupplierPricesBySupplierID", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<SupplierPrice> list = new List<SupplierPrice>();
                while (dr.Read())
                {
                    list.Add(GetSupplierPriceFromReader(dr));
                }
                return list;
            }
        }
        public List<SupplierPrice> GetSupplierPricesByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectSupplierPricesByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<SupplierPrice> list = new List<SupplierPrice>();
                while (dr.Read())
                {
                    list.Add(GetSupplierPriceFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<SupplierPrice> GetSupplierPricesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectSupplierPricesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<SupplierPrice> list = new List<SupplierPrice>();
                while (dr.Read())
                {
                    list.Add(GetSupplierPriceFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(SupplierPrice supplierPrice)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertSupplierPrice", cn);

                cmd.Parameters.Add("@InputPrice", SqlDbType.Int).Value = ConvertNullToDBNull(supplierPrice.InputPrice);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value= supplierPrice.SupplierID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = supplierPrice.ProductID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return ret;
            }
        }
        //Update
        public bool Update(SupplierPrice supplierPrice)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateSupplierPrice", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = ConvertNullToDBNull(supplierPrice.SupplierID);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(supplierPrice.ProductID);
                cmd.Parameters.Add("@InputPrice", SqlDbType.Int).Value = ConvertNullToDBNull(supplierPrice.InputPrice);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int supplierID, int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteSupplierPrice", cn);

                cmd.Parameters.Add("@SupplierID", SqlDbType.Int).Value = supplierID;
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
