using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class CyclesController : Controller
    {
        private CyclesRepository cyclesRepository;

        public CyclesController()
        {
            this.cyclesRepository = new CyclesRepository(new Academy());
        }

        public CyclesController(CyclesRepository cyclesRepository)
        {
            this.cyclesRepository = cyclesRepository;
        }

        public ActionResult Index()
        {
            return View(cyclesRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = cyclesRepository.GetById(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title")] Cycles cycles)
        {
            if (ModelState.IsValid)
            {
                cycles.Id = Guid.NewGuid();
                cyclesRepository.Add(cycles);
                cyclesRepository.Save();
                return RedirectToAction("Index");
            }

            return View(cycles);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = cyclesRepository.GetById(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title")] Cycles cycles)
        {
            if (ModelState.IsValid)
            {
                cyclesRepository.SetEntryState(cycles, EntityState.Modified);
                cyclesRepository.Save();
                return RedirectToAction("Index");
            }
            return View(cycles);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cycles cycles = cyclesRepository.GetById(id);
            if (cycles == null)
            {
                return HttpNotFound();
            }
            return View(cycles);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Cycles cycles = cyclesRepository.GetById(id);
            cyclesRepository.Remove(cycles);
            cyclesRepository.Save();
            return RedirectToAction("Index");
        }        
    }
}
