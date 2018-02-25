using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class EstablishmentsRepository : IDisposable
    {


        private Academy db;

        public EstablishmentsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Establishments> GetAll()
        {
            var establishments = db.Establishments.Include(e => e.Academies).Include(e => e.Users);
            return db.Establishments.ToList();
        }

        public Establishments GetById(Guid? id)
        {
            return db.Establishments.Find(id);
        }

        public void Add(Establishments establishments)
        {
            db.Establishments.Add(establishments);
        }

        public void Remove(Establishments establishments)
        {
            db.Establishments.Remove(establishments);
        }

        public void SetEntryState(Establishments establishments, EntityState entityState)
        {
            db.Entry(establishments).State = entityState;
        }

        public Academy GetAcademy()
        {
            return db;
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