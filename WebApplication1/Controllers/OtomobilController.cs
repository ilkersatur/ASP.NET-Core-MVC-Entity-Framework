using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class OtomobilController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormFile dosya)
        {
            Guid guid = Guid.NewGuid();

            FileStream fs = new FileStream("wwwroot/Resimler/" + guid.ToString()+dosya.FileName, FileMode.Create);

            dosya.CopyTo(fs);
            fs.Close();
            return Content(dosya.FileName);
        }
    }
}
