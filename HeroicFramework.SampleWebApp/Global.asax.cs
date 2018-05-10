using System.Web.Mvc;
using System.Web.Routing;
using Heroic.AutoMapper;
using HeroicFramework.SampleWebApp.Controllers;

namespace HeroicFramework.SampleWebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            HeroicAutoMapperConfigurator.LoadMapsFromAssemblyContainingTypeAndReferencedAssemblies<HomeController>();
        }
    }
}
