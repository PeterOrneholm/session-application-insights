using System.Web.Http;

namespace Orneholm.Session.ApplicationInsights.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
        }
    }
}