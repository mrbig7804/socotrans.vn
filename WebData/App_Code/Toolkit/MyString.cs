using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Zensoft.Website.Toolkit
{

    /// <summary>
    /// Summary description for MyString
    /// </summary>
    public class MyString
    {
        public MyString()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static string ConvertToJavascriptSting(string s)
        {
            string ret = s;

            ret = ret.Trim().Replace("\"", "&quot;"); 
            ret = ret.Replace("'", "&apos;"); 
            ret = ret.Replace("&", "&amp"); 
            ret = ret.Replace(">", "&gt");
            ret = ret.Replace("<", "&lt");
            ret = ret.Replace("\r\n", "<br/>"); 

            return ret;
        }
    }
}
