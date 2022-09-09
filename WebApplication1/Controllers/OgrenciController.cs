using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly AppDBContext _db;
        public OgrenciController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ogrenci> objOgrenciList = _db.Ogrenciler;
            return View(objOgrenciList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> values = (from Ogretmen in _db.Ogretmenler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = Ogretmen.OgretmenName,
                                               Value = Ogretmen.Id.ToString()
                                           }).ToList();
            ViewBag.v1 = values;


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ogrenci obj)
        {
            if (ModelState.IsValid)
            {
                _db.Ogrenciler.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return View(obj);
            
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ogrenciFromDb = _db.Ogrenciler.Find(id);
            if (ogrenciFromDb == null)
            {
                return NotFound();
            }
            return View(ogrenciFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ogrenci obj)
        {
            if (ModelState.IsValid)
            {
                _db.Ogrenciler.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var ogrenciFromDb = _db.Ogrenciler.Find(id);
            if (ogrenciFromDb == null)
            {
                return NotFound();
            }
            return View(ogrenciFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Ogrenciler.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            _db.Ogrenciler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
