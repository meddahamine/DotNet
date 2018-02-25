using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class UsersRepository : IDisposable
    {


        private Academy db;

        public UsersRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users.ToList();
        }

        public Users GetById(Guid? id)
        {
            return db.Users.Find(id);
        }

        public void Add(Users users)
        {
            db.Users.Add(users);
        }

        public void Remove(Users users)
        {
            db.Users.Remove(users);
        }

        public void SetEntryState(Users users, EntityState entityState)
        {
            db.Entry(users).State = entityState;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}