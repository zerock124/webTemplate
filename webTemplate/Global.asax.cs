using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace webTemplate
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            //沒有以下設定，無法使用WebApi
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_EndRequest(object sender, EventArgs e)
        //{

        //    if (Response.Cookies.Count > 0)
        //    {
        //        foreach (string s in Response.Cookies.AllKeys)
        //        {
        //            Response.Cookies[s].Secure = true;
        //        }
        //    }
        //}
    }
}
