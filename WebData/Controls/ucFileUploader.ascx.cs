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

    public partial class FileUploader : System.Web.UI.UserControl
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
        protected string UploadButton1_UploadClick(object sender, WebControls.UploadButtonEventArgs e)
        {
            string ret;

            if (e.FileUploadControl.PostedFile != null && e.FileUploadControl.PostedFile.ContentLength > 0)
            {
                if (this.Page.User.IsInRole("Administrators") || e.FileUploadControl.PostedFile.ContentLength <= 500000) //500k
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
                            string dirPath = Server.MapPath(dirUrl);
                            if (!Directory.Exists(dirPath))
                                Directory.CreateDirectory(dirPath);

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

                            ret = e.FileUploadControl.PostedFile.FileName +" -> "+ existFile;// file được lưu thành công
                        }
                        catch (Exception ex)
                        {
                            if (this.Page.User.IsInRole("Administrators")) // chỉ admin mới được xem lỗi
                                ret = ex.Message;
                            else
                                ret = e.FileUploadControl.PostedFile.FileName +" -> " + "Có lỗi trong quá trình đưa file lên server";
                        }
                    }
                    else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Định dạng file không phải là file ảnh";
                }
                else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "File bạn đưa lên quá lớn. dung lượng file không được quá 500k";
            }
            else ret = e.FileUploadControl.PostedFile.FileName + " -> " + "Bạn chưa chọn file.";

            return ret;
        }
    }
