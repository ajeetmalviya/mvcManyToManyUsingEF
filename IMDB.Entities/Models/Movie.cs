using System;
using System.Collections.Generic;

namespace IMDB.Entities.Models
{
    public partial class Movie
    {
        public Movie()
        {
            this.Actors = new List<Actor>();
        }

        public int MovieId { get; set; }
        public string MoviesName { get; set; }
        public int YOR { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual ICollection<Actor> Actors { get; set; }
    }
}
