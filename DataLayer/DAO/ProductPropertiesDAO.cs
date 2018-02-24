using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class ProductPropertiesDAO : BaseDAO
    {

        public ProductProperty GetProductPropertyFromReader(IDataReader dr)
        {
            ProductProperty temp = new ProductProperty();

            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["PropertyValueID"] != DBNull.Value) temp.PropertyValueID = Convert.ToInt32(dr["PropertyValueID"]);

            return temp;
        }

        public ProductPropertiesDAO()
        {
        }

        public ProductProperty GetProductProperty(int productID, int propertyValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductProperty", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@PropertyValueID", SqlDbType.Int).Value = propertyValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetProductPropertyFromReader(dr);
                else
                    return null;
            }
        }

        public List<ProductProperty> GetProductPropertyByProduct(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductPropertyByProduct", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductProperty> list = new List<ProductProperty>();
                while (dr.Read())
                {
                    list.Add(GetProductPropertyFromReader(dr));
                }

                return list;
            }
        }

        public List<ProductProperty> GetProductPropertyByPropertyValue(int propertyValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductPropertyByPropertyValue", cn);

                cmd.Parameters.Add("@PropertyValueID", SqlDbType.Int).Value = propertyValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductProperty> list = new List<ProductProperty>();
                while (dr.Read())
                {
                    list.Add(GetProductPropertyFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public bool Insert(ProductProperty productProperty)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertProductProperty", cn);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productProperty.ProductID;
                cmd.Parameters.Add("@PropertyValueID", SqlDbType.Int).Value = productProperty.PropertyValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool Delete(int productID, int propertyValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductProperty", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;
                cmd.Parameters.Add("@PropertyValueID", SqlDbType.Int).Value = propertyValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        public bool DeleteByProduct(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductPropertyByProduct", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        //Delete
        public bool DeleteByPropertyValue(int propertyValueID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductPropertyByPropertyValue", cn);

                cmd.Parameters.Add("@PropertyValueID", SqlDbType.Int).Value = propertyValueID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
