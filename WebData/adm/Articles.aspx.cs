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

using Zensoft.Website.DataLayer.DataObject;
using Zensoft.Website.BusinessLayer.BusinessFacade;

using Zensoft.Website.Security;
using System.Collections.Generic;
using Zensoft.Website.Utilities.HTML;
using System.IO;
using System.Net;
using Zensoft.Website.UI;

public partial class admin_Articles : Zensoft.Website.UI.BasePage
{

    protected string UploadUrl = "UploadArticleFile.aspx";
    protected string AttachedUrl = "AttachedFileArticle.aspx";

    protected bool InRole()
    {
        return Permissions.ArticlesApprovedPermission(this.User.Identity.Name);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bool inRoles = Permissions.ArticlesApprovedPermission(User.Identity.Name);

            if (Request.QueryString["Action"] == "add")
            {
                ArticlesBF temp = new ArticlesBF();
                temp.AddedDate = DateTime.Now;
                temp.AddedBy = User.Identity.Name;

                temp.ExpireDate = DateTime.MaxValue;
                temp.ReleaseDate = DateTime.Now;

                temp.Approved = inRoles;
                temp.Listed = true;

                ucArticleDetail1.SetArticle(temp);

                UploadUrl = "UploadArticleFile.aspx";
                AttachedUrl = "AttachedFileArticle.aspx";

                lblUploadMessage.Visible = true;
                lblViewMassage.Visible = false;
                panUpload.Visible = false;

                btnView.Visible = false;

                panDownloadImage.Visible = false;

            }
            else if (Request.QueryString["Action"] == "edit")
            {
                int articleID = Convert.ToInt32(Request.QueryString["ArticleID"]);

                lblUploadMessage.Visible = false;
                lblViewMassage.Visible = true;
                panUpload.Visible = true;

                panDownloadImage.Visible = Permissions.IsAdministrator(User.Identity.Name);

                ucArticleDetail1.ArticleID = articleID;

                ArticlesBF article = ArticlesBF.GetArticlesBF(articleID);

                //chỉ những người tạo ra bài viết và người có quyền mới có thể thay đổi bài viết
                if (article.AddedBy == User.Identity.Name || Permissions.ArticlesEditPermission(User.Identity.Name))
                {
                    //nếu người post bài là admin thì chỉ có admin mới có quyền edit
                    if (Permissions.IsAdministrator(article.AddedBy))
                    {
                        if (!Permissions.IsAdministrator(this.User.Identity.Name))
                            Response.Redirect("~/showArticle.aspx?ID=" + articleID.ToString());
                    }

                    UploadUrl = "UploadArticleFile.aspx?ArticleID=" + articleID.ToString();
                    AttachedUrl = "AttachedFileArticle.aspx?ArticleID=" + articleID.ToString();

                    panUpload.DataBind();
                }
                else
                    Response.Redirect("~/showArticle.aspx?ID=" + articleID.ToString());
            }
        }
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Action"] == "add")
        {
            int articleID;

            ArticlesBF article = ucArticleDetail1.GetArticle();

            //nếu không phải là người có quyền duyệt bài thì bài viết sẽ ko đc duyệt (không đc hiện lên trang chủ)
            if (Permissions.ArticlesApprovedPermission(User.Identity.Name))
            {
                articleID = article.Insert();
            }
            else
            {
                articleID = article.ContributorInsert();
            }

            //chuyển file từ đường dẫn tạm sang đường dẫn file đính kèm bài viết
            if (article.PictureUrl != string.Empty)
            {
                string path = Server.MapPath(article.PictureUrl);
                string desPath = Server.MapPath(Globals.ARTICLE_IMAGE_SAVE_PATH + articleID);

                if (!Directory.Exists(desPath))
                    Directory.CreateDirectory(desPath);

                File.Copy(path, desPath + "\\Preview_" + Path.GetFileName(path));
                File.Delete(path);

                ArticlesBF articleUpdate = ArticlesBF.GetArticlesBF(articleID);
                articleUpdate.PictureUrl = Globals.ARTICLE_IMAGE_SAVE_PATH + articleID + "/Preview_" + Path.GetFileName(path);
                articleUpdate.Update();
            }

            Response.Redirect("~/adm/Articles.aspx?Action=edit&ArticleID=" + articleID.ToString());
        }
        else if (Request.QueryString["Action"] == "edit")
        {
            ArticlesBF article = this.ucArticleDetail1.GetArticle();

            if (article.AddedBy == User.Identity.Name || Permissions.ArticlesEditPermission(User.Identity.Name))
                //nếu là người có quyền thay đổi bài viết hoặc người có quyền duyệt bài viêt thì cập nhật bình thường
                if (Permissions.ArticlesApprovedPermission(User.Identity.Name))
                    article.Update();
                else
                {
                    //nếu là người không có quyền duyệt bài viết
                    article.ContributorUpdate();
                }
            else
                Response.Redirect("~/error.aspx");
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ShowArticle.aspx?ID=" + Request.QueryString["ArticleID"]);
    }


