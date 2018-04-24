using AutoMapper;

namespace Heroic.AutoMapper
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IMapperConfigurationExpression configuration);
	}
}