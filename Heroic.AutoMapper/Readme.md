# ![HtmlTags](../HeroicApplications-Small.png) 
# Heroic.AutoMapper

*Be a hero!*  Cleaner configuration for AutoMapper!  Just implement one of the mapping interfaces in your view model, and you're set!

## Installation
Install via [nuget](https://www.nuget.org/packages/Heroic.AutoMapper):

    PM> Install-Package Heroic.AutoMapper

## Usage
Want to map your view model from a domain model?  Just implement the IMapFrom&lt;T&gt; interface!
```c#
	public class CustomerRiskViewModel : IMapFrom<Risk>
	{
		public string Title { get; set; }

		public string Description { get; set; }
	}
```

Need to map a model back to your domain instead?  You can implement IMapTo&lt;T&gt; instead:

```c#
	public class AddCustomerForm : IMapTo<Customer>
	{
		[Required, Display(Name = "Full Name", Prompt = "Full Name (ex: John Doe)...")]
		public string Name { get; set; }

		[Required, DataType(DataType.EmailAddress)]
		public string WorkEmail { get; set; }
	}
```

But what if you need to customize your mappings?  Implement IHaveCustomMappings instead:

```c#
	public class ProfileForm : IMapFrom<User>, IHaveCustomMappings
	{
		public string FullName { get; set; }

		public string EmailAddress { get; set; }

		public void CreateMappings(IConfiguration configuration)
		{
			configuration.CreateMap<User, ProfileForm>()
				.ForMember(d => d.FullName, opt => opt.MapFrom(s => s.UserName))
				.ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.Email));
		}
	}
```

By default, configuration information will be loaded from all types in your web application project as well as any referenced assemblies.  You can customize this behavior by editing the AutoMapperConfig class, located in your App_Start folder.

## Want more?
Check out the rest of the [Heroic Framework](https://github.com/MattHoneycutt/HeroicFramework)!