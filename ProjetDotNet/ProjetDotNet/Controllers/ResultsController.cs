using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class ResultsController : Controller
    {
        private ResultsRepository resultsRepository;

        public ResultsController()
        {
            this.resultsRepository = new ResultsRepository(new Academy());
        }

        public ResultsController(ResultsRepository resultsRepository)
        {
            this.resultsRepository = resultsRepository;
        }

        public ActionResult Index()
        {
            return View(resultsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = resultsRepository.GetById(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        public ActionResult Create()
        {
            ViewBag.Evaluation_Id = new SelectList(resultsRepository.GetAcademy().Evaluations, "Id", "Id");
            ViewBag.Pupil_Id = new SelectList(resultsRepository.GetAcademy().Pupils, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Evaluation_Id,Pupil_Id,Note")] Results results)
        {
            if (ModelState.IsValid)
            {
                results.Id = Guid.NewGuid();
                resultsRepository.Add(results);
                resultsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Evaluation_Id = new SelectList(resultsRepository.GetAcademy().Evaluations, "Id", "Id", results.Evaluation_Id);
            ViewBag.Pupil_Id = new SelectList(resultsRepository.GetAcademy().Pupils, "Id", "FirstName", results.Pupil_Id);
            return View(results);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = resultsRepository.GetById(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            ViewBag.Evaluation_Id = new SelectList(resultsRepository.GetAcademy().Evaluations, "Id", "Id", results.Evaluation_Id);
            ViewBag.Pupil_Id = new SelectList(resultsRepository.GetAcademy().Pupils, "Id", "FirstName", results.Pupil_Id);
            return View(results);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evaluation_Id,Pupil_Id,Note")] Results results)
        {
            if (ModelState.IsValid)
            {
                resultsRepository.SetEntryState(results, EntityState.Modified);
                resultsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Evaluation_Id = new SelectList(resultsRepository.GetAcademy().Evaluations, "Id", "Id", results.Evaluation_Id);
            ViewBag.Pupil_Id = new SelectList(resultsRepository.GetAcademy().Pupils, "Id", "FirstName", results.Pupil_Id);
            return View(results);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = resultsRepository.GetById(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Results results = resultsRepository.GetById(id);
            resultsRepository.Remove(results);
            resultsRepository.Save();
            return RedirectToAction("Index");
        }
    }
}
