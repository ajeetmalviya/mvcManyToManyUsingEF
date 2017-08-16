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
    public class ProducerController : Controller
    {

        private IUoWRepository _repContext = null;
        public ProducerController()
            : this(new UoWRepository())
        {

        }
        public ProducerController(IUoWRepository repContext)
        {
            _repContext = repContext;
        }

        public ActionResult GetProducers()
        {
            List<ProducerViewModel> model = new List<ProducerViewModel>();
            var producers = _repContext.ProducerRep.GetProducer();
            if (producers != null)
            {
                foreach (var producer in producers)
                {
                    model.Add(new ProducerViewModel()
                    {
                        ProducerName = producer.ProducerName,
                        ProducerGender = producer.Gender,
                        ProducerBio = producer.Bio,
                        ProducerDOB = producer.DOB
                    });
                }
            }
            return View(model);
        }

        public ActionResult AddProducer()
        {
            return View("_AddProducer");
        }

        [HttpPost]
        public ActionResult AddProducer(ProducerViewModel model)
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

            var duplicateProducer = _repContext.ProducerRep.GetProducer().Count(m => m.ProducerName.Trim().ToLower() == model.ProducerName.Trim().ToLower());
            if (duplicateProducer > 0)
            {
                ModelState.AddModelError(" ", "Producer is already in the database");
                return View(model);
            }

            var actor = model.ToModel();
            var result = _repContext.ProducerRep.AddProducer(actor);
            return new JsonResult() { Data = result };
        }
    }
}