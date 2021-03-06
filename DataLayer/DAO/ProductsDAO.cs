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

    public partial class ProductsDAO : BaseDAO
    {

        public Product GetProductFromReader(IDataReader dr)
        {
            Product temp = new Product();

            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["DepartmentID"] != DBNull.Value) temp.DepartmentID = Convert.ToInt32(dr["DepartmentID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["EditedDate"] != DBNull.Value) temp.EditedDate = Convert.ToDateTime(dr["EditedDate"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["Details"] != DBNull.Value) temp.Details = Convert.ToString(dr["Details"]);
            if (dr["UnitPrice"] != DBNull.Value) temp.UnitPrice = Convert.ToInt32(dr["UnitPrice"]);
            if (dr["UnitInStock"] != DBNull.Value) temp.UnitInStock = Convert.ToInt32(dr["UnitInStock"]);
            if (dr["SalePrice"] != DBNull.Value) temp.SalePrice = Convert.ToInt32(dr["SalePrice"]);
            if (dr["Discontinued"] != DBNull.Value) temp.Discontinued = Convert.ToBoolean(dr["Discontinued"]);
            if (dr["SmallPictureUrl"] != DBNull.Value) temp.SmallPictureUrl = Convert.ToString(dr["SmallPictureUrl"]);
            if (dr["FullPictureUrl"] != DBNull.Value) temp.FullPictureUrl = Convert.ToString(dr["FullPictureUrl"]);
            if (dr["ViewCount"] != DBNull.Value) temp.ViewCount = Convert.ToInt32(dr["ViewCount"]);
            if (dr["Votes"] != DBNull.Value) temp.Votes = Convert.ToInt32(dr["Votes"]);
            if (dr["TotalRating"] != DBNull.Value) temp.TotalRating = Convert.ToInt32(dr["TotalRating"]);
            if (dr["Brand"] != DBNull.Value) temp.Brand = Convert.ToString(dr["Brand"]);
            if (dr["ProductCode"] != DBNull.Value) temp.ProductCode = Convert.ToString(dr["ProductCode"]);
            if (dr["Listed"] != DBNull.Value) temp.Listed = Convert.ToBoolean(dr["Listed"]);
            if (dr["Profile"] != DBNull.Value) temp.Profile = Convert.ToString(dr["Profile"]);
            if (dr["UniqueTitle"] != DBNull.Value) temp.UniqueTitle = Convert.ToString(dr["UniqueTitle"]);

            return temp;
        }

        public ProductsDAO()
        {
        }

        public Product GetProduct(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProduct", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetProductFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetProductsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectProductsAll");
        //}


        //Get by ForeignKey
        public List<Product> GetProductsByDepartmentID(int departmentID, int vote)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductsByDepartmentID", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = departmentID;
                cmd.Parameters.Add("@Vote", SqlDbType.Int).Value = vote;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<Product> GetProductsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectProductsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Product> list = new List<Product>();
                while (dr.Read())
                {
                    list.Add(GetProductFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Product product)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertProduct", cn);

                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(product.DepartmentID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(product.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.AddedBy);
                cmd.Parameters.Add("@EditedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(product.EditedDate);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.Description);
                cmd.Parameters.Add("@Details", SqlDbType.NText).Value = ConvertNullToDBNull(product.Details);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int).Value = ConvertNullToDBNull(product.UnitPrice);
                cmd.Parameters.Add("@UnitInStock", SqlDbType.Int).Value = ConvertNullToDBNull(product.UnitInStock);
                cmd.Parameters.Add("@SalePrice", SqlDbType.Int).Value = ConvertNullToDBNull(product.SalePrice);
                cmd.Parameters.Add("@Discontinued", SqlDbType.Bit).Value = ConvertNullToDBNull(product.Discontinued);
                cmd.Parameters.Add("@SmallPictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.SmallPictureUrl);
                cmd.Parameters.Add("@FullPictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.FullPictureUrl);
                cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = ConvertNullToDBNull(product.ViewCount);
                cmd.Parameters.Add("@Votes", SqlDbType.Int).Value = ConvertNullToDBNull(product.Votes);
                cmd.Parameters.Add("@TotalRating", SqlDbType.Int).Value = ConvertNullToDBNull(product.TotalRating);
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.Brand);
                cmd.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(product.ProductCode);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(product.Listed);
                cmd.Parameters.Add("@Profile", SqlDbType.NText).Value = ConvertNullToDBNull(product.Profile);
                cmd.Parameters.Add("@UniqueTitle", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.UniqueTitle);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ProductID"].Value;
            }
        }
        //Update
        public bool Update(Product product)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateProduct", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(product.ProductID);
                cmd.Parameters.Add("@DepartmentID", SqlDbType.Int).Value = ConvertNullToDBNull(product.DepartmentID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(product.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.AddedBy);
                cmd.Parameters.Add("@EditedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(product.EditedDate);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.Description);
                cmd.Parameters.Add("@Details", SqlDbType.NText).Value = ConvertNullToDBNull(product.Details);
                cmd.Parameters.Add("@UnitPrice", SqlDbType.Int).Value = ConvertNullToDBNull(product.UnitPrice);
                cmd.Parameters.Add("@UnitInStock", SqlDbType.Int).Value = ConvertNullToDBNull(product.UnitInStock);
                cmd.Parameters.Add("@SalePrice", SqlDbType.Int).Value = ConvertNullToDBNull(product.SalePrice);
                cmd.Parameters.Add("@Discontinued", SqlDbType.Bit).Value = ConvertNullToDBNull(product.Discontinued);
                cmd.Parameters.Add("@SmallPictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.SmallPictureUrl);
                cmd.Parameters.Add("@FullPictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.FullPictureUrl);
                cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = ConvertNullToDBNull(product.ViewCount);
                cmd.Parameters.Add("@Votes", SqlDbType.Int).Value = ConvertNullToDBNull(product.Votes);
                cmd.Parameters.Add("@TotalRating", SqlDbType.Int).Value = ConvertNullToDBNull(product.TotalRating);
                cmd.Parameters.Add("@Brand", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.Brand);
                cmd.Parameters.Add("@ProductCode", SqlDbType.VarChar).Value = ConvertNullToDBNull(product.ProductCode);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(product.Listed);
                cmd.Parameters.Add("@Profile", SqlDbType.NText).Value = ConvertNullToDBNull(product.Profile);
                cmd.Parameters.Add("@UniqueTitle", SqlDbType.NVarChar).Value = ConvertNullToDBNull(product.UniqueTitle);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProduct", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
