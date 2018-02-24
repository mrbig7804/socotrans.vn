using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;

/// <summary>
/// Summary description for AppConfiguration
/// </summary>
namespace Zensoft.Website.Configuration
{
    public class AppConfiguration
    {
		private System.Xml.XmlNode m_section;

        public AppConfiguration(System.Xml.XmlNode node)
		{
			m_section = node;
		}

		public string this [string key]
		{
			get
			{
				System.Xml.XmlNode node = m_section.SelectSingleNode( key );
				if ( node != null )
					return node.InnerText;
				else
					return null;
			}
		}

        static private AppConfiguration configSection
		{
			get
			{
                AppConfiguration config = (AppConfiguration)System.Configuration.ConfigurationManager.GetSection("zensoft");
				if ( config == null )
				{
					if ( System.Web.HttpContext.Current == null )
						throw new ApplicationException( "Loi he thong." );
					else
						throw new ApplicationException( "Khong tim thay Web.config." );
				}
				return config;
			}
		}

        static public AppConfiguration ZensoftSection
		{
			get
			{
				return configSection;
			}
		}

        public static void WriteSetting(string key, string value)
        {
            // load config document for current assembly
            XmlDocument doc = loadConfigDocument();

            // retrieve appSettings node
            XmlNode node = doc.SelectSingleNode("//" + key);

            if (node == null)
                throw new InvalidOperationException("appSettings section not found in config file.");

            try
            {
                node.InnerText = value;

                doc.Save(getConfigFilePath());
            }
            catch
            {
                throw;
            }
        }

        private static XmlDocument loadConfigDocument()
        {
            XmlDocument doc = null;
            try
            {
                doc = new XmlDocument();
                doc.Load(getConfigFilePath());
                return doc;
            }
            catch (System.IO.FileNotFoundException e)
            {
                throw new Exception("No configuration file found.", e);
            }
        }

        private static string getConfigFilePath()
        {
            //return Assembly.GetExecutingAssembly().Location + ".config";
            return HttpContext.Current.Server.MapPath("~/zensoft.config");
        }

        static public long MaxSizeUploadFile
        {
            get
            {
                return Convert.ToInt64(configSection["maxSizeUploadFile"]);
            }
        }
        static public long MaxSizeUploadPerArticle
        {
            get
            {
                return Convert.ToInt64(configSection["maxSizeUploadPerArticle"]);
            }
        }

        static public string AllowExtension
        {
            get
            {
                return configSection["allowExtension"];
            }
        }

        static public bool RedirectDomain
        {
            get
            {
                return Convert.ToBoolean(Convert.ToInt32(configSection["redirectDomain"]));
            }
        }

        //------------------------------------------------
        static public bool ArticleImagePreviewCrop
        {
            get
            {
                return Convert.ToBoolean(configSection["ArticleImagePreviewCrop"]);
            }
        }
        static public string ArticleImagePreviewResize
        {
            get
            {
                return configSection["ArticleImagePreviewResize"];
            }
        }
        static public int ArticleImagePreviewMaxWidth
        {
            get
            {
                return Convert.ToInt32(configSection["ArticleImagePreviewMaxWidth"]);
            }
        }
        static public int ArticleImagePreviewMaxHeight
        {
            get
            {
                return Convert.ToInt32(configSection["ArticleImagePreviewMaxHeight"]);
            }
        }

        //------------------------------------------------
        static public bool ItemImagePreviewCrop
        {
            get
            {
                return Convert.ToBoolean(configSection["ItemImagePreviewCrop"]);
            }
        }
        static public string ItemImagePreviewResize
        {
            get
            {
                return configSection["ItemImagePreviewResize"];
            }
        }
        static public int ItemImagePreviewMaxWidth
        {
            get
            {
                return Convert.ToInt32(configSection["ItemImagePreviewMaxWidth"]);
            }
        }
        static public int ItemImagePreviewMaxHeight
        {
            get
            {
                return Convert.ToInt32(configSection["ItemImagePreviewMaxHeight"]);
            }
        }


        //------------------------------------------------
        static public bool ItemImageMedCrop
        {
            get
            {
                return Convert.ToBoolean(configSection["ItemImageMedCrop"]);
            }
        }
        static public string ItemImageMedResize
        {
            get
            {
                return configSection["ItemImageMedResize"];
            }
        }
        static public int ItemImageMedMaxWidth
        {
            get
            {
                return Convert.ToInt32(configSection["ItemImageMedMaxWidth"]);
            }
        }
        static public int ItemImageMedMaxHeight
        {
            get
            {
                return Convert.ToInt32(configSection["ItemImageMedMaxHeight"]);
            }
        }
        //------------------------------------------------
        static public bool ItemImageFullCrop
        {
            get
            {
                return Convert.ToBoolean(configSection["ItemImageFullCrop"]);
            }
        }
        static public string ItemImageFullResize
        {
            get
            {
                return configSection["ItemImageFullResize"];
            }
        }
        static public int ItemImageFullMaxWidth
        {
            get
            {
                return Convert.ToInt32(configSection["ItemImageFullMaxWidth"]);
            }
        }
        static public int ItemImageFullMaxHeight
        {
            get
            {
                return Convert.ToInt32(configSection["ItemImageFullMaxHeight"]);
            }
        }

