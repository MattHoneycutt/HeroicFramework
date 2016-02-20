**********WARNING********
If you are upgrading from a previous version of Heroic.Web.IoC, you MAY need to update your existing StructureMapConfig!  

If your StructureMapConfig file contains any references to ObjectFactory, please replace them with IoC.Container instead, like so:

//Old code
ObjectFactory.Configure(cfg => 
{
	//Stuff
});

//New code:
IoC.Container.Configure(cfg => 
{
	//Stuff
});

Any other references you have created to ObjectFactory should also be replaced with IoC.Container. 

**********ASP.NET IDENTITY SUPPORT************
If you're using the default ASP.NET MVC project template, you'll probably get an error about IUserStore<ApplicationUser> when you try
to access the AccountController.  If so, add the following to your StructureMapConfig class.  You may have to adjust the type names
to match the types in your project.

	//1) Make IUserStore injectable.  Replace 'ApplicationUser' with whatever your Identity user type is.
	cfg.For<IUserStore<ApplicationUser>>().Use<UserStore<ApplicationUser>>();
				
	//2) Change AppDbContext to your application's Entity Framework context.
	cfg.For<DbContext>().Use<AppDbContext>();
				
	//3) This will allow you to inject the IAuthenticationManager.  You may not need this, but you will if you 
	//   used the default ASP.NET MVC project template as a starting point!
	cfg.For<IAuthenticationManager>().Use(ctx => ctx.GetInstance<HttpRequestBase>().GetOwinContext().Authentication);
