**********UPGRADING?********
AutoMapper 4.x and 5.x introduced breaking changes from previous versions.

You will need to update any models that implement the IHaveCustomMappings interface.

All you have to do is change the signature of your CreateMappings methods to take in 
an IMapperConfigurationExpression, rather than an IConfiguration/IMapperConfiguration, 
like so:

//Before 4.2, CreateMappings looked like:
public void CreateMappings(IConfiguration configuration)
{
    configuration.CreateMap<Foo, FooViewModel>()
        .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
}

//Before 5.0, CreateMappings looked like:
public void CreateMappings(IMapperConfiguration configuration)
{
    configuration.CreateMap<Foo, FooViewModel>()
        .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
}

//After 5.0, CreateMappings looks like:
public void CreateMappings(IMapperConfigurationExpression configuration)
{
    configuration.CreateMap<Foo, FooViewModel>()
        .ForMember(x => x.Name, opt => opt.MapFrom(x => x.FullName));
}

The following simple find-and-replace operations will fix your existing code:
"CreateMappings(IConfiguration" => "CreateMappings(IMapperConfigurationExpression" 
"CreateMappings(IMapperConfiguration" => "CreateMappings(IMapperConfigurationExpression" 
