using System.Web.Http;

namespace Orneholm.Session.ApplicationInsights.Web
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}