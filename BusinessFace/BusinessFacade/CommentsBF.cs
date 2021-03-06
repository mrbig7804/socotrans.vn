using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    /// <summary>
    /// sondt:27/09/07 Tạo mới
    /// ngocdv:17/10/07 Thêm hàm Sửa dổi comment (update comment)
    /// ngocdv:19/10/07 Thêm thuộc tính ArticleTitle để hiển thị Tiêu đề của bài viết
    /// sondt:05/11/07 Thêm hàm GetCommentsByUser(name)
    /// </summary>
    public class CommentsBF: Zensoft.Website.DataLayer.DataObject.Comment
    { 

        protected string _articleTitle = string.Empty;

        public string ArticleTitle
        {
            get
            {
                if (string.IsNullOrEmpty(_articleTitle))
                {
                    ArticlesBF article = ArticlesBF.GetArticlesBF(this.ArticleID);
                    _articleTitle = article.Title;
                }
                return _articleTitle;
            }
        }

        private static List<CommentsBF> GetCommentsBFListFromCommentsList(List<Comment> recordset)
        {
            List<CommentsBF> ret = new List<CommentsBF>();
            foreach (Comment record in recordset)
                ret.Add(GetCommentsBFFromComment(record));
            return ret;
        }

        private static CommentsBF GetCommentsBFFromComment(Comment record)
        {
            if (record == null)
                return null;
            else
            {
                return new CommentsBF(record.CommentID, record.FullName, record.Email, record.Body, record.ArticleID, record.UserName, record.AddedDate, record.Approved);
            }
        }

        public CommentsBF()
        {
        }


        public CommentsBF(long commentID, string fullName, string email, string body, int articleID, string userName, DateTime addedDate, bool approved)
        {
            _commentID = commentID;
            _fullName = fullName;
            _email = email;
            _body = body;
            _articleID = articleID;
            _userName = userName;
            _addedDate = addedDate;
            _approved = approved;
        }

        public static CommentsBF GetCommentsBF(long commentID)
        {
            return GetCommentsBFFromComment(SiteProvider.CommentsProvider.GetComment(commentID));
        }

        //Get by ForeignKey
        public static List<CommentsBF> GetCommentsByArticleID(int articleID)
        {
            return GetCommentsBFListFromCommentsList(SiteProvider.CommentsProvider.GetCommentsByArticleID(articleID));
        }

        //Get All
        public static List<CommentsBF> GetCommentsAll()
        {
            return GetCommentsBFListFromCommentsList(SiteProvider.CommentsProvider.GetCommentsAll());
        }

        //Get All
        public static List<CommentsBF> GetCommentsByUser(string name)
        {
            return GetCommentsBFListFromCommentsList(SiteProvider.CommentsProvider.GetCommentsByUser(name));
        }

        //Get All the Comments have not Specified
        public static List<CommentsBF> GetCommentsNotSpecied()
        {
            return GetCommentsBFListFromCommentsList(SiteProvider.CommentsProvider.GetCommentsNotSpecied());
        }

        // Get all the Comments Specified
        public static List<CommentsBF> GetCommentsSpecied()
        {
            return GetCommentsBFListFromCommentsList(SiteProvider.CommentsProvider.GetCommentsSpecied());
        }

        // Specifying comments for the Articles
        public static bool SpecifyComment(int commentID)
        {
            return SiteProvider.CommentsProvider.SpecifyComment(commentID);
        }

        //Insert
        public long Insert()
        {
            return CommentsBF.Insert(this.CommentID, this.FullName, this.Email, this.Body, this.ArticleID, this.UserName, this.AddedDate, this.Approved);
        }

        //Update
        public bool Update()
        {
            return CommentsBF.Update(this.CommentID, this.FullName, this.Email, this.Body, this.ArticleID, this.UserName, this.AddedDate, this.Approved);
        }

        public static bool Update(long commentID, string body, bool approved)
        {
            CommentsBF comment = CommentsBF.GetCommentsBF(commentID);
            comment.Body = body;
            comment.Approved = approved;

            return SiteProvider.CommentsProvider.Update((Comment)comment);
        }


        //Delete
        public bool Delete()
        {
            return CommentsBF.Delete(this.CommentID);
        }

        //Insert
        public static long Insert(long commentID, string fullName, string email, string body, int articleID, string userName, DateTime addedDate, bool approved)
        {
            return SiteProvider.CommentsProvider.Insert(new Comment(commentID, fullName, email, body, articleID, userName, addedDate, approved));
        }

        //Update
        public static bool Update(long commentID, string fullName, string email, string body, int articleID, string userName, DateTime addedDate, bool approved)
        {
            return SiteProvider.CommentsProvider.Update(new Comment(commentID, fullName, email, body, articleID, userName, addedDate, approved));
        }

        //Delete
        public static bool Delete(long commentID)
        {
            return SiteProvider.CommentsProvider.Delete(commentID);
        }

    }


}
