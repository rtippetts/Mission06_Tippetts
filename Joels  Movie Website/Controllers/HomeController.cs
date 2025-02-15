using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Joels__Movie_Website.Models;
using Microsoft.AspNetCore.Mvc;

namespace Joels__Movie_Website.Controllers
{

   
    public class HomeController : Controller
    {
        private Movie_Website_Context _context;
        public HomeController(Movie_Website_Context someName) //Constructor
        {
            _context = someName;
        }
        

    

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Get_to_know_Joel()
        {
            return View();
        }

        [HttpGet]

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Add_a_movie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_a_movie(Application response)
        {
            _context.Applications.Add(response); //Add record to database
            _context.SaveChanges();

            return View("Confirmation", response);
        }
    
    }


}
