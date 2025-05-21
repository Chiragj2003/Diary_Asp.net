using DiaryApp.Data;
using DiaryApp.Models;
using Microsoft.AspNetCore.Mvc;

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
    }
}
 