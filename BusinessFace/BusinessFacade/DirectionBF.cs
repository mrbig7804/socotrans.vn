using System;
using System.Collections.Generic;
using System.Text;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class DirectionBF
    {
        #region Public Properties
        public int DirectionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Important { get; set; }
        #endregion

        public DirectionBF()
        {
        }

        public DirectionBF(int directionID, string title, string description, int important)
        {
            this.DirectionID = directionID;
            this.Title = title;
            this.Description = description;
            this.Important = important;
        }

        private static DirectionBF GetDirectionBFFromDirection(Direction record)
        {
            if (record == null)
                return null;
            else
            {
                return new DirectionBF(record.DirectionID, record.Title, record.Description, record.Important);
            }
        }

        private static List<DirectionBF> GetDirectionBFListFromDirectionList(List<Direction> recordset)
        {
            List<DirectionBF> ret = new List<DirectionBF>();
            foreach (Direction record in recordset)
                ret.Add(GetDirectionBFFromDirection(record));
            return ret;
        }

        public static DirectionBF GetDirectionBF(int directionID)
        {
            return GetDirectionBFFromDirection(SiteProvider.DirectionProvider.GetDirection(directionID));
        }

        //Get All
        public static List<DirectionBF> GetDirectionAll()
        {
            return GetDirectionBFListFromDirectionList(SiteProvider.DirectionProvider.GetDirectionAll());
        }

        //Insert
        public int Insert()
        {
            return DirectionBF.Insert(this.DirectionID, this.Title, this.Description, this.Important);
        }

        //Update
        public bool Update()
        {
            return DirectionBF.Update(this.DirectionID, this.Title, this.Description, this.Important);
        }

        //Delete
        public bool Delete()
        {
            return DirectionBF.Delete(
            this.DirectionID);
        }

        //Insert
        public static int Insert(int directionID, string title, string description, int important)
        {
            return SiteProvider.DirectionProvider.Insert(new Direction(directionID, title, description, important));
        }

        //Update
        public static bool Update(int directionID, string title, string description, int important)
        {
            return SiteProvider.DirectionProvider.Update(new Direction(directionID, title, description, important));
        }

        //Delete
        public static bool Delete(int directionID)
        {
            return SiteProvider.DirectionProvider.Delete(directionID);
        }

    }
}
