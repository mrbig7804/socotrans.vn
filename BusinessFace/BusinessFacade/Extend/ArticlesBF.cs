using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

using System.Web.Security;
using System.Security;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public partial class ArticlesBF : BaseBF
    {

        const int PREVIOUS_ARTICLE_ROW = 10;

        private CategoriesBF _category = null;
        public CategoriesBF Category
        {
            get
            {
                if (_category == null)
                    _category = CategoriesBF.GetCategoriesBF(this.CategoryID);
                return _category;
            }
        }

        public string Body
        {
            get
            {
                if (_body == string.Empty)
                    _body = SiteProvider.ArticlesProvider.GetBody(_articleID);
                return _body;
            }
            set { _body = (value); }
        }

        public double AverageRating
        {
            get
            {
                if (this.Votes >= 1)
                    return ((double)this.TotalRating / (double)this.Votes);
                else
                    return 0.0;
            }
        }


        ///////////////////////////////////////////////////////////

        public static List<ArticlesBF> GetArticlesBySuperCategoryID(int superCategoryID)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesBySuperCategoryID(superCategoryID));
        }

        /// <summary>
        /// Lấy bài viết mới nhất trong thư mục bài viết 
        /// </summary>
        /// <returns></returns>
        private static ArticlesBF GetLastArticle(ArticlesBF article)
        {

            List<CategoriesBF> categories = CategoriesBF.GetCategoriesByParentCategoryID(article.CategoryID);

            if (categories.Count > 0)
            {
                foreach (CategoriesBF c in categories)
                {
                    List<ArticlesBF> a = ArticlesBF.GetArticlesPublishedPagedByCategoryIDAndParentCategoryID(c.CategoryID, 0, 1);
                    if (a.Count > 0)
                        if (a[0].ReleaseDate.CompareTo(article.ReleaseDate) > 0)
                        {
                            return GetLastArticle(a[0]);
                        }
                }
                return article;
            }
            else return article;
        }

        /// <summary>
        /// Lấy bài viết mới nhất trong thư mục và thư mục con 
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static ArticlesBF GetLastArticleInCategory(int categoryID)
        {
            List<ArticlesBF> a = ArticlesBF.GetArticlesPublishedPagedByCategoryIDAndParentCategoryID(categoryID, 0, 1);

            try
            {

                return GetLastArticle(a[0]);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Increments an article's view count
        /// </summary>
        public static bool RateArticle(int articleID, int rating)
        {
            return SiteProvider.ArticlesProvider.RateArticle(articleID, rating);
        }

        public static List<ArticlesBF> GetArticlesPublishedPagedByCategoryIDAndParentCategoryID(int categoryID, int page, int maximumRows)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesPublishedPagedByCategoryIDAndParentCategoryID(categoryID, DateTime.Now, page, maximumRows));
        }

        public static List<ArticlesBF> GetArticlesPublishedPagedBySuperCategoryID(int superSategoryID, int page, int maximumRows)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesPublishedPagedBySuperCategoryID(superSategoryID, DateTime.Now, page, maximumRows));
        }

        /// <summary>
        /// lấy bài viết theo nhiều tiêu chí
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesByFilter(int categoryID, string addedBy)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesByFilter(categoryID, addedBy));
        }

        /// <summary>
        /// Lấy bài viết theo tác giả
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesByAuthor(int categoryID, string addedBy)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesByAuthor(categoryID, addedBy));
        }

        /// <summary>
        /// Lấy bài viết theo tác giả
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesByAuthor(string addedBy)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesByAuthor(addedBy));
        }

        /// <summary>
        /// Lấy tổng số bài viết đã được duyệt và còn tồn tại theo tác giả
        /// </summary>
        /// <param name="addedBy"></param>
        /// <returns></returns>
        public static int GetTotalArticlesByAuthor(string addedBy)
        {
            return SiteProvider.ArticlesProvider.GetTotalArticlesByAuthor(addedBy);
        }

        /// <summary>
        /// Lấy tổng số bài viết đã được duyệt và còn tồn tại có trong 1 thư mục theo tác giả (UserName) 
        /// </summary>
        /// <param name="addedBy">Tên tác giả (UserName)</param>
        /// <param name="categoryID">Mã thư mục bài viết</param>
        /// <returns>Tổng số bài viết</returns>
        public static int GetTotalArticlesByAuthorAndCategoryID(string addedBy, int categoryID)
        {
            return SiteProvider.ArticlesProvider.GetTotalArticlesByAuthorAndCategoryID(addedBy, categoryID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryID">Mã thư mục bài viết</param>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesByCategoryIDFilter(int categoryID)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesByCategoryIDFilter(categoryID));
        }

        /// <summary>
        /// Tăng số lần xem của bài viết
        /// </summary>
        /// <returns></returns>
        public bool IncrementViewCount()
        {
            return ArticlesBF.IncrementViewCount(this.ArticleID);
        }

        /// <summary>
        /// Tăng số lần xem của bài viết
        /// </summary>
        /// <returns></returns>
        public static bool IncrementViewCount(int articleID)
        {
            return SiteProvider.ArticlesProvider.IncrementViewCount(articleID);
        }

        //Cập nhật xuất bản, lệnh này chỉ dùng cho mod
        public static bool UpdatePublish(
            int articleID,
            DateTime releaseDate,
            DateTime expireDate,
            bool approved,
            bool listed,
            bool commentsEnabled,
            bool onlyForMembers)
        {

            Article article = new Article();

            article.ArticleID = articleID;
            article.ReleaseDate = releaseDate;
            article.ExpireDate = expireDate;
            article.Approved = approved;
            article.Listed = listed;
            article.CommentsEnabled = commentsEnabled;
            article.OnlyForMembers = onlyForMembers;

            return SiteProvider.ArticlesProvider.UpdatePublish(article);
        }

        /// <summary>
        /// Thêm bài viết dùng cho cộng tác viên (bài viết chưa xuất bản)
        /// </summary>
        /// <returns></returns>
        public int ContributorInsert()
        {
            return Insert(this.CategoryID, this.Title, this.Abstract, this.Body, this.PictureUrl);
        }

        /// <summary>
        /// Thêm bài viết mặc định, chưa xuất bản dùng cho cộng tác viên
        /// </summary>
        /// <param name="categoryID"></param>
        /// <param name="title"></param>
        /// <param name="articleAbstract"></param>
        /// <param name="body"></param>
        /// <param name="pictureUrl"></param>
        /// <returns></returns>
        public static int Insert(int categoryID, string title, string articleAbstract, string body, string pictureUrl)
        {
            return SiteProvider.ArticlesProvider.Insert(
                new Article(-1,
                        DateTime.Now, CurrentUserName,
                        categoryID,
                        title,
                        articleAbstract,
                        body,
                        DateTime.Now,
                        DateTime.MaxValue,
                        false,
                        true, //listed
                        false,
                        false,
                        0,
                        0,
                        0,
                        pictureUrl));
        }

        /// <summary>
        /// Cập nhật bài viết, dùng cho cộng tác viên (bài viết sẽ không duyệt sau khi cập nhật)
        /// </summary>
        /// <returns></returns>
        public bool ContributorUpdate()
        {
            return Update(this.ArticleID, this.CategoryID, this.Title, this.Abstract, this.Body, this.PictureUrl);
        }

        /// <summary>
        /// Cập nhật bài viết, dùng cho cộng tác viên
        /// Khi thay đổi bài viết thì bài viết sẽ không được hiển thị cho người dùng nữa
        /// </summary>
        /// <param name="articleID"></param>
        /// <param name="categoryID"></param>
        /// <param name="title"></param>
        /// <param name="articleAbstract"></param>
        /// <param name="body"></param>
        /// <param name="pictureUrl"></param>
        /// <returns></returns>
        public static bool Update(int articleID, int categoryID, string title, string articleAbstract, string body, string pictureUrl)
        {
            Article article = SiteProvider.ArticlesProvider.GetArticle(articleID);

            article.CategoryID = categoryID;
            article.Title = title;
            article.Abstract = articleAbstract;
            article.PictureUrl = pictureUrl;
            article.Approved = false;
            article.Body = body;

            return SiteProvider.ArticlesProvider.Update(article);
        }

        public bool UpdatePublish()
        {
            return UpdatePublish(this.ArticleID,
                this.ReleaseDate,
                this.ExpireDate,
                this.Approved,
                this.Listed,
                this.CommentsEnabled,
                this.OnlyForMembers);
        }

        /// <summary>
        /// Liệt kê danh sách bài viết chưa được hiển thị
        /// </summary>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesUnListed()
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesUnListed());
        }

        /// <summary>
        /// Lấy các bài viết chưa được duyệt
        /// </summary>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesUnApproved()
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesUnApproved());
        }

        public static List<ArticlesBF> GetArticlesBFPaged(int page, int maximumRows)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesPaged(page, maximumRows));
        }

        public static List<ArticlesBF> GetArticlesPublishedPrevious(int articleID, int rowCount)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesPublishedPrevious(articleID, rowCount, DateTime.Now));
        }

        /// <summary>
        /// Lấy tất cả các bài viết đã được duyệt
        /// </summary>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesPublishedAll()
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesPublishedPaged(DateTime.Now, 0, MAXROWS));
        }



        /// <summary>
        /// Lấy các bài viết đã được duyệt và phân trang
        /// </summary>
        /// <param name="page">thứ tự trang (bắt đầu là 0)</param>
        /// <param name="maximumRows">số bài viết</param>
        /// <returns></returns>
        public static List<ArticlesBF> GetArticlesPublishedPaged(int page, int maximumRows)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesPublishedPaged(DateTime.Now, 0, maximumRows));
        }

        public static List<ArticlesBF> GetArticlesPublishedPagedByCategoryID(int categoryID, int page, int maximumRows)
        {
            return GetArticlesBFListFromArticlesList(
                SiteProvider.ArticlesProvider.GetArticlesPublishedPagedByCategoryID(categoryID, DateTime.Now, page, maximumRows));
        }

        public static List<ArticlesBF> GetArticlesDynamic(string whereCondition, string orderByExpression)
        {
            if (string.IsNullOrEmpty(whereCondition)) return null;
            return GetArticlesBFListFromArticlesList(
              SiteProvider.ArticlesProvider.GetArticlesDynamic(whereCondition, orderByExpression));
        }

        public static List<ArticlesBF> GetArticlesDynamic(string whereCondition)
        {
            if (string.IsNullOrEmpty(whereCondition)) return null;
            return GetArticlesBFListFromArticlesList(
              SiteProvider.ArticlesProvider.GetArticlesDynamic(whereCondition, ""));
        }

        public static List<ArticlesBF> SearchArticle(string whereCondition)
        {
            if (string.IsNullOrEmpty(whereCondition)) return null;
            return GetArticlesBFListFromArticlesList(
              SiteProvider.ArticlesProvider.SearchArticles(whereCondition));
        }

        // Get top Ten Articles by CategoryID
        public static List<ArticlesBF> GetTopTenArticlesByCategoryID(int categoryID)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetTopTenArticlesByCategoryID(categoryID));
        }

        // Advance Search
        public static List<ArticlesBF> Articles_AdvanceSearch(string whereCondition, DateTime fromDate, DateTime toDate, int categoryID, int superCategoryID)
        {
            if (string.IsNullOrEmpty(whereCondition)) return null;
            return GetArticlesBFListFromArticlesList(
              SiteProvider.ArticlesProvider.AdvanceSearchArticles(whereCondition, fromDate, toDate, categoryID, superCategoryID));
        }

        /// <summary>
        /// Tìm kiếm nâng cao
        /// </summary>
        /// <param name="whereCondition"></param>
        /// <param name="categoryID"></param>
        /// <param name="superCategoryID"></param>
        /// <returns></returns>
        public static List<ArticlesBF> Articles_AdvanceSearch(string whereCondition, int categoryID, int superCategoryID)
        {
            if (string.IsNullOrEmpty(whereCondition)) return null;
            return GetArticlesBFListFromArticlesList(
              SiteProvider.ArticlesProvider.AdvanceSearchArticles(whereCondition, new DateTime(1980, 1, 1), DateTime.Now, categoryID, superCategoryID));
        }

        /// <summary>
        /// Lấy tổng số bài viết đã có
        /// </summary>
        /// <returns></returns>
        public static int GetTotalArticle()
        {
            return SiteProvider.ArticlesProvider.GetTotalArticles();
        }

        /// <summary>
        /// Lấy tổng số bài viết trong thư mục
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        public static int GetTotalArticlesByCategoryID(int categoryID)
        {
            return SiteProvider.ArticlesProvider.GetTotalArticlesByCategoryID(categoryID);
        }


    }

}
