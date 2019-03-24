using System;
using System.Collections.Generic;
using System.Linq;
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
            //PER RISOLVERE IL PROBLEMA DEL CORS - SE SI LAVORA CON PIU PROGETTI NELLA STESSA SOLUZIOME
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
