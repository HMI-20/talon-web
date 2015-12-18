//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using OnlineCoupone.Web.Models;

//namespace OnlineCoupone.Web.Repository
//{
//    public class SpecialityRepository : IDisposable
//    {
//        private ContextName _context;
//        private bool _disposed = false;

//        public SpecialityRepository(ContextName context)
//        {
//            _context = context;
//        }

//        public void DeleteSpeciality(int specialityId)
//        {
//            Speciality speciality = _context.Speciality.Find(specialityId);
//            if (speciality == null)
//            {
//                throw new ArgumentException();
//            }
//            _context.Speciality.Remove(speciality);
//        }

//        public Speciality GetByID(int specialityId)
//        {
//            return _context.Speciality.Find(specialityId);
//        }

//        public IEnumerable<Speciality> Get()
//        {
//            return _context.Speciality.ToList();
//        }

//        public void InsertSpeciality(Speciality speciality)
//        {
//            _context.Speciality.Add(speciality);
//        }

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public void UpdateSpeciality(Speciality speciality)
//        {
//            _context.Entry(speciality).State = System.Data.Entity.EntityState.Modified;
//        }

//        protected virtual void Dispose(bool disposing)
//        {
//            if (!_disposed)
//            {
//                if (disposing)
//                {
//                    _context.Dispose();
//                }
//            }
//            _disposed = true;
//        }

//        public void Dispose()
//        {
//            Dispose(true);
//            GC.SuppressFinalize(this);
//        }
//    }
//}