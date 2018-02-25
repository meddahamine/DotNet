using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers
{
    public class PupilsController : Controller
    {
        private Academy db = new Academy();

        // GET: Pupils
        public ActionResult Index()
        {
            var pupils = db.Pupils.Include(p => p.Classrooms).Include(p => p.Levels).Include(p => p.Tutors);
            return View(pupils.ToList());
        }

        // GET: Pupils/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            return View(pupils);
        }

        // GET: Pupils/Create
        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title");
            ViewBag.Level_Id = new SelectList(db.Levels, "Id", "Title");
            ViewBag.Tutor_Id = new SelectList(db.Tutors, "Id", "LastName");
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
                db.Pupils.Add(pupils);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(db.Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(db.Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // GET: Pupils/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = db.Pupils.Find(id);
            if (pupils == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(db.Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(db.Tutors, "Id", "LastName", pupils.Tutor_Id);
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
                db.Entry(pupils).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title", pupils.Classroom_Id);
            ViewBag.Level_Id = new SelectList(db.Levels, "Id", "Title", pupils.Level_Id);
            ViewBag.Tutor_Id = new SelectList(db.Tutors, "Id", "LastName", pupils.Tutor_Id);
            return View(pupils);
        }

        // GET: Pupils/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pupils pupils = db.Pupils.Find(id);
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
            Pupils pupils = db.Pupils.Find(id);
            db.Pupils.Remove(pupils);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
