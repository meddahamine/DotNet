using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class TutorsController : Controller
    {
        private TutorsRepository tutorsRepository;

        public TutorsController()
        {
            this.tutorsRepository = new TutorsRepository(new Academy());
        }

        public TutorsController(TutorsRepository tutorsRepository)
        {
            this.tutorsRepository = tutorsRepository;
        }

        public ActionResult Index()
        {
            return View(tutorsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = tutorsRepository.GetById(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Address,PostCode,Town,Tel,Mail,Comment")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                tutors.Id = Guid.NewGuid();
                tutorsRepository.Add(tutors);
                tutorsRepository.Save();
                return RedirectToAction("Index");
            }

            return View(tutors);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = tutorsRepository.GetById(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Address,PostCode,Town,Tel,Mail,Comment")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                tutorsRepository.SetEntryState(tutors, EntityState.Modified);
                tutorsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(tutors);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = tutorsRepository.GetById(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tutors tutors = tutorsRepository.GetById(id);
            tutorsRepository.Remove(tutors);
            tutorsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
