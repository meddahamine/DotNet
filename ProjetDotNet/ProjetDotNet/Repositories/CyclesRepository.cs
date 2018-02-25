using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class CyclesRepository : IDisposable
    {


        private Academy db;

        public CyclesRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Cycles> GetAll()
        {
            return db.Cycles.ToList();
        }

        public Cycles GetById(Guid? id)
        {
            return db.Cycles.Find(id);
        }

        public void Add(Cycles cycles)
        {
            db.Cycles.Add(cycles);
        }

        public void Remove(Cycles cycles)
        {
            db.Cycles.Remove(cycles);
        }

        public void SetEntryState(Cycles cycles, EntityState entityState)
        {
            db.Entry(cycles).State = entityState;
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