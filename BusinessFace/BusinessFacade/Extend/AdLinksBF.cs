using System;
using System.Collections.Generic;
using System.Text;

using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;

namespace Zensoft.Website.BusinessLayer.BusinessFacade
{
    /// <summary>
    /// NgocDV - 26-10-2007 - Thêm hàm GetAdLinksByLocationAndEffectiveTime
    /// sondt = 30/10/2007 - Thêm hàm IncreaseClick (tang so lượt click vào quảng cáo)
    /// </summary>
    public partial class AdLinksBF
    {

        public bool IncreaseClick()
        {
            return IncreaseClick(this.AdLinkID);
        }

        public static bool IncreaseClick(int adlinkID)
        {
            return SiteProvider.AdLinksProvider.IncreaseClick(adlinkID);
        }

        /// <summary>
        /// Lấy tất cả Adlink trong thời gian còn hiệu lực và đặt chúng theo vùng nhất định.
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public static List<AdLinksBF> GetByLocationIDAndEffectiveTime(int location)
        {
            return GetAdLinksBFListFromAdLinksList(SiteProvider.AdLinksProvider.GetByLocationIDAndEffectiveTime(location));
        }

    }
}
