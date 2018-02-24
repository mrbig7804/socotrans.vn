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
using System.IO;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Toolkit;
using Zensoft.Website;
using System.Drawing.Imaging;
using System.Security;
using Zensoft.Website.Configuration;

public partial class adm_ucUploadProductPicture : System.Web.UI.UserControl
{
    protected int _productID;
    public int ProductID
    {
        get
        {
            return _productID;
        }
        set
        {
            _productID = value;
            this.DataBind();
        }
    }

    protected override void OnInit(EventArgs e)
    {
        Page.RegisterRequiresControlState(this);
        base.OnInit(e);
    }

    protected override void LoadControlState(object savedState)
    {
        object[] ctlState = (object[])savedState;
        base.LoadControlState(ctlState[0]);
        this.ProductID = (int)ctlState[1];
    }

    protected override object SaveControlState()
    {
        object[] ctlState = new object[2];
        ctlState[0] = base.SaveControlState();
        ctlState[1] = this.ProductID;
        return ctlState;
    }
    protected void Page_Load(object sender, EventArgs e)
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
        string ret ="";


        Zensoft.Website.Toolkit.UploadHandler myUploadHandler;
        myUploadHandler = new Zensoft.Website.Toolkit.UploadHandler();
        myUploadHandler.GenerateUniqueFileName = true;
        myUploadHandler.AllowedExtensions = AppConfiguration.AllowExtension;

        myUploadHandler.VirtualSavePath = "~/Attachs/Items/" + ProductID.ToString() + "/Preview/"; // ApplicationSettingsGroup Configuration.TempImagesFolder;

        try
        {
            myUploadHandler.UploadFile(e.FileUploadControl);
        }
        catch (ArgumentException )
        {

            //switch  (aex.ParamName.ToLower())
            //{
            //    case  "extension":
            //      lblIllegalExtension.Visible = true;
            //    case "filename":
            //      lblFileName.Visible =true;
            //    case "myfileupload":
            //      lblNoFile.Visible = true;
            //}
        }
        catch (Exception )
        {
            //lblErrorMessageUnknownError.Visible = false;
        }


        try
        {
            
            FileName = Path.Combine(myUploadHandler.VirtualSavePath, myUploadHandler.FileName) + myUploadHandler.Extension;
            string smallPicturePath = Path.Combine(myUploadHandler.VirtualSavePath, Guid.NewGuid().ToString()) + myUploadHandler.Extension;
            string midPicturePath = Path.Combine(myUploadHandler.VirtualSavePath, Guid.NewGuid().ToString()) + myUploadHandler.Extension;

            //if (AppConfiguration.ItemImagePreviewCrop)
            //{

            //    Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(smallPicturePath),);
            //}



            Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(FileName), AppConfiguration.ItemImageFullMaxWidth, AppConfiguration.ItemImageFullMaxHeight);
            Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(FileName), Server.MapPath(midPicturePath), AppConfiguration.ItemImageMedMaxWidth, AppConfiguration.ItemImageMedMaxHeight, ImageFormat.Jpeg);
            Zensoft.Website.Toolkit.Imaging.ResizeCropImage(Server.MapPath(FileName), Server.MapPath(smallPicturePath), AppConfiguration.ItemImagePreviewMaxWidth, AppConfiguration.ItemImagePreviewMaxHeight);

            ProductImagesBF.Insert(0, ProductID, smallPicturePath, midPicturePath, FileName);

            //imgUploaded.ImageUrl = FileName;
            //plcUpload.Visible = false;
            //plcImage.Visible = true;
        }
        catch (ArgumentException )
        {
            //lblErrorMessageIllegalFile.Visible = true;
        }
        catch (Exception )
        {
            //lblErrorMessageUnknownError.Visible = true;
        }


        return ret;
    }

    protected string UploadButton1_UploadClick(object sender, WebControls.UploadButtonEventArgs e)
    {

        if (!string.IsNullOrEmpty(this.Request["ProductID"]))
        {
            int productId;
            int.TryParse(this.Request["ProductID"], out productId);

            ProductsBF product = ProductsBF.GetProductsBF(productId);

            if (product == null || product.AddedBy != this.Page.User.Identity.Name)
                Response.Redirect("~/error.aspx?code=404");

            return UploadForProduct(e);

        }
        else
        {
            //Response.Redirect("~/error.aspx?code=404");
            return "";
        }

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
}
