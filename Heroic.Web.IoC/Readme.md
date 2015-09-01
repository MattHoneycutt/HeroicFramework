# ![HtmlTags](../HeroicApplications-Small.png) 
# Heroic.Web.IoC
 
*Be a hero!*  Easily add dependency injection and a container-per-request to your ASP.NET MVC 5.x and Web API 2.x applications with this package!  Never worry about new-ing up objects, tracking references, or disposing of things when the current web request ends.  Just install this package, add your registries, and you're all set!

## Installation
Install via [nuget](https://www.nuget.org/packages/Heroic.Web.IoC/):

    PM> Install-Package Heroic.Web.IoC

## Usage
Just install the NuGet package, and you're all set!  The dependency resolvers for both MVC and Web API will be swapped out to the heroic dependency resolver, which uses StructureMap under the hood.

If you need to adjust the container's configuration, you'll find a StructureMapConfig class in your application's App_Start folder.   By default, any registries in your web application will be automatically loaded.   You can also add registries for other assemblies, or adjust the conventions as you see fit.

## Want more?
Check out the rest of the [Heroic Framework](https://github.com/MattHoneycutt/HeroicFramework)!