    protected void btnCopyImageToServer_Click(object sender, EventArgs e)
    {
        string body = ucArticleDetail1.GetArticle().Body;

        body = body.Replace("%20", " ");


        foreach (RepeaterItem item in rptUrlCopy.Items)
        {
            Control c = item.FindControl("chkCopy");

            if (c != null)
            {
                CheckBox chkCopy = (CheckBox)c;
                if (chkCopy.Checked)
                {
                    Label lblUrl = (Label)item.FindControl("lblUrl");
                    TextBox txtFile = (TextBox)item.FindControl("txtFile");
                    Label lblMessage = (Label)item.FindControl("lblMessage");

                    Uri u = new Uri(lblUrl.Text);

                    //nếu link ảnh từ host khác thì tiến hành down về host
                    if (u.Host != this.Request.Url.Host)
                    {
                        string uploadPath = StartDownload(lblUrl.Text, txtFile.Text).Replace("~/", this.FullBaseUrl);

                        lblMessage.Text = "<b>Url trên host:</b> <b style='color: #f95037;font-weight: normal'>" + uploadPath + "</b>";

                        //nếu copy thành công file ảnh lên server thì thay đổi đường dẫn trong bài viết
                        int i = uploadPath.LastIndexOf("/");
                        if (i > 0)
                        {
                            body = body.Replace(lblUrl.Text, uploadPath);
                            ucArticleDetail1.Body = body;
                        }
                    }
                    else
                    {
                        lblMessage.Text = "<b class='err'>Tên file ảnh bị trùng hoặc ảnh đã có trên server</b>";
                    }
                }

            }
        }
    }


    /// <summary>
    /// Dùng để gán mô tả mặc định cho thẻ ảnh việc này có thể hỗ trợ các bộ máy tìm kiếm dánh dấu ảnh tốt hơn
    /// </summary>
    /// <param name="html"></param>
    /// <param name="defaultAlt"></param>
    /// <returns></returns>
    private string SetImageAltTag(string html, string defaultAlt)
    {
        html = html.Replace("alt=\"\"", "alt=\"" + defaultAlt + "\"");
        html = html.Replace("alt=''", "alt=\"" + defaultAlt + "\"");
        return html;
    }

