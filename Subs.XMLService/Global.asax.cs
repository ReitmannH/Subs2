using Subs.Data;
using System;

namespace Subs.XMLService
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            string lConnectionString = global::Subs.XMLService.Properties.Settings.Default.ConnectionString;

            if (lConnectionString == "")
            {
                throw new Exception("No connection string has been set.");
            }
            else
            {
                Settings.ConnectionString = lConnectionString;
            }
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception lException = Server.GetLastError();
            if (lException != null)
            {
                ExceptionData.WriteException(1, lException.Message, this.ToString(), "Application Error", "");
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}