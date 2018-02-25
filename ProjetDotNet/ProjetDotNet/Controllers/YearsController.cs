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
    public class YearsController : Controller
    {
        private Academy db = new Academy();

        // GET: Years
        public ActionResult Index()
        {
            return View(db.Years.ToList());
        }

        // GET: Years/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Years years = db.Years.Find(id);
            if (years == null)
            {
                return HttpNotFound();
            }
            return View(years);
        }

        // GET: Years/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Years/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year")] Years years)
        {
            if (ModelState.IsValid)
            {
                years.Id = Guid.NewGuid();
                db.Years.Add(years);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(years);
        }

        // GET: Years/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Years years = db.Years.Find(id);
            if (years == null)
            {
                return HttpNotFound();
            }
            return View(years);
        }

        // POST: Years/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year")] Years years)
        {
            if (ModelState.IsValid)
            {
                db.Entry(years).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(years);
        }

        // GET: Years/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Years years = db.Years.Find(id);
            if (years == null)
            {
                return HttpNotFound();
            }
            return View(years);
        }

        // POST: Years/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Years years = db.Years.Find(id);
            db.Years.Remove(years);
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
