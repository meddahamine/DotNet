using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class ClassroomsRepository : IDisposable
    {

        private Academy db;
        
        public ClassroomsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Classrooms> GetAll()
        {
            var classrooms = db.Classrooms.Include(c => c.Establishments).Include(c => c.Users).Include(c => c.Years);
            return classrooms.ToList();
        }

        public Classrooms GetById(Guid? id)
        {
            return db.Classrooms.Find(id);
        }

        public void Add(Classrooms classrooms)
        {
            db.Classrooms.Add(classrooms);
        }

        public void Remove(Classrooms classrooms)
        {
            db.Classrooms.Remove(classrooms);
        }

        public void SetEntryState(Classrooms classrooms, EntityState entityState)
        {
            db.Entry(classrooms).State = entityState;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Academy GetAcademy()
        {
            return db;
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