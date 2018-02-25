using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class ResultsRepository : IDisposable
    {

        private Academy db;

        public ResultsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Results> GetAll()
        {
            var results = db.Results.Include(r => r.Evaluations).Include(r => r.Pupils);
            return results.ToList();
        }

        public Results GetById(Guid? id)
        {
            return db.Results.Find(id);
        }

        public void Add(Results results)
        {
            db.Results.Add(results);
        }

        public void Remove(Results results)
        {
            db.Results.Remove(results);
        }

        public void SetEntryState(Results results, EntityState entityState)
        {
            db.Entry(results).State = entityState;
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