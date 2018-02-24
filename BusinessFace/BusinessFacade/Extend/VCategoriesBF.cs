using System;
using System.Collections.Generic;
using System.Text;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    public partial class VCategoriesBF
    {
        public void IncreaseImportance()
        {
            List<VCategoriesBF> cVideos = VCategoriesBF.GetVCategoriesByParentID(this.ParentID);

            int index = 0;

            for (int i = 0; i < cVideos.Count; i++)
            {
                if (cVideos[i].CategoryID == this.CategoryID & (i > 0))
                {
                    index = i;
                }

                cVideos[i].Important = i;
                cVideos[i].Update();
            }

            if (index > 0)
            {
                cVideos[index].Important = index - 1;
                cVideos[index - 1].Important = index;
                cVideos[index].Update();
                cVideos[index - 1].Update();
            }
        }

        public void ReducedImportance()
        {
            List<VCategoriesBF> cVideos = VCategoriesBF.GetVCategoriesByParentID(this.ParentID);

            int index = cVideos.Count - 1;

            for (int i = 0; i < cVideos.Count; i++)
            {
                if (cVideos[i].CategoryID == this.CategoryID)
                {
                    index = i;
                }

                cVideos[i].Important = i;
                cVideos[i].Update();
            }

            if ((index != cVideos.Count - 1) & cVideos.Count > 0)
            {
                cVideos[index].Important = index + 1;
                cVideos[index + 1].Important = index;
                cVideos[index].Update();
                cVideos[index + 1].Update();
            }
        }
    }
}
