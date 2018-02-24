using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    //26/04/08 : sondt: thay ðôÒi haÌm Delele
    //29/04/08 : sondt: them ham GetInboxByPMessageID 

    public class UserPMessagesBF
    {

        protected int _userPMessageID;
        protected string _userName = String.Empty;
        protected int _pMessageID;
        protected bool _isRead;
        protected bool _deleted;

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

        #region Custom Methor
        public static UserPMessagesBF GetInboxByPMessageID(string userName, int pMessageID)
        {
            return GetUserPMessagesBFFromUserPMessage(SiteProvider.UserPMessagesProvider.GetInboxByPMessageID(userName, pMessageID));
        }

        public static List<UserPMessagesBF> GetInboxNewMessage(string userName)
        {
            return GetUserPMessagesBFListFromUserPMessagesList(SiteProvider.UserPMessagesProvider.GetInboxNewMessage(userName));
        }

        public bool MarkDeleted()
        {
            return UserPMessagesBF.MarkDeleted(this.UserPMessageID);
        }

        public static bool MarkDeleted(int userPMessageID)
        {
            return SiteProvider.UserPMessagesProvider.MarkDeleted(userPMessageID);

        }

        #endregion


        private static List<UserPMessagesBF> GetUserPMessagesBFListFromUserPMessagesList(List<UserPMessage> recordset)
        {
            List<UserPMessagesBF> ret = new List<UserPMessagesBF>();
            foreach (UserPMessage record in recordset)
                ret.Add(GetUserPMessagesBFFromUserPMessage(record));
            return ret;
        }

        private static UserPMessagesBF GetUserPMessagesBFFromUserPMessage(UserPMessage record)
        {
            if (record == null)
                return null;
            else
            {
                return new UserPMessagesBF(record.UserPMessageID, record.UserName, record.PMessageID, record.IsRead, record.Deleted);
            }
        }

        public UserPMessagesBF()
        {
        }


        public UserPMessagesBF(int userPMessageID, string userName, int pMessageID, bool isRead, bool deleted)
        {
            _userPMessageID = userPMessageID;
            _userName = userName;
            _pMessageID = pMessageID;
            _isRead = isRead;
            _deleted = deleted;
        }

        public static UserPMessagesBF GetUserPMessagesBF(int userPMessageID)
        {
            return GetUserPMessagesBFFromUserPMessage(SiteProvider.UserPMessagesProvider.GetUserPMessage(userPMessageID));
        }

        //Get by ForeignKey
        public static List<UserPMessagesBF> GetUserPMessagesByPMessageID(int pMessageID)
        {
            return GetUserPMessagesBFListFromUserPMessagesList(SiteProvider.UserPMessagesProvider.GetUserPMessagesByPMessageID(pMessageID));
        }

        //Get All
        public static List<UserPMessagesBF> GetUserPMessagesAll()
        {
            return GetUserPMessagesBFListFromUserPMessagesList(SiteProvider.UserPMessagesProvider.GetUserPMessagesAll());
        }

        //Insert
        public int Insert()
        {
            return UserPMessagesBF.Insert(this.UserPMessageID, this.UserName, this.PMessageID, this.IsRead, this.Deleted);
        }

        //Update
        public bool Update()
        {
            return UserPMessagesBF.Update(this.UserPMessageID, this.UserName, this.PMessageID, this.IsRead, this.Deleted);
        }

        //Delete
        public bool Delete()
        {
            return UserPMessagesBF.Delete(
            this.UserPMessageID);
        }

        //Insert
        public static int Insert(int userPMessageID, string userName, int pMessageID, bool isRead, bool deleted)
        {
            return SiteProvider.UserPMessagesProvider.Insert(new UserPMessage(userPMessageID, userName, pMessageID, isRead, deleted));
        }

        //Update
        public static bool Update(int userPMessageID, string userName, int pMessageID, bool isRead, bool deleted)
        {
            return SiteProvider.UserPMessagesProvider.Update(new UserPMessage(userPMessageID, userName, pMessageID, isRead, deleted));
        }

        //Delete
        public static bool Delete(int userPMessageID)
        {
            PMessagesBF message = PMessagesBF.GetPMessagesBF(UserPMessagesBF.GetUserPMessagesBF(userPMessageID).PMessageID);


            if (message.SenderDeleted)
            {
                SiteProvider.UserPMessagesProvider.Delete(userPMessageID);

                List<UserPMessagesBF> umessages = UserPMessagesBF.GetUserPMessagesByPMessageID(message.PMessageID);

                if (umessages.Count == 0) message.Delete();
            }
            else
                UserPMessagesBF.MarkDeleted(userPMessageID);

            return true;
        }

    }

}
