using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Web.Models
{
    public class MovieViewModel
    {
        #region Fields
        private List<SelectListItem> _Actors;
        private List<SelectListItem> _Producers; 
        #endregion

        #region Constructors
        public MovieViewModel()
        {
        }

        public MovieViewModel(Movie movie)
        {
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            MoviesName = movie.MoviesName;
            YOR = movie.YOR;
            Plot = movie.Plot;
            Poster = movie.Poster;
            ProducerId = movie.ProducerId;
        } 
        #endregion

        #region Properties
        public int MovieId { get; set; }

        [Required(ErrorMessage ="Movie name is required.")]
        public string MoviesName { get; set; }

        [Required(ErrorMessage = "Please select year of release.")]
        public int YOR { get; set; }

        [Required(ErrorMessage = "Plot is required.")]
        public string Plot { get; set; }

       // [Required(ErrorMessage ="Select the image")]
        public string Poster { get; set; }

        [Required(ErrorMessage = "Please select Producer.")]
        public int ProducerId { get; set; }

        
        public string Producer { get; set; }
        public List<int> SelectedActors { get; set; }
        public List<int> SelectedProducer { get; set; }
        
        public List<SelectListItem> Actors
        {
            get
            {
                if (_Actors == null)
                    return new List<SelectListItem>();

                return _Actors;
            }
            set
            {
                _Actors = value;
            }
        }        
        public List<SelectListItem> Producers
        {
            get
            {
                if (_Producers == null)
                    return new List<SelectListItem>();

                return _Producers;
            }
            set
            {
                _Producers = value;
            }
        }
        #endregion

        #region Methods
        public Movie ToModel()
        {
            var movie = new Movie
            {
                MoviesName = MoviesName,
                YOR = YOR,
                Plot = Plot,
                Poster = Poster,
                ProducerId = ProducerId,                
            };

            return movie;
        }

        public void UpdateEntity(Movie movie)
        {
            movie.MovieId = MovieId;
            movie.MoviesName = MoviesName;
            movie.YOR = YOR;
            movie.Plot = Plot;
            movie.Poster = Poster;
            movie.ProducerId = ProducerId;
        } 
        #endregion
    }
}