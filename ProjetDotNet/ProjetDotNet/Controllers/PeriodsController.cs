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
    public class PeriodsController : Controller
    {
        private Academy db = new Academy();

        // GET: Periods
        public ActionResult Index()
        {
            var periods = db.Periods.Include(p => p.Years);
            return View(periods.ToList());
        }

        // GET: Periods/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = db.Periods.Find(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            return View(periods);
        }

        // GET: Periods/Create
        public ActionResult Create()
        {
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Year");
            return View();
        }

        // POST: Periods/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Begin,End,Year_Id")] Periods periods)
        {
            if (ModelState.IsValid)
            {
                periods.Id = Guid.NewGuid();
                db.Periods.Add(periods);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Year", periods.Year_Id);
            return View(periods);
        }

        // GET: Periods/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = db.Periods.Find(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Id", periods.Year_Id);
            return View(periods);
        }

        // POST: Periods/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Begin,End,Year_Id")] Periods periods)
        {
            if (ModelState.IsValid)
            {
                db.Entry(periods).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Year_Id = new SelectList(db.Years, "Id", "Id", periods.Year_Id);
            return View(periods);
        }

        // GET: Periods/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Periods periods = db.Periods.Find(id);
            if (periods == null)
            {
                return HttpNotFound();
            }
            return View(periods);
        }

        // POST: Periods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Periods periods = db.Periods.Find(id);
            db.Periods.Remove(periods);
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
