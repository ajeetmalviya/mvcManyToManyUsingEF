using System;
using System.Collections.Generic;

namespace IMDB.Entities.Models
{
    public partial class Producer
    {
        public Producer()
        {
            this.Movies = new List<Movie>();
        }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Bio { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }
    }
}
