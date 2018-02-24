using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class PriceDistance
    {
        public int PriceID { get; set; }
        public string Title { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int Important { get; set; }
        public bool AllowSearcch { get; set; }

        public PriceDistance()
        {
        }

        public PriceDistance(int priceID, string title, int priceFrom, int priceTo, int important, bool allowSearcch)
        {
            this.PriceID = priceID;
            this.Title = title;
            this.PriceFrom = priceFrom;
            this.PriceTo = priceTo;
            this.Important = important;
            this.AllowSearcch = allowSearcch;
        }
    }
}
