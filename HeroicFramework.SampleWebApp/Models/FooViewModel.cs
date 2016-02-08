using System;
using AutoMapper;
using Heroic.AutoMapper;
using HeroicFramework.SampleWebApp.Domain;

namespace HeroicFramework.SampleWebApp.Models
{
    public class FooViewModel : IMapFrom<Foo>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Foo, FooViewModel>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
        }
    }
}