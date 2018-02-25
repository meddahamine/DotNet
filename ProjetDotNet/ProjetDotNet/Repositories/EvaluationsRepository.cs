using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class EvaluationsRepository : IDisposable
    {

        private Academy db;

        public EvaluationsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Evaluations> GetAll()
        {
            var evaluations = db.Evaluations.Include(e => e.Classrooms).Include(e => e.Periods).Include(e => e.Users);
            return evaluations.ToList();
        }

        public Evaluations GetById(Guid? id)
        {
            return db.Evaluations.Find(id);
        }

        public void Add(Evaluations evaluations)
        {
            db.Evaluations.Add(evaluations);
        }

        public void Remove(Evaluations evaluations)
        {
            db.Evaluations.Remove(evaluations);
        }

        public void SetEntryState(Evaluations evaluations, EntityState entityState)
        {
            db.Entry(evaluations).State = entityState;
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