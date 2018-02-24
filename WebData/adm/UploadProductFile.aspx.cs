using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security;
using System.IO;
using Zensoft.Website.Configuration;

public partial class adm_UploadProductFile : Zensoft.Website.UI.BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Không cho phép người dùng lạc danh dùng điều khiển này
        if (!this.Page.User.Identity.IsAuthenticated)
            throw new SecurityException("Phải đăng nhập để có thể upload file.");
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

        if (e.FileUploadControl.PostedFile == null || e.FileUploadControl.PostedFile.ContentLength == 0)
        {
            return "Bạn chưa chọn file.";
        }

        if (this.Page.User.IsInRole("Administrators") ||
            e.FileUploadControl.PostedFile.ContentLength <= AppConfiguration.MaxSizeUploadFile)
        {

            Zensoft.Website.Toolkit.UploadHandler myUploadHandler;

            myUploadHandler = new Zensoft.Website.Toolkit.UploadHandler();
            myUploadHandler.GenerateUniqueFileName = false;
            //myUploadHandler.FileName= 
            myUploadHandler.AllowedExtensions = AppConfiguration.AllowExtension;
            myUploadHandler.VirtualSavePath = "~/Attachs/Items/" + this.Request["ProductID"].ToString() + "/"; // ApplicationSettingsGroup Configuration.TempImagesFolder;

            try
            {
                myUploadHandler.UploadFile(e.FileUploadControl);

                string fileName = Path.Combine(myUploadHandler.VirtualSavePath, myUploadHandler.FileName) + myUploadHandler.Extension;

                //ret = fileName.Replace("~/", this.FullBaseUrl);// file được lưu thành công;

                ret = fileName.Replace("~/", "/");// file được lưu thành công;
            }
            catch (ArgumentException aex)
            {
                ret = aex.Message;
            }
            catch (Exception ex)
            {
                if (this.Page.User.IsInRole("Administrators")) // chỉ admin mới được xem lỗi
                    ret = ex.Message;
                else
                    ret = "Có lỗi trong quá trình đưa file lên server";
            }
        }
        else
        {
            ret = "Bạn upload file có kích thước quá lớn. Bạn hãy thử lại với kích thước file nhỏ hơn " + AppConfiguration.MaxSizeUploadFile.ToString() + " byte.";
        }

        return "<input type='text' value='" + ret + "' class='txt' />";
    }

    string UploadForQuiz(WebControls.UploadButtonEventArgs e)
    {
        string ret = "";

        if (e.FileUploadControl.PostedFile == null || e.FileUploadControl.PostedFile.ContentLength == 0)
        {
            return "Bạn chưa chọn file.";
        }

        if (this.Page.User.IsInRole("Administrators") ||
            e.FileUploadControl.PostedFile.ContentLength <= AppConfiguration.MaxSizeUploadFile)
        {

            Zensoft.Website.Toolkit.UploadHandler myUploadHandler;

            myUploadHandler = new Zensoft.Website.Toolkit.UploadHandler();
            myUploadHandler.GenerateUniqueFileName = false;
            //myUploadHandler.FileName= 
            myUploadHandler.AllowedExtensions = AppConfiguration.AllowExtension;
            myUploadHandler.VirtualSavePath = "~/Attachs/Quiz/" + this.Request["questionID"].ToString() + "/"; // ApplicationSettingsGroup Configuration.TempImagesFolder;

            try
            {
                myUploadHandler.UploadFile(e.FileUploadControl);

                string fileName = Path.Combine(myUploadHandler.VirtualSavePath, myUploadHandler.FileName) + myUploadHandler.Extension;

                ret = fileName.Replace("~/", this.FullBaseUrl);// file được lưu thành công;
            }
            catch (ArgumentException aex)
            {
                ret = aex.Message;
            }
            catch (Exception ex)
            {
                if (this.Page.User.IsInRole("Administrators")) // chỉ admin mới được xem lỗi
                    ret = ex.Message;
                else
                    ret = "Có lỗi trong quá trình đưa file lên server";
            }
        }
        else
        {
            ret = "Bạn upload file có kích thước quá lớn. Bạn hãy thử lại với kích thước file nhỏ hơn " + AppConfiguration.MaxSizeUploadFile.ToString() + " byte.";
        }

        return e.FileUploadControl.FileName + "<br/> -> <b>" + ret + "<b>";
    }

    string UploadFile(WebControls.UploadButtonEventArgs e)
    {

        string ret;

        if (e.FileUploadControl.PostedFile != null && e.FileUploadControl.PostedFile.ContentLength > 0)
        {
            if (this.Page.User.IsInRole("Administrators") || e.FileUploadControl.PostedFile.ContentLength <= Zensoft.Website.Configuration.AppConfiguration.MaxSizeUploadFile) //100k
            {
                if (this.Page.User.IsInRole("Administrators") ||
                    e.FileUploadControl.PostedFile.ContentType == "image/jpeg" ||
                    e.FileUploadControl.PostedFile.ContentType == "image/pjpeg" ||
                    e.FileUploadControl.PostedFile.ContentType == "image/bmp" ||
                    e.FileUploadControl.PostedFile.ContentType == "image/gif" ||
                    e.FileUploadControl.PostedFile.ContentType == "application/x-shockwave-flash" ||
                    e.FileUploadControl.PostedFile.ContentType == "image/x-png" ||
                    e.FileUploadControl.PostedFile.ContentType == "image/png"
                    )
                {
                    try
                    {
                        // Nếu chưa tồn tại đường dẫn thì tạo mới dường dẫn
                        string dirUrl =
                           "~/Uploads/" + this.Page.User.Identity.Name;
                        dirUrl += "/" + DateTime.Now.ToString("yyMMdd");



                        string dirPath = Server.MapPath(dirUrl);
                        if (!Directory.Exists(dirPath))
                            Directory.CreateDirectory(dirPath);

                        //kiểm tra kích thước thư mục
                        DirectoryInfo d = new DirectoryInfo(dirPath);
                        double size = DirSize(d);

                        if (this.Page.User.IsInRole("Administrators") || (size < 500000))// chỉ cho phép 1 ngày upload 500k
                        {

                            // lấy tên file
                            string fileUrl = dirUrl + "/" + Path.GetFileName(e.FileUploadControl.PostedFile.FileName);

                            int i = 0;
                            string existFile = fileUrl;
                            string filename = fileUrl.Substring(0, fileUrl.LastIndexOf("."));
                            string fileExtention = fileUrl.Substring(fileUrl.LastIndexOf("."), fileUrl.Length - fileUrl.LastIndexOf("."));

                            //thử xem đã tồn tại file trùng tên ko
                            while (File.Exists(Server.MapPath(existFile)))
                            {
                                i++;
                                existFile = filename + "(" + i.ToString() + ")" + fileExtention;
                            }

                            e.FileUploadControl.PostedFile.SaveAs(Server.MapPath(existFile));

                            ret = e.FileUploadControl.PostedFile.FileName + " -> " + existFile;// file được lưu thành công
                        }
                        else
                        {
                            ret = ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn đã upload quá nhiều ảnh trong 1 ngày, hãy thử upload lại vào ngày mai. Rất xin lỗi vì sự phiền phức này";
                        }
                    }
                    catch (Exception ex)
                    {
                        if (this.Page.User.IsInRole("Administrators")) // chỉ admin mới được xem lỗi
                            ret = ex.Message;
                        else
                            ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Có lỗi trong quá trình đưa file lên server";
                    }
                }
                else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Định dạng file không phải là file ảnh";
            }
            else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "File bạn đưa lên quá lớn. dung lượng file không được quá 100k";
        }
        else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn chưa chọn file.";

        return ret;
    }

    protected string UploadButton1_UploadClick(object sender, WebControls.UploadButtonEventArgs e)
    {
        if (!string.IsNullOrEmpty(this.Request["ProductID"]))
        {
            return UploadForProduct(e);
        }
        else if (!string.IsNullOrEmpty(this.Request["questionID"]))
        {
            return UploadForQuiz(e);
        }
        else
            return UploadFile(e);
    }
}