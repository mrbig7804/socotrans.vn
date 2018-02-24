using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Poll
    {
        protected int _pollID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _questionText = String.Empty;
        protected bool _isCurrent;
        protected bool _isArchived;
        protected DateTime _archivedDate;
        protected int _votes;

        public Poll()
        {
        }

        public Poll(int pollID, DateTime addedDate, string addedBy, string questionText, bool isCurrent, bool isArchived, DateTime archivedDate, int votes)
        {
            _pollID = pollID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _questionText = questionText;
            _isCurrent = isCurrent;
            _isArchived = isArchived;
            _archivedDate = archivedDate;
            _votes = votes;
        }

        public Poll(int pollID, DateTime addedDate, string addedBy, string questionText, bool isCurrent, bool isArchived, int votes)
        {
            _pollID = pollID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _questionText = questionText;
            _isCurrent = isCurrent;
            _isArchived = isArchived;
            _votes = votes;
        }

        #region Public Properties

        public int PollID
        {
            get { return _pollID; }
            set { _pollID = value; }
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

        public string QuestionText
        {
            get { return _questionText; }
            set { _questionText = value; }
        }

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { _isCurrent = value; }
        }

        public bool IsArchived
        {
            get { return _isArchived; }
            set { _isArchived = value; }
        }

        public DateTime ArchivedDate
        {
            get { return _archivedDate; }
            set { _archivedDate = value; }
        }

        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }
        #endregion
    }


}