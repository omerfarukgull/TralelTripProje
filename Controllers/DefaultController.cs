using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TralelTripProje.Models.Siniflar;


namespace TralelTripProje.Controllers
{
    public class DefaultController : Controller
    {
        Context Db = new Context();
        public ActionResult Index()
        {
            var dgr = Db.Blogs.OrderByDescending(x => x.ID).Take(4).ToList();
            return View(dgr);
        }
        public ActionResult About() 
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var dgr = Db.Blogs.OrderByDescending(x => x.ID).Take(2).ToList();
            return PartialView(dgr);
        }

        public PartialViewResult Partial2()
        {
            var dgr = Db.Blogs.Where(x => x.ID == 1).ToList();
            return PartialView(dgr);
        }
        public PartialViewResult Partial3()
        {
            var dgr = Db.Blogs.Take(10).ToList();
            return PartialView(dgr);
        }

        public PartialViewResult Partial4()
        {
            var dgr = Db.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(dgr);
        }
        public PartialViewResult Partial5()
        {
            var dgr = Db.Blogs.OrderBy(x => x.ID).Take(3).ToList();
            return PartialView(dgr);
        }
    }
}