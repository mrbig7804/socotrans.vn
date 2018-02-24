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
        public List<Video> GetVideosByCategoryID(int catID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectVideoByCategoryID", cn);
                cmd.Parameters.Add("@CategoriesID", SqlDbType.Int).Value = catID;

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

        public List<Video> GetVideosConnexion(int catID, int videoID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectVideoConnexion", cn);
                cmd.Parameters.Add("@CategoriesID", SqlDbType.Int).Value = catID;
                cmd.Parameters.Add("@VideoID", SqlDbType.Int).Value = videoID;

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

        public bool UpdateViewCount(int videoID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateVideoViewCount", cn);

                cmd.Parameters.Add("@VideoID", SqlDbType.Int).Value = videoID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }
}
