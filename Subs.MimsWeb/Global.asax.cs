using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Subs.Data;

namespace Subs.MimsWeb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Settings.ConnectionString = "Data Source = PKLWEBDB01\\mssql2016std; Initial Catalog = MIMS3; Integrated Security = True; Enlist = False; Pooling = True; Max Pool Size = 10; Connect Timeout = 100";
            Settings.EMailHostIp = "172.15.64.23";
            Settings.DirectoryPath = @"\\PKLWEBDB01\MimsData";
        }
    }
}
