using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;
using Zensoft.Website.DataLayer.DAO;

namespace Zensoft.Website.DataLayer.DAO
{
    public class AlbumImageDAO : BaseDAO
    {

        public AlbumImage GetAlbumImageFromReader(IDataReader dr)
        {
            AlbumImage temp = new AlbumImage();

            if (dr["ImageId"] != DBNull.Value) temp.ImageId = Convert.ToInt32(dr["ImageId"]);
            if (dr["AlbumId"] != DBNull.Value) temp.AlbumId = Convert.ToInt32(dr["AlbumId"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["PreviewUrl"] != DBNull.Value) temp.PreviewUrl = Convert.ToString(dr["PreviewUrl"]);
            if (dr["MainUrl"] != DBNull.Value) temp.MainUrl = Convert.ToString(dr["MainUrl"]);
            if (dr["IsMain"] != DBNull.Value) temp.IsMain = Convert.ToBoolean(dr["IsMain"]);

            return temp;
        }

        public AlbumImageDAO()
        {
        }

        public AlbumImage GetAlbumImage(int imageId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectAlbumImage", cn);

                cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = imageId;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetAlbumImageFromReader(dr);
                else
                    return null;
            }
        }

        //Get By AlbumID
        public List<AlbumImage> GetAlbumImageByAlbumID(int albumID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAlbumsImageByAlbumID", cn);
                cmd.Parameters.Add("@AlbumID", SqlDbType.Int).Value = albumID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<AlbumImage> list = new List<AlbumImage>();
                while (dr.Read())
                {
                    list.Add(GetAlbumImageFromReader(dr));
                }

                return list;
            }
        }

        //Get Dynamic
        public List<AlbumImage> GetAlbumImageDynamic(string whereCondition, string orderByExpression)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectAlbumsImageDynamic", cn);
                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = whereCondition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderByExpression;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<AlbumImage> list = new List<AlbumImage>();
                while (dr.Read())
                {
                    list.Add(GetAlbumImageFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(AlbumImage albumImage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertAlbumImage", cn);

                cmd.Parameters.Add("@AlbumId", SqlDbType.Int).Value = ConvertNullToDBNull(albumImage.AlbumId);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(albumImage.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NText).Value = ConvertNullToDBNull(albumImage.Description);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(albumImage.AddedDate);
                cmd.Parameters.Add("@PreviewUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(albumImage.PreviewUrl);
                cmd.Parameters.Add("@MainUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(albumImage.MainUrl);
                cmd.Parameters.Add("@IsMain", SqlDbType.Bit).Value = ConvertNullToDBNull(albumImage.IsMain);

                cmd.Parameters.Add("@ImageId", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ImageId"].Value;
            }
        }
        //Update
        public bool Update(AlbumImage albumImage)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateAlbumImage", cn);

                cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = ConvertNullToDBNull(albumImage.ImageId);
                cmd.Parameters.Add("@AlbumId", SqlDbType.Int).Value = ConvertNullToDBNull(albumImage.AlbumId);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(albumImage.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NText).Value = ConvertNullToDBNull(albumImage.Description);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(albumImage.AddedDate);
                cmd.Parameters.Add("@PreviewUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(albumImage.PreviewUrl);
                cmd.Parameters.Add("@MainUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(albumImage.MainUrl);
                cmd.Parameters.Add("@IsMain", SqlDbType.Bit).Value = ConvertNullToDBNull(albumImage.IsMain);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int imageId)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteAlbumImage", cn);

                cmd.Parameters.Add("@ImageId", SqlDbType.Int).Value = imageId;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
