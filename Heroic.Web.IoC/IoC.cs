using StructureMap;

namespace Heroic.Web.IoC
{
	public static class IoC
	{
		public static IContainer Container { get; set; }

		static IoC()
		{
			Container = new Container();
		}
	}
}