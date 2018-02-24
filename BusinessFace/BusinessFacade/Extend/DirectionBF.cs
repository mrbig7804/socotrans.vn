using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class DirectionBF
    {
        public void IncreaseImportance()
        {
            List<DirectionBF> directions = DirectionBF.GetDirectionAll();

            int index = 0;

            for (int i = 0; i < directions.Count; i++)
            {
                if (directions[i].DirectionID == this.DirectionID & (i > 0))
                {
                    index = i;
                }

                directions[i].Important = i;
                directions[i].Update();
            }

            if (index > 0)
            {
                directions[index].Important = index - 1;
                directions[index - 1].Important = index;
                directions[index].Update();
                directions[index - 1].Update();
            }
        }

        public void ReducedImportance()
        {
            List<DirectionBF> directions = DirectionBF.GetDirectionAll();

            int index = directions.Count - 1;

            for (int i = 0; i < directions.Count; i++)
            {
                if (directions[i].DirectionID == this.DirectionID)
                {
                    index = i;
                }

                directions[i].Important = i;
                directions[i].Update();
            }

            if ((index != directions.Count - 1) & directions.Count > 0)
            {
                directions[index].Important = index + 1;
                directions[index + 1].Important = index;
                directions[index].Update();
                directions[index + 1].Update();
            }
        }
    }
}
