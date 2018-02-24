using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class BrandDepartmentsBF
    {
        #region Public Properties
        public int BrandID { get; set; }
        public int DepartmentID { get; set; }
        #endregion

        public BrandDepartmentsBF()
        {
        }

        public BrandDepartmentsBF(int brandID, int departmentID)
        {
            this.BrandID = brandID;
            this.DepartmentID = departmentID;
        }

        private static BrandDepartmentsBF GetBrandDepartmentsBFFromBrandDepartment(BrandDepartment record)
        {
            if (record == null)
                return null;
            else
            {
                return new BrandDepartmentsBF(record.BrandID, record.DepartmentID);
            }
        }

        private static List<BrandDepartmentsBF> GetBrandDepartmentsBFListFromBrandDepartmentsList(List<BrandDepartment> recordset)
        {
            List<BrandDepartmentsBF> ret = new List<BrandDepartmentsBF>();
            foreach (BrandDepartment record in recordset)
                ret.Add(GetBrandDepartmentsBFFromBrandDepartment(record));
            return ret;
        }

        public static BrandDepartmentsBF GetBrandDepartmentBF(int brandID, int departmentID)
        {
            return GetBrandDepartmentsBFFromBrandDepartment(SiteProvider.BrandDepartmentsProvider.GetBrandDepartment(brandID, departmentID));
        }

        //Insert
        public bool Insert()
        {
            return BrandDepartmentsBF.Insert(this.BrandID, this.DepartmentID);
        }

        //Delete
        public bool Delete()
        {
            return BrandDepartmentsBF.Delete(this.BrandID, this.DepartmentID);
        }

        public bool DeleteByBrand()
        {
            return BrandDepartmentsBF.DeleteByBrand(this.BrandID);
        }

        public bool DeleteByDepartment()
        {
            return BrandDepartmentsBF.DeleteByDepartment(this.DepartmentID);
        }

        //Insert
        public static bool Insert(int brandID, int departmentID)
        {
            return SiteProvider.BrandDepartmentsProvider.Insert(new BrandDepartment(brandID, departmentID));
        }

        //Delete
        public static bool Delete(int brandID, int departmentID)
        {
            return SiteProvider.BrandDepartmentsProvider.Delete(brandID, departmentID);
        }

        public static bool DeleteByBrand(int brandID)
        {
            return SiteProvider.BrandDepartmentsProvider.DeleteByBrand(brandID);
        }

        public static bool DeleteByDepartment(int departmentID)
        {
            return SiteProvider.BrandDepartmentsProvider.DeleteByDepartment(departmentID);
        }
    }
}
