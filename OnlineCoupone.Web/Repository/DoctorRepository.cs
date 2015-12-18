//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using OnlineCoupone.Web.Models;

//namespace OnlineCoupone.Web.Repository
//{
//    public class DoctorRepository : IDisposable
//    {
//        private ContextName _context;
//        private bool _disposed = false;

//        public DoctorRepository(ContextName context)
//        {
//            _context = context;
//        }

//        public void DeleteDoctor(int doctorId)
//        {
//            Doctor doctor = _context.Doctor.Find(doctorId);
//            if (doctor == null)
//            {
//                throw new ArgumentException();
//            }
//            _context.Doctor.Remove(doctor);
//        }

//        public Doctor GetByID(int doctorId)
//        {
//            return _context.Doctor.Find(doctorId);
//        }

//        public IEnumerable<Doctor> Get()
//        {
//            return _context.Doctor.ToList();
//        }

//        public void InsertDoctor(Doctor doctor)
//        {
//            _context.Doctor.Add(doctor);
//        }

//        public void Save()
//        {
//            _context.SaveChanges();
//        }

//        public void UpdateDoctor(Doctor doctor)
//        {
//            _context.Entry(doctor).State = System.Data.Entity.EntityState.Modified;
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