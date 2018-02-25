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

        // GET: Pupils
        public ActionResult Index()
        {
            return View(pupilsRepository.GetPupils());
        }

        // GET: Pupils/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = pupilsRepository.GetPupilsById(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        // GET: Pupils/Create
        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademyEntities().Classrooms, "Id", "Title");
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademyEntities().Levels, "Id", "Title");
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademyEntities().Tutors, "Id", "LastName");
            return View();
        }

        // POST: Pupils/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Sex,BirthdayDate,State,Tutor_Id,Classroom_Id,Level_Id")] Pupils pupils)
        {
            if (ModelState.IsValid)
            {
                pupils.Id = Guid.NewGuid();
                pupilsRepository.AddPupils(pupils);
                pupilsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademyEntities().Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademyEntities().Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademyEntities().Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // GET: Pupils/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = pupilsRepository.GetPupilsById(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademyEntities().Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademyEntities().Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademyEntities().Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // POST: Pupils/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.Classroom_Id = new SelectList(pupilsRepository.GetAcademyEntities().Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(pupilsRepository.GetAcademyEntities().Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(pupilsRepository.GetAcademyEntities().Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // GET: Pupils/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = pupilsRepository.GetPupilsById(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        // POST: Pupils/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Pupils pupils = pupilsRepository.GetPupilsById(id);
            pupilsRepository.Remove(pupils);
            pupilsRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                pupilsRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
