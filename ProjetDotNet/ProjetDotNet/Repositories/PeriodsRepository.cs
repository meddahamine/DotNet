using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class PeriodsRepository : IDisposable
    {

        private Academy db;

        public PeriodsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Periods> GetAll()
        {
            var periods = db.Periods.Include(p => p.Years);
            return periods.ToList();
        }

        public Periods GetById(Guid? id)
        {
            return db.Periods.Find(id);
        }

        public void Add(Periods periods)
        {
            db.Periods.Add(periods);
        }

        public void Remove(Periods periods)
        {
            db.Periods.Remove(periods);
        }

        public void SetEntryState(Periods periods, EntityState entityState)
        {
            db.Entry(periods).State = entityState;
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