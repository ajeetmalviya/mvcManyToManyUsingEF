using IMDB.Common.Interface.Repository;
using IMDB.Repository;
using IMDB.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMDB.Web.Controllers
{
    public class ActorController : Controller
    {
        private IUoWRepository _repContext = null;
        public ActorController()
            : this(new UoWRepository())
        {

        }
        public ActorController(IUoWRepository repContext)
        {
            _repContext = repContext;
        }

        // GET: Actor
        public ActionResult GetActors()
        {
            List<ActorViewModel> model = new List<ActorViewModel>();
            var actors = _repContext.ActorRep.GetActors();
            if (actors != null)
            {
                foreach (var actor in actors)
                {
                    model.Add(new ActorViewModel()
                    {
                        ActorName = actor.ActorName,
                        Gender = actor.Gender,
                        Bio = actor.Bio,
                        DOB = actor.DOB
                    });
                }
            }
            return View(model);
        }

        public ActionResult AddActor()
        {

            return View("_AddActor");
        }

        [HttpPost]
        public ActionResult AddActor(ActorViewModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException();
            }

            var errorList = new List<string>();
            if (!ModelState.IsValid)
            {
                errorList = ModelState.Values.SelectMany(m => m.Errors).Select(e => e.ErrorMessage).ToList();
                return new JsonResult() { Data = errorList };

            }

            var duplicateActor = _repContext.ActorRep.GetActors().Count(m => m.ActorName.Trim().ToLower() == model.ActorName.Trim().ToLower());
            if (duplicateActor > 0)
            {
                ModelState.AddModelError(" ", "Actor is already in the database");
                return View(model);
            }

       

            var actor = model.ToModel();
            var result = _repContext.ActorRep.AddActor(actor);
            return new JsonResult() { Data = result };
        }
    }
}