using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PollsBF: BaseBF
    {

        protected int _pollID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _questionText = String.Empty;
        protected bool _isCurrent;
        protected bool _isArchived;
        protected DateTime _archivedDate;

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
//--------------------------------------------
        private int _votes = 0;
        public int Votes
        {
            get { return _votes; }
            private set { _votes = value; }
        }

        private List<PollOptionsBF> _pollOptions = null;
        public List<PollOptionsBF> PollOptions
        {
            get
            {
                if (_pollOptions == null)
                    _pollOptions = PollOptionsBF.GetPollOptionsByPollId(this.PollID);
                return _pollOptions;
            }
        }
        #endregion

        /***********************************
      * Static properties
      ************************************/

        public static int CurrentPollID
        {
            get
            {
                int pollID = -1;
                //string key = "Polls_Poll_Current";

                //if (BasePoll.Settings.EnableCaching && BizObject.Cache[key] != null)
                //{
                //    pollID = (int)BizObject.Cache[key];
                //}
                //else
                //{
                    pollID = SiteProvider.PollsProvider.GetCurrentPollID();
                //    BasePoll.CacheData(key, pollID);
                //}

                return pollID;
            }
        }

        public static PollsBF CurrentPoll
        {
            get
            {
                return GetPollsBF(CurrentPollID);
            }
        }

        //Lưu trữ bình trọn (không bình chọn nữa)
        public static bool ArchivePoll(int pollID)
        {
            return SiteProvider.PollsProvider.ArchivePoll(pollID);
        }

        public static int Insert(string questionText, bool isCurrent, bool isArchived)
        {
            return SiteProvider.PollsProvider.Insert(new Poll(-1, DateTime.Now, CurrentUserName, questionText, isCurrent, false, 0));
        }

        public static List<PollsBF> GetPollsArchived()
        {
            return GetPollsBFListFromPollsList(SiteProvider.PollsProvider.GetPollsArchived());
        }

        public static List<PollsBF> GetPollsNonArchived()
        {
            return GetPollsBFListFromPollsList(SiteProvider.PollsProvider.GetPollsNonArchived());
        }
        //=============================================
		public PollsBF(int pollID, DateTime addedDate, string addedBy, string questionText, bool isCurrent, bool isArchived, DateTime archivedDate, int votes)
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

        private static List<PollsBF> GetPollsBFListFromPollsList(List<Poll> recordset)
        {
            List<PollsBF> ret = new List<PollsBF>();
            foreach (Poll record in recordset)
                ret.Add(GetPollsBFFromPoll(record));
            return ret;
        }

        private static PollsBF GetPollsBFFromPoll(Poll record)
        {
            if (record == null)
                return null;
            else
            {
                return new PollsBF(record.PollID, record.AddedDate, record.AddedBy, record.QuestionText, record.IsCurrent, record.IsArchived, record.ArchivedDate, record.Votes);
            }
        }

		public static PollsBF  GetPollsBF(int pollID)
		{
			return GetPollsBFFromPoll(SiteProvider.PollsProvider.GetPoll(pollID));
		}
		
		//Get by ForeignKey
		
		//Get All
		public static List<PollsBF> GetPollsAll()
		{
			return GetPollsBFListFromPollsList(SiteProvider.PollsProvider.GetPollsAll());
		}
		
		//Insert
		public int Insert()
		{
			return PollsBF.Insert(this.PollID, this.AddedDate, this.AddedBy, this.QuestionText, this.IsCurrent, this.IsArchived, this.ArchivedDate, this.Votes);
		}
		
		//Update
		public bool Update()
		{
			return PollsBF.Update(this.PollID, this.AddedDate, this.AddedBy, this.QuestionText, this.IsCurrent, this.IsArchived, this.ArchivedDate, this.Votes);
		}
		
		//Delete
		public bool Delete()
		{
			return PollsBF.Delete(this.PollID);
		}			
		
		//Insert
		public static int Insert(int pollID, DateTime addedDate, string addedBy, string questionText, bool isCurrent, bool isArchived, DateTime archivedDate, int votes)
		{
			return SiteProvider.PollsProvider.Insert(new Poll(pollID, addedDate, addedBy, questionText, isCurrent, isArchived, archivedDate, votes));
		}
		
		//Update
		public static bool Update(int pollID, DateTime addedDate, string addedBy, string questionText, bool isCurrent, bool isArchived, DateTime archivedDate, int votes)
		{
			return SiteProvider.PollsProvider.Update(new Poll(pollID, addedDate, addedBy, questionText, isCurrent, isArchived, archivedDate, votes));
		}
		
		//Delete
		public static bool Delete(int pollID)
		{
			return SiteProvider.PollsProvider.Delete(pollID);
		}			

    }

}
