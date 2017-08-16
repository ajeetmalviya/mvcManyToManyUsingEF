using IMDB.Common.Interface.Repository;
using IMDB.Entities.Models;
using IMDB.Repository;
using IMDB.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Web.Controllers
{
    [HandleError]
    public class MovieController : Controller
    {
        private IUoWRepository _repContext = null;
        public MovieController()
            : this(new UoWRepository())
        {

        }
        public MovieController(IUoWRepository repContext)
        {
            _repContext = repContext;
        }

        public ActionResult GetMovies()
        {

            List<MovieViewModel> model = new List<MovieViewModel>();
            var movies = _repContext.MoviesRep.GetMovies();
            foreach (var item in movies)
            {
                model.Add(new MovieViewModel
                {
                    MovieId = item.MovieId,
                    MoviesName = item.MoviesName,
                    YOR = item.YOR,
                    Plot = item.Plot,
                    Poster = item.Poster,
                    Producer = item.Producer.ProducerName,
                    Actors = item.Actors.Select(a => new SelectListItem
                    {
                        Text = a.ActorName,
                    }).ToList(),
                });
            }
            return View(model);
        }

        public ActionResult AddMovie()
        {
            var model = new MovieViewModel
            {
                Actors = GetActors(),
                Producers = GetProducers()
            };

            return View("AddMovie", model);
        }

        [HttpPost]
        public ActionResult AddMovie(MovieViewModel model, HttpPostedFileBase fileUpload)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            model.Actors = GetActors();
            model.Producers = GetProducers();

            var errorList = new List<string>();

            string filePath = string.Empty;
            if (fileUpload != null)
            {

                string fileName = Path.GetFileName(Guid.NewGuid() + fileUpload.FileName).ToString();
                filePath = Path.Combine(Server.MapPath("~/UploadedFile/"), fileName);
                fileUpload.SaveAs(filePath);

                var index = filePath.IndexOf("UploadedFile");
                model.Poster = "~\\" + filePath.Substring(index);
            }


            if (!ModelState.IsValid)
            {
                errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                return View(model);
            }

            var duplicateMovie = _repContext.MoviesRep.GetMovies().Count(m => m.MoviesName.Trim().ToLower() == model.MoviesName.Trim().ToLower());
            if (duplicateMovie > 0)
            {
                ModelState.AddModelError(" ", "Movie is already in the database");
                return View(model);
            }


            var movie = model.ToModel();
            movie.Actors = GetActors(model.SelectedActors);
            var result = _repContext.MoviesRep.AddMovie(movie);
            return RedirectToAction("GetMovies");
        }


        public ActionResult EditMovie(int movieId)
        {
            if (movieId <= 0)
            {
                return View(new MovieViewModel());
            }

            var movie = _repContext.MoviesRep.GetMovieById(movieId);

            if (movie == null)
            {
                return HttpNotFound();
            }

            var map = movie.Actors.ToDictionary(a => a.ActorId.ToString(), a => a);
            var allActors = GetActors();
            Actor actorEntity;
            foreach (var actor in allActors)
            {
                if (map.TryGetValue(actor.Value, out actorEntity))
                {
                    actor.Selected = true;
                }
            }

            MovieViewModel model = new MovieViewModel(movie)
            {
                Producers = GetProducers(),
                Actors = allActors,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMovie(MovieViewModel model, HttpPostedFileBase fileUpload)
        {
            var actors = new MovieViewModel { Actors = GetActors() };
            var movie = _repContext.MoviesRep.GetMovieById(model.MovieId);
            if (movie == null)
            {
                return HttpNotFound();
            }

            var errorList = new List<string>();
            if (!ModelState.IsValid)
            {
                errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                return View(model);
            }


            var duplicateMovie = _repContext.MoviesRep.GetMovies().Count(m => m.MoviesName.Trim().ToLower() == model.MoviesName.Trim().ToLower());
            if (duplicateMovie > 1)
            {
                ModelState.AddModelError(" ", "Movie is already in the database");
                return View(model);
            }

            string filePath = string.Empty;

            if (fileUpload != null)
            {
                string fileName = Path.GetFileName(fileUpload.FileName);
                filePath = Path.Combine(Server.MapPath("~/UploadedFile"), fileName);
                fileUpload.SaveAs(filePath);
                var index = filePath.IndexOf("UploadedFile");
                model.Poster = "~\\" + filePath.Substring(index);
            }

            AddOrUpdateKeepExistingActors(movie, model);
            model.UpdateEntity(movie);
            movie.Actors = GetActors(model.SelectedActors);

            var result = _repContext.MoviesRep.EditMovie(movie);

            return RedirectToAction("GetMovies");
        }

  

        [HttpPost]
        public ActionResult DeleteMovie(int movieId)
        {
            if (movieId <= 0)
            {
                return HttpNotFound("Movie not found with this id." + movieId);
            }
            var result = _repContext.MoviesRep.DeleteMovie(movieId);
            return RedirectToAction("GetMovies");
        }

        private void AddOrUpdateKeepExistingActors(Movie movie, MovieViewModel movieViewModel)
        {
            //TODO: Extention to parst int
            var webSelectedActors = movieViewModel.Actors.Where(c => c.Selected).Select(a => int.Parse(a.Value)).ToList();
            var dbActors = movie.Actors.Select(a => a.ActorId).ToList();
            //TODO: Need a null check on web and dbActors

            var coursesToDeleteIDs = dbActors.Where(id => !webSelectedActors.Contains(id)).ToList();
            var allDbActors = _repContext.ActorRep.GetActors();
            if (allDbActors == null)
                return;
            var actorMap = allDbActors.ToDictionary(a => a.ActorId, a => a);
            // Delete removed courses
            Actor actor;
            foreach (var id in coursesToDeleteIDs)
            {
                if (actorMap.TryGetValue(id, out actor))
                {
                    movie.Actors.Remove(actor);
                }
            }

            // Add courses that user doesn't already have
            foreach (var id in webSelectedActors)
            {
                if (!dbActors.Contains(id))
                {
                    if (actorMap.TryGetValue(id, out actor))
                    {
                        movie.Actors.Add(actor);
                    }
                }
            }
        }

        private List<Actor> GetActors(List<int> ids)
        {
            if (ids == null)
            {
                return new List<Actor>();
            }
            var actors = _repContext.ActorRep.GetActors(ids);
            return actors;
        }

        private List<SelectListItem> GetActors()
        {
            var actors = _repContext.ActorRep.GetActors();
            if (actors == null)
            {
                return new List<SelectListItem>();
            }
            var actorVM = actors.Select(a => new SelectListItem
            {
                Value = a.ActorId.ToString(),
                Text = a.ActorName,
            }).ToList();
            return actorVM;
        }

        private List<SelectListItem> GetProducers()
        {
            var producer = _repContext.ProducerRep.GetProducer();
            if (producer == null)
            {
                return new List<SelectListItem>();
            }
            var producerVM = producer.Select(a => new SelectListItem
            {
                Value = a.ProducerId.ToString(),
                Text = a.ProducerName,
            }).ToList();
            return producerVM;
        }
    }

}