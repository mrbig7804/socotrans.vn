using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{

    public class SpecialsBF
    {

        protected int _specialID;
        protected string _title = String.Empty;
        protected string _description = String.Empty;

        #region Public Properties

        public int SpecialID
        {
            get { return _specialID; }
            set { _specialID = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        #endregion

        private static List<SpecialsBF> GetSpecialsBFListFromSpecialsList(List<Special> recordset)
        {
            List<SpecialsBF> ret = new List<SpecialsBF>();
            foreach (Special record in recordset)
                ret.Add(GetSpecialsBFFromSpecial(record));
            return ret;
        }

        private static SpecialsBF GetSpecialsBFFromSpecial(Special record)
        {
            if (record == null)
                return null;
            else
            {
                return new SpecialsBF(record.SpecialID, record.Title, record.Description);
            }
        }

        public SpecialsBF()
        {
        }


        public SpecialsBF(int specialID, string title, string description)
        {
            _specialID = specialID;
            _title = title;
            _description = description;
        }

        public static SpecialsBF GetSpecialsBF(int specialID)
        {
            return GetSpecialsBFFromSpecial(SiteProvider.SpecialsProvider.GetSpecial(specialID));
        }

        //Get by ForeignKey

        //Get All
        public static List<SpecialsBF> GetSpecialsAll()
        {
            return GetSpecialsBFListFromSpecialsList(SiteProvider.SpecialsProvider.GetSpecialsAll());
        }

        //Insert
        public int Insert()
        {
            return SpecialsBF.Insert(this.SpecialID, this.Title, this.Description);
        }

        //Update
        public bool Update()
        {
            return SpecialsBF.Update(this.SpecialID, this.Title, this.Description);
        }

        //Delete
        public bool Delete()
        {
            return SpecialsBF.Delete(this.SpecialID);
        }

        //Insert
        public static int Insert(int specialID, string title, string description)
        {
            return SiteProvider.SpecialsProvider.Insert(new Special(specialID, title, description));
        }

        //Update
        public static bool Update(int specialID, string title, string description)
        {
            return SiteProvider.SpecialsProvider.Update(new Special(specialID, title, description));
        }

        //Delete
        public static bool Delete(int specialID)
        {
            return SiteProvider.SpecialsProvider.Delete(specialID);
        }

    }

}
