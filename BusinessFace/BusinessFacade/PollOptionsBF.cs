using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PollOptionsBF : BaseBF
	{
        //--custom method------------------------
        public static bool Vote(int pollOptionID)
        {
            return SiteProvider.PollOptionsProvider.Vote(pollOptionID);
        }

        public static int insert(int pollId, string optionText) 
        {
            return SiteProvider.PollOptionsProvider.Insert(new PollOption(-1, DateTime.Now, CurrentUserName, pollId, optionText, 0, 0));
        }

        //--------------------------------
        protected int _pollOptionID;
		protected DateTime _addedDate;
		protected string _addedBy = String.Empty;
		protected int _pollId;
		protected string _optionText = String.Empty;
		protected int _votes;
		protected double _percentage;
		
		#region Public Properties
		
		public int PollOptionID
		{
			get {return _pollOptionID;}
			set {_pollOptionID = value;}
		}

		public DateTime AddedDate
		{
			get {return _addedDate;}
			set {_addedDate = value;}
		}

		public string AddedBy
		{
			get {return _addedBy;}
			set {_addedBy = value;}
		}

		public int PollId
		{
			get {return _pollId;}
			set {_pollId = value;}
		}

		public string OptionText
		{
			get {return _optionText;}
			set {_optionText = value;}
		}

		public int Votes
		{
			get {return _votes;}
			set {_votes = value;}
		}

		public double Percentage
		{
			get {return _percentage;}
			set {_percentage = value;}
		}
		#endregion
		
		private static List<PollOptionsBF> GetPollOptionsBFListFromPollOptionsList(List<PollOption> recordset)
        {
            List<PollOptionsBF> ret = new List<PollOptionsBF>();
            foreach (PollOption record in recordset)
                ret.Add(GetPollOptionsBFFromPollOption(record));
            return ret;
        }
		
		private static PollOptionsBF GetPollOptionsBFFromPollOption(PollOption record)
      	{
        	if (record == null)
            	return null;
         	else
         	{
            	return new PollOptionsBF(record.PollOptionID, record.AddedDate, record.AddedBy, record.PollId, record.OptionText, record.Votes, record.Percentage);
         	}
      	}
		
		public PollOptionsBF()
		{
		}


		public PollOptionsBF(int pollOptionID, DateTime addedDate, string addedBy, int pollId, string optionText, int votes, double percentage)
		{
			_pollOptionID = pollOptionID;
			_addedDate = addedDate;
			_addedBy = addedBy;
			_pollId = pollId;
			_optionText = optionText;
			_votes = votes;
			_percentage = percentage;
		}
		
		public static PollOptionsBF  GetPollOptionsBF(int pollOptionID)
		{
			return GetPollOptionsBFFromPollOption(SiteProvider.PollOptionsProvider.GetPollOption(pollOptionID));
		}
		
		//Get by ForeignKey
		public static  List<PollOptionsBF> GetPollOptionsByPollId(int pollId)
		{
			return GetPollOptionsBFListFromPollOptionsList(SiteProvider.PollOptionsProvider.GetPollOptionsByPollId(pollId));
		} 
		
		//Get All
		public static List<PollOptionsBF> GetPollOptionsAll()
		{
			return GetPollOptionsBFListFromPollOptionsList(SiteProvider.PollOptionsProvider.GetPollOptionsAll());
		}
		
		//Insert
		public int Insert()
		{
			return PollOptionsBF.Insert(this.PollOptionID, this.AddedDate, this.AddedBy, this.PollId, this.OptionText, this.Votes, this.Percentage);
		}
		
		//Update
		public bool Update()
		{
			return PollOptionsBF.Update(this.PollOptionID, this.AddedDate, this.AddedBy, this.PollId, this.OptionText, this.Votes, this.Percentage);
		}
		
		//Delete
		public bool Delete()
		{
			return PollOptionsBF.Delete(this.PollOptionID);
		}			
		
		//Insert
		public static int Insert(int pollOptionID, DateTime addedDate, string addedBy, int pollId, string optionText, int votes, double percentage)
		{
			return SiteProvider.PollOptionsProvider.Insert(new PollOption(pollOptionID, addedDate, addedBy, pollId, optionText, votes, percentage));
		}
		
		//Update
		public static bool Update(int pollOptionID, DateTime addedDate, string addedBy, int pollId, string optionText, int votes, double percentage)
		{
			return SiteProvider.PollOptionsProvider.Update(new PollOption(pollOptionID, addedDate, addedBy, pollId, optionText, votes, percentage));
		}
		
		//Delete
		public static bool Delete(int pollOptionID)
		{
			return SiteProvider.PollOptionsProvider.Delete(pollOptionID);
		}			

	}

}
