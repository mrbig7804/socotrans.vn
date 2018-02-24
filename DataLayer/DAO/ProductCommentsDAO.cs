using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.DataLayer.DAO
{
    public partial class ProductCommentsDAO : BaseDAO
    {

        public ProductComment GetProductCommentFromReader(IDataReader dr)
        {
            ProductComment temp = new ProductComment();

            if (dr["ProductCommentID"] != DBNull.Value) temp.ProductCommentID = Convert.ToInt32(dr["ProductCommentID"]);
            if (dr["FullName"] != DBNull.Value) temp.FullName = Convert.ToString(dr["FullName"]);
            if (dr["Email"] != DBNull.Value) temp.Email = Convert.ToString(dr["Email"]);
            if (dr["Phone"] != DBNull.Value) temp.Phone = Convert.ToString(dr["Phone"]);
            if (dr["Body"] != DBNull.Value) temp.Body = Convert.ToString(dr["Body"]);
            if (dr["ProductID"] != DBNull.Value) temp.ProductID = Convert.ToInt32(dr["ProductID"]);
            if (dr["UserName"] != DBNull.Value) temp.UserName = Convert.ToString(dr["UserName"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["Approved"] != DBNull.Value) temp.Approved = Convert.ToBoolean(dr["Approved"]);

            return temp;
        }

        public ProductCommentsDAO()
        {
        }

        public ProductComment GetProductComment(int productCommentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductComment", cn);

                cmd.Parameters.Add("@ProductCommentID", SqlDbType.Int).Value = productCommentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetProductCommentFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetProductCommentsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectProductCommentsAll");
        //}


        //Get by ForeignKey
        public List<ProductComment> GetProductCommentsByProductID(int productID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectProductCommentsByProductID", cn);

                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = productID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductComment> list = new List<ProductComment>();
                while (dr.Read())
                {
                    list.Add(GetProductCommentFromReader(dr));
                }
                return list;
            }
        }

        //Get All
        public List<ProductComment> GetProductCommentsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectProductCommentsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ProductComment> list = new List<ProductComment>();
                while (dr.Read())
                {
                    list.Add(GetProductCommentFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(ProductComment productComment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertProductComment", cn);

                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.FullName);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.Email);
                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = ConvertNullToDBNull(productComment.Phone);
                cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.Body);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(productComment.ProductID);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.UserName);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(productComment.AddedDate);
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = ConvertNullToDBNull(productComment.Approved);

                cmd.Parameters.Add("@ProductCommentID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ProductCommentID"].Value;
            }
        }
        //Update
        public bool Update(ProductComment productComment)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateProductComment", cn);

                cmd.Parameters.Add("@ProductCommentID", SqlDbType.Int).Value = ConvertNullToDBNull(productComment.ProductCommentID);
                cmd.Parameters.Add("@FullName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.FullName);
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.Email);
                cmd.Parameters.Add("@Phone", SqlDbType.NChar).Value = ConvertNullToDBNull(productComment.Phone);
                cmd.Parameters.Add("@Body", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.Body);
                cmd.Parameters.Add("@ProductID", SqlDbType.Int).Value = ConvertNullToDBNull(productComment.ProductID);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(productComment.UserName);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(productComment.AddedDate);
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = ConvertNullToDBNull(productComment.Approved);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int productCommentID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteProductComment", cn);

                cmd.Parameters.Add("@ProductCommentID", SqlDbType.Int).Value = productCommentID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
