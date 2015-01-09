using System.Collections.Generic;
using System.Web.Mvc;

namespace Heroic.Web.IoC
{
	public class StructureMapFilterProvider : FilterAttributeFilterProvider
	{
		public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
		{
			var filters = base.GetFilters(controllerContext, actionDescriptor);

			var container = StructureMapContainerPerRequestModule.Container;

			foreach (var filter in filters)
			{
				container.BuildUp(filter.Instance);
				yield return filter;
			}
		}
	}
}