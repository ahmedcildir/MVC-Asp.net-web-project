using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_ilk_procem.Models.Entity;
namespace MVC_ilk_procem.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        STOKTAKIPEntities db = new STOKTAKIPEntities();
        public ActionResult Index()
        {
            var urun = db.TBLURUNLERs.ToList();
            return View(urun);
        }

        [HttpGet]
        public ActionResult Yeniurun()
        {
            //kategoriden değerleri dropdawnliste çekme
            List<SelectListItem> kategori = (from kate in db.TBLKATEGORILERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = kate.KATEGORI_AD,
                                                 Value = kate.KATEGORI_ID.ToString()
                                             }).ToList();
            //kategori değerini VievBag ile html sayfasına gönderiyoruz
            ViewBag.deger = kategori;
            return View();
        }
        [HttpPost]
        public ActionResult Yeniurun(TBLURUNLER p1)
        {
            //dropdawnlist ten gelen değeri atama
            var kat = db.TBLKATEGORILERs.Where(x => x.KATEGORI_ID == p1.TBLKATEGORILER.KATEGORI_ID).FirstOrDefault();
            p1.TBLKATEGORILER = kat;
            db.TBLURUNLERs.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Ürünler Silme işlemi
        public ActionResult Sil(int id)
        {
            var urun = db.TBLURUNLERs.Find(id);
            db.TBLURUNLERs.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //İdiyi getir 
        public ActionResult UrunGetir(int id)
        {
            var urun = db.TBLURUNLERs.Find(id);
            List<SelectListItem> kategori = (from kate in db.TBLKATEGORILERs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = kate.KATEGORI_AD,
                                                 Value = kate.KATEGORI_ID.ToString()
                                             }).ToList();
            //kategori değerini VievBag ile html sayfasına gönderiyoruz
            ViewBag.deger = kategori;
            return View("UrunGetir", urun);
        }
        //Güncelle
        public ActionResult Guncelle(TBLURUNLER p1)
        {
            
            var urun = db.TBLURUNLERs.Find(p1.URUN_ID);
            urun.URUN_AD = p1.URUN_AD;
            urun.MARKA = p1.MARKA;
            //urun.URUNKATEGORI = p1.URUNKATEGORI;
            var kat = db.TBLKATEGORILERs.Where(x => x.KATEGORI_ID == p1.TBLKATEGORILER.KATEGORI_ID).FirstOrDefault();
            urun.URUNKATEGORI = kat.KATEGORI_ID;
            urun.FIYAT = p1.FIYAT;
            urun.STOK = p1.STOK;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}