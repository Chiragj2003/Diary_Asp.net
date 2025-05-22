using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Controllers
{
    public class DiaryEnteriesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DiaryEnteriesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<DiaryEntry> objDiaryEntries = _db.DiaryEntries.ToList();

            return View(objDiaryEntries);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3) { 
                ModelState.AddModelError("Title", "Title too Short");
            }
            if (ModelState.IsValid) // check if model state is valid
            {
                _db.DiaryEntries.Add(obj); // add diary enteries to database
                _db.SaveChanges(); // save ch anges to database
                return RedirectToAction("Index");
            }

            return View(obj); // return the view with the model if not valid
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound(); 
            }

            DiaryEntry? obj = _db.DiaryEntries.Find(id); 
            if (obj == null) 
            {
                return NotFound(); 
            }
            return View(obj); 
        }

        [HttpPost]
        public IActionResult Edit(DiaryEntry obj)
        {
            if (obj != null && obj.Title.Length < 3)
            {
                ModelState.AddModelError("Title", "Title too Short");
            }
            if (ModelState.IsValid) // check if model state is valid
            {
                _db.DiaryEntries.Update(obj); // update diary enteries in the database
                _db.SaveChanges(); // save ch anges to database
                return RedirectToAction("Index");
            }

            return View(obj); // return the view with the model if not valid
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            DiaryEntry? obj = _db.DiaryEntries.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        public IActionResult Delete(int id)
        {
            var entry = _db.DiaryEntries.FirstOrDefault(e => e.Id == id);
            if (entry == null)
            {
                return NotFound();
            }

            _db.DiaryEntries
                .Where(e => e.Id == id)
                .ExecuteDelete(); // EF Core 7+

            return RedirectToAction("Index");
        }
    }
}
 