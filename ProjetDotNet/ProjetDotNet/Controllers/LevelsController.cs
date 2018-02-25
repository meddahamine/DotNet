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
    public class LevelsController : Controller
    {
        private Academy db = new Academy();

        // GET: Levels
        public ActionResult Index()
        {
            var levels = db.Levels.Include(l => l.Cycles);
            return View(levels.ToList());
        }

        // GET: Levels/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Levels levels = db.Levels.Find(id);
            if (levels == null)
            {
                return HttpNotFound();
            }
            return View(levels);
        }

        // GET: Levels/Create
        public ActionResult Create()
        {
            ViewBag.Cycle_Id = new SelectList(db.Cycles, "Id", "Title");
            return View();
        }

        // POST: Levels/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Cycle_Id")] Levels levels)
        {
            if (ModelState.IsValid)
            {
                levels.Id = Guid.NewGuid();
                db.Levels.Add(levels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Cycle_Id = new SelectList(db.Cycles, "Id", "Title", levels.Cycle_Id);
            return View(levels);
        }

        // GET: Levels/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Levels levels = db.Levels.Find(id);
            if (levels == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cycle_Id = new SelectList(db.Cycles, "Id", "Title", levels.Cycle_Id);
            return View(levels);
        }

        // POST: Levels/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Cycle_Id")] Levels levels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(levels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Cycle_Id = new SelectList(db.Cycles, "Id", "Title", levels.Cycle_Id);
            return View(levels);
        }

        // GET: Levels/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Levels levels = db.Levels.Find(id);
            if (levels == null)
            {
                return HttpNotFound();
            }
            return View(levels);
        }

        // POST: Levels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Levels levels = db.Levels.Find(id);
            db.Levels.Remove(levels);
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
