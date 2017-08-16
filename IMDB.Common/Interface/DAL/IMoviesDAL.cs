using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Common.Interface.DAL
{
    public interface IMoviesDAL
    {
        List<Movie> GetMovies();
        int AddMovie(Movie movie);
        bool EditMovie(Movie movie);
        bool DeleteMovie(int movieId);
        Movie GetMovieById(int Id);
    }
}
