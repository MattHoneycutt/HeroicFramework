using System.Web.Mvc;
using StructureMap;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Heroic.Web.IoC.PackageContents.StructureMapConfig), "Configure")]
namespace Heroic.Web.IoC.PackageContents
{
	public static class StructureMapConfig
	{
		public static void Configure()
		{
			ObjectFactory.Configure(cfg =>
			{
				cfg.AddRegistry<ControllerRegistry>();
				cfg.AddRegistry<MvcRegistry>();

				//TODO: Add other registries and configure your container!
			});

			DependencyResolver.SetResolver(new StructureMapDependencyResolver());
		}
	}
}