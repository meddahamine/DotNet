using ProjetDotNet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjetDotNet.Repositories
{
    public class PupilsRepository : IDisposable
    {
        private Academy db;


        public PupilsRepository(Academy db)
        {
            this.db = db;
        }

        public IEnumerable<Pupils> GetPupils()
        {
            var pupils = db.Pupils.Include(p => p.Classrooms).Include(p => p.Levels).Include(p => p.Tutors);
            return pupils.ToList();
        }

        public Pupils GetPupilsById(Guid? id)
        {
            return db.Pupils.Find(id);
        }

        public void AddPupils(Pupils pupils)
        {
            db.Pupils.Add(pupils);
        }

        public void Remove(Pupils pupils)
        {
            db.Pupils.Remove(pupils);
        }

        public void SetEntryState(Pupils pupils, EntityState entityState)
        {
            db.Entry(pupils).State = entityState;
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public Academy GetAcademyEntities()
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