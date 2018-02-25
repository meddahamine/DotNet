using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class PupilsController : Controller
    {
        private PupilsRepository pupilsRepository;

        public PupilsController()
        {
            this.pupilsRepository = new PupilsRepository(new Academy());
        }

        public PupilsController(PupilsRepository pupilsRepository)
        {
            this.pupilsRepository = pupilsRepository;
        }

        public ActionResult Index()
        {
            return View(pupilsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = pupilsRepository.GetById(id);
            
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademy().Classrooms, "Id", "Title");
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademy().Levels, "Id", "Title");
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademy().Tutors, "Id", "LastName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Sex,BirthdayDate,State,Tutor_Id,Classroom_Id,Level_Id")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                pupils.Id = Guid.NewGuid();
                pupilsRepository.Add(pupils);
                pupilsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademy().Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademy().Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademy().Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = pupilsRepository.GetById(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademy().Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademy().Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademy().Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Sex,BirthdayDate,State,Tutor_Id,Classroom_Id,Level_Id")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                pupilsRepository.SetEntryState(pupils, EntityState.Modified);
                pupilsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademy().Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademy().Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademy().Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = pupilsRepository.GetById(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Pupils pupils = pupilsRepository.GetById(id);
            pupilsRepository.Remove(pupils);
            pupilsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
