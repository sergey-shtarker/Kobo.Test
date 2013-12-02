using Kobo.Test.MvcApplication.Contracts;
using Kobo.Test.MvcApplication.Models;
using Kobo.Test.MvcApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Kobo.Test.MvcApplication.Controllers
{
    public class PersonController : Controller
    {
        IPersonModelService _personModelService;

        public PersonController(IPersonModelService personModelService)
        {
            _personModelService = personModelService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            IList<PersonItemModel> list = _personModelService.GetPersonItemModelList();
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PersonModel personModel)
        {
            try
            {
                _personModelService.CreatePerson(personModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(long id)
        {
            PersonModel personModel = _personModelService.GetPersonModel(id);
            return View(personModel);
        }

        [HttpPost]
        public ActionResult Edit(long id, PersonModel personModel)
        {
            try
            {
                _personModelService.UpdatePerson(personModel);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Delete(long id)
        {
            _personModelService.DeletePerson(id);

            return RedirectToAction("Index");
        }
    }
}
