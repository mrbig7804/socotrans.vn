using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Security;
using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;
using System.Web.Security;
using System.Drawing.Imaging;
using Zensoft.Website.Toolkit;

public partial class person_UploadProductPreview : System.Web.UI.Page
{
    string _productID;
    public string ProductID
    {
        set
        {
            _productID = value;
        }
        get
        {
            return _productID;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Không cho phép người dùng lạc danh dùng điều khiển này
        //if (!this.Page.User.Identity.IsAuthenticated)
        //    throw new SecurityException("Anonymous users cannot upload files.");

        ProductID = Request["ProductID"];
        this.DataBind();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
    }

    /// <summary>
    /// lấy kích thước của thư mục tính theo byte
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static long DirSize(DirectoryInfo d)
    {
        long Size = 0;
        // Add file sizes.
        FileInfo[] fis = d.GetFiles();
        foreach (FileInfo fi in fis)
        {
            Size += fi.Length;
        }
        // Add subdirectory sizes.
        DirectoryInfo[] dis = d.GetDirectories();
        foreach (DirectoryInfo di in dis)
        {
            Size += DirSize(di);
        }
        return (Size);
    }

    string UploadForProduct(WebControls.UploadButtonEventArgs e)
    {

        string ret = "";
        int ProductID;
        int.TryParse(this.Request["ProductID"], out ProductID);

        if (Roles.IsUserInRole("Administrators") || Page.User.Identity.Name == ProductsBF.GetProductsBF(ProductID).AddedBy)
        {

            List<ProductImagesBF> images = ProductImagesBF.GetProductImagesByProductID(ProductID);

            //mỗi sản phẩm chỉ được upload ko quá 8 ảnh minh họa
            if (images.Count >= 8)
                return "error";

            Zensoft.Website.Toolkit.UploadHandler myUploadHandler;
            myUploadHandler = new Zensoft.Website.Toolkit.UploadHandler();
            myUploadHandler.GenerateUniqueFileName = true;
            myUploadHandler.AllowedExtensions = AppConfiguration.AllowExtension;
            myUploadHandler.VirtualSavePath = "~/Attachs/Items/" + ProductID.ToString() + "/Preview/";

            try
            {
                myUploadHandler.UploadFile(e.FileUploadControl);
            }
            catch { }

            try
            {
                FileName = Path.Combine(myUploadHandler.VirtualSavePath, myUploadHandler.FileName) + myUploadHandler.Extension;

                //thêm đóng dấu bản quyền
                using (System.Drawing.Image im = System.Drawing.Image.FromFile(Server.MapPath(FileName)))
                {
                    Zensoft.Website.Toolkit.Watermarker watemark = new Watermarker(im);

                    watemark.ScaleRatio = (float)im.Width / AppConfiguration.ItemImageFullMaxWidth;
                    watemark.Position = WatermarkPosition.Center;
                    watemark.DrawImage(Server.MapPath("~/Watermark/watermark.png"));

                    //save ảnh vào file tạm
                    watemark.Image.Save(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), ImageFormat.Jpeg);

                }

                //xóa file tạm
                if (File.Exists(Server.MapPath(FileName)))
                    File.Delete(Server.MapPath(FileName));

                string smallPicturePath = Path.Combine(myUploadHandler.VirtualSavePath, Guid.NewGuid().ToString()) + myUploadHandler.Extension;
                string midPicturePath = Path.Combine(myUploadHandler.VirtualSavePath, Guid.NewGuid().ToString()) + myUploadHandler.Extension;

                Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), Server.MapPath(smallPicturePath), AppConfiguration.ItemImagePreviewMaxWidth, AppConfiguration.ItemImagePreviewMaxHeight, ImageFormat.Jpeg);
                Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), Server.MapPath(midPicturePath), AppConfiguration.ItemImageMedMaxWidth, AppConfiguration.ItemImageMedMaxHeight, ImageFormat.Jpeg);
                Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"), Server.MapPath(FileName), AppConfiguration.ItemImageFullMaxWidth, AppConfiguration.ItemImageFullMaxWidth, ImageFormat.Jpeg);

                //xóa file tạm
                if (File.Exists(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg")))
                    File.Delete(Server.MapPath(myUploadHandler.VirtualSavePath + "temp.jpg"));

                ProductImagesBF.Insert(0, ProductID, smallPicturePath, midPicturePath, FileName);

            }
            catch { }
        }

        return ret;
    }

    string UploadForNewProduct(WebControls.UploadButtonEventArgs e)
    {
        string ret = "";

        string dir = "~/Temp/" + this.User.Identity.Name + "/ItemImage/";

        if (!Directory.Exists(Server.MapPath(dir)))
        {
            Directory.CreateDirectory(Server.MapPath(dir));
        }

        //mỗi sản phẩm chỉ được upload ko quá 8 ảnh minh họa
        string[] files = Directory.GetFiles(Server.MapPath(dir));
        if (files.Length >= 8)
            return "error";

        Zensoft.Website.Toolkit.UploadHandler myUploadHandler;
        myUploadHandler = new Zensoft.Website.Toolkit.UploadHandler();
        myUploadHandler.GenerateUniqueFileName = true;
        myUploadHandler.AllowedExtensions = AppConfiguration.AllowExtension;
        myUploadHandler.VirtualSavePath = dir;

        try
        {
            myUploadHandler.UploadFile(e.FileUploadControl);
        }
        catch { }

        return ret;
    }


    public string FileName
    {
        get
        {
            if (ViewState["FileName"] != null)
                return ViewState["FileName"].ToString();
            else
                return String.Empty;
        }
        private set
        {
            ViewState["FileName"] = value;
        }

    }

    protected string UploadButton1_UploadClick(object sender, WebControls.UploadButtonEventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request["ProductID"]) && this.Request["ProductID"] != "0")
        {
            int productId;

            int.TryParse(this.Request["ProductID"], out productId);

            ProductsBF product = ProductsBF.GetProductsBF(productId);

            if (product == null || (product.AddedBy != this.Page.User.Identity.Name && !this.Page.User.IsInRole("Administrators")))
                Response.Redirect("~/error.aspx?code=404");

            return UploadForProduct(e);

        }
        else
        {
            return UploadForNewProduct(e);
        }
    }
}