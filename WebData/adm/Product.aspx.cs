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
using Zensoft.Website.BusinessLayer.BusinessFacade;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using Zensoft.Website.Utilities.HTML;
using System.Net;
using Zensoft.Website.Configuration;
using Zensoft.Website.Toolkit;

public partial class Product : Zensoft.Website.UI.BasePage
{
    protected string UploadUrl = "UploadProductFile.aspx";
    protected string AttachedUrl = "AttachedFileProduct.aspx";

    private void BindDropDepartment(int superDepId, int parentId, string prefix)
    {
        List<DepartmentsBF> deps = DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(parentId, superDepId);

        foreach (DepartmentsBF dep in deps)
        {
            if (DepartmentsBF.GetDepartmentsByParentIDAndSuperDepartmentID(dep.DepartmentID, superDepId).Count > 0)
            {
                BindDropDepartment(superDepId, dep.DepartmentID, prefix + dep.Title + " - ");
            }
            else
            {
                ListItem item = new ListItem(prefix + dep.Title, dep.DepartmentID.ToString());
                ddlDepartment.Items.Add(item);
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDropDepartment(SuperDepartmentsBF.GetSuperDepartmentsAll().First().SuperDepartmentID, 0, "");

            if (Request.QueryString["action"] == "add")
            {
                UploadUrl = "UploadProductFile.aspx";
                AttachedUrl = "AttachedFileProduct.aspx";

                btnView.Visible = false;
                pnlProductImages.Visible = false;
                panUpload.Visible = false;

                pnlSpecialProduct.Visible = false;
                pnlProductProperty.Visible = false;
                ucProductProperties1.ProductID = 0;

            }
            else if (Request.QueryString["action"] == "edit")
            {
                btnView.Visible = true;
                pnlProductImages.Visible = true;
                panUpload.Visible = true;

                int productID;
                int.TryParse(Request.QueryString["productID"], out productID);

                ProductsBF product = ProductsBF.GetProductsBF(productID);

                //Người ko có quyền sẽ ko thể thay đổi được thông tin mặt hàng
                if (!(product.AddedBy == Page.User.Identity.Name || Roles.IsUserInRole("Administrators")))
                    Response.Redirect("~/error.aspx?code=404");

                txtTitle.Text = product.Title;
                txtDescription.Text = product.Description;

                ddlDepartment.SelectedValue = product.DepartmentID.ToString();

                txtBrand.Text = product.Brand;
                txtProdutcode.Text = product.ProductCode;

                txtPrice.Text = product.UnitPrice.ToString();
                txtSalePrice.Text = product.SalePrice.ToString();

                fckDetail.Text = product.Details;
                chkDescontinued.Checked = product.Discontinued;
                chkListed.Checked = product.Listed;

                chkVote.Checked = product.Votes == 1;

                UploadUrl = "UploadProductFile.aspx?ProductID=" + productID.ToString();
                AttachedUrl = "AttachedFileProduct.aspx?ProductID=" + productID.ToString();

                panUpload.DataBind();

                pnlSpecialProduct.Visible = true;
                ucSpecialProduct1.ProductID = productID;
                ucSpecialProduct1.SetSpecialProduct();
                ucSpecialProduct2.ProductID = productID;
                ucSpecialProduct2.SetSpecialProduct();
                ucSpecialProduct3.ProductID = productID;
                ucSpecialProduct3.SetSpecialProduct();

                pnlProductProperty.Visible = true;
                ucProductProperties1.ProductID = productID;
            }
        }

    }

    /// <summary>
    /// Upload ảnh cho sản phẩm
    /// </summary>
    /// <param name="productID"></param>
    void UploadProductImage(int productID)
    {
        if (!fuProductImages.HasFile) return;

        var product = ProductsBF.GetProductsBF(productID);

        Zensoft.Website.Toolkit.UploadHandler myUploadHandler = new Zensoft.Website.Toolkit.UploadHandler();
        myUploadHandler.GenerateUniqueFileName = false;
        myUploadHandler.AllowedExtensions = AppConfiguration.AllowExtension;
        myUploadHandler.VirtualSavePath = "~/Attachs/Items/" + productID.ToString() + "/Preview/";

        //tạo tên file ảnh theo tên sản phẩm
        string name = VNString.TextToUrl(product.Title);
        string fullPath = Path.Combine(myUploadHandler.VirtualSavePath, name) + ".jpg";
        int i = 0;

        while (File.Exists(Server.MapPath(fullPath)))
        {
            i++;
            name = VNString.TextToUrl(product.Title) + "-" + i.ToString();
            fullPath = Path.Combine(myUploadHandler.VirtualSavePath, name) + ".jpg";
        }

        myUploadHandler.FileName = name;
        myUploadHandler.UploadFile(fuProductImages);

        //resize ảnh
        try
        {
            string FileName = Path.Combine(myUploadHandler.VirtualSavePath, myUploadHandler.FileName) + myUploadHandler.Extension;
            string smallPicturePath = Path.Combine(myUploadHandler.VirtualSavePath, "s-" + myUploadHandler.FileName) + myUploadHandler.Extension;
            string midPicturePath = Path.Combine(myUploadHandler.VirtualSavePath, "m-" + myUploadHandler.FileName) + myUploadHandler.Extension;

            Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(FileName), Server.MapPath(smallPicturePath), AppConfiguration.ItemImagePreviewMaxWidth, AppConfiguration.ItemImagePreviewMaxHeight, ImageFormat.Jpeg);

            //thêm đóng dấu bản quyền
            if (AppConfiguration.ItemImageWatemark)
            {
                using (System.Drawing.Image im = System.Drawing.Image.FromFile(Server.MapPath(FileName)))
                {
                    Zensoft.Website.Toolkit.Watermarker watemark = new Watermarker(im);

                    watemark.ScaleRatio = (float)im.Width / AppConfiguration.ItemImageFullMaxWidth;
                    watemark.Position = WatermarkPosition.BottomRight;

                    watemark.DrawImage(Server.MapPath(AppConfiguration.ItemImageWatemarkPath));

                    //save ảnh vào file tạm
                    watemark.Image.Save(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), ImageFormat.Jpeg);

                }
            }
            else File.Move(Server.MapPath(FileName), Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"));

            //xóa file ảnh gốc
            if (File.Exists(Server.MapPath(FileName)))
                File.Delete(Server.MapPath(FileName));

            Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), Server.MapPath(midPicturePath), AppConfiguration.ItemImageMedMaxWidth, AppConfiguration.ItemImageMedMaxHeight, ImageFormat.Jpeg);
            Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), Server.MapPath(FileName), AppConfiguration.ItemImageFullMaxWidth, AppConfiguration.ItemImageFullMaxHeight, ImageFormat.Jpeg);

            //xóa file tạm
            if (File.Exists(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg")))
                File.Delete(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"));

            ProductImagesBF.Insert(0, productID, smallPicturePath, midPicturePath, FileName);

            //cập nhật ảnh minh họa cho sản phẩm
            List<ProductImagesBF> pi = ProductImagesBF.GetProductImagesByProductID(product.ProductID);
            if (pi.Count > 0)
                product.SmallPictureUrl = pi[0].SmallImage;
            else
                product.SmallPictureUrl = "";

            product.Update();
        }
        catch
        {
        }
    }

    protected void lbtnUpImage_Click(object sender, EventArgs e)
    {
        if (!fuProductImages.HasFile) return;

        int productID;

        if (Request.QueryString["action"] == "add")
        {
            productID = InsertProduct();

            UploadProductImage(productID);
            Response.Redirect("~/adm/Product.aspx?ProductID=" + productID + "&action=edit");
        }
        else if (Request.QueryString["action"] == "edit")
        {
            int.TryParse(Request.QueryString["ProductID"], out productID);

            UploadProductImage(productID);
            rptProductImages.DataBind();
        }

    }

    protected void rptProductImages_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "DeleteImage")
        {
            int imageID = int.Parse(e.CommandArgument.ToString());

            if (imageID != 0)
            {
                ProductImagesBF image = ProductImagesBF.GetProductImagesBF(imageID);

                if (File.Exists(Server.MapPath(image.SmallImage)))
                    File.Delete(Server.MapPath(image.SmallImage));

                if (File.Exists(Server.MapPath(image.MedImage)))
                    File.Delete(Server.MapPath(image.MedImage));

                if (File.Exists(Server.MapPath(image.FullImage)))
                    File.Delete(Server.MapPath(image.FullImage));

                image.Delete();

                //cập nhật lại ảnh minh họa cho sản phẩm
                var product = ProductsBF.GetProductsBF(image.ProductID);

                List<ProductImagesBF> pi = ProductImagesBF.GetProductImagesByProductID(product.ProductID);
                if (pi.Count > 0)
                    product.SmallPictureUrl = pi[0].SmallImage;
                else
                    product.SmallPictureUrl = "";

                product.Update();
                rptProductImages.DataBind();
            }
        }
    }

    /// <summary>
    /// thêm sản phẩm mới
    /// </summary>
    int InsertProduct()
    {
        int productID;

        ProductsBF product = new ProductsBF();

        //xóa bớt khoảng trằng ở tiêu đề sản phẩm
        string st = txtTitle.Text.Trim();
        st = Regex.Replace(st, "\\ {2,}", " ");

        product.Title = st;

        product.Description = txtDescription.Text;

        product.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

        product.Brand = txtBrand.Text;
        product.ProductCode = txtProdutcode.Text;

        if (!string.IsNullOrEmpty(txtPrice.Text))
            product.UnitPrice = Convert.ToInt32(txtPrice.Text.Replace(".", "").Replace(",", ""));
        else
            product.UnitPrice = 0;

        if (!string.IsNullOrEmpty(txtSalePrice.Text))
            product.SalePrice = Convert.ToInt32(txtSalePrice.Text.Replace(".", "").Replace(",", ""));
        else
            product.SalePrice = 0;

        product.AddedBy = Page.User.Identity.Name;
        product.AddedDate = DateTime.Now;
        product.EditedDate = DateTime.Now;

        product.Details = fckDetail.Text;
        product.Discontinued = chkDescontinued.Checked;

        if (chkVote.Checked)
            product.Votes = 1;
        else
            product.Votes = 0;

        product.Listed = chkListed.Checked;

        productID = product.Insert();

        //chuyển tiêu đề sản phẩm thành chuỗi duy nhất để có thể tìm sản phẩm bằng chuỗi này
        st = st.Replace(" ", "-");

        st = VNString.vietDecode(st.ToLower());
        st = Regex.Replace(st, "[^\\w\\-]", "-");
        st = Regex.Replace(st, "\\-{2,}", "-");

        product.ProductID = productID;
        var productTemp = ProductsBF.GetProductByUniqueTitle(st);

        if (productTemp == null)//nếu chưa tồn tại sản phẩm với tiêu đề mới thì
            product.UniqueTitle = st;
        else if (productTemp.ProductID != productID)//nếu đã tồn tại tiêu đề đó rồi thì
            product.UniqueTitle = productID.ToString() + "-" + st;

        product.Update();

        MembershipUser currentUser = Membership.GetUser(false);
        ActivityLogsBF.LogUserActivity((Guid)currentUser.ProviderUserKey, "Product->Add", this.Request.Url.AbsoluteUri.Replace(this.Request.Url.PathAndQuery, "") + "/adm/Product.aspx?productID=" + productID + "&action=edit");

        return productID;
    }

    /// <summary>
    /// cập nhật thay đổi thông tin sản phẩm
    /// </summary>
    int UpdateProduct()
    {
        int productID;
        int.TryParse(Request.QueryString["productID"], out productID);

        ProductsBF product = ProductsBF.GetProductsBF(productID);

        //check quyền được thay đổi thông tin sản phẩm
        if (!(product.AddedBy == Page.User.Identity.Name || Roles.IsUserInRole("Administrators")))
            Response.Redirect("~/error.aspx?code=404");

        //xóa bớt khoảng trằng ở tiêu đề sản phẩm
        string st = txtTitle.Text.Trim(); ;
        st = Regex.Replace(st, "\\ {2,}", " ");

        product.Title = st;
        product.Description = txtDescription.Text; ;

        product.DepartmentID = Convert.ToInt32(ddlDepartment.SelectedValue);

        product.Brand = txtBrand.Text;
        product.ProductCode = txtProdutcode.Text;

        if (!string.IsNullOrEmpty(txtPrice.Text))
            product.UnitPrice = Convert.ToInt32(txtPrice.Text.Replace(".", "").Replace(",", ""));
        else
            product.UnitPrice = 0;

        if (!string.IsNullOrEmpty(txtSalePrice.Text))
            product.SalePrice = Convert.ToInt32(txtSalePrice.Text.Replace(".", "").Replace(",", ""));
        else
            product.SalePrice = 0;

        product.EditedDate = DateTime.Now;

        product.Details = fckDetail.Text;
        product.Discontinued = chkDescontinued.Checked;
        product.Listed = chkListed.Checked;

        if (chkVote.Checked)
            product.Votes = 1;
        else
            product.Votes = 0;

        //ảnh minh họa = ảnh đầu tiên trong danh sách ảnh minh họa
        List<ProductImagesBF> images = ProductImagesBF.GetProductImagesByProductID(product.ProductID);
        if (images.Count > 0)
            product.SmallPictureUrl = images[0].SmallImage;
        else
            product.SmallPictureUrl = "";

        //chuyển tiêu đề sản phẩm thành chuỗi duy nhất để có thể tìm sản phẩm bằng chuỗi này
        st = st.Replace(" ", "-");

        st = VNString.vietDecode(st.ToLower());
        st = Regex.Replace(st, "[^\\w\\-]", "-");
        st = Regex.Replace(st, "\\-{2,}", "-");

        var productTemp = ProductsBF.GetProductByUniqueTitle(st);

        //nếu chưa tồn tại sản phẩm với tiêu đề mới thì
        if (productTemp == null)
            product.UniqueTitle = st;
        else if (productTemp.ProductID != product.ProductID)
            product.UniqueTitle = st + "-" + product.ProductID.ToString();

        product.Update();

        MembershipUser currentUser = Membership.GetUser(false);
        ActivityLogsBF.LogUserActivity((Guid)currentUser.ProviderUserKey, "Product->Edit", this.Request.Url.ToString());

        return productID;
    }

    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        //thay đổi thông tin về mặt hàng
        if (Request.QueryString["action"] == "edit")
        {
            UpdateProduct();            //cập nhật thông tin sản phẩm

            UploadProductImage(int.Parse(Request.QueryString["ProductID"]));            //up ảnh sản phẩm

            ucSpecialProduct1.ActiveSpecialProduct();
            ucSpecialProduct2.ActiveSpecialProduct();
            ucSpecialProduct3.ActiveSpecialProduct();

            ucProductProperties1.ActiveProductProperty();

            Response.Redirect("~/adm/Product.aspx?productID=" + Request.QueryString["ProductID"] + "&action=edit");
        }//thêm mới mặt hàng
        else if (Request.QueryString["action"] == "add")
        {
            int productID = InsertProduct();            //thêm mới sản phẩm

            UploadProductImage(productID);          //up ảnh sản phẩm
            Response.Redirect("~/adm/Product.aspx?productID=" + productID + "&action=edit");
        }
    }

    protected void btnView_Click(object sender, EventArgs e)
    {
        int productID = UpdateProduct();            //cập nhật thay đổi sản phẩm

        ProductsBF product = ProductsBF.GetProductsBF(productID);

        Response.Redirect("/ShowItem/" + product.UniqueTitle);
    }

    ///// <summary>
    ///// lấy tất cả các thẻ ảnh trong đoạn mã html
    ///// </summary>
    ///// <param name="html"></param>
    ///// <returns>trả về tập hợp các đường dẫn ảnh</returns>
    //List<string> GetImageTag(string html)
    //{
    //    ParseHTML parse = new ParseHTML();
    //    List<string> result = new List<string>();

    //    parse.Source = html + "\n\r";
    //    while (!parse.Eof())
    //    {
    //        char ch = parse.Parse();
    //        if (ch == 0)
    //        {
    //            AttributeList tag = parse.GetTag();
    //            if (tag.Name.ToLower() == "img")
    //            {
    //                for (int i = 0; i < tag.List.Count; i++)
    //                {
    //                    Zensoft.Website.Utilities.HTML.Attribute att = (Zensoft.Website.Utilities.HTML.Attribute)tag.List[i];
    //                    if (att.Name.ToLower() == "src")
    //                    {
    //                        result.Add(att.Value);
    //                    }
    //                }
    //            }
    //        }
    //    }

    //    return result;
    //}

    //protected void btnGenUrl_Click(object sender, EventArgs e)
    //{
    //    string details = (ProductsBF.GetProductsBF(int.Parse(Request.QueryString["productID"]))).Details;

    //    details = details.Replace("%20", " ");

    //    //lấy tất cả các link ảnh trong bài viết
    //    List<string> urlAll = GetImageTag(details);

    //    List<string> urls = new List<string>();

    //    //Xóa các đường đẫn trùng nhau
    //    foreach (string tmp in urlAll)
    //    {
    //        bool bChungDuongDan = false;
    //        foreach (string u in urls)
    //        {
    //            if (u.ToUpper() == tmp.ToUpper()) bChungDuongDan = true;
    //        }

    //        if (!bChungDuongDan) urls.Add(tmp);
    //    }

    //    Hashtable fileList = new Hashtable();

    //    foreach (string url in urls)
    //    {
    //        string filename = url.Substring(url.LastIndexOf("/") + 1);
    //        fileList.Add(url, filename);
    //    }

    //    rptUrlCopy.DataSource = fileList;
    //    rptUrlCopy.DataBind();

    //    btnCopyImageToServer.Visible = true;
    //}

    ///// <summary>
    ///// download ảnh vào server
    ///// Hàm này dùng để tải tất cả các link ảnh khi copy bài viết từ website khác
    ///// </summary>
    ///// <param name="url">dường dẫn ảnh</param>
    ///// <returns>Đường đẫn file ảnh được up lên server, nếu không ghi được lên server thì trả lại thông báo lỗi</returns>
    //private string StartDownload(string url)
    //{

    //    string fileName = url.Substring(url.LastIndexOf("/") + 1);

    //    return StartDownload(url, fileName);
    //}

    //private string StartDownload(string url, string filename)
    //{
    //    //đường dẫn file để ghi lên server
    //    string destFileName;

    //    Stream stream = null;
    //    FileStream fstream = null;
    //    MemoryStream memStream = null;

    //    //kiểm tra đã tồn tại thư mục lưu trữ file đính kèm trên server chưa
    //    string dirPath = "~/Attachs/Items/Articles" + "/" + Convert.ToInt32(Request.QueryString["productID"]);
    //    if (!Directory.Exists(Server.MapPath(dirPath)))
    //        Directory.CreateDirectory(Server.MapPath(dirPath));

    //    destFileName = dirPath + "/" + filename;
    //    destFileName = destFileName.Replace("%20", " ");

    //    //ghi file vào ổ cứng
    //    //Kiểm tra có file trùng tên trên server ko, nếu có có nghĩa là đã đc up lên server rồi
    //    if (!File.Exists(Server.MapPath(destFileName)))
    //    {

    //        try
    //        {
    //            //lấy dữ liệu từ url
    //            WebRequest req = WebRequest.Create(url);
    //            WebResponse response = req.GetResponse();
    //            stream = response.GetResponseStream();

    //            byte[] buffer = new byte[1024];

    //            int dataLength = (int)response.ContentLength;

    //            //Download dữ liệu vào RAM trước khi ghi vào ổ cứng
    //            memStream = new MemoryStream();
    //            int bytesRead = 0;
    //            while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
    //            {
    //                memStream.Write(buffer, 0, bytesRead);
    //            }

    //        }
    //        catch (Exception)
    //        {
    //            // lỗi có thể do ko kết nối được với server hoặc url không tồn tại
    //            if (memStream != null) memStream.Close();
    //            if (stream != null) stream.Close();
    //            return "Đường đẫn ảnh không chỉnh xác";
    //        }

    //        try
    //        {
    //            //fstream = System.IO.File.Create(destFileName);
    //            fstream = new FileStream(Server.MapPath(destFileName), FileMode.Create, FileAccess.Write);
    //            fstream.Write(memStream.ToArray(), 0, (int)memStream.Length);

    //        }
    //        catch (System.Exception)
    //        {
    //            //lỗi không gi được vào ổ cứng
    //            return "Không thể ghi link ảnh lên server";
    //        }
    //        finally
    //        {
    //            fstream.Close();
    //            stream.Close();
    //            memStream.Close();
    //        }
    //    }
    //    else
    //    {
    //        //return destFileName;
    //        return "Đã tồn tại file này trên server";
    //    }

    //    return destFileName;
    //}

    //protected void btnCopyImageToServer_Click(object sender, EventArgs e)
    //{
    //    string body = (ProductsBF.GetProductsBF(int.Parse(Request.QueryString["productID"]))).Details;

    //    body = body.Replace("%20", " ");


    //    foreach (RepeaterItem item in rptUrlCopy.Items)
    //    {
    //        Control c = item.FindControl("chkCopy");

    //        if (c != null)
    //        {
    //            CheckBox chkCopy = (CheckBox)c;
    //            if (chkCopy.Checked)
    //            {
    //                Label lblUrl = (Label)item.FindControl("lblUrl");
    //                TextBox txtFile = (TextBox)item.FindControl("txtFile");
    //                Label lblMessage = (Label)item.FindControl("lblMess");

    //                Uri u = new Uri(lblUrl.Text);

    //                //nếu link ảnh từ host khác thì tiến hành down về host
    //                if (u.Host != this.Request.Url.Host)
    //                {
    //                    string uploadPath = StartDownload(lblUrl.Text, txtFile.Text).Replace("~/", this.FullBaseUrl);

    //                    lblMessage.Text = " ==&gt; " + uploadPath;

    //                    //nếu copy thành công file ảnh lên server thì thay đổi đường dẫn trong bài viết
    //                    int i = uploadPath.LastIndexOf("/");
    //                    if (i > 0)
    //                    {
    //                        body = body.Replace(lblUrl.Text, uploadPath);

    //                        ProductsBF product = ProductsBF.GetProductsBF(int.Parse(Request.QueryString["productID"]));
    //                        product.Details = body;
    //                        product.Update();
    //                    }
    //                }
    //                else
    //                {
    //                    lblMessage.Text = "==&gt; (ảnh trên server)";
    //                }
    //            }

    //        }
    //    }
    //}
}
