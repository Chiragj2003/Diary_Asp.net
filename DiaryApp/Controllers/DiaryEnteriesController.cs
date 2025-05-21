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
            _db.DiaryEntries.Add(obj); // add diary enteries to database
            _db.SaveChanges(); // save changes to database

            return RedirectToAction("Index");
        }
    }
}
 