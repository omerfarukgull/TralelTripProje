using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TralelTripProje.Models.Siniflar;

namespace TralelTripProje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var dgr = c.Blogs.ToList();
            return View(dgr);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogSil(int id)
        {
            var dgr = c.Blogs.Find(id);
            c.Blogs.Remove(dgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var dgr = c.Blogs.Find(id);
            return View("BlogGetir", dgr);
        }

        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Baslik = b.Baslik;
            blg.Aciklama = b.Aciklama;
            blg.BlogImage = b.BlogImage;
            blg.Tarih = b.Tarih;

            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var dgr=c.Yorumlars.ToList();
            return View(dgr);
        }

        public ActionResult YorumSil(int id)
        {
            var dgr = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(dgr);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var dgr = c.Yorumlars.Find(id);
            return View(dgr);
        }

        public ActionResult YorumGuncelle(Yorumlar Y)
        {
            var dgr = c.Yorumlars.Find(Y.ID);
            dgr.ID = Y.ID;
            dgr.KullaniciAdi = Y.KullaniciAdi;
            dgr.Mail = Y.Mail;
            dgr.Yorum = Y.Yorum;
            dgr.Blog.Baslik = Y.Blog.Baslik;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}