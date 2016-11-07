using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentals.Models;

namespace MovieRentals.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies

        ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var movieDetails = _context.Movies.Include("Genres").OrderBy(c => c.MovieName);
            return View(movieDetails);
        }

        public ActionResult Details(int id)
        {
            var movieDetail = _context.Movies.SingleOrDefault(c => c.Id == id);
            return View(movieDetail);
        }

        
    }
}