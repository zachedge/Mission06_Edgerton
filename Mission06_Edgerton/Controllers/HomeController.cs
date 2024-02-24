using Microsoft.AspNetCore.Mvc;
using Mission06_Edgerton.Models;
using System.Diagnostics;

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
            return View();
        }
        [HttpPost]
        public IActionResult DBEntry(Application response)
        {
            _context.Entries.Add(response);
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    }
}
