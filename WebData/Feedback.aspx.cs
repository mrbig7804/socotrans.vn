using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.Utilities;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Drawing.Imaging;
using System.Drawing;
using Zensoft.Website.BusinessLayer;
using Zensoft.Website.DataLayer.DataObject;
using System.IO;

public partial class Feedback: Zensoft.Website.UI.BasePage
{
    protected string FeedbackTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!this.IsPostBack && !string.IsNullOrEmpty(this.Request.QueryString["Title"]))
        {
            FeedbackTitle = this.Request.QueryString["Title"];
            txtTitle.DataBind();
        }

        Image1.ImageUrl = "~/GenImage.aspx";
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Session["VerifyFeedback"] == null) return;

        string verify = (string)Session["VerifyFeedback"];

        if (verify == txtVerify.Text)
        {

            FeedbacksBF fb = new FeedbacksBF();

            fb.FeedbackDate = DateTime.Now;

            fb.Detail = txtDetail.Text;
            fb.Email = txtEmail.Text;
            fb.FullName = txtFullName.Text;
            fb.Tel = txtTel.Text;
            fb.Title = txtTitle.Text;

            fb.Detail = fb.Detail.Replace("\n", "<br />");

            fb.Insert();

            //send mail
            StreamReader sr = new StreamReader(Server.MapPath("/FeedbackPage.html"));
            sr = File.OpenText(Server.MapPath("/FeedbackPage.html"));
            string content = sr.ReadToEnd();
            content = content.Replace("[FullName]", txtFullName.Text);
            content = content.Replace("[Tel]", txtTel.Text);
            content = content.Replace("[Email]", txtEmail.Text);
            content = content.Replace("[Title]", txtTitle.Text);
            content = content.Replace("[Detail]", txtDetail.Text);

            SendMail mail = new SendMail();
            mail.Send("websitetinnghia@gmail.com", "tinnghia@123", "chimcanhnamdinh@gmail.com", "Phản hồi từ người dùng sử dụng website Chim cảnh Nam Định", content);

            panelFeedBack.Visible = false;
            panelSuccessMsg.Visible = true;

            Session.Remove("VerifyFeedback");
        }
        else
        {
            lblErrorMsg.Visible = true; 
        }
    }
}
