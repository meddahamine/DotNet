using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class AcademiesController : Controller
    {
        private AcademiesRepository academiesRepository;

        public AcademiesController()
        {
            this.academiesRepository = new AcademiesRepository(new Academy());
        }

        public AcademiesController(AcademiesRepository academiesRepository)
        {
            this.academiesRepository = academiesRepository;
        }

        public ActionResult Index()
        {
            return View(academiesRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = academiesRepository.GetById(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Academies academies)
        {
            if (ModelState.IsValid)
            {
                academies.Id = Guid.NewGuid();
                academiesRepository.Add(academies);
                academiesRepository.Save();
                return RedirectToAction("Index");
            }

            return View(academies);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = academiesRepository.GetById(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Academies academies)
        {
            if (ModelState.IsValid)
            {
                academiesRepository.SetEntryState(academies, EntityState.Modified);
                academiesRepository.Save();
                return RedirectToAction("Index");
            }
            return View(academies);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = academiesRepository.GetById(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Academies academies = academiesRepository.GetById(id);
            academiesRepository.Remove(academies);
            academiesRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
