using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using HeroicFramework.SampleWebApp.Data;
using HeroicFramework.SampleWebApp.Models;

namespace HeroicFramework.SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFooProvider _fooProvider;

        public HomeController(IFooProvider fooProvider)
        {
            _fooProvider = fooProvider;
        }

        public ActionResult Index()
        {
            var models = _fooProvider.GetFoos().ProjectTo<FooViewModel>().ToArray();
            return View(models);
        }
    }
}