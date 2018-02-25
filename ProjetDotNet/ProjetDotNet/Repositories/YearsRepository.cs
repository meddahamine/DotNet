using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class YearsRepository : IDisposable
    {


        private Academy db;

        public YearsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Years> GetAll()
        {
            return db.Years.ToList();
        }

        public Years GetById(Guid? id)
        {
            return db.Years.Find(id);
        }

        public void Add(Years years)
        {
            db.Years.Add(years);
        }

        public void Remove(Years years)
        {
            db.Years.Remove(years);
        }

        public void SetEntryState(Years years, EntityState entityState)
        {
            db.Entry(years).State = entityState;
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