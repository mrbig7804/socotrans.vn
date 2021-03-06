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

        //public List<Article> GetArticlesBySuperCategoryID(int superCategoryID)
        //{
        //    using (SqlConnection cn = new SqlConnection(this.ConnectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("usp_SelectArticlesBySuperCategoryID", cn);

        //        cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;

        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cn.Open();

        //        IDataReader dr = ExecuteReader(cmd);

        //        List<Article> list = new List<Article>();
        //        while (dr.Read())
        //        {
        //            list.Add(GetArticleFromReader(dr, false));
        //        }
        //        return list;
        //    }
        //}

        public bool RateArticle(int articleID, int rating)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_InsertVote", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;
                cmd.Parameters.Add("@Rating", SqlDbType.Int).Value = rating;

                cn.Open();

                ExecuteScalar(cmd);
                return true;
            }
        }

        public List<Article> GetArticlesPublishedPagedByCategoryIDAndParentCategoryID(int categoryID, DateTime currentDate, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesPublishedPagedByCategoryIDAndParentCategoryID", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
                cmd.Parameters.Add("@CurrentDate", SqlDbType.DateTime).Value = currentDate;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

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

        /// <summary>
        /// Lấy các bài viết theo nhóm thư mục
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="currentDate"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public List<Article> GetArticlesPublishedPagedBySuperCategoryID(int superCategoryID, DateTime currentDate, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetPublishedPagedBySuperCategoryID", cn);

                cmd.Parameters.Add("@SuperCategoryID", SqlDbType.Int).Value = superCategoryID;
                cmd.Parameters.Add("@CurrentDate", SqlDbType.DateTime).Value = currentDate;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

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


        /// <summary>
        /// Lấy các bài viết theo tiêu chuẩn nhất định
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByFilter(int categoryID, string addedBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetByFilter", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        /// <summary>
        /// Lấy các bài viết theo tác giả (adderby)
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByAuthor(int categoryID, string addedBy)
        {

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetByAuthor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        /// <summary>
        /// Lấy các bài viết theo tác giả (adderby)
        /// </summary>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByAuthor(string addedBy)
        {

            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetByAuthorName", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        /// <summary>
        /// Lấy tổng số bài viết theo tác giả (adderby)
        /// </summary>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public int GetTotalArticlesByAuthor(string addedBy)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetTotalByAuthor", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;

                cn.Open();

                return (int)this.ExecuteScalar(cmd);
            }
        }
        /// <summary>
        /// Lấy tổng số bài viết trong 1 thư mục theo tên tác giả
        /// </summary>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public int GetTotalArticlesByAuthorAndCategoryID(string addedBy, int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetTotalByAuthorAndCategoryID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@AddedBy", SqlDbType.NVarChar).Value = addedBy;
                cmd.Parameters.Add("@CategoryID", SqlDbType.NVarChar).Value = categoryID;

                cn.Open();

                return (int)this.ExecuteScalar(cmd);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<Article> GetArticlesByCategoryIDFilter(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesByCategoryIDFilter", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        /// <summary>
        /// Cập nhật các thông tin về xuất bản của bài viết
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        public bool UpdatePublish(Article article)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_UpdatePublish", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = article.ArticleID;
                cmd.Parameters.Add("@ReleaseDate", SqlDbType.DateTime).Value = article.ReleaseDate;
                cmd.Parameters.Add("@ExpireDate", SqlDbType.DateTime).Value = article.ExpireDate;
                cmd.Parameters.Add("@Approved", SqlDbType.Bit).Value = article.Approved;
                cmd.Parameters.Add("@Listed", SqlDbType.Bit).Value = article.Listed;
                cmd.Parameters.Add("@CommentsEnabled", SqlDbType.Bit).Value = article.CommentsEnabled;
                cmd.Parameters.Add("@OnlyForMembers", SqlDbType.Bit).Value = article.OnlyForMembers;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                int ret = ExecuteNonQuery(cmd);

                return (ret == 1);
            }
        }

        /// <summary>
        /// Lấy danh sách các bài viết theo mệnh đề được động
        /// </summary>
        /// <param name="whereCondition">Mênh đề để lọc bài viết(SQL)</param>
        /// <param name="orderByExpression">Mệnh đề sắp xếp</param>
        /// <returns></returns>
        public List<Article> GetArticlesDynamic(string whereCondition, string orderByExpression)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[usp_SelectArticlesDynamic]", cn);

                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = whereCondition;
                cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderByExpression;

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

        /// <summary>
        /// Tìm kiếm bài viết theo mệnh đề SQL
        /// </summary>
        /// <param name="whereCondition">mệnh đề sql</param>
        /// <returns></returns>
        public List<Article> SearchArticles(string whereCondition)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[Articles_Search]", cn);

                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = whereCondition;
                //cmd.Parameters.Add("@OrderByExpression", SqlDbType.NVarChar).Value = orderByExpression;

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

        public List<Article> AdvanceSearchArticles(string whereCondition, DateTime fromDate, DateTime toDate, int categoryID, int superCategoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[Articles_AdvanceSearch]", cn);

                cmd.Parameters.Add("@WhereCondition", SqlDbType.NVarChar).Value = whereCondition;
                cmd.Parameters.Add("@FromDate", SqlDbType.DateTime).Value = fromDate;
                cmd.Parameters.Add("@ToDate", SqlDbType.DateTime).Value = toDate;
                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
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

        // Lấy Top 10 các bài viết được xem nhiều nhất.

        public List<Article> TopTenArticles()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("[usp_SelectTopTenArticles]", cn);

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

        /// <summary>
        /// Lấy các bài viết chưa được duyệt
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticlesUnApproved()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Articles_GetUnapproved", cn);

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

        /// <summary>
        /// Lấy các bài viết không được hiển thị.
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticlesUnListed()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Articles_GetUnlisted", cn);

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

        public string GetBody(int articleID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Articles_GetBody", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;
                cn.Open();

                return (string)this.ExecuteScalar(cmd);
            }
        }

        public bool IncrementViewCount(int articleID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Articles_IncrementViewCount", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;
                cn.Open();
                int ret = ExecuteNonQuery(cmd);
                return (ret == 1);
            }
        }

        /// <summary>
        /// Lấy các bài viết trước bài viết hiện tại
        /// </summary>
        /// <param name="articleID">bài viết hiện tại</param>
        /// <param name="rowCount">số bài viết tiếp theo</param>
        /// <param name="currentDate">Ngày hiện tại (để sét bài viết có được thể hiện hay không)</param>
        /// <returns></returns>
        public List<Article> GetArticlesPublishedPrevious(int articleID, int rowCount, DateTime currentDate)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetPreviousFromArticlesID", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;
                cmd.Parameters.Add("@RowCount", SqlDbType.Int).Value = rowCount;
                cmd.Parameters.Add("@CurrentDate", SqlDbType.DateTime).Value = currentDate;

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
        /// <summary>
        /// Get top ten Articles with the same CategotyID
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>

        public List<Article> GetTopTenArticles(int articleID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_GetTopTenFromArticlesID", cn);

                cmd.Parameters.Add("@ArticleID", SqlDbType.Int).Value = articleID;

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

        /// <summary>
        /// Get Top Ten Articles by CategoryID
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public List<Article> GetTopTenArticlesByCategoryID(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("Articles_AssessArticlesByCategoryID", cn);

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


        public List<Article> GetArticlesPaged(int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesPaged", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        public List<Article> GetArticlesPublishedPaged(DateTime currentDate, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesPublishedPaged", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CurrentDate", SqlDbType.DateTime).Value = currentDate;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        public List<Article> GetArticlesPublishedPagedByCategoryID(int categoryID, DateTime currentDate, int pageIndex, int pageSize)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("usp_SelectArticlesPublishedPagedByCategoryID", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;
                cmd.Parameters.Add("@CurrentDate", SqlDbType.DateTime).Value = currentDate;
                cmd.Parameters.Add("@PageIndex", SqlDbType.Int).Value = pageIndex;
                cmd.Parameters.Add("@PageSize", SqlDbType.Int).Value = pageSize;

                cn.Open();

                List<Article> list = new List<Article>();
                IDataReader dr = ExecuteReader(cmd);
                while (dr.Read())
                {
                    list.Add(GetArticleFromReader(dr, false));
                }
                return list;
            }
        }

        public int GetTotalArticles()
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Articles_GetTotal", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                return (int)this.ExecuteScalar(cmd);
            }
        }

        public int GetTotalArticlesByCategoryID(int categoryID)
        {
            using (SqlConnection cn = new SqlConnection(this.ConnectionString))
            {

                SqlCommand cmd = new SqlCommand("Articles_GetTotalArticlesByCategoryID", cn);

                cmd.Parameters.Add("@CategoryID", SqlDbType.Int).Value = categoryID;

                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();

                return (int)this.ExecuteScalar(cmd);
            }
        }



    }

}