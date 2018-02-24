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

public partial class adm_ManageProductCommnets : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        } 

    }
    public string GetAvatarUrl(string userName)
    {
        //ProfileCommon profile = null;
        //if (userName.Length > 0)
        //    profile = this.Profile.GetProfile(userName);

        string ret = "";
        //if (profile != null)
        //{
        //    ret = profile.AvatarUrl;
        //}

        if (string.IsNullOrEmpty(ret))
            ret = "~/images/avatars/noavatar.gif";

        return ret;
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblUserName = (Label)e.Row.FindControl("lblUserName");
        Label lblFullName = (Label)e.Row.FindControl("lblFullName");

        HyperLink lnkSendMessage = (HyperLink)e.Row.FindControl("lnkSendMessage");

        Image imgAvatar = (Image)e.Row.FindControl("imgAvatar");

        if (lblUserName != null)
        {
            if (lblUserName.Text == "")
            {
                lblUserName.Visible = false;
                lblFullName.Visible = true;
            }
            else
            {
                lblUserName.Visible = true;
                lblFullName.Visible = false;
            }
        }

    }

    protected void gvwComments_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "DeleteComment")
        {
            ProductCommentsBF.Delete(Convert.ToInt32(e.CommandArgument));
            gvwComments.DataBind();
        }
        if (e.CommandName == "ApprovedComment")
        {
            var comment = ProductCommentsBF.GetProductCommentsBF(Convert.ToInt32(e.CommandArgument));
            comment.Approved = true;
            comment.Update();

            gvwComments.DataBind();
        }
    }


    protected void lnkUnapprovedComment_Click(object sender, EventArgs e)
    {

        gvwComments.Visible = false;
        gvwUnapprovedComments.Visible = true;
    }
    protected void lnkAllComment_Click(object sender, EventArgs e)
    {
 
        gvwComments.Visible = true;
        gvwUnapprovedComments.Visible = false;
    }
}
