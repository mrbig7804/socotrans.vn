using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Brand
    {
        public int BrandID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Important { get; set; }
        public string ImageUrl { get; set; }

        public Brand()
        {
        }

        public Brand(int brandID, string title, string description, int important, string imageUrl)
        {
            this.BrandID = brandID;
            this.Title = title;
            this.Description = description;
            this.Important = important;
            this.ImageUrl = imageUrl;
        }
    }
}
