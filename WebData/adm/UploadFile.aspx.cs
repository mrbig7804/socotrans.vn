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

using System.IO;
using System.Security;

public partial class admin_UploadFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Không cho phép người dùng lạc danh dùng điều khiển này
        if (!this.Page.User.Identity.IsAuthenticated)
            throw new SecurityException("Anonymous users cannot upload files.");

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

    string UploadForArticle(WebControls.UploadButtonEventArgs e)
    {
        string ret;

        if (e.FileUploadControl.PostedFile != null && e.FileUploadControl.PostedFile.ContentLength > 0)
        {
            if (this.Page.User.IsInRole("Administrators") || e.FileUploadControl.PostedFile.ContentLength <= 200000) //200k
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
                           "~/Attachs/Articles/" + this.Request["ArticleID"].ToString();

                        string dirPath = Server.MapPath(dirUrl);
                        if (!Directory.Exists(dirPath))
                            Directory.CreateDirectory(dirPath);

                        //kiểm tra kích thước thư mục
                        DirectoryInfo d = new DirectoryInfo(dirPath);
                        double size = DirSize(d);

                        if (this.Page.User.IsInRole("Administrators") || (size < 1000000))// Mỗi bài viết cho phép đính kèm 1000k
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

                            ret = e.FileUploadControl.PostedFile.FileName + " -> <b>" + existFile + "<b/>";// file được lưu thành công
                        }
                        else
                        {
                            ret = ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn đã upload quá nhiều ảnh trong 1 bài viết, bạn nên chia ra thành nhiều phần";
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
            else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "File bạn đưa lên quá lớn. dung lượng file không được quá 200k";
        }
        else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn chưa chọn file.";

        return ret;
    }

    string UploadForProduct(WebControls.UploadButtonEventArgs e)
    {
        string ret;

        if (e.FileUploadControl.PostedFile != null && e.FileUploadControl.PostedFile.ContentLength > 0)
        {
            if (this.Page.User.IsInRole("Administrators") || e.FileUploadControl.PostedFile.ContentLength <= 200000) //200k
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
                           "~/Attachs/Items/" + this.Request["ProductID"].ToString();

                        string dirPath = Server.MapPath(dirUrl);
                        if (!Directory.Exists(dirPath))
                            Directory.CreateDirectory(dirPath);

                        //kiểm tra kích thước thư mục
                        DirectoryInfo d = new DirectoryInfo(dirPath);
                        double size = DirSize(d);

                        if (this.Page.User.IsInRole("Administrators") || (size < 1000000))// Mỗi bài viết cho phép đính kèm 1000k
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

                            ret = e.FileUploadControl.PostedFile.FileName + " -> <b>" + existFile + "<b/>";// file được lưu thành công
                        }
                        else
                        {
                            ret = ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn đã upload quá nhiều ảnh trong 1 bài viết, bạn nên chia ra thành nhiều phần";
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
            else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "File bạn đưa lên quá lớn. dung lượng file không được quá 200k";
        }
        else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn chưa chọn file.";

        return ret;
    }

    string UploadFile(WebControls.UploadButtonEventArgs e)
    {
        
        string ret;

        if (e.FileUploadControl.PostedFile != null && e.FileUploadControl.PostedFile.ContentLength > 0)
        {
            if (this.Page.User.IsInRole("Administrators") || e.FileUploadControl.PostedFile.ContentLength <= 100000) //100k
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
        if (!string.IsNullOrEmpty(this.Request["ArticleID"]))
        {
            return UploadForArticle(e);
        }
        else if (!string.IsNullOrEmpty(this.Request["ProductID"]))
            {
                return UploadForProduct(e);
            }
            else
                return UploadFile(e);
    }
}
