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
    public class ResultsController : Controller
    {
        private Academy db = new Academy();

        // GET: Results
        public ActionResult Index()
        {
            var results = db.Results.Include(r => r.Evaluations).Include(r => r.Pupils);
            return View(results.ToList());
        }

        // GET: Results/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // GET: Results/Create
        public ActionResult Create()
        {
            ViewBag.Evaluation_Id = new SelectList(db.Evaluations, "Id", "Id");
            ViewBag.Pupil_Id = new SelectList(db.Pupils, "Id", "FirstName");
            return View();
        }

        // POST: Results/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Evaluation_Id,Pupil_Id,Note")] Results results)
        {
            if (ModelState.IsValid)
            {
                results.Id = Guid.NewGuid();
                db.Results.Add(results);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Evaluation_Id = new SelectList(db.Evaluations, "Id", "Id", results.Evaluation_Id);
            ViewBag.Pupil_Id = new SelectList(db.Pupils, "Id", "FirstName", results.Pupil_Id);
            return View(results);
        }

        // GET: Results/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            ViewBag.Evaluation_Id = new SelectList(db.Evaluations, "Id", "Id", results.Evaluation_Id);
            ViewBag.Pupil_Id = new SelectList(db.Pupils, "Id", "FirstName", results.Pupil_Id);
            return View(results);
        }

        // POST: Results/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Evaluation_Id,Pupil_Id,Note")] Results results)
        {
            if (ModelState.IsValid)
            {
                db.Entry(results).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Evaluation_Id = new SelectList(db.Evaluations, "Id", "Id", results.Evaluation_Id);
            ViewBag.Pupil_Id = new SelectList(db.Pupils, "Id", "FirstName", results.Pupil_Id);
            return View(results);
        }

        // GET: Results/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Results results = db.Results.Find(id);
            if (results == null)
            {
                return HttpNotFound();
            }
            return View(results);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Results results = db.Results.Find(id);
            db.Results.Remove(results);
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
