using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        KitapDB _db;
        public BookController(KitapDB db)
        {
            _db = db;
            //db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            return View(_db.Kitaplar.ToList());
        }

        public IActionResult Add()
        {
            ViewBag.KategoriID = new SelectList(_db.Kategoriler.ToList(),"KategoriID","KategoriAdi");
            return View();
        }
    }
}
