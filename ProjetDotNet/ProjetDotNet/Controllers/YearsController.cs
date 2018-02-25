using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class YearsController : Controller
    {
        private YearsRepository yearsRepository;

        public YearsController()
        {
            this.yearsRepository = new YearsRepository(new Academy());
        }

        public YearsController(YearsRepository yearsRepository)
        {
            this.yearsRepository = yearsRepository;
        }

        public ActionResult Index()
        {
            return View(yearsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Years years = yearsRepository.GetById(id);
            if (years == null)
            {
                return HttpNotFound();
            }
            return View(years);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year")] Years years)
        {
            if (ModelState.IsValid)
            {
                years.Id = Guid.NewGuid();
                yearsRepository.Add(years);
                yearsRepository.Save();
                return RedirectToAction("Index");
            }

            return View(years);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Years years = yearsRepository.GetById(id);
            if (years == null)
            {
                return HttpNotFound();
            }
            return View(years);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year")] Years years)
        {
            if (ModelState.IsValid)
            {
                yearsRepository.SetEntryState(years, EntityState.Modified);
                yearsRepository.Save();
                return RedirectToAction("Index");
            }
            return View(years);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Years years = yearsRepository.GetById(id);
            if (years == null)
            {
                return HttpNotFound();
            }
            return View(years);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Years years = yearsRepository.GetById(id);
            yearsRepository.Remove(years);
            yearsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
