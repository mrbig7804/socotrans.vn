using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class ProductSpecial
    {
        public int ProductID { get; set; }
        public int SpecialID { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public bool Listed { get; set; }

        public ProductSpecial()
        {
        }

        public ProductSpecial(int productID, int specialID, DateTime releaseDate, DateTime expireDate, bool listed)
        {
            this.ProductID = productID;
            this.SpecialID = specialID;
            this.ReleaseDate = releaseDate;
            this.ExpireDate = expireDate;
            this.Listed = listed;
        }
    }
}
