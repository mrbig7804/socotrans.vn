using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PMessage
    {
        protected int _pMessageID;
        protected string _fromUserName = String.Empty;
        protected DateTime _created;
        protected string _subject = String.Empty;
        protected string _body = String.Empty;
        protected bool _senderDeleted;

        public PMessage()
        {
        }

        public PMessage(int pMessageID, string fromUserName, DateTime created, string subject, string body, bool senderDeleted)
        {
            _pMessageID = pMessageID;
            _fromUserName = fromUserName;
            _created = created;
            _subject = subject;
            _body = body;
            _senderDeleted = senderDeleted;
        }

        #region Public Properties

        public int PMessageID
        {
            get { return _pMessageID; }
            set { _pMessageID = value; }
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

        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        public bool SenderDeleted
        {
            get { return _senderDeleted; }
            set { _senderDeleted = value; }
        }
        #endregion
    }

}
