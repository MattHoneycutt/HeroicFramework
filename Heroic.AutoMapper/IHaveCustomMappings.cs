using AutoMapper;

namespace Heroic.AutoMapper
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IConfiguration configuration);
	}
}