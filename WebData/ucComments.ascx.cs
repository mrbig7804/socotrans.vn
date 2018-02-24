using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;

public partial class ucComments : System.Web.UI.UserControl
{
    private int _articleID;
    public int ArticleID
    {
        get { return _articleID; }
        set { _articleID = value; }
    }


    public Boolean AllowEditComment
    {
        get
        {
            return Roles.IsUserInRole("Administrators");
        }
    }

    /// <summary>
    /// 3 Hàm bên dưới để lưu giá trị của ArticleID.
    /// </summary>
    /// <param name="e"></param>
    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        this.ArticleID = (int)ctlState[1];
    }

    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = this.ArticleID;
        return ctlState;
    }
    public string GetAvatarUrl(string userName)
    {
        //ProfileCommon profile = null;
        //if (userName.Length > 0)
        //    profile = this.Profile.GetProfile(userName);

        string ret = "";
        //if (profile !=null)
        //{
        //    ret = profile.AvatarUrl;
        //}

        if (string.IsNullOrEmpty(ret))
            ret = "~/images/avatars/noavatar.gif";

        return ret ;
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Label lblUserName = (Label)e.Row.FindControl("lblUserName");
        Label lblFullName = (Label)e.Row.FindControl("lblFullName");

        HyperLink lnkSendMessage = (HyperLink)e.Row.FindControl("lnkSendMessage");

        Image imgAvatar = (Image)e.Row.FindControl("imgAvatar");

       // imgAvatar.Visible = (! string.IsNullOrEmpty( imgAvatar.ImageUrl ));

        if (lblUserName != null)
        {
            if (lblUserName.Text == "")
            {
                lblUserName.Visible = false;
                lblFullName.Visible = true;
                lnkSendMessage.Visible = false;
            }
            else
            {
                lblUserName.Visible = true;
                lblFullName.Visible = false;
                lnkSendMessage.Visible = true;
            }
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            gvwComments.DataSource = CommentsBF.GetCommentsByArticleID(this.ArticleID);
            gvwComments.DataBind();

            if (this.Page.User.Identity.IsAuthenticated)
            {
                //pnInfor.Visible = false; 
                txtHoTen.ReadOnly = true;
                txt_Thua.ReadOnly = true;
                MembershipUser mu = Membership.GetUser(this.Page.User.Identity.Name);
                txt_Thua.Text = mu.Email;
                txtHoTen.Text = mu.UserName; //+ " ("+ this.Profile.FullName +")";
            }
            else
            {
                //tự động điền tên người comment
                if (Session["Comment_Name"]!= null)
                    txtHoTen.Text = Session["Comment_Name"].ToString();
                if (Session["Comment_Email"] != null)
                    txt_Thua.Text = Session["Comment_Email"].ToString();
            }
        }
    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        int comment;

        string key = this.Request.UserHostAddress.ToString() + "_"+ "Comment_Article" + ArticleID.ToString();

        if (Cache[key] == null)
        {

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                MembershipUser mu = Membership.GetUser(txtHoTen.Text);
                string mu1 = Membership.GetUserNameByEmail(txt_Thua.Text);
                if (mu != null)
                {
                    lblResults.Text = "Tên bạn dùng đã được đăng ký. Hãy đăng nhập nếu bạn đã đăng ký tài khoản trên hoặc bạn có thể sử dụng tên khác để nhận xét!";
                    return;
                }

                if (string.IsNullOrEmpty(mu1) == false)
                {
                    lblResults.Text = "Email này đã Tồn tại. Bạn hãy đăng nhập nếu đã đăng ký tài khoản bằng Email này hoặc sử dụng Email khác!";
                    return;
                }
                
                comment = Convert.ToInt32(CommentsBF.Insert(0, txtHoTen.Text, txt_Thua.Text, txtContents.Text, ArticleID, null, DateTime.Now, false));
            }
            else
            {
                comment = Convert.ToInt32(CommentsBF.Insert(0, "", txt_Thua.Text, txtContents.Text, ArticleID, Page.User.Identity.Name, DateTime.Now, true));

                gvwComments.DataBind();
            }
            
            txtContents.Text = "";

            if (comment > 0)
                if (!this.Page.User.Identity.IsAuthenticated)
                {
                    lblResults.Text = "Đã gửi thành công! Lưu ý: Nếu bạn chưa là thành viên của website, các nhận xét của bạn sẽ không hiện lên ngay sau khi gửi";
                }
                else
                    lblResults.Text = "Đã gửi thành công!";

            //lưu comment vào cache để tránh spam comment
            Cache.Insert(key, 1, null, DateTime.Now.AddMinutes(5), TimeSpan.Zero);

            Session.Add("Comment_Name", txtHoTen.Text);
            Session.Add("Comment_Email", txt_Thua.Text);

            gvwComments.DataSource = CommentsBF.GetCommentsByArticleID(this.ArticleID);
            gvwComments.DataBind();
        }
        else lblResults.Text = "Bạn hãy chờ một khoảng thời gian trước khi tiếp tục nhận xét (Hai nhận xét trong cùng 1 bài viết phải cách nhau ít nhất 5')";
    }

    protected string ConvertToHTMLTag(string s)
    {
        return s.ToString().Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\n", "<br/>").Replace("  ", "&nbsp; ");
    }

}
