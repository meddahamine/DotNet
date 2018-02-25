using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class ClassroomsController : Controller
    {

        private ClassroomsRepository classroomsRepository;

        public ClassroomsController()
        {
            this.classroomsRepository = new ClassroomsRepository(new Academy());
        }

        public ClassroomsController(ClassroomsRepository classroomsRepository)
        {
            this.classroomsRepository = classroomsRepository;
        }

        public ActionResult Index()
        {
            return View(classroomsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = classroomsRepository.GetById(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            return View(classrooms);
        }

        public ActionResult Create()
        {
            ViewBag.Establishment_Id = new SelectList(classroomsRepository.GetAcademy().Establishments, "Id", "Name");
            ViewBag.User_Id = new SelectList(classroomsRepository.GetAcademy().Users, "Id", "UserName");
            ViewBag.Year_Id = new SelectList(classroomsRepository.GetAcademy().Years, "Id", "Year");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,User_Id,Year_Id,Establishment_Id")] Classrooms classrooms)
        {
            if (ModelState.IsValid)
            {
                classrooms.Id = Guid.NewGuid();
                classroomsRepository.Add(classrooms);
                classroomsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Establishment_Id = new SelectList(classroomsRepository.GetAcademy().Establishments, "Id", "Name", classrooms.Establishment_Id);
            ViewBag.User_Id = new SelectList(classroomsRepository.GetAcademy().Users, "Id", "UserName", classrooms.User_Id);
            ViewBag.Year_Id = new SelectList(classroomsRepository.GetAcademy().Years, "Id", "Year", classrooms.Year_Id);
            return View(classrooms);
        }

        // GET: Classrooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = classroomsRepository.GetById(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.Establishment_Id = new SelectList(classroomsRepository.GetAcademy().Establishments, "Id", "Name", classrooms.Establishment_Id);
            ViewBag.User_Id = new SelectList(classroomsRepository.GetAcademy().Users, "Id", "UserName", classrooms.User_Id);
            ViewBag.Year_Id = new SelectList(classroomsRepository.GetAcademy().Years, "Id", "Year", classrooms.Year_Id);
            return View(classrooms);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,User_Id,Year_Id,Establishment_Id")] Classrooms classrooms)
        {
            if (ModelState.IsValid)
            {
                classroomsRepository.SetEntryState(classrooms, EntityState.Modified);
                classroomsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Establishment_Id = new SelectList(classroomsRepository.GetAcademy().Establishments, "Id", "Name", classrooms.Establishment_Id);
            ViewBag.User_Id = new SelectList(classroomsRepository.GetAcademy().Users, "Id", "UserName", classrooms.User_Id);
            ViewBag.Year_Id = new SelectList(classroomsRepository.GetAcademy().Years, "Id", "Year", classrooms.Year_Id);
            return View(classrooms);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = classroomsRepository.GetById(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            return View(classrooms);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Classrooms classrooms = classroomsRepository.GetById(id);
            classroomsRepository.Remove(classrooms);
            classroomsRepository.Save();
            return RedirectToAction("Index");
        }
        
    }
}
