using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetDotNet.Models;

namespace ProjetDotNet.Controllers
{
    public class TutorsController : Controller
    {
        private Academy db = new Academy();

        // GET: Tutors
        public ActionResult Index()
        {
            return View(db.Tutors.ToList());
        }

        // GET: Tutors/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // GET: Tutors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tutors/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,Address,PostCode,Town,Tel,Mail,Comment")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                tutors.Id = Guid.NewGuid();
                db.Tutors.Add(tutors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tutors);
        }

        // GET: Tutors/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,Address,PostCode,Town,Tel,Mail,Comment")] Tutors tutors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tutors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tutors);
        }

        // GET: Tutors/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tutors tutors = db.Tutors.Find(id);
            if (tutors == null)
            {
                return HttpNotFound();
            }
            return View(tutors);
        }

        // POST: Tutors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Tutors tutors = db.Tutors.Find(id);
            db.Tutors.Remove(tutors);
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
