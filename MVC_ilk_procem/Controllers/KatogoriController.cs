using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ilk_procem.Models.Entity;
using PagedList;
using PagedList.Mvc;
namespace MVC_ilk_procem.Controllers
{
    
    public class KatogoriController : Controller
    {

        // GET: Katogori
        STOKTAKIPEntities db = new STOKTAKIPEntities();
        public ActionResult Index(int sayfa=1)
        {
            //var kategori = db.TBLKATEGORILERs.ToList();
            var kategori = db.TBLKATEGORILERs.ToList().ToPagedList(sayfa, 4);

            return View(kategori);
        }

        [HttpGet]
        public ActionResult Yenikategori()
        {
            return View();
        }

        //Yeni kategori ekleme
        [HttpPost]
        public ActionResult Yenikategori(TBLKATEGORILER p1)
        {
            //validetion kontrolü
            if (!ModelState.IsValid)
            {
                return View("Yenikategori");
            }
            db.TBLKATEGORILERs.Add(p1);
            db.SaveChanges();
            return View();
        }

        //Kategorilede silme işlemi yapma
        public ActionResult Sil(int id)
        {
            var kategori = db.TBLKATEGORILERs.Find(id);
            db.TBLKATEGORILERs.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        //veri gönderme
        public ActionResult Guncelle(int id)
        {
            var kate = db.TBLKATEGORILERs.Find(id);
            return View("Guncelle", kate);
        }

        //veri güncelleme
        public ActionResult Guncelle1(TBLKATEGORILER p1)
        {
            var kate = db.TBLKATEGORILERs.Find(p1.KATEGORI_ID);
            kate.KATEGORI_AD = p1.KATEGORI_AD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}