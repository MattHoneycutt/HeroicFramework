using Heroic.Web.IoC;
using System.Web.Http;
using System.Web.Mvc;
using StructureMap;
using StructureMap.Graph;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof($rootnamespace$.StructureMapConfig), "Configure")]
namespace $rootnamespace$
{
	public static class StructureMapConfig
	{
		public static void Configure()
		{
			ObjectFactory.Configure(cfg =>
			{
				cfg.Scan(scan =>
				{
					scan.TheCallingAssembly();
					scan.WithDefaultConventions();
				});

				cfg.AddRegistry(new ControllerRegistry());
				cfg.AddRegistry(new MvcRegistry());
				cfg.AddRegistry(new ActionFilterRegistry(namespacePrefix: "$rootnamespace$"));

				//TODO: Add other registries and configure your container!
			});

			var resolver = new StructureMapDependencyResolver();
			DependencyResolver.SetResolver(resolver);
			GlobalConfiguration.Configuration.DependencyResolver = resolver;
		}
	}
}