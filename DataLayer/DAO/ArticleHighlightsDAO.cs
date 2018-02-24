using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.DataLayer.DAO
{
    public class ArticleHighlightsDAO : ArticleHighlightsBaseDAO
    {
        public int GetCurrentID()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("ArticlesHighlights_GetCurrentID", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ArticleHighlightID", SqlDbType.Int).Direction = ParameterDirection.Output;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (int)cmd.Parameters["@ArticleHighlightID"].Value;
            }
        }
    }

    public class ArticleHighlightsBaseDAO : BaseDAO
    {

        public ArticleHighlight GetArticleHighlightFromReader(IDataReader dr)
        {
            ArticleHighlight temp = new ArticleHighlight();

            if (dr["ArticleHighlightID"] != DBNull.Value) temp.ArticleHighlightID = Convert.ToInt32(dr["ArticleHighlightID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Description"] != DBNull.Value) temp.Description = Convert.ToString(dr["Description"]);
            if (dr["SmallPictureUrl"] != DBNull.Value) temp.SmallPictureUrl = Convert.ToString(dr["SmallPictureUrl"]);
            if (dr["PictureUrl"] != DBNull.Value) temp.PictureUrl = Convert.ToString(dr["PictureUrl"]);
            if (dr["Link"] != DBNull.Value) temp.Link = Convert.ToString(dr["Link"]);
            if (dr["IsCurrent"] != DBNull.Value) temp.IsCurrent = Convert.ToBoolean(dr["IsCurrent"]);
            if (dr["Listed"] != DBNull.Value) temp.Listed = Convert.ToBoolean(dr["Listed"]);

            return temp;
        }

        public ArticleHighlightsBaseDAO()
        {
        }

        public ArticleHighlight GetArticleHighlight(int articleHighlightID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticleHighlight", cn);

                cmd.Parameters.Add("@ArticleHighlightID", SqlDbType.Int).Value = articleHighlightID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetArticleHighlightFromReader(dr);
                else
                    return null;
            }
        }

        //public DataSet GetArticleHighlightsAll()
        //{
        //	SqlService service = new SqlService();
        //	return service.ExecuteSPDataSet("usp_SelectArticleHighlightsAll");
        //}


        //Get by ForeignKey

        //Get All
        public List<ArticleHighlight> GetArticleHighlightsAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectArticleHighlightsAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<ArticleHighlight> list = new List<ArticleHighlight>();
                while (dr.Read())
                {
                    list.Add(GetArticleHighlightFromReader(dr));
                }

                return list;
            }
        }
        //Insert
        public int Insert(ArticleHighlight articleHighlight)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertArticleHighlight", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(articleHighlight.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.Description);
                cmd.Parameters.Add("@SmallPictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.SmallPictureUrl);
                cmd.Parameters.Add("@PictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.PictureUrl);
                cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.Link);
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Bit).Value = ConvertNullToDBNull(articleHighlight.IsCurrent);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(articleHighlight.Listed);

                cmd.Parameters.Add("@ArticleHighlightID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ArticleHighlightID"].Value;
            }
        }
        //Update
        public bool Update(ArticleHighlight articleHighlight)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateArticleHighlight", cn);

                cmd.Parameters.Add("@ArticleHighlightID", SqlDbType.Int).Value = ConvertNullToDBNull(articleHighlight.ArticleHighlightID);
                //cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(articleHighlight.AddedDate);
                //cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.AddedBy);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.Title);
                cmd.Parameters.Add("@Description", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.Description);
                cmd.Parameters.Add("@SmallPictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.SmallPictureUrl);
                cmd.Parameters.Add("@PictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.PictureUrl);
                cmd.Parameters.Add("@Link", SqlDbType.NVarChar).Value = ConvertNullToDBNull(articleHighlight.Link);
                cmd.Parameters.Add("@IsCurrent", SqlDbType.Bit).Value = ConvertNullToDBNull(articleHighlight.IsCurrent);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(articleHighlight.Listed);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int articleHighlightID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteArticleHighlight", cn);

                cmd.Parameters.Add("@ArticleHighlightID", SqlDbType.Int).Value = articleHighlightID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
    }

}
