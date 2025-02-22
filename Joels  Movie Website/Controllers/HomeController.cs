using System.Diagnostics;
using AspNetCoreGeneratedDocument;
using Joels__Movie_Website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            // Get unique rating values from the database
            ViewBag.Ratings = _context.Movies
                .Select(m => m.Rating) // Select only the Rating column
                .Distinct() // Get unique values
                .OrderBy(r => r) // Sort alphabetically
                .ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Add_a_movie(Movie response)
        {
            _context.Movies.Add(response); //Add record to database
            _context.SaveChanges();

            return View("Confirmation", response);
        }


        public IActionResult MovieList()
        {
            //Linq
            var movies = _context.Movies.Include(m => m.Category).ToList()
                .OrderBy(x => x.Title).ToList();

            return View(movies);
        }

        [HttpGet]

        public IActionResult Edit(int Id)
        {

            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == Id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

            // Get unique rating values from the database
            ViewBag.Ratings = _context.Movies
                .Select(m => m.Rating) // Select only the Rating column
                .Distinct() // Get unique values
                .OrderBy(r => r) // Sort alphabetically
                .ToList();

            return View("Add_a_movie", recordToEdit);
        }

        [HttpPost]

        public IActionResult Edit(Movie updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            
            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            var recordToDelete = _context.Movies
                .Single(x => x.MovieId == Id);

            return View(recordToDelete);
        }

        [HttpPost]

        public IActionResult Delete(Movie movie)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }


}
