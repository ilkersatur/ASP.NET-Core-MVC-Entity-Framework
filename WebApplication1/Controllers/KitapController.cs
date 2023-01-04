global using WebApplication1.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        KitapDB _db;
        public KitapController(KitapDB db)
        {
            _db = db;
            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
        public IActionResult Index()
        {
            //KitapDB db = new KitapDB();
            //db.Database.EnsureDeleted();
            //db.Database.EnsureCreated();
           
            //return View(_db.Kitaplar.ToList());
            return View(_db.Kitaplar.Include("Kategori").ToList());
         
        }
        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(),"KategoriID","KategoriAdi");

            return View();
        }

        //[HttpPost]
        //public IActionResult Ekle(Kitap kitap)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Kitaplar.Add(kitap);
        //        _db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
        //        return View();
        //    }
        //}

        [HttpPost]
        public IActionResult Ekle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                FileStream fs = new FileStream("wwwroot/Resimler/" + kitap.Dosya.FileName, FileMode.Create);
                kitap.Dosya.CopyTo(fs);
                fs.Close();
                kitap.KapakResmi = kitap.Dosya.FileName;
                _db.Kitaplar.Add(kitap);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
                return View();
            }
        }
    }
}
