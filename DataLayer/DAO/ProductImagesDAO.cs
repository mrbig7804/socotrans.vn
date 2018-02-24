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
    public class ProductImagesDAO : ProductImagesBaseDAO
    {
    }

    public class ProductImagesBaseDAO : BaseDAO
    {

        public ProductImage GetProductImageFromReader(IDataReader dr)
        {
            ProductImage temp = new ProductImage();

            if (dr["ProductImageID"] != DBNull.Value) temp.ProductImageID = Convert.ToInt32(dr["ProductImageID"]);
            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["SmallImage"] != DBNull.Value) temp.SmallImage = Convert.ToString(dr["SmallImage"]);
            if (dr["MedImage"] != DBNull.Value) temp.MedImage = Convert.ToString(dr["MedImage"]);
            if (dr["FullImage"] != DBNull.Value) temp.FullImage = Convert.ToString(dr["FullImage"]);

            return temp;
        }

        public ProductImagesBaseDAO()
        {
        }

        public ProductImage GetProductImage(int productImageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductImage", cn);

                cmd.Parameters.Add("@ProductImageID", SqlDbType.Int).Value = productImageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetProductImageFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetProductImagesAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectProductImagesAll");
        //}


        //Get by ForeignKey
        public List<ProductImage> GetProductImagesByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductImagesByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductImage> list = new List<ProductImage>();
                while (dr.Read())
                {
                    list.Add(GetProductImageFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<ProductImage> GetProductImagesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectProductImagesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductImage> list = new List<ProductImage>();
                while (dr.Read())
                {
                    list.Add(GetProductImageFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(ProductImage productImage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertProductImage", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(productImage.ProductID);
                cmd.Parameters.Add("@SmallImage", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productImage.SmallImage);
                cmd.Parameters.Add("@MedImage", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productImage.MedImage);
                cmd.Parameters.Add("@FullImage", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productImage.FullImage);

                cmd.Parameters.Add("@ProductImageID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ProductImageID"].Value;
            }
        }
        //Update
        public bool Update(ProductImage productImage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateProductImage", cn);

                cmd.Parameters.Add("@ProductImageID", SqlDbType.Int).Value = ConvertNullToDBNull(productImage.ProductImageID);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(productImage.ProductID);
                cmd.Parameters.Add("@SmallImage", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productImage.SmallImage);
                cmd.Parameters.Add("@MedImage", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productImage.MedImage);
                cmd.Parameters.Add("@FullImage", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productImage.FullImage);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int productImageID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductImage", cn);

                cmd.Parameters.Add("@ProductImageID", SqlDbType.Int).Value = productImageID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
