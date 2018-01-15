using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace WebApiProxy.Server
{
    public static class WebApiProxyExtensions
    {
        //todo:简单处理,考虑重新设计
        internal static IApiFilter Filter;

        /// <summary>
        /// Sets up the proxy route table entries.
        /// </summary>
        public static void RegisterProxyRoutes(this HttpConfiguration config, string routeTemplate = "api/proxies")
        {
            config.Routes.MapHttpRoute(
                name: "WebApiProxy",
                routeTemplate: routeTemplate,
                defaults: new { id = RouteParameter.Optional },
                constraints: null,
                handler: new ProxyHandler(config) { InnerHandler = new HttpControllerDispatcher(config) }
            );

            //register .js url
            if (!routeTemplate.EndsWith(".js"))
            {
                config.Routes.MapHttpRoute(
                    name: "WebApiProxy.js",
                    routeTemplate: routeTemplate + ".js",
                    defaults: new { id = RouteParameter.Optional },
                    constraints: null,
                    handler: new ProxyHandler(config) { InnerHandler = new HttpControllerDispatcher(config) }
                );
            }
        }

        public static HttpConfiguration RegisterFilter(this HttpConfiguration config, IApiFilter filter)
        {
            Filter = filter;
            return config;
        }
    }
}
