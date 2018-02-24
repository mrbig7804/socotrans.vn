using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class GMessage
    {
        protected int _gMessageID;
        protected string _fromUserName = String.Empty;
        protected DateTime _created;
        protected string _message = String.Empty;
        protected bool _isSale;

        public GMessage()
        {
        }

        public GMessage(int gMessageID, string fromUserName, DateTime created, string message, bool isSale)
        {
            _gMessageID = gMessageID;
            _fromUserName = fromUserName;
            _created = created;
            _message = message;
            _isSale = isSale;
        }

        #region Public Properties

        public int GMessageID
        {
            get { return _gMessageID; }
            set { _gMessageID = value; }
        }

        public string FromUserName
        {
            get { return _fromUserName; }
            set { _fromUserName = value; }
        }

        public DateTime Created
        {
            get { return _created; }
            set { _created = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }

        public bool IsSale
        {
            get { return _isSale; }
            set { _isSale = value; }
        }
        #endregion
    }


}
