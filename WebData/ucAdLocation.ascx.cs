using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Collections.Generic;

public partial class ucAdLocation : System.Web.UI.UserControl
{

    int _adLocation;
    public int AdLocation
    {
        get
        {
            return _adLocation;
        }
        set
        {
            _adLocation = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            List<AdLinksBF> ads = AdLinksBF.GetByLocationIDAndEffectiveTime(AdLocation);

            if (ads.Count == 0) return;

            Random r = new Random();

            AdLinksBF ad = ads[r.Next(ads.Count)];
            ucAdLink1.AdLinkID = ad.AdLinkID;
        }
    }
}
