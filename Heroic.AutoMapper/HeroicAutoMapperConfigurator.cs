using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace Heroic.AutoMapper
{
	public static class HeroicAutoMapperConfigurator
	{
		public static void LoadMapsFromAssemblyContainingTypeAndReferencedAssemblies<TType>(Func<AssemblyName, bool> assemblyFilter = null)
		{
			var target = typeof (TType).Assembly;

			Func<AssemblyName, bool> loadAllFilter = (x => true);

			var assembliesToLoad = target.GetReferencedAssemblies()
				.Where(assemblyFilter ?? loadAllFilter)
				.Select(a => Assembly.Load(a))
				.ToList();

			assembliesToLoad.Add(target);

			LoadMapsFromAssemblies(assembliesToLoad.ToArray());
		}

		public static void LoadMapsFromCallerAndReferencedAssemblies(Func<AssemblyName, bool> assemblyFilter = null)
		{
			var target = Assembly.GetCallingAssembly();

			Func<AssemblyName, bool> loadAllFilter = (x => true);

			var assembliesToLoad = target.GetReferencedAssemblies()
				.Where(assemblyFilter ?? loadAllFilter)
				.Select(a => Assembly.Load(a))
				.ToList();

			assembliesToLoad.Add(target);

			LoadMapsFromAssemblies(assembliesToLoad.ToArray());
		}

		public static void LoadMapsFromAssemblies(params Assembly[] assemblies)
		{
			var types = assemblies.SelectMany(a => a.GetExportedTypes()).ToArray();

            #pragma warning disable 618
		    Mapper.Initialize(cfg => Load(cfg, types));
            #pragma warning restore 618
        }

	    private static void Load(IMapperConfigurationExpression cfg, Type[] types)
	    {
            LoadIMapFromMappings(cfg, types);
            LoadIMapToMappings(cfg, types);

            LoadCustomMappings(cfg, types);
        }

        private static void LoadCustomMappings(IMapperConfigurationExpression cfg, IEnumerable<Type> types)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where typeof(IHaveCustomMappings).IsAssignableFrom(t) &&
							  !t.IsAbstract &&
							  !t.IsInterface
						select (IHaveCustomMappings)Activator.CreateInstance(t)).ToArray();

			foreach (var map in maps)
			{
				map.CreateMappings(cfg);
			}
		}

		private static void LoadIMapFromMappings(IMapperConfigurationExpression cfg, IEnumerable<Type> types)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>) &&
							  !t.IsAbstract &&
							  !t.IsInterface
						select new
						{
							Source = i.GetGenericArguments()[0],
							Destination = t
						}).ToArray();

			foreach (var map in maps)
			{
				cfg.CreateMap(map.Source, map.Destination);
			}
		}

		private static void LoadIMapToMappings(IMapperConfigurationExpression cfg, IEnumerable<Type> types)
		{
			var maps = (from t in types
						from i in t.GetInterfaces()
						where i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>) &&
							  !t.IsAbstract &&
							  !t.IsInterface
						select new
						{
							Destination = i.GetGenericArguments()[0],
							Source = t
						}).ToArray();

			foreach (var map in maps)
			{
				cfg.CreateMap(map.Source, map.Destination);
			}
		}
	}

}