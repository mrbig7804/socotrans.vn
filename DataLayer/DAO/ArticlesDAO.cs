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


    public partial class ArticlesDAO : BaseDAO
    {

        public Article GetArticleFromReader(IDataReader dr, bool readBody)
        {
            Article temp = new Article();

            if (dr["ArticleID"] != DBNull.Value) temp.ArticleID = Convert.ToInt32(dr["ArticleID"]);
            if (dr["AddedDate"] != DBNull.Value) temp.AddedDate = Convert.ToDateTime(dr["AddedDate"]);
            if (dr["AddedBy"] != DBNull.Value) temp.AddedBy = Convert.ToString(dr["AddedBy"]);
            if (dr["CategoryID"] != DBNull.Value) temp.CategoryID = Convert.ToInt32(dr["CategoryID"]);
            if (dr["Title"] != DBNull.Value) temp.Title = Convert.ToString(dr["Title"]);
            if (dr["Abstract"] != DBNull.Value) temp.Abstract = Convert.ToString(dr["Abstract"]);
            //body
            if (readBody) if (dr["Body"] != DBNull.Value) temp.Body = Convert.ToString(dr["Body"]);

            if (dr["ReleaseDate"] != DBNull.Value) temp.ReleaseDate = Convert.ToDateTime(dr["ReleaseDate"]);
            if (dr["ExpireDate"] != DBNull.Value) temp.ExpireDate = Convert.ToDateTime(dr["ExpireDate"]);
            if (dr["Approved"] != DBNull.Value) temp.Approved = Convert.ToBoolean(dr["Approved"]);
            if (dr["Listed"] != DBNull.Value) temp.Listed = Convert.ToBoolean(dr["Listed"]);
            if (dr["CommentsEnabled"] != DBNull.Value) temp.CommentsEnabled = Convert.ToBoolean(dr["CommentsEnabled"]);
            if (dr["OnlyForMembers"] != DBNull.Value) temp.OnlyForMembers = Convert.ToBoolean(dr["OnlyForMembers"]);
            if (dr["ViewCount"] != DBNull.Value) temp.ViewCount = Convert.ToInt32(dr["ViewCount"]);
            if (dr["Votes"] != DBNull.Value) temp.Votes = Convert.ToInt32(dr["Votes"]);
            if (dr["TotalRating"] != DBNull.Value) temp.TotalRating = Convert.ToInt32(dr["TotalRating"]);
            if (dr["PictureUrl"] != DBNull.Value) temp.PictureUrl = Convert.ToString(dr["PictureUrl"]);

            return temp;
        }

        public ArticlesDAO()
        {
        }

        public Article GetArticle(int articleID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticle", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);
                if (dr.Read())
                    return GetArticleFromReader(dr, true);
                else
                    return null;
            }
        }


        //Get by ForeignKey
        public List<Article> GetArticlesByCategoryID(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesByCategoryID", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Article> list = new List<Article>();
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        public List<Article> GetArticlesBySuperCategoryID(int superCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesBySuperCategoryID", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Article> list = new List<Article>();
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        //Get All
        public List<Article> GetArticlesAll()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("usp_SelectArticlesAll", cn);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                IDataReader dr = ExecuteReader(cmd);

                List<Article> list = new List<Article>();
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }

                return list;
            }
        }

        //Insert
        public int Insert(Article article)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_InsertArticle", cn);

                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(article.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.AddedBy);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(article.CategoryID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.Title);
                cmd.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.Abstract);
                cmd.Parameters.Add("@Body", SqlDbType.NText).Value = ConvertNullToDBNull(article.Body);
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(article.ReleaseDate);
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(article.ExpireDate);
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = ConvertNullToDBNull(article.Approved);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(article.Listed);
                cmd.Parameters.Add("@CommentsEnabled", SqlDbType.Bit).Value = ConvertNullToDBNull(article.CommentsEnabled);
                cmd.Parameters.Add("@OnlyForMembers", SqlDbType.Bit).Value = ConvertNullToDBNull(article.OnlyForMembers);
                cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = ConvertNullToDBNull(article.ViewCount);
                cmd.Parameters.Add("@Votes", SqlDbType.Int).Value = ConvertNullToDBNull(article.Votes);
                cmd.Parameters.Add("@TotalRating", SqlDbType.Int).Value = ConvertNullToDBNull(article.TotalRating);
                cmd.Parameters.Add("@PictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.PictureUrl);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (int)cmd.Parameters["@ArticleID"].Value;
            }
        }
        //Update
        public bool Update(Article article)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_UpdateArticle", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = ConvertNullToDBNull(article.ArticleID);
                cmd.Parameters.Add("@AddedDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(article.AddedDate);
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.AddedBy);
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = ConvertNullToDBNull(article.CategoryID);
                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.Title);
                cmd.Parameters.Add("@Abstract", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.Abstract);
                cmd.Parameters.Add("@Body", SqlDbType.NText).Value = ConvertNullToDBNull(article.Body);
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(article.ReleaseDate);
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = ConvertNullToDBNull(article.ExpireDate);
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = ConvertNullToDBNull(article.Approved);
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = ConvertNullToDBNull(article.Listed);
                cmd.Parameters.Add("@CommentsEnabled", SqlDbType.Bit).Value = ConvertNullToDBNull(article.CommentsEnabled);
                cmd.Parameters.Add("@OnlyForMembers", SqlDbType.Bit).Value = ConvertNullToDBNull(article.OnlyForMembers);
                cmd.Parameters.Add("@ViewCount", SqlDbType.Int).Value = ConvertNullToDBNull(article.ViewCount);
                cmd.Parameters.Add("@Votes", SqlDbType.Int).Value = ConvertNullToDBNull(article.Votes);
                cmd.Parameters.Add("@TotalRating", SqlDbType.Int).Value = ConvertNullToDBNull(article.TotalRating);
                cmd.Parameters.Add("@PictureUrl", SqlDbType.NVarChar).Value = ConvertNullToDBNull(article.PictureUrl);

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }
        //Delete
        public bool Delete(int articleID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_DeleteArticle", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);//gia tri mac dinh
            }
        }
    }

}