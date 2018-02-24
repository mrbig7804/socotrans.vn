using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for Permissions
/// </summary>
/// 
namespace Zensoft.Website.Security
{
    public class Permissions
    {
        public Permissions()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        /// <summary>
        /// Xác thực tài khoản có quyền administrators
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsAdministrator(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        /// <summary>
        /// Xác thực tài khoản có quyền member
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsMember(string userName)
        {
            return Roles.IsUserInRole(userName, "Members");
        }

        /// <summary>
        /// Xác thực tài khoản có quyền visit
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool IsVisit(string userName)
        {
            return Roles.IsUserInRole(userName, "Visit");
        }

        /// <summary>
        /// Xác thực tài khoản có quyền thay đổi thông tin sản phẩm
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool ProductEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators") || Roles.IsUserInRole(userName, "Members");
        }

        /// <summary>
        /// Xác thực tài khoản có quyền duyệt sản phẩm
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool ProductApprovedPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        /// <summary>
        /// Xác thực tài khoản có quyền thay đổi thông tin bài viết
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool ArticlesEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        /// <summary>
        /// Xác thực tài khoản có quyền duyệt bài viết
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool ArticlesApprovedPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators") || Roles.IsUserInRole(userName, "Administrators");
        }

        public static bool ArticleHighlightsBrowserPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "administrators") || Roles.IsUserInRole(userName, "Editors");
        }

        public static bool ArticleHighlightsEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators") || Roles.IsUserInRole(userName, "Editors");
        }

        public static bool CategoriesBrowsePermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators") || Roles.IsUserInRole(userName, "Editors");
        }

        public static bool CategoriesEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators") || Roles.IsUserInRole(userName, "Editors");
        }

        public static bool UsersBrowsePermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        public static bool UsersEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        public static bool FeedbacksBrowsePermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        public static bool FeedbacksEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        protected bool PoolsBrowsePermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        public static bool PoolsEditPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Administrators");
        }

        public static bool PostImageApprovedPermission(string userName)
        {
            return Roles.IsUserInRole(userName, "Members") || Roles.IsUserInRole(userName, "Administrators");
        }
    }
}