        //------------------------------------------------
        static public int SlideshowWidth
        {
            get
            {
                return Convert.ToInt32(configSection["SlideshowWidth"]);
            }
        }
        static public int SlideshowHeight
        {
            get
            {
                return Convert.ToInt32(configSection["SlideshowHeight"]);
            }
        }

        //------------------------------------------------
        static public int BrandWidth
        {
            get
            {
                return Convert.ToInt32(configSection["BrandWidth"]);
            }
        }
        static public int BrandHeight
        {
            get
            {
                return Convert.ToInt32(configSection["BrandHeight"]);
            }
        }

        //------------------------------------------------
        static public int AlbumImagePreviewWidth
        {
            get
            {
                return Convert.ToInt32(configSection["AlbumImagePreviewWidth"]);
            }
        }
        static public int AlbumImagePreviewHeight
        {
            get
            {
                return Convert.ToInt32(configSection["AlbumImagePreviewHeight"]);
            }
        }

        //------------------------------------------------
        static public int AlbumImageMainWidth
        {
            get
            {
                return Convert.ToInt32(configSection["AlbumImageMainWidth"]);
            }
        }
        static public int AlbumImageMainHeight
        {
            get
            {
                return Convert.ToInt32(configSection["AlbumImageMainHeight"]);
            }
        }

        private static string _promotionOrder = "0";
        static public string PromotionOrder
        {
            get
            {
                if (_promotionOrder == "0") _promotionOrder = configSection["PromotionOrder"];
                return _promotionOrder;
            }
            set
            {
                AppConfiguration.WriteSetting("PromotionOrder", value);
                _promotionOrder = value;
            }
        }

        //------------------------------------------------
        static public int ProductDepartmentWidth
        {
            get
            {
                return Convert.ToInt32(configSection["ProductDepartmentWidth"]);
            }
        }
        static public int ProductDepartmentHeight
        {
            get
            {
                return Convert.ToInt32(configSection["ProductDepartmentHeight"]);
            }
        }

        //------------------------------------------------
        static public int ArticleCategoryWidth
        {
            get
            {
                return Convert.ToInt32(configSection["ArticleCategoryWidth"]);
            }
        }
        static public int ArticleCategoryHeight
        {
            get
            {
                return Convert.ToInt32(configSection["ArticleCategoryHeight"]);
            }
        }

        //------------------------------------------------
        private static bool _itemImageWatemark;
        static public bool ItemImageWatemark
        {
            get
            {
                return Convert.ToBoolean(configSection["ItemImageWatemark"]);
            }
            set
            {
                AppConfiguration.WriteSetting("ItemImageWatemark", value.ToString());
                _itemImageWatemark = value;

            }
        }
        static public string ItemImageWatemarkPath
        {
            get
            {
                return configSection["ItemImageWatemarkPath"];
            }
        }

        //-------------
        static public string Email {
            get {
                return configSection["Email"];
            }
        }
        static public string UrlSuccess {
            get
            {
                return configSection["UrlSuccess"];
            }
        }
        static public string UrlCancel
        {
            get
            {
                return configSection["UrlCancel"];
            }
        }

        //-------------INFO FOOTER
        private static string _footerName = "";
        static public string FooterName
        {
            get
            {
                if (_footerName == "") _footerName = configSection["FooterName"];
                return _footerName;
            }
            set
            {
                AppConfiguration.WriteSetting("FooterName", value);
                _footerName = value;
            }
        }

        private static string _footerAdd = "";
        static public string FooterAdd
        {
            get
            {
                if (_footerAdd == "") _footerAdd = configSection["FooterAdd"];
                return _footerAdd;
            }
            set
            {
                AppConfiguration.WriteSetting("FooterAdd", value);
                _footerAdd = value;
            }
        }

        private static string _footerPhone = "";
        static public string FooterPhone
        {
            get
            {
                if (_footerPhone == "") _footerPhone = configSection["FooterPhone"];
                return _footerPhone;
            }
            set
            {
                AppConfiguration.WriteSetting("FooterPhone", value);
                _footerPhone = value;
            }
        }

        private static string _footerEmail = "";
        static public string FooterEmail
        {
            get
            {
                if (_footerEmail == "") _footerEmail = configSection["FooterEmail"];
                return _footerEmail;
            }
            set
            {
                AppConfiguration.WriteSetting("FooterEmail", value);
                _footerEmail = value;
            }
        }

        private static string _footerWeb = "";
        static public string FooterWeb
        {
            get
            {
                if (_footerWeb == "") _footerWeb = configSection["FooterWeb"];
                return _footerWeb;
            }
            set
            {
                AppConfiguration.WriteSetting("FooterWeb", value);
                _footerWeb = value;
            }
        }

        private static string _footerFace = "";
        static public string FooterFace
        {
            get
            {
                if (_footerFace == "") _footerFace = configSection["FooterFace"];
                return _footerFace;
            }
            set
            {
                AppConfiguration.WriteSetting("FooterFace", value);
                _footerFace = value;
            }
        }

    }
}
