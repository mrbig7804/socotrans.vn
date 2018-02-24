using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class FeedbacksBF
    {

        protected int _contactID;
        protected DateTime _feedbackDate;
        protected string _fullName = String.Empty;
        protected string _tel = String.Empty;
        protected string _email = String.Empty;
        protected string _title = String.Empty;
        protected string _detail = String.Empty;

        #region Public Properties

        public int ContactID
        {
            get { return _contactID; }
            set { _contactID = value; }
        }

        public DateTime FeedbackDate
        {
            get { return _feedbackDate; }
            set { _feedbackDate = value; }
        }

        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Detail
        {
            get { return _detail; }
            set { _detail = value; }
        }
        #endregion

        private static List<FeedbacksBF> GetFeedbacksBFListFromFeedbacksList(List<Feedback> recordset)
        {
            List<FeedbacksBF> ret = new List<FeedbacksBF>();
            foreach (Feedback record in recordset)
                ret.Add(GetFeedbacksBFFromFeedback(record));
            return ret;
        }

        private static FeedbacksBF GetFeedbacksBFFromFeedback(Feedback record)
        {
            if (record == null)
                return null;
            else
            {
                return new FeedbacksBF(record.ContactID, record.FeedbackDate, record.FullName, record.Tel, record.Email, record.Title, record.Detail);
            }
        }

        public FeedbacksBF()
        {
        }


        public FeedbacksBF(int contactID, DateTime feedbackDate, string fullName, string tel, string email, string title, string detail)
        {
            _contactID = contactID;
            _feedbackDate = feedbackDate;
            _fullName = fullName;
            _tel = tel;
            _email = email;
            _title = title;
            _detail = detail;
        }

        public static FeedbacksBF GetFeedbacksBF(int contactID)
        {
            return GetFeedbacksBFFromFeedback(SiteProvider.FeedbacksProvider.GetFeedback(contactID));
        }

        //Get by ForeignKey

        //Get All
        public static List<FeedbacksBF> GetFeedbacksAll()
        {
            return GetFeedbacksBFListFromFeedbacksList(SiteProvider.FeedbacksProvider.GetFeedbacksAll());
        }

        //Insert
        public int Insert()
        {
            return FeedbacksBF.Insert(this.ContactID, this.FeedbackDate, this.FullName, this.Tel, this.Email, this.Title, this.Detail);
        }

        //Update
        public bool Update()
        {
            return FeedbacksBF.Update(this.ContactID, this.FeedbackDate, this.FullName, this.Tel, this.Email, this.Title, this.Detail);
        }

        //Delete
        public bool Delete()
        {
            return FeedbacksBF.Delete(this.ContactID);
        }

        //Insert
        public static int Insert(int contactID, DateTime feedbackDate, string fullName, string tel, string email, string title, string detail)
        {
            return SiteProvider.FeedbacksProvider.Insert(new Feedback(contactID, feedbackDate, fullName, tel, email, title, detail));
        }

        //Update
        public static bool Update(int contactID, DateTime feedbackDate, string fullName, string tel, string email, string title, string detail)
        {
            return SiteProvider.FeedbacksProvider.Update(new Feedback(contactID, feedbackDate, fullName, tel, email, title, detail));
        }

        //Delete
        public static bool Delete(int contactID)
        {
            return SiteProvider.FeedbacksProvider.Delete(contactID);
        }

    }

}
