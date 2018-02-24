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


using System.Drawing.Imaging;
using System.Drawing;

using Zensoft.Website.Utilities;

public partial class GenImage :  Zensoft.Website.UI.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageVerify cI = new ImageVerify();
        string sTxt = cI.getRandomAlphaNumeric();
        Bitmap bmp = cI.generateImage(sTxt);

        Response.ContentType = "image/gif";
        bmp.Save(Response.OutputStream, ImageFormat.Gif);

        bmp.Dispose();

        Session.Add("VerifyFeedback",sTxt);
    }
}
