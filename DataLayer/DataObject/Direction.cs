using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.DataLayer.DataObject
{
    [Serializable]
    public class Direction
    {
        public int DirectionID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Important { get; set; }

        public Direction()
        {
        }

        public Direction(int directionID, string title, string description, int important)
        {
            this.DirectionID = directionID;
            this.Title = title;
            this.Description = description;
            this.Important = important;
        }
    }
}
