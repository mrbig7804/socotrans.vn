using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class City
    {
        public int CityID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Important { get; set; }
        public bool IsMain { get; set; }

        public City()
        {
        }

        public City(int cityID, int parentID, string name, string description, int important, bool isMain)
        {
            this.CityID = cityID;
            this.ParentID = parentID;
            this.Name = name;
            this.Description = description;
            this.Important = important;
            this.IsMain = isMain;
        }
    }
}
