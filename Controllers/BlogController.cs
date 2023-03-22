using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TralelTripProje.Models.Siniflar;

namespace TralelTripProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var dgr=c.Blogs.ToList();
            by.Deger1 = c.Blogs.OrderByDescending(x => x.ID).ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            by.Deger2 = c.Yorumlars.Take(3).ToList();
            return View(by);
        }


        public ActionResult BlogDetay(int id)
        {

            //var blogBul=c.blogs.Where(x=>x.ID==id).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == id).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.Blogid == id).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }



        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar y)
        {
            c.Yorumlars.Add(y);
            c.SaveChanges();
            return PartialView();
        }
    }
}