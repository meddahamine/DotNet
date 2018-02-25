using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class AcademiesRepository : IDisposable
    {


        private Academy db;

        public AcademiesRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Academies> GetAll()
        {
            return db.Academies.ToList();
        }

        public Academies GetById(Guid? id)
        {
            return db.Academies.Find(id);
        }

        public void Add(Academies academies)
        {
            db.Academies.Add(academies);
        }

        public void Remove(Academies academies)
        {
            db.Academies.Remove(academies);
        }

        public void SetEntryState(Academies academies, EntityState entityState)
        {
            db.Entry(academies).State = entityState;
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