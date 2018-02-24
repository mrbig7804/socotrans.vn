using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;
using System.Web.Security;
using System.Security;
using System.Net;


    public class ShowItemRouteHandler : IRouteHandler
    {
        string _virtualPath;
        public ShowItemRouteHandler(string virtualPath)
        {
            _virtualPath = virtualPath;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            if (!UrlAuthorizationModule.CheckUrlAccessForPrincipal(
                _virtualPath, requestContext.HttpContext.User,
                              requestContext.HttpContext.Request.HttpMethod))
            {
                requestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                requestContext.HttpContext.Response.End();
            }

            var display = BuildManager.CreateInstanceFromVirtualPath(
                            _virtualPath, typeof(Page)) as IShowItemDisplay;

            display.ProductTitle = requestContext.RouteData.Values["name"] as string;
            return display;
        }

    }

