using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Feedback
    {
        protected int _contactID;
        protected DateTime _feedbackDate;
        protected string _fullName = String.Empty;
        protected string _tel = String.Empty;
        protected string _email = String.Empty;
        protected string _title = String.Empty;
        protected string _detail = String.Empty;

        public Feedback()
        {
        }

        public Feedback(int contactID, DateTime feedbackDate, string fullName, string tel, string email, string title, string detail)
        {
            _contactID = contactID;
            _feedbackDate = feedbackDate;
            _fullName = fullName;
            _tel = tel;
            _email = email;
            _title = title;
            _detail = detail;
        }

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
    }


}
