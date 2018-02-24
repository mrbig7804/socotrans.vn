using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PollOption
    {
        protected int _pollOptionID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected int _pollId;
        protected string _optionText = String.Empty;
        protected int _votes;
        protected double _percentage;

        public PollOption()
        {
        }

        public PollOption(int pollOptionID, DateTime addedDate, string addedBy, int pollId, string optionText, int votes, double percentage)
        {
            _pollOptionID = pollOptionID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _pollId = pollId;
            _optionText = optionText;
            _votes = votes;
            _percentage = percentage;
        }

        #region Public Properties

        public int PollOptionID
        {
            get { return _pollOptionID; }
            set { _pollOptionID = value; }
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

        public int PollId
        {
            get { return _pollId; }
            set { _pollId = value; }
        }

        public string OptionText
        {
            get { return _optionText; }
            set { _optionText = value; }
        }

        public int Votes
        {
            get { return _votes; }
            set { _votes = value; }
        }

        public double Percentage
        {
            get { return _percentage; }
            set { _percentage = value; }
        }
        #endregion
    }
}

