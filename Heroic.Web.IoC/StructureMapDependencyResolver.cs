using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Heroic.Web.IoC
{
	public class StructureMapDependencyResolver : IDependencyResolver
	{
		public object GetService(Type serviceType)
		{
			if (serviceType == null)
			{
				return null;
			}

			var container = StructureMapContainerPerRequestModule.Container;

			return serviceType.IsAbstract || serviceType.IsInterface
				? container.TryGetInstance(serviceType)
				: container.GetInstance(serviceType);
		}

		public IEnumerable<object> GetServices(Type serviceType)
		{
			return StructureMapContainerPerRequestModule.Container.GetAllInstances(serviceType).Cast<object>();
		}
	}
}