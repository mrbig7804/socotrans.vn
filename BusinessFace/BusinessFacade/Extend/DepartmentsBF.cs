using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

using System.Web.Security;
using System.Security;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class DepartmentsBF
    {
        #region Custom Method

        public static List<DepartmentsBF> GetDepartmentsByUserName(string userName)
        {
            return GetDepartmentsBFListFromDepartmentsList(SiteProvider.DepartmentsProvider.GetDepartmentsByUserName(userName));
        }

        public static List<DepartmentsBF> GetDepartmentsByParentID(int parentId)
        {
            return GetDepartmentsBFListFromDepartmentsList(SiteProvider.DepartmentsProvider.GetDepartmentsByParentID(parentId));
        }

        public static List<DepartmentsBF> GetDepartmentsByParentIDAndSuperDepartmentID(int parentId, int superDepId)
        {
            return GetDepartmentsBFListFromDepartmentsList(SiteProvider.DepartmentsProvider.GetDepartmentsByParentIDAndSuperDepartmentID(parentId, superDepId));
        }

        public static List<DepartmentsBF> GetDepartmentsListedBySuperDepartmentID(int superDepartmentID)
        {
            return GetDepartmentsBFListFromDepartmentsList(SiteProvider.DepartmentsProvider.GetDepartmentsListedBySuperDepartmentID(superDepartmentID));
        }

        public void IncreaseImportance()
        {
            List<DepartmentsBF> departments;
            if (this.ParentID != 0)
                departments = DepartmentsBF.GetDepartmentsByParentID(this.ParentID);
            else
                departments = DepartmentsBF.GetDepartmentsBySuperDepartmentID(this.SuperDepartmentID);

            int index = 0;

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].DepartmentID == this.DepartmentID & (i > 0))
                {
                    index = i;
                }

                departments[i].Importance = i;
                departments[i].Update();
            }

            if (index > 0)
            {
                departments[index].Importance = index - 1;
                departments[index - 1].Importance = index;
                departments[index].Update();
                departments[index - 1].Update();
            }
        }

        public void ReducedImportance()
        {
            List<DepartmentsBF> departments;

            if (this.ParentID != 0)
                departments = DepartmentsBF.GetDepartmentsByParentID(this.ParentID);
            else
                departments = DepartmentsBF.GetDepartmentsBySuperDepartmentID(this.SuperDepartmentID);

            int index = departments.Count - 1;

            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].DepartmentID == this.DepartmentID)
                {
                    index = i;
                }

                departments[i].Importance = i;
                departments[i].Update();
            }

            if ((index != departments.Count - 1) & departments.Count > 0)
            {
                departments[index].Importance = index + 1;
                departments[index + 1].Importance = index;
                departments[index].Update();
                departments[index + 1].Update();
            }
        }
        #endregion
    }
}
