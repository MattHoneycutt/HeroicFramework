using AutoMapper;

namespace Heroic.AutoMapper
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IMapperConfiguration configuration);
	}
}