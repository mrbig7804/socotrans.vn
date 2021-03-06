using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

using System.Web.Security;
using System.Security;
using System.IO;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    [Serializable]

    public partial class ArticlesBF
    {
        protected int _articleID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected int _categoryID;
        protected string _title = String.Empty;
        protected string _abstract = String.Empty;
        protected string _body = String.Empty;
        protected DateTime _releaseDate;
        protected DateTime _expireDate;
        protected bool _approved;
        protected bool _listed;
        protected bool _commentsEnabled;
        protected bool _onlyForMembers;
        protected int _viewCount;
        protected int _votes;
        protected int _totalRating;
        protected string _pictureUrl = String.Empty;

        #region Public Properties

        public int ArticleID
        {
            get { return _articleID; }
            set { _articleID = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Abstract
        {
            get { return _abstract; }
            set { _abstract = value; }
        }

        //public string Body
        //{
        //    get {return _body;}
        //    set {_body = value;}
        //}

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        public DateTime ExpireDate
        {
            get { return _expireDate; }
            set { _expireDate = value; }
        }

        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }

        public bool Listed
        {
            get { return _listed; }
            set { _listed = value; }
        }

        public bool CommentsEnabled
        {
            get { return _commentsEnabled; }
            set { _commentsEnabled = value; }
        }

        public bool OnlyForMembers
        {
            get { return _onlyForMembers; }
            set { _onlyForMembers = value; }
        }

        public int ViewCount
        {
            get { return _viewCount; }
            set { _viewCount = value; }
        }

        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        public int TotalRating
        {
            get { return _totalRating; }
            set { _totalRating = value; }
        }

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set { _pictureUrl = value; }
        }
        #endregion

        private static List<ArticlesBF> GetArticlesBFListFromArticlesList(List<Article> recordset)
        {
            List<ArticlesBF> ret = new List<ArticlesBF>();
            foreach (Article record in recordset)
                ret.Add(GetArticlesBFFromArticle(record));
            return ret;
        }

        private static ArticlesBF GetArticlesBFFromArticle(Article record)
        {
            if (record == null)
                return null;
            else
            {
                return new ArticlesBF(record.ArticleID, record.AddedDate, record.AddedBy, record.CategoryID, record.Title, record.Abstract, record.Body, record.ReleaseDate, record.ExpireDate, record.Approved, record.Listed, record.CommentsEnabled, record.OnlyForMembers, record.ViewCount, record.Votes, record.TotalRating, record.PictureUrl);
            }
        }

        public ArticlesBF()
        {
        }


        public ArticlesBF(int articleID, DateTime addedDate, string addedBy, int categoryID, string title, string articleAbstract, string body, DateTime releaseDate, DateTime expireDate, bool approved, bool listed, bool commentsEnabled, bool onlyForMembers, int viewCount, int votes, int totalRating, string pictureUrl)
        {
            _articleID = articleID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _categoryID = categoryID;
            _title = title;
            _abstract = articleAbstract;
            _body = body;
            _releaseDate = releaseDate;
            _expireDate = expireDate;
            _approved = approved;
            _listed = listed;
            _commentsEnabled = commentsEnabled;
            _onlyForMembers = onlyForMembers;
            _viewCount = viewCount;
            _votes = votes;
            _totalRating = totalRating;
            _pictureUrl = pictureUrl;
        }

        public static ArticlesBF GetArticlesBF(int articleID)
        {
            return GetArticlesBFFromArticle(SiteProvider.ArticlesProvider.GetArticle(articleID));
        }

        //Get by ForeignKey
        public static List<ArticlesBF> GetArticlesByCategoryID(int categoryID)
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesByCategoryID(categoryID));
        }

        //Get All
        public static List<ArticlesBF> GetArticlesAll()
        {
            return GetArticlesBFListFromArticlesList(SiteProvider.ArticlesProvider.GetArticlesAll());
        }

        //Insert
        public int Insert()
        {
            return ArticlesBF.Insert(this.ArticleID, this.AddedDate, this.AddedBy, this.CategoryID, this.Title, this.Abstract, this.Body, this.ReleaseDate, this.ExpireDate, this.Approved, this.Listed, this.CommentsEnabled, this.OnlyForMembers, this.ViewCount, this.Votes, this.TotalRating, this.PictureUrl);
        }

        //Update
        public bool Update()
        {
            return ArticlesBF.Update(this.ArticleID, this.AddedDate, this.AddedBy, this.CategoryID, this.Title, this.Abstract, this.Body, this.ReleaseDate, this.ExpireDate, this.Approved, this.Listed, this.CommentsEnabled, this.OnlyForMembers, this.ViewCount, this.Votes, this.TotalRating, this.PictureUrl);
        }

        //Delete
        public bool Delete()
        {
            return ArticlesBF.Delete(
            this.ArticleID);
        }

        //Insert
        public static int Insert(int articleID, DateTime addedDate, string addedBy, int categoryID, string title, string articleAbstract, string body, DateTime releaseDate, DateTime expireDate, bool approved, bool listed, bool commentsEnabled, bool onlyForMembers, int viewCount, int votes, int totalRating, string pictureUrl)
        {
            return SiteProvider.ArticlesProvider.Insert(new Article(articleID, addedDate, addedBy, categoryID, title, articleAbstract, body, releaseDate, expireDate, approved, listed, commentsEnabled, onlyForMembers, viewCount, votes, totalRating, pictureUrl));
        }

        //Update
        public static bool Update(int articleID, DateTime addedDate, string addedBy, int categoryID, string title, string articleAbstract, string body, DateTime releaseDate, DateTime expireDate, bool approved, bool listed, bool commentsEnabled, bool onlyForMembers, int viewCount, int votes, int totalRating, string pictureUrl)
        {
            return SiteProvider.ArticlesProvider.Update(new Article(articleID, addedDate, addedBy, categoryID, title, articleAbstract, body, releaseDate, expireDate, approved, listed, commentsEnabled, onlyForMembers, viewCount, votes, totalRating, pictureUrl));
        }

        //Delete
        public static bool Delete(int articleID)
        {
            //xóa tất cả ảnh liên quan tới bài viết
            string pathCheck = "~/Attachs/Articles/" + articleID + "/";

            if(Directory.Exists(HttpContext.Current.Server.MapPath(pathCheck)))
            {
                string[] files = Directory.GetFiles(HttpContext.Current.Server.MapPath(pathCheck));

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        File.Delete(files[i]);
                    }
                    catch
                    { }
                }

                try
                {
                    Directory.Delete(HttpContext.Current.Server.MapPath(pathCheck), true);
                }
                catch
                { }
            }

            ////xóa tất cả những bình luận tới bài viết trên trang
            //List<CommentsBF> listCmt = CommentsBF.GetCommentsByArticleID(articleID);

            //if (listCmt != null)
            //{
            //    foreach (CommentsBF cmt in listCmt)
            //    {
            //        cmt.Delete();
            //    }
            //}

            return SiteProvider.ArticlesProvider.Delete(articleID);
        }
    }
}
