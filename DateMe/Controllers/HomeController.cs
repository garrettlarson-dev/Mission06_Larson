using Mission06_Larson.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Larson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext;
       
        public HomeController(ILogger<HomeController> logger, MovieContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movie()
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View(new Movie());
        }

        [HttpPost]
        public IActionResult Movie(Movie response)
        {
            if (ModelState.IsValid)
            {
                _movieContext.Movies.Add(response);
                _movieContext.SaveChanges();
                return View("Success", response);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View(response);
            }
            
        }

        public IActionResult GetMovies() {
            var movies = _movieContext.Movies.Include(x => x.Category).ToList(); ;
            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Movie movie = _movieContext.Movies.Single(x => x.MovieId == id);
            ViewBag.Categories = _movieContext.Categories.ToList();
            return View("Movie", movie);
        }

        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            _movieContext.Update(updatedInfo);
            _movieContext.SaveChanges();
            return RedirectToAction("GetMovies");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var movie = _movieContext.Movies.Single(x => x.MovieId == id);
            return View(movie);
        }

        [HttpPost]
        public IActionResult Delete(Movie movie)
        {
            _movieContext.Movies.Remove(movie);
            _movieContext.SaveChanges();
            return RedirectToAction("GetMovies");
        }
    }
}