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
    public class ClassroomsController : Controller
    {
        private Academy db = new Academy();

        // GET: Classrooms
        public ActionResult Index()
        {
            var classrooms = db.Classrooms.Include(c => c.Establishments).Include(c => c.Users).Include(c => c.Years);
            return View(classrooms.ToList());
        }

        // GET: Classrooms/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = db.Classrooms.Find(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            return View(classrooms);
        }

        // GET: Classrooms/Create
        public ActionResult Create()
        {
            ViewBag.Establishment_Id = new SelectList(db.Establishments, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName");
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Id");
            return View();
        }

        // POST: Classrooms/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,User_Id,Year_Id,Establishment_Id")] Classrooms classrooms)
        {
            if (ModelState.IsValid)
            {
                classrooms.Id = Guid.NewGuid();
                db.Classrooms.Add(classrooms);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Establishment_Id = new SelectList(db.Establishments, "Id", "Name", classrooms.Establishment_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", classrooms.User_Id);
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Id", classrooms.Year_Id);
            return View(classrooms);
        }

        // GET: Classrooms/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = db.Classrooms.Find(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            ViewBag.Establishment_Id = new SelectList(db.Establishments, "Id", "Name", classrooms.Establishment_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", classrooms.User_Id);
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Id", classrooms.Year_Id);
            return View(classrooms);
        }

        // POST: Classrooms/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,User_Id,Year_Id,Establishment_Id")] Classrooms classrooms)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classrooms).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Establishment_Id = new SelectList(db.Establishments, "Id", "Name", classrooms.Establishment_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", classrooms.User_Id);
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Id", classrooms.Year_Id);
            return View(classrooms);
        }

        // GET: Classrooms/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classrooms classrooms = db.Classrooms.Find(id);
            if (classrooms == null)
            {
                return HttpNotFound();
            }
            return View(classrooms);
        }

        // POST: Classrooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Classrooms classrooms = db.Classrooms.Find(id);
            db.Classrooms.Remove(classrooms);
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
