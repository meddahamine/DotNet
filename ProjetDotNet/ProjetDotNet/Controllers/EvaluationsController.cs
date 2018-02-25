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
    public class EvaluationsController : Controller
    {
        private Academy db = new Academy();

        // GET: Evaluations
        public ActionResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Classrooms).Include(e => e.Periods).Include(e => e.Users);
            return View(evaluations.ToList());
        }

        // GET: Evaluations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = db.Evaluations.Find(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        // GET: Evaluations/Create
        public ActionResult Create()
        {
            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title");
            ViewBag.Period_Id = new SelectList(db.Periods, "Id", "Id");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Evaluations/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Classroom_Id,User_Id,Period_Id,Date,TotalPoint")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                evaluations.Id = Guid.NewGuid();
                db.Evaluations.Add(evaluations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(db.Periods, "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        // GET: Evaluations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = db.Evaluations.Find(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(db.Periods, "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        // POST: Evaluations/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Classroom_Id,User_Id,Period_Id,Date,TotalPoint")] Evaluations evaluations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evaluations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Classroom_Id = new SelectList(db.Classrooms, "Id", "Title", evaluations.Classroom_Id);
            ViewBag.Period_Id = new SelectList(db.Periods, "Id", "Id", evaluations.Period_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", evaluations.User_Id);
            return View(evaluations);
        }

        // GET: Evaluations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Evaluations evaluations = db.Evaluations.Find(id);
            if (evaluations == null)
            {
                return HttpNotFound();
            }
            return View(evaluations);
        }

        // POST: Evaluations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Evaluations evaluations = db.Evaluations.Find(id);
            db.Evaluations.Remove(evaluations);
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
