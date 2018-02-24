using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class LikeDAO: BaseDAO
    {
        public Like GetAlbumFromReader(IDataReader dr)
        {
            Like temp = new Like();

            if (dr["ProductId"] != DBNull.Value) temp.ProductId = Convert.ToInt32(dr["ProductId"]);
            if (dr["UserName"] != DBNull.Value) temp.UserName = Convert.ToString(dr["UserName"]);
            if (dr["IsLike"] != DBNull.Value) temp.IsLike = Convert.ToBoolean(dr["IsLike"]);

            return temp;
        }

        public LikeDAO()
        {
        }

        public Like GetLike(int productId, string userName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectLike", cn);

                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetAlbumFromReader(dr);
                else
                    return null;
            }
        }

        //Insert
        public int Insert(Like like)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertLike", cn);

                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = ConvertNullToDBNull(like.ProductId);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(like.UserName);
                cmd.Parameters.Add("@IsLike", SqlDbType.Bit).Value = ConvertNullToDBNull(like.IsLike);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return ret;
            }
        }
        //Update
        public bool Update(Like like)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateLike", cn);

                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = ConvertNullToDBNull(like.ProductId);
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = ConvertNullToDBNull(like.UserName);
                cmd.Parameters.Add("@IsLike", SqlDbType.Bit).Value = ConvertNullToDBNull(like.IsLike);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int productId, string userName)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteLike", cn);

                cmd.Parameters.Add("@ProductId", SqlDbType.Int).Value = productId;
                cmd.Parameters.Add("@UserName", SqlDbType.NVarChar).Value = userName;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
