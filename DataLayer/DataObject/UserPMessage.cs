using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class UserPMessage
    {
        protected int _userPMessageID;
        protected string _userName = String.Empty;
        protected int _pMessageID;
        protected bool _isRead;
        protected bool _deleted;

        public UserPMessage()
        {
        }

        public UserPMessage(int userPMessageID, string userName, int pMessageID, bool isRead, bool deleted)
        {
            _userPMessageID = userPMessageID;
            _userName = userName;
            _pMessageID = pMessageID;
            _isRead = isRead;
            _deleted = deleted;
        }

        #region Public Properties

        public int UserPMessageID
        {
            get { return _userPMessageID; }
            set { _userPMessageID = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public int PMessageID
        {
            get { return _pMessageID; }
            set { _pMessageID = value; }
        }

        public bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }

        public bool Deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }
        #endregion
    }

}
