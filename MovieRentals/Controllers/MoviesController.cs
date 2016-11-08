using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieRentals.Models;
using MovieRentals.ViewModel;
using System.Data.Entity;

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
            var movieView = new MovieView()
            {
                Movies = movieDetail,
                Genres =  _context.Genres.ToList()
            };
            return View("MovieForm",movieView);
        }

        public ActionResult MovieForm()
        {
            MovieView view = new MovieView();
            view.Genres = _context.Genres.ToList();
            return View(view);
        }

        public ActionResult Submit(MovieView movie)
        {
            if(movie.Movies.Id == 0)
            {
                _context.Movies.Add(movie.Movies);
                _context.SaveChanges();
            }
            else
            {
                var movieDetail = _context.Movies.First(c => c.Id == movie.Movies.Id);
                movieDetail.MovieName = movie.Movies.MovieName;
                movieDetail.ReleaseDate = movie.Movies.ReleaseDate;
                movieDetail.NumberInStock = movie.Movies.NumberInStock;
                movieDetail.GenresId = movie.Movies.GenresId;
                movieDetail.Genres = _context.Genres.First(c => c.GenresId == movie.Movies.GenresId);
                _context.Entry(movieDetail).State = EntityState.Modified;
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "Movies");
        }
        
    }
}