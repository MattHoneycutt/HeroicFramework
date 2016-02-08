using System;
using System.Linq;
using HeroicFramework.SampleWebApp.Domain;

namespace HeroicFramework.SampleWebApp.Data
{
    public interface IFooProvider
    {
        IQueryable<Foo> GetFoos();
    }

    public class FooProvider : IFooProvider
    {
        private static readonly Foo[] Foos;

        static FooProvider()
        {
            Foos = new[]
            {
                new Foo {Id = Guid.NewGuid(), FullName = "Foo 1", Description = "Foo 1 Description"},
                new Foo {Id = Guid.NewGuid(), FullName = "Foo 2", Description = "Foo 2 Description"},
                new Foo {Id = Guid.NewGuid(), FullName = "Foo 3", Description = "Foo 3 Description"},
                new Foo {Id = Guid.NewGuid(), FullName = "Foo 4", Description = "Foo 4 Description"},
                new Foo {Id = Guid.NewGuid(), FullName = "Foo 5", Description = "Foo 5 Description"},
            };
        }

        public IQueryable<Foo> GetFoos()
        {
            return Foos.AsQueryable();
        }
    }
}