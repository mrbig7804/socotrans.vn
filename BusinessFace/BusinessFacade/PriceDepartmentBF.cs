using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class PriceDepartmentBF
    {
        #region Public Properties
        public int PriceID { get; set; }
        public int DepartmentID { get; set; }
        #endregion

        public PriceDepartmentBF()
        {
        }

        public PriceDepartmentBF(int priceID, int departmentID)
        {
            this.PriceID = priceID;
            this.DepartmentID = departmentID;
        }

        private static PriceDepartmentBF GetPriceDepartmentBFFromPriceDepartment(PriceDepartment record)
        {
            if (record == null)
                return null;
            else
            {
                return new PriceDepartmentBF(record.PriceID, record.DepartmentID);
            }
        }

        private static List<PriceDepartmentBF> GetPriceDepartmentBFListFromPriceDepartmentList(List<PriceDepartment> recordset)
        {
            List<PriceDepartmentBF> ret = new List<PriceDepartmentBF>();
            foreach (PriceDepartment record in recordset)
                ret.Add(GetPriceDepartmentBFFromPriceDepartment(record));
            return ret;
        }

        public static PriceDepartmentBF GetPriceDepartmentBF(int priceID, int departmentID)
        {
            return GetPriceDepartmentBFFromPriceDepartment(SiteProvider.PriceDepartmentProvider.GetPriceDepartment(priceID, departmentID));
        }
        
        //Insert
        public bool Insert()
        {
            return PriceDepartmentBF.Insert(this.PriceID, this.DepartmentID);
        }


        //Delete
        public bool Delete()
        {
            return PriceDepartmentBF.Delete(this.PriceID, this.DepartmentID);
        }

        public bool DeleteByPrice()
        {
            return PriceDepartmentBF.DeleteByPrice(this.PriceID);
        }

        public bool DeleteByDepartment()
        {
            return PriceDepartmentBF.DeleteByDepartment(this.DepartmentID);
        }

        //Insert
        public static bool Insert(int priceID, int departmentID)
        {
            return SiteProvider.PriceDepartmentProvider.Insert(new PriceDepartment(priceID, departmentID));
        }

        //Delete
        public static bool Delete(int priceID, int departmentID)
        {
            return SiteProvider.PriceDepartmentProvider.Delete(priceID, departmentID);
        }

        public static bool DeleteByPrice(int priceID)
        {
            return SiteProvider.PriceDepartmentProvider.DeleteByPrice(priceID);
        }

        public static bool DeleteByDepartment(int departmentID)
        {
            return SiteProvider.PriceDepartmentProvider.DeleteByDepartment(departmentID);
        }

    }
}
