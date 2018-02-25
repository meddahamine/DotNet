using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class TutorsRepository : IDisposable
    {


        private Academy db;

        public TutorsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Tutors> GetAll()
        {
            return db.Tutors.ToList();
        }

        public Tutors GetById(Guid? id)
        {
            return db.Tutors.Find(id);
        }

        public void Add(Tutors tutors)
        {
            db.Tutors.Add(tutors);
        }

        public void Remove(Tutors tutors)
        {
            db.Tutors.Remove(tutors);
        }

        public void SetEntryState(Tutors tutors, EntityState entityState)
        {
            db.Entry(tutors).State = entityState;
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