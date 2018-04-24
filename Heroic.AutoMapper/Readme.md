# ![Heroic.AutoMapper](../HeroicApplications-Small.png) 
# Heroic.AutoMapper

*Now with .NET Core support!*

*Be a hero!*  Cleaner configuration for AutoMapper!  Just implement one of the mapping interfaces in your view model, and you're set!

Note that you can use Heroic.AutoMapper with *any* type of project.  It no longer depends on ASP.NET!

## Installation
Install via [nuget](https://www.nuget.org/packages/Heroic.AutoMapper):

    PM> Install-Package Heroic.AutoMapper

## Configuration

Just call `HeroicAutoMapperConfigurator.Configure` during your application's startup.

### Console Application Setup

For a simple console application, you might do something like this:

```c#
using Heroic.AutoMapper;

public class Program 
{
	public static void Main() 
	{
		HeroicAutoMapperConfigurator.LoadMapsFromCallerAndReferencedAssemblies();

		Console.WriteLine("All set!");
	}
}
```

### ASP.NET Core

For an ASP.NET Core application, you should configure Heroic.AutoMapper in your Startup class, like so:

```c#
//..
using Heroic.AutoMapper;

namespace SmartMoving.Api
{
    public class Startup
    {
        //.. snip

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseAuthentication();

            app.UseMvc();

			HeroicAutoMapperConfigurator.LoadMapsFromAssemblyContainingTypeAndReferencedAssemblies<WidgetModel>();
        }
    }
}

```

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

		public void CreateMappings(IMapperConfiguration configuration)
		{
			configuration.CreateMap<User, ProfileForm>()
				.ForMember(d => d.FullName, opt => opt.MapFrom(s => s.UserName))
				.ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => s.Email));
		}
	}
```

## Want more?
Check out the rest of the [Heroic Framework](https://github.com/MattHoneycutt/HeroicFramework)!
