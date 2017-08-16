using IMDB.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Web.Models
{
    public class ActorViewModel
    {
        public ActorViewModel()
        {
            this.Movies = new List<MovieViewModel>();
        }

        public int ActorId { get; set; }

        [Required(ErrorMessage ="Actor name is required.")]
        [Display(Name ="Actor Name")]
        public string ActorName { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public Nullable<System.DateTime> DOB { get; set; }

        [Required(ErrorMessage = "Bio name is required.")]
        public string Bio { get; set; }

        [Required(ErrorMessage = "Gender name is required.")]
        public string Gender { get; set; }
        public virtual ICollection<MovieViewModel> Movies { get; set; }
        public bool IsSelected { get; set; }


        public Actor ToModel()
        {
            var actor = new Actor
            {
                ActorName = ActorName,
                Gender = Gender,
                DOB = DOB,
                Bio = Bio,
            };

            return actor;
        }

        public IEnumerable<SelectListItem> GetGenderSelectItems()
        {
            yield return new SelectListItem { Text = "Male", Value = "Male" };
            yield return new SelectListItem { Text = "Female", Value = "Female" };
            yield return new SelectListItem { Text = "Others", Value = "Others" };
        }
    }
}