using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class AlbumDAO : BaseDAO
    {

        public Album GetAlbumFromReader(IDataReader dr)
        {
            Album temp = new Album();

            if (dr["AlbumId"] != DBNull.Value) temp.AlbumId = Convert.ToInt32(dr["AlbumId"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["Listed"] != DBNull.Value) temp.Listed = Convert.ToBoolean(dr["Listed"]);
            if (dr["PictureUrl"] != DBNull.Value) temp.PictureUrl = Convert.ToString(dr["PictureUrl"]);

            return temp;
        }

        public AlbumDAO()
        {
        }

        public Album GetAlbum(int albumId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAlbum", cn);

                cmd.Parameters.Add("@AlbumId", SqlDbType.Int).Value = albumId;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetAlbumFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<Album> GetAlbumAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAlbumsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Album> list = new List<Album>();
                while (dr.Read())
                {
                    list.Add(GetAlbumFromReader(dr));
                }

                return list;
            }
        }

        //Get By listed
        public List<Album> GetAlbumByListed(bool listed)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAlbumsByListed", cn);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = listed;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Album> list = new List<Album>();
                while (dr.Read())
                {
                    list.Add(GetAlbumFromReader(dr));
                }

                return list;
            }
        }

        //Get Dynamic
        public List<Album> GetAlbumDynamic(string whereCondition, string orderByExpression)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAlbumsDynamic", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.Int).Value = whereCondition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.Int).Value = orderByExpression;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Album> list = new List<Album>();
                while (dr.Read())
                {
                    list.Add(GetAlbumFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Album album)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertAlbum", cn);

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(album.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NText).Value = ConvertNullToDBNull(album.Description);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(album.AddedDate);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(album.Listed);
                cmd.Parameters.Add("@PictureUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(album.PictureUrl);

                cmd.Parameters.Add("@AlbumId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@AlbumId"].Value;
            }
        }
        //Update
        public bool Update(Album album)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateAlbum", cn);

                cmd.Parameters.Add("@AlbumId", SqlDbType.Int).Value = ConvertNullToDBNull(album.AlbumId);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(album.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NText).Value = ConvertNullToDBNull(album.Description);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(album.AddedDate);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(album.Listed);
                cmd.Parameters.Add("@PictureUrl", SqlDbType.VarChar).Value = ConvertNullToDBNull(album.PictureUrl);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int albumId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteAlbum", cn);

                cmd.Parameters.Add("@AlbumId", SqlDbType.Int).Value = albumId;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
