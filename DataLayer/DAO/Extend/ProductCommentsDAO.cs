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

        public List<ProductComment> GetProductCommentsByUserProduct(string username)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ProductComments_GetByUserProduct", cn);

                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = username;

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

        public List<ProductComment> GetProductCommentsApproved()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ProductComments_GetApproved", cn);

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

        public List<ProductComment> GetProductCommentsUnapproved()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ProductComments_GetUnapproved", cn);

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
        
    }
}
