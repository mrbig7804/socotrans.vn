using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class AlbumBF
    {
        #region Public Properties
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Listed { get; set; }
        public string PictureUrl { get; set; }
        #endregion

        public AlbumBF()
        {
        }

        public AlbumBF(int albumId, string title, string description, DateTime addedDate, bool listed, string pictureUrl)
        {
            this.AlbumId = albumId;
            this.Title = title;
            this.Description = description;
            this.AddedDate = addedDate;
            this.Listed = listed;
            this.PictureUrl = pictureUrl;
        }

        private static AlbumBF GetAlbumBFFromAlbum(Album record)
        {
            if (record == null)
                return null;
            else
            {
                return new AlbumBF(record.AlbumId, record.Title, record.Description, record.AddedDate, record.Listed, record.PictureUrl);
            }
        }

        private static List<AlbumBF> GetAlbumBFListFromAlbumList(List<Album> recordset)
        {
            List<AlbumBF> ret = new List<AlbumBF>();
            foreach (Album record in recordset)
                ret.Add(GetAlbumBFFromAlbum(record));
            return ret;
        }

        public static AlbumBF GetAlbumBF(int albumId)
        {
            return GetAlbumBFFromAlbum(SiteProvider.AlbumProvider.GetAlbum(albumId));
        }

        //Get All
        public static List<AlbumBF> GetAlbumAll()
        {
            return GetAlbumBFListFromAlbumList(SiteProvider.AlbumProvider.GetAlbumAll());
        }

        //Get By Listed
        public static List<AlbumBF> GetAlbumByListed(bool listed)
        {
            return GetAlbumBFListFromAlbumList(SiteProvider.AlbumProvider.GetAlbumByListed(listed));
        }

        //Get Dynamic
        public static List<AlbumBF> GetAlbumByListed(string whereCondition, string orderByExpression)
        {
            return GetAlbumBFListFromAlbumList(SiteProvider.AlbumProvider.GetAlbumDynamic(whereCondition, orderByExpression));
        }

        //Insert
        public int Insert()
        {
            return AlbumBF.Insert(this.AlbumId, this.Title, this.Description, this.AddedDate, this.Listed, this.PictureUrl);
        }

        //Update
        public bool Update()
        {
            return AlbumBF.Update(this.AlbumId, this.Title, this.Description, this.AddedDate, this.Listed, this.PictureUrl);
        }

        //Delete
        public bool Delete()
        {
            return AlbumBF.Delete(this.AlbumId);
        }

        //Insert
        public static int Insert(int albumId, string title, string description, DateTime addedDate, bool listed, string pictureUrl)
        {
            return SiteProvider.AlbumProvider.Insert(new Album(albumId, title, description, addedDate, listed, pictureUrl));
        }

        //Update
        public static bool Update(int albumId, string title, string description, DateTime addedDate, bool listed, string pictureUrl)
        {
            return SiteProvider.AlbumProvider.Update(new Album(albumId, title, description, addedDate, listed, pictureUrl));
        }

        //Delete
        public static bool Delete(int albumId)
        {
            var albImage = AlbumImageBF.GetAlbumImageByAlbumID(albumId);

            foreach( AlbumImageBF item in albImage )
            {
                item.Delete();
            }

            return SiteProvider.AlbumProvider.Delete(albumId);
        }

    }
}
