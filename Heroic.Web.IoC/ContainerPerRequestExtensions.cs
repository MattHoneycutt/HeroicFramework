using System.Web;
using StructureMap;

namespace Heroic.Web.IoC
{
	public static class ContainerPerRequestExtensions
	{
		private const string ContainerKey = "_Container";

		public static IContainer GetContainer(this HttpContextBase context)
		{
			return (IContainer)context.Items[ContainerKey] ?? ObjectFactory.Container;
		}

		public static void SetContainer(this HttpContextBase context, IContainer container)
		{
			context.Items[ContainerKey] = container;
		}
	}
}