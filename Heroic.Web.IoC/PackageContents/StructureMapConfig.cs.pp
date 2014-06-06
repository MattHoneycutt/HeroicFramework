using Heroic.Web.IoC;
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

				cfg.AddRegistry<ControllerRegistry>();
				cfg.AddRegistry<MvcRegistry>();

				//TODO: Add other registries and configure your container!
			});

			DependencyResolver.SetResolver(new StructureMapDependencyResolver());
		}
	}
}