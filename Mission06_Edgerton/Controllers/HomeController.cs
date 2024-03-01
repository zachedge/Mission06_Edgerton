using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Edgerton.Models;
using System.Diagnostics;
using System.Linq;

namespace Mission06_Edgerton.Controllers
{
    public class HomeController : Controller
    {
        private MovieEntryContext _context;
        public HomeController(MovieEntryContext instance) 
        {
            _context = instance;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GTKJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DBEntry()
        {
            ViewBag.Cats = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("DBEntry", new Application());
        }

        [HttpPost]
        public IActionResult DBEntry(Application response)
        {
            if (ModelState.IsValid)
            {
                _context.Movies.Add(response);
                _context.SaveChanges();

                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Cats = _context.Categories
                    .OrderBy(x => x.CategoryName)
                    .ToList();

                return View(response);
            }
        }

        public IActionResult DBList()
        {
            var All = _context.Movies
                             .Include(x => x.Category)
                             .OrderBy(x => x.Title)
                             .ToList();

            return View(All);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);
            ViewBag.Cats = _context.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();

            return View("DBEntry", recordToEdit);
        }
        [HttpPost]
        public IActionResult Edit(Application updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();
            return RedirectToAction("DBList");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == id);

            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Application app)
        {
            _context.Movies.Remove(app);
            _context.SaveChanges();

            return RedirectToAction("DBList");
        }
    }
}