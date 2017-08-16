using System;
using System.Collections.Generic;

namespace IMDB.Entities.Models
{
    public partial class Actor
    {
        public Actor()
        {
            this.Movies = new List<Movie>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
