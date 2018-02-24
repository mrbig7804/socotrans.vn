using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Zensoft.Website.BusinessLayer.BusinessFacade;
using Zensoft.Website.Configuration;
using System.IO;
using System.Drawing.Imaging;

public partial class adm_ReloadPictures : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        List<ProductImagesBF> images =  ProductImagesBF.GetProductImagesAll();

        foreach (ProductImagesBF image in images)
        {
            string path = "~/Attachs/Items/" + image.ProductID.ToString() + "/Preview/"; // ApplicationSettingsGroup Configuration.TempImagesFolder;

            //FileInfo file = new FileInfo(Server.MapPath(image.FullImage));

            if(!Directory.Exists(Server.MapPath(path)))
                Directory.CreateDirectory(Server.MapPath(path));
            
            string FileName =  image.FullImage;

            if (File.Exists(Server.MapPath(FileName)))
            {

                string smallPicturePath = Path.Combine(path, Guid.NewGuid().ToString()) + ".jpg";
                string midPicturePath = Path.Combine(path, Guid.NewGuid().ToString()) + ".jpg";

                Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(FileName), AppConfiguration.ItemImageFullMaxWidth, AppConfiguration.ItemImageFullMaxHeight);
                Zensoft.Website.Toolkit.Imaging.ResizeImage(Server.MapPath(FileName), Server.MapPath(midPicturePath), AppConfiguration.ItemImageMedMaxWidth, AppConfiguration.ItemImageMedMaxHeight, ImageFormat.Jpeg);
                Zensoft.Website.Toolkit.Imaging.ResizeCropImage(Server.MapPath(FileName), Server.MapPath(smallPicturePath), AppConfiguration.ItemImagePreviewMaxWidth, AppConfiguration.ItemImagePreviewMaxHeight);

                if (File.Exists(Server.MapPath(image.SmallImage)))
                    File.Delete(Server.MapPath(image.SmallImage));

                if (File.Exists(Server.MapPath(image.MedImage)))
                    File.Delete(Server.MapPath(image.MedImage));


                image.MedImage = midPicturePath;
                image.SmallImage = smallPicturePath;

                image.Update();

                ProductsBF product = ProductsBF.GetProductsBF(image.ProductID);
                product.SmallPictureUrl = smallPicturePath;

                product.Update();
            }

        }
    }
}