using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class EvaluationsController : Controller
    {
        private EvaluationsRepository evaluationsRepository;

        public EvaluationsController()
        {
            this.evaluationsRepository = new EvaluationsRepository(new Academy());
        }

        public EvaluationsController(EvaluationsRepository evaluationsRepository)
        {
            this.evaluationsRepository = evaluationsRepository;
        }

        public ActionResult Index()
        {
            return View(evaluationsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = evaluationsRepository.GetById(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(evaluationsRepository.GetAcademy().Classrooms, "Id", "Title");
            ViewBag.Period_Id = new SelectList(evaluationsRepository.GetAcademy().Periods, "Id", "Id");
            ViewBag.User_Id = new SelectList(evaluationsRepository.GetAcademy().Users, "Id", "UserName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Classroom_Id,User_Id,Period_Id,Date,TotalPoint")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                evaluations.Id = Guid.NewGuid();
                evaluationsRepository.Add(evaluations);
                evaluationsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(evaluationsRepository.GetAcademy().Classrooms, "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(evaluationsRepository.GetAcademy().Periods, "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(evaluationsRepository.GetAcademy().Users, "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = evaluationsRepository.GetById(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(evaluationsRepository.GetAcademy().Classrooms, "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(evaluationsRepository.GetAcademy().Periods, "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(evaluationsRepository.GetAcademy().Users, "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Classroom_Id,User_Id,Period_Id,Date,TotalPoint")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                evaluationsRepository.SetEntryState(evaluations, EntityState.Modified);
                evaluationsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Classroom_Id = new SelectList(evaluationsRepository.GetAcademy().Classrooms, "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(evaluationsRepository.GetAcademy().Periods, "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(evaluationsRepository.GetAcademy().Users, "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = evaluationsRepository.GetById(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Evaluations evaluations = evaluationsRepository.GetById(id);
            evaluationsRepository.Remove(evaluations);
            evaluationsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
