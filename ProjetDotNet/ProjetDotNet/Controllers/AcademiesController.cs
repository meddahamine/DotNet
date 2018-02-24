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
    public class AcademiesController : Controller
    {
        private Academy db = new Academy();

        // GET: Academies
        public ActionResult Index()
        {
            return View(db.Academies.ToList());
        }

        // GET: Academies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        // GET: Academies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Academies/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Academies academies)
        {
            if (ModelState.IsValid)
            {
                academies.Id = Guid.NewGuid();
                db.Academies.Add(academies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(academies);
        }

        // GET: Academies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        // POST: Academies/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Academies academies)
        {
            if (ModelState.IsValid)
            {
                db.Entry(academies).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(academies);
        }

        // GET: Academies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Academies academies = db.Academies.Find(id);
            if (academies == null)
            {
                return HttpNotFound();
            }
            return View(academies);
        }

        // POST: Academies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Academies academies = db.Academies.Find(id);
            db.Academies.Remove(academies);
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
