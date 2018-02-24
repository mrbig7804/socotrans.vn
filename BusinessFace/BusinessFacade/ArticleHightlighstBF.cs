using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;
using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class ArticleHighlightsBF : BaseBF
    {

        protected int _articleHighlightID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        protected string _smallPictureUrl = String.Empty;
        protected string _pictureUrl = String.Empty;
        protected string _link = String.Empty;
        protected bool _isCurrent;
        protected bool _listed;

        #region Public Properties

        public int ArticleHighlightID
        {
            get { return _articleHighlightID; }
            set { _articleHighlightID = value; }
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

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string SmallPictureUrl
        {
            get { return _smallPictureUrl; }
            set { _smallPictureUrl = value; }
        }

        public string PictureUrl
        {
            get { return _pictureUrl; }
            set { _pictureUrl = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        public bool IsCurrent
        {
            get { return _isCurrent; }
            set { _isCurrent = value; }
        }

        public bool Listed
        {
            get { return _listed; }
            set { _listed = value; }
        }
        #endregion

        //Custom method-----------------------------------------------------------
        public static int CurrentID
        {
            get
            {
                int articlesHighlighID = -1;
                articlesHighlighID = SiteProvider.ArticleHighlightsProvider.GetCurrentID();

                return articlesHighlighID;
            }
        }

        public static ArticleHighlightsBF CurrentArticleHighlight
        {
            get
            {
                return GetArticleHighlightsBFFromArticleHighlight(SiteProvider.ArticleHighlightsProvider.GetArticleHighlight(CurrentID));
            }
        }
     

        public static int Insert(string title, string description, string smallPictureUrl, string pictureUrl, string link, bool isCurrent, bool listed)
        {
            return SiteProvider.ArticleHighlightsProvider.Insert(new ArticleHighlight(-1, DateTime.Now, CurrentUserName , title, description, smallPictureUrl, pictureUrl, link, isCurrent, listed));
        }

        //-----------------------------------------------------------
        private static List<ArticleHighlightsBF> GetArticleHighlightsBFListFromArticleHighlightsList(List<ArticleHighlight> recordset)
        {
            List<ArticleHighlightsBF> ret = new List<ArticleHighlightsBF>();
            foreach (ArticleHighlight record in recordset)
                ret.Add(GetArticleHighlightsBFFromArticleHighlight(record));
            return ret;
        }

        private static ArticleHighlightsBF GetArticleHighlightsBFFromArticleHighlight(ArticleHighlight record)
        {
            if (record == null)
                return null;
            else
            {
                return new ArticleHighlightsBF(record.ArticleHighlightID, record.AddedDate, record.AddedBy, record.Title, record.Description, record.SmallPictureUrl, record.PictureUrl, record.Link, record.IsCurrent, record.Listed);
            }
        }

        public ArticleHighlightsBF()
        {
        }


        public ArticleHighlightsBF(int articleHighlightID, DateTime addedDate, string addedBy, string title, string description, string smallPictureUrl, string pictureUrl, string link, bool isCurrent, bool listed)
        {
            _articleHighlightID = articleHighlightID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _description = description;
            _smallPictureUrl = smallPictureUrl;
            _pictureUrl = pictureUrl;
            _link = link;
            _isCurrent = isCurrent;
            _listed = listed;
        }

        public static ArticleHighlightsBF GetArticleHighlightsBF(int articleHighlightID)
        {
            return GetArticleHighlightsBFFromArticleHighlight(SiteProvider.ArticleHighlightsProvider.GetArticleHighlight(articleHighlightID));
        }

        //Get by ForeignKey

        //Get All
        public static List<ArticleHighlightsBF> GetArticleHighlightsAll()
        {
            return GetArticleHighlightsBFListFromArticleHighlightsList(SiteProvider.ArticleHighlightsProvider.GetArticleHighlightsAll());
        }

        public static List<ArticleHighlightsBF> GetArticleHighlightsListed()
        {
            List<ArticleHighlightsBF> ret = new List<ArticleHighlightsBF>();
            foreach (ArticleHighlight record in SiteProvider.ArticleHighlightsProvider.GetArticleHighlightsAll())
            {
                if(record.Listed)
                {
                    ret.Add(GetArticleHighlightsBFFromArticleHighlight(record));
                }
            }
            return ret;
        }

        //Insert
        public int Insert()
        {
            return ArticleHighlightsBF.Insert(this.ArticleHighlightID, this.AddedDate, this.AddedBy, this.Title, this.Description, this.SmallPictureUrl, this.PictureUrl, this.Link, this.IsCurrent, this.Listed);
        }

        //Update
        public bool Update()
        {
            return ArticleHighlightsBF.Update(this.ArticleHighlightID, this.AddedDate, this.AddedBy, this.Title, this.Description, this.SmallPictureUrl, this.PictureUrl, this.Link, this.IsCurrent, this.Listed);
        }

        //Delete
        public bool Delete()
        {
            return ArticleHighlightsBF.Delete(this.ArticleHighlightID);
        }

        //Insert
        public static int Insert(int articleHighlightID, DateTime addedDate, string addedBy, string title, string description, string smallPictureUrl, string pictureUrl, string link, bool isCurrent, bool listed)
        {
            return SiteProvider.ArticleHighlightsProvider.Insert(new ArticleHighlight(articleHighlightID, addedDate, addedBy, title, description, smallPictureUrl, pictureUrl, link, isCurrent, listed));
        }

        //Update
        public static bool Update(int articleHighlightID, DateTime addedDate, string addedBy, string title, string description, string smallPictureUrl, string pictureUrl, string link, bool isCurrent, bool listed)
        {
            return SiteProvider.ArticleHighlightsProvider.Update(new ArticleHighlight(articleHighlightID, addedDate, addedBy, title, description, smallPictureUrl, pictureUrl, link, isCurrent, listed));
        }

        //Delete
        public static bool Delete(int articleHighlightID)
        {
            ArticleHighlightsBF ah = ArticleHighlightsBF.GetArticleHighlightsBF(articleHighlightID);

            if (File.Exists(HttpContext.Current.Server.MapPath(ah.SmallPictureUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(ah.SmallPictureUrl));
            if (File.Exists(HttpContext.Current.Server.MapPath(ah.PictureUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(ah.PictureUrl));

            return SiteProvider.ArticleHighlightsProvider.Delete(articleHighlightID);


        }

    }

}
