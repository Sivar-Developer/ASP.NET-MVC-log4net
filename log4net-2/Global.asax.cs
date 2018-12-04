using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace log4net_2
{
    public class MvcApplication : System.Web.HttpApplication
    {

        private static readonly log4net.ILog log = LogHelper.GetLogger(); // log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public class LogHelper
        {
            public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
            {
                return log4net.LogManager.GetLogger(filename);
            }
        }

        protected void Application_Error(Object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();

            // Stop error from displaying on the client browser
            Context.ClearError();

            log.Fatal(ex.ToString());
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
