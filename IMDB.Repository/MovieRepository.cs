using IMDB.Common.Interface.DAL;
using IMDB.Common.Interface.Repository;
using IMDB.DAL.DAL;
using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Repository
{
    public class MovieRepository : IMoviesRepository
    {
        private IUoWDAL _dalContext = null;

        public MovieRepository()
            : this(new UoWDAL())
        {

        }

        public MovieRepository(IUoWDAL dalContext)
        {
            _dalContext = dalContext;
        }

        /// <summary>
        /// Add movies
        /// </summary>
        /// <param name="movie"></param>
        public int AddMovie(Movie movie)
        {
            var result = _dalContext.MovieDAL.AddMovie(movie);
            return result;
        }

        /// <summary>
        /// delete movie based on id.
        /// </summary>
        /// <param name="movieId"></param>
        public bool DeleteMovie(int movieId)
        {
            var result = _dalContext.MovieDAL.DeleteMovie(movieId);
            return result;
        }

        /// <summary>
        /// edit movie based on perticular Id.
        /// </summary>
        /// <param name="movie"></param>
        public bool EditMovie(Movie movie)
        {
            bool result = _dalContext.MovieDAL.EditMovie(movie);
            return result;
        }

        /// <summary>
        /// get movie by id.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Movie GetMovieById(int Id)
        {
            var movie = _dalContext.MovieDAL.GetMovieById(Id);
            return movie;
        }

        /// <summary>
        /// list of movie.
        /// </summary>
        /// <returns></returns>
        public List<Movie> GetMovies()
        {
            return _dalContext.MovieDAL.GetMovies();
        }
    }
}
