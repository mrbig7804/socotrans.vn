using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Zensoft.Website.DataLayer.DataObject
{
	[Serializable]
	public class Article
	{
		protected int _articleID;
		protected DateTime _addedDate;
		protected string _addedBy = String.Empty;
		protected int _categoryID;
		protected string _title = String.Empty;
		protected string _abstract = String.Empty;
		protected string _body = String.Empty;
		protected DateTime _releaseDate;
		protected DateTime _expireDate;
		protected bool _approved;
		protected bool _listed;
		protected bool _commentsEnabled;
		protected bool _onlyForMembers;
		protected int _viewCount;
		protected int _votes;
		protected int _totalRating;
		protected string _pictureUrl = String.Empty;
		
		public Article()
		{
		}

        public Article(int articleID, DateTime addedDate, string addedBy, int categoryID, string title, string articleAbstract, string body, DateTime releaseDate, DateTime expireDate, bool approved, bool listed, bool commentsEnabled, bool onlyForMembers, int viewCount, int votes, int totalRating, string pictureUrl)
		{
			_articleID = articleID;
			_addedDate = addedDate;
			_addedBy = addedBy;
			_categoryID = categoryID;
			_title = title;
			_abstract = articleAbstract;
			_body = body;
			_releaseDate = releaseDate;
			_expireDate = expireDate;
			_approved = approved;
			_listed = listed;
			_commentsEnabled = commentsEnabled;
			_onlyForMembers = onlyForMembers;
			_viewCount = viewCount;
			_votes = votes;
			_totalRating = totalRating;
			_pictureUrl = pictureUrl;
		}
		
		#region Public Properties
		
		public int ArticleID
		{
			get {return _articleID;}
			set {_articleID = value;}
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

		public int CategoryID
		{
			get {return _categoryID;}
			set {_categoryID = value;}
		}

		public string Title
		{
			get {return _title;}
			set {_title = value;}
		}

		public string Abstract
		{
			get {return _abstract;}
			set {_abstract = value;}
		}

		public string Body
		{
			get {return _body;}
			set {_body = value;}
		}

		public DateTime ReleaseDate
		{
			get {return _releaseDate;}
			set {_releaseDate = value;}
		}

		public DateTime ExpireDate
		{
			get {return _expireDate;}
			set {_expireDate = value;}
		}

		public bool Approved
		{
			get {return _approved;}
			set {_approved = value;}
		}

		public bool Listed
		{
			get {return _listed;}
			set {_listed = value;}
		}

		public bool CommentsEnabled
		{
			get {return _commentsEnabled;}
			set {_commentsEnabled = value;}
		}

		public bool OnlyForMembers
		{
			get {return _onlyForMembers;}
			set {_onlyForMembers = value;}
		}

		public int ViewCount
		{
			get {return _viewCount;}
			set {_viewCount = value;}
		}

		public int Votes
		{
			get {return _votes;}
			set {_votes = value;}
		}

		public int TotalRating
		{
			get {return _totalRating;}
			set {_totalRating = value;}
		}

		public string PictureUrl
		{
			get {return _pictureUrl;}
			set {_pictureUrl = value;}
		}
		#endregion
	}


}
