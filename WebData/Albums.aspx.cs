using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class Albums : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void lvwAlbums_PreRender(object sender, EventArgs e)
    {
        DataPager1.Visible = (DataPager1.TotalRowCount > DataPager1.PageSize);
    }
}