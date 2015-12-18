//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using OnlineCoupone.Web.Models;

//namespace OnlineCoupone.Web.Repository
//{
//    public class TalonRepository : IDisposable
//    {
//        private ContextName _context;
//        private bool _disposed = false;

//        public TalonRepository(ContextName context)
//        {
//            _context = context;
//        }

//        public void DeleteTalon(int talonId)
//        {
//            Talon talon = _context.Talon.Find(talonId);
//            if (talon == null)
//            {
//                throw new ArgumentException();
//            }
//            _context.Talon.Remove(talon);
//        }

//        public Talon GetByID(int talonId)
//        {
//            return _context.Talon.Find(talonId);
//        }

//        public IEnumerable<Talon> Get()
//        {
//            return _context.Talon.ToList();
//        }

//        public void InsertTalon(Talon talon)
//        {
//            _context.Talon.Add(talon);
//        }

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public void UpdateTalon(Talon talon)
//        {
//            _context.Entry(talon).State = System.Data.Entity.EntityState.Modified;
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