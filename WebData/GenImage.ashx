<%@ WebHandler Language="C#" Class="GenImage" %>

using System;
using System.Web;

using System.Drawing.Imaging;
using System.Drawing;

using Zensoft.Website.Utilities;

public class GenImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        
        ImageVerify cI = new ImageVerify();
        string sTxt = cI.getRandomAlphaNumeric();
        Bitmap bmp = cI.generateImage(sTxt);

        context.Response.ContentType = "image/gif";
        bmp.Save(context.Response.OutputStream, ImageFormat.Gif);

        bmp.Dispose();
        
        context.Session["VerifyFeedback"] =  sTxt;
    }
 
    public bool IsReusable {
        get {
            return true;
        }
    }

}