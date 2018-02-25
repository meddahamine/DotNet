using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class EstablishmentsController : Controller
    {
        private EstablishmentsRepository establishmentsRepository;

        public EstablishmentsController()
        {
            this.establishmentsRepository = new EstablishmentsRepository(new Academy());
        }

        public EstablishmentsController(EstablishmentsRepository establishmentsRepository)
        {
            this.establishmentsRepository = establishmentsRepository;
        }

       public ActionResult Index()
        {
            return View(establishmentsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = establishmentsRepository.GetById(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            return View(establishments);
        }

        public ActionResult Create()
        {
            ViewBag.Academie_Id = new SelectList(establishmentsRepository.GetAcademy().Academies, "Id", "Name");
            ViewBag.User_Id = new SelectList(establishmentsRepository.GetAcademy().Users, "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,PostCode,Town,User_Id,Academie_Id")] Establishments establishments)
        {
            if (ModelState.IsValid)
            {
                establishments.Id = Guid.NewGuid();
                establishmentsRepository.Add(establishments);
                establishmentsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Academie_Id = new SelectList(establishmentsRepository.GetAcademy().Academies, "Id", "Name", establishments.Academie_Id);
            ViewBag.User_Id = new SelectList(establishmentsRepository.GetAcademy().Users, "Id", "UserName", establishments.User_Id);
            return View(establishments);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = establishmentsRepository.GetById(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Academie_Id = new SelectList(establishmentsRepository.GetAcademy().Academies, "Id", "Name", establishments.Academie_Id);
            ViewBag.User_Id = new SelectList(establishmentsRepository.GetAcademy().Users, "Id", "UserName", establishments.User_Id);
            return View(establishments);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,PostCode,Town,User_Id,Academie_Id")] Establishments establishments)
        {
            if (ModelState.IsValid)
            {
                establishmentsRepository.SetEntryState(establishments, EntityState.Modified);
                establishmentsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Academie_Id = new SelectList(establishmentsRepository.GetAcademy().Academies, "Id", "Name", establishments.Academie_Id);
            ViewBag.User_Id = new SelectList(establishmentsRepository.GetAcademy().Users, "Id", "UserName", establishments.User_Id);
            return View(establishments);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = establishmentsRepository.GetById(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            return View(establishments);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Establishments establishments = establishmentsRepository.GetById(id);
            establishmentsRepository.Remove(establishments);
            establishmentsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
