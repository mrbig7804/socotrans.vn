using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
using System.IO;
using System.Web;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    [Serializable]
    public class CategoriesBF : BaseBF
    {
        protected int _categoryID;
        protected DateTime _addedDate;
        protected string _addedBy = String.Empty;
        protected string _title = String.Empty;
        protected int _importance;
        protected string _description = String.Empty;
        protected string _imageUrl = String.Empty;
        protected int _superCategoryID;
        protected int _parentCategoryID;

        #region Public Properties

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public DateTime AddedDate
        {
            get { return _addedDate; }
            set { _addedDate = value; }
        }

        public string AddedBy
        {
            get { return _addedBy; }
            set { _addedBy = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public int Importance
        {
            get { return _importance; }
            set { _importance = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public int SuperCategoryID
        {
            get { return _superCategoryID; }
            set { _superCategoryID = value; }
        }

        public int ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }

        SuperCategoriesBF _superCategory = null;
        public SuperCategoriesBF SuperCategory
        {
            get
            {
                if (_superCategory == null)
                    _superCategory = SuperCategoriesBF.GetSuperCategoriesBF(SuperCategoryID);
                return _superCategory;
            }
        }
        CategoriesBF _parentCategory = null;
        public CategoriesBF ParentCategory
        {
            get
            {
                if (_parentCategory == null)
                    _parentCategory = CategoriesBF.GetCategoriesBF(this.ParentCategoryID);
                return _parentCategory;
            }
        }

        public int ParentID
        {
            get
            {
                if (this.ParentCategoryID != 0)
                    return ParentCategory.ParentID;
                else return this.CategoryID;
            }
        }


        public string ParentCategoryTitle
        {
            get
            {
                if (this.ParentCategoryID != 0)
                    return ParentCategory.ParentCategoryTitle;
                else return this.Title;
            }
        }

        #endregion

        public CategoriesBF()
        {
        }

        public CategoriesBF(int categoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl, int superCategoryID, int parentCategoryID)
        {
            _categoryID = categoryID;
            _addedDate = addedDate;
            _addedBy = addedBy;
            _title = title;
            _importance = importance;
            _description = description;
            _imageUrl = imageUrl;
            _superCategoryID = superCategoryID;
            _parentCategoryID = parentCategoryID;
        }

        private static List<CategoriesBF> GetCategoriesBFListFromCategoriesList(List<Category> recordset)
        {
            List<CategoriesBF> ret = new List<CategoriesBF>();
            foreach (Category record in recordset)
                ret.Add(GetCategoriesBFFromCategory(record));
            return ret;
        }

        private static CategoriesBF GetCategoriesBFFromCategory(Category record)
        {
            if (record == null)
                return null;
            else
            {
                return new CategoriesBF(record.CategoryID, record.AddedDate, record.AddedBy, record.Title, record.Importance, record.Description, record.ImageUrl, record.SuperCategoryID, record.ParentCategoryID);
            }
        }

        public static CategoriesBF GetCategoriesBF(int categoryID)
        {
            return GetCategoriesBFFromCategory(SiteProvider.CategoriesProvider.GetCategory(categoryID));
        }

        //Get by ForeignKey
        public static List<CategoriesBF> GetCategoriesBySuperCategoryID(int superCategoryID)
        {
            return GetCategoriesBFListFromCategoriesList(SiteProvider.CategoriesProvider.GetCategoriesBySuperCategoryID(superCategoryID));
        }

        //Get All
        public static List<CategoriesBF> GetCategoriesAll()
        {
            return GetCategoriesBFListFromCategoriesList(SiteProvider.CategoriesProvider.GetCategoriesAll());
        }

        #region Custom Method

        public static List<CategoriesBF> GetCategoriesBySuperCategoryIDAndParent(int superCategoryID, int parentID)
        {
            return GetCategoriesBFListFromCategoriesList(SiteProvider.CategoriesProvider.GetCategoriesBySuperCategoryIDAndParent(superCategoryID, parentID));
        }

        public static List<CategoriesBF> GetCategoriesByParentCategoryID(int categoryID)
        {
            return GetCategoriesBFListFromCategoriesList(SiteProvider.CategoriesProvider.GetCategoriesByParentCategoryID(categoryID));
        }

        public void IncreaseImportance()
        {
            List<CategoriesBF> categories;

            if (this.ParentCategoryID != 0)
                categories = CategoriesBF.GetCategoriesByParentCategoryID(this.ParentCategoryID);
            else
                categories = CategoriesBF.GetCategoriesBySuperCategoryIDAndParent(this.SuperCategoryID, 0);

            int index = 0;

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].CategoryID == this.CategoryID & (i > 0))
                {
                    index = i;
                }

                categories[i].Importance = i;
                categories[i].Update();
            }

            if (index > 0)
            {
                categories[index].Importance = index - 1;
                categories[index - 1].Importance = index;
                categories[index].Update();
                categories[index - 1].Update();
            }
        }

        public void ReducedImportance()
        {
            List<CategoriesBF> categories;

            if (this.ParentID != 0)
                categories = CategoriesBF.GetCategoriesByParentCategoryID(this.ParentCategoryID);
            else
                categories = CategoriesBF.GetCategoriesBySuperCategoryIDAndParent(this.SuperCategoryID, 0);

            int index = categories.Count - 1;

            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].CategoryID == this.CategoryID)
                {
                    index = i;
                }

                categories[i].Importance = i;
                categories[i].Update();
            }

            if ((index != categories.Count - 1) & categories.Count > 0)
            {
                categories[index].Importance = index + 1;
                categories[index + 1].Importance = index;
                categories[index].Update();
                categories[index + 1].Update();
            }
        }

        //Insert với các giá trị mặc định
        public static int Insert(string title, int importance, string description, string imageUrl, int superCategoryID, int parentCategoryID)
        {
            return SiteProvider.CategoriesProvider.Insert(
                new Category(-1,
                    DateTime.Now, // AddedDate
                    CurrentUserName, // AddedBy
                    title, importance, description, imageUrl, superCategoryID, parentCategoryID));
        }

        //Update với các giá trị mặc định
        public static bool Update(int categoryID, string title, int importance, string description, string imageUrl, int superCategoryID, int parentCategoryID)
        {
            Category c = SiteProvider.CategoriesProvider.GetCategory(categoryID);
            c.Description = description;
            c.ImageUrl = imageUrl;
            c.Title = title;
            c.Importance = importance;
            c.SuperCategoryID = superCategoryID;
            c.ParentCategoryID = parentCategoryID;

            return SiteProvider.CategoriesProvider.Update(c);
        }
        #endregion

        //Insert
        public int Insert()
        {
            return CategoriesBF.Insert(this.CategoryID, this.AddedDate, this.AddedBy, this.Title, this.Importance, this.Description, this.ImageUrl, this.SuperCategoryID, this.ParentCategoryID);
        }

        //Update
        public bool Update()
        {
            return CategoriesBF.Update(this.CategoryID, this.AddedDate, this.AddedBy, this.Title, this.Importance, this.Description, this.ImageUrl, this.SuperCategoryID, this.ParentCategoryID);
        }

        //Delete
        public bool Delete()
        {
            return CategoriesBF.Delete(this.CategoryID);
        }

        //Insert
        public static int Insert(int categoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl, int superCategoryID, int parentCategoryID)
        {
            return SiteProvider.CategoriesProvider.Insert(new Category(categoryID, addedDate, addedBy, title, importance, description, imageUrl, superCategoryID, parentCategoryID));
        }

        //Update
        public static bool Update(int categoryID, DateTime addedDate, string addedBy, string title, int importance, string description, string imageUrl, int superCategoryID, int parentCategoryID)
        {
            return SiteProvider.CategoriesProvider.Update(new Category(categoryID, addedDate, addedBy, title, importance, description, imageUrl, superCategoryID, parentCategoryID));
        }

        //Delete
        public static bool Delete(int categoryID)
        {
            var cat = CategoriesBF.GetCategoriesBF(categoryID);

            if (File.Exists(HttpContext.Current.Server.MapPath(cat.ImageUrl)))
                File.Delete(HttpContext.Current.Server.MapPath(cat.ImageUrl));

            return SiteProvider.CategoriesProvider.Delete(categoryID);
        }

    }

}
