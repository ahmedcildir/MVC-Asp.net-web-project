using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ilk_procem.Models.Entity;
namespace MVC_ilk_procem.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        STOKTAKIPEntities db = new STOKTAKIPEntities();
        public ActionResult Index()
        {
            var musteri = db.TBLMUSTERILERs.ToList();
            return View(musteri);
        }

        //Muşteri ekleme get
        [HttpGet]
        public ActionResult Yenimusteri()
        {
            return View();
        }

        //Müşteri ekleme postişlemi
        [HttpPost]
        public ActionResult Yenimusteri(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenimusteri");
            }
            db.TBLMUSTERILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        //müşteri silme işlemi
        public ActionResult Sil(int id)
        {
            var musteri = db.TBLMUSTERILERs.Find(id);
            db.TBLMUSTERILERs.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
         public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMUSTERILERs.Find(id);
            
            return View("MusteriGetir", musteri);
        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            var musteri = db.TBLMUSTERILERs.Find(p1.MUSTERI_ID);
            musteri.MUSTERI_AD = p1.MUSTERI_AD;
            musteri.MUSTERI_SOYAD = p1.MUSTERI_SOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}