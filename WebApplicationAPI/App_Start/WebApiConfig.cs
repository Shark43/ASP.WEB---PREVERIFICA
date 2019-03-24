using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebApplicationAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Servizi e configurazione dell'API Web

            // Route dell'API Web
            config.MapHttpAttributeRoutes();
            //Vieni disabilitato il cors per problemi sul protocollo "file://" utilizzato da visualstudio
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            //IMPOSTA COME DEFAULT JSON AL POSTO DI XML
            //COSI NON è PIù OBBLIGATORIO USARE IHttpActionResult MA SI PUò USARE DIRETTAMENTE LIST<NOMECLASSE>
            GlobalConfiguration.Configuration.Formatters.Clear();
            GlobalConfiguration.Configuration.Formatters.Add(new JsonMediaTypeFormatter());
                
        }
    }
}
