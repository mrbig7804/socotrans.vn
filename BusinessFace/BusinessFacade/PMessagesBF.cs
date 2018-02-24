using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    //25/04/08: Sondt them ham GetPMessagesOutbox
    //25/04/08: Sondt them ham GetPMessagesInbox
    //26/04/08: Sondt sua ham Delete
    public class PMessagesBF
    {

        protected int _pMessageID;
        protected string _fromUserName = String.Empty;
        protected DateTime _created;
        protected string _subject = String.Empty;
        protected string _body = String.Empty;
        protected bool _senderDeleted;

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

        #region Custom Methor
        public static List<PMessagesBF> GetPMessagesOutbox(string userName)
        {
            return GetPMessagesBFListFromPMessagesList(SiteProvider.PMessagesProvider.GetPMessagesOutbox(userName));
        }

        public static List<PMessagesBF> GetPMessagesInbox(string userName)
        {
            return GetPMessagesBFListFromPMessagesList(SiteProvider.PMessagesProvider.GetPMessagesInbox(userName));
        }

        #endregion

        private static List<PMessagesBF> GetPMessagesBFListFromPMessagesList(List<PMessage> recordset)
        {
            List<PMessagesBF> ret = new List<PMessagesBF>();
            foreach (PMessage record in recordset)
                ret.Add(GetPMessagesBFFromPMessage(record));
            return ret;
        }

        private static PMessagesBF GetPMessagesBFFromPMessage(PMessage record)
        {
            if (record == null)
                return null;
            else
            {
                return new PMessagesBF(record.PMessageID, record.FromUserName, record.Created, record.Subject, record.Body, record.SenderDeleted);
            }
        }

        public PMessagesBF()
        {
        }


        public PMessagesBF(int pMessageID, string fromUserName, DateTime created, string subject, string body, bool senderDeleted)
        {
            _pMessageID = pMessageID;
            _fromUserName = fromUserName;
            _created = created;
            _subject = subject;
            _body = body;
            _senderDeleted = senderDeleted;
        }

        public static PMessagesBF GetPMessagesBF(int pMessageID)
        {
            return GetPMessagesBFFromPMessage(SiteProvider.PMessagesProvider.GetPMessage(pMessageID));
        }

        //Get by ForeignKey

        //Get All
        public static List<PMessagesBF> GetPMessagesAll()
        {
            return GetPMessagesBFListFromPMessagesList(SiteProvider.PMessagesProvider.GetPMessagesAll());
        }

        //Insert
        public int Insert()
        {
            return PMessagesBF.Insert(this.PMessageID, this.FromUserName, this.Created, this.Subject, this.Body, this.SenderDeleted);
        }

        //Update
        public bool Update()
        {
            return PMessagesBF.Update(this.PMessageID, this.FromUserName, this.Created, this.Subject, this.Body, this.SenderDeleted);
        }

        //Delete
        public bool Delete()
        {
            return PMessagesBF.Delete(
            this.PMessageID);
        }

        //Insert
        public static int Insert(int pMessageID, string fromUserName, DateTime created, string subject, string body, bool senderDeleted)
        {
            return SiteProvider.PMessagesProvider.Insert(new PMessage(pMessageID, fromUserName, created, subject, body, senderDeleted));
        }

        //Update
        public static bool Update(int pMessageID, string fromUserName, DateTime created, string subject, string body, bool senderDeleted)
        {
            return SiteProvider.PMessagesProvider.Update(new PMessage(pMessageID, fromUserName, created, subject, body, senderDeleted));
        }

        //Delete
        public static bool Delete(int pMessageID)
        {
            PMessagesBF message = PMessagesBF.GetPMessagesBF(pMessageID);
            message.SenderDeleted = true;
            message.Update();

            List<UserPMessagesBF> umessages = UserPMessagesBF.GetUserPMessagesByPMessageID(pMessageID);
            int i = 0;

            foreach (UserPMessagesBF um in umessages)
            {
                if (um.Deleted)
                {
                    um.Delete();
                    i++;
                }
            }

            if (umessages.Count == i)
                SiteProvider.PMessagesProvider.Delete(pMessageID);

            return true;
        }

    }
}
