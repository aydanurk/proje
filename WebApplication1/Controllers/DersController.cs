using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DersController : Controller
    {
        private readonly AppDBContext _db;
        public DersController(AppDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Ders> objDersList = _db.Dersler;
            return View(objDersList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Ders obj)
        {
            if (ModelState.IsValid)
            {
                _db.Dersler.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null || id==0)
            {
                return NotFound();
            }
            var dersFromDb = _db.Dersler.Find(id);
            if (dersFromDb == null)
            {
                return NotFound();
            }
            return View(dersFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Ders obj)
        {
            if (ModelState.IsValid)
            {
                _db.Dersler.Update(obj);
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
            var dersFromDb = _db.Dersler.Find(id);
            if (dersFromDb == null)
            {
                return NotFound();
            }
            return View(dersFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Dersler.Find(id);

            if (obj==null)
            {
                return NotFound();
            }
            _db.Dersler.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
            
        }
    }
}
