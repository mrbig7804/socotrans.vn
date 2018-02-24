using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Listed { get; set; }
        public string PictureUrl { get; set; }

        public Album()
        {
        }

        public Album(int albumId, string title, string description, DateTime addedDate, bool listed, string pictureUrl)
        {
            this.AlbumId = albumId;
            this.Title = title;
            this.Description = description;
            this.AddedDate = addedDate;
            this.Listed = listed;
            this.PictureUrl = pictureUrl;
        }
    }
}
