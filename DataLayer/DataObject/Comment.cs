using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Comment
    {
        protected long _commentID;
        protected string _fullName = String.Empty;
        protected string _email = String.Empty;
        protected string _body = String.Empty;
        protected int _articleID;
        protected string _userName = String.Empty;
        protected DateTime _addedDate;
        protected bool _approved;

        public Comment()
        {
        }

        public Comment(long commentID, string fullName, string email, string body, int articleID, string userName, DateTime addedDate, bool approved)
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

        #region Public Properties

        public long CommentID
        {
            get { return _commentID; }
            set { _commentID = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public int ArticleID
        {
            get { return _articleID; }
            set { _articleID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public bool Approved
        {
            get { return _approved; }
            set { _approved = value; }
        }
        #endregion
    }

}
