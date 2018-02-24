using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class AlbumImage
    {
        public int ImageId { get; set; }
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public string PreviewUrl { get; set; }
        public string MainUrl { get; set; }
        public bool IsMain { get; set; }

        public AlbumImage()
        {
        }

        public AlbumImage(int imageId, int albumId, string title, string description, DateTime addedDate, string previewUrl, string mainUrl, bool isMain)
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
    }
}
