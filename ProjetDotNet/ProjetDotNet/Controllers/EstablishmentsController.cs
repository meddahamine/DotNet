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
    public class EstablishmentsController : Controller
    {
        private AcademyEntities db = new AcademyEntities();

        // GET: Establishments
        public ActionResult Index()
        {
            var establishments = db.Establishments.Include(e => e.Academies).Include(e => e.Users);
            return View(establishments.ToList());
        }

        // GET: Establishments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = db.Establishments.Find(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            return View(establishments);
        }

        // GET: Establishments/Create
        public ActionResult Create()
        {
            ViewBag.Academie_Id = new SelectList(db.Academies, "Id", "Name");
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName");
            return View();
        }

        // POST: Establishments/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Address,PostCode,Town,User_Id,Academie_Id")] Establishments establishments)
        {
            if (ModelState.IsValid)
            {
                establishments.Id = Guid.NewGuid();
                db.Establishments.Add(establishments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Academie_Id = new SelectList(db.Academies, "Id", "Name", establishments.Academie_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", establishments.User_Id);
            return View(establishments);
        }

        // GET: Establishments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = db.Establishments.Find(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            ViewBag.Academie_Id = new SelectList(db.Academies, "Id", "Name", establishments.Academie_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", establishments.User_Id);
            return View(establishments);
        }

        // POST: Establishments/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,PostCode,Town,User_Id,Academie_Id")] Establishments establishments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(establishments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Academie_Id = new SelectList(db.Academies, "Id", "Name", establishments.Academie_Id);
            ViewBag.User_Id = new SelectList(db.Users, "Id", "UserName", establishments.User_Id);
            return View(establishments);
        }

        // GET: Establishments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Establishments establishments = db.Establishments.Find(id);
            if (establishments == null)
            {
                return HttpNotFound();
            }
            return View(establishments);
        }

        // POST: Establishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Establishments establishments = db.Establishments.Find(id);
            db.Establishments.Remove(establishments);
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
