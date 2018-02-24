using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
using System.IO;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class AlbumImageBF
    {
        #region Public Properties
        public int ImageId { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public string PreviewUrl { get; set; }
        public string MainUrl { get; set; }
        public bool IsMain { get; set; }
        #endregion

        public AlbumImageBF()
        {
        }

        public AlbumImageBF(int imageId, int albumId, string title, string description, DateTime addedDate, string previewUrl, string mainUrl, bool isMain)
        {
            this.ImageId = imageId;
            this.AlbumId = albumId;
            this.Title = title;
            this.Description = description;
            this.AddedDate = addedDate;
            this.PreviewUrl = previewUrl;
            this.MainUrl = mainUrl;
            this.IsMain = isMain;
        }

        private static AlbumImageBF GetAlbumImageBFFromAlbumImage(AlbumImage record)
        {
            if (record == null)
                return null;
            else
            {
                return new AlbumImageBF(record.ImageId, record.AlbumId, record.Title, record.Description, record.AddedDate, record.PreviewUrl, record.MainUrl, record.IsMain);
            }
        }

        private static List<AlbumImageBF> GetAlbumImageBFListFromAlbumImageList(List<AlbumImage> recordset)
        {
            List<AlbumImageBF> ret = new List<AlbumImageBF>();
            foreach (AlbumImage record in recordset)
                ret.Add(GetAlbumImageBFFromAlbumImage(record));
            return ret;
        }

        public static AlbumImageBF GetAlbumImageBF(int imageId)
        {
            return GetAlbumImageBFFromAlbumImage(SiteProvider.AlbumImageProvider.GetAlbumImage(imageId));
        }

        //Get by albumID
        public static List<AlbumImageBF> GetAlbumImageByAlbumID(int albumID)
        {
            return GetAlbumImageBFListFromAlbumImageList(SiteProvider.AlbumImageProvider.GetAlbumImageByAlbumID(albumID));
        }

        //Get by dynamic
        public static List<AlbumImageBF> GetAlbumImageDynamic(string whereCondition, string orderByExpression)
        {
            return GetAlbumImageBFListFromAlbumImageList(SiteProvider.AlbumImageProvider.GetAlbumImageDynamic(whereCondition, orderByExpression));
        }

        //Insert
        public int Insert()
        {
            return AlbumImageBF.Insert(this.ImageId, this.AlbumId, this.Title, this.Description, this.AddedDate, this.PreviewUrl, this.MainUrl, this.IsMain);
        }

        //Update
        public bool Update()
        {
            return AlbumImageBF.Update(this.ImageId, this.AlbumId, this.Title, this.Description, this.AddedDate, this.PreviewUrl, this.MainUrl, this.IsMain);
        }

        //Delete
        public bool Delete()
        {
            return AlbumImageBF.Delete(
            this.ImageId);
        }

        //Insert
        public static int Insert(int imageId, int albumId, string title, string description, DateTime addedDate, string previewUrl, string mainUrl, bool isMain)
        {
            return SiteProvider.AlbumImageProvider.Insert(new AlbumImage(imageId, albumId, title, description, addedDate, previewUrl, mainUrl, isMain));
        }

        //Update
        public static bool Update(int imageId, int albumId, string title, string description, DateTime addedDate, string previewUrl, string mainUrl, bool isMain)
        {
            return SiteProvider.AlbumImageProvider.Update(new AlbumImage(imageId, albumId, title, description, addedDate, previewUrl, mainUrl, isMain));
        }

        //Delete
        public static bool Delete(int imageId)
        {
            AlbumImageBF albImage = AlbumImageBF.GetAlbumImageBF(imageId);

            if (File.Exists(HttpContext.Current.Server.MapPath(albImage.PreviewUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(albImage.PreviewUrl));
            if (File.Exists(HttpContext.Current.Server.MapPath(albImage.MainUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(albImage.MainUrl));

            return SiteProvider.AlbumImageProvider.Delete(imageId);
        }

    }
}
