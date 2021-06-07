using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAutomation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly IRepository<Movie> movieRepository;
        private readonly IRepository<Genre> genreRepository;

        public MovieController(IRepository<Movie> movieRepository, IRepository<Genre> genreRepository)
        {
            this.movieRepository = movieRepository;
            this.genreRepository = genreRepository;
        }


        public ActionResult Index()
        {
            var movieGenres = movieRepository.ActiveMovieGenreVMs();

            return View(movieGenres);
        }

        public ActionResult Details(int id)
        {
            var movie = movieRepository.GetById(id);
            return View(movie);
        }

        public ActionResult Create()
        {
            ViewBag.Genres = genreRepository.GetActive();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movie movie, List<int> genresId)
        {
            try
            {
                ImageUploader.MovieImageUpload(movie);
                movieRepository.Create(movie);
                movieRepository.AddMovieGenres(movie.Id, genresId);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var exeption = ex.Message;

                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var selectedGenres = movieRepository.GetGenresByMovieId(id);
            var unSelectedGenres = genreRepository.GetAll(x => !selectedGenres.Contains(x)).ToList();
            var edit = movieRepository.GetById(id);

            ViewBag.selectedGenres = selectedGenres;
            ViewBag.unSelectedGenres = unSelectedGenres;

            return View(edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie, List<int> genresId)
        {
            try
            {
                movieRepository.AddMovieGenres(movie.Id, genresId);
                movieRepository.Update(movie);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var exeption = ex.Message;

                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                var movie = movieRepository.GetById(id);
                movieRepository.Delete(movie);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                var exeption = ex.Message;

                return View();
            }
        }
    }
}
