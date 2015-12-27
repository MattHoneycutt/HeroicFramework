using System.Reflection;
using StructureMap;

namespace Heroic.Web.IoC
{
	public class ControllerRegistry : Registry
	{
		public ControllerRegistry()
		{
			var assembly = Assembly.GetCallingAssembly();
			Scan(scan =>
			{
				scan.Assembly(assembly);
				scan.With(new ControllerConvention());
			});
		}
	}
}