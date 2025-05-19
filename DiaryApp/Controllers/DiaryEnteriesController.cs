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
    }
}
 