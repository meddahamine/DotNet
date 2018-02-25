using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class PeriodsController : Controller
    {
        private PeriodsRepository periodsRepository;

        public PeriodsController()
        {
            this.periodsRepository = new PeriodsRepository(new Academy());
        }

        public PeriodsController(PeriodsRepository periodsRepository)
        {
            this.periodsRepository = periodsRepository;
        }

        public ActionResult Index()
        {
           return View(periodsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = periodsRepository.GetById(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            return View(periods);
        }

        public ActionResult Create()
        {
            ViewBag.Year_Id = new SelectList(periodsRepository.GetAcademy().Years, "Id", "Year");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Begin,End,Year_Id")] Periods periods)
        {
            if (ModelState.IsValid)
            {
                periods.Id = Guid.NewGuid();
                periodsRepository.Add(periods);
                periodsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Year_Id = new SelectList(periodsRepository.GetAcademy().Years, "Id", "Year", periods.Year_Id);
            return View(periods);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = periodsRepository.GetById(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            ViewBag.Year_Id = new SelectList(periodsRepository.GetAcademy().Years, "Id", "Id", periods.Year_Id);
            return View(periods);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Begin,End,Year_Id")] Periods periods)
        {
            if (ModelState.IsValid)
            {
                periodsRepository.SetEntryState(periods, EntityState.Modified);
                periodsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Year_Id = new SelectList(periodsRepository.GetAcademy().Years, "Id", "Id", periods.Year_Id);
            return View(periods);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = periodsRepository.GetById(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            return View(periods);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Periods periods = periodsRepository.GetById(id);
            periodsRepository.Remove(periods);
            periodsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
