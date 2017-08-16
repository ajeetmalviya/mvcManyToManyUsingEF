using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IMDB.Web.Models
{
    public class ProducerViewModel
    {
        public ProducerViewModel()
        {
            this.Movies = new List<MovieViewModel>();
        }

        public int ProducerId { get; set; }
        [Display(Name = "Producer Name")]
        [Required(ErrorMessage ="Producer Name is required")]
        public string ProducerName { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Producer gender is required")]
        public string ProducerGender { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        [Display(Name = "Date of Birth")]
        public Nullable<System.DateTime> ProducerDOB { get; set; }

        [Display(Name = "Producer Bio")]
        [Required(ErrorMessage = "Bio is required")]
        public string ProducerBio { get; set; }
        public virtual ICollection<MovieViewModel> Movies { get; set; }

        public Producer ToModel()
        {
            var producer = new Producer
            {
                ProducerName = ProducerName,
                Gender = ProducerGender,
                DOB = ProducerDOB,
                Bio = ProducerBio,
            };

            return producer;
        }
    }
}