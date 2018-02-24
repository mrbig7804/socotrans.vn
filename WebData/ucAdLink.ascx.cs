using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Security;

public partial class ucAdLink : System.Web.UI.UserControl
{

    public int AdLinkID
    {
        //get;
        set
        {
            var adLink = AdLinksBF.GetAdLinksBF(value);

            if (adLink == null) return;

            // nếu chỉ hiển thị những quảng cáo còn khả dụng thì sẽ không hiển thị những quảng cáo đã quá hạn
            if (ShowAvailableAdOnly && (adLink.RegionDate > DateTime.Now || adLink.ExpireDate < DateTime.Now)) return;

            if (adLink.IsCode)
            {
                txtAd.Text = adLink.Code;
            }
            else
            {
                txtAd.Text = "<a title=\"" + adLink.Title + "\" href=\"/adclick.aspx?id=" + adLink.AdLinkID.ToString() + "\"><img alt=\"" + adLink.Title + "\" src=\"" + adLink.Image + "\"></a>";
            }

            lnkEdit.Visible = Permissions.IsAdministrator(this.Page.User.Identity.Name) && Request.Url.AbsolutePath.ToLower() != "/adm/manageadlinks.aspx";
            lnkEdit.NavigateUrl = "~/adm/ManageAdlinks.aspx?adID=" + adLink.AdLinkID.ToString();

        }
    }

    public bool ShowAvailableAdOnly
    {
        get;
        set;
    }

    protected void Page_Load(object sender, EventArgs e)
    {


    }

}
