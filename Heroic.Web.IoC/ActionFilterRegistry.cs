using System.Reflection;
using System.Web.Mvc;
using StructureMap.Configuration.DSL;
using StructureMap.TypeRules;

namespace Heroic.Web.IoC
{
	public class ActionFilterRegistry : Registry
	{
		public ActionFilterRegistry(string namespacePrefix)
		{
			For<IFilterProvider>().Use(new StructureMapFilterProvider());

			Policies.SetAllProperties(x =>
				x.Matching(p =>
					p.DeclaringType.CanBeCastTo(typeof(ActionFilterAttribute)) &&
					p.DeclaringType.Namespace.StartsWith(namespacePrefix) &&
					!p.PropertyType.IsPrimitive &&
					p.PropertyType != typeof(string)));
		}
	}
}