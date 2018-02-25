using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using ProjetDotNet.Models;
using ProjetDotNet.Repositories;

namespace ProjetDotNet.Controllers
{
    public class UsersController : Controller
    {
        private UsersRepository usersRepository;

        public UsersController()
        {
            this.usersRepository = new UsersRepository(new Academy());
        }

        public UsersController(UsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public ActionResult Index()
        {
            return View(usersRepository.GetAll());
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = usersRepository.GetById(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Password,FirstName,LastName,Mail")] Users users)
        {
            if (ModelState.IsValid)
            {
                users.Id = Guid.NewGuid();
                usersRepository.Add(users);
                usersRepository.Save();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = usersRepository.GetById(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Password,FirstName,LastName,Mail")] Users users)
        {
            if (ModelState.IsValid)
            {
                usersRepository.SetEntryState(users, EntityState.Modified);
                usersRepository.Save();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users users = usersRepository.GetById(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Users users = usersRepository.GetById(id);
            usersRepository.Remove(users);
            usersRepository.Save();
            return RedirectToAction("Index");
        }
        
    }
}
