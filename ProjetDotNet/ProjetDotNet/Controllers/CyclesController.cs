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
    public class CyclesController : Controller
    {
        private Academy db = new Academy();

        // GET: Cycles
        public ActionResult Index()
        {
            return View(db.Cycles.ToList());
        }

        // GET: Cycles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = db.Cycles.Find(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        // GET: Cycles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cycles/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Cycles cycles)
        {
            if (ModelState.IsValid)
            {
                cycles.Id = Guid.NewGuid();
                db.Cycles.Add(cycles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cycles);
        }

        // GET: Cycles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = db.Cycles.Find(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        // POST: Cycles/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Cycles cycles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cycles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cycles);
        }

        // GET: Cycles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = db.Cycles.Find(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        // POST: Cycles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cycles cycles = db.Cycles.Find(id);
            db.Cycles.Remove(cycles);
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
