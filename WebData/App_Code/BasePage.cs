using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Zensoft.Website.Configuration;
using Zensoft.Website.BusinessLayer.BusinessFacade;

namespace Zensoft.Website.UI
{
    public class BasePage : System.Web.UI.Page
    {
        protected void CheckRequestValidity( HttpRequest request )
		{
			// ip with 
			// deny access if POST request comes from other server
			if ( request.HttpMethod == "POST" && request.UrlReferrer.Host != request.Url.Host )
			{
				this.Response.Redirect("~/Error.aspx");
			}
		}


        protected override void InitializeCulture()
        {
            //string culture = (HttpContext.Current.Profile as ProfileCommon).Preferences.Culture;
            //this.Culture = culture;
            //this.UICulture = culture;
        }

        protected override void OnPreInit(EventArgs e)
        {
            //string id = Globals.ThemesSelectorID;
            //if (id.Length > 0)
            //{
            //    // Nếu theme được thay đổi bởi ThemeSelector
            //    if (this.Request.Form["__EVENTTARGET"] == id && !string.IsNullOrEmpty(this.Request.Form[id]))
            //    {
            //        this.Theme = this.Request.Form[id];
            //        (HttpContext.Current.Profile as ProfileCommon).Preferences.Theme = this.Theme;
            //    }
            //    else
            //    {
            //        // Trang được lạp lại không phải do ThemeSelector thay đổi 
            //        if (!string.IsNullOrEmpty((HttpContext.Current.Profile as ProfileCommon).Preferences.Theme))
            //            this.Theme = (HttpContext.Current.Profile as ProfileCommon).Preferences.Theme;
            //    }
            //}

            //if ((HttpContext.Current.Profile as ProfileCommon).ShoppingCart == null)
            //    (HttpContext.Current.Profile as ProfileCommon).ShoppingCart = new ShoppingCart();

            base.OnPreInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            // add onfocus and onblur javascripts to all input controls on the forum,
            // so that the active control has a difference appearance
            //Helpers.SetInputControlsHighlight(this, "highlight", false);

            // basic Request Checking (can be easily spoofed)
            CheckRequestValidity(Request);

            base.OnLoad(e);
        }

        public string BaseUrl
        {
            get
            {
                string url = this.Request.ApplicationPath;
                if (url.EndsWith("/"))
                    return url;
                else
                    return url + "/";
            }
        }

        public string FullBaseUrl
        {
            get
            {
                return this.Request.Url.AbsoluteUri.Replace(
                   this.Request.Url.PathAndQuery, "") + this.BaseUrl;
            }
        }

        protected void RequestLogin()
        {
            this.Response.Redirect(FormsAuthentication.LoginUrl +
               "?ReturnUrl=" + this.Request.Url.PathAndQuery);
        }

        //public string FormatPrice(object price)
        //{
        //    return Convert.ToDecimal(price).ToString("N2") + " " + Globals.Settings.Store.CurrencyCode;
        //}
    }
}