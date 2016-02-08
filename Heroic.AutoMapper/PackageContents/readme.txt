**********WARNING********
AutoMapper 4.2 introduced a breaking change from the 4.1 release: https://github.com/AutoMapper/AutoMapper/issues/1084

If you are upgrading from AutoMapper 4.1 to 4.2, you will need to update any models that implement the IHaveCustomMappings interface.

All you have to do is change the signature of your CreateMappings methods to take in an IMapperConfiguration, rather than an IConfiguration,
like so:

//Before:
public void CreateMappings(IConfiguration configuration)
{
    configuration.CreateMap<Foo, FooViewModel>()
        .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
}

//After:
public void CreateMappings(IMapperConfiguration configuration)
{
    configuration.CreateMap<Foo, FooViewModel>()
        .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
}

A simple find-and-replace with "CreateMappings(IConfiguration" and "CreateMappings(IMapperConfiguration" will do the trick!

*****A NOTE ABOUT AUTOMAPPER 5.0******

AutoMapper 5.0 will eliminate the static Mapper class that has existed since the initial release of AutoMapper.  I do plan to 
support AutoMapper 5.0 once it is released, and Heroic.AutoMapper will likely ship with "bridge" code to ensure your existing
applications continue to compile with minimal changes.  