using System.Web;
using Heroic.Web.IoC;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(StructureMapStartup), "RegisterModule")]
namespace Heroic.Web.IoC
{
	public static class StructureMapStartup
	{
		public static void RegisterModule()
		{
			HttpApplication.RegisterModule(typeof(StructureMapContainerPerRequestModule));
		}
	}
}