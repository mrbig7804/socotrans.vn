using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public class PriceDistanceBF
    {
        #region Public Properties
        public int PriceID { get; set; }
        public string Title { get; set; }
        public int PriceFrom { get; set; }
        public int PriceTo { get; set; }
        public int Important { get; set; }
        public bool AllowSearcch { get; set; }
        #endregion

        public PriceDistanceBF()
        {
        }

        public PriceDistanceBF(int priceID, string title, int priceFrom, int priceTo, int important, bool allowSearcch)
        {
            this.PriceID = priceID;
            this.Title = title;
            this.PriceFrom = priceFrom;
            this.PriceTo = priceTo;
            this.Important = important;
            this.AllowSearcch = allowSearcch;
        }

        private static PriceDistanceBF GetPriceDistanceBFFromPriceDistance(PriceDistance record)
        {
            if (record == null)
                return null;
            else
            {
                return new PriceDistanceBF(record.PriceID, record.Title, record.PriceFrom, record.PriceTo, record.Important, record.AllowSearcch);
            }
        }

        private static List<PriceDistanceBF> GetPriceDistanceBFListFromPriceDistanceList(List<PriceDistance> recordset)
        {
            List<PriceDistanceBF> ret = new List<PriceDistanceBF>();
            foreach (PriceDistance record in recordset)
                ret.Add(GetPriceDistanceBFFromPriceDistance(record));
            return ret;
        }

        public static PriceDistanceBF GetPriceDistanceBF(int priceID)
        {
            return GetPriceDistanceBFFromPriceDistance(SiteProvider.PriceDistanceProvider.GetPriceDistance(priceID));
        }

        //Get All
        public static List<PriceDistanceBF> GetPriceDistanceAll()
        {
            return GetPriceDistanceBFListFromPriceDistanceList(SiteProvider.PriceDistanceProvider.GetPriceDistanceAll());
        }

        //Get All
        public static List<PriceDistanceBF> GetPriceDistanceByDepartment(int departmentID)
        {
            return GetPriceDistanceBFListFromPriceDistanceList(SiteProvider.PriceDistanceProvider.GetPriceDistanceByDepartment(departmentID));
        }

        //Get All
        public static List<PriceDistanceBF> GetPriceDistanceDynamic(string condition, string orderBy)
        {
            return GetPriceDistanceBFListFromPriceDistanceList(SiteProvider.PriceDistanceProvider.GetPriceDistanceDynamic(condition, orderBy));
        }

        //Insert
        public int Insert()
        {
            return PriceDistanceBF.Insert(this.PriceID, this.Title, this.PriceFrom, this.PriceTo, this.Important, this.AllowSearcch);
        }

        //Update
        public bool Update()
        {
            return PriceDistanceBF.Update(this.PriceID, this.Title, this.PriceFrom, this.PriceTo, this.Important, this.AllowSearcch);
        }

        //Delete
        public bool Delete()
        {
            return PriceDistanceBF.Delete(
            this.PriceID);
        }

        //Insert
        public static int Insert(int priceID, string title, int priceFrom, int priceTo, int important, bool allowSearcch)
        {
            return SiteProvider.PriceDistanceProvider.Insert(new PriceDistance(priceID, title, priceFrom, priceTo, important, allowSearcch));
        }

        //Update
        public static bool Update(int priceID, string title, int priceFrom, int priceTo, int important, bool allowSearcch)
        {
            return SiteProvider.PriceDistanceProvider.Update(new PriceDistance(priceID, title, priceFrom, priceTo, important, allowSearcch));
        }

        //Delete
        public static bool Delete(int priceID)
        {
            PriceDepartmentBF.DeleteByPrice(priceID);

            return SiteProvider.PriceDistanceProvider.Delete(priceID);
        }

    }
}
