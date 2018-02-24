using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public partial class VideosDAO : BaseDAO
    {

        public Video GetVideoFromReader(IDataReader dr)
        {
            Video temp = new Video();

            if (dr["VideoID"] != DBNull.Value) temp.VideoID = Convert.ToInt32(dr["VideoID"]);
            if (dr["CategoriesID"] != DBNull.Value) temp.CategoriesID = Convert.ToInt32(dr["CategoriesID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["ImageUrl"] != DBNull.Value) temp.ImageUrl = Convert.ToString(dr["ImageUrl"]);
            if (dr["VideoUrl"] != DBNull.Value) temp.VideoUrl = Convert.ToString(dr["VideoUrl"]);
            if (dr["Important"] != DBNull.Value) temp.Important = Convert.ToInt32(dr["Important"]);
            if (dr["ViewCount"] != DBNull.Value) temp.ViewCount = Convert.ToInt32(dr["ViewCount"]);
            if (dr["Published"] != DBNull.Value) temp.Published = Convert.ToBoolean(dr["Published"]);

            return temp;
        }

        public VideosDAO()
        {
        }

        public Video GetVideo(int videoID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectVideo", cn);

                cmd.Parameters.Add("@VideoID", SqlDbType.Int).Value = videoID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetVideoFromReader(dr);
                else
                    return null;
            }
        }

        //Get All
        public List<Video> GetVideosAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectVideosAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Video> list = new List<Video>();
                while (dr.Read())
                {
                    list.Add(GetVideoFromReader(dr));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Video video)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertVideo", cn);

                cmd.Parameters.Add("@CategoriesID", SqlDbType.Int).Value = ConvertNullToDBNull(video.CategoriesID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(video.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.ImageUrl);
                cmd.Parameters.Add("@VideoUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.VideoUrl);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(video.Important);
                cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = ConvertNullToDBNull(video.ViewCount);
                cmd.Parameters.Add("@Published", SqlDbType.Bit).Value = ConvertNullToDBNull(video.Published);

                cmd.Parameters.Add("@VideoID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@VideoID"].Value;
            }
        }
        //Update
        public bool Update(Video video)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateVideo", cn);

                cmd.Parameters.Add("@VideoID", SqlDbType.Int).Value = ConvertNullToDBNull(video.VideoID);
                cmd.Parameters.Add("@CategoriesID", SqlDbType.Int).Value = ConvertNullToDBNull(video.CategoriesID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(video.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.Description);
                cmd.Parameters.Add("@ImageUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.ImageUrl);
                cmd.Parameters.Add("@VideoUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(video.VideoUrl);
                cmd.Parameters.Add("@Important", SqlDbType.Int).Value = ConvertNullToDBNull(video.Important);
                cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = ConvertNullToDBNull(video.ViewCount);
                cmd.Parameters.Add("@Published", SqlDbType.Bit).Value = ConvertNullToDBNull(video.Published);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int videoID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteVideo", cn);

                cmd.Parameters.Add("@VideoID", SqlDbType.Int).Value = videoID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
