using Heroic.Web.IoC;
using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HeroicFramework.SampleWebApp.StructureMapConfig), "Configure")]
namespace HeroicFramework.SampleWebApp
{
	public static class StructureMapConfig
	{
		public static void Configure()
		{
			IoC.Container.Configure(cfg =>
			{
				cfg.Scan(scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
				});

				cfg.AddRegistry(new ControllerRegistry());
				cfg.AddRegistry(new MvcRegistry());
				cfg.AddRegistry(new ActionFilterRegistry(namespacePrefix: "HeroicFramework.SampleWebApp"));

				//Are you using ASP.NET Identity?  If so, you'll probably need to configure some additional services:
				
				//1) Make IUserStore injectable.  Replace 'ApplicationUser' with whatever your Identity user type is.
				//For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
				
				//2) Change AppDbContext to your application's Entity Framework context.
				//For<DbContext>().Use<AppDbContext>();
				
				//3) This will allow you to inject the IAuthenticationManager.  You may not need this, but you will if you 
				//   used the default ASP.NET MVC project template as a starting point!
				//For<IAuthenticationManager>().Use(ctx => ctx.GetInstance<HttpRequestBase>().GetOwinContext().Authentication);

				//TODO: Add other registries and configure your container (if needed)
			});

			var resolver = new StructureMapDependencyResolver();
			DependencyResolver.SetResolver(resolver);
			GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}
	}
}