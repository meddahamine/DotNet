using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class LevelsRepository : IDisposable
    {

        private Academy db;

        public LevelsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Levels> GetAll()
        {
            var levels = db.Levels.Include(l => l.Cycles);
            return levels.ToList();
        }

        public Levels GetById(Guid? id)
        {
            return db.Levels.Find(id);
        }

        public void Add(Levels levels)
        {
            db.Levels.Add(levels);
        }

        public void Remove(Levels levels)
        {
            db.Levels.Remove(levels);
        }

        public void SetEntryState(Levels levels, EntityState entityState)
        {
            db.Entry(levels).State = entityState;
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