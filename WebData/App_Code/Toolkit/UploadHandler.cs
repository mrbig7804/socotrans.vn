using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.IO;
using System.Text.RegularExpressions;

namespace Zensoft.Website.Toolkit
{
    public class UploadHandler
    {

        private String _virtualSavePath = String.Empty;
        private bool _overwriteExistingFile = false;
        private String _allowedExtensions = String.Empty;
        private String _fileName = String.Empty;
        private String _extension = String.Empty;
        private String _newDateFolder = String.Empty;
        private bool _generateUniqueFileName = false;
        private bool _generateDateFolder = false;
        private String _physicalFolderAndFileName = String.Empty;

        public UploadHandler()
        {
        }

        public void UploadFile(FileUpload myFileUpload)
        {
            if (myFileUpload.HasFile)
            {
                if (_generateUniqueFileName)
                    _fileName = Guid.NewGuid().ToString();
                else if (string.IsNullOrEmpty(_fileName))
                {
                    _fileName = Path.GetFileNameWithoutExtension(myFileUpload.FileName);
                }


                _extension = System.IO.Path.GetExtension(myFileUpload.PostedFile.FileName);

                if (_virtualSavePath == String.Empty)
                {
                    throw new ArgumentException("Không tìm thấy đường dẫn để upload.", "VirtualSavePath");
                }

                if (_generateDateFolder)
                {
                    _virtualSavePath += DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString().PadLeft(2, '0');
                }

                _physicalFolderAndFileName = Path.Combine(HttpContext.Current.Server.MapPath(_virtualSavePath), _fileName);
                _physicalFolderAndFileName += Extension;

                if (_overwriteExistingFile == false)
                {
                    if (FileExists(_physicalFolderAndFileName))
                    {
                        throw new ArgumentException("File " + _fileName + " đã tồn tại bạn hãy chọn 1 tên file khác.");
                    }
                }

                if (!IsExtensionAllowed())
                    throw new ArgumentException("Đinh dạng của File không phù hợp. Bản hãy thử lại với các file có phân mở rộng là" + _allowedExtensions);


                try
                {
                    string myFolder = Path.GetDirectoryName(_physicalFolderAndFileName);
                    if (!Directory.Exists(myFolder))
                        Directory.CreateDirectory(myFolder);

                    myFileUpload.PostedFile.SaveAs(_physicalFolderAndFileName);
                }
                catch (UnauthorizedAccessException uaex)
                {
                    throw uaex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else throw new ArgumentException("Không tìm thấy file để upload");
        }

        private bool IsExtensionAllowed()
        {
            Boolean tempResult = true;
            if (!string.IsNullOrEmpty(_allowedExtensions))
                try
                {
                    tempResult = Regex.IsMatch(_extension, _allowedExtensions, RegexOptions.IgnoreCase);
                }
                catch
                {
                    tempResult = false;
                }

            return tempResult;
        }

        private bool FileExists(string myFileName)
        {
            return System.IO.File.Exists(myFileName);
        }

        #region "Public Properties"

        public string VirtualSavePath
        {
            get
            {
                return _virtualSavePath;
            }
            set
            {
                value = value.Replace("\\", "/");

                if (!value.EndsWith("/"))
                    value += "/";

                _virtualSavePath = value;
            }
        }

        public bool OverwriteExistingFile
        {
            get
            {
                return _overwriteExistingFile;
            }

            set
            {
                _overwriteExistingFile = value;
            }
        }

        public string AllowedExtensions
        {
            get
            {
                return _allowedExtensions;
            }
            set
            {
                _allowedExtensions = value;
            }
        }

        public string FileName
        {
            get
            {
                return _fileName;
            }
            set
            {

                if (value.LastIndexOf(".") > 0)
                    value = value.Substring(0, value.LastIndexOf("."));

                _fileName = value;
            }
        }

        public string Extension
        {
            get
            {
                return _extension;
            }
        }

        public bool GenerateUniqueFileName
        {
            get
            {
                return _generateUniqueFileName;
            }

            set
            {
                _generateUniqueFileName = value;
            }
        }

        public bool GenerateDateFolder
        {
            get
            {
                return _generateDateFolder;
            }
            set
            {
                _generateDateFolder = value;
            }
        }

        #endregion

    }
}

