using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class CitiesBF
    {
        public void IncreaseImportance()
        {
            List<CitiesBF> cities = CitiesBF.GetCitiesByParentID(this.ParentID);

            int index = 0;

            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].CityID == this.CityID & (i > 0))
                {
                    index = i;
                }

                cities[i].Important = i;
                cities[i].Update();
            }

            if (index > 0)
            {
                cities[index].Important = index - 1;
                cities[index - 1].Important = index;
                cities[index].Update();
                cities[index - 1].Update();
            }
        }

        public void ReducedImportance()
        {
            List<CitiesBF> cities = CitiesBF.GetCitiesByParentID(this.ParentID);

            int index = cities.Count - 1;

            for (int i = 0; i < cities.Count; i++)
            {
                if (cities[i].CityID == this.CityID)
                {
                    index = i;
                }

                cities[i].Important = i;
                cities[i].Update();
            }

            if ((index != cities.Count - 1) & cities.Count > 0)
            {
                cities[index].Important = index + 1;
                cities[index + 1].Important = index;
                cities[index].Update();
                cities[index + 1].Update();
            }
        }
    }
}
