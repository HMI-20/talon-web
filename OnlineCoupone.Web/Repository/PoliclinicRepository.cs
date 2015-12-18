//using System;
//using System.Collections.Generic;
//using System.Linq;
//using OnlineCoupone.Web.Models;
//using System.Web;

//namespace OnlineCoupone.Web.Repository
//{
//    public class PoliclinicRepository : IDisposable
//    {
//        private ContextName _context;
//        private bool _disposed = false;

//        public PoliclinicRepository(ContextName context)
//        {
//            _context = context;
//        }

//        public void DeletePoliclinic(int policlinicId)
//        {
//            Policlinic policlinic = _context.Policlinic.Find(policlinicId);
//            if (policlinic == null)
//            {
//                throw new ArgumentException();
//            }
//            _context.Policlinic.Remove(policlinic);
//        }

//        public Policlinic GetByID(int policlinicId)
//        {
//            return _context.Policlinic.Find(policlinicId);
//        }

//        public IEnumerable<Policlinic> Get()
//        {
//            return _context.Policlinic.ToList();
//        }

//        public void InsertPoliclinic(Policlinic policlinic)
//        {
//            _context.Policlinic.Add(policlinic);
//        }

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public void UpdatePoliclinic(Policlinic policlinic)
//        {
//            _context.Entry(policlinic).State = System.Data.Entity.EntityState.Modified;
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