    /// <summary>
    /// lấy tất cả các thẻ ảnh trong đoạn mã html
    /// </summary>
    /// <param name="html"></param>
    /// <returns>trả về tập hợp các đường dẫn ảnh</returns>
    List<string> GetImageTag(string html)
    {
        ParseHTML parse = new ParseHTML();
        List<string> result = new List<string>();

        parse.Source = html + "\n\r";
        while (!parse.Eof())
        {
            char ch = parse.Parse();
            if (ch == 0)
            {
                AttributeList tag = parse.GetTag();
                if (tag.Name.ToLower() == "img")
                {
                    for (int i = 0; i < tag.List.Count; i++)
                    {
                        Zensoft.Website.Utilities.HTML.Attribute att = (Zensoft.Website.Utilities.HTML.Attribute)tag.List[i];
                        if (att.Name.ToLower() == "src")
                        {
                            result.Add(att.Value);
                        }
                    }
                }
            }
        }

        return result;
    }
    /// <summary>
    /// download ảnh vào server
    /// Hàm này dùng để tải tất cả các link ảnh khi copy bài viết từ website khác
    /// </summary>
    /// <param name="url">dường dẫn ảnh</param>
    /// <returns>Đường đẫn file ảnh được up lên server, nếu không ghi được lên server thì trả lại thông báo lỗi</returns>
    private string StartDownload(string url)
    {

        string fileName = url.Substring(url.LastIndexOf("/") + 1);

        return StartDownload(url, fileName);
    }

    private string StartDownload(string url, string filename)
    {
        //đường dẫn file để ghi lên server
        string destFileName;

        Stream stream = null;
        FileStream fstream = null;
        MemoryStream memStream = null;

        //kiểm tra đã tồn tại thư mục lưu trữ file đính kèm trên server chưa
        string dirPath = "~/Attachs/Articles" + "/" + Convert.ToInt32(Request.QueryString["ArticleID"]);
        if (!Directory.Exists(Server.MapPath(dirPath)))
            Directory.CreateDirectory(Server.MapPath(dirPath));

        destFileName = dirPath + "/" + filename;
        destFileName = destFileName.Replace("%20", " ");

        //ghi file vào ổ cứng
        //Kiểm tra có file trùng tên trên server ko, nếu có có nghĩa là đã đc up lên server rồi
        if (!File.Exists(Server.MapPath(destFileName)))
        {
            try
            {
                //lấy dữ liệu từ url
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                stream = response.GetResponseStream();

                byte[] buffer = new byte[1024];

                int dataLength = (int)response.ContentLength;

                //Download dữ liệu vào RAM trước khi ghi vào ổ cứng
                memStream = new MemoryStream();
                int bytesRead = 0;
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    memStream.Write(buffer, 0, bytesRead);
                }

            }
            catch (Exception)
            {
                // lỗi có thể do ko kết nối được với server hoặc url không tồn tại
                if (memStream != null) memStream.Close();
                if (stream != null) stream.Close();
                return "Đường đẫn ảnh không chính xác";
            }

            try
            {
                //fstream = System.IO.File.Create(destFileName);
                fstream = new FileStream(Server.MapPath(destFileName), FileMode.Create, FileAccess.Write);
                fstream.Write(memStream.ToArray(), 0, (int)memStream.Length);

            }
            catch (System.Exception)
            {
                //lỗi không gi được vào ổ cứng
                return "Không thể ghi link ảnh lên server";
            }
            finally
            {
                fstream.Close();
                stream.Close();
                memStream.Close();
            }
        }
        else
        {
            //return destFileName;
            return "Đã tồn tại file này trên server";
        }

        return destFileName;
    }

    protected void btnGenUrl_Click(object sender, EventArgs e)
    {
        string body = ucArticleDetail1.GetArticle().Body;

        body = body.Replace("%20", " ");

        //lấy tất cả các link ảnh trong bài viết
        List<string> urlAll = GetImageTag(body);

        List<string> urls = new List<string>();

        //Xóa các đường đẫn trùng nhau
        foreach (string tmp in urlAll)
        {
            bool bChungDuongDan = false;
            foreach (string u in urls)
            {
                if (u.ToUpper() == tmp.ToUpper()) bChungDuongDan = true;
            }

            if (!bChungDuongDan) urls.Add(tmp);
        }

        Hashtable fileList = new Hashtable();

        foreach (string url in urls)
        {
            string filename = url.Substring(url.LastIndexOf("/") + 1);
            fileList.Add(url, filename);
        }

        rptUrlCopy.DataSource = fileList;
        rptUrlCopy.DataBind();

        btnCopyImageToServer.Visible = true;
    }
}
