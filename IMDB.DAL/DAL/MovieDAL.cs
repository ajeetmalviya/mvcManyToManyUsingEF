using IMDB.Common.Interface.DAL;
using IMDB.DAL.Models;
using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.DAL.DAL
{
    public class MovieDAL : IMoviesDAL
    {
        IMDBDatabaseContext _context = null;

        public MovieDAL()
            : this(new IMDBDatabaseContext())
        {

        }

        public MovieDAL(IMDBDatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// save movie to the db.
        /// </summary>
        /// <param name="movie"></param>
        public int AddMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return movie.MovieId;

        }

        /// <summary>
        /// delete movie base on movie id.
        /// </summary>
        /// <param name="movieId"></param>
        public bool DeleteMovie(int movieId)
        {
            if (movieId < 0)
            {
                return false;
            }
            var movieById = _context.Movies.SingleOrDefault(m => m.MovieId == movieId);
            DeleteUserProfile(movieById);
            return true;
        }

        /// <summary>
        /// Delete actors from the table under respective movie
        /// </summary>
        /// <param name="userProfile"></param>
        private void DeleteUserProfile(Movie movie)
        {
            if (movie.Actors != null)
            {
                foreach (var actor in movie.Actors.ToList())
                {
                    movie.Actors.Remove(actor);
                }
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        /// <summary>
        /// edit movie based on perticular id.
        /// </summary>
        /// <param name="movie"></param>
        public bool EditMovie(Movie movie)
        {
            if (movie == null)
            {
                throw new ArgumentNullException(nameof(movie));
            }

            var singleMovie = _context.Movies.SingleOrDefault(m => m.MovieId == movie.MovieId);

            if (singleMovie == null)
            {
                return false;
            }

            singleMovie.MoviesName = movie.MoviesName;
            singleMovie.YOR = movie.YOR;
            singleMovie.Plot = movie.Plot;
            singleMovie.Poster = movie.Poster;
            singleMovie.Actors = movie.Actors;
            singleMovie.ProducerId = movie.ProducerId;
            _context.SaveChanges();
            return true;
        }



        /// <summary>
        /// Get list of movie.
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        /// <summary>
        /// get movie by Id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Movie GetMovieById(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.MovieId == Id);
            return movie;
        }
    }
}
