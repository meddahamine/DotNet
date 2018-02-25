using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class LevelsController : Controller
    {
        private LevelsRepository levelsRepository;

        public LevelsController()
        {
            this.levelsRepository = new LevelsRepository(new Academy());
        }

        public LevelsController(LevelsRepository levelsRepository)
        {
            this.levelsRepository = levelsRepository;
        }

        public ActionResult Index()
        {            
            return View(levelsRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Levels levels = levelsRepository.GetById(id);
            if (levels == null)
            {
                return HttpNotFound();
            }
            return View(levels);
        }

        public ActionResult Create()
        {
            ViewBag.Cycle_Id = new SelectList(levelsRepository.GetAcademy().Cycles, "Id", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Cycle_Id")] Levels levels)
        {
            if (ModelState.IsValid)
            {
                levels.Id = Guid.NewGuid();
                levelsRepository.Add(levels);
                levelsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.Cycle_Id = new SelectList(levelsRepository.GetAcademy().Cycles, "Id", "Title", levels.Cycle_Id);
            return View(levels);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Levels levels = levelsRepository.GetById(id);
            if (levels == null)
            {
                return HttpNotFound();
            }
            ViewBag.Cycle_Id = new SelectList(levelsRepository.GetAcademy().Cycles, "Id", "Title", levels.Cycle_Id);
            return View(levels);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Cycle_Id")] Levels levels)
        {
            if (ModelState.IsValid)
            {
                levelsRepository.SetEntryState(levels, EntityState.Modified);
                levelsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.Cycle_Id = new SelectList(levelsRepository.GetAcademy().Cycles, "Id", "Title", levels.Cycle_Id);
            return View(levels);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Levels levels = levelsRepository.GetById(id);
            if (levels == null)
            {
                return HttpNotFound();
            }
            return View(levels);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Levels levels = levelsRepository.GetById(id);
            levelsRepository.Remove(levels);
            levelsRepository.Save();
            return RedirectToAction("Index");
        }

    }
